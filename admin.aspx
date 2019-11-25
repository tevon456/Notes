<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Notes.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>signup</title>
    <link rel="stylesheet" href="resources/css/main.css" />
    <link rel="stylesheet" href="resources/css/input.css" />
    <link rel="stylesheet" href="https://unpkg.com/balloon-css/balloon.min.css" />
    <link rel="shortcut icon" href="resources/icons/favicon.ico" type="image/x-icon" />
    <script src="resources/js/main.js"></script>
</head>
<body onload="activeLink()">
    <nav>
        <ul class="nav dp-flx jc-center">
            <li><a tabindex="0" id="nav_admin" href="/admin.aspx">admin dashboard</a></li>
        </ul>
    </nav>
    <div class="dp-flx jc-center">
        <form id="form1" runat="server" style="margin-top: 10vh; background:none;">
            <div class="dp-flx jc-center">

                <asp:GridView class="data-grid-view" ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource_User">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="full_name" HeaderText="name" SortExpression="full_name" />
                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                        <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
                        <asp:BoundField DataField="active" HeaderText="active" SortExpression="active" />
                        <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource_User" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users] WHERE ([role] = @role)" DeleteCommand="DELETE FROM [Users] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Users] ([full_name], [email], [password], [comment], [active], [role]) VALUES (@full_name, @email, @password, @comment, @active, @role)" UpdateCommand="UPDATE [Users] SET [full_name] = @full_name, [email] = @email, [password] = @password, [comment] = @comment, [active] = @active, [role] = @role WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="full_name" Type="String" />
                        <asp:Parameter Name="email" Type="String" />
                        <asp:Parameter Name="password" Type="String" />
                        <asp:Parameter Name="comment" Type="String" />
                        <asp:Parameter Name="active" Type="Int16" />
                        <asp:Parameter Name="role" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="user" Name="role" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="full_name" Type="String" />
                        <asp:Parameter Name="email" Type="String" />
                        <asp:Parameter Name="password" Type="String" />
                        <asp:Parameter Name="comment" Type="String" />
                        <asp:Parameter Name="active" Type="Int16" />
                        <asp:Parameter Name="role" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
        </form>
    </div>
</body>
</html>
