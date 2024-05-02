<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="vv.webpages.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>
    <link rel="stylesheet" type="text/css" href="../styles/RegistrationStyles.css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="heroDiv">
            <h1>Join VoiceVanguard</h1>


            <div class="flexboxDiv">
                <div class="labelsDiv">
                    <label id="username">Username</label>
                    <label>E-Mail</label>
                    <label>Password</label>
                    <br />
                    <label>Confirm Password</label>

                </div>

                <div class="inputsDiv">
                    <asp:TextBox runat="server" ID="txtboxName" CssClass="txtboxStyles"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" CssClass="errorlbl"
                        ControlToValidate="txtboxName" ErrorMessage="Username is required"></asp:RequiredFieldValidator>
                    <br />

                    <asp:TextBox runat="server" ID="txtboxEmail" CssClass="txtboxStyles" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" CssClass="errorlbl" ControlToValidate="txtboxEmail"
                        ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                    <br />

                    <asp:TextBox runat="server" ID="txtboxPass" CssClass="txtboxStyles" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="errorlbl" ControlToValidate="txtboxPass"
                        ErrorMessage="Password is required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" CssClass="errorlbl" ControlToValidate="txtboxPass"
                        ErrorMessage="Password must be at least 8 characters long"
                        ValidationExpression="^.{8,}$"></asp:RegularExpressionValidator>
                    <br />

                    <asp:TextBox runat="server" ID="txtboxConfirmPass" CssClass="txtboxStyles" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" CssClass="errorlbl"
                        ControlToValidate="txtboxConfirmPass" ErrorMessage="Confirm Password is required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" CssClass="errorlbl" ControlToValidate="txtboxConfirmPass"
                        ControlToCompare="txtboxPass" Operator="Equal" ErrorMessage="Passwords do not match"></asp:CompareValidator>

                </div>
            </div>
            <div class="submitAndLinkDiv">
                <input type="submit" value="SIGNUP" /><br />
                <p>
                    Already have an account? 
                    <asp:LinkButton ID="loginLink" runat="server" OnClick="loginLink_Click">Login</asp:LinkButton>
                </p>

                <img src="../resources/images/icon.png" alt="watermelon icon" />
            </div>
    </form>
</body>
</html>
