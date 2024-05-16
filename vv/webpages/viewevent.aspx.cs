using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vv.models;
using vv.web_pages;

namespace vv.webpages
{
    public partial class viewevent : System.Web.UI.Page
    {
        int isOrganizer = 0;
        EventTemp eventDetails = null;
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
                if (Guid.TryParse(eventIdString, out Guid eventId))
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
                    //eventDetails.eventParticipants = (Guid)reader["eventParticipants"];
                }

                reader.Close();
                connection.Close();
            }

            return eventDetails;
        }

        private void UpdateEventDetails(EventTemp eventDetails)
        {
            eventMainImg.ImageUrl = "../resources/images/rallypic.jpg";
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
            
            //LoadParticipants(eventDetails.eventId);
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
                    if (userId == id) { 
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

        private void LoadParticipants(Guid eventId)
        {
            // Implement logic to load and display participant images
            // You might need to query the database for participant data
        }
    }
}