using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vv.webpages
{
    public partial class resetpasswordii : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (!IsPostBack)
            {
                email = Session["UserEmail"] as string;
            }*/
        }

        protected void confirmbtn_Click(object sender, EventArgs e)
        {
            string email = Session["UserEmail"] as string;
            string newpass = newPassword.Text;
            ResetPassword(email, newpass);








            /*string token = Request.QueryString["token"];
            string mewpass = newPassword.Text;

            // Validate the token
            if (IsValidToken(token))
            {
                // Reset the password in the database for the user associated with the token
                ResetPassword(token, mewpass);

                // Redirect to the login page after successful password reset
                Response.Redirect("login.aspx");
            }
            else
            {
                // Token is invalid or expired, handle accordingly
                // You can display an error message or redirect to another page
            }*/
        }




        /*private bool IsValidToken(string token)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT COUNT(*) FROM passwordResetTokens WHERE token = @token AND expiryDate > GETDATE()";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@token", token);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }*/

        private void ResetPassword(string email, string newPassword)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "UPDATE users SET password = @newpassword WHERE email = @email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newpassword", newPassword);
                command.Parameters.AddWithValue("@email", email);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}