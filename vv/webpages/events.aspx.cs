using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using vv.models;

namespace vv.web_pages
{
    public partial class events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] != null)
                {

                }
                else
                {
                    Response.Redirect("~/webpages/login.aspx");
                }
            }

            List<Guid> lastThreePhysicalEventIds = GetLastThreePhysicalEventIds();
            foreach (Guid id in lastThreePhysicalEventIds)
            {
                HtmlGenericControl physicalEventControl = CreateEventControl(id);
                physicalEventContainer.Controls.Add(physicalEventControl);
            }

            List<Guid> lastThreeVirtualEventIds = GetLastThreeVirtualEventIds();
            foreach (Guid id in lastThreeVirtualEventIds)
            {
                HtmlGenericControl virtualEventControl = CreateEventControl(id);
                virtualEventContainer.Controls.Add(virtualEventControl);
            }

        }
    
        public EventTemp loadEventData(Guid id)
        {
            EventTemp eventDetails = null;

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT * FROM event WHERE eventId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    eventDetails = new EventTemp();
                    eventDetails.eventTitle = reader["eventTitle"].ToString();
                    eventDetails.eventDesc = reader["eventDesc"].ToString();
                    eventDetails.eventTime = (TimeSpan)reader["eventTime"];
                    eventDetails.eventDate = (DateTime)reader["eventDate"];
                    eventDetails.eventPic = reader["eventPic"].ToString();
                    eventDetails.eventLink = reader["eventLink"].ToString();
                    eventDetails.eventLocation = reader["eventLocation"].ToString();
                    eventDetails.eventRoom = reader["eventRoom"].ToString();
                    eventDetails.eventOrganizer = (Guid)reader["eventOrganizer"];
                    eventDetails.eventDuration = (TimeSpan)reader["eventDuration"];
                    //eventDetails.eventParticipants = (Guid)reader["eventParticipants"];
                }

                reader.Close();
                connection.Close();
            }

            return eventDetails;
        }

    protected HtmlGenericControl CreateEventControl(Guid eventId)
    {
        EventTemp eventData = loadEventData(eventId);

        HtmlGenericControl div = new HtmlGenericControl("div");
        div.Attributes["class"] = "card";

        Image image = new Image();
        image.ImageUrl = "../resources/images/rallypic.jpg"; // eventData.eventPic;
        div.Controls.Add(image);

        HtmlGenericControl contentDiv = new HtmlGenericControl("div");
        contentDiv.Attributes["class"] = "content";
        div.Controls.Add(contentDiv);

        Label titleLabel = new Label();
        titleLabel.CssClass = "eventTitleStyles";
        titleLabel.Text = eventData.eventTitle;
        contentDiv.Controls.Add(titleLabel);

        contentDiv.Controls.Add(new LiteralControl("<br /><br />"));

        Label descriptionLabel = new Label();
        descriptionLabel.CssClass = "eventDescStyles";
        descriptionLabel.Text = eventData.eventDesc;
        contentDiv.Controls.Add(descriptionLabel);

        HtmlGenericControl detailsDiv = new HtmlGenericControl("div");
        detailsDiv.Attributes["class"] = "details";
        contentDiv.Controls.Add(detailsDiv);

        HtmlGenericControl dateDiv = new HtmlGenericControl("div");
        dateDiv.Attributes["class"] = "date";
        detailsDiv.Controls.Add(dateDiv);

        Label dateIcon = new Label();
        dateIcon.CssClass = "far fa-calendar-alt";
        dateDiv.Controls.Add(dateIcon);

        Label dateLabel = new Label();
        dateLabel.Text = eventData.eventDate.ToShortDateString();
        dateDiv.Controls.Add(dateLabel);

        HtmlGenericControl timeDiv = new HtmlGenericControl("div");
        timeDiv.Attributes["class"] = "time";
        detailsDiv.Controls.Add(timeDiv);

        Label timeIcon = new Label();
        timeIcon.CssClass = "far fa-clock";
        timeDiv.Controls.Add(timeIcon);

        Label timeLabel = new Label();
        timeLabel.Text = eventData.eventTime.ToString(@"hh\:mm");
        timeDiv.Controls.Add(timeLabel);

        Button seeMoreButton = new Button();
        seeMoreButton.Text = "SEE MORE";
        seeMoreButton.CssClass = "learnmoreBtn";
        seeMoreButton.Click += (s, args) => btnLearnMore_Click(s, EventArgs.Empty);
        contentDiv.Controls.Add(seeMoreButton);

        return div;
    }

    protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/addevent.aspx");
        }

        protected void btnLearnMore_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/viewevent.aspx");
        }

        protected List<Guid> GetLastThreePhysicalEventIds()
            {
                List<Guid> lastThreeEventIds = new List<Guid>();

                string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
                string query = "SELECT TOP 3 eventId FROM event WHERE eventLocation IS NOT NULL ORDER BY eventDate DESC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Guid eventId = (Guid)reader["eventId"];
                        lastThreeEventIds.Add(eventId);
                    }

                    reader.Close();
                    connection.Close();
                }

                return lastThreeEventIds;
            }

        protected List<Guid> GetLastThreeVirtualEventIds()
        {
            List<Guid> lastThreeEventIds = new List<Guid>();

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT TOP 3 eventId FROM event WHERE eventLink IS NOT NULL ORDER BY eventDate DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Guid eventId = (Guid)reader["eventId"];
                    lastThreeEventIds.Add(eventId);
                }

                reader.Close();
                connection.Close();
            }

            return lastThreeEventIds;
        }
    }
}