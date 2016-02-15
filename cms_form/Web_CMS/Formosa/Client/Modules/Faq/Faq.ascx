<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Faq.ascx.cs" Inherits="Fomusa.Client.Modules.Faq.Faq" %>
<div class="mainContent_panel2">
    <div class="mainContent_mainTitle">
        <asp:Image ID="Image2" ImageUrl="~/images/icon_faq.png" runat="server" CssClass="icon"
            Width="32px" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server" Text="<%$ Resources: resource, Faq%>"></asp:Literal></span>
    </div>
    <div class="main_home">
        <div style="margin: 0 10px; vertical-align: top">
            <div style="text-align: right; margin-bottom: 5px;">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="detail_link" Text='Đặt câu hỏi...'
                    NavigateUrl="~/question/Default.aspx"></asp:HyperLink>
            </div>
            <asp:DataList ID="DataListFaq" runat="server" Width="100%">
                <ItemTemplate>
                    <div class="gt_title">
                        <table width="100%" border="0" cellspacing="0" cellpadding="4">
                            <tr>
                                <td width="62">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo_faq.gif" Width="62"
                                        Height="56" />
                                </td>
                                <td align="left" valign="top" class="text_faq_title">
                                    <asp:HyperLink ID="HyperLinkQuestion" runat="server" CssClass="text_faq_title_link"
                                        Text='<%# Eval("Question") %>' NavigateUrl='<%# "~/FaqDetail/" +Eval("FaqID") +"/Default.aspx" %>'></asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="text-align: right; margin-bottom: 5px;">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="detail_link" Text='Xem trả lời...'
                            NavigateUrl='<%# "~/FaqDetail/" +Eval("FaqID") +"/Default.aspx" %>'></asp:HyperLink>
                    </div>
                    <div style="height: 1px; background-color: #eeeeee; width: 100%; text-align: center;">
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</div>
