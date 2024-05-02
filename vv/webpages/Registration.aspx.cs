using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vv.webpages
{
    public partial class Registration : System.Web.UI.Page
    {
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
            DateTime dateCreated = DateTime.Now; 

            int day = int.Parse(ddlDay.SelectedValue);
            int month = int.Parse(ddlMonth.SelectedValue);
            int year = int.Parse(ddlYear.SelectedValue);
            DateTime dob = new DateTime(year, month, day);

            Guid userId = Guid.NewGuid();


            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\CRC\\Desktop\\Y4S2\\senior\\vv\\vv\\App_Data\\VV.mdf;Integrated Security=True";
            string query = "INSERT INTO users (userId, username, name, email, password, dob, dateCreated)" +
                " VALUES (@userId, @username, @name, @email, @password, @dob, @dateCreated)";
            using (SqlConnection connection = new SqlConnection(connectionString))
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
                    Response.Redirect("~/webpages/profile.aspx");
                }
                else
                {

                }
            }
        }
    }
}