using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using vv.models;
using vv.web_pages;

namespace vv.webpages
{
    public partial class viewevent : System.Web.UI.Page
    {
        int isOrganizer = 0;
        EventTemp eventDetails = null;
        int x;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["userId"] != null)
                {
                    //userId = new Guid(Session["UserId"].ToString());

                }

                else
                {
                    Response.Redirect("~/webpages/login.aspx");
                }

                string eventIdString = Request.QueryString["eventId"];
                if (!string.IsNullOrEmpty(eventIdString) && Guid.TryParse(eventIdString, out Guid eventId))
                {
                    eventDetails = LoadEventDetails(eventId);
                    UpdateEventDetails(eventDetails);
                }
                else
                {
                }
            }
        }

        private EventTemp LoadEventDetails(Guid eventId)
        {
            EventTemp eventDetails = null;

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT * FROM event WHERE eventId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", eventId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    eventDetails = new EventTemp();
                    eventDetails.eventTitle = reader["eventTitle"].ToString();
                    eventDetails.eventDesc = reader["eventDesc"].ToString();
                    eventDetails.eventTime = (TimeSpan)reader["eventTime"];
                    eventDetails.eventDate = (DateTime)reader["eventDate"];
                    eventDetails.eventPic = reader["eventPic"].ToString();
                    eventDetails.eventLink = reader["eventLink"].ToString();
                    eventDetails.eventLocation = reader["eventLocation"].ToString();
                    eventDetails.eventRoom = reader["eventRoom"].ToString();
                    eventDetails.eventOrganizer = (Guid)reader["eventOrganizer"];
                    eventDetails.eventDuration = (TimeSpan)reader["eventDuration"];
                }

                reader.Close();
                connection.Close();
            }

            return eventDetails;
        }

        private void UpdateEventDetails(EventTemp eventDetails)
        {
            eventMainImg.ImageUrl = eventDetails.eventPic;
            lblEventTitle.Text = eventDetails.eventTitle;
            lblEventDesc.Text = eventDetails.eventDesc;
            lblEventDate.Text = eventDetails.eventDate.ToString("dd MMMM yyyy");
            lblEventTime.Text = eventDetails.eventTime.ToString(@"hh\:mm");

            if (!string.IsNullOrEmpty(eventDetails.eventLocation))
            {
                lblEventLocation.Text = eventDetails.eventLocation;
                lblEventLocation.Visible = true;
            }
            else
            {
                lblEventLocation.Visible = false;
                eventLocationIconlbl.Visible = false;
            }

            if (!string.IsNullOrEmpty(eventDetails.eventRoom))
            {
                lblEventRoom.Text = eventDetails.eventRoom;
                lblEventRoom.Visible = true;
            }
            else
            {
                lblEventRoom.Visible = false;
                eventRoomIconlbl.Visible = false;
            }

            if (!string.IsNullOrEmpty(eventDetails.eventLink))
            {
                lblEventLink.Text = eventDetails.eventLink;
                lblEventLink.Visible = true;
            }
            else
            {
                lblEventLink.Visible = false;
                eventLinkIconlbl.Visible = false;

            }

            eventOrganizerProfile.Text = GetOrganizerName(eventDetails.eventOrganizer);

            /*
            List<Guid> participants = LoadParticipants(eventDetails.eventId);
            foreach (Guid id in participants)
            {
                string imageUrl = getParticipantPic(id);

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    Image participantImage = new Image();
                    participantImage.ImageUrl = imageUrl;
                    participantImage.CssClass = "participantProfileImg";
                    participantsPanel.Controls.Add(participantImage);
                }
            }
            */

            int numOfParticipants = GetNumOfParticipants(eventDetails.eventId);
            lblParticipantCount.Text = numOfParticipants + " people are interested in this event";

        }

        private String GetOrganizerName(Guid organizerId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT * FROM users WHERE userId = @id";

            String organizerName;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", organizerId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    organizerName = reader["name"].ToString();

                    Guid userId = new Guid(Session["UserId"].ToString());
                    Guid id = new Guid(reader["userId"].ToString());
                    if (userId == id)
                    {
                        btnInterested.Visible = false;
                        //return "You";
                    }

                    return organizerName;
                }

                reader.Close();
                connection.Close();
            }
            return null;
        }

        private int GetNumOfParticipants(Guid eventId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT COUNT(userId) FROM participants WHERE eventId = @id";
            int participantCount = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", eventId);

                connection.Open();
                participantCount = (int)command.ExecuteScalar();
                connection.Close();
            }
            return participantCount;
        }

        /*
        private List<Guid> LoadParticipants(Guid eventId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT userId FROM participants WHERE eventId = @id";
            List<Guid> allParticipantsIds = new List<Guid>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", eventId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Guid userid = (Guid)reader["userId"];
                    allParticipantsIds.Add(userid);
                }

                reader.Close();
            }
            return allParticipantsIds;
        }
        */

        protected void btnInterested_Click(object sender, EventArgs e)
        {
            Guid userId = new Guid(Session["UserId"].ToString());
            string eventIdString = Request.QueryString["eventId"];
            Guid eventId = new Guid(eventIdString);
            int rowsAffected = 0;

            if (IsUserSubscribed(eventId, userId))
            {
                string dataToSend = "You have already subscribed to this event! Please check your calendar.";
                string url = "popups/participantsAdditionPopup.aspx?data=" + Server.UrlEncode(dataToSend);
                string script = "window.open('" + url + "', '_blank', 'width=400,height=250,top=250,left=450,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');";
                ClientScript.RegisterStartupScript(this.GetType(), "openwindow", script, true);
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
                string query = "INSERT INTO participants VALUES (@eventid, @userid)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@eventid", eventId);
                    command.Parameters.AddWithValue("@userid", userId);

                    connection.Open();
                    try
                    {
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }

                    if (rowsAffected > 0)
                    {
                        Guid notifid = Guid.NewGuid();
                        DateTime notifDate = DateTime.Today;
                        TimeSpan notifTime = DateTime.Now - DateTime.Today;
                        NotifTemp notif = new NotifTemp();
                        notif.addNotif(notifid, userId, eventId, "EventSubscription", notifDate, notifTime);
                        sendNotifToOrganizer(eventId);

                        string dataToSend = "Event was added to your calendar!\nThank you for your contribution.";
                        string url = "popups/participantsAdditionPopup.aspx?data=" + Server.UrlEncode(dataToSend);
                        string script = "window.open('" + url + "', '_blank', 'width=400,height=250,top=250,left=450,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');";
                        ClientScript.RegisterStartupScript(this.GetType(), "openwindow", script, true);
                    }
                    else
                    {
                        string dataToSend = "Something went wrong.\nPlease try again later!";
                        string url = "popups/participantsAdditionPopup.aspx?data=" + Server.UrlEncode(dataToSend);
                        string script = "window.open('" + url + "', '_blank', 'width=400,height=300,top=250,left=450,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');";
                        ClientScript.RegisterStartupScript(this.GetType(), "openwindow", script, true);
                    }

                    connection.Close();
                }
            }
        }

        private void sendNotifToOrganizer(Guid eventid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT eventOrganizer FROM event where eventId = @id";
            Guid userid = Guid.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", eventid);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userid = (Guid)reader["eventOrganizer"];
                    Guid notifid = Guid.NewGuid();
                    DateTime notifDate = DateTime.Today;
                    TimeSpan notifTime = DateTime.Now - DateTime.Today;
                    NotifTemp notif = new NotifTemp();
                    notif.addNotif(notifid, userid, eventid, "EventInterested", notifDate, notifTime);
                }

            }
        }
        private bool IsUserSubscribed(Guid eventId, Guid userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT COUNT(*) FROM participants WHERE eventId = @eventid AND userId = @userid";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@eventid", eventId);
                command.Parameters.AddWithValue("@userid", userId);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }

        /*
        protected string getParticipantPic(Guid userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT profilePic FROM users WHERE userId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", userId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string picurl = reader["profilePic"].ToString();
                    return picurl;
                }
            }
            return null;
        }
        */
    }
}
