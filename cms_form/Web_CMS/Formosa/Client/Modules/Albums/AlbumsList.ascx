<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlbumsList.ascx.cs" Inherits="Fomusa.Client.Modules.Albums.AlbumsList" %>
<div class="mainContent_panel2">
    <div class="mainContent_mainTitle">
        <asp:Image ID="Image6" ImageUrl="~/images/block_albums.png" runat="server" CssClass="icon"
            Width="32px" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server" Text="<%$ Resources: resource, Libraries_Images%>" ></asp:Literal></span>
    </div>
    <div class="main_home">
        <div style="margin: 0 10px; vertical-align: top">
            <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound"
                RepeatColumns="2" CellPadding="10" HorizontalAlign="Justify" RepeatDirection="Horizontal"
                ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <div class="main_title_news" style="text-align: center;">
                        <a href="#" onclick='newwindow("<%# ResolveUrl("~/")+ "AlbumsView/" + Eval("AlbumsCateID") + "/default.aspx" %>");return false '>
                            <%#Eval("AlbumsCateName")%></a>
                    </div>
                    <div class="albums_frame">
                        <a href="#" onclick='newwindow("<%# ResolveUrl("~/")+ "AlbumsView/" + Eval("AlbumsCateID") + "/default.aspx" %>");return false '>
                            <asp:Literal ID="ltlImageThumb" runat="server"></asp:Literal></a>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</div>
