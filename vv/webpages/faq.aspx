<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faq.aspx.cs" Inherits="vv.web_pages.faq" %>
<%@ Register Src="notifications.ascx" TagName="Notification" TagPrefix="uc" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="stylesheet" type="text/css" href="../styles/faqpageStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="shortcut icon" type="image/x-icon" href="~/resources/images/icon.ico" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>FAQs PAGE </title>
</head>
<body>

    <!-- header section -->

    <nav class="navbar">
        <div class="navbar-container">
            <div class="navbar-left">
                <a href="home.aspx" class="nav-item">HOME</a>
                <a href="events.aspx" class="nav-item">EVENTS</a>
                <a href="community.aspx" class="nav-item">COMMUNITY</a>
                <a href="faq.aspx" class="nav-item current-page">FAQs</a>
            </div>
            <div class="navbar-right">
                <a href="profile.aspx" class="nav-item icon"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>

    <form id="form1" runat="server">
        <uc:Notification ID="Notification1" runat="server" />

        <div class="faqmain">
            <div>
                <h1>Discover VoiceVanguard:  Frequently Asked Questions</h1>
            </div>

            <br />

            <div class="faq">
                <div class="faq-item">
                    <div class="question" onclick="toggleAnswer(this)">
                        What is VoiceVanguard?
        <i class="fas fa-chevron-down arrow"></i>
                    </div>
                    <div class="answer">
                        Our project, “VoiceVanguard”, aims to address the
                        growing need for efficient communication and organization
                        with activist communities. By developing a robust digital platform,
                        we seek to empower activists in their pursuit of social change.   
                        The main objectives of VoiceVanguard are centered around creating a centralized platform that
                        facilitates seamless coordination among activists by providing them with essential tools, 
                        including event scheduling, and community feed.

                    </div>
                </div>

                        <div class="faq-item">
                            <div class="question" onclick="toggleAnswer(this)">
                                Can I create my own events on VoiceVanguard?
                <i class="fas fa-chevron-down arrow"></i>
                            </div>
                            <div class="answer">
                                Yes, anyone can create an event on VoiceVanguard.
                                However, please use common sense and do not post innapropriate events.
                            </div>
                        </div>

                <div class="faq-item">
                    <div class="question" onclick="toggleAnswer(this)">
                        Is there a fee to use Voice Vanguard?
        <i class="fas fa-chevron-down arrow"></i>
                    </div>
                    <div class="answer">
                        No, VoiceVanguard is completelly free to use.
                    </div>
                </div>

                <div class="faq-item">
                    <div class="question" onclick="toggleAnswer(this)">
                        How do I reset my password?
        <i class="fas fa-chevron-down arrow"></i>ething somthing 
                    </div>
                    <div class="answer">
                        Navigate to the Login page, and click on the link "Forgot Password", and follow the process to create a new password.
                    </div>
                </div>

            </div>

            <div class="faq-item">
                <div class="question" onclick="toggleAnswer(this)">
                    What should I do if I encounter a technical issue?
        <i class="fas fa-chevron-down arrow"></i>
                </div>
                <div class="answer">
                    If you experience any technical problems, please visit our support page or contact us directly at voicevanguard@gmail.com.

                </div>
            </div>
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



    <script>
        function toggleAnswer(element) {
            element.nextElementSibling.classList.toggle('answer-show');
            element.querySelector('.arrow').classList.toggle('rotate');
        }
    </script>
</body>
</html>
