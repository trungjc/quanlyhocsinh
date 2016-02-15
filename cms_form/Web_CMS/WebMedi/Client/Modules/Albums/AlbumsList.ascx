<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlbumsList.ascx.cs"
    Inherits="WebMedi.Client.Modules.Albums.AlbumsList" %>
<div class="col-md-9 main-content">
    <div class="row navigater">
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server" Text="<%$ Resources: resource, Libraries_Images%>"></asp:Literal></span>
    </div>
    <div class="row main-category">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <div class="col-md-6" align="center">                    
                    <div class="albums_frame">
                        <a href="#" onclick='newwindow("<%# ResolveUrl("~/")+ "AlbumsView/" + Eval("AlbumsCateID") + "/Albums.aspx" %>");return false '>
                            <asp:Literal ID="ltlImageThumb" runat="server"></asp:Literal></a>
                    </div>
                    <div class="main_title_news">
                        <a href="#" onclick='newwindow("<%# ResolveUrl("~/")+ "AlbumsView/" + Eval("AlbumsCateID") + "/Albums.aspx" %>");return false '>
                            <%#Eval("AlbumsCateName")%></a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>        
    </div>
</div>
