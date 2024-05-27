<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewevent.aspx.cs" Inherits="vv.webpages.viewevent" %>
 <%@ Register Src="notifications.ascx" TagName="Notification" TagPrefix="uc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/viewEventStyles.css" />
        <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>VIEW EVENT PAGE </title>
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
    <br />
    <br />

    <form id="vieweventform" runat="server">
         <uc:Notification ID="Notification1" runat="server" />
        <div>
            <asp:Image ID="eventMainImg" runat="server"
                 />

            <div class="labelsEventMain">
                <asp:Label ID="lblEventTitle" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblEventOrganizer" runat="server" Text="Organized by: ">
                    <asp:HyperLink runat="server" ID="eventOrganizerProfile"></asp:HyperLink>
                </asp:Label>
                <asp:Label ID="lblParticipantCount" runat="server" Text=""></asp:Label>
            </div>
            
            <!--<asp:Panel runat="server" ID="participantsPanel" CssClass="participantsProfileimgs"> </asp:Panel> -->

            <div class="eventDescDiv">
                <asp:Label ID="lblEventDesc" runat="server" Text=""></asp:Label>
                <br /> <br />
                <div class="eventDateNTime">
                    <div class="eventDetailsDiv">
                        <i class="fa fa-calendar eventIcon" aria-hidden="true"></i>
                        <asp:Label ID="lblEventDate" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="eventDetailsDiv">
                        <i class="fa fa-clock eventIcon" aria-hidden="true"></i>
                        <asp:Label ID="lblEventTime" runat="server" Text=""></asp:Label>
                    </div>
                </div>

                <div class="eventLocationNRoom">
                    <div class="eventDetailsDiv">
                        <asp:Label runat="server" ID="eventLocationIconlbl"><i class="fa fa-map-marker eventIcon" aria-hidden="true"></i></asp:Label>
                        <asp:Label ID="lblEventLocation" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="eventDetailsDiv">
                        <asp:Label runat="server" ID="eventRoomIconlbl"><i class="fa fa-building eventIcon" aria-hidden="true"></i></asp:Label>
                        <asp:Label ID="lblEventRoom" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="eventLink">
                <div class="eventDetailsDiv">
                   <asp:Label runat="server" ID="eventLinkIconlbl"><i class="fa fa-link eventIcon" aria-hidden="true"  id="eventLinkIcon"></i></asp:Label>
                    <asp:Label ID="lblEventLink" runat="server" Text=""></asp:Label>
                </div>
                    </div>
            </div>
            <br /><br />
            <asp:Button runat="server" Text="I Am Interested" ID="btnInterested" 
                OnClick="btnInterested_Click" />

        </div>
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
