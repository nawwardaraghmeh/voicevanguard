<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addpost.aspx.cs" Inherits="vv.webpages.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link rel="stylesheet" type="text/css" href="../styles/addPostStyles.css">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <script src="https://kit.fontawesome.com/f6d959a275.js" crossorigin="anonymous"></script>

    <title>ADD POST PAGE</title>
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
                <a href="notification.aspx" class="nav-item icon"><i class="fa fa-bell" aria-hidden="true">
                </i></a>
                <a href="profile.aspx" class="nav-item icon"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>
    <br /> <br /> <br /> <br />

    <form id="form1" runat="server">
        <h1 id="pageTitle">ADD POST</h1>

        <div id="heroDiv">
            <label id="title">TITLE</label><br />
            <input type="text" id="titleBox" required="required" /><br />
            <select>
                <option value="only-me">Only Me</option>
                <option value="only-followers">Only Followers</option>
                <option value="everyone">Everyone</option>
            </select><br />

            <div id="secondDiv">
                <input type="text" id="contentBox" placeholder="What's On Your Mind?" required="required" /><br />
                <div id="text-strip">

                    <label for="imageUpload"><i class="fa-solid fa-image fa-2x"></i></label>
                    <input type="file" id="imageUpload" name="imageUpload" />

                    <i class="fa-regular fa-face-smile fa-2x"></i>
                </div>
            </div>
            <br />
            <asp:Button runat="server" Text="POST" ID="postBtn" />
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
