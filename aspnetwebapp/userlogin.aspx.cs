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
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetMemberID() != "")
                {
                    Response.Redirect("home.aspx");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        private string GetMemberID()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_checkmemberauth @member_id, @password ", cn);
                    cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Session["username"] = dr["member_id"].ToString();
                            Session["fullname"] = dr["full_name"].ToString();
                            Session["role"] = "user";
                            Session["status"] = dr["account_status"].ToString();
                            return dr["member_id"].ToString();
                        }
                    }
                    else
                    {
                        string title = "INFO";
                        string body = "Invlid Credentials";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                        return "";
                    }
                }

            }
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                return "";
            }
            return "";
        }
    }
}