using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace vv.webpages
{
    public partial class Registration : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
        string query = "INSERT INTO users (userId, username, name, email, password, dob, dateCreated)" +
            " VALUES (@userId, @username, @name, @email, @password, @dob, @dateCreated)";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int day = 1; day <= 31; day++)
                {
                    ddlDay.Items.Add(new ListItem(day.ToString(), day.ToString()));
                }

                string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
                for (int month = 1; month <= 12; month++)
                {
                    ddlMonth.Items.Add(new ListItem(monthNames[month - 1], month.ToString()));
                }

                int currentYear = DateTime.Now.Year;
                for (int year = currentYear; year >= currentYear - 100; year--)
                {
                    ddlYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                }
            }
        }

        protected void loginLink_Click (object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/login.aspx");
        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            string username = txtboxUsername.Text;
            string name = txtboxName.Text;
            string email = txtboxEmail.Text;
            string password = txtboxPass.Text;
            DateTime dateCreated = DateTime.Today; 

            int day = int.Parse(ddlDay.SelectedValue);
            int month = int.Parse(ddlMonth.SelectedValue);
            int year = int.Parse(ddlYear.SelectedValue);
            DateTime dob = new DateTime(year, month, day);

            Guid userId = Guid.NewGuid();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (IsUsernameUnique(username))
                {    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@dob", dob);
                    command.Parameters.AddWithValue("@dateCreated", dateCreated);


                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        Response.Redirect("~/webpages/login.aspx");
                    } 
                }

                else
                {
                    usernameErrorlbl.Text = "Username is already taken.";
                }



            }
        }

        private bool IsUsernameUnique(string username)
        {
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
    }
}