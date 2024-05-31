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
        PostTemp postDetails = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["userId"] != null)
                {
                    //userId = new Guid(Session["UserId"].ToString());

                }

                else
                {
                    Response.Redirect("~/webpages/login.aspx");
                }

                string eventIdString = Request.QueryString["postId"];
                if (!string.IsNullOrEmpty(eventIdString) && Guid.TryParse(eventIdString, out Guid eventId))
                {
                    postDetails = LoadPostDetails(postId);
                    UpdatePostDetails(postDetails);
                }
                else
                {
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
                        postDetails = new PostTemp();
                        postDetails.postTitle = reader["postTitle"].ToString();
                        postDetails.postContent = reader["postContent"].ToString();
                        postDetails.postTime = (TimeSpan)reader["postTime"];
                        postDetails.postDate = (DateTime)reader["postDate"];
                        postDetails.userId = (Guid)reader["userId"];
                    }

                    reader.Close();
                    connection.Close();
                }

                return postDetails;
            }

            private void UpdatePostDetails(PostTemp postDetails)
            {
                postTitle.Text = postDetails.postTitle;
                postContent.Text = postDetails.postContent;
                postDate.Text = postDetails.postDate.ToString("dd MMMM yyyy");
            userName.Text = getPosterName(postDetails.userId);
            commentNumber.Text = getNumofComments(postDetails.postId).ToString();



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
            lblCommentPostDate.Text = comment.commentDate.ToString() + " " + comment.commentTime.ToString();
            alignNameAndPostdate.Controls.Add(lblCommentPostDate);

            commentDiv.Controls.Add(alignNameAndPostdate);

            Label lblCommentContent = new Label();
            lblCommentContent.CssClass = "commentContent";
            lblCommentContent.Text = comment.commentContent;
            commentDiv.Controls.Add(lblCommentContent);

            commentDiv.Controls.Add(new LiteralControl("<br />"));


            commentContainer.Controls.Add(commentDiv);
        }

        private CommentTemp loadCommentDetails(Guid commentid)
        {
            CommentTemp commentDetails = null;

            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT * FROM Comments WHERE commentId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", commentid);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    commentDetails = new CommentTemp();
                    commentDetails.commentContent = reader["commentContent"].ToString();
                    commentDetails.commentTime = (TimeSpan)reader["commentTime"];
                    commentDetails.commentDate = (DateTime)reader["commentDate"];
                    commentDetails.userId = (Guid)reader["userId"];
                }

                reader.Close();
                connection.Close();
            }

            return commentDetails;
        }

        protected List<Guid> getCommentsIds(Guid postId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT commentId FROM Comments WHERE postId = @id";
            List<Guid> allCommentsIds = new List<Guid>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", postId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Guid userid = (Guid)reader["userId"];
                    allCommentsIds.Add(userid);
                }

                reader.Close();
            }
            return allCommentsIds;
        }

        private int getNumofComments(Guid postId)
        {
            int numOfComments = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

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

        private String getPosterName(Guid posterId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT * FROM users WHERE userId = @id";

            String posterName;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", posterId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    posterName = reader["name"].ToString();

                    Guid userId = new Guid(Session["UserId"].ToString());
                    Guid id = new Guid(reader["userId"].ToString());

                    return posterName;
                }

                reader.Close();
                connection.Close();
            }
            return null;
        }


    }
}
}