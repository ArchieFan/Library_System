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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                Response.Write("<script>alert('');</script>");
                string title = "INFO";
                string body = "Publisher Already Exist with this ID.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);

            }
            else
            {
                addNewPublisher();
            }
        }

        private bool checkPublisherExists()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_getpublisher @publisher_id", cn);
                    cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
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

        private void addNewPublisher()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_insertpublisher @publisher_id,@publisher_name ", cn);
                    cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                string title = "INFO";
                string body = "Publisher added successfully.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                clearForm();
                GridView1.DataBind();
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
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                updatePublisherByID();
            }
            else
            {
                string title = "INFO";
                string body = "Publisher with this ID does not exist";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        public void updatePublisherByID()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_updatepublisher @publisher_id, @publisher_name ", cn);
                    cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                    int result = cmd.ExecuteNonQuery();
                    cn.Close();
                    if (result > 0)
                    {
                        string title = "INFO";
                        string body = "Publisher Updated Successfully";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                        clearForm();
                        GridView1.DataBind();
                    }
                    else
                    {
                        string title = "INFO";
                        string body = "Publisher ID does not Exist";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                deletePublisherByID();
            }
            else
            {
                string title = "INFO";
                string body = "Publisher with this ID does not exist";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        public void deletePublisherByID()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_deletepublisher @publisher_id; ", cn);
                    cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                    int result = cmd.ExecuteNonQuery();
                    cn.Close();
                    if (result > 0)
                    {
                        string title = "INFO";
                        string body = "Publisher Deleted Successfully";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                        clearForm();
                        GridView1.DataBind();
                    }
                    else
                    {
                        string title = "INFO";
                        string body = "Publisher ID does not Exist";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            getPublisherByID();
        }

        private void getPublisherByID()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_getpublisher @publisher_id;", cn);
                    cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        //TextBox2.Text = dt.Rows[0][1].ToString();
                        foreach (DataRow row1 in dt.Rows)
                        {
                            TextBox2.Text = row1["publisher_name"].ToString();
                        }
                    }
                    else
                    {
                        string title = "INFO";
                        string body = "Publisher with this ID does not exist.";
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

    }
}