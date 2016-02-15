<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsgDetail.ascx.cs" Inherits="Fomusa.Client.Modules.News.NewsgDetail" %>
<div class="mainContent_panel2">
    <div class="mainContent_mainTitle">
        <asp:Image ID="Image3" ImageUrl="~/images/block_hotnews.png" runat="server" CssClass="icon"
            Width="32px" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server"></asp:Literal></span>
    </div>
    <div class="main_home">
        <div style="padding: 0 10px; vertical-align: top">
            <div class="main_title_news_bold">
                <asp:Label ID="ltlTitle" runat="server" CssClass="main_title_news_bold"></asp:Label>
                <span class="date">(
                    <asp:Label ID="LabelDate" runat="server" CssClass="date"></asp:Label>
                    )</span></div>
            <div style="width: 100%">
                <%--<asp:Literal ID="ltlImageThumb" runat="server"></asp:Literal>--%>
                <div class="main_desc_news">
                    <strong>
                        <asp:Literal ID="ltlDescribe" runat="server"></asp:Literal></strong>
                </div>
                <div class="text_attach">
                    <asp:Literal ID="ltlFile" runat="server"></asp:Literal></div>
                <div class="main_desc_news">
                    <asp:Label ID="FullDescirbe" runat="server"></asp:Label></div>
            </div>
            <div class="main_content_author">
                <asp:Label ID="LabelAuthor" runat="server" /></div>
            <div style="text-align: center; vertical-align: middle;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/icon_print.gif" Width="16"
                    Height="16" CssClass="icon_bullet" />
                <span class="title_right1">
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="Print">Print</asp:LinkButton></span>
                &nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icon_email.gif" Width="16"
                    Height="16" CssClass="icon_bullet" />
                <span class="title_right1">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Send_email">Email</asp:LinkButton></span>
            </div>
            <div id="CommentPanel" runat="server">
                <asp:Label ID="lblComment" runat="server" Text=""></asp:Label>
                <div style="padding: 5px 5px 5px 5px">
                    <asp:DataList ID="DataListProductComment" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
                        Width="625px" CellPadding="4" ForeColor="#333333" BorderColor="#FFE0C0" BorderStyle="Solid"
                        BorderWidth="1px">
                        <ItemTemplate>
                            <span style="font-family: Tahoma; font-size: 11px; font-weight: bold; color: #9a1706">
                                <asp:Label ID="label1" Text='<%# Eval("Title") %>' runat="server"></asp:Label>
                            </span>&nbsp;<span style="font-family: Tahoma; font-size: 11px; font-style: italic;
                                color: Gray"><asp:Label ID="label2" Text='<%# Eval("DateCreated") %>' runat="server"></asp:Label></span><br />
                            <span style="font-family: Tahoma; font-size: 11px; color: Black">
                                <asp:Label ID="label3" Text='<%# Eval("Content") %>' runat="server"></asp:Label></span>
                            <br />
                            <div align="right">
                                <span style="font-family: Tahoma; font-size: 11px; font-weight: bold; color: Black;
                                    text-align: right">
                                    <asp:Label ID="label4" Text='<%# Eval("Email") %>' runat="server"></asp:Label></span></div>
                        </ItemTemplate>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <AlternatingItemStyle ForeColor="#284775" BackColor="Transparent" />
                        <ItemStyle BackColor="#FCF7F4" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    </asp:DataList>
                </div>
                <div style="padding: 10px 0;">
                    <div class='title_article_top_comment'>
                        Gửi ý kiến nhận xét</div>
                    <div style="color: #e51d18; text-align: center">
                        <asp:Literal ID="error" runat="server"></asp:Literal>
                    </div>
                    <div class="main_register_panel">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 20%; height: 20px" class="register_text">
                                    Tên của bạn
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFullName" runat="server" Width="377px" CssClass="register_text_input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%; height: 20px" class="register_text">
                                    Địa chỉ Email
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" Width="377px" CssClass="register_text_input"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        class="register_text_error1">Email không đúng</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%; height: 20px" class="register_text">
                                    Tiêu đề
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" Width="377px" CssClass="register_text_input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%; height: 20px" class="register_text">
                                    Nội dung
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContent" runat="server" Width="377px" CssClass="register_text_input"
                                        Height="100px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="height: 48px">
                                    <asp:ImageButton ID="ImageButton1" runat="server" OnClick="Send_Click" ImageUrl="~/images/btn_ykien.png" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!--Tin tuc khác -->
        <div style="padding: 0 10px; vertical-align: top">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <div class="main_article_list_other">
                <ul>
                    <asp:Repeater ID="DataListNews" runat="server">
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/News/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +".aspx"%>'
                                    Text='<%# Eval("Title") %>'></asp:HyperLink>
                                <asp:Label ID="LabelDate" runat="server" Text='<%#" ("+ Convert.ToString(Eval("PostDate")).Substring(0,10)+")" %>'
                                    CssClass="date"></asp:Label>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <!--End Tin tức khác-->
    </div>
</div>
<asp:HiddenField ID="txtNewsGroupID" runat="server" />
<asp:HiddenField ID="hddGroupCate" runat="server" />
