<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Notes.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>home</title>
    <link rel="stylesheet" href="resources/css/main.css" />
    <link rel="stylesheet" href="resources/css/input.css" />
    <link rel="stylesheet" href="https://unpkg.com/balloon-css/balloon.min.css" />
    <link rel="shortcut icon" href="resources/icons/favicon.ico" type="image/x-icon" />
    <script src="resources/js/main.js"></script>
</head>
<body onload="activeLink()">
    <nav>
        <ul class="nav dp-flx jc-center">
            <li><a tabindex="0" id="nav_home" href="/home.aspx">home</a></li>
        </ul>
    </nav>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
