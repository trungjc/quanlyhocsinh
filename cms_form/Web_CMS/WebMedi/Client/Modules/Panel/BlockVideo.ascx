<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockVideo.ascx.cs" Inherits="WebMedi.Client.Modules.Panel.BlockVideo" %>
<div class="row sidebar-content">
    <h4>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </h4>
</div>
<div class="row sidebar-body">
    <div class="col-md-12">
        <a href="<%= ResolveUrl("~/") %>listvideo/Default.aspx">
            <img src="<%= ResolveUrl("~/") %>Img/video_avatar.png" alt="" style="max-width:238px;" /></a></div>
</div>