﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notification.aspx.cs" Inherits="vv.webpages.notification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="stylesheet" type="text/css" href="../styles/notifPageStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>VV PROFILE PAGE </title>
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
                <a href="notification.aspx" class="nav-item icon current-page"><i class="fa fa-bell"
                    aria-hidden="true"></i></a>
                <a href="profile.aspx" class="nav-item icon"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>


    <form id="notifMainForm" runat="server">
        <div class="notifTemp">
            <asp:Image ID="notifImage" runat="server"
                ImageUrl="~/resources/images/person2.jpg" />
            <div class="notifTextDiv">
                <asp:Label ID="lblNotifBody" runat="server" Text="X started following you"></asp:Label>
                <asp:HyperLink ID="hLinkCheckNotif" runat="server">Check it out!</asp:HyperLink>
            </div>
        </div>

        <div class="notifTemp">
            <asp:Image ID="Image1" runat="server"
                ImageUrl="~/resources/images/person2.jpg" />
            <div class="notifTextDiv">
                <asp:Label ID="Label1" runat="server" Text="X started following you"></asp:Label>
                <asp:HyperLink ID="HyperLink1" runat="server">Check it out!</asp:HyperLink>
            </div>
        </div>

        <div class="notifTemp">
            <asp:Image ID="Image2" runat="server"
                ImageUrl="~/resources/images/person2.jpg" />
            <div class="notifTextDiv">
                <asp:Label ID="Label2" runat="server" Text="X started following you"></asp:Label>
                <asp:HyperLink ID="HyperLink2" runat="server">Check it out!</asp:HyperLink>
            </div>
        </div>
    </form>

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