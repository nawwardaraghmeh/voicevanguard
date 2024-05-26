using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
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
            if (Session["userId"] != null)
            {
                userId = new Guid(Session["UserId"].ToString());

                if (!IsPostBack)
                {
                    loadUserData(userId);
                    btnMyActivity.CssClass = "clickedBtn";
                    MainView.ActiveViewIndex = 0;
                }
                else if (Session["ProfileUpdated"] != null && (bool)Session["ProfileUpdated"])
                {
                    loadUserData(userId);
                    Session["ProfileUpdated"] = false; // reset the session variable
                }
            }
            else
            {
                Response.Redirect("~/webpages/login.aspx");
            }

        }

        protected void loadUserData(Guid id)
        {
            userProfile.LoadFromDatabase(userId);

            lblAccountName.Text = userProfile.Name;
            lblAccountUsername.Text = userProfile.Username;
            lblJoinDate.Text = "Joined " + userProfile.DateCreated.ToString("yyyy/MM/dd");
            lblUserInterests.Text = "Interests: " + userProfile.interests.ToString();
            imgProfilePic.ImageUrl = userProfile.ProfilePicturePath;
            imgBannerPic.ImageUrl = userProfile.BannerPicturePath;
            
        }

        protected void linkEditProfile_click(object sender, EventArgs e)
        {
            string url = "popups/editProfile.aspx";
            string script = "window.open('" + url + "', '_blank', 'toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');";
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
            Guid userId = GetUserIdFromSession(); 

            List<Guid> subscribedEventIds = GetUserEventIds(userId);
            List<Guid> createdEventIds = GetEventIdsUserCreated(userId);

            foreach (Guid eventId in subscribedEventIds)
            {
                EventTemp eventData = GetEventData(eventId);
                if (eventData != null && eventData.eventDate == e.Day.Date)
                {
                    RenderEventInCell(e.Cell, eventData, "#DE2B2B"); 
                }
            }

            foreach (Guid eventId in createdEventIds)
            {
                EventTemp eventData = GetEventData(eventId);
                if (eventData != null && eventData.eventDate == e.Day.Date)
                {
                    RenderEventInCell(e.Cell, eventData, "#7BCC98"); 
                }
            }
        }

        private void RenderEventInCell(TableCell cell, EventTemp eventData, string borderColor)
        {
            cell.BorderColor = System.Drawing.ColorTranslator.FromHtml(borderColor);
            cell.BorderStyle = BorderStyle.Inset;

            HyperLink eventLink = new HyperLink
            {
                Text = eventData.eventTitle.ToUpper(),
                NavigateUrl = $"~/webpages/viewevent.aspx?eventId={eventData.eventId}",
                ForeColor = System.Drawing.ColorTranslator.FromHtml(borderColor),
                Font = { Italic = true }
            };

            cell.Controls.Add(new LiteralControl("<br />"));
            cell.Controls.Add(eventLink);
        }

        private EventTemp GetEventData(Guid id)
        {
            EventTemp eventDetails = null;
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT eventTitle, eventDate FROM event WHERE eventId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            eventDetails = new EventTemp
                            {
                                eventTitle = reader["eventTitle"].ToString(),
                                eventDate = (DateTime)reader["eventDate"],
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return eventDetails;
        }

        private List<Guid> GetUserEventIds(Guid userId)
        {
            List<Guid> eventIds = new List<Guid>();

            if (userId == Guid.Empty)
            {
                return eventIds; 
            }

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT eventId FROM participants WHERE userId = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            eventIds.Add((Guid)reader["eventId"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return eventIds;
        }

        private List<Guid> GetEventIdsUserCreated(Guid userId)
        {
            List<Guid> eventIds = new List<Guid>();

            if (userId == Guid.Empty)
            {
                return eventIds; 
            }

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT eventId FROM event WHERE eventOrganizer = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            eventIds.Add((Guid)reader["eventId"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return eventIds;
        }

        private Guid GetUserIdFromSession()
        {
            if (Session["UserId"] != null && Guid.TryParse(Session["UserId"].ToString(), out Guid userId))
            {
                return userId;
            }
            else
            {
                return Guid.Empty; 
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/login.aspx");
        }


    }
}