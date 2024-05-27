using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using vv.web_pages;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace vv.models
{
    public class NotifTemp
    {
        public Guid NotifId { get; set; }
        public DateTime NotifDateTime { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public string notifType { get; set; }

        public int addNotif(Guid notifid, Guid userid, Guid eventid, string notifType, DateTime date, TimeSpan time)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";

            query = "INSERT INTO notification (notifId, userId, eventId, notifType,notifDate, notifTime) VALUES(@notifid, @userid, @eventid, @type, @notifDate, @notifTime)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@notifid", notifid);
                command.Parameters.AddWithValue("@userid", userid);
                command.Parameters.AddWithValue("@eventid", eventid);
                command.Parameters.AddWithValue("@type", notifType);
                command.Parameters.AddWithValue("@notifDate", date);
                command.Parameters.AddWithValue("@notifTime", time);


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;
            }
        }
    }
        
}