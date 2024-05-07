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

namespace vv.web_pages
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT name, dateCreated, profilePic, bannerPic FROM users WHERE userId = @userId";
            

            
            if (!IsPostBack)
            {
                
                if (Session["userId"] != null)
                {
                    string userId = Session["UserId"].ToString();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@userId", userId);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            
                            string name = reader["name"].ToString();
                            DateTime dateCreated = (DateTime)reader["dateCreated"];
                            string formattedDate = dateCreated.ToString("yyyy/MM/dd");
                            //Session["profilePic"] = reader["profilePic"].ToString();
                            //Session["bannerPic"] = reader["bannerPic"].ToString();

                            lblAccountName.Text = name;
                            lblJoinDate.Text = "Joined " + formattedDate;
                        }
                        reader.Close();
                    }
                }

                else
                {
                    Response.Redirect("~/webpages/login.aspx");
                }
                
                btnMyActivity.CssClass = "clickedBtn";
                MainView.ActiveViewIndex = 0;
            }

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

        /*
        protected void fileUploadBanner_Changed(object sender, EventArgs e)
        {
            if (fileUploadBanner.HasFile)
            {
                string fileName = Path.GetFileName(fileUploadBanner.FileName);
                string uploadPath = Server.MapPath("~/uploads/") + fileName;
                fileUploadBanner.SaveAs(uploadPath);

                // Update banner image path in database for the current user
                UpdateImagePathInDatabase("banner", uploadPath);
            }
        }

        protected void fileUploadProfile_Changed(object sender, EventArgs e)
        {
            if (fileUploadProfile.HasFile)
            {
                string fileName = Path.GetFileName(fileUploadProfile.FileName);
                string uploadPath = Server.MapPath("~/uploads/") + fileName;
                fileUploadProfile.SaveAs(uploadPath);

                // Update profile image path in database for the current user
                UpdateImagePathInDatabase("profile", uploadPath);
            }
        }

        protected void UpdateImagePathInDatabase(string imageType, string imagePath)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if(imageType == "profile")
                {
                    query = "update users set profilePic = @imagePath where userId = @userId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@imagePath", imagePath);
                    command.Parameters.AddWithValue("@userId", userId);
                }
            }

            }*/


    }
}