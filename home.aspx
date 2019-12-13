<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Notes.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>home</title>
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

    <form id="form1" runat="server" style="margin-top: 6vh;">
        <nav>
            <ul class="nav dp-flx jc-center">
                <li><a tabindex="0" id="nav_home" href="/home.aspx"><asp:Label ID="Name" runat="server" Text="Label"></asp:Label></a></li>
                <li>
                    <asp:LinkButton ID="LinkLogout" runat="server" OnClick="LinkLogout_Click">log out</asp:LinkButton></li>
                <li><span class="btn btn-accent" onclick="MicroModal.show('modal-1');" data-micromodal-trigger="modal-1">
                    <img src="resources/icons/plus-square.svg" width="20px" height="20px" class="dp-inl" style="transform: translateY(6px);" />new note</span></li>
            </ul>
        </nav>



        <div class="modal micromodal-slide" id="modal-1" aria-hidden="false">
            <div class="modal__overlay" tabindex="-1" data-micromodal-close>
                <div class="modal__container" role="dialog" aria-modal="true" aria-labelledby="modal-1-title">
                    <header class="modal__header">
                        <h2 class="modal__title" id="modal-1-title">New Note
                        </h2>
                        <button class="modal__close" aria-label="Close modal" data-micromodal-close></button>
                    </header>
                    <main class="modal__content" id="modal-1-content">
                        <p>
                            Try hitting the <code>tab</code> key and notice how the focus stays within the modal itself. Also, <code>esc</code> to close modal.
                        </p>
                        <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label><br />
                        <asp:TextBox class="input width-max" ID="Title" runat="server"></asp:TextBox><br />

                        <asp:Label ID="Label2" runat="server" Text="Body"></asp:Label><br />
                        <asp:TextBox class="input width-max" style="height: 300px;"  ID="Note" runat="server"></asp:TextBox><br />
                    </main>

                    <footer class="modal__footer">
                        <asp:Button class="modal__btn modal__btn-primary" ID="SaveNote" runat="server" Text="Save" OnClick="SaveNote_Click" />
                        <button class="modal__btn" data-micromodal-close aria-label="Close this dialog window">Close</button>
                    </footer>
                </div>
            </div>
            <div>
            </div>
        </div>
        <div class="dp-flx jc-start">
            <div class="">
                <asp:ListView Style="margin-top: 20px;" ID="ListView2" runat="server" DataSourceID="SqlDataSourceNotesList">
                    <LayoutTemplate>
                        <div runat="server" style="margin: 16px;"  id="lstProducts">
                            <div runat="server" id="itemPlaceholder" />
                        </div>
                        <asp:DataPager style="margin: 16px;" class="dp-blk" ID="pagebtn" runat="server" PageSize="5">
                            <Fields>
                                <asp:NextPreviousPagerField
                                    ButtonType="Button"
                                    ShowFirstPageButton="True"
                                    ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="plainBox" runat="server">
                            <asp:HyperLink ID="NoteLink" runat="server" target="NoteFrame" Text='<%# Eval("title") %>'
                                NavigateUrl='<%# "NoteDetails.aspx?noteID=" + Eval("Id") %>' />
                        </div>
                       
                    </ItemTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="SqlDataSourceNotesList" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [title], [Id] FROM [Notes] WHERE ([user_id] = @user_id)">
                    <SelectParameters>
                        <asp:SessionParameter Name="user_id" SessionField="user_id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div style="border-left:2px solid var(--light-gray);">
                
            </div>
            <iframe name="NoteFrame" src="" style="width:100%;height:90vh;border:none;border-left:1px solid var(--light-gray);">
            </iframe>
        </div>
         <%--<script>
            var link = document.getElementById('NoteLink');
            link.onclick = function (event) {
                if (event) {
                    event.preventDefault();
                } else {
                    window.event.returnValue = false;
                }

                document.getElementById('NoteFrame').src = link.href;
            }
        </script>--%>
    </form>
</body>
</html>
