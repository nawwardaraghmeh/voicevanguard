using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using vv.models;

namespace vv.web_pages
{
    public partial class community : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] != null)
                {
                    loadPosts(); 
                }
                else
                {
                    Response.Redirect("~/webpages/login.aspx");
                }
            }
        }

        private void loadPosts()
        {
            List<Guid> postIds = getPostsIds();
            foreach (Guid postId in postIds)
            {
                PostTemp post = loadPostDetails(postId);
                    Panel postPanel = new Panel();
                    postPanel.CssClass = "post";

                    Label lblPoster = new Label();
                    lblPoster.CssClass = "poster";
                    lblPoster.Text = "By: " + getPosterName(post.userId);
                    postPanel.Controls.Add(lblPoster);

                    Label lblPostTime = new Label();
                    lblPostTime.CssClass = "time";
                    lblPostTime.Text = post.postDate.ToString("yyyy-MM-dd") + " " + post.postTime.ToString(@"hh\:mm");
                    postPanel.Controls.Add(lblPostTime);

                    postPanel.Controls.Add(new LiteralControl("<br />"));

                    HyperLink lnkTitle = new HyperLink();
                    lnkTitle.CssClass = "h4";
                    lnkTitle.Text = post.postTitle;
                    string url = $"~/webpages/viewPost.aspx?postId={postId}";
                lnkTitle.NavigateUrl = url;
                    postPanel.Controls.Add(lnkTitle);

                    postPanel.Controls.Add(new LiteralControl("<br />"));

                    Label lblPostContent = new Label();
                    lblPostContent.CssClass = "postContent";
                    lblPostContent.Text = post.postContent;
                    postPanel.Controls.Add(lblPostContent);

                    postPanel.Controls.Add(new LiteralControl("<br />"));

                    Label lblNumOfComments = new Label();
                    lblNumOfComments.CssClass = "num_of_comments";
                    lblNumOfComments.Text = "Comments: " + getNumofComments(postId).ToString();
                    postPanel.Controls.Add(lblNumOfComments);

                    postsContainer.Controls.Add(postPanel);
                
            }
        }

        private List<Guid> getPostsIds()
        {
            List<Guid> allPostsIds = new List<Guid>();

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT postId FROM post ORDER BY postDate DESC, postTime DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Guid postId = (Guid)reader["postId"];
                    allPostsIds.Add(postId);
                }

                reader.Close();
                connection.Close();
            }

            return allPostsIds;
        }

        private PostTemp loadPostDetails(Guid postId)
        {
            PostTemp postDetails = null;

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT * FROM post WHERE postId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", postId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    postDetails = new PostTemp();
                    postDetails.postTitle = reader["postTitle"].ToString();
                    postDetails.postContent = reader["postContent"].ToString();
                    postDetails.postTime = (TimeSpan)reader["postTime"];
                    postDetails.postDate = (DateTime)reader["postDate"];
                    postDetails.userId = (Guid)reader["userId"];
                    postDetails.postId = (Guid)reader["postId"];
                }

                reader.Close();
                connection.Close();
            }

            return postDetails;
        }

        private String getPosterName(Guid posterId)
        {
            string posterName = null;
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT name FROM users WHERE userId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", posterId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    posterName = reader["name"].ToString();
                }

                reader.Close();
                connection.Close();
            }

            return posterName;
        }

        private int getNumofComments(Guid postId)
        {
            int numOfComments = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString; // Corrected connection string name

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Comments WHERE postId = @postId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@postId", postId);
                conn.Open();

                numOfComments = (int)cmd.ExecuteScalar();
            }

            return numOfComments;
        }

        protected void createPostbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/addpost.aspx");
        }

        protected void title2_Click(object sender, EventArgs e, Guid postId)
        {
            string url = $"~/webpages/viewPost.aspx?postId={postId}";
            Response.Redirect(url);
        }
    }
}
