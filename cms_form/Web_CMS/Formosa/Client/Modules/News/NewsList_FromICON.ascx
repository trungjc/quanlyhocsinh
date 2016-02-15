<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsList_FromICON.ascx.cs" Inherits="Fomusa.Client.Modules.News.NewsList_FromICON" %>
<style type="text/css">
    .search_news
    {
        display: none !important;
    }
</style>
<div class="mainContent_panel2">
    <div class="mainContent_mainTitle">
        <asp:Image ID="Image1" ImageUrl="~/images/icon_news.png" runat="server" CssClass="icon"
            Width="32px" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server"></asp:Literal></span>
    </div>
    <div class="main_home">
    <div style="padding:0 10px;">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</div>