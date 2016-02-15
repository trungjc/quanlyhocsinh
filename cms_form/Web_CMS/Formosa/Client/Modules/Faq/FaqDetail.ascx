<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FaqDetail.ascx.cs" Inherits="Fomusa.Client.Modules.Faq.FaqDetail" %>
<div class="mainContent_panel2">
    <div class="mainContent_mainTitle">
        <asp:Image ID="Image2" ImageUrl="~/images/icon_faq.png" runat="server" CssClass="icon"
            Width="32px" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server"></asp:Literal></span>
    </div>
    <div class="main_home">
        <div style="margin: 0 10px; vertical-align: top">
            <div class="gt_title">
                <table width="100%" border="0" cellspacing="0" cellpadding="4">
                    <tr>
                        <td width="62">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo_faq.gif" Width="62"
                                Height="56" />
                        </td>
                        <td align="left" valign="top" class="text_faq_title">
                            <asp:Literal ID="LiteralQuestion" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="gt_title" align="justify">
                <span class="text_faq_content">
                    <asp:Literal ID="LiteralAnswer" runat="server"></asp:Literal></span>
            </div>
            <div class="gt_title">
                <div class="title_article_top">
                    Câu hỏi khác</div>
            </div>
            <div class="main_article_list_other">
                <asp:Repeater ID="DataListOtherFaq" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Question") %>' NavigateUrl='<%# "~/FaqDetail/" +Eval("FaqID") +"/Default.aspx" %>'></asp:HyperLink>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</div>