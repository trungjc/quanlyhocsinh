<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoList.ascx.cs" Inherits="WebMedi.Client.Modules.Video.VideoList" %>
<div class="col-md-9 main-content">
    <div class="row navigater">
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server"></asp:Literal></span>
    </div>
    <div class="row main-category">
        <asp:Panel ID="PanelCate" runat="server">
            <div id="CateNewsPanel" runat="server">
                <div style="margin-left: 10px; margin-right: 10px; padding-top: 20px; margin-bottom: 30px;
                    vertical-align: top; text-align: center;">
                    <asp:Literal ID="ltlVideo" runat="server"></asp:Literal>
                </div>
            </div>
        </asp:Panel>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <div class="col-md-6" align="center">
                    <div class="video_frame1">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/listvideo/" +Eval("VideoID") +"/Video.aspx" %>'>
                            <asp:Literal ID="ltlImageThumb" runat="server"></asp:Literal></asp:HyperLink>
                    </div>
                    <div class="main_title_news" style="text-align: center">
                        <asp:HyperLink ID="hyperLink1" runat="server" NavigateUrl='<%# "~/listvideo/" +Eval("VideoID") +"/Video.aspx" %>'><%#Eval("VideoName")%></asp:HyperLink></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
