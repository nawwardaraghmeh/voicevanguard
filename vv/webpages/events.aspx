<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faq.aspx.cs" Inherits="vv.web_pages.faq" %>

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

    <title>VV EVENTS PAGE </title>
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
                <a href="#" class="nav-item icon"><i class="fa fa-bell" aria-hidden="true"></i></a>
                <a href="profile.aspx" class="nav-item icon"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>

    <br />

    <form id="form1" class="events-main" runat="server">
        <div class="events-top">
            <button id="btnAddEvent">ADD EVENT</button>

            <div class="search-container">
                <form action="/search" method="get">
                    <div class="search-box">
                        <i class="fas fa-search"></i>
                        <input type="text" placeholder="Eneter Keywords ... " name="search">
                    </div>
                </form>
            </div>
        </div>

        <!-- recommended events section -->
        <h1>Recommended for you</h1>
        <div class="card-container">

            <div class="card">
                <img src="../resources/images/rallypic.jpg">
                <div class="content">
                    <h2>CLIMATE ACTION RALLY</h2>
                    <p>
                        Join us for a city-wide rally advocating for sustainable practices and urgent climate
                        action.
                    </p>
                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <span>Feb 20th</span>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <span>10:00 AM</span>
                        </div>
                    </div>
                    <button class="btnLearnmore">LEARN MORE</button>
                </div>
            </div>

            <div class="card">
                <img src="../resources/images/rallypic.jpg">
                <div class="content">
                    <h2>CLIMATE ACTION RALLY</h2>
                    <p>
                        Join us for a city-wide rally advocating for sustainable practices and urgent climate
                        action.
                    </p>
                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <span>Feb 20th</span>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <span>10:00 AM</span>
                        </div>
                    </div>
                    <button class="btnLearnmore">LEARN MORE</button>
                </div>
            </div>

            <div class="card">
                <img src="../resources/images/rallypic.jpg">
                <div class="content">
                    <h2>CLIMATE ACTION RALLY</h2>
                    <p>
                        Join us for a city-wide rally advocating for sustainable practices and urgent climate
                        action.
                    </p>
                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <span>Feb 20th</span>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <span>10:00 AM</span>
                        </div>
                    </div>
                    <button class="btnLearnmore">LEARN MORE</button>
                </div>
            </div>

        </div>
        <a href="#" class="seemore">Click to see more</a>


        <!-- virtual events section -->
        <h1>Virtual events coming up</h1>
        <div class="card-container">

            <div class="card">
                <img src="../resources/images/virtualeventpic.jpg">
                <div class="content">
                    <h2>VOICES UNVEILED</h2>
                    <p>
                        Experience the power of art through our virtual exhibition featuring works with diverse voices and social narratives.
                    </p>
                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <span>Jan 15th</span>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <span>8:30 PM</span>
                        </div>
                    </div>
                    <button class="btnLearnmore">LEARN MORE</button>
                </div>
            </div>

            
            <div class="card">
                <img src="../resources/images/virtualeventpic.jpg">
                <div class="content">
                    <h2>VOICES UNVEILED</h2>
                    <p>
                        Experience the power of art through our virtual exhibition featuring works with diverse voices and social narratives.
                    </p>
                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <span>Jan 15th</span>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <span>8:30 PM</span>
                        </div>
                    </div>
                    <button class="btnLearnmore">LEARN MORE</button>
                </div>
            </div>
          
            
            <div class="card">
                <img src="../resources/images/virtualeventpic.jpg">
                <div class="content">
                    <h2>VOICES UNVEILED</h2>
                    <p>
                        Experience the power of art through our virtual exhibition featuring works with diverse voices and social narratives.
                    </p>
                    <div class="details">
                        <div class="date">
                            <i class="far fa-calendar-alt"></i>
                            <span>Jan 15th</span>
                        </div>
                        <div class="time">
                            <i class="far fa-clock"></i>
                            <span>8:30 PM</span>
                        </div>
                    </div>
                    <button class="btnLearnmore">LEARN MORE</button>
                </div>
            </div>

        </div>
        <a href="#" class="seemore">Click to see more</a>

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
        </div>

        <div class="bottom-bar">
            <p>
                <i class="fa fa-copyright" aria-hidden="true"></i>2024 VoiceVanguard. All rights
                reserved
            </p>
        </div>
    </footer>
</body>
</html>
