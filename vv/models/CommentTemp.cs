using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace vv.models
{
    public class CommentTemp
    {
        public Guid postId { get; set; }
        public Guid userId { get; set; }
        public Guid commentId { get; set; }

        public DateTime commentDate { get; set; }
        public TimeSpan commentTime { get; set; }
        public string commentContent { get; set; }

        public CommentTemp() {
            postId = Guid.Empty;
            userId = Guid.Empty;
            commentId = Guid.Empty;
            commentDate = DateTime.MinValue;
            commentTime = TimeSpan.Zero;
            commentContent = string.Empty;
        }

        public int addComment(Guid postId, Guid userId, string commentContent)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";

            query = "INSERT INTO Comments (postId, userId, commentContent, commentDate, commentTime, commentId)" +
                        "VALUES (@postId, @userId, @commentContent, @commentDate, @commentTime, @commentId)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@postId", postId);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@commentContent", commentContent);
                command.Parameters.AddWithValue("@commentDate", DateTime.Today);
                command.Parameters.AddWithValue("@commentTime", DateTime.Now - DateTime.Today);
                command.Parameters.AddWithValue("@commentId", Guid.NewGuid());

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;

            }
        }
    }
}