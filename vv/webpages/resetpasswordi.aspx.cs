using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace vv.webpages
{
    public partial class resetpasswordi : Page
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
            string token = "exampletoken";
            string resetUrl = GetResetPasswordUrl(token);
            string userEmail = setEmailtxtbox.Text;

            if (string.IsNullOrEmpty(userEmail))
            {
                errorlbl.Text = "Please provide an email address.";
                return;
            }

            if (!doesEmailExist(userEmail))
            {
                errorlbl.Text = "Email doesn't exist.";
                return;
            }

            try
            {
                SendResetPasswordEmail(userEmail, resetUrl);
                Session["UserEmail"] = userEmail;
                Response.Redirect("~/webpages/resetlink.aspx");
            }
            catch (Exception ex)
            {
                errorlbl.Text = "An error occurred while sending the email. Please try again.";
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('The email could not be sent. Please try again later.');", true);
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

        public string GetResetPasswordUrl(string token)
        {
            string baseUrl = "https://localhost:44313/webpages/resetpasswordii";
            return $"{baseUrl}?token={HttpUtility.UrlEncode(token)}";
        }

        public void SendResetPasswordEmail(string email, string resetUrl)
        {
            var fromAddress = new MailAddress("voicevanguardofficial@gmail.com", "Voice Vanguard");
            var toAddress = new MailAddress(email);
            const string fromPassword = "vihb kxst ueep kswy";
            const string subject = "Password Reset Request";
            string body = $"Please click the link to reset your password for Voice Vanguard: {resetUrl}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {

                smtp.Send(message);

            }
        }//
    }
}
