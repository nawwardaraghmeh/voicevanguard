<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="vv.web_pages.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login VoiceVanguard</title>
     <link rel="stylesheet" type="text/css" href="../styles/Login_RegisterStyles.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Welcome Back</h2>
            <label>username</label><input type="text" /><br />
            <label>password</label><input type="password" /><br />
            <a href="">Forgot Password?</a><br />
            <input type="submit" value="LOGIN" /><br />
            <p>New to VoiceVanguard?</p><a href="">Register Here</a>

        </div>
    </form>
</body>
</html>
