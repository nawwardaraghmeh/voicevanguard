    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="vv.web_pages.profile" %>
    <%@ Register Src="notifications.ascx" TagName="Notification" TagPrefix="uc" %>
    


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="stylesheet" type="text/css" href="../styles/ProfileStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
    <script src="https://kit.fontawesome.com/f6d959a275.js" crossorigin="anonymous"></script>

    <title>PROFILE PAGE </title>

    <script>
        function showProfilePicker() {
        const input = document.getElementById("profileInput");
        input.click(); // Trigger the file picker dialog
    }

    function showBannerPicker() {
        const input = document.getElementById("bannerInput");
        input.click(); // Trigger the file picker dialog for banner picture
    }

    function handleBannerChange(event) {
        const file = event.target.files[0];
        const img = document.getElementById("<%=imgBannerPic.ClientID %>");
        img.src = URL.createObjectURL(file); // Display the selected image as banner picture
    }

    function handleProfileChange(event) {
        const file = event.target.files[0];
        const img = document.getElementById("<%=imgProfilePic.ClientID %>");
        img.src = URL.createObjectURL(file); // Display the selected image as profile picture
    }

         //CHANGING NAME CODE

         document.addEventListener("DOMContentLoaded", function () {
            const input = document.getElementById("usernameInput");
            const label = document.getElementById("usernameLabel");
            const currentUsername = document.getElementById("lblAccountName");

            // Add event listener for when the input field loses focus
            input.addEventListener("blur", function () {
                updateUsername(input, label, currentUsername);
            });
        });

        function showUsernameInput() {
            const label = document.getElementById("usernameLabel");
            const input = document.getElementById("usernameInput");
            const currentUsername = document.getElementById("lblAccountName");

            // Hide the label and show the input field
            label.style.display = "none";
            input.style.display = "inline-block";
    
            // Set the input value to the current username
            input.value = currentUsername.innerText;

            // Set focus to the input field
            input.focus();
        }

        function updateUsername(input, label, currentUsername) {
            // Get the new username from the input field
            const newUsername = input.value;
    
            // Update the label with the new username
            currentUsername.innerText = newUsername;

            // Show the label and hide the input field
            label.style.display = "block";
            input.style.display = "none";
        }
    </script>
</head>
<body>
    <!-- header section -->
    <nav class="navbar">
        <div class="navbar-container">
            <div class="navbar-left">
                <a href="home.aspx" class="nav-item">HOME</a>
                <a href="events.aspx" class="nav-item">EVENTS</a>
                <a href="community.aspx" class="nav-item">COMUUNITY</a>
                <a href="faq.aspx" class="nav-item">FAQs</a>
            </div>
            <div class="navbar-right">
                <a href="profile.aspx" class="nav-item icon current-page"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>

    <!-- profile main content -->
    <form id="form1" runat="server">
        <uc:Notification ID="Notification1" runat="server" />


        <!-- profile page top section -->

       
            <!--banner picture-->
        <div id="bannerPicture" class="picture" onclick="showBannerPicker()"><asp:Image ID="imgBannerPic" runat="server"
            ImageUrl="~/resources/images/defaultbanner.png" CssClass="hoverable" /></div>
      <!--banner picker content-->
        <div id="bannerPicker" class="picker">
            <input type="file" id="bannerInput" accept="image/*" onchange="handleBannerChange(event)"/>
            <button onclick="uploadBanner()">Upload</button>
        </div>

        <div class="pencilIcon1"><i class="fa-solid fa-pencil fa-2xl"></i></div>
        <div class="profileAccountInfo">


            <!--profile picture-->
           <div id="profilePicture" class="picture" onclick="showProfilePicker()"> <asp:Image ID="imgProfilePic" runat="server"
                ImageUrl="~/resources/images/profilePic.png" CssClass="hoverable" /></div>
            <div class="pencilIcon2"><i class="fa-solid fa-pencil fa-2xl"></i></div>
          <!--pfp picker content-->
            <div id="profilePicker" class="picker">
                <input type="file" id="profileInput" accept="image/*" onchange="handleProfileChange(event)"/>
                <button onclick="uploadProfile()">Upload</button>
            </div> 
            

            <div class="profileAccountInfoTxt">
                <div id="usernameLabel" onclick="showUsernameInput()">
                <div id="nameAndPencilDiv">
                    <asp:Label ID="lblAccountName" runat="server" Text="Amanda Crowley" CssClass="hoverableLbl"></asp:Label>
                    <div class="pencilIcon3"><i class="fa-solid fa-pencil"></i></div>
                </div>
                    </div>
                <!--username input-->
                <input type="text" id="usernameInput"/>
                    

                <div class="profileAccountInfoGrey">
                    <asp:Label ID="lblJoinDate" runat="server" Text="Joined 3/12/2024"></asp:Label>
                    <asp:Button runat="server" Text="LOGOUT" ID="btnLogout" OnClick="btnLogout_Click" />
                </div>

                <br />
                <br />
                <div class="divTabTitlel">

                    <asp:Button ID="btnMyActivity" CssClass="initialBtn" runat="server"
                        Text="My Activity" OnClick="btnMyActivity_Click"></asp:Button>
                    <asp:Button ID="btnUpcomingEvents" CssClass="initialBtn" runat="server"
                        Text="Upcoming Events" OnClick="btnUpcomingEvents_Click"></asp:Button>

                </div>
            </div>
        </div>


        <!-- tabs section -->
        <asp:MultiView ID="MainView" runat="server">
            <asp:View ID="ActivityView" runat="server">
                <div class="viewStyles">
                    <div class="tabDiv">
                        <asp:Label ID="Label1" runat="server" Text="You gained a new follower!"></asp:Label>
                    </div>
                    <div class="tabDiv">
                        <asp:Label ID="Label2" runat="server" Text="Y replied to your comment on X post."></asp:Label>
                    </div>
                    <div class="tabDiv">
                        <asp:Label ID="Label3" runat="server" Text="Z created a new event. Check it out"></asp:Label>
                    </div>
                </div>
            </asp:View>


            <asp:View ID="upcomingEventsView" runat="server">
                <div class="viewStyles">

                    <asp:Calendar BorderStyle="None" CellPadding="40" CssClass="custom-calendar"
                        ID="Calendar1" runat="server" AutoPostBack="false"
                        OnDayRender="Calendar1_DayRender">
                        <DayHeaderStyle BackColor="#a7ddba" />
                        <SelectedDayStyle BackColor="#e46262" />
                        <WeekendDayStyle ForeColor="#F1A7A7" />
                        <OtherMonthDayStyle ForeColor="#545454" />
                        <TodayDayStyle BackColor="#DE2B2B" ForeColor="White" />
                        <TitleStyle ForeColor="#7BCC98" BackColor="White" />
                    </asp:Calendar>

                </div>
            </asp:View>

        </asp:MultiView>

    </form>

    <!-- footer section -->
    <footer class="footer">
        <div class="footer-content">
            <h2>Contactt</h2>
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
