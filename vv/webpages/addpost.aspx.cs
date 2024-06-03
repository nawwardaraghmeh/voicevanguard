using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vv.models;

namespace vv
{
    public partial class addpost : System.Web.UI.Page
    {
        int x;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void postBtn_Click(object sender, EventArgs e)
        {

            PostTemp postobj = new PostTemp();

            Guid userId = new Guid(Session["UserId"].ToString());
            Guid postId = Guid.NewGuid();
            string postTitle = titleBox.Text;
            string postContent = contentBox.Text;

            x = postobj.addPost(userId, postId, postTitle, postContent);

            if (x > 0)
            {
                Guid notifid = Guid.NewGuid();
                DateTime notifDate = DateTime.Today;
                TimeSpan notifTime = DateTime.Now - DateTime.Today;
                NotifTemp notif = new NotifTemp();
                notif.addNotif(notifid, userId, postId, "PostAddition", notifDate, notifTime);

                string dataToSend = "Post was added successfully!\nThank you for your contribution.";
                string url = "popups/postAdditionPopup.aspx?data=" + Server.UrlEncode(dataToSend);
                string script = "window.open('" + url + "', '_blank', 'width=400,height=250,top=250,left=450,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');";
                ClientScript.RegisterStartupScript(this.GetType(), "openwindow", script, true);
            }
            else
            {
                string dataToSend = "Post addition failed.\nPlease try again later!";
                string url = "popups/postAdditionPopup.aspx?data=" + Server.UrlEncode(dataToSend);
                string script = "window.open('" + url + "', '_blank', 'width=400,height=300,top=250,left=450,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');";
                ClientScript.RegisterStartupScript(this.GetType(), "openwindow", script, true);
            }

        }
    }
}