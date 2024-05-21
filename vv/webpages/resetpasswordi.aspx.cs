using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
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
            bool emailSent = false;

            if (userEmail != "")
            {
                SendResetPasswordEmail(userEmail, resetUrl);
                emailSent = true;
            }
            else
            {
                errorlbl.Text = "Please provide an email address";
            }

            if (emailSent)
            {
                // Set the session variable before redirecting
                Session["UserEmail"] = userEmail;
                Response.Redirect("~/webpages/resetlink.aspx");
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
        }
    }
}
