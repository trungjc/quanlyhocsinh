<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomePage.ascx.cs" Inherits="Fomusa.Client.MainHomePage" %>
<%@ Register Src="~/Client/Modules/Panel/BlockSearch.ascx" TagName="BlockSearch"
    TagPrefix="panelBlockSearch" %>
<%@ Register Src="~/Client/Modules/MainHome/MainHomeHotNews.ascx" TagName="MainHomeHotNews"
    TagPrefix="panelMainHomeHotNews" %>
<%@ Register Src="~/Client/Modules/MainHome/MainHomeTabAnnounce.ascx" TagName="MainHomeTabAnnounce"
    TagPrefix="panelMainHomeTabAnnounce" %>
<%@ Register Src="~/Client/Modules/MainHome/MainHomeTabGroupNews.ascx" TagName="MainHomeTabGroupNews"
    TagPrefix="panelMainHomeTabGroupNews" %>
<div class="mainContent_panel">
    <div class="mainContent_mainTitle">
        <panelBlockSearch:BlockSearch ID="blockSearch1" runat="server" />
    </div>
    <div class="main_home" style="padding-top: 10px;">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 890px; text-align: left; vertical-align: top">
                    <panelMainHomeHotNews:MainHomeHotNews ID="mainHomeHotNews1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div class="main_home" style="padding-top: 10px;">
        <div class="mainhome_tab_group_news">
            <asp:PlaceHolder ID="AreaMainPanel" runat="server"></asp:PlaceHolder>
        </div>
    </div>
</div>
<input type="hidden" id="Oload" value="<%= isPopup %>" />