<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetlink.aspx.cs" Inherits="vv.webpages.resetlink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            <asp:Label ID="Label1" runat="server" Text="">Please check your email <br/>and click on the link!</asp:Label>
        </div>
    </form>
</body>
</html>
