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
                ImageUrl="~/resources/images/rallypic.jpg" />

            <div class="labelsEventMain">
                <asp:Label ID="lblEventTitle" runat="server" Text="CLIMATE ACTION RALLY"></asp:Label>
                <asp:Label ID="lblEventOrganizer" runat="server" Text="Organized by: ">
                    <asp:HyperLink runat="server" ID="eventOrganizerProfile"> Mia Singh</asp:HyperLink>
                </asp:Label>
            </div>

            <div class="profileimgs">
                <asp:Image ID="imgPerson1" runat="server"
                    ImageUrl="~/resources/images/person1.jpg" />
                <asp:Image ID="imgPerson2" runat="server" ImageUrl="~/resources/images/person2.jpg" />
            </div>

            <div class="eventDescDiv">
                <asp:Label ID="lblEventDesc" runat="server" Text="Be a part of our community cleanup effort
                    to maintain a cleaner and greener neighborhood. Join us for a day filled with purpose and positive impact.
                    During the event, you'll have the opportunity to connect with other community members, 
                    contribute to the improvement of our neighborhood, and enjoy a sense of fulfillment in making a tangible difference. 
                    Let's work together to create a cleaner and more sustainable environment for everyone. 
                    Don't miss this chance to be a catalyst for positive change in our community! 
                    RSVP now and be a part of this meaningful initiative."></asp:Label>
            </div>

            <div class="eventDetailsDiv">
                <div class="eventDateDiv">
                    <i class="fa fa-calendar" aria-hidden="true"></i>
                    <asp:Label ID="lblEventDate" runat="server" Text="13 January 2025 "></asp:Label>
                </div>

                <div class="eventTimeDiv">
                    <i class="fa fa-clock" aria-hidden="true"></i>
                    <asp:Label ID="lblEventTime" runat="server" Text="10:AM"></asp:Label>
                </div>

                <div class="eventLocationDiv">
                    <i class="fa fa-map-marker" aria-hidden="true"></i>
                    <asp:Label ID="lblEventLocation" runat="server" Text="Main Park"></asp:Label>
                </div>
            </div>

            <asp:Button ID="btnInterested" runat="server" Text="I AM INTERESTED" />

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
