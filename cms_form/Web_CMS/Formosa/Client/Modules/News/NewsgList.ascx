<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsgList.ascx.cs" Inherits="Fomusa.Client.Modules.News.NewsgList" %>
<div class="mainContent_panel2">
    <div class="mainContent_mainTitle">
        <asp:Image ID="Image1" ImageUrl="~/images/icon_home.png" runat="server" CssClass="icon"
            Width="32px" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server"></asp:Literal></span>
    </div>
    <div class="main_home">
        <div style="padding: 0 10px; vertical-align: top">
            <div id="CateNewsPanel" runat="server">
                <asp:DataList ID="DataListCateNews" runat="server" OnItemDataBound="DataListCateNews_ItemDataBound"
                    Width="100%">
                    <ItemTemplate>
                        <div class="main_title_news">
                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="main_title_news" NavigateUrl='<%# "~/News/"+Eval("GroupCate")+"/" +Eval("NewsGroupID")+"/"+GetString(Eval("Title")) +"/default.aspx" %>'
                                Text='<%# Eval("Title") %>'></asp:HyperLink>
                            <span class="date">
                                <asp:Label ID="LabelDate" runat="server" Text='<%#" ("+ Convert.ToString(Eval("PostDate")).Substring(0,10)+")" %>'
                                    CssClass="date"></asp:Label>
                            </span>
                        </div>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/News/"+Eval("GroupCate")+"/" +Eval("NewsGroupID")+"/"+GetString(Eval("Title")) +"/default.aspx" %>'>
                            <asp:Literal ID="ltlImageThumb" runat="server"></asp:Literal></asp:HyperLink>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ShortDescribe") %>' CssClass="main_desc_news"></asp:Label>
                        <div class="detail_link">
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/News/"+Eval("GroupCate")+"/" +Eval("NewsGroupID")+"/"+GetString(Eval("Title")) +"/default.aspx" %>'>Chi tiết ...</asp:HyperLink></div>
                    </ItemTemplate>
                </asp:DataList>
                <!--Tin tuc khác -->
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <br />
                <div class="main_article_list_other">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Title") %>' NavigateUrl='<%# "~/News/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +"/default.aspx"%>'></asp:HyperLink>
                                <asp:Label ID="LabelDate" runat="server" Text='<%#" ("+ Convert.ToString(Eval("PostDate")).Substring(0,10)+")" %>'
                                    CssClass="date"></asp:Label>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <!--End Tin tức khác-->
            </div>
            <!-- ********************************************* -->
            <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound"
                Width="610px">
                <ItemTemplate>
                    <div class="main_title_catenews">
                        <asp:HyperLink ID="hyperLink1" runat="server" NavigateUrl='<%#"~/Category/"+Eval("GroupCate")+"/"+Eval("CateNewsID") +"/"+GetString(Eval("CateNewsName")) +"/default.aspx" %>'><%#Eval("CateNewsName")%></asp:HyperLink></div>
                    <div class="main_linecate">
                    </div>
                    <asp:DataList ID="Datalist2" runat="server" OnItemDataBound="DataList2_ItemDataBound"
                        RepeatColumns="1" CellPadding="0" HorizontalAlign="Justify" RepeatDirection="Horizontal"
                        ItemStyle-VerticalAlign="Top" Width="610px">
                        <ItemTemplate>
                            <div class="main_title_news">
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="main_title_news" NavigateUrl='<%# "~/News/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +"/default.aspx"%>'
                                    Text='<%# Eval("Title") %>'></asp:HyperLink>
                                <asp:Label ID="LabelDate" runat="server" Text='<%#" ("+ Convert.ToString(Eval("PostDate")).Substring(0,10)+")" %>'
                                    CssClass="date"></asp:Label>
                            </div>
                            <div class="main_desc_news">
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/News/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +"/default.aspx" %>'>
                                    <asp:Literal ID="ltlImageThumb" runat="server"></asp:Literal></asp:HyperLink>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ShortDescribe") %>' CssClass="main_desc_news"></asp:Label>
                            </div>
                            <div class="detail_link">
                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/News/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +"/default.aspx" %>'>Chi tiết ...</asp:HyperLink></div>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" />
                    </asp:DataList>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</div>
<asp:HiddenField ID="hddGroupCate" runat="server" />