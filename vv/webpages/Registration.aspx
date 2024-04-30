<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="vv.webpages.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>
     <link rel="stylesheet" type="text/css" href="../styles/RegistrationStyles.css"/>
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
                        <label>Confirm Password</label>
                        <label>Areas of Interest</label>
                        
                        </div>
       
            <div class="inputsDiv">  
                <input type="text" />
                <input type="email" />        
                <input type="password" />            
                <input type="password" />           
                <select>
                         <option value="0">Select Interest</option>
                         <option>Women's Rights</option>
                         <option>Environment</option>
                         <option>Racial Issues</option>
                </select>
                </div>              
             </div>
            <div class="submitAndLinkDiv">
                <input type="submit" value="SIGNUP" /><br />
                <p>Already have an account? 
                    <asp:HyperLink ID="loginLink" runat="server" OnDataBinding="loginLink_Click">Login</asp:HyperLink></p>

          <img src="../resources/images/icon.png" alt="watermelon icon"/>
        </div>
    </form>
</body>
</html>
