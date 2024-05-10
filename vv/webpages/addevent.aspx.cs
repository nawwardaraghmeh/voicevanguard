using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vv.models;

namespace vv.webpages
{
    public partial class addevent : System.Web.UI.Page
    {
        Guid userId;
        List<string> selectedTags = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["userId"] != null)
                {
                    userId = new Guid(Session["UserId"].ToString());

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
        }

        protected void btnAddNewEvent_Click(object sender, EventArgs e)
        {
            EventTemp eventobj = new EventTemp();
            Guid eventId = Guid.NewGuid();
            string title = txtTitle.Text;
            string desc = txtDesc.Text;
            string location = txtLocation.Text;
            string room = txtRoom.Text;
            string link = txtLink.Text;
            string pic = eventPicUpload.FileName;
            string tags = selectTags.ToString();

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

            if (location != null && room != null)
            {
                eventobj.addEvent(eventId, userId, title, desc, location, room, "", pic, tags, date, time, duration);
            }
            else if (location != null && room == null)
            {
                eventobj.addEvent(eventId, userId, title, desc, location, "", "", pic, tags, date, time, duration);
            }
            else if (link != null)
            {
                eventobj.addEvent(eventId, userId, title, desc, "", "", link, pic, tags, date, time, duration);
            }
        }
    }
}