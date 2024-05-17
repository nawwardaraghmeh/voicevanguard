using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace vv.models
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfilePicturePath { get; set; }
        public string BannerPicturePath { get; set; }
        public string interests {  get; set; }

        public UserProfile()
        {
            // initialize default values
            Id = Guid.Empty;
            Username = "";
            Name = "";
            Email = "";
            DateOfBirth = DateTime.MinValue;
            DateCreated = DateTime.MinValue;
            interests = "";
        }

        public void LoadFromDatabase(Guid userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT * FROM users WHERE userId = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Id = (Guid)reader["userId"];
                    Username = reader["username"].ToString();
                    Name = reader["name"].ToString();
                    Email = reader["email"].ToString();
                    DateOfBirth = (DateTime)reader["dob"];
                    DateCreated = (DateTime)reader["dateCreated"];
                    ProfilePicturePath = reader["profilePic"].ToString();
                    BannerPicturePath = reader["bannerPic"].ToString();
                    interests = reader["interests"].ToString();
                }

                reader.Close();
            }
        }

        public void UpdateProfilePicture(Guid userId, string imagePath)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";

            query = "INSERT INTO users (profilePic) VALUES (@imagePath)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@imagePath", imagePath);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            /*ProfilePicturePath = imagePath;*/
        }

        public void UpdateBannerPicture(Guid userId, String imagePath)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";

            query = "INSERT INTO users (bannerPic) VALUES (@imagePath)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@imagePath", imagePath);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }

           /* BannerPicturePath = imagePath;*/
        }

        public void UpdateUsername(Guid userId, String newUsername)
        {
            if (IsUsernameUnique(newUsername))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
                string query = "";

                query = "INSERT INTO users (username) VALUES (@newUsername)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@newUsername", newUsername);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
               /* Username = newUsername;*/
        }

        private bool IsUsernameUnique(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT COUNT(*) FROM users WHERE username = @username";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count == 0;
                }
            }
        }

        public void UpdateName(Guid userId, String newName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";

            query = "INSERT INTO users (name) VALUES (@newName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newName", newName);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateInterest(Guid userId, String interestTags)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "";

            query = "INSERT INTO users (interests) VALUES (@interestTags)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@interestTags", interestTags);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}