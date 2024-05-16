<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="participantsAdditionPopup.aspx.cs" Inherits="vv.webpages.popups.participantsAdditionPopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>PARTICIPANTS ADDITION POPUP</title>
 <style>
     body {
         background-color: #FFFFFF;
         border: 2px solid #E46262;
         padding: 50px;
         font-family: "Coustard", serif;
         border-radius: 20px;
         display: flex;
         justify-content: center;
     }

     #btnOk {
         background-color: #A7DDBA;
         border: none;
         color: black;
         padding: 10px 20px;
         cursor: pointer;
         font-family: "Coustard", serif;
         border-radius: 22px;
         margin: 20px 33%;
     }

         #btnOk:hover {
             background-color: #7BCC98;
         }
         
     #lblEventAdditionPopup {
         margin: 20px auto;
     }
 </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblParticipantAdditionPopup" runat="server" Text=""></asp:Label> 
            <br />
            <asp:Button ID="btnOk" runat="server" Text="CLOSE" OnClick="btnOk_Click" />
        </div>
    </form>
</body>
</html>
