using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vv.webpages
{
    public partial class resetpasswordi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cancelHlink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/login.aspx");
        }

        protected void resetPasswordbtn_Click(object sender, EventArgs e)
        {
            string email = setEmailtxtbox.Text;

            if (doesEmailExist(email))
            {
                string token = Guid.NewGuid().ToString();

                // Store the token in the database along with the user's email and timestamp
                StoreTokenInDatabase(email, token);

                // Send an email to the user's email address with a link that includes the token
                string resetLink = $"https://localhost:44313/webpages/resetpasswordii.aspx?token={HttpUtility.UrlEncode(token)}";
                bool emailSent = SendResetEmail(email, resetLink);

                if (emailSent)
                {
                    // Redirect to a page indicating that the reset link has been sent
                    Response.Redirect("~/webpages/resetlink.aspx");
                }
                else
                {
                    errorlbl.Text = "Sending password reset link failed. Please try again.";
                }
            }
            else
            {
                errorlbl.Text = "Email address not found";
            }
        }

        private bool doesEmailExist(string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT COUNT(*) FROM users WHERE email = @email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }

        private void StoreTokenInDatabase(string email, string token)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "INSERT INTO passwordResetTokens (email, token, expiryDate) VALUES (@email, @token, DATEADD(day, 1, GETDATE()))";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@token",token);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private bool SendResetEmail(string email, string resetLink)
        {
            string senderEmail = "voicevanguardofficial@gmail.com";
            string appPassword = "ytwzeqnusfhdaxoz";

            MailMessage message = new MailMessage(senderEmail, email);
            message.Subject = "Password Reset Request";
            message.Body = $"Please click the following link to reset your password: {resetLink}";
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 465);
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(senderEmail, appPassword);

            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                // Log the error message
                System.Diagnostics.Debug.WriteLine($"Error sending email: {ex.Message}");

                // Display an alert message using JavaScript
                string errorMessage = $"Error sending email: {ex.Message.Replace("'", "\\'")}";
                string script = $"<script>alert('{errorMessage}');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script);

                return false;
            }
        }
    }
}