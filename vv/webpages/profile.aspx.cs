using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using vv.models;

namespace vv.web_pages
{
    public partial class profile : System.Web.UI.Page
    {
        private UserProfile userProfile = new UserProfile();
        Guid userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["userId"] != null)
                {
                    userId = new Guid(Session["UserId"].ToString());
 
                    userProfile.LoadFromDatabase(userId);

                    lblAccountName.Text = userProfile.Name;
                    lblJoinDate.Text = "Joined " + userProfile.DateCreated.ToString("yyyy/MM/dd");

                    imgProfilePic.ImageUrl = userProfile.ProfilePicturePath;
                    imgBannerPic.ImageUrl = userProfile.BannerPicturePath;
                }

                else
                {
                    Response.Redirect("~/webpages/login.aspx");
                }
                
                btnMyActivity.CssClass = "clickedBtn";
                MainView.ActiveViewIndex = 0;
            }
          

        }

       /* protected void UploadImage(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string pictureType = clickedButton.CommandName;

            FileUpload fileUpload = null;
            Image imageControl = null;

            if (pictureType == "ProfilePicture")
            {
                fileUpload = fileUploadProfilePic;
                imageControl = imgProfilePic;
            }
            else if (pictureType == "BannerPicture")
            {
                fileUpload = fileUploadBannerPic;
                imageControl = imgBannerPic;
            }

            if (fileUpload.HasFile)
            {
                HttpPostedFile postedFile = fileUpload.PostedFile;
                byte[] imageData = null;

                using (BinaryReader reader = new BinaryReader(postedFile.InputStream))
                {
                    imageData = reader.ReadBytes(postedFile.ContentLength);
                }

                imageControl.ImageUrl = "data:image;base64," + Convert.ToBase64String(imageData);

                if (pictureType == "ProfilePicture")
                {
                    SaveUserProfilePicture(userId, imageData);
                }
                else if (pictureType == "BannerPicture")
                {
                    SaveUserBannerPicture(userId, imageData);
                }
            }
        }

        protected void SaveUserProfilePicture(Guid userId, byte[] imageData)
        {
            // Update user profile picture in the database
            // Replace this with your actual database update logic
            string query = "UPDATE Users SET ProfilePicture = @ImageData WHERE UserId = @UserId";
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ImageData", imageData);
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void SaveUserBannerPicture(Guid userId, byte[] imageData)
        {
            // Update user banner picture in the database
            // Replace this with your actual database update logic
            string query = "UPDATE Users SET BannerPicture = @ImageData WHERE UserId = @UserId";
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ImageData", imageData);
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }*/

        protected void linkEditProfile_click(object sender, EventArgs e)
        {
            string url = "popups/editProfile.aspx";
            string script = "window.open('" + url + "', '_blank', 'width=500px,height=650px,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "openwindow", script, true);
        }




        protected void btnMyActivity_Click(object sender, EventArgs e)
        {
            btnMyActivity.CssClass = "clickedBtn";
            btnUpcomingEvents.CssClass = "initialBtn";
            MainView.ActiveViewIndex = 0;
        }

        protected void btnUpcomingEvents_Click(object sender, EventArgs e)
        {
            btnMyActivity.CssClass = "initialBtn";
            btnUpcomingEvents.CssClass = "clickedBtn";
            MainView.ActiveViewIndex = 1;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            // Check if the day has events and customize its appearance
            if (HasEventsOnDate(e.Day.Date))
            {
                e.Cell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#DE2B2B");
                e.Cell.BorderStyle = BorderStyle.Inset;

                // Create a hyperlink
                HyperLink eventLink = new HyperLink();
                //eventLink.Text = e.Day.DayNumberText;
                eventLink.Text = "CLIMATE ACTION RALLY";
                //eventLink.NavigateUrl = "EventDetails.aspx?date=" + e.Day.Date.ToShortDateString(); // Replace with your event details page URL
                eventLink.NavigateUrl = "~/webpages/viewevent.aspx";

                // Customize the appearance of the hyperlink
                eventLink.ForeColor = System.Drawing.ColorTranslator.FromHtml("#DE2B2B");
                eventLink.Font.Italic = true;

                // Add a line break before the hyperlink
                e.Cell.Controls.Add(new LiteralControl("<br />"));

                // Add the hyperlink to the cell
                e.Cell.Controls.Add(eventLink);
            }
        }

        private bool HasEventsOnDate(DateTime date)
        {
            // Check if there are events on the specified date
            // Replace this with your actual logic to determine if there are events on the given date
            return (date == new DateTime(2024, 5, 15) || date == new DateTime(2024, 5, 29));
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/login.aspx");
        }






    }
}