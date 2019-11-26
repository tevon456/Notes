using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Notes
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["sessionAdmin"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void LinkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("index.aspx");
        }
    }
}