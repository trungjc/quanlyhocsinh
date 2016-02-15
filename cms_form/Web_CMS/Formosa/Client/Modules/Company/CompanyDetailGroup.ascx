<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyDetailGroup.ascx.cs" Inherits="Fomusa.Client.Modules.Company.CompanyDetailGroup" %>
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
            <div class="main_title_news_bold">
                <asp:Label ID="ltlTitle" runat="server" CssClass="main_title_news_bold"></asp:Label></div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 100%">
                        <div class="main_desc_news">
                            <asp:Literal ID="ltlDescribe" runat="server"></asp:Literal></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="main_content_author">
                            <asp:Label ID="LabelAuthor" runat="server" /></div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icon_print.gif" Width="16"
                            Height="16" CssClass="icon_bullet" />
                        <span class="title_right1">Print</span>
                    </td>
                </tr>
            </table>
        </div>
        <!--Tin tuc khác -->
        <div style="margin-left: 10px; margin-right: 10px; vertical-align: top">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <div class="main_article_list_other">
                <ul>
                    <asp:DataList ID="DataListNews" runat="server">
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Pages/"+ Eval("GroupCate") +"/" +Eval("CompanyID") +"/"+GetString(Eval("Title"))+".aspx" %>'
                                    Text='<%# Eval("Title") %>'></asp:HyperLink>
                            </li>
                        </ItemTemplate>
                    </asp:DataList>
                </ul>
            </div>
        </div>
        <!--End Tin tức khác-->
    </div>
    <div class="cat_main_bottom">
    </div>
</div>
<asp:HiddenField ID="txtCompanyID" runat="server" />
<asp:HiddenField ID="hddGroupCate" runat="server" />