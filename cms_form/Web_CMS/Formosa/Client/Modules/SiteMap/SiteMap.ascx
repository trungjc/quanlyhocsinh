<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteMap.ascx.cs" Inherits="Fomusa.Client.Modules.SiteMap.SiteMap" %>
<div class="mainContent_panel2">
    <div class="mainContent_mainTitle">
        <asp:Image ID="Image6" ImageUrl="~/images/icon_sitemap.png" runat="server" CssClass="icon"
            Width="32px" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server" ></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server" Text="<%$ Resources: resource, Sitemap%>"></asp:Literal></span>
    </div>
    <div class="main_home">
        <div style="margin: 0 10px; vertical-align: top">
            <div class="content_Text_Cat_sitemap">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="Default.aspx">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/icon_home.png" CssClass="icon"
                        Width="25px" />
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: resource, Home%>"></asp:Literal>
                </asp:HyperLink>
            </div>
            <div class="content_Text_Cat_sitemap">
                <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <div class="content_Text_Cat_sitemap">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/icon_info.png" CssClass="icon"
                                Width="20px" />
                            <asp:HyperLink ID="hyperLink2" runat="server" NavigateUrl='<%#"~/FullNews/"+Eval("CateNewsGroupID") + "/" + GetString(Eval("CateNewsGroupName")) +".aspx" %>'><%#Eval("CateNewsGroupName")%></asp:HyperLink>
                        </div>
                        <dl class="navigation_right" style="padding-left: 20px;">
                            <asp:Repeater ID="rptnewsg" runat="server">
                                <ItemTemplate>
                                    <dt class="link">
                                        <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("CateNewsName")%>' NavigateUrl='<%# "~/Category/"+ Eval("GroupCate") +"/" +Eval("CateNewsID") + "/" + GetString(Eval("CateNewsName")) +"/default.aspx" %>'
                                            Target="_blank"></asp:HyperLink>
                                    </dt>
                                </ItemTemplate>
                            </asp:Repeater>
                        </dl>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="content_Text_Cat_sitemap">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Faq/Default.aspx">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icon_faq.png" CssClass="icon"
                        Width="25px" />
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: resource, Faq%>"></asp:Literal>
                    </asp:HyperLink>
            </div>
            <div class="content_Text_Cat_sitemap">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Albums/Default.aspx">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/block_albums.png" CssClass="icon"
                        Width="25px" />
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: resource, Libraries_Images%>"></asp:Literal></asp:HyperLink>
            </div>
            <div class="content_Text_Cat_sitemap">
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Video/Default.aspx">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/block_videos.png" CssClass="icon"
                        Width="25px" />
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources: resource, Video_Gallery%>"></asp:Literal></asp:HyperLink>
            </div>
            <div class="content_Text_Cat_sitemap">
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Contact/Default.aspx">
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/images/icon_contact.png" CssClass="icon"
                        Width="25px" />
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources: resource, Contact%>"></asp:Literal></asp:HyperLink>
            </div>
        </div>
    </div>
</div>
