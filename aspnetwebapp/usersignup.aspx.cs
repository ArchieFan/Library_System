using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Messaging;

namespace aspnetwebapp
{
    public partial class usersignup : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                string title = "INFO";
                string body = "Member Already Exist with this Member ID, try other ID";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
            else
            {
                signUpNewMember();
            }
        }

        // user defined method
        private bool checkMemberExists()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_getmember @member_id", cn);
                    cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
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

        private void signUpNewMember()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_insertmember @member_id, @full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@password,@account_status", cn);
                    cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@account_status", "pending");
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                string title = "INFO";
                string body = "Sign Up Successful. Go to User Login to Login";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
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
            TextBox4.Text = "";
            DropDownList1.SelectedIndex = 0;
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox5.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }

    }
}