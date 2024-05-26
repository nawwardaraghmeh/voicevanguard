<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="notifications.ascx.cs" Inherits="vv.webpages.notifications" %>



    <style>
        #notifheroDiv {
    background-color: black;
    border-style: none;
    border-radius: 5px;
    position:fixed;
    width: 15%;
    margin: 100px 22%;
    padding: 10px;
    font-family: "Coustard", serif;
    left: 47.5%;
    top: -4%;
    display: none;
    z-index:1000;
}

    #notifheroDiv:before {
        content: "";
        position: absolute;
        top: -9%;
        left: 88%;
        border: 15px solid;
        border-color: transparent transparent black transparent;
    }

    #notifheroDiv.show {
        display: inline-block;
    }


    .notifTemp {
        background-color: #F1A7A7;
        border-style: none;
        border-radius: 22px;
        margin-bottom: 10px;
        padding: 10px;
        display: flex;
        flex-direction: row;
    }

    .notifTemp span {
        font-size: 15px;
        font-weight: 500;
        color: black;
    }

    .notifTemp a {
        font-size: 12px;
        color: #545454;
        cursor: pointer;
    }

    .notifTemp img {
        width: 30px;
        height: 30px;
        margin: 5px;
        margin-right: 5px;
        border-radius: 50%;
        object-fit: cover;
    }

.notifTextDiv {
    display: flex;
    justify-content: center;
    font-size:15px;
}

.noNotifText {
    color: white;
    font-weight: 700;
}

.current-page{
    position:relative;
}

#bellIcon{
    font-size: 20px;
    color:white;
    position:fixed;
    z-index:1000;
    top:1.60%;
    left:84%;
    padding:10px 10px;
    cursor:pointer;
}

.eventLink {
    text-decoration: none;
    margin-left: 5px;
    font-size: 15px;
}
.eventLink:hover {
    text-decoration: underline;
    color: #DE2B2B;
}

    </style>
     <script>
         document.addEventListener("DOMContentLoaded", function () {
             const notificationIcon = document.getElementById("bellIcon");
             const notificationTray = document.getElementById("notifheroDiv");
             let isTrayShown = false;

             notificationIcon.addEventListener("click", function () {
                 notificationTray.classList.toggle("show");
                 isTrayShown = !isTrayShown;

                 if (isTrayShown) {
                     // Colors when tray is shown
                     notificationIcon.style.backgroundColor = "#7BCC98";
                     notificationIcon.style.color = "black";
                 } else {
                     // Colors when tray is hidden
                     notificationIcon.style.backgroundColor = ""; // Revert to original background color
                     notificationIcon.style.color = ""; // Revert to original text color
                 }
                 
             });
         });
     </script>
    <!-- header section -->
                <div class="bellIconDiv"><i id="bellIcon" class="fa fa-bell"
                    aria-hidden="true"></i></div>

    <!-- end of header-->


<div id="notifheroDiv">
    <asp:Panel runat="server" id="notifheroContainer">
    </asp:Panel>
</div>


