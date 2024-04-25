using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vv.webpages
{
    public partial class addevent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rbtnPhysical_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPhysical.Checked == true) txtLink.Enabled = false;
        }

        protected void rbtnVirtual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnVirtual.Checked == true)
            {
                txtLocation.Enabled = false;
                hlinkAddRoom.Enabled = false;
            }
        }
    }
}