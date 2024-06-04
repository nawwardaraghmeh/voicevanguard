﻿using System;
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
            if(eventNotifIds != null)
            {
                emptynotif.Visible = false;
                foreach (Guid id in eventNotifIds)
                {
                    NotifTemp notif = LoadEventNotifContent(id);
                    populateNotifContainer(notif);
                }
            }

            List<Guid> postNotifIds = getUserEventNotifIds(userId);
            if (postNotifIds != null)
            {
                emptynotif.Visible = false;
                foreach (Guid id in postNotifIds)
                {
                    NotifTemp notif = LoadPostNotifContent(id);
                    populateNotifContainer(notif);
                }
            }
            /* else
             {
                 Label notifLabel = new Label();
                 notifLabel.Text = "No notifications!";
                 notifLabel.CssClass = "noNotifText";
                 notifheroContainer.Controls.Add(notifLabel);
             }*/


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
                        notifLabel.Text = "1 person is interested in your event! ";
                        break;
                    case "PostAdded":
                        notifLabel.Text = "You added a post!";
                        break;
                }
                /*
                HyperLink eventPage = new HyperLink();
                string url = $"~/webpages/viewevent.aspx?eventId={notif.EventId}";
                eventPage.NavigateUrl = url;
                eventPage.Text = "event!";
                eventPage.CssClass = "eventLink";
                */
                notifPanel.Controls.Add(notifLabel);
                //notifPanel.Controls.Add(eventPage);

                notifPanel.Controls.Add(divEnd);

                notifheroContainer.Controls.Add(notifPanel);
            }
        }

        public List<Guid> getUserEventNotifIds(Guid userid)
        {
            List<Guid> notifIds = new List<Guid>();
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string sqlQuery = "SELECT top 5 notifId FROM notification WHERE userId = @userid AND eventId IS NOT NULL order by notifDate DESC, notifTime";

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
    }
}