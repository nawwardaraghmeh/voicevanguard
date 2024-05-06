    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="vv.web_pages.profile" %>
    <%@ Register Src="notifications.ascx" TagName="Notification" TagPrefix="uc" %>
    


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="stylesheet" type="text/css" href="../styles/ProfileStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
     <script src="https://kit.fontawesome.com/f6d959a275.js" crossorigin="anonymous"></script>

    <title>PROFILE PAGE </title>
</head>
<body>
    <!-- header section -->
    <nav class="navbar">
        <div class="navbar-container">
            <div class="navbar-left">
                <a href="index.aspx" class="nav-item">HOME</a>
                <a href="evnets.aspx" class="nav-item">EVENTS</a>
                <a href="community.aspx" class="nav-item">COMUUNITY</a>
                <a href="faq.aspx" class="nav-item">FAQs</a>
            </div>
            <div class="navbar-right">
                <a href="profile.aspx" class="nav-item icon current-page"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>

    <!-- profile main content -->
    <form id="form1" runat="server">
        <uc:Notification ID="Notification1" runat="server" />


        <!-- profile page top section -->

       
        <asp:Image ID="imgBannerPic" runat="server"
            ImageUrl="~/resources/images/defaultbanner.png" CssClass="hoverable" />
        <div class="pencilIcon1"><i class="fa-solid fa-pencil fa-2xl"></i></div>
        <div class="profileAccountInfo">
            <asp:Image ID="imgProfilePic" runat="server"
                ImageUrl="~/resources/images/defaultProfile.jpg" CssClass="hoverable" />
            <div class="pencilIcon2"><i class="fa-solid fa-pencil fa-2xl"></i></div>

            <div class="profileAccountInfoTxt">
                <div id="nameAndPencilDiv">
                <asp:Label ID="lblAccountName" runat="server" Text="Amanda Crowley" CssClass="hoverableLbl"></asp:Label>
                 <div class="pencilIcon3"><i class="fa-solid fa-pencil"></i></div>
                </div>

                <div class="profileAccountInfoGrey">
                    <asp:Label ID="lblJoinDate" runat="server" Text="Joined 3/12/2024"></asp:Label>
                    
                &nbsp;</div>
                <br />
                <br />
                <div class="divTabTitlel">

                    <asp:Button ID="btnMyActivity" CssClass="initialBtn" runat="server"
                        Text="My Activity" OnClick="btnMyActivity_Click"></asp:Button>
                    <asp:Button ID="btnUpcomingEvents" CssClass="initialBtn" runat="server"
                        Text="Upcoming Events" OnClick="btnUpcomingEvents_Click"></asp:Button>

                </div>
            </div>
        </div>


            <!-- tabs section -->
            <asp:MultiView ID="MainView" runat="server">
                <asp:View ID="ActivityView" runat="server">
                    <div class="viewStyles">
                        <div class="tabDiv">
                            <asp:Label ID="Label1" runat="server" Text="You gained a new follower!"></asp:Label>
                        </div>
                        <div class="tabDiv">
                            <asp:Label ID="Label2" runat="server" Text="Y replied to your comment on X post."></asp:Label>
                        </div>
                        <div class="tabDiv">
                            <asp:Label ID="Label3" runat="server" Text="Z created a new event. Check it out"></asp:Label>
                        </div>
                    </div>
                </asp:View>


                <asp:View ID="upcomingEventsView" runat="server">
                    <div class="viewStyles">

                        <asp:Calendar BorderStyle="None" CellPadding="40" CssClass="custom-calendar" 
                            ID="Calendar1" runat="server" AutoPostBack="false" 
                            OnDayRender="Calendar1_DayRender">
                            <DayHeaderStyle BackColor="#a7ddba" />
                            <SelectedDayStyle BackColor="#e46262" />
                            <WeekendDayStyle ForeColor="#F1A7A7" />
                            <OtherMonthDayStyle ForeColor="#545454" />
                            <TodayDayStyle BackColor="#DE2B2B" ForeColor="White" />
                            <TitleStyle ForeColor="#7BCC98" BackColor="White" />
                        </asp:Calendar>
      
                    </div>
                </asp:View>

            </asp:MultiView>

    </form>

    <!-- footer section -->
    <footer class="footer">
        <div class="footer-content">
            <h2>Contactt</h2>
            <p>
                <a href="mailto:voicevanguard@gmail.com" class="contact-info">voicevanguard@gmail.com</a>
            </p>
            <p>+972 12-345-6789</p>
            <div class="social-icons">
                <a href="#" class="icon"><i class="fab fa-facebook-f"></i></a>
                <a href="#" class="icon"><i class="fab fa-instagram"></i></a>
                <a href="#" class="icon"><i class="fab fa-twitter"></i></a>
            </div>
            <p style="font-size: 12px; padding-bottom: 10px;">
                <i class="fa fa-copyright" aria-hidden="true"></i>2024 VoiceVanguard. All rights
                reserved
            </p>
        </div>
    </footer>
</body>
</html>
