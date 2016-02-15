<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editmember.ascx.cs" Inherits="CMS.Client.Admin.editmember" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<link href="~\RadControls\Editor\Skins\Default\Editor.css" rel="stylesheet" type="text/css" />
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right">
                <div class="toolbar" id="toolbar">
                    <table class="toolbar">
                        <tbody>
                            <tr>
                                <td id="toolbar-unarchive">
                                    <asp:HyperLink ID="btn_home" runat="server" NavigateUrl="~/Admin/home/Default.aspx"
                                        CssClass="toolbar">
			                                <span class="icon-32-home" title="Trở về trang chủ">
			                                </span>
			                                Trang chủ
                                    </asp:HyperLink>
                                </td>
                                <td id="Td2" style="text-align: center">
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listmember/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editmember/Default.aspx">
			                                <span class="icon-32-publish" title="Đăng tin mới">
			                                </span>
			                                Tạo mới
                                    </asp:HyperLink>
                                </td>
                                <td id="Td4" style="text-align: center">
                                    <asp:HyperLink ID="btn_add" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-save.png"
                                            OnClick="btn_add_Click" />
                                        <br />
                                        Lưu lại
                                    </asp:HyperLink>
                                </td>
                                <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="btn_edit" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"
                                            OnClick="btn_edit_Click" />
                                        <br />
                                        Cập nhật
                                    </asp:HyperLink>
                                </td>
                                <td id="Td6">
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/home/Default.aspx"
                                        CssClass="toolbar">
			                                <span class="icon-32-help" title="Trợ giúp">
			                                </span>
			                                Trợ giúp
                                    </asp:HyperLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="5">
        <tr>
            <td colspan="2" height="22" align="center">
                <asp:Literal ID="error" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi" style="width: 140px;">
                <asp:Label ID="Label2" runat="server" Text="Tài khoản :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" Width="277px" CssClass="txt-form-create-input"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top" class="txt-from-taomoi">
                <asp:Label ID="Label4" runat="server" Text="Mật khẩu :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="277px" TextMode="Password" CssClass="txt-form-create-input"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label3" runat="server" Text="Email :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="277px" CssClass="txt-form-create-input"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="txtFullName1" runat="server" Text="Tên thành viên :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFullName" runat="server" Width="277px" CssClass="txt-form-create-input"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFullName"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label7" runat="server" Text="Ngày sinh :"></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="txtBirth" runat="server" Width="150px" Culture="Vietnamese (Vietnam)">
                    <DateInput CatalogIconImageUrl="" Description="" DisplayPromptChar="_" PromptChar=" "
                        Title="" TitleIconImageUrl="" TitleUrl="" Width="80"></DateInput>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label8" runat="server" Text="Giới tính :"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbSex" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="True">Nam</asp:ListItem>
                    <asp:ListItem Value="False">Nữ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label1" runat="server" Text="Điện thoại :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" Width="200px" CssClass="txt-form-create-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label6" runat="server" Text="Địa chỉ :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Width="300px" CssClass="txt-form-create-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label9" runat="server" Text="Nick Yahoo :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNickYahoo" runat="server" Width="200px" CssClass="txt-form-create-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label10" runat="server" Text="Nick Skype :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNickSkype" runat="server" Width="200px" CssClass="txt-form-create-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label11" runat="server" Text="Ảnh đại diện :"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="txtAvatar" runat="server" Width="200px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAvatar"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label5" runat="server" Text="Trạng thái"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbList" runat="server" RepeatDirection="Vertical">
                    <asp:ListItem Selected="True" Value="True">K&#237;ch hoạt</asp:ListItem>
                    <asp:ListItem Value="False">Ngưng k&#237;ch hoạt</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddUsername" runat="server" />
<asp:HiddenField ID="hddMemberID" runat="server" />
<asp:HiddenField ID="hddImageThumb" runat="server" />
