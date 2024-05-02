<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="vv.web_pages.profile" %>

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
                <a href="notification.aspx" class="nav-item icon"><i class="fa fa-bell" aria-hidden="true">
                </i></a>
                <a href="profile.aspx" class="nav-item icon current-page"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>

    <!-- profile main content -->
    <form id="form1" runat="server">

        <!-- profile page top section -->
        <asp:Image ID="imgBannerPic" runat="server"
            ImageUrl="~/resources/images/profilebanner.jpg" />
        <div class="profileAccountInfo">
            <asp:Image ID="imgProfilePic" runat="server"
                ImageUrl="~/resources/images/profilepic.jpg" />

            <div class="profileAccountInfoTxt">
                <asp:Label ID="lblAccountName" runat="server" Text="Amanda Crowley"></asp:Label>

                <div class="profileAccountInfoGrey">
                    <asp:Label ID="lblJoinDate" runat="server" Text="Joined 3/12/2024"></asp:Label>
                    
                    <asp:HyperLink ID="hLinkEditProfile" runat="server">Edit Profile</asp:HyperLink>
                &nbsp;</div>

                <asp:Label ID="lblAccountBio" runat="server" Text="Hello, I’m Amanda, 
                    and I care about the environment and women’s rights. I believe in Policy and change. 
                    and together, we can change the world for the better"></asp:Label>
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
                        <div class="tabDiv">
                            <asp:Label ID="Label4" runat="server" Text="CLIMATE ACTION RALLY"></asp:Label>
                            <asp:Label ID="Label7" runat="server" Text="1/5/2024"></asp:Label>
                        </div>
                        <div class="tabDiv">
                            <asp:Label ID="Label5" runat="server" Text="VOICES UNVEILED"></asp:Label>
                            <asp:Label ID="Label8" runat="server" Text="7/5/2024"></asp:Label>
                        </div>
                        <div class="tabDiv">
                            <asp:Label ID="Label6" runat="server" Text="SOCIAL JUSTICE READS"></asp:Label>
                            <asp:Label ID="Label9" runat="server" Text="21/6/2024"></asp:Label>
                        </div>
                    </div>
                </asp:View>

            </asp:MultiView>

    </form>

    <!-- footer section -->
    <footer class="footer">
        <div class="footer-content">
            <h2>Contact</h2>
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
