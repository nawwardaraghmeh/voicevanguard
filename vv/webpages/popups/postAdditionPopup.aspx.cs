using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vv.webpages.popups
{
    public partial class postAdditionPopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dataReceived = Request.QueryString["data"];
                if (!string.IsNullOrEmpty(dataReceived))
                {
                    lblPostAdditionPopup.Text = dataReceived;
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "closewindow", "window.close();", true);
        }
    }
}