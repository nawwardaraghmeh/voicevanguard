using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vv.webpages
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        protected void loginLink_Click (object sender, EventArgs e)
        {
            Response.Redirect("~/webpages/login.aspx");
        }

    }
}