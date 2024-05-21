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

        }

        protected void confirmbtn_Click(object sender, EventArgs e)
        {
            if (Session["UserEmail"] != null)
            {
                string email = Session["UserEmail"].ToString();
                string newpass = newPassword.Text;
                ResetPassword(email, newpass);
                Response.Redirect("~/webpages/login.aspx");
            }
            else
            {
                Label5.Text = "Something went wrong. Please try again";
            }
        }

        private void ResetPassword(string email, string newPassword)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "UPDATE users SET password = @newpassword WHERE email = @mail";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@mail", email);
                command.Parameters.AddWithValue("@newpassword", newPassword);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}