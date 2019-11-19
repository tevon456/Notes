<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Notes.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>home</title>
    <link rel="stylesheet" href="resources/css/main.css" />
    <link rel="stylesheet" href="resources/css/input.css" />
</head>
<body>
    <form id="form1" runat="server" class="dp-flx jc-center">
        <h3 class="dp-blk">Login</h3><br />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label><br />
            <asp:TextBox class="input" placeholder="eg john@mail.com" ID="TextBoxEmail" runat="server"></asp:TextBox><br />
            
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox class="input" placeholder="min 8 characters" ID="TextBoxPassword" runat="server"></asp:TextBox><br />
            
            <asp:Label ID="lb_msg" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:Button class="btn btn-black text-white" ID="btn_login" runat="server" Text="Login" onClick="btn_login_Click"/>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
