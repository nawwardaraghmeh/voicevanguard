<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="vv.web_pages.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN TO VOICEVANGUARD</title>
     <link rel="stylesheet" type="text/css" href="../styles/LoginStyles.css"/>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
    rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div id="loginDiv">
            <h1>Welcome Back</h1>
            <label>username</label><input type="text" /><br />
            <label>password</label><input type="password" /><br />
            <a href="" id="forgotPasswordLink">Forgot Password?</a><br />
            <input type="submit" value="LOGIN" /><br />
            
            <p>New to VoiceVanguard?</p> <a href="Registration.aspx" id="registerHereLink">Register Here</a>
            <br />
            <img src="../resources/images/icon.png" alt="watermelon icon"/>
           

        </div>
    </form>
</body>
</html>
