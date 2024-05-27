using Google.Cloud.Vision.V1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vv.models;
using Image = Google.Cloud.Vision.V1.Image;

namespace vv.webpages
{
    public partial class addevent : System.Web.UI.Page
    {
        int x;
        List<string> selectedTags = new List<string>();

        private readonly string _tempDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
        private readonly string _uploadsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");

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

            if (!Directory.Exists(_tempDirectory))
            {
                Directory.CreateDirectory(_tempDirectory);
            }

            if (!Directory.Exists(_uploadsDirectory))
            {
                Directory.CreateDirectory(_uploadsDirectory);
            }
        }

        protected void rbtnPhysical_CheckedChanged(object sender, EventArgs e)
        {
            txtLink.Enabled = false;
            txtLink.BackColor = System.Drawing.Color.LightGray;

            txtLocation.Enabled = true;
            txtRoom.Enabled = true;
            txtLocation.BackColor = System.Drawing.Color.White;
            txtRoom.BackColor = System.Drawing.Color.White;
        }

        protected void rbtnVirtual_CheckedChanged(object sender, EventArgs e)
        {
            txtLink.Enabled = true;
            txtLink.BackColor = System.Drawing.Color.White;

            txtLocation.Enabled = false;
            txtRoom.Enabled = false;
            txtLocation.BackColor = System.Drawing.Color.LightGray;
            txtRoom.BackColor = System.Drawing.Color.LightGray;

        }


        protected void selectTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in selectTags.Items)
            {
                if (item.Selected)
                {
                    selectedTags.Add(item.Text);
                }
            }
            eventstagslabel.Text = "#" + string.Join(" #", selectedTags);
            string eventTags = string.Join(",", selectedTags);
        }

        protected void btnAddNewEvent_Click(object sender, EventArgs e)
        {
            EventTemp eventobj = new EventTemp();

            Guid userId =  new Guid(Session["UserId"].ToString());
            Guid eventId = Guid.NewGuid();
            string title = txtTitle.Text;
            string desc = txtDesc.Text;
            string location = txtLocation.Text;
            string room = txtRoom.Text;
            string link = txtLink.Text;
            string relativePath ="";
            /*string pic = eventPicUpload.ToString();*/
            //string tags = selectTags.ToString();

            if (eventPicUpload.HasFile)
            {
                /* var tempFilePath = Path.Combine(_tempDirectory, Guid.NewGuid().ToString() + Path.GetExtension(eventPicUpload.FileName));
                 eventPicUpload.SaveAs(tempFilePath);
                 var isSafe = IsImageSafe(tempFilePath).GetAwaiter().GetResult();
                 if (!isSafe)
                 {
                     File.Delete(tempFilePath);
                     MessageLabel.Text = "The uploaded image contains inappropriate content.";
                     return;
                 }

                 string fileName = Path.GetFileName(eventPicUpload.FileName);

                 var permanentFilePath = Path.Combine(_uploadsDirectory, eventPicUpload.FileName);
                 File.Move(tempFilePath, permanentFilePath);
                 eventPicUpload.SaveAs(permanentFilePath);
                 relativePath = "~/Uploads/" + fileName; 

                 MessageLabel.Text = "Image uploaded successfully.";
                 MessageLabel.ForeColor = System.Drawing.Color.Green;*/


                string folderPath = Server.MapPath("~/Uploads/");

                // Create the directory if it does not exist
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = Path.GetFileName(eventPicUpload.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                eventPicUpload.SaveAs(filePath);
                relativePath = "~/Uploads/" + fileName;
            }

            foreach (ListItem item in selectTags.Items)
            {
                if (item.Selected)
                {
                    selectedTags.Add(item.Text);
                }
            }
            string eventTags = string.Join(",", selectedTags);
            string tags = eventTags;

            int timeH = int.Parse(selectTimeH.SelectedValue);
            int timeM = int.Parse(selectTimeM.SelectedValue);
            TimeSpan time = new TimeSpan(timeH, timeM, 0);

            int durationH = int.Parse(selectDurationH.SelectedValue);
            int durationM = int.Parse(selectDurationM.SelectedValue);
            TimeSpan duration = new TimeSpan(durationH, durationM, 0);

            int day = int.Parse(ddlDay.SelectedValue);
            int month = int.Parse(ddlMonth.SelectedValue);
            int year = int.Parse(ddlYear.SelectedValue);
            DateTime date = new DateTime(year, month, day);

            x = eventobj.addEvent(eventId, userId, title, desc, location, room, link, relativePath, tags, date, time, duration);


            if (x > 0)
            {
                Guid notifid = Guid.NewGuid();
                DateTime notifDate = DateTime.Today;
                TimeSpan notifTime = DateTime.Now - DateTime.Today;
                NotifTemp notif = new NotifTemp();
                notif.addNotif(notifid, userId, eventId, "EventAddition", notifDate, notifTime);

                string dataToSend = "Event was added successfully!\nThank you for your contribution.";
                string url = "popups/eventAdditionPopup.aspx?data=" + Server.UrlEncode(dataToSend);
                string script = "window.open('" + url + "', '_blank', 'width=400,height=250,top=250,left=450,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');";
                ClientScript.RegisterStartupScript(this.GetType(), "openwindow", script, true);
            }
            else
            {
                string dataToSend = "Event addition failed.\nPlease try again later!";
                string url = "popups/eventAdditionPopup.aspx?data=" + Server.UrlEncode(dataToSend);
                string script = "window.open('" + url + "', '_blank', 'width=400,height=300,top=250,left=450,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');";
                ClientScript.RegisterStartupScript(this.GetType(), "openwindow", script, true);
            }
        }

      
    }
}