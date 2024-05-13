using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Web.UI;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Security.Cryptography;
using vv.web_pages;

namespace vv.models
{
    public class EventTemp
    {
        public Guid eventId { get; set; }
        public string eventTitle { get; set; }
        public string eventDesc { get; set; }
        public DateTime eventDate { get; set; }
        public TimeSpan eventTime { get; set; }
        public string eventLocation { get; set; }
        public string eventRoom { get; set; }
        public string eventLink { get; set; }
        public Guid eventOrganizer { get; set; }
        public List<Guid> eventParticipants { get; set; }
        public string eventPic { get; set; }
        public TimeSpan eventDuration { get; set; }


        public EventTemp()
        {
            eventId = Guid.Empty;
            eventTitle = "";
            eventDesc = "";
            eventDate = DateTime.MinValue;
            eventTime = TimeSpan.MinValue;
            eventDuration = TimeSpan.MinValue;
            eventLocation = "";
            eventRoom = "";
            eventLink = "";
            eventOrganizer = Guid.Empty;
            eventParticipants = new List<Guid> ();
            eventPic = "";
        }

        public int addEvent(Guid id, Guid organizerid, string title, string desc, string location, string room,
            string link, string pic, string tags, DateTime date, TimeSpan time, TimeSpan duration)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";
            string script = "";

            if (location != null && room != null)
            {
                query = "INSERT INTO event (eventId, eventTitle, eventDesc, eventLocation, eventRoom, eventPic, eventOrganizer, eventTags, eventDate, eventTime, eventDuration) " +
                        "VALUES (@id, @title, @desc, @location, @room, @pic, @organizerid, @tags, @date, @time, @duration)";
            }
            else if (location != null && room == null)
            {
                query = "INSERT INTO event (eventId, eventTitle, eventDesc, eventLocation, eventPic, eventOrganizer, eventTags, eventDate, eventTime, eventDuration) " +
                "VALUES (@id, @title, @desc, @location, @pic, @organizerid, @tags, @date, @time, @duration)";
            }
            else
            {
                query = "INSERT INTO event (eventId, eventTitle, eventDesc, eventLink, eventPic, eventOrganizer, eventTags, eventDate, eventTime, eventDuration) " +
                        "VALUES (@id, @title, @desc, @link, @pic, @organizerid, @tags, @date, @time, @duration)";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@desc", desc);
                command.Parameters.AddWithValue("@location", location);
                command.Parameters.AddWithValue("@room", room);
                command.Parameters.AddWithValue("@link", link);
                command.Parameters.AddWithValue("@pic", pic);
                command.Parameters.AddWithValue("@organizerid", organizerid);
                command.Parameters.AddWithValue("@tags", tags);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@time", time);
                command.Parameters.AddWithValue("@duration", duration);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;
            }
        }

       

        
    }
}