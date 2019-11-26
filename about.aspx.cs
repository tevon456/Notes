using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Notes
{
    public partial class about : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["Version"] != null)
            {
                VersionLabel.Text = Application["Version"].ToString() + " version from state." ;
            }

            if (Application["Creators"] != null)
            {
                Creators.Text = Application["Creators"].ToString();
            }
        }
    }
}