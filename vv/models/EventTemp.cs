using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace vv.models
{
    public class EventTemp
    {
        public Guid eventId { get; set; }
        public string eventTitle { get; set; }
        public string eventDesc { get; set; }
        public DateTime eventDate { get; set; }
        public DateTime eventTime { get; set; }
        public string eventLocation { get; set; }
        public string eventRoom { get; set; }
        public string eventLink { get; set; }
        public UserProfile eventOrganizer { get; set; }
        public List<UserProfile> eventParticipants { get; set; }
        public string eventPic { get; set; }


        public EventTemp()
        {
            eventId = Guid.Empty;
            eventTitle = "";
            eventDesc = "";
            eventDate = DateTime.MinValue;
            eventTime = DateTime.MinValue;
            eventLocation = "";
            eventRoom = "";
            eventLink = "";
            eventOrganizer = new UserProfile();
            eventParticipants = new List<UserProfile>();
            eventPic = "";
        }

        public void addEvent(Guid id, UserProfile organizer, List<UserProfile> participants, string title, string desc,
            string location = " ", string room = " ", string link = " ", string pic = "", string tags = "")
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            if(location != null)
            {
                string query = "insert into event values (eventId = @id, eventTitle = @title, eventDesc = @desc," +
                    "eventLocation = @location, eventRoom = @room, eventPic = @pic, eventOrganizer = @organizerid, evntTags = @tags)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@desc", desc);
                    command.Parameters.AddWithValue("@location", location);
                    command.Parameters.AddWithValue("@room", room);
                    command.Parameters.AddWithValue("@pic", pic);
                    command.Parameters.AddWithValue("@organizerid", organizer.Id);
                    command.Parameters.AddWithValue("@tags", tags);
                    //command.Parameters.AddWithValue("@participants", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            if (link != null)
            {
                string query = "insert into event values (eventId = @id, eventTitle = @title, eventDesc = @desc," +
                    "eventLink = @link, eventPic = @pic, eventOrganizer = @organizerid)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@desc", desc);
                    command.Parameters.AddWithValue("@link", link);
                    command.Parameters.AddWithValue("@pic", pic);
                    command.Parameters.AddWithValue("@organizerid", organizer.Id);
                    command.Parameters.AddWithValue("@tags", tags);
                    //command.Parameters.AddWithValue("@participants", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}