<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Notes.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>login</title>
    <link rel="stylesheet" href="resources/css/main.css" />
    <link rel="stylesheet" href="resources/css/input.css" />
    <link rel="stylesheet" href="https://unpkg.com/balloon-css/balloon.min.css"/>
    <link rel="shortcut icon" href="resources/icons/favicon.ico" type="image/x-icon"/>
    <script src="resources/js/main.js"></script>
</head>
<body onload="activeLink()">
    <nav>
        <ul class="nav dp-flx jc-center">
            <li><a tabindex="0" id="nav_home" href="/index.aspx">GT Notes</a></li>
            <li><a tabindex="0" id="nav_about" href="/about.aspx">about</a></li>
        </ul>
    </nav>
    <section class="grid-center">
        <form id="form1" runat="server" style="margin-top: 20vh;" class="shadow border">
            <div>
                <h2 class="dp-blk">Login</h2>
                <span aria-label="email address" data-balloon-pos="up">
                    <img src="resources/icons/mail.svg" class="dp-inl" style="transform: translateY(8px);" />
                </span>
                <asp:TextBox class="input" type="email" placeholder="eg john@mail.com" ID="TextBoxEmail" runat="server" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2, 4}$"></asp:TextBox>

                <br />

                <span aria-label="password" data-balloon-pos="up">
                    <img src="resources/icons/key.svg" class="dp-inl" style="transform: translateY(8px);" />
                </span>
                <asp:TextBox class="input" type="password" placeholder="min 8 characters" ID="TextBoxPassword" runat="server"></asp:TextBox><br />

                <span data-balloon-length="medium" aria-label="select user type to login as, only works if you are of the selected role" data-balloon-pos="up">
                    <img src="resources/icons/user.svg" class="dp-inl" style="transform: translateY(4px);" />
                </span>

                <asp:DropDownList class="input" ID="DropDownListRole" runat="server">
                    <asp:ListItem Value="">Select role</asp:ListItem>
                    <asp:ListItem Value="user">User</asp:ListItem>
                    <asp:ListItem Value="admin">Admin</asp:ListItem>
                </asp:DropDownList>

                <asp:Button class="btn btn-black text-white" ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
                
                <br />
                <div  style="max-width:220px;">
                    <asp:Label ID="lb_msg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>

                <small>Dont have an account? <a href="/signup.aspx">Signup</a></small>
                
            </div>
        </form>
    </section>

</body>
</html>
