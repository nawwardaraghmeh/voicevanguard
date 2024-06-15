using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using vv.models;

namespace vv.webpages.popups
{
    public partial class editProfile : System.Web.UI.Page
    {
        Guid UserId;
        List<string> selectedTags = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void selectTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in selectTags.Items)
            {
                if (item.Selected)
                {
                    selectedTags.Add(item.Text);
                }
            }
            showInterestlbl.Text = "#" + string.Join(" #", selectedTags);
        }

        protected void closebtn_click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "closewindow", "window.close();", true);
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile();
            Guid userId = new Guid(Session["UserId"].ToString());
            string name = changeName.Text;
            List<string> selectedTags = new List<string>();

            foreach (ListItem item in selectTags.Items)
            {
                if (item.Selected)
                {
                    selectedTags.Add(item.Text);
                }
            }
            string tags = string.Join(",", selectedTags);

            if (changeBanner.HasFile)
            {
                string folderPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = Path.GetFileName(changeBanner.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                changeBanner.SaveAs(filePath);
                string relativePath = "~/Uploads/" + fileName;
                profile.UpdateBannerPicture(userId, relativePath);
            }

            if (changePfp.HasFile)
            {
                string folderPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = Path.GetFileName(changePfp.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                changePfp.SaveAs(filePath);
                string relativePath = "~/Uploads/" + fileName;
                profile.UpdateProfilePicture(userId, relativePath);
            }

            if (name != "")
            {
                profile.UpdateName(userId, name);
            }

            if (tags != "")
            {
                profile.UpdateInterest(userId, tags);
            }

            Session["ProfileUpdated"] = true;

            string script = "window.opener.location.reload(); window.close();";
            ClientScript.RegisterStartupScript(this.GetType(), "closewindow", script, true);
        }

        protected void ConfirmDeleteButton_Click(object sender, EventArgs e)
        {
            Guid userId = new Guid(Session["UserId"].ToString());

            DeleteUserProfile(userId);

            string script = "<script>window.opener.location.href = '../index.aspx'; window.close();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script);
        }

        private void DeleteUserProfile(Guid userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;

            string deleteCommentsQuery = "DELETE FROM Comments WHERE userId = @userId";
            string deleteNotificationsForCommentsQuery = "DELETE FROM notification WHERE commentId IN (SELECT commentId FROM Comments WHERE userId = @userId)";
            string deleteNotificationsForPostsQuery = "DELETE FROM notification WHERE postId IN (SELECT postId FROM post WHERE userId = @userId)";
            string deletePostsQuery = "DELETE FROM post WHERE userId = @userId";
            string deleteNotificationsForEventsQuery = "DELETE FROM notification WHERE eventId IN (SELECT eventId FROM event WHERE eventOrganizer = @userId)";
            string deleteParticipantsByEventQuery = "DELETE FROM participants WHERE eventId IN (SELECT eventId FROM event WHERE eventOrganizer = @userId)";
            string deleteParticipantsQuery = "DELETE FROM participants WHERE userId = @userId";
            string deleteEventsQuery = "DELETE FROM event WHERE eventOrganizer = @userId";
            string deleteProfileQuery = "DELETE FROM users WHERE userId = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        // Delete notifications related to comments
                        using (SqlCommand command = new SqlCommand(deleteNotificationsForCommentsQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.ExecuteNonQuery();
                        }

                        // Delete notifications related to posts
                        using (SqlCommand command = new SqlCommand(deleteNotificationsForPostsQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.ExecuteNonQuery();
                        }

                        // Delete notifications related to events
                        using (SqlCommand command = new SqlCommand(deleteNotificationsForEventsQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.ExecuteNonQuery();
                        }

                        // Delete comments 
                        using (SqlCommand command = new SqlCommand(deleteCommentsQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.ExecuteNonQuery();
                        }

                        // Delete posts
                        using (SqlCommand command = new SqlCommand(deletePostsQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.ExecuteNonQuery();
                        }

                        // Delete participants by event
                        using (SqlCommand command = new SqlCommand(deleteParticipantsByEventQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.ExecuteNonQuery();
                        }

                        // Delete participants
                        using (SqlCommand command = new SqlCommand(deleteParticipantsQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.ExecuteNonQuery();
                        }

                        // Delete events
                        using (SqlCommand command = new SqlCommand(deleteEventsQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.ExecuteNonQuery();
                        }

                        // Finally, delete the user profile
                        using (SqlCommand command = new SqlCommand(deleteProfileQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    LogError("Error deleting user profile: " + ex.Message);
                    throw;
                }
            }
        }

        private void LogError(string message)
        {
            System.Diagnostics.Debug.WriteLine("ERROR: " + message);
        }

    }
}
