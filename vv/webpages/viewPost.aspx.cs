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
using vv.web_pages;

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

            // Calculate the time difference for post date and time
            DateTime postDateTime = postDetails.postDate.Add(postDetails.postTime);
            TimeSpan timeDifference = DateTime.Now - postDateTime;
            string timeText;
            if (timeDifference.TotalMinutes < 60)
                timeText = $"{(int)timeDifference.TotalMinutes}m ago";
            else if (timeDifference.TotalHours < 24)
                timeText = $"{(int)timeDifference.TotalHours}h ago";
            else
                timeText = $"{(int)timeDifference.TotalDays}d ago";

            postDate.Text = timeText;
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
            alignNameAndPostdate.CssClass = "alignCommenternameAndCommentdate";

            Label lblUserName = new Label();
            lblUserName.CssClass = "commenterName";
            lblUserName.Text = getPosterName(comment.userId);
            alignNameAndPostdate.Controls.Add(lblUserName);

            // Calculate the time difference for comment date and time
            DateTime commentDateTime = comment.commentDate.Add(comment.commentTime);
            TimeSpan timeDifference = DateTime.Now - commentDateTime;
            string timeText;
            if (timeDifference.TotalMinutes < 60)
                timeText = $"{(int)timeDifference.TotalMinutes}m ago";
            else if (timeDifference.TotalHours < 24)
                timeText = $"{(int)timeDifference.TotalHours}h ago";
            else
                timeText = $"{(int)timeDifference.TotalDays}d ago";

            Label lblCommentPostDate = new Label();
            lblCommentPostDate.CssClass = "commentPostDate";
            lblCommentPostDate.Text = timeText;
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
            CommentTemp comment = new CommentTemp();

            Guid userId = new Guid(Session["UserId"].ToString());
            string commentContent = postComment.Text;
            string postIdString = Request.QueryString["postId"];
            Guid postId = new Guid(postIdString);
            Guid commentId = Guid.NewGuid();
            int x = comment.addComment(postId, userId, commentId, commentContent);

            if(x != 0)
            {
                Guid notifid = Guid.NewGuid();
                NotifTemp notif = new NotifTemp();
                TimeSpan time = DateTime.Now - DateTime.Today;
                DateTime date = DateTime.Now;
                notif.addCommentNotif(notifid, userId, postId, commentId, "CommentAddition", date, time);
                sendNotifToPoster(postId);
            }

            Response.Redirect(Request.RawUrl);
        }

        private void sendNotifToPoster(Guid postid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["VoiceVanguardDB"].ConnectionString;
            string query = "SELECT userId FROM post where postId = @id";
            Guid userid = Guid.Empty;
            Guid commentid = Guid.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", postid);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userid = (Guid)reader["userId"];
                    Guid notifid = Guid.NewGuid();
                    NotifTemp notif = new NotifTemp();
                    TimeSpan time = DateTime.Now - DateTime.Today;
                    DateTime date = DateTime.Now;
                    notif.addCommentNotiftoPoster(notifid, userid, postid, "CommentAddedtoPost", date, time);
                }

            }
        }
    }
}
