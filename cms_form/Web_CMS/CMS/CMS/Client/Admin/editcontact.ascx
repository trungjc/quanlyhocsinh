<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editcontact.ascx.cs"
    Inherits="CMS.Client.Admin.editcontact" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listcontact/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editcontact/Default.aspx">
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
            <td class="txt-from-taomoi" height="22" colspan="2">
                <asp:Literal ID="error" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="txtFullName1" runat="server" Text="Tên khách hàng:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="277px" CssClass="txt-form-create-input"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
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
                <asp:Label ID="Label7" runat="server" Text="Địa chỉ :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Width="400px" CssClass="txt-form-create-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label4" runat="server" Text="Điện thoại :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTel" runat="server" Width="200px" CssClass="txt-form-create-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label1" runat="server" Text="Fax:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFax" runat="server" Width="200px" CssClass="txt-form-create-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label9" runat="server" Text="Tỉnh/Thành phố  :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" Width="200px" CssClass="txt-form-create-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label12" runat="server" Text="Ngày liên hệ  :"></asp:Label>
            </td>
            <td>
                Ngày
                <asp:DropDownList ID="cboDay1" runat="server">
                </asp:DropDownList>
                Tháng
                <asp:DropDownList ID="cboMonth1" runat="server">
                </asp:DropDownList>
                Năm
                <asp:DropDownList ID="cboYear1" runat="server">
                </asp:DropDownList>
                Giờ
                <asp:DropDownList ID="cboHour1" runat="server">
                </asp:DropDownList>
                Phút
                <asp:DropDownList ID="cboMinutes1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label16" runat="server" Text="Công ty  :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCompany" runat="server" Width="400px" CssClass="txt-form-create-input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label8" runat="server" Text="Yêu cầu  :"></asp:Label>
            </td>
            <td>
                <textarea name="txtRequire" id="txtRequire" cols="40" rows="5" runat="server"></textarea>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label5" runat="server" Text="Trả lời  :"></asp:Label>
            </td>
            <td>
                <asp:TextBox name="txtAnswer" ID="txtAnswer" Height="80" Width="340" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label2" runat="server" Text="Gửi mail  :"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkSendMail" runat="server" OnCheckedChanged="chkSendMail_CheckChanged" />
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddContactID" runat="server" />
