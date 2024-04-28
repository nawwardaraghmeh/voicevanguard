<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="community.aspx.cs" Inherits="vv.web_pages.community" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="stylesheet" type="text/css" href="../styles/CommunityPageStyles.css">

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
  <script src="https://kit.fontawesome.com/f6d959a275.js" crossorigin="anonymous"></script>


    <title>VV COMMUNITY PAGE </title>
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
                <a href="notification.aspx" class="nav-item icon"><i class="fa fa-bell" aria-hidden="true"></i></a>
                <a href="profile.aspx" class="nav-item icon"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>
    <br />
    <br />
    <br />
    <br />
    <br />


    <form runat="server">
        <div id="heroDiv">
            <div class="buttons">
            <select>
                <option>Topic</option>
                <option value="women's-Rights">Women's Rights</option>
                <option value="Environment">Environment</option>
                <option value="Racial-Issues">Racial Issues</option>
                <option value="Animal-Rights">Animal Rights</option>
                <option value="Mental-Health">Mental Health</option>
            </select>
            <input type="button" value="Most Popular" />
            <input type="button" value="Recent Posts" />
            <input type="button" value="Trending" />
           
            <asp:Button runat="server" id="createPostbtn" Text="Join the community, Ignite the Action" OnClick="createPostbtn_Click"/>
            </div>
            <div id="SecondDiv">
                <div class="post">
                    <p class="poster">By: Andrew Matt</p><p class="time">2d ago</p><br />
                    <h4>Is this Organization Legitimate?</h4>
                    <p class="postContent">I've come across an organization that claims to support a cause close to my heart,
                        but I want to ensure its legitimacy. 
                        Has anyone had experience with “EarthGuardians”?
                        I heard some bad rumors about it recently, and I ... Read More</p><br />
                    <p class="num_of_comments">25 comments</p>
                </div>
                <div class="post">
                    <p class="poster">By: Isabella Lopez</p><p class="time">3h ago</p><br />
                    <h4>Equality Rally Pictures</h4>
                    <p class="postContent">Captured these moments at today's equality rally. The power of unity! 
                                            💙✊ #SocialJustice #EqualityForAll</p><br />
                    <p class="num_of_comments">17 comments</p>
                </div>
                <div class="post">
                    <p class="poster">By: Aiden Kim </p><p class="time">2w ago</p><br />
                    <h4>Sustainable Living Article</h4>
                    <p class="postContent">Stumbled upon an inspiring article about sustainable living. Dive into the details and let's discuss its impact on our community!
                                            https://www.example.com/sustainable-living</p><br />
                    <p class="num_of_comments">49 comments</p>
                </div>
            </div>
        </div>
        </form>
    <br />
    <br />

    <!-- footer section -->
    <footer class="footer">
        <div class="footer-content">
            <h2>Contact</h2>
            <p>
                <a href="mailto:voicevanguard@gmail.com" class="contact-info">voicevanguard@gmail.com</a>
            </p>
            <br />
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
