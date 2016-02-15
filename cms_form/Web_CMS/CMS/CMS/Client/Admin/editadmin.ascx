<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editadmin.ascx.cs" Inherits="CMS.Client.Admin.editadmin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listadmin/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editadmin/Default.aspx">
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
    <div class="search_panel" style="height: 30px; text-align: center; line-height: 30px;
        vertical-align: middle;">
        <asp:Literal ID="error" runat="server"></asp:Literal>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="6">
        <tr>
            <td class="txt-from-taomoi" width="70%">
                <table width="100%" border="0" cellspacing="0" cellpadding="6">
                    <tr>
                        <td class="txt-from-taomoi" width="150">
                            <asp:Label ID="Label15" runat="server" Text="Kiểu tài khoản :"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbLoginType" runat="server" RepeatDirection="Vertical"
                                OnSelectedIndexChanged="rdbLoginType_SelectedIndexChanged" AutoPostBack="True"
                                Enabled="true">
                                <asp:ListItem Selected="True" Value="True">Tài khoản</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td width="150" class="txt-from-taomoi">
                            <asp:Label ID="Label2" runat="server" Text="Tài khoản :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAdminName" runat="server" Width="277px" CssClass="txt-form-create-input"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdminName"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="lblAdminPass" runat="server" Text="Mật khẩu :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAdminPass" runat="server" Width="277px" TextMode="Password" CssClass="txt-form-create-input"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label3" runat="server" Text="Email :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAdminEmail" runat="server" Width="277px" CssClass="txt-form-create-input"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAdminEmail"
                                ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAdminEmail"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="150" class="txt-from-taomoi">
                            <asp:Label ID="Label7" runat="server" Text="Tên đầy đủ :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFullName" runat="server" Width="277px" CssClass="txt-form-create-input"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFullName"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label8" runat="server" Text="Ngày sinh :"></asp:Label>
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
                            <asp:Label ID="Label9" runat="server" Text="Giới tính :"></asp:Label>
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
                            <asp:Label ID="Label10" runat="server" Text="Điện thoại :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" Width="200px" CssClass="txt-form-create-input"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label11" runat="server" Text="Địa chỉ :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" Width="300px" CssClass="txt-form-create-input"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label12" runat="server" Text="Nick Yahoo :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNickYahoo" runat="server" Width="200px" CssClass="txt-form-create-input"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label13" runat="server" Text="Nick Skype :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNickSkype" runat="server" Width="200px" CssClass="txt-form-create-input"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label14" runat="server" Text="Ảnh đại diện :"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="txtAvatar" runat="server" Width="310px" onchange="PreviewImage();" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAvatar"
                                ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
                            <img id="uploadPreview" style="max-width: 100px" runat="server" src="" alt="" />
                            <script type="text/javascript">
                                var oFReader = new FileReader();
                                var uploadImage = '<%=txtAvatar.ClientID%>';
                                var uploadPreview = '<%=uploadPreview.ClientID%>';

                                oFReader.readAsDataURL(document.getElementById(uploadImage).files[0]);

                                oFReader.onload = function (oFREvent) {
                                    document.getElementById(uploadPreview).src = oFREvent.target.result;
                                };

                                function PreviewImage() {
                                    var oFReader = new FileReader();
                                    oFReader.readAsDataURL(document.getElementById(uploadImage).files[0]);

                                    oFReader.onload = function (oFREvent) {
                                        document.getElementById(uploadPreview).src = oFREvent.target.result;
                                    };
                                };
                            </script>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="6" class="bg-line-cham">
                    <tr>
                        <td class="txt-from-taomoi">
                            <strong>
                                <asp:Label ID="Label5" runat="server" Text="Trạng thái"></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="rdbList" runat="server" RepeatDirection="Vertical">
                                <asp:ListItem Selected="True" Value="True">K&#237;ch hoạt</asp:ListItem>
                                <asp:ListItem Value="False">Ngưng k&#237;ch hoạt</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="Label6" runat="server" Text="Phân quyền người dùng"></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBoxList ID="chklist" runat="server">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddAdmin_Username" runat="server" />
<asp:HiddenField ID="hdd_Created" runat="server" />
<asp:HiddenField ID="hdd_log" runat="server" />
<asp:HiddenField ID="hddPass" runat="server" />
<asp:HiddenField ID="hddImageThumb" runat="server" />
