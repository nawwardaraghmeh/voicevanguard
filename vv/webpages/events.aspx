﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="vv.web_pages.events" %>

<%@ Register Src="notifications.ascx" TagName="Notification" TagPrefix="uc" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="stylesheet" type="text/css" href="../styles/eventspageStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="shortcut icon" type="image/x-icon" href="~/resources/images/icon.ico" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>EVENTS PAGE </title>
</head>
<body>

    <!-- header section -->
    <nav class="navbar">
        <div class="navbar-container">
            <div class="navbar-left">
                <a href="home.aspx" class="nav-item">HOME</a>
                <a href="events.aspx" class="nav-item current-page">EVENTS</a>
                <a href="community.aspx" class="nav-item">COMMUNITY</a>
                <a href="faq.aspx" class="nav-item">FAQs</a>
            </div>
            <div class="navbar-right">
                <a href="profile.aspx" class="nav-item icon"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>

    <br />


    <form id="form1" class="events-main" runat="server">
        <uc:Notification ID="Notification1" runat="server" />
        <div class="events-top">
            <asp:Button ID="btnAddEvent" runat="server" Text="ADD EVENT"
                OnClick="btnAddEvent_Click" />
            <div class="search-container">
            </div>
            <div class="search-box">
                <i class="fas fa-search"></i>
                <asp:TextBox runat="server" placeholder="Enter Keyword/s" name="search" ID="txtboxUserSearch">
                </asp:TextBox>
                <asp:Button runat="server" ID="btnSearch" Text="SEARCH"
                    OnClick="btnSearch_Click" />
            </div>
        </div>

        <!-- matching events section -->
        <asp:Label runat="server" ID="lblMatchingEventsSection" CssClass="h1" Text="Matching Events"></asp:Label>
        <br />
        <asp:Panel runat="server" ID="matchingEventsContainer" CssClass="card-container">
        </asp:Panel>

        <!-- recommended for you section -->
        <asp:Label runat="server" ID="lblFirstEventsSection" CssClass="h1" Text="Recommended For You"></asp:Label>
        <br />
        <asp:Panel runat="server" ID="physicalEventContainer" CssClass="card-container">
        </asp:Panel>
        <asp:PlaceHolder runat="server" ID="placeholder1"></asp:PlaceHolder>
        <asp:LinkButton runat="server" class="seemore" ID="physicalClicktoSeeMore"
            OnClick="physicalClicktoSeeMore_Click"> Click to see more! </asp:LinkButton>

        <!-- events coming up section -->
        <br />
        <br />
        <asp:Label runat="server" ID="lblSecondEventsSection" CssClass="h1" Text="Events Coming Up"></asp:Label>
        <br />
        <asp:Panel runat="server" CssClass="card-container" ID="virtualEventContainer">
        </asp:Panel>
        <asp:LinkButton runat="server" class="seemore" ID="virtualClicktoSeeMore"
            OnClick="virtualClicktoSeeMore_Click"> Click to see more! </asp:LinkButton>
    </form>

    <br />

    <!-- footer section -->
    <footer class="footer">
        <div class="footer-content">
            <h2>Contactt</h2>
            <p>
                <a href="mailto:voicevanguardofficial@gmail.com" class="contact-info">voicevanguardofficial@gmail.com</a>
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
