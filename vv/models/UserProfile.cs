using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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

        public UserProfile()
        {
            // initialize default values
            Id = Guid.Empty;
            Username = "";
            Name = "";
            Email = "";
            DateOfBirth = DateTime.MinValue;
            DateCreated = DateTime.MinValue;
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
                }

                reader.Close();
            }
        }

        public void UpdateProfilePicture(Guid userId, string imagePath)
        {
            // Perform database update with imagePath
            ProfilePicturePath = imagePath;
        }

        public void UpdateBannerPicture(Guid userId, String imagePath)
        {
            // Perform database update with imagePath
            BannerPicturePath = imagePath;
        }

        public void UpdateUsername(Guid userId, String newUsername)
        {
            // Perform database update with newUsername
            Username = newUsername;
        }
    }
}