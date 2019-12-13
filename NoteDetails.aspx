<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoteDetails.aspx.cs" Inherits="Notes.NoteDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Note</title>
    <link rel="stylesheet" href="resources/css/main.css" />
    <link rel="stylesheet" href="resources/css/input.css" />
    <link rel="stylesheet" href="https://unpkg.com/balloon-css/balloon.min.css" />
    <link rel="shortcut icon" href="resources/icons/favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" href="resources/css/modal.css" />
    <script src="https://unpkg.com/micromodal/dist/micromodal.min.js"></script>
    <script src="resources/js/main.js"></script>
    <script>MicroModal.init();</script>
</head>
<body onload="activeLink()">
    <form id="form1" runat="server">
        <nav>
            <ul class="nav dp-flx jc-center">
                <li>
                    <asp:Label ID="Title" runat="server" Text="Loading..."></asp:Label>
                </li>
                <li>
                    <asp:Button ID="Delete" runat="server" Text="Delete" BackColor="#FF3300" BorderColor="Black" BorderWidth="2" ForeColor="#333333" />
                </li>
            </ul>
        </nav>
        <div style="margin-top:20px;" class="dp-flx jc-center">
            <asp:Label style="margin-top:50px;max-width:400px;" ID="Body" runat="server" Text="Loading..."></asp:Label>
        </div>
    </form>
</body>
</html>
