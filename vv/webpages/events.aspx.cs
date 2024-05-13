using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using vv.models;

namespace vv.web_pages
{
    public partial class events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] != null)
                {

                }
                else
                {
                    Response.Redirect("~/webpages/login.aspx");
                }
            }
        }

        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/addevent.aspx");
        }

        protected void btnLearnMore_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/viewevent.aspx");
        }
    }
}