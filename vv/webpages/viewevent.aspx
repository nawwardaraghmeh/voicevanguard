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
            <asp:Image ID="eventMainImg" runat="server" />
            <div class="labelsEventMain">
                <asp:Label ID="lblEventTitle" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblEventOrganizer" runat="server" Text="Label"></asp:Label>
            </div>

            <div>
                <asp:Image ID="imgPerson1" runat="server" />
                <asp:Image ID="imgPerson2" runat="server" />
            </div>

            <asp:Label ID="lblEventDesc" runat="server" Text="Label"></asp:Label>
            
            <div>
                <asp:Label ID="lblEventDate" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblEventTime" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblEventLocation" runat="server" Text="Label"></asp:Label>
            </div>

            <asp:Button ID="btnInterested" runat="server" Text="Button" />

        </div>
    </form>
</body>
</html>
