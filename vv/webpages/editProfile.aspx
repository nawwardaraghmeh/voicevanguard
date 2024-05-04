<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editProfile.aspx.cs" Inherits="vv.webpages.editProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
     <link rel="stylesheet" type="text/css" href="../styles/editProfileStyles.css">
     <link rel="preconnect" href="https://fonts.googleapis.com">
     <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
     <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
     rel="stylesheet">
 <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
    <title>Edit Profile</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="heroDiv">
            <div id="lblandbtn">
            <asp:Label ID="titleLabel" runat="server" Text="Edit Profile"></asp:Label>
            <asp:Button ID="savebtn" runat="server" Text="Save" />
                </div>
            <div id="secondDiv">
            <asp:ImageButton ID="bannerimgbtn" runat="server" for="BannerimageUpload" ImageUrl="~/resources/images/profilebanner.jpg" />
                       <input type="file" id="BannerimageUpload" name="imageUpload" /> 
            
                <div id="pfpandname">
            <asp:ImageButton ID="profileimgbtn" runat="server" ImageUrl="~/resources/images/profilepic.jpg" />
               <asp:TextBox ID="nametxtBox" runat="server"></asp:TextBox>
                    </div>
                </div>
            

        </div>
    </form>
</body>
</html>
