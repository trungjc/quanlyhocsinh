<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockAlbum.ascx.cs" Inherits="Fomusa.Client.Modules.Panel.BlockAlbum" %>
<div class="block_panel">
    <div class="block_top">
        <img src="<%= ResolveUrl("~/") %>images/block_albums.png" class="block_icon" />
        <asp:Label ID="lblTitle" CssClass="block_text_title" runat="server"></asp:Label>        
    </div>
    <div class="block_bg">
        <div class="block_body">
            <a href="<%= ResolveUrl("~/") %>Albums/Default.aspx">
                <img alt="Albums" src="<%= ResolveUrl("~/") %>images/album_avatar.png" width="128px"
                    height="128px" />
            </a>
        </div>
    </div>
    <div class="block_bottom">
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
<asp:HiddenField ID="hddTitle" runat="server" />