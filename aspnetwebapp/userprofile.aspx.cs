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
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    string title = "INFO";
                    string body = "Session Expired Login Again";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();
                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = "Session Expired Login Again!" + Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                Response.Redirect("userlogin.aspx");
            }
        }

        private void getUserBookData()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_getbookissuefrommember @member_id;", cn);
                    cmd.Parameters.AddWithValue("@member_id", Session["username"].ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

            }
            catch (Exception ex)
            {
                string title = "ERROR";
                string body = Server.HtmlEncode(ex.Message.Replace("\r\n", " "));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
            }
        }

        private void getUserPersonalDetails()
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
                    cmd.Parameters.AddWithValue("@member_id", Session["username"].ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                    TextBox2.Text = Convert.ToDateTime(dt.Rows[0]["dob"]).ToString("yyyy-MM-dd");
                    TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
                    TextBox4.Text = dt.Rows[0]["email"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["city"].ToString();
                    TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                    TextBox5.Text = dt.Rows[0]["full_address"].ToString();
                    TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                    Label9.Text = dt.Rows[0]["password"].ToString();
                    Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();
                    if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                    {
                        Label1.Attributes.Add("class", "badge rounded-pill bg-success");
                    }
                    else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                    {
                        Label1.Attributes.Add("class", "badge rounded-pill bg-warning");
                    }
                    else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                    {
                        Label1.Attributes.Add("class", "badge rounded-pill bg-danger");
                    }
                    else
                    {
                        Label1.Attributes.Add("class", "badge rounded-pill bg-info");
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
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                string title = "INFO";
                string body = "Session Expired Login Again";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUserPersonalDetails();

            }
        }

        private void updateUserPersonalDetails()
        {
            string password = "";
            if (TextBox10.Text.Trim() == "")
            {
                password = Label9.Text.Trim();
            }
            else
            {
                password = TextBox10.Text.Trim();
            }
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("exec dbo.sp_updatemember @member_id, @full_name, @dob, @contact_no, @email, @state, @city, @pincode, @full_address, @password, @account_status;", cn);
                    cmd.Parameters.AddWithValue("@member_id", Session["username"].ToString());
                    cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@account_status", "pending");
                    int result = cmd.ExecuteNonQuery();
                    cn.Close();
                    if (result > 0)
                    {
                        string title = "INFO";
                        string body = "Your Details Updated Successfully";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowMsg('" + title + "', '" + body + "');", true);
                        getUserPersonalDetails();
                        getUserBookData();
                    }
                    else
                    {
                        string title = "INFO";
                        string body = "Invaid entry";
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


    }
}