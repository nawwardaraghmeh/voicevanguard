<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="community.aspx.cs" Inherits="vv.web_pages.community" %>
<%@ Register Src="notifications.ascx" TagName="Notification" TagPrefix="uc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="stylesheet" type="text/css" href="../styles/CommunityPageStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="shortcut icon" type="image/x-icon" href="~/resources/images/icon.ico" />
  <script src="https://kit.fontawesome.com/f6d959a275.js" crossorigin="anonymous"></script>


    <title>COMMUNITY PAGE </title>
</head>
<body>

    <!-- header section -->
    <nav class="navbar">
        <div class="navbar-container">
            <div class="navbar-left">
                <a href="home.aspx" class="nav-item">HOME</a>
                <a href="events.aspx" class="nav-item">EVENTS</a>
                <a href="community.aspx" class="nav-item  current-page">COMMUNITY</a>
                <a href="faq.aspx" class="nav-item">FAQs</a>
            </div>
            <div class="navbar-right">
               <!-- <div class="nav-item icon"><i class="fa fa-bell" aria-hidden="true"></i></div>-->
                <a href="profile.aspx" class="nav-item icon"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />


    <form runat="server">
        <uc:Notification ID="Notification1" runat="server" />
        <div id="heroDiv">
            <div class="buttons">
            <asp:Button runat="server" ID="createPostbtn" Text="Join the community, Ignite the Action"
                OnClick="createPostbtn_Click" />
            <div class="greybtnDiv">
            <asp:Button runat="server" ID="mostPopularbtn" CssClass="greybtnstyles" Text="Most Popular" OnClick="mostPopularbtn_Click" />
            <asp:Button runat="server" ID="recentPostsbtn" CssClass="greybtnstyles" Text="Recent Posts" OnClick="recentPostsbtn_Click" /> 
                </div>
            </div>
            <asp:Panel runat="server" CssClass="SecondDiv" ID="postsContainer">
               
            </asp:Panel>
        </div>
        </form>
    <br />
    <br />

    <!-- footer section -->
    <footer class="footer">
        <div class="footer-content">
            <h2>Contactt</h2>
            <p>
                <a href="mailto:voicevanguardofficial@gmail.com" class="contact-info">voicevanguardofficial@gmail.com</a>
            </p>
            <br />
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
