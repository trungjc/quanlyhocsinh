<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.ascx.cs" Inherits="Fomusa.Client.Modules.Search.SearchResult" %>
<div class="mainContent_panel2">
    <div class="mainContent_mainTitle">
        <asp:Image ID="Image1" ImageUrl="~/images/icon_search.png" runat="server" CssClass="icon"
            Width="32px" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server"></asp:Literal></span>
    </div>
    <div class="main_home">
        <div style="padding: 0 10px; vertical-align: top">
            <asp:DataList ID="DataListCateNews" runat="server" Width="100%">
                <ItemTemplate>
                    <div class="main_title_news">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="main_title_news" NavigateUrl='<%# "~/News/"+Eval("GroupCate")+"/" +Eval("NewsGroupID")+ "/" + GetString(Eval("Title")) +".aspx" %>'
                            Text='<%# Eval("Title") %>'></asp:HyperLink>
                    </div>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ShortDescribe") %>' CssClass="main_desc_news"></asp:Label>
                    <div class="detail_link">
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/News/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") + "/" + GetString(Eval("Title")) +".aspx" %>'>Chi tiết ...</asp:HyperLink></div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</div>