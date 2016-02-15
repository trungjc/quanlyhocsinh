<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockAlbum.ascx.cs"
    Inherits="WebMedi.Client.Modules.Panel.BlockAlbum" %>
<div class="row sidebar-content">
    <h4>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </h4>
</div>
<div class="row sidebar-body">
    <div class="col-md-12">
        <a href="<%= ResolveUrl("~/") %>ListAlbums/Default.aspx">
            <img src="<%= ResolveUrl("~/") %>Img/album_avatar.png" alt="" style="max-width:238px;" /></a></div>
</div>
