using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vv.models;

namespace vv.webpages
{
    public partial class viewPost : System.Web.UI.Page
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

                string postIdString = Request.QueryString["postId"];
                if (!string.IsNullOrEmpty(postIdString) && Guid.TryParse(postIdString, out Guid postId))
                {
                    PostTemp postDetails = LoadPostDetails(postId);
                    UpdatePostDetails(postDetails);
                    
                }
            }
        }

        private PostTemp LoadPostDetails(Guid postId)
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
                    postDetails = new PostTemp
                    {
                        postTitle = reader["postTitle"].ToString(),
                        postContent = reader["postContent"].ToString(),
                        postTime = (TimeSpan)reader["postTime"],
                        postDate = (DateTime)reader["postDate"],
                        userId = (Guid)reader["userId"],
                        postId = postId
                    };
                }

                reader.Close();
            }

            return postDetails;
        }

        private void UpdatePostDetails(PostTemp postDetails)
        {
            postTitle.Text = postDetails.postTitle;
            postContent.Text = postDetails.postContent;
            postDate.Text = postDetails.postDate.ToString("dd MMMM yyyy") + " " + postDetails.postTime.ToString(@"hh\:mm");
            userName.Text = getPosterName(postDetails.userId);
            commentNumber.Text = getNumofComments(postDetails.postId).ToString() + " Comments";

            List<Guid> comments = getCommentsIds(postDetails.postId);
            foreach (Guid id in comments)
            {
                CommentTemp comment = loadCommentDetails(id);
                createCommentContainer(comment);
            }
        }

        private void createCommentContainer(CommentTemp comment)
        {
            Panel commentDiv = new Panel();
            commentDiv.CssClass = "commentsDetails";

            Panel alignNameAndPostdate = new Panel();
            alignNameAndPostdate.CssClass = "alignNameAndPostdate";

            Label lblUserName = new Label();
            lblUserName.CssClass = "commenterName";
            lblUserName.Text = getPosterName(comment.userId);
            alignNameAndPostdate.Controls.Add(lblUserName);

            Label lblCommentPostDate = new Label();
            lblCommentPostDate.CssClass = "commentPostDate";
            lblCommentPostDate.Text = comment.commentDate.ToString("dd MMMM yyyy") + " " + comment.commentTime.ToString(@"hh\:mm");
            alignNameAndPostdate.Controls.Add(lblCommentPostDate);

            commentDiv.Controls.Add(alignNameAndPostdate);

            Label lblCommentContent = new Label();
            lblCommentContent.CssClass = "commentContent";
            lblCommentContent.Text = comment.commentContent;
            commentDiv.Controls.Add(lblCommentContent);

            commentDiv.Controls.Add(new LiteralControl("<br />"));

            commentContainer.Controls.Add(commentDiv);
        }

        private CommentTemp loadCommentDetails(Guid commentId)
        {
            CommentTemp commentDetails = null;

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT * FROM Comments WHERE commentId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", commentId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    commentDetails = new CommentTemp
                    {
                        commentContent = reader["commentContent"].ToString(),
                        commentTime = (TimeSpan)reader["commentTime"],
                        commentDate = (DateTime)reader["commentDate"],
                        userId = (Guid)reader["userId"]
                    };
                }

                reader.Close();
            }

            return commentDetails;
        }

        private List<Guid> getCommentsIds(Guid postId)
        {
            List<Guid> allCommentsIds = new List<Guid>();

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT commentId FROM Comments WHERE postId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", postId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Guid commentId = (Guid)reader["commentId"];
                    allCommentsIds.Add(commentId);
                }

                reader.Close();
            }

            return allCommentsIds;
        }

        private int getNumofComments(Guid postId)
        {
            int numOfComments = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;

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

        private string getPosterName(Guid posterId)
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
            }

            return posterName;
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {

        }
    }
}
