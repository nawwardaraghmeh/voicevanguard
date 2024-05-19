using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
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
            string eventTags = string.Join(",", selectedTags);
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
            String name = changeName.Text;

            foreach (ListItem item in selectTags.Items)
            {
                if (item.Selected)
                {
                    selectedTags.Add(item.Text);
                }
            }
            string tags = string.Join(",", selectedTags);

            if(changeBanner.HasFile)
            {
                string folderPath = Server.MapPath("~/Uploads/");

                // Create the directory if it does not exist
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = Path.GetFileName(changeBanner.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                changeBanner.SaveAs(filePath); 
                string relativePath = "~/Uploads/" + fileName;

                profile.UpdateBannerPicture(userId, relativePath);
            }

            if (changePfp.HasFile)
            {
                string folderPath = Server.MapPath("~/Uploads/");

                // Create the directory if it does not exist
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = Path.GetFileName(changePfp.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                changePfp.SaveAs(filePath); 
                string relativePath = "~/Uploads/" + fileName;

                profile.UpdateProfilePicture(userId, relativePath);
            }


            if (name != "")
            {
                profile.UpdateName(userId, name);
            }

            if (tags != "")
            {
                profile.UpdateInterest(userId, tags);
            }


            ClientScript.RegisterStartupScript(this.GetType(), "closewindow", "window.close();", true);
            Response.Redirect("~/webpages/profile.aspx");
        }
    }
}