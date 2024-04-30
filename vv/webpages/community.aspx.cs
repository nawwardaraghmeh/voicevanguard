using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vv.web_pages
{
    public partial class community : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createPostbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/addpost.aspx");
        }

        protected void title1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/viewPost.aspx");
        }
    }
}