<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faq.aspx.cs" Inherits="vv.web_pages.faq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>VV FAQs PAGE </title>
</head>
<body>
    <nav class="navbar">
        <div class="navbar-container">
            <div class="navbar-left">
                <a href="index.aspx" class="nav-item">HOME</a>
                <a href="evnets.aspx" class="nav-item">EVENTS</a>
                <a href="community.aspx" class="nav-item">COMUUNITY</a>
                <a href="faq.aspx" class="nav-item">FAQs</a>
            </div>
            <div class="navbar-right">
                <a href="#" class="nav-item icon"><i class="fa fa-bell" aria-hidden="true"></i></a>
                <a href="profile.aspx" class="nav-item icon"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>

    <form id="form1" runat="server">
        <div>
        </div>
    </form>


    <footer class="footer">
        <div class="footer-container">
            <div class="footer-links">
                <h3>LINKS</h3>
                <ul>
                    <li><a href="index.aspx">Home</a></li>
                    <li><a href="events.aspx">Events</a></li>
                    <li><a href="community.aspx">Community</a></li>
                    <li><a href="faq.aspx">FAQs</a></li>
                </ul>
            </div>
            <div class="footer-logo">   
                <img src="../resources/images/icon.png" alt="Logo">
            </div>
            <div class="footer-contact">
                <h3>CONTACT</h3>
                <p><a href="mailto:voicevanguard@gmail.com">voicevanguard@gmail.com</a></p>
                <p>123-456-789</p>
                <div class="social-icons">
                    <a href="#"><i class="fa fa-facebook-official" aria-hidden="true"></i></a>
                    <a href="#"><i class="fa fa-instagram" aria-hidden="true"></i></a>
                    <a href="#"><i class="fa fa-twitter-square" aria-hidden="true"></i></a>
                </div>
            </div>
        </div>
    </footer>
</body>
</html>
