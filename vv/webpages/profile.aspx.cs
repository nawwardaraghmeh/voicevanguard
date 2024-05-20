using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using vv.models;

namespace vv.web_pages
{
    public partial class profile : System.Web.UI.Page
    {
        private UserProfile userProfile = new UserProfile();
        Guid userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["userId"] != null)
                {
                    userId = new Guid(Session["UserId"].ToString());
 
                    userProfile.LoadFromDatabase(userId);

                    lblAccountName.Text = userProfile.Name;
                    lblAccountUsername.Text = userProfile.Username;
                    lblJoinDate.Text = "Joined " + userProfile.DateCreated.ToString("yyyy/MM/dd");

                    imgProfilePic.ImageUrl = userProfile.ProfilePicturePath;
                    imgBannerPic.ImageUrl = userProfile.BannerPicturePath;
                }

                else
                {
                    Response.Redirect("~/webpages/login.aspx");
                }
                
                btnMyActivity.CssClass = "clickedBtn";
                MainView.ActiveViewIndex = 0;
            }
          

        }

        protected void linkEditProfile_click(object sender, EventArgs e)
        {
            string url = "popups/editProfile.aspx";
            string script = "window.open('" + url + "', '_blank', 'toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "openwindow", script, true);
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
            List<Guid> eventIds = GetUserEventIds();
            foreach (Guid eventId in eventIds)
            {
                EventTemp eventData = GetEventData(eventId);
                if (eventData != null && eventData.eventDate == e.Day.Date)
                {
                    e.Cell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#DE2B2B");
                    e.Cell.BorderStyle = BorderStyle.Inset;

                    HyperLink eventLink = new HyperLink
                    {
                        Text = eventData.eventTitle.ToUpper(),
                        NavigateUrl = $"~/webpages/viewevent.aspx?eventId={eventId}",
                        ForeColor = System.Drawing.ColorTranslator.FromHtml("#DE2B2B"),
                        Font = { Italic = true }
                    };

                    e.Cell.Controls.Add(new LiteralControl("<br />"));
                    e.Cell.Controls.Add(eventLink);
                }
            }
        }

        private EventTemp GetEventData(Guid id)
        {
            EventTemp userEvent = null;
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT eventTitle, eventDate FROM event WHERE eventId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userEvent = new EventTemp
                            {
                                eventTitle = reader["eventTitle"].ToString(),
                                eventDate = (DateTime)reader["eventDate"]
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return userEvent;
        }

        private List<Guid> GetUserEventIds()
        {
            List<Guid> ids = new List<Guid>();
            if (Session["UserId"] == null)
            {
                return ids; 
            }

            Guid userId = new Guid(Session["UserId"].ToString());
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT eventId FROM participants WHERE userId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", userId);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ids.Add((Guid)reader["eventId"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return ids;
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/login.aspx");
        }


    }
}