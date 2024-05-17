using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vv.models;

namespace vv.webpages.popups
{
    public partial class editProfile : System.Web.UI.Page
    {
        Guid UserId;
        List<string> selectedTags = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void selectTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in selectTags.Items)
            {
                if (item.Selected)
                {
                    selectedTags.Add(item.Text);
                }
            }
            showInterestlbl.Text = "#" + string.Join(" #", selectedTags);
        }

        protected void closebtn_click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "closewindow", "window.close();", true);
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {

            UserProfile profile = new UserProfile();

            Guid userId = new Guid(Session["UserId"].ToString());
            String bannerPic = changeBanner.ToString();
            String profilePic = changePfp.ToString();
            String username = changeUsername.Text;
            String name = changeName.Text;

            foreach (ListItem item in selectTags.Items)
            {
                if (item.Selected)
                {
                    selectedTags.Add(item.Text);
                }
            }
            string tags = string.Join(",", selectedTags);

            if(bannerPic != null)
            {
                profile.UpdateBannerPicture(userId, bannerPic);
            }

            if (profilePic != null)
            {
                profile.UpdateProfilePicture(userId, profilePic);
            }

            if (username != null)
            {
                profile.UpdateUsername(userId, username);
            }

            if (name != null)
            {
                profile.UpdateName(userId, name);
            }

            if (tags != null)
            {
                profile.UpdateInterest(userId, tags);
            }
        }
    }
}