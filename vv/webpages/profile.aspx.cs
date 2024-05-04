using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace vv.web_pages
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\CRC\\Desktop\\Y4S2\\senior\\vv\\vv\\App_Data\\VV.mdf;Integrated Security=True";
            string query = "SELECT name, dateCreated, bio, profilePic, bannerPic FROM users WHERE userId = @userId";

            if (!IsPostBack)
            {
                if (Session["userId"] != null)
                {
                    string userId = Session["UserId"].ToString();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@userId", userId);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            
                            string name = reader["name"].ToString();
                            DateTime dateCreated = (DateTime)reader["dateCreated"];
                            string formattedDate = dateCreated.ToString("yyyy/MM/dd");
                            string bio = reader["bio"].ToString();
                            //Session["profilePic"] = reader["profilePic"].ToString();
                            //Session["bannerPic"] = reader["bannerPic"].ToString();

                            lblAccountName.Text = name;
                            lblJoinDate.Text = "Joined" + formattedDate;

                            if(string.IsNullOrEmpty(bio))
                            {
                                lblAccountBio.Text = "No Bio Yet";
                            }
                            else
                            {
                                lblAccountBio.Text = bio;
                            }
                        }
                        reader.Close();
                    }
                }

                else
                {
                    Response.Redirect("~/login.aspx");
                }
                
                btnMyActivity.CssClass = "clickedBtn";
                MainView.ActiveViewIndex = 0;
            }
          
        }

        protected void btnMyActivity_Click(object sender, EventArgs e)
        {
            btnMyActivity.CssClass = "clickedBtn";
            btnUpcomingEvents.CssClass = "initialBtn";
            MainView.ActiveViewIndex = 0;
        }

        protected void btnUpcomingEvents_Click(object sender, EventArgs e)
        {
            btnMyActivity.CssClass = "initialBtn";
            btnUpcomingEvents.CssClass = "clickedBtn";
            MainView.ActiveViewIndex = 1;
        }

    }
}