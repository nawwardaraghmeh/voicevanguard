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
            <asp:Label runat="server" ID="lblerror" CssClass="errorlbl" style="margin-left:100px"></asp:Label> <br />
            <label>username</label>
            <asp:TextBox runat="server" CssClass="textboxStyles" ID="nametxtbox"></asp:TextBox> <br />
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="nametxtbox"
                ErrorMessage="Username is required" CssClass="errorlbl"></asp:RequiredFieldValidator> <br />
            <br />

            <label>password</label>
            <asp:TextBox runat="server" CssClass="textboxStyles" TextMode="Password" ID="pwtxtbox"></asp:TextBox>  <br /> 
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="pwtxtbox"
                ErrorMessage="Password is required" CssClass="errorlbl"></asp:RequiredFieldValidator> <br />

            <br />

            <a href="" id="forgotPasswordLink">Forgot Password?</a><br />
            <asp:Button runat="server" ID="btnLogin" Text="LOGIN" CssClass="btnLoginStyle" 
                OnClick="btnLogin_Click"  />
           <br />
            
            <p>New to VoiceVanguard?</p> <a href="Registration.aspx" id="registerHereLink">Register Here</a>
            <br />
            <img src="../resources/images/icon.png" alt="watermelon icon"/>
        </div>
    </form>
</body>
</html>
