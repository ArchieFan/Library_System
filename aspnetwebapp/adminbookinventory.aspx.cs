using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspnetwebapp
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_sold_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
            }
            GridView1.DataBind();
        }

        private void fillAuthorPublisherValues()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_builddropdownauthor ", cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DropDownList3.DataSource = dt;
                    DropDownList3.DataValueField = "author_name";
                    DropDownList3.DataBind();

                    cmd = new SqlCommand("exec dbo.sp_builddropdownpublisher ", cn);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    DropDownList2.DataSource = dt;
                    DropDownList2.DataValueField = "publisher_name";
                    DropDownList2.DataBind();
                }

            }
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getBookByID();
        }

        private void getBookByID()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_getbook @book_id;", cn);
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                        TextBox3.Text = Convert.ToDateTime(dt.Rows[0]["publish_date"]).ToString("yyyy-MM-dd");
                        TextBox9.Text = dt.Rows[0]["edition"].ToString();
                        TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                        TextBox11.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                        TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                        TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                        TextBox6.Text = dt.Rows[0]["book_description"].ToString();
                        TextBox7.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                        if (DropDownList1.Items.FindByText(dt.Rows[0]["language"].ToString().Trim()) != null)
                        {
                            DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                        }
                        if (DropDownList2.Items.FindByText(dt.Rows[0]["publisher_name"].ToString().Trim()) != null)
                        {
                            DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                        }
                        if (DropDownList3.Items.FindByText(dt.Rows[0]["author_name"].ToString().Trim()) != null)
                        {
                            DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                        }

                        ListBox1.ClearSelection();
                        string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                        for (int i = 0; i < genre.Length; i++)
                        {
                            for (int j = 0; j < ListBox1.Items.Count; j++)
                            {
                                if (ListBox1.Items[j].ToString() == genre[i])
                                {
                                    ListBox1.Items[j].Selected = true;

                                }
                            }
                        }
                        global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                        global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                        global_sold_books = global_actual_stock - global_current_stock;
                        global_filepath = dt.Rows[0]["book_img_link"].ToString();
                    }
                    else
                    {
                        string title = "INFO";
                        string body = "Invalid Book ID";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                        clearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }

        private void updateBookByID()
        {
            string title = "";
            string body = "";
            if (checkIfBookExists())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox5.Text.Trim());
                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_sold_books)
                        {
                            title = "INFO";
                            body = "Actual Stock value cannot be less than the Sold books";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_sold_books;
                            TextBox5.Text = "" + current_stock;
                        }
                    }
                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    if (genres.Length > 0)
                    {
                        genres = genres.Remove(genres.Length - 1);
                    }
                    else
                    {
                        genres = "";
                    }
                    string filepath = "~/book_inventory/books1";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }
                    using (SqlConnection cn = new SqlConnection(strcon))
                    {
                        if (cn.State == ConnectionState.Closed)
                        {
                            cn.Open();
                        }
                        SqlCommand cmd = new SqlCommand("exec dbo.sp_updatebook @book_id, @book_name, @genre, @author_name, @publisher_name, @publish_date, @language, @edition, @book_cost, @no_of_pages, @book_description, @actual_stock, @current_stock, @book_img_link ", cn);
                        cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@genre", genres);
                        cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                        cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                        cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                        cmd.Parameters.AddWithValue("@book_img_link", filepath);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                    GridView1.DataBind();
                    clearForm();
                    title = "INFO";
                    body = "Book Updated Successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                }
                catch (Exception ex)
                {
                    title = "ERROR";
                    body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                }
            }
            else
            {
                title = "INFO";
                body = "Invalid Book ID";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        private bool checkIfBookExists()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_checkbook @book_id, @book_name;", cn);
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                return false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteBookByID();
        }

        private void deleteBookByID()
        {
            string title = "";
            string body = "";
            if (checkIfBookExists())
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(strcon))
                    {
                        if (cn.State == ConnectionState.Closed)
                        {
                            cn.Open();
                        }
                        SqlCommand cmd = new SqlCommand("exec dbo.sp_deletebook @book_id ", cn);
                        cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                        cmd.ExecuteNonQuery();
                        cn.Close();

                    }

                    title = "INFO";
                    body = "Book Deleted Successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                    GridView1.DataBind();
                    clearForm();
                }
                catch (Exception ex)
                {
                    title = "ERROR";
                    body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                }
            }
            else
            {
                title = "INFO";
                body = "Invalid Member ID";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                string title = "INFO";
                string body = "Book Already Exists, try some other Book ID";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
            else
            {
                addNewBook();
            }
        }

        private void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
                if (genres.Length > 0)
                {
                    genres = genres.Remove(genres.Length - 1);
                }
                else
                {
                    genres = "";
                }
                string filepath = "~/book_inventory/books1.png";
                if (FileUpload1.PostedFile.FileName.Trim() != "")
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_insertbook @book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link ", cn);
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                string title = "INFO";
                string body = "Book added successfully.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                GridView1.DataBind();
                clearForm();
            }
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        private void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox4.Text = "0";
            TextBox5.Text = "0";
            TextBox6.Text = "";
            TextBox7.Text = "0";
            //for (int j = 0; j < ListBox1.Items.Count; j++)
            //{
            //        ListBox1.Items[j].Selected = false;
            //}
            ListBox1.ClearSelection();
            DropDownList1.SelectedIndex = 1;
            DropDownList2.SelectedIndex = 1;
            DropDownList3.SelectedIndex = 1;
        }



    }
}