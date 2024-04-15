<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs"  Inherits="vv.web_pages.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/homepageStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">

    <title>VV HOMEPAGE</title>
</head>
<body style="width:100vw; height:100vh; margin=0">
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="headerPanel" CssClass="headerPanel" runat="server" BackColor="#E5E3E4"
                ForeColor="Black" Width="100%" BorderStyle="None">

                <asp:Button ID="mainbtnSignup" CssClass="heroBtn" runat="server" Text="SIGNUP" 
                    Font-Bold="True" Width="95px" />

                <asp:Button ID="mainbtnLogin"  CssClass="heroBtn" runat="server" Text="LOGIN" 
                     Font-Bold="True" Width="95px" />

                <asp:Image ID="imgLogo" CssClass="imgLogo" runat="server" Height="29px" ImageUrl="~/resources/images/logo.png"
                    Width="188px" />

                <br />
                <br />
                <br />
                <br />
                <br />
            </asp:Panel>
        </div>
        <asp:Image ID="Image1" runat="server" Height="524px" ImageUrl="~/resources/images/header.png"
            Width="100%" />
        <asp:Image ID="imgAboutus" CssClass="imgAboutus" runat="server" ImageUrl="~/resources/images/aboutusPic.png" />
        <asp:Image ID="imgAboutusTxt" CssClass="imgAboutusTxt" runat="server" ImageUrl="~/resources/images/aboutusText.png" />
        <p>
            &nbsp;
        </p>
        <p>
            &nbsp;
        </p>
        <asp:Label ID="lblAboutus" runat="server" Text="VoiceVanguard is a platform designed to address
            the evolving landscape of social activism in an era
            of unparalleled connectivity. The conventional
            methods of communication utilized by activist
            communities are struggling to meet the ever-
            changing demands of modern movements.
            In order to bridge this gap, VoiceVanguard offers
            a specialized digital space equipped with a range
            of features including event scheduling, user
            authentication, and discussion forums."
            CssClass="lblAboutus" Font-Bold="False" Font-Names="Century" Font-Size="19pt"
            ForeColor="#656262" Width="500px"></asp:Label>
    </form>
</body>
</html>