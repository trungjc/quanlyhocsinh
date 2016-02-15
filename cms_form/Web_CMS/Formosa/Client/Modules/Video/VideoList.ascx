<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoList.ascx.cs" Inherits="Fomusa.Client.Modules.Video.VideoList" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>
<div class="mainContent_panel2">
    <div class="mainContent_mainTitle">
        <asp:Image ID="Image6" ImageUrl="~/images/block_videos.png" runat="server" CssClass="icon"
            Width="32px" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server"></asp:Literal></span>
    </div>
    <div class="main_home">
        <asp:Panel ID="PanelCate" runat="server">
            <div id="CateNewsPanel" runat="server">
                <div style="margin-left: 10px; margin-right: 10px; padding-top: 20px; margin-bottom: 30px;
                    vertical-align: top; text-align: center;">
                    <asp:Literal ID="ltlVideo" runat="server"></asp:Literal>
                </div>
            </div>
        </asp:Panel>
        <div style="margin: 0 10px; vertical-align: top">
            <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound"
                RepeatColumns="3" CellPadding="10" HorizontalAlign="Justify" RepeatDirection="Horizontal"
                ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <div class="video_frame1">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/Video/" +Eval("VideoID") +"/video.aspx" %>'>
                            <asp:Literal ID="ltlImageThumb" runat="server"></asp:Literal></asp:HyperLink>
                    </div>
                    <div class="main_title_news" style="text-align: center">
                        <asp:HyperLink ID="hyperLink1" runat="server" NavigateUrl='<%# "~/Video/" +Eval("VideoID") +"/video.aspx" %>'><%#Eval("VideoName")%></asp:HyperLink></div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</div>
<radA:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <radA:AjaxSetting AjaxControlID="DataList1">
            <UpdatedControls>
                <radA:AjaxUpdatedControl ControlID="PanelCate" LoadingPanelID="Loading" />
            </UpdatedControls>
        </radA:AjaxSetting>
    </AjaxSettings>
</radA:RadAjaxManager>
<radA:AjaxLoadingPanel ID="Loading" runat="server" Height="75px" Width="75px">
    <asp:Image ID="Image2" runat="server" ImageUrl="~/RadControls/Ajax/Skins/Default/Loading5.gif" /></radA:AjaxLoadingPanel>
