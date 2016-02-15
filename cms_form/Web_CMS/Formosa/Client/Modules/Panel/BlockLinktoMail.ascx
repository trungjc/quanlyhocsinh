<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockLinktoMail.ascx.cs" Inherits="Fomusa.Client.Modules.Panel.BlockLinktoMail" %>
<div class="block_panel">
    <div class="block_top">
        <img src="<%= ResolveUrl("~/") %>images/icon_contact.png" class="block_icon" />
        <span class="block_text_title">E-mail</span>
    </div>
    <div class="block_bg">
        <div class="block_body">
            <%--<a href="<%= System.Configuration.ConfigurationManager.AppSettings["UrlMail"].ToString() %>"
                style="color: #123891; font-size: 13px; text-decoration: none;">--%>
                <asp:Label ID="Label1" runat="server" Text="<%$ Resources: resource, Email%>"></asp:Label></a>
        </div>
    </div>
    <div class="block_bottom">
    </div>
</div>