using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vv.webpages
{
    public partial class resetPasswordPageOne : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cancelHlink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/login.aspx");
        }
    }
}