<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eventAdditionPopup.aspx.cs"
    Inherits="vv.popups.eventAdditionPopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
    <title>EVENT ADDITION POPUP</title>
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

    <script type="text/javascript">
        function closePopupAndRedirect() {
            window.opener.location.href = '../events.aspx';
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblEventAdditionPopup" runat="server" Text="none"></asp:Label>
            <br />
            <asp:Button ID="btnOk" runat="server" Text="CLOSE" OnClientClick="closePopupAndRedirect(); return false;" />
        </div>
    </form>
</body>
</html>
