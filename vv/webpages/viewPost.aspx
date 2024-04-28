<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewPost.aspx.cs" Inherits="vv.webpages.viewPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Post</title>
        <link rel="stylesheet" type="text/css" href="../styles/viewPostStyle.css"/>
        <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
            rel="stylesheet">
        <script src="https://kit.fontawesome.com/f6d959a275.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="heroDiv">

    <div class="nameAndPicDiv">       
        <asp:Image ID="pfp1" runat="server" src="../resources/images/pfp1.jpg"/>
        <asp:Label ID="userName" runat="server" Text="Ahmad Ibraheem"></asp:Label><br /><br />
         <asp:Label ID="postDate" runat="server" Text="3d"></asp:Label><br />
    </div>

       <div>
        <div id="postDiv">
            
            <asp:Label ID="postTitle" runat="server" Text="Is this Organization Legitimate? "></asp:Label>
            <asp:Label ID="postContent" runat="server" Text="I've come across an organization that claims to support a cause close to my heart,
                but I want to ensure its legitimacy. Has anyone had experience with “EarthGuardians”? 
                I heard some bad rumors about it recently, and I don’t want to accidentally support a corrupt organization. 
                If anyone here has had experience with them please tell me.

                Your opinion is much appreciated🙏🙏"></asp:Label><br />
            
        </div>
            <div id="commentsAndReport">
                <asp:Label ID="commentNumber" runat="server" Text="24Comments"></asp:Label>
                <asp:HyperLink ID="reportPostLink" runat="server">ReportPost</asp:HyperLink><br />
            </div>
            </div>

        <asp:TextBox ID="postComment" runat="server" placeholder="Share Your Thoughts! " ></asp:TextBox><br />
        
        <asp:Label ID="commentLabel" runat="server" Text="COMMENTS"></asp:Label><br />
        
        <div id="commentSectionDiv">

            <div class="nameAndPicDiv">
            <asp:Image ID="pfp2" runat="server" src="../resources/images/pfp2.jpg"/>
            <div id="commentDiv" class="commentsDetails">

                <asp:Label ID="userName2" runat="server" Text="Sam Wyler"></asp:Label>
                <asp:Label ID="commentPostDate" runat="server" Text="2h"></asp:Label><br />
                <asp:Label ID="commentContent" runat="server" Text="Hey, I’ve heard of that organization before. They are scammers! beware and don’t use their services!!"></asp:Label><br />
               
                <div class="reportAndReply">
                <asp:HyperLink ID="reportCommentLink" runat="server">Report</asp:HyperLink>
                <asp:Button ID="replyButton1" runat="server" Text="Reply" class="replybtn"/><br />
                    </div>

            </div>
                </div>

            <div class="nameAndPicDiv" id="replySectionDiv">
            <asp:Image ID="pfp3" runat="server" src="../resources/images/pfp1.jpg"/>
            <div id="replyDiv" class="commentsDetails">

                <asp:Label ID="userName3" runat="server" Text="Ahmad Ibraheem"></asp:Label><br />
                <asp:Label ID="replyDate" runat="server" Text="2h"></asp:Label><br />
                <asp:Label ID="replyContent" runat="server" Text="Oh I see! Thank you."></asp:Label><br />

                <div class="reportAndReply">
                <asp:HyperLink ID="reportReplyLink" runat="server">Report</asp:HyperLink>
                <asp:Button ID="replyButton2" runat="server" Text="Reply" class="replybtn"/>
                    </div>
            </div>
                </div>

        </div>
             </div>
    </form>
</body>
</html>
