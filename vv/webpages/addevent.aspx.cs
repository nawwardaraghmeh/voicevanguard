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
            txtLink.Enabled = false;
            txtLink.BackColor = System.Drawing.Color.LightGray;

            txtLocation.Enabled = true;
            txtRoom.Enabled = true;
            txtLocation.BackColor = System.Drawing.Color.White;
            txtRoom.BackColor = System.Drawing.Color.White;
        }

        protected void rbtnVirtual_CheckedChanged(object sender, EventArgs e)
        {
            txtLink.Enabled = true;
            txtLink.BackColor = System.Drawing.Color.White;

            txtLocation.Enabled = false;
            txtRoom.Enabled = false;
            txtLocation.BackColor = System.Drawing.Color.LightGray;
            txtRoom.BackColor = System.Drawing.Color.LightGray;

        }


        protected void selectTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> selectedTags = new List<string>();
            foreach (ListItem item in selectTags.Items)
            {
                if (item.Selected)
                {
                    selectedTags.Add(item.Text);
                }
            }
            eventstagslabel.Text = "#" + string.Join(" #", selectedTags);
        }

    }
}