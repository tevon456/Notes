<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="Notes.about" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>about</title>
    <link rel="stylesheet" href="resources/css/main.css" />
    <link rel="stylesheet" href="resources/css/input.css" />
    <link rel="shortcut icon" href="resources/icons/favicon.ico" type="image/x-icon">
    <link rel="stylesheet" href="https://unpkg.com/balloon-css/balloon.min.css">
    <script src="resources/js/main.js"></script>
</head>
<body onload="activeLink()">
    <nav>
        <ul class="nav dp-flx jc-center">
            <li><a tabindex="0" id="nav_home" href="/index.aspx">GT Notes</a></li>
            <li><a tabindex="0" id="nav_about" href="/about.aspx">about</a></li>
        </ul>
    </nav>
    <main class="main">
        <h1>
            About
        </h1>
        <p class="lh1-2"> 
            GT Notes is a simple note taking application that removes the fluff and allows you to focus on what matters, getting your ideas down and stored.
        </p>

        <p class="lh1-2"> 
            GT Notes was created by software engineers Tevon Davis , Gerard Neil and Daquaman.
        </p>
    </main>
</body>
</html>
