using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace vv.models
{
    public class PostTemp
    {
        public Guid postId { get; set; }
        public Guid userId { get; set; }
        public DateTime postDate { get; set; }
        public TimeSpan postTime { get; set; }
        public string postContent { get; set; }
        public string postTitle { get; set; }

        public PostTemp() {
            postId = Guid.Empty;
            userId = Guid.Empty;
            postDate = DateTime.MinValue;
            postTime = TimeSpan.Zero;
            postContent = string.Empty;
            postTitle = string.Empty;
        }

        public int addPost(Guid userId, Guid postId, string postTitle, string postContent)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";

            query = "INSERT INTO post (postId, postContent, postDate, postTime, userId, postTitle) " +
                        "VALUES (@postId, @postContent, @postDate, @postTime, @userId, @postTitle)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@postId", postId);
                command.Parameters.AddWithValue("@postContent", postContent);
                command.Parameters.AddWithValue("@postDate", DateTime.Today);
                command.Parameters.AddWithValue("@postTime", DateTime.Now - DateTime.Today);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@postTitle", postTitle);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;

            }
        }
    }

    
}