<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="CMS.Client.Admin.Login" %>
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" ImageUrl="~/images/Admin_Theme/Icons/icon_login.png"
        Width="32px" />
    <span class="subNavLink">Đăng nhập</span>
</div>
<div class="container_ListProduct">
    <div class="main_panel_homepage">
        <div class="error_register_text">
            <asp:Literal ID="error" runat="server"></asp:Literal></div>
        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
    </div>
    <div class="main_panel_homepage">
        <table width="100%" border="0" cellspacing="0" cellpadding="6">
            <tr>
                <td width="60%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="4">
                        <tr>
                            <td style="width: 45%; height: 20px; text-align: right" class="register_text_form">
                                Tài khoản:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAdminUser" runat="server" CssClass="register_text_input" Width="180"></asp:TextBox>
                                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdminUser"
                                    ErrorMessage="Tên đăng nhập chưa đúng">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; height: 20px; text-align: right" class="register_text_form">
                                Mật khẩu:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAdminPass" runat="server" TextMode="Password" CssClass="register_text_input"
                                    Width="180"></asp:TextBox>
                                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAdminPass"
                                    ErrorMessage="Mật khẩu chưa đúng">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; height: 20px; text-align: right" class="register_text_form">
                            </td>
                            <td align="left">
                                <asp:ImageButton ID="btn_sumit1" runat="server" ImageUrl="~/images/btn_submit.png"
                                    OnClick="btn_sumit1_Click" />
                                &nbsp;
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#" Visible="false" CssClass="ulink">Quên mật khẩu</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="6" class="bg-line-cham">
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="rdbCheck" runat="server" RepeatDirection="Vertical">
                                    <asp:ListItem Selected="True" Value="False">Quản trị nội dung Public</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</div>
