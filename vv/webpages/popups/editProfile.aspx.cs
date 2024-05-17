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
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (changeBanner.HasFile)
                {
                    string bannerImagePath = "~/resources/Banners/" + changeBanner.FileName;
                    string updateBannerQuery = "UPDATE users SET bannerPic = @BannerImagePath WHERE UserId = @UserId";

                    using (SqlCommand command = new SqlCommand(updateBannerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BannerImagePath", bannerImagePath);
                        command.Parameters.AddWithValue("@UserId", UserId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}