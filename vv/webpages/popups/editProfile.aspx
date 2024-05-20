<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editProfile.aspx.cs" Inherits="vv.webpages.popups.editProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../styles/editProfileStyles.css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet" />
    <!--
            <script type="text/javascript">
        function closePopupAndRedirect() {
            window.opener.location.href = '../profile.aspx'; 
            window.close();
        }
            </script> -->
</head>
<body>
    <form id="form1" runat="server">
        <div id="heroDiv">
            <asp:Label ID="editTitle" runat="server" Text="EDIT PROFILE"></asp:Label>


            <div id="fieldsLabelsDiv">
                <div class="userChangeInput">
                    <asp:Label ID="changeBannerlbl" CssClass="labels" runat="server" Text="Change Banner Image"></asp:Label>
                    <asp:FileUpload ID="changeBanner" CssClass="fields" runat="server" />
                </div>
                <div class="userChangeInput">
                    <asp:Label ID="changePfplbl" CssClass="labels" runat="server" Text="Change Profile Image"></asp:Label>
                    <asp:FileUpload ID="changePfp" CssClass="fields" runat="server" />
                </div>
                <div class="userChangeInput">
                    <asp:Label ID="changeNamelbl" CssClass="labels" runat="server" Text="Change Name"></asp:Label>
                    <asp:TextBox ID="changeName" CssClass="fields" placeholder="Enter new name" runat="server"></asp:TextBox>
                </div>

            </div>

            <div class="userChangeInput">
                <asp:Label ID="interestlbl" runat="server" Text="Interests"></asp:Label>
                <div id="interestPickerDiv" style="height: 200px; overflow-y: auto;">
                    <!-- the interestr picker goes here -->
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
            </div>
            <asp:Label ID="showInterestlbl" runat="server" Text=""></asp:Label>
                        <div class="buttons">

            <asp:Button ID="savebtn" runat="server" Text="SAVE" OnClick="Savebtn_Click" />
            <asp:Button ID="cancelbtn" runat="server" Text="CANCEL" OnClick="closebtn_click" />
                            </div>
        </div>
    </form>
</body>
</html>
