<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewevent.aspx.cs" Inherits="vv.webpages.viewevent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/eventspageStyles.css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>VV VIEW EVENT PAGE </title>
</head>
<body>
    <form ID="vieweventform" runat="server">
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
                <i class="fa fa-calendar" aria-hidden="true"></i><asp:Label ID="lblEventDate" runat="server" Text="13 January 2025 "></asp:Label>
                </div>

                <div class="eventTimeDiv">
                <i class="fa fa-clock" aria-hidden="true"></i><asp:Label ID="lblEventTime" runat="server" Text="10:AM"></asp:Label>
                </div>

                <div class="eventLocationDiv">
                <i class="fa fa-map-marker" aria-hidden="true"></i><asp:Label ID="lblEventLocation" runat="server" Text="Main Park"></asp:Label>
                </div>
            </div>

            <asp:Button ID="btnInterested" runat="server" Text="I AM INTERESTED" />

        </div>
    </form>
</body>
</html>
