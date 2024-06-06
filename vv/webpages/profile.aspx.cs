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
                    PopulateActivitiesTab();
                }
                else if (Session["ProfileUpdated"] != null && (bool)Session["ProfileUpdated"])
                {
                    loadUserData(userId);
                    Session["ProfileUpdated"] = false; 
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
            PopulateActivitiesTab();
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
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string sqlQuery = "SELECT eventId FROM participants WHERE userId = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Guid.TryParse(reader["eventId"].ToString(), out Guid eventId))
                    {
                        eventIds.Add(eventId);
                    }
                }
            }

            return eventIds;
        }


        private List<Guid> GetEventIdsUserCreated(Guid userId)
        {
            List<Guid> eventIds = new List<Guid>();
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string sqlQuery = "SELECT eventId FROM event WHERE eventOrganizer = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Guid.TryParse(reader["eventId"].ToString(), out Guid eventId))
                    {
                        eventIds.Add(eventId);
                    }
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

        public void PopulateActivitiesTab()
        {
            Guid userId = GetUserIdFromSession();

            List<Guid> eventNotifIds = getUserEventNotifIds(userId);
            List<Guid> postNotifIds = getUserPostNotifIds(userId);

            if (postNotifIds == null && eventNotifIds == null)
            {
                Label notifLabel = new Label();
                notifLabel.Text = "No activity yet!";
                notifLabel.CssClass = "noActLabel";
                activitiesPanel.Controls.Add(notifLabel);
            }

            if (eventNotifIds != null && eventNotifIds.Count > 0)
            {
                foreach (Guid id in eventNotifIds)
                {
                    NotifTemp notif = LoadEventNotifContent(id);
                    if (notif != null)
                    {
                        populateActivityContainer(notif);
                    }
                }
            }
            if (postNotifIds != null && postNotifIds.Count > 0)
            {
                foreach (Guid id in postNotifIds)
                {
                    NotifTemp notif = LoadPostNotifContent(id);
                    if (notif != null)
                    {
                        populateActivityContainer(notif);
                    }
                }
            }
        }

        public void populateActivityContainer(NotifTemp notif)
        {
            Panel actPanel = new Panel();
            actPanel.CssClass = "tabDiv";

            LiteralControl divStart = new LiteralControl("<div class=\"activityDiv\">");
            LiteralControl divEnd = new LiteralControl("</div>");

            actPanel.Controls.Add(divStart);

            Label actLabel = new Label();
            HyperLink link = new HyperLink();
            switch (notif.notifType)
            {
                case "EventAddition":
                    actLabel.Text = "You created a new event: ";
                    link = getEventHyperLink(notif.EventId);
                    break;
                case "EventSubscription":
                    actLabel.Text = "You added an event to your calendar: ";
                    link = getEventHyperLink(notif.EventId);
                    break;
                case "EventInterested":
                    actLabel.Text = "1 person is interested in your event: ";
                    link = getEventHyperLink(notif.EventId);
                    break;
                case "PostAdded":
                    actLabel.Text = "You added a post!";
                    link = getPostHyperLink(notif.PostId);
                    break;
            }

            actPanel.Controls.Add(actLabel);
            actPanel.Controls.Add(link);

            actPanel.Controls.Add(divEnd);

            activitiesPanel.Controls.AddAt(0, actPanel);
        }
    
        public HyperLink getEventHyperLink(Guid eventId)
        {
            HyperLink eventPage = new HyperLink();
            string url = $"~/webpages/viewevent.aspx?eventId={eventId}";
            eventPage.NavigateUrl = url;
            eventPage.Text = GetEventTitle(eventId).ToUpper();
            eventPage.CssClass = "eventLink";
            return eventPage;
        }

        public HyperLink getPostHyperLink(Guid postId)
        {
            HyperLink eventPage = new HyperLink();
            string url = $"~/webpages/viewPost.aspx?postId={postId}";
            eventPage.NavigateUrl = url;
            eventPage.Text = GetPostTitle(postId).ToUpper();
            eventPage.CssClass = "eventLink";
            return eventPage;
        }

        public List<Guid> getUserEventNotifIds(Guid userid)
        {
            List<Guid> notifIds = new List<Guid>();
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string sqlQuery = "SELECT top 5 notifId FROM notification WHERE userId = @userid and eventId IS NOT NULL order by notifDate DESC, notifTime";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@userid", userid);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    notifIds.Add((Guid)reader["notifId"]);
                }
            }

            return notifIds;
        }

        public List<Guid> getUserPostNotifIds(Guid userid)
        {
            List<Guid> notifIds = new List<Guid>();
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string sqlQuery = "SELECT top 5 notifId FROM notification WHERE userId = @userid and postId IS NOT NULL order by notifDate DESC, notifTime";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@userid", userid);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    notifIds.Add((Guid)reader["notifId"]);
                }
            }

            return notifIds;
        }

        private NotifTemp LoadEventNotifContent(Guid notifId)
        {
            NotifTemp notifContent = null;

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT * FROM notification WHERE notifId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", notifId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    notifContent = new NotifTemp();
                    notifContent.NotifId = (Guid)reader["notifId"];
                    notifContent.EventId = (Guid)reader["eventId"];
                    notifContent.notifType = reader["notifType"].ToString();
                }

                reader.Close();
                connection.Close();
            }

            return notifContent;
        }

        private NotifTemp LoadPostNotifContent(Guid notifId)
        {
            NotifTemp notifContent = null;

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT * FROM notification WHERE notifId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", notifId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    notifContent = new NotifTemp();
                    notifContent.NotifId = (Guid)reader["notifId"];
                    notifContent.PostId = (Guid)reader["postId"];
                    notifContent.notifType = reader["notifType"].ToString();
                }

                reader.Close();
                connection.Close();
            }

            return notifContent;
        }

        private string GetEventTitle(Guid eventId)
        {
            string eventTitle = "";
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT eventTitle FROM event WHERE eventId = @eventId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@eventId", eventId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    eventTitle = reader["eventTitle"].ToString();
                }
            }

            return eventTitle;
        }

        private string GetPostTitle(Guid postId)
        {
            string postTitle = "";
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT postTitle FROM post WHERE postId = @postId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@postId", postId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    postTitle = reader["postTitle"].ToString();
                }
            }

            return postTitle;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/login.aspx");
        }


    }
}