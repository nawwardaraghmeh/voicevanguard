using Antlr.Runtime.Misc;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using vv.models;

namespace vv.web_pages
{
    public partial class events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/webpages/login.aspx");
                    return;
                }
            }
            LoadInitialEvents();
            lblMatchingEventsSection.Visible = false;
            matchingEventsContainer.Visible = false;

        }

        private void LoadInitialEvents()
        {
            List<Guid> recommendedEventsIds = GetAllRecommendedEventsIds().Take(3).ToList();
            foreach (Guid id in recommendedEventsIds)
            {
                HtmlGenericControl physicalEventControl = CreateEventControl(id);
                physicalEventContainer.Controls.Add(physicalEventControl);
            }

            List<Guid> upcomingEventsIds = GetAllUpcomingEvents().Take(3).ToList();
            foreach (Guid id in upcomingEventsIds)
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


        string imageUrl = eventData.eventPic;

        Image image = new Image();
        image.ImageUrl = imageUrl; 
        div.Controls.Add(image);

        HtmlGenericControl contentDiv = new HtmlGenericControl("div");
        contentDiv.Attributes["class"] = "content";
        div.Controls.Add(contentDiv);

        Label titleLabel = new Label();
        titleLabel.CssClass = "eventTitleStyles";
        titleLabel.Text = eventData.eventTitle.ToUpper();
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
        dateLabel.Text = "  " + eventData.eventDate.ToString("dd MMMM yyyy");
            dateDiv.Controls.Add(dateLabel);

        HtmlGenericControl timeDiv = new HtmlGenericControl("div");
        timeDiv.Attributes["class"] = "time";
        detailsDiv.Controls.Add(timeDiv);

        Label timeIcon = new Label();
        timeIcon.CssClass = "far fa-clock";
        timeDiv.Controls.Add(timeIcon);

        Label timeLabel = new Label();
        timeLabel.Text = "  " + eventData.eventTime.ToString(@"hh\:mm");
        timeDiv.Controls.Add(timeLabel);

        Button seeMoreButton = new Button();
        seeMoreButton.Text = "SEE MORE";
        seeMoreButton.CssClass = "learnmoreBtn";
        seeMoreButton.Click += (s, args) => btnLearnMore_Click(s, EventArgs.Empty, eventId);
        contentDiv.Controls.Add(seeMoreButton);

        return div;
        }

        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/addevent.aspx");
        }

        protected void btnLearnMore_Click(object sender, EventArgs e, Guid eventId)
        {
            string url = $"~/webpages/viewevent.aspx?eventId={eventId}";
            Response.Redirect(url);
        }

        protected string getUserTags(Guid userid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            Guid userId = new Guid(Session["UserId"].ToString());
            string userQuery = "SELECT interests FROM users WHERE userId = @userid";
            string userTags = "";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(userQuery, connection);
                command.Parameters.AddWithValue("@userid", userId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userTags = reader["interests"].ToString();
                    return userTags;
                }
                else
                {
                }
                reader.Close();
            }
            return null;
        }

        protected List<Guid> GetAllRecommendedEventsIds()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            Guid userId = new Guid(Session["UserId"].ToString());
            string userTags = getUserTags(userId);

            List<Guid> allRecommendedEventsIds = new List<Guid>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = string.IsNullOrEmpty(userTags) ?
                               "SELECT eventId FROM event ORDER BY eventDateCreated DESC" :
                               "SELECT eventId FROM event WHERE eventTags LIKE '%' + @usertags + '%'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(userTags))
                    {
                        command.Parameters.AddWithValue("@usertags", userTags);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Guid eventId = (Guid)reader["eventId"];
                                    allRecommendedEventsIds.Add(eventId);
                                }
                            }
                        }
                    }

                    // if no matches found or userTags is null/empty, fallback to the second query
                    if (allRecommendedEventsIds.Count == 0)
                    {
                        command.CommandText = "SELECT eventId FROM event ORDER BY eventDateCreated DESC";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Guid eventId = (Guid)reader["eventId"];
                                allRecommendedEventsIds.Add(eventId);
                            }
                        }
                    }
                }
            }

            return allRecommendedEventsIds;
        }



        protected List<Guid> GetAllUpcomingEvents()
        {
            List<Guid> allUpcomingEventsIds = new List<Guid>();

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT eventId FROM event ORDER BY eventDate DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Guid eventId = (Guid)reader["eventId"];
                    allUpcomingEventsIds.Add(eventId);
                }

                reader.Close();
                connection.Close();
            }

            return allUpcomingEventsIds;
        }

        
        protected void physicalClicktoSeeMore_Click(object sender, EventArgs e)
        {
            int currentCount = physicalEventContainer.Controls.Count;
            List<Guid> allEventIds = GetAllRecommendedEventsIds().ToList();

            List<Guid> physicalEventIds = GetAllRecommendedEventsIds().Skip(currentCount).Take(3).ToList();
            foreach (Guid id in physicalEventIds)
            {
                HtmlGenericControl physicalEventControl = CreateEventControl(id);
                physicalEventContainer.Controls.Add(physicalEventControl);
            }

            if (currentCount + physicalEventIds.Count >= allEventIds.Count)
            {
                // Hide or disable the "see more" button
                physicalClicktoSeeMore.Visible = false;
            }
        }


        protected void virtualClicktoSeeMore_Click(object sender, EventArgs e)
        {
            int currentCount = virtualEventContainer.Controls.Count;
            List<Guid> allEventIds = GetAllUpcomingEvents().ToList();

            List<Guid> virtualEventIds = GetAllUpcomingEvents().Skip(currentCount).Take(3).ToList();
            foreach (Guid id in virtualEventIds)
            {
                HtmlGenericControl virtualEventControl = CreateEventControl(id);
                virtualEventContainer.Controls.Add(virtualEventControl);
            }

            if (currentCount + virtualEventIds.Count >= allEventIds.Count)
            {
                // Hide or disable the "see more" button
                virtualClicktoSeeMore.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keywords = txtboxUserSearch.Text;
            List<Guid> matchingEventsIds = SearchEvents(keywords);
            lblMatchingEventsSection.Visible = true;
            matchingEventsContainer.Visible = true;
            lblFirstEventsSection.Visible = false;
            virtualEventContainer.Visible = false;
            virtualClicktoSeeMore.Visible = false;
            lblSecondEventsSection.Visible = false;
            physicalClicktoSeeMore.Visible = false;
            physicalEventContainer.Visible = false;

            if (matchingEventsIds != null)
            {
                foreach (Guid id in matchingEventsIds)
                {
                    HtmlGenericControl matchingEventControl = CreateEventControl(id);
                    matchingEventsContainer.Controls.Add(matchingEventControl);
                }
            }
            else
            {
                Label noMatch = new Label();
                noMatch.Text = "No matching events found. Please try different keywords!";
                noMatch.CssClass = "noMatchingEvents";
                matchingEventsContainer.Controls.Add(noMatch);
            }
            
        }

        private List<Guid> SearchEvents(string query)
        {
            List<Guid> eventIds = new List<Guid>();
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string sqlQuery = "SELECT eventId FROM event WHERE eventTitle LIKE @query OR eventDesc LIKE @query OR eventTags LIKE @query";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@query", "%" + query + "%");

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    eventIds.Add((Guid)reader["eventId"]);
                }
            }

            return eventIds;
        }
    }
}