using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vv.web_pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = nametxtbox.Text;
            string password = pwtxtbox.Text;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\CRC\\Desktop\\Y4S2\\senior\\vv\\vv\\App_Data\\VV.mdf;Integrated Security=True";
            string query = "SELECT userId FROM users WHERE username = @username AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null) 
                {
                   
                    Response.Redirect("~/webpages/profile.aspx");
                }
                else
                {
                    
                }
            }
        }
    }
}