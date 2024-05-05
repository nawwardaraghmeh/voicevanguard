<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetPasswordPageOne.aspx.cs" Inherits="vv.webpages.resetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    
      <link rel="preconnect" href="https://fonts.googleapis.com">
      <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
      <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
          rel="stylesheet">
      <link rel="stylesheet" type="text/css" href="../styles/resetPasswordPageOneStyle.css">
    <script src="https://kit.fontawesome.com/f6d959a275.js" crossorigin="anonymous"></script> 
    <title>Reset Password</title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div id="heroDiv">
            <asp:Label ID="Label1" runat="server" Text="RESET PASSWORD"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Please enter you email address and click Reset Password button to reset your password "></asp:Label>
            <asp:TextBox ID="setEmailtxtbox" runat="server" placeholder="example@email.com"></asp:TextBox>

        <div id="btnAndCancelDiv">
            <asp:Button ID="resetPasswordbtn" runat="server" Text="Reset Password" />
            <asp:Label ID="Label3" runat="server" Text="Cancel"></asp:Label>
            </div>
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
