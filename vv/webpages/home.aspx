<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faq.aspx.cs" Inherits="vv.web_pages.faq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
        <link rel="stylesheet" type="text/css" href="../styles/homepageStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>VV HOME PAGE </title>
</head>
<body>
    <nav class="navbar">
        <div class="navbar-container">
            <div class="navbar-left">
                <a href="home.aspx" class="nav-item current-page">HOME</a>
                <a href="events.aspx" class="nav-item">EVENTS</a>
                <a href="community.aspx" class="nav-item">COMUUNITY</a>
                <a href="faq.aspx" class="nav-item" >FAQs</a>
            </div>
            <div class="navbar-right">
                <a href="#" class="nav-item icon"><i class="fa fa-bell" aria-hidden="true"></i></a>
                <a href="profile.aspx" class="nav-item icon"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>

       <form id="form2" runat="server">
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

     <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />

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
        </div>

        <div class="bottom-bar">
            <p><i class="fa fa-copyright" aria-hidden="true"></i>2024 VoiceVanguard. All rights
                reserved</p>
        </div>
    </footer>
</body>
</html>
