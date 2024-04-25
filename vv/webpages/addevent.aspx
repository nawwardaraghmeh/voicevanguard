<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addevent.aspx.cs" Inherits="vv.webpages.addevent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/eventspageStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>VV ADD EVENT PAGE </title>
</head>
<body>
    <form id="addEventForm" runat="server">

        <asp:Label ID="lblTitle" runat="server" Text="TITLE"></asp:Label>
        <br />
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <br />
        <div class="addHlinksDiv">
            <asp:HyperLink ID="hlinkAddDesc" runat="server">+ Add Description</asp:HyperLink>
            <asp:HyperLink ID="hlinkAddPic" runat="server">+ Add Picture</asp:HyperLink>
        </div>
        <br />

        <asp:Label ID="lblDate" runat="server" Text="DATE"></asp:Label>
        <br />
        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>

        <br />


        <div class="timeInputDiv">
            <asp:Label ID="lblTime" runat="server" Text="TIME"></asp:Label>

            <select id="selectTimeH" name="D1">
                <option value="one" selected>01</option>
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

            <select id="selectTimeM" name="D2">
                <option value="zero-mins" selected>00</option>
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

            <select id="selectTimeAMPM" name="D3">
                <option value="AM" selected>AM</option>
                <option value="PM">PM</option>
            </select>
        </div>
        <br />

        <div class="durationInputDiv">
            <asp:Label ID="lblDuration" runat="server" Text="DURATION"></asp:Label>
            <select id="selectDurationH" name="D4">
                <option value="one" selected>01</option>
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
                <option value="zero-mins" selected>00</option>
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
            Text="Physical Event" OnCheckedChanged="rbtnPhysical_CheckedChanged" />
        <br />
        <asp:Label ID="lblLocation" runat="server" Text="LOCATION"></asp:Label>
        <br />
        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
        <br />
        <asp:HyperLink ID="hlinkAddRoom" runat="server">+ Set Meeting Room</asp:HyperLink>
        <br />
        <br />

        <asp:RadioButton ID="rbtnVirtual" GroupName="eventType" runat="server" 
            Text="Virtual Event" OnCheckedChanged="rbtnVirtual_CheckedChanged" />
        <br />
        <asp:Label ID="lblLink" runat="server" Text="LINK"></asp:Label>
        <br />
        <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="lblTags" runat="server" Text="ADD TAGS"></asp:Label>
        <select id="selectTags" name="D6">
            <option value="ClimateChange">Climate Change</option>
            <option value="SocialJustice">Social Justice</option>
            <option value="Equality">Equality</option>
            <option value="HumanRights">Human Rights</option>
            <option value="EnvironmentalJustice">Environmental Justice</option>
            <option value="Feminism">Feminism</option>
            <option value="Activism">Activism</option>
            <option value="BlackLivesMatter">Black Lives Matter</option>
            <option value="Vote">Vote</option>
        </select><br />
        <br />

        <asp:RadioButton ID="rbtnAddOrganizer" runat="server" Text="Any Co-Organizers for the Event?"
            Checked="false" />
        <br />
        <br />

        <asp:Button ID="btnAddNewEvent" runat="server" Text="ADD EVENT" />
    </form>
</body>
</html>
