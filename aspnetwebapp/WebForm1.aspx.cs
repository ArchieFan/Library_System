using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspnetwebapp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            this.lblMessage.Text = "Your Registration is done successfully. Our team will contact you shotly";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowPopup();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "none", "<script>$(function () { $('#exampleModal').modal('show'); });</script>", false);
        }

        protected void ShowPopup(object sender, EventArgs e)
        {
            string title = "Greetings";
            string body = "Welcome to ASPSnippets.com";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
}