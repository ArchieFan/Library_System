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
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }

        private void getMemberByID()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_getmember @member_id;", cn);
                    cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TextBox2.Text = dr["full_name"].ToString(); //dr.GetValue(0).ToString();
                            TextBox7.Text = dr["account_status"].ToString(); //dr.GetValue(10).ToString();
                            TextBox8.Text = dr["dob"].ToString(); //dr.GetValue(1).ToString();
                            TextBox3.Text = dr["contact_no"].ToString(); //dr.GetValue(2).ToString();
                            TextBox4.Text = dr["email"].ToString(); //dr.GetValue(3).ToString();
                            TextBox9.Text = dr["state"].ToString(); //dr.GetValue(4).ToString();
                            TextBox10.Text = dr["city"].ToString(); //dr.GetValue(5).ToString();
                            TextBox11.Text = dr["pincode"].ToString(); //dr.GetValue(6).ToString();
                            TextBox6.Text = dr["full_address"].ToString(); //dr.GetValue(7).ToString();
                        }
                    }
                    else
                    {
                        string title = "INFO";
                        string body = "Invalid credentials";
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("active");
        }

        private void updateMemberStatusByID(string status)
        {
            if (checkIfMemberExists())
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(strcon))
                    {
                        if (cn.State == ConnectionState.Closed)
                        {
                            cn.Open();
                        }
                        SqlCommand cmd = new SqlCommand("exec dbo.sp_updatememberstatus @member_id, @status; ", cn);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                    GridView1.DataBind();
                    string title = "INFO";
                    string body = "Member Status Updated";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                }
                catch (Exception ex)
                {
                    string title = "ERROR";
                    string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                }
            }
            else
            {
                string title = "INFO";
                string body = "Invalid Member ID";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        private bool checkIfMemberExists()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_getmember @member_id;", cn);
                    cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
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

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("pending");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("deactive");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteMemberByID();
        }

        private void deleteMemberByID()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(strcon))
                    {
                        if (cn.State == ConnectionState.Closed)
                        {
                            cn.Open();
                        }
                        SqlCommand cmd = new SqlCommand("exec dbo.sp_deletemember @member_id", cn);
                        cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                    string title = "INFO";
                    string body = "Member Deleted Successfully";
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
            else
            {
                string title = "INFO";
                string body = "Invalid Member ID";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        private void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }

    }
}