using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace vv.web_pages
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\CRC\\Desktop\\Y4S2\\senior\\vv\\vv\\App_Data\\VV.mdf;Integrated Security=True";
            string query = "SELECT name, dateCreated, bio, profilePic, bannerPic FROM users WHERE userId = @userId";
            */

            
            if (!IsPostBack)
            {
                /*
                if (Session["userId"] != null)
                {
                    string userId = Session["UserId"].ToString();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@userId", userId);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            
                            string name = reader["name"].ToString();
                            DateTime dateCreated = (DateTime)reader["dateCreated"];
                            string formattedDate = dateCreated.ToString("yyyy/MM/dd");
                            //Session["profilePic"] = reader["profilePic"].ToString();
                            //Session["bannerPic"] = reader["bannerPic"].ToString();

                            lblAccountName.Text = name;
                            lblJoinDate.Text = "Joined " + formattedDate;
                        }
                        reader.Close();
                    }
                }

                else
                {
                    Response.Redirect("~/webpages/login.aspx");
                }
                */
                btnMyActivity.CssClass = "clickedBtn";
                MainView.ActiveViewIndex = 0;
            }

        }

        protected void btnMyActivity_Click(object sender, EventArgs e)
        {
            btnMyActivity.CssClass = "clickedBtn";
            btnUpcomingEvents.CssClass = "initialBtn";
            MainView.ActiveViewIndex = 0;
        }

        protected void btnUpcomingEvents_Click(object sender, EventArgs e)
        {
            btnMyActivity.CssClass = "initialBtn";
            btnUpcomingEvents.CssClass = "clickedBtn";
            MainView.ActiveViewIndex = 1;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            // Check if the day has events and customize its appearance
            if (HasEventsOnDate(e.Day.Date))
            {
                e.Cell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#DE2B2B");
                e.Cell.BorderStyle = BorderStyle.Inset;

                // Create a hyperlink
                HyperLink eventLink = new HyperLink();
                //eventLink.Text = e.Day.DayNumberText;
                eventLink.Text = "CLIMATE ACTION RALLY";
                //eventLink.NavigateUrl = "EventDetails.aspx?date=" + e.Day.Date.ToShortDateString(); // Replace with your event details page URL
                eventLink.NavigateUrl = "~/webpages/viewevent.aspx";

                // Customize the appearance of the hyperlink
                eventLink.ForeColor = System.Drawing.ColorTranslator.FromHtml("#DE2B2B");
                eventLink.Font.Italic = true;

                // Add a line break before the hyperlink
                e.Cell.Controls.Add(new LiteralControl("<br />"));

                // Add the hyperlink to the cell
                e.Cell.Controls.Add(eventLink);
            }
        }

        private bool HasEventsOnDate(DateTime date)
        {
            // Check if there are events on the specified date
            // Replace this with your actual logic to determine if there are events on the given date
            return (date == new DateTime(2024, 5, 15) || date == new DateTime(2024, 5, 29));
        }


    }
}