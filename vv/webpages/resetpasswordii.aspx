<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetpasswordii.aspx.cs" Inherits="vv.webpages.resetpasswordii" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/resetPasswordPageTwoStyle.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <script src="https://kit.fontawesome.com/f6d959a275.js" crossorigin="anonymous"></script>
    <title>Reset Password</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="heroDiv">
            <asp:Label ID="Label1" runat="server" Text="RESET PASSWORD" CssClass="labels"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Enter your new password below" CssClass="labels"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="" CssClass="errorlbl"></asp:Label>


            <div id="secondDiv">
                <div class="passwordlblDiv">
                    <asp:Label ID="Label3" runat="server" Text="New Password" TextMode="password" CssClass="labels"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="Confirm Password" CssClass="labels"></asp:Label>
                </div>

                <div class="passwordtxtDiv">
                    <asp:TextBox ID="newPassword" runat="server" CssClass="textbox"
                        TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="newPassword"
                        ErrorMessage="Password is required" CssClass="errorlbl"></asp:RequiredFieldValidator>
                    
                    <asp:TextBox ID="confirmPassword" runat="server" CssClass="textbox"
                        TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" CssClass="errorlbl"
                        ControlToValidate="confirmPassword" ControlToCompare="newPassword" ErrorMessage="Passwords don't match"></asp:CompareValidator>
                </div>
            </div>

            <asp:Button ID="confirmbtn" runat="server" Text="Confirm" 
                OnClick="confirmbtn_Click" />

        </div>
    </form>
</body>
</html>
