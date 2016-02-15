<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editcatenews.ascx.cs"
    Inherits="CMS.Client.Admin.editcatenews" %>
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
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="toolbar" ToolTip="Danh mục nhóm">
                                        <asp:ImageButton ID="btn_editpage" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-menu.png"
                                            OnClick="btn_list_click" />
                                        <br />
                                        Danh mục nhóm
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" ToolTip="Đăng danh mục mới">
                                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-publish.png"
                                            OnClick="btn_create_click" />
                                        <br />
                                        Tạo mới
                                    </asp:HyperLink>
                                </td>
                                <td id="Td4" style="text-align: center">
                                    <asp:HyperLink ID="btn_add" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-save.png"
                                            OnClick="btn_add_Click" ValidationGroup="Save" />
                                        <br />
                                        Lưu lại
                                    </asp:HyperLink>
                                </td>
                                <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="btn_edit" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"
                                            OnClick="btn_edit_Click" ValidationGroup="Save" />
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
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label1" runat="server" Text="Cấp độ danh mục"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddlCateNews" runat="server" AppendDataBoundItems="True" Width="370px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label2" runat="server" Text="Tên danh mục"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCateNewsName" runat="server" Width="370px"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCateNewsName"
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Save">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi" style="height: 22px">
                <asp:Label ID="Label4" runat="server" Text="Icon (nếu có)"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:FileUpload ID="file_icon" runat="server"  onchange="PreviewImage();" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="file_icon"
                    ErrorMessage="RegularExpressionValidator" ValidationGroup="Save" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
                <br />
                <img id="uploadPreview" style="max-width: 100px" runat="server" src="" alt="" />
                <script type="text/javascript">
                    var oFReader = new FileReader();
                    var uploadImage = '<%=file_icon.ClientID%>';
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
            <td class="txt-from-taomoi" style="height: 22px">
                <asp:Label ID="Label6" runat="server" Text="Hình ảnh (nếu có)"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:FileUpload ID="FileUpload1" runat="server"  onchange="PreviewImage1();" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileUpload1"
                    ErrorMessage="RegularExpressionValidator" ValidationGroup="Save" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
                <br />
                <img id="uploadPreview1" style="max-width: 100px" runat="server" src="" alt="" />
                <script type="text/javascript">
                    var oFReader = new FileReader();
                    var uploadImage = '<%=FileUpload1.ClientID%>';
                    var uploadPreview = '<%=uploadPreview1.ClientID%>';

                    oFReader.readAsDataURL(document.getElementById(uploadImage).files[0]);

                    oFReader.onload = function (oFREvent) {
                        document.getElementById(uploadPreview).src = oFREvent.target.result;
                    };

                    function PreviewImage1() {
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
                <asp:Label ID="Label5" runat="server" Text="Khẩu hiệu"></asp:Label>
            </td>
            <td>
                <div style="padding-top: 3px;">
                    <asp:TextBox ID="txtSlogan" runat="server" Height="70px" TextMode="MultiLine" Width="370px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label7" runat="server" Text="Liên kết ngoài"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbType" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbType_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem Value="True">Url (Internet)</asp:ListItem>
                    <asp:ListItem Selected="True" Value="False">(local)</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label3" runat="server" Text="Link liên kết(url)"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUrl" runat="server" Width="272px"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddCateNewsID" runat="server" />
<asp:HiddenField ID="hddParentID" runat="server" />
<asp:HiddenField ID="hddCateNewsTotal" runat="server" />
<asp:HiddenField ID="hddCateNewsOrder" runat="server" />
<asp:HiddenField ID="hddIcon" runat="server" />
<asp:HiddenField ID="hddImage" runat="server" />
<asp:HiddenField ID="HddGroupCate" runat="server" />
<asp:HiddenField ID="hddRoles" runat="server" />
<asp:HiddenField ID="hddUserName" runat="server" />
<asp:HiddenField ID="hddCreated" runat="server" />
