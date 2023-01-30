using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspnetwebapp
{
    public partial class adminbookissuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
            TextBox5.Text = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            TextBox6.Text = Convert.ToDateTime(DateTime.Now.AddDays(14)).ToString("yyyy-MM-dd");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfIssueEntryExist())
                {
                    string title = "INFO";
                    string body = "This Member already has this book";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                }
                else
                {
                    issueBook();
                }
            }
            else
            {
                string title = "INFO";
                string body = "Wrong Book ID or Member ID";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        private bool checkIfBookExist()
        {
            try
            {
                SqlConnection cn = new SqlConnection(strcon);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from tbl_book_master WHERE book_id=@book_id AND current_stock >0", cn);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
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
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                return false;
            }
        }

        private bool checkIfMemberExist()
        {
            try
            {
                SqlConnection cn = new SqlConnection(strcon);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                SqlCommand cmd = new SqlCommand("select full_name from tbl_member_master WHERE member_id=@member_id;", cn);
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
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
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                return false;
            }

        }

        private bool checkIfIssueEntryExist()
        {
            try
            {
                SqlConnection cn = new SqlConnection(strcon);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from tbl_book_issue WHERE member_id=@member_id AND book_id=@book_id;", cn);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
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
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                return false;
            }
        }

        private void issueBook()
        {
            try
            {
                SqlConnection cn = new SqlConnection(strcon);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_book_issue(member_id,member_name,book_id,book_name,issue_date,due_date) values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", cn);
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update  tbl_book_master set current_stock = current_stock-1 WHERE book_id=@book_id", cn);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.ExecuteNonQuery();
                cn.Close();
                string title = "INFO";
                string body = "Book Issued Successfully";
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {

                if (checkIfIssueEntryExist())
                {
                    returnBook();
                }
                else
                {
                    string title = "INFO";
                    string body = "This Entry does not exist";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                }
            }
            else
            {
                string title = "INFO";
                string body = "Wrong Book ID or Member ID";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        private void returnBook()
        {
            try
            {
                SqlConnection cn = new SqlConnection(strcon);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                SqlCommand cmd = new SqlCommand("Delete from tbl_book_issue WHERE book_id=@book_id AND member_id=@member_id;", cn);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    cmd = new SqlCommand("update tbl_book_master set current_stock = current_stock+1 WHERE book_id=@book_id;", cn);
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    string title = "INFO";
                    string body = "Book Returned Successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                    GridView1.DataBind();
                    clearForm();
                }
                else
                {
                    string title = "INFO";
                    string body = "Error - Invalid details";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                }
            }
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();
        }
        private void getNames()
        {
            try
            {
                SqlConnection cn = new SqlConnection(strcon);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                SqlCommand cmd = new SqlCommand("select book_name from tbl_book_master WHERE book_id=@book_id;", cn);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    string title = "INFO";
                    string body = "Wrong Book ID";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                }
                cmd = new SqlCommand("select full_name from tbl_member_master WHERE member_id=@member_id;", cn);
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    string title = "INFO";
                    string body = "Wrong User ID";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                }
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
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox1.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            TextBox6.Text = Convert.ToDateTime(DateTime.Now.AddDays(14)).ToString("yyyy-MM-dd");
        }
    }
}