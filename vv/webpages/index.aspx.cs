﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vv.web_pages
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void mainbtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/login.aspx");
        }

        protected void mainbtnSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/Registration.aspx");
        }
    }
}