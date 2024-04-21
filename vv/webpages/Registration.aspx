<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="vv.webpages.WebForm1" %>

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
        <div>
             <h1>Join VoiceVanguard</h1>

             <label>Username</label><input type="text" /><br />
             <label>E-Mail</label><input type="email" /><br />
             <label>Password</label><input type="password" /><br />
             <label>Confirm Password</label><input type="password" /><br />
             <label>Areas of Interest</label><select>
                                                <option value="0">Select Interest</option>
                                                <option>Women's Rights</option>
                                                <option>Environment</option>
                                                <option>Racial Issues</option>
                                             </select><br />
             <input type="submit" value="SIGNUP" /><br />
             <p>Already have an account?</p> <a href="" id="registerHereLink">Login</a>
        </div>
    </form>
</body>
</html>
