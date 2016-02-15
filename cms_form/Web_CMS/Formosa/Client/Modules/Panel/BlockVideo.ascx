<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockVideo.ascx.cs" Inherits="Fomusa.Client.Modules.Panel.BlockVideo" %>
<div class="block_panel">
    <div class="block_top">
        <img src="<%= ResolveUrl("~/") %>images/block_videos.png" class="block_icon" />
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources: resource, Video_Gallery%>"
            CssClass=" block_text_title" />
    </div>
    <div class="block_bg">
        <div class="block_body">
            <a href="<%= ResolveUrl("~/") %>Video/Default.aspx">
                <img alt="Albums" src="<%= ResolveUrl("~/") %>images/video_avatar.png" width="128px"
                    height="128px" />
            </a>
        </div>
    </div>
    <div class="block_bottom">
    </div>
</div>