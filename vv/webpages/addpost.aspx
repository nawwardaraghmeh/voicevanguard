<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addpost.aspx.cs" Inherits="vv.webpages.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADD POST PAGE</title>
    <link rel="stylesheet" type="text/css" href="../styles/addPostStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <script src="https://kit.fontawesome.com/f6d959a275.js" crossorigin="anonymous"></script>
   


</head>
<body>
    <form id="form1" runat="server">
        <h1 id="pageTitle">ADD POST</h1>

        <div id="heroDiv">
            <label id="title">TITLE</label><br />
            <input type="text" id="titleBox" required="required"/><br />
            <select>
                <option value="only-me">Only Me</option>
                <option value="only-followers">Only Followers</option>
                <option value="everyone">Everyone</option>
            </select><br />
            
            <div id="secondDiv">
                <input type="text" id="contentBox" placeholder="What's On Your Mind?" required="required"/><br />
                <div id="text-strip">

                        <label for="imageUpload"><i class="fa-solid fa-image fa-2x"></i> </label>
                       <input type="file" id="imageUpload" name="imageUpload" /> 

                        <i class="fa-regular fa-face-smile fa-2x"></i>
                    </div>
            </div><br />
            <asp:Button runat="server" Text="POST" ID="postBtn" />
        </div>
    </form>
</body>
</html>
