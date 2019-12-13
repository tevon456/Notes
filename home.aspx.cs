using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Notes
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessionUser"] == null)
            {
                Response.Redirect("index.aspx");
            }
            Title.Text = "Example note title";
            Note.Text = "Example note body content";
        }

        protected void LinkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("index.aspx");
        }

        protected void SaveNote_Click(object sender, EventArgs e)
        {

        }
    }
}