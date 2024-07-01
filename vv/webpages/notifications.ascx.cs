using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using vv.models;
using vv.web_pages;

namespace vv.webpages
{
    public partial class notifications : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid userId = new Guid(Session["UserId"].ToString());

            List<Guid> eventNotifIds = getUserEventNotifIds(userId);
            List<Guid> postNotifIds = getUserPostNotifIds(userId);

            List<NotifTemp> allNotifications = new List<NotifTemp>();

            if (eventNotifIds != null && eventNotifIds.Count > 0)
            {
                foreach (Guid id in eventNotifIds)
                {
                    NotifTemp notif = LoadEventNotifContent(id);
                    if (notif != null) allNotifications.Add(notif);
                }
            }

            if (postNotifIds != null && postNotifIds.Count > 0)
            {
                foreach (Guid id in postNotifIds)
                {
                    NotifTemp notif = LoadPostNotifContent(id);
                    if (notif != null) allNotifications.Add(notif);
                }
            }

            if (allNotifications.Count > 0)
            {
                emptynotif.Visible = false;

                var topNotifications = allNotifications
                    .OrderByDescending(n => n.NotifDate)
                    .Take(6)
                    .ToList();

                foreach (var notif in topNotifications)
                {
                    populateNotifContainer(notif);
                }
            }
            else
            {
                Label notifLabel = new Label();
                notifLabel.Text = "No notifications!";
                notifLabel.CssClass = "noNotifText";
                notifheroContainer.Controls.Add(notifLabel);
            }
        }

        public void populateNotifContainer(NotifTemp notif)
        {
            if (notif != null)
            {
                Panel notifPanel = new Panel();
                notifPanel.CssClass = "notifTemp";

                Image notifImage = new Image();
                switch (notif.notifType)
                {
                    case "EventAddition":
                        notifImage.ImageUrl = "~/resources/images/eventadd.png";
                        break;
                    case "EventSubscription":
                        notifImage.ImageUrl = "~/resources/images/eventsub.png";
                        break;
                    case "EventInterested":
                        notifImage.ImageUrl = "~/resources/images/eventinterest.png";
                        break;
                    case "PostAdded":
                        notifImage.ImageUrl = "~/resources/images/postadded.png";
                        break;
                    case "CommentAddition":
                        notifImage.ImageUrl = "~/resources/images/addcomment.png";
                        break;
                    case "CommentAddedtoPost":
                        notifImage.ImageUrl = "~/resources/images/commentadded.png";
                        break;
                    case "EventCancellation":
                        notifImage.ImageUrl = "~/resources/images/eventCancel.png";
                        break;
                }
                notifPanel.Controls.Add(notifImage);

                LiteralControl divStart = new LiteralControl("<div class=\"notifTextDiv\">");
                LiteralControl divEnd = new LiteralControl("</div>");

                notifPanel.Controls.Add(divStart);

                Label notifLabel = new Label();
                switch (notif.notifType)
                {
                    case "EventAddition":
                        notifLabel.Text = "You added an event! ";
                        break;
                    case "EventSubscription":
                        notifLabel.Text = "You subscribed to an event!";
                        break;
                    case "EventInterested":
                        notifLabel.Text = "1 person is interested in your event!";
                        break;
                    case "PostAdded":
                        notifLabel.Text = "You added a post!";
                        break;
                    case "CommentAddition":
                        notifLabel.Text = "You added a comment!";
                        break;
                    case "CommentAddedtoPost":
                        notifLabel.Text = "1 person commented on your post!";
                        break;
                    case "EventCancellation":
                        notifLabel.Text = "1 event you subscribed to got deleted got deleted.";
                        break;
                }

                notifPanel.Controls.Add(notifLabel);
                notifPanel.Controls.Add(divEnd);

                notifheroContainer.Controls.AddAt(0, notifPanel);
            }
        }

        public List<Guid> getUserEventNotifIds(Guid userid)
        {
            List<Guid> notifIds = new List<Guid>();
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string sqlQuery = "SELECT notifId FROM notification WHERE userId = @userid AND eventId IS NOT NULL ORDER BY notifDate DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@userid", userid);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Guid.TryParse(reader["notifId"].ToString(), out Guid notifId))
                    {
                        notifIds.Add(notifId);
                    }
                }
            }

            return notifIds;
        }

        public List<Guid> getUserPostNotifIds(Guid userid)
        {
            List<Guid> notifIds = new List<Guid>();
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string sqlQuery = "SELECT notifId FROM notification WHERE userId = @userid AND postId IS NOT NULL ORDER BY notifDate DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@userid", userid);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Guid.TryParse(reader["notifId"].ToString(), out Guid notifId))
                    {
                        notifIds.Add(notifId);
                    }
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
                    notifContent = new NotifTemp
                    {
                        NotifId = reader.GetGuid(reader.GetOrdinal("notifId")),
                        notifType = reader["notifType"]?.ToString(),
                        NotifDate = reader.GetDateTime(reader.GetOrdinal("notifDate"))
                    };

                    if (reader["eventId"] != DBNull.Value)
                    {
                        notifContent.EventId = reader.GetGuid(reader.GetOrdinal("eventId"));
                    }
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
                    notifContent = new NotifTemp
                    {
                        NotifId = reader.GetGuid(reader.GetOrdinal("notifId")),
                        notifType = reader["notifType"]?.ToString(),
                        NotifDate = reader.GetDateTime(reader.GetOrdinal("notifDate"))
                    };

                    if (reader["postId"] != DBNull.Value)
                    {
                        notifContent.PostId = reader.GetGuid(reader.GetOrdinal("postId"));
                    }
                }

                reader.Close();
                connection.Close();
            }

            return notifContent;
        }

    }
}