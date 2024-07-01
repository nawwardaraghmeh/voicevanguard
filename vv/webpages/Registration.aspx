<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="vv.webpages.Registration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REGISTER TO VOICECANGUARD</title>
    <link rel="stylesheet" type="text/css" href="../styles/RegistrationStyles.css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
    <link rel="shortcut icon" type="image/x-icon" href="~/resources/images/icon.ico" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="heroDiv">
            <h1>Join VoiceVanguard</h1>

            <asp:Label runat="server" CssClass="errorlbl" ID="usernameErrorlbl" style="margin-left: 100px"></asp:Label>
            <div class="flexboxDiv">
                <div class="labelsDiv">
                    <label>Username</label>
                    <label>Name</label>
                    <label>E-Mail</label>
                    <label>Password</label>
                    <br />
                    <label>Confirm Password</label>
                    <br />
                    <label>Date of Birth</label>
                </div>

                <div class="inputsDiv">
                    <asp:TextBox runat="server" ID="txtboxUsername" CssClass="txtboxStyles"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" CssClass="errorlbl"
                        ControlToValidate="txtboxUsername" ErrorMessage="Username is required"></asp:RequiredFieldValidator>  
                    <br />

                    <asp:TextBox runat="server" ID="txtboxName" CssClass="txtboxStyles"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" CssClass="errorlbl"
                        ControlToValidate="txtboxName" ErrorMessage="Username is required"></asp:RequiredFieldValidator>
                    <br />

                    <asp:TextBox runat="server" ID="txtboxEmail" CssClass="txtboxStyles" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" CssClass="errorlbl" ControlToValidate="txtboxEmail"
                        ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                    <br />

                    <asp:TextBox runat="server" ID="txtboxPass" CssClass="txtboxStyles" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="errorlbl" ControlToValidate="txtboxPass"
                        ErrorMessage="Password is required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" CssClass="errorlbl"
                        ControlToValidate="txtboxPass" ErrorMessage="Invalid password format." ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$"
                        ClientValidationFunction="validatePassword"></asp:RegularExpressionValidator>
                    <br />

                    <asp:TextBox runat="server" ID="txtboxConfirmPass" CssClass="txtboxStyles" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" CssClass="errorlbl"
                        ControlToValidate="txtboxConfirmPass" ErrorMessage="Confirm Password is required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" CssClass="errorlbl"
                        ControlToValidate="txtboxConfirmPass" ControlToCompare="txtboxPass" ErrorMessage="Passwords don't match"></asp:CompareValidator>
                    <br />

                    <div class="dobDDL">
                        <asp:DropDownList ID="ddlDay" runat="server" CssClass="ddlStyle"></asp:DropDownList>
                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="ddlStyle"></asp:DropDownList>
                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="ddlStyle"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="submitAndLinkDiv">
                <asp:Button runat="server" Text="SIGNUP" CssClass="btnSignupStyle" ID="btnsignup" OnClick="btnsignup_Click"/><br />
                <p>
                    Already have an account? 
                    <asp:LinkButton ID="loginLink" runat="server" OnClick="loginLink_Click">Login</asp:LinkButton>
                </p>
                <img src="../resources/images/icon.png" alt="watermelon icon" />
            </div>
        </div>
    </form>

</body>
</html>
