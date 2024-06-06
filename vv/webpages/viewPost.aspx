<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewPost.aspx.cs" Inherits="vv.webpages.viewPost" %>

<%@ Register Src="notifications.ascx" TagName="Notification" TagPrefix="uc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/viewPostStyle.css" />
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <script src="https://kit.fontawesome.com/f6d959a275.js" crossorigin="anonymous"></script>

    <title>VIEW POST PAGE</title>

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
                <a href="profile.aspx" class="nav-item icon"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>
    <br />
    <br />
    <br />
    <br />

    <form id="form1" runat="server">
        <uc:Notification ID="Notification1" runat="server" />

        <asp:Panel runat="server" CssClass="heroDiv" ID="postDetailsContainer">
            <div class="nameAndPicDiv">
                <div class="alignPosterAndPostdate">
                    <asp:Label ID="userName" runat="server" Text=""></asp:Label>
                    <asp:Label ID="postDate" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div>
                <div id="postDiv">
                    <asp:Label ID="postTitle" runat="server" Text=""></asp:Label>
                    <asp:Label ID="postContent" runat="server" Text=""></asp:Label>
                    <br />
                </div>
                <div id="commentsAndReport">
                    <asp:Label ID="commentNumber" runat="server" Text=""></asp:Label>
                    <!--<asp:HyperLink ID="reportPostLink" runat="server">ReportPost</asp:HyperLink><br />-->
                </div>
            </div>

            <asp:TextBox ID="postComment" runat="server" placeholder="Share Your Thoughts! " TextMode="MultiLine" ></asp:TextBox>
            <br />

            <asp:Label ID="commentLabel" runat="server" Text="COMMENTS"></asp:Label><br />

            <asp:Panel runat="server" CssClass="commentSectionDiv" ID="commentContainer">
                <!--
                <div class="nameAndPicDiv">
                    <div id="commentDiv" class="commentsDetails">

                        <div class="alignNameAndPostdate">
                            <asp:Label ID="userName2" runat="server" Text=""></asp:Label>
                            <asp:Label ID="commentPostDate" runat="server" Text=""></asp:Label>
                        </div>

                        <asp:Label ID="commentContent" runat="server" Text=""></asp:Label><br />

                    </div>
                </div>
                -->
                </asp:Panel>
        </asp:Panel>
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
