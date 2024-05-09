<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addevent.aspx.cs" Inherits="vv.webpages.addevent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/addEventStyles.css">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>ADD EVENT PAGE </title>
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
                <a href="notification.aspx" class="nav-item icon"><i class="fa fa-bell" aria-hidden="true">
                </i></a>
                <a href="profile.aspx" class="nav-item icon"><i class="fa fa-user" aria-hidden="true">
                </i></a>
            </div>
        </div>
    </nav>

    <br />
    <br />
    <br />
    <br />
    <h1 id="pageTitle">ADD EVENT</h1>
    <form id="addEventForm" runat="server">

        <asp:Label ID="lblTitle" runat="server" Text="TITLE"></asp:Label>
        <br />
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDesc" runat="server" Text="DESCRIPTION"></asp:Label>
        <br />
        <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        
        <asp:Label ID="lblPic" runat="server" Text="PICTURE"></asp:Label>
        <br />
        <asp:FileUpload runat="server" ID="eventPicUpload" />
        
        <br />
        <asp:Label ID="lblDate" runat="server" Text="DATE"></asp:Label>
        <br />
        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>

        <br />


        <div class="timeInputDiv">
            <asp:Label ID="lblTime" runat="server" Text="TIME"></asp:Label>

            <asp:DropDownList runat="server" ID="selectTimeH">
                <asp:ListItem Value="default" Selected>Hour</asp:ListItem>
                <asp:ListItem Value="one">01</asp:ListItem>
                <asp:ListItem Value="two">02</asp:ListItem>
                <asp:ListItem Value="three">03</asp:ListItem>
                <asp:ListItem Value="four">04</asp:ListItem>
                <asp:ListItem Value="five">05</asp:ListItem>
                <asp:ListItem Value="six">06</asp:ListItem>
                <asp:ListItem Value="seven">07</asp:ListItem>
                <asp:ListItem Value="eight">08</asp:ListItem>
                <asp:ListItem Value="nine">09</asp:ListItem>
                <asp:ListItem Value="ten">10</asp:ListItem>
                <asp:ListItem Value="eleven">11</asp:ListItem>
                <asp:ListItem Value="twelve">12</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList runat="server" ID="selectTimeM">
                <asp:ListItem Value="default" Selected>Min</asp:ListItem>
                <asp:ListItem Value="zero-mins">00</asp:ListItem>
                <asp:ListItem Value="five-mins">05</asp:ListItem>
                <asp:ListItem Value="ten-mins">10</asp:ListItem>
                <asp:ListItem Value="fifteen-mins">15</asp:ListItem>
                <asp:ListItem Value="twenty-mins">20</asp:ListItem>
                <asp:ListItem Value="twentyfive-mins">25</asp:ListItem>
                <asp:ListItem Value="thirty-mins">30</asp:ListItem>
                <asp:ListItem Value="thirtyfive-mins">35</asp:ListItem>
                <asp:ListItem Value="forty-mins">40</asp:ListItem>
                <asp:ListItem Value="fortyfive-mins">45</asp:ListItem>
                <asp:ListItem Value="fifty-mins">50</asp:ListItem>
                <asp:ListItem Value="fiftyfive-mins">55</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList runat="server" ID="selectTimeAMPM">
                <asp:ListItem Value="AM" Selected>AM</asp:ListItem>
                <asp:ListItem Value="PM">PM</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />

        <div class="durationInputDiv">
            <asp:Label ID="lblDuration" runat="server" Text="DURATION"></asp:Label>
            <select id="selectDurationH" name="D4">
                <option value="default" selected>Hour</option>
                <option value="one">01</option>
                <option value="two">02</option>
                <option value="three">03</option>
                <option value="four">04</option>
                <option value="five">05</option>
                <option value="six">06</option>
                <option value="seven">07</option>
                <option value="eight">08</option>
                <option value="nine">09</option>
                <option value="ten">10</option>
                <option value="eleven">11</option>
                <option value="twelve">12</option>
            </select>

            <select id="selectDurationM" name="D5">
                <option value="default" selected>Min</option>
                <option value="zero-mins">00</option>
                <option value="five-mins">05</option>
                <option value="ten-mins">10</option>
                <option value="fifteen-mins">15</option>
                <option value="twenty-mins">20</option>
                <option value="twentyfive-mins">25</option>
                <option value="thirty-mins">30</option>
                <option value="thirtyfive-mins">35</option>
                <option value="forty-mins">40</option>
                <option value="fortyfive-mins">45</option>
                <option value="fifty-mins">50</option>
                <option value="fiftyfive-mins">55</option>
            </select>
        </div>
        <br />

        <asp:RadioButton ID="rbtnPhysical" GroupName="eventType" runat="server"
            Text="Physical Event" OnCheckedChanged="rbtnPhysical_CheckedChanged" AutoPostBack="true" />
        <br />
        <asp:Label ID="lblLocation" runat="server" Text="LOCATION"></asp:Label>
        <br />
        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblRoom" runat="server" Text="ROOM"></asp:Label>
        <br />
        <asp:TextBox ID="txtRoom" runat="server"></asp:TextBox>
        <br />
        <asp:RadioButton ID="rbtnVirtual" GroupName="eventType" runat="server"
            Text="Virtual Event" OnCheckedChanged="rbtnVirtual_CheckedChanged" AutoPostBack="true" />
        <br />
        <asp:Label ID="lblLink" runat="server" Text="LINK"></asp:Label>
        <br />
        <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblTags" runat="server" Text="ADD TAGS"></asp:Label>
        <div class="tagsAdditionDiv">
            <div style="height: 100px; overflow-y:auto;">
                <asp:CheckBoxList runat="server" ID="selectTags" AutoPostBack="true" OnSelectedIndexChanged="selectTags_SelectedIndexChanged">
                    <asp:ListItem Value="1">Animal Rights</asp:ListItem>
                    <asp:ListItem Value="2">Climate Change</asp:ListItem>
                    <asp:ListItem Value="3">Community Development</asp:ListItem>
                    <asp:ListItem Value="4">Education</asp:ListItem>
                    <asp:ListItem Value="5">Environmental Justice</asp:ListItem>
                    <asp:ListItem Value="6">Equality</asp:ListItem>
                    <asp:ListItem Value="7">Fair Trade</asp:ListItem>
                    <asp:ListItem Value="8">Feminism</asp:ListItem>
                    <asp:ListItem Value="9">Human Rights</asp:ListItem>
                    <asp:ListItem Value="11">Peace and Conflict Resolution</asp:ListItem>
                    <asp:ListItem Value="12">Poverty Alleviation</asp:ListItem>
                    <asp:ListItem Value="13">Racial Justice</asp:ListItem>
                    <asp:ListItem Value="14">Reproductive Rights</asp:ListItem>
                    <asp:ListItem Value="15">Social Justice</asp:ListItem>
                    <asp:ListItem Value="16">Sustainability</asp:ListItem>
                    <asp:ListItem Value="17">Voting Rights</asp:ListItem>
                    <asp:ListItem Value="18">Worker Rights</asp:ListItem>
                    <asp:ListItem Value="19">Women's Rights</asp:ListItem>
                    <asp:ListItem Value="20">Zero Waste</asp:ListItem>
                    <asp:ListItem Value="21">Access to Healthcare</asp:ListItem>
                    <asp:ListItem Value="22">Anti-Corruption</asp:ListItem>
                    <asp:ListItem Value="23">Civic Engagement</asp:ListItem>
                    <asp:ListItem Value="24">Cultural Preservation</asp:ListItem>
                    <asp:ListItem Value="25">Disability Rights</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <asp:Label runat="server" ID="eventstagslabel"></asp:Label>
        </div>


        <asp:Button ID="btnAddNewEvent" runat="server" Text="ADD EVENT" />
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
