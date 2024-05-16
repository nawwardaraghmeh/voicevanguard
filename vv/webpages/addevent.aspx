<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addevent.aspx.cs" Inherits="vv.webpages.addevent" %>
<%@ Register Src="notifications.ascx" TagName="Notification" TagPrefix="uc" %>

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
         <uc:Notification ID="Notification1" runat="server" />

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
        <div class="dateInputDiv">
            <asp:Label ID="lblDate" runat="server" Text="DATE"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlDay" runat="server" CssClass="ddlStyle">
                <asp:ListItem Value="default" Selected>Day</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="ddlStyle">
                <asp:ListItem Value="default" Selected>Month</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlYear" runat="server" CssClass="ddlStyle">
                <asp:ListItem Value="default" Selected>Year</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />


        <div class="timeInputDiv">
            <asp:Label ID="lblTime" runat="server" Text="TIME"></asp:Label>

            <asp:DropDownList runat="server" ID="selectTimeH">
                <asp:ListItem Value="default" Selected>Hour</asp:ListItem>
                <asp:ListItem Value="1">01</asp:ListItem>
                <asp:ListItem Value="2">02</asp:ListItem>
                <asp:ListItem Value="3">03</asp:ListItem>
                <asp:ListItem Value="4">04</asp:ListItem>
                <asp:ListItem Value="5">05</asp:ListItem>
                <asp:ListItem Value="6">06</asp:ListItem>
                <asp:ListItem Value="7">07</asp:ListItem>
                <asp:ListItem Value="8">08</asp:ListItem>
                <asp:ListItem Value="9">09</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
                <asp:ListItem Value="13">13</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="16">16</asp:ListItem>
                <asp:ListItem Value="17">17</asp:ListItem>
                <asp:ListItem Value="18">18</asp:ListItem>
                <asp:ListItem Value="19">19</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="21">21</asp:ListItem>
                <asp:ListItem Value="22">22</asp:ListItem>
                <asp:ListItem Value="23">23</asp:ListItem>
                <asp:ListItem Value="24">24</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList runat="server" ID="selectTimeM">
                <asp:ListItem Value="default" Selected>Minute</asp:ListItem>
                <asp:ListItem Value="0">00</asp:ListItem>
                <asp:ListItem Value="5">05</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="25">25</asp:ListItem>
                <asp:ListItem Value="30">30</asp:ListItem>
                <asp:ListItem Value="35">35</asp:ListItem>
                <asp:ListItem Value="40">40</asp:ListItem>
                <asp:ListItem Value="45">45</asp:ListItem>
                <asp:ListItem Value="50">50</asp:ListItem>
                <asp:ListItem Value="55">55</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />

        <div class="durationInputDiv">
            <asp:Label ID="lblDuration" runat="server" Text="DURATION"></asp:Label>

            <asp:DropDownList runat="server" ID="selectDurationH">
                <asp:ListItem Value="default" Selected>Hour</asp:ListItem>
                <asp:ListItem Value="1">01</asp:ListItem>
                <asp:ListItem Value="2">02</asp:ListItem>
                <asp:ListItem Value="3">03</asp:ListItem>
                <asp:ListItem Value="4">04</asp:ListItem>
                <asp:ListItem Value="5">05</asp:ListItem>
                <asp:ListItem Value="6">06</asp:ListItem>
                <asp:ListItem Value="7">07</asp:ListItem>
                <asp:ListItem Value="8">08</asp:ListItem>
                <asp:ListItem Value="9">09</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
                <asp:ListItem Value="13">13</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="16">16</asp:ListItem>
                <asp:ListItem Value="17">17</asp:ListItem>
                <asp:ListItem Value="18">18</asp:ListItem>
                <asp:ListItem Value="19">19</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="21">21</asp:ListItem>
                <asp:ListItem Value="22">22</asp:ListItem>
                <asp:ListItem Value="23">23</asp:ListItem>
                <asp:ListItem Value="24">24</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList runat="server" ID="selectDurationM">
                <asp:ListItem Value="default" Selected>Minute</asp:ListItem>
                <asp:ListItem Value="0">00</asp:ListItem>
                <asp:ListItem Value="5">05</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="25">25</asp:ListItem>
                <asp:ListItem Value="30">30</asp:ListItem>
                <asp:ListItem Value="35">35</asp:ListItem>
                <asp:ListItem Value="40">40</asp:ListItem>
                <asp:ListItem Value="45">45</asp:ListItem>
                <asp:ListItem Value="50">50</asp:ListItem>
                <asp:ListItem Value="55">55</asp:ListItem>
            </asp:DropDownList>

        </div>
        <br />

        <div class="radioButtons">
            <div class="physicalRbutton">
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
            </div>

            <div class="virtualRbutton">
                <asp:RadioButton ID="rbtnVirtual" GroupName="eventType" runat="server"
                    Text="Virtual Event" OnCheckedChanged="rbtnVirtual_CheckedChanged" AutoPostBack="true" />
                <br />
                <asp:Label ID="lblLink" runat="server" Text="LINK"></asp:Label>
                <br />
                <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
            </div>
        </div>

        <asp:Label ID="lblTags" runat="server" Text="ADD TAGS"></asp:Label>
        <div class="tagsAdditionDiv">
            <div style="height: 100px; overflow-y: auto;">
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


        <asp:Button ID="btnAddNewEvent" runat="server" Text="ADD EVENT" 
            OnClick="btnAddNewEvent_Click" />
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
