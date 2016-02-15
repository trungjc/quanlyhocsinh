<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCateNewsGroup.ascx.cs"
    Inherits="CMS.Client.Admin.EditCateNewsGroup" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listcatenewsgroup/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editcatenewsgroup/Default.aspx">
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
            <td align="center" colspan="2">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="6">
        <tr>
            <td class="txt-from-taomoi" width="70%">
                <table width="100%" border="0" cellspacing="0" cellpadding="6">
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label13" runat="server" Text="Kiểu ngôn ngữ"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="NgonNgu">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi" style="width: 170px;">
                            <asp:Label ID="Label2" runat="server" Text="Tên nhóm danh mục"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCateNewsGroupName" runat="server" Width="270px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCateNewsGroupName"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label5" runat="server" Text="Giá trị"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtGroupCate" runat="server" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGroupCate"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label8" runat="server" Text="Icon (nếu có)"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="icon" runat="server" onchange="PreviewImage();" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="icon"
                                ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
                            <br />
                            <img id="uploadPreview" style="max-width: 100px" runat="server" src="" alt="" />
                            <script type="text/javascript">
                                var oFReader = new FileReader();
                                var uploadImage = '<%=icon.ClientID%>';
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
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label12" runat="server" Text="Vị trí"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPosition" runat="server" Width="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label1" runat="server" Text="Mô tả"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" Height="50px" TextMode="MultiLine"
                                Width="270px" Text=""></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="6" class="bg-line-cham">
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label3" runat="server" Text="Hiển thị"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkView" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label4" runat="server" Text="Hiện Trang chủ"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkHome" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label6" runat="server" Text="Hiện Trên Menu"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkMenu" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label7" runat="server" Text="Kiểu Menu Footer"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkNews" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label11" runat="server" Text="Kiểu Page(Rút gọn)"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkPage" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label9" runat="server" Text="Liên kết ngoài"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbUrl" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbUrl_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Value="True">Url (Internet)</asp:ListItem>
                                <asp:ListItem Selected="True" Value="False">(local)</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label10" runat="server" Text="Link liên kết(url)"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtUrl" runat="server" Width="272px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddCateNewsGroupID" runat="server" />
<asp:HiddenField ID="hddOrder" runat="server" />
<asp:HiddenField ID="hddIcon" runat="server" />
