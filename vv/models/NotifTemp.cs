﻿using System;
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
        public DateTime NotifDate { get; set; }
        public TimeSpan NotifTime { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public string notifType { get; set; }
        public Guid PostId { get; set; }
        public Guid CommentId {  get; set; }

        public int addNotif(Guid notifid, Guid userid, Guid eventid, string notifType, DateTime date, TimeSpan time)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";

            query = "INSERT INTO notification (notifId, userId, eventId, notifType, notifDate, notifTime) VALUES(@notifid, @userid, @eventid, @type, @notifDate, @notifTime)";


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

        public int addPostNotif(Guid notifid, Guid userid, Guid postid, DateTime date, TimeSpan time)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";

            query = "INSERT INTO notification (notifId, userId, postId, notifType, notifDate, notifTime) VALUES(@notifid, @userid, @postid, @type, @notifDate, @notifTime)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@notifid", notifid);
                command.Parameters.AddWithValue("@userid", userid);
                command.Parameters.AddWithValue("@postid", postid);
                command.Parameters.AddWithValue("@type", "PostAdded");
                command.Parameters.AddWithValue("@notifDate", date);
                command.Parameters.AddWithValue("@notifTime", time);


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;
            }
        }

        public int addCommentNotif(Guid notifid, Guid userid, Guid postid, Guid commentId, string notifType, DateTime date, TimeSpan time)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";

            query = "INSERT INTO notification (notifId, userId, postId, commentId, notifType, notifDate, notifTime) VALUES(@notifid, @userid, @postid, @commentid, @type, @notifDate, @notifTime)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@notifid", notifid);
                command.Parameters.AddWithValue("@commentid", commentId);
                command.Parameters.AddWithValue("@userid", userid);
                command.Parameters.AddWithValue("@postid", postid);
                command.Parameters.AddWithValue("@type", notifType);
                command.Parameters.AddWithValue("@notifDate", date);
                command.Parameters.AddWithValue("@notifTime", time);


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;
            }
        }

        public int addCommentNotiftoPoster(Guid notifid, Guid userid, Guid postid, string notifType, DateTime date, TimeSpan time)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";

            query = "INSERT INTO notification (notifId, userId, postId, notifType, notifDate, notifTime) VALUES(@notifid, @userid, @postid, @type, @notifDate, @notifTime)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@notifid", notifid);
                command.Parameters.AddWithValue("@userid", userid);
                command.Parameters.AddWithValue("@postid", postid);
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