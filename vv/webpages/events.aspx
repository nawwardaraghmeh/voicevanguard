<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="vv.web_pages.events" %>

<%@ Register Src="notifications.ascx" TagName="Notification" TagPrefix="uc" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="stylesheet" type="text/css" href="../styles/eventspageStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>EVENTS PAGE </title>
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


    <form id="form1" class="events-main" runat="server">
        <uc:Notification ID="Notification1" runat="server" />
        <div class="events-top">
            <asp:Button ID="btnAddEvent" runat="server" Text="ADD EVENT"
                OnClick="btnAddEvent_Click" />
            <div class="search-container">
            </div>
            <div class="search-box">
                <i class="fas fa-search"></i>
                <asp:TextBox runat="server" placeholder="Enter Keyword/s" name="search">
                </asp:TextBox>
            </div>
        </div>


        <!-- recommended events section -->
        <h1>Recently added</h1>
        <div class="card-container">

            <div class="card">
                <asp:Image runat="server" ID="eventImg" ImageUrl="../resources/images/rallypic.jpg" />
                <div class="content">
                    <asp:Label runat="server" CssClass="eventTitleStyles" ID="lblEventTitle" Text="CLIMATE ACTION RALLY"></asp:Label>
                    <br />
                    <br />
                    <asp:Label runat="server" CssClass="eventDescStyles" ID="lblEventDesc" Text="Join us for a city-wide rally advocating
                        for sustainable practices and urgent climate action.">
                    </asp:Label>

                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <asp:Label runat="server" ID="lblEventDate" Text="Feb 20th"></asp:Label>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <asp:Label runat="server" ID="lblEventTime" Text="10:00 AM"></asp:Label>
                            <br />
                        </div>
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="SEE MORE"
                        CssClass="learnmoreBtn" OnClick="btnLearnMore_Click" />
                </div>
            </div>

            <div class="card">
                <asp:Image runat="server" ID="Image1" ImageUrl="../resources/images/rallypic.jpg" />
                <div class="content">
                    <asp:Label runat="server" CssClass="eventTitleStyles" ID="Label1" Text="CLIMATE ACTION RALLY"></asp:Label>
                    <br />
                    <br />
                    <asp:Label runat="server" CssClass="eventDescStyles" ID="Label2" Text="Join us for a city-wide rally advocating
                        for sustainable practices and urgent climate action.">
                    </asp:Label>

                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <asp:Label runat="server" ID="Label3" Text="Feb 20th"></asp:Label>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <asp:Label runat="server" ID="Label4" Text="10:00 AM"></asp:Label>
                            <br />
                        </div>
                    </div>
                    <asp:Button ID="Button2" runat="server" Text="SEE MORE"
                        CssClass="learnmoreBtn" OnClick="btnLearnMore_Click" />
                </div>
            </div>

            <div class="card">
                <asp:Image runat="server" ID="Image2" ImageUrl="../resources/images/rallypic.jpg" />
                <div class="content">
                    <asp:Label runat="server" CssClass="eventTitleStyles" ID="Label5" Text="CLIMATE ACTION RALLY"></asp:Label>
                    <br />
                    <br />
                    <asp:Label runat="server" CssClass="eventDescStyles" ID="Label6" Text="Join us for a city-wide rally advocating
                        for sustainable practices and urgent climate action.">
                    </asp:Label>

                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <asp:Label runat="server" ID="Label7" Text="Feb 20th"></asp:Label>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <asp:Label runat="server" ID="Label8" Text="10:00 AM"></asp:Label>
                            <br />
                        </div>
                    </div>
                    <asp:Button ID="Button3" runat="server" Text="SEE MORE"
                        CssClass="learnmoreBtn" OnClick="btnLearnMore_Click" />
                </div>
            </div>

        </div>
        <asp:HyperLink runat="server" class="seemore"> Click to see more! </asp:HyperLink>


        <!-- virtual events section -->
        <h1>Virtual events coming up</h1>
        <div class="card-container">

            <div class="card">
                <asp:Image runat="server" ID="Image3" ImageUrl="../resources/images/virtualeventpic.jpg" />
                <div class="content">
                    <asp:Label runat="server" CssClass="eventTitleStyles" ID="Label9" Text="VOICES UNVEILED"></asp:Label>
                    <br />
                    <br />
                    <asp:Label runat="server" CssClass="eventDescStyles" ID="Label10" Text="Experience the power of art through our virtual exhibition featuring works with
diverse voices and social narratives.">
                    </asp:Label>

                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <asp:Label runat="server" ID="Label11" Text="Jan 15th"></asp:Label>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <asp:Label runat="server" ID="Label12" Text="8:30 PM"></asp:Label>
                            <br />
                        </div>
                    </div>
                    <asp:Button ID="Button4" runat="server" Text="SEE MORE"
                        CssClass="learnmoreBtn" OnClick="btnLearnMore_Click" />
                </div>
            </div>


            <div class="card">
                <asp:Image runat="server" ID="Image4" ImageUrl="../resources/images/virtualeventpic.jpg" />
                <div class="content">
                    <asp:Label runat="server" CssClass="eventTitleStyles" ID="Label13" Text="VOICES UNVEILED"></asp:Label>
                    <br />
                    <br />
                    <asp:Label runat="server" CssClass="eventDescStyles" ID="Label14" Text="Experience the power of art through our virtual exhibition featuring works with
diverse voices and social narratives.">
                    </asp:Label>

                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <asp:Label runat="server" ID="Label15" Text="Jan 15th"></asp:Label>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <asp:Label runat="server" ID="Label16" Text="8:30 PM"></asp:Label>
                            <br />
                        </div>
                    </div>
                    <asp:Button ID="Button5" runat="server" Text="SEE MORE"
                        CssClass="learnmoreBtn" OnClick="btnLearnMore_Click" />
                </div>
            </div>


            <div class="card">
                <asp:Image runat="server" ID="Image5" ImageUrl="../resources/images/virtualeventpic.jpg" />
                <div class="content">
                    <asp:Label runat="server" CssClass="eventTitleStyles" ID="Label17" Text="VOICES UNVEILED"></asp:Label>
                    <br />
                    <br />
                    <asp:Label runat="server" CssClass="eventDescStyles" ID="Label18" Text="Experience the power of art through our virtual exhibition featuring works with
diverse voices and social narratives.">
                    </asp:Label>

                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <asp:Label runat="server" ID="Label19" Text="Jan 15th"></asp:Label>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <asp:Label runat="server" ID="Label20" Text="8:30 PM"></asp:Label>
                            <br />
                        </div>
                    </div>
                    <asp:Button ID="Button6" runat="server" Text="SEE MORE"
                        CssClass="learnmoreBtn" OnClick="btnLearnMore_Click" />
                </div>
            </div>

        </div>
        <asp:HyperLink runat="server" class="seemore"> Click to see more! </asp:HyperLink>
    </form>

    <br />

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
