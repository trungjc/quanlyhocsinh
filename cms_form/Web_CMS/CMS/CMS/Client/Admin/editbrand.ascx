<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editbrand.ascx.cs" Inherits="CMS.Client.Admin.editbrand" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listbrand/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editbrand/Default.aspx">
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
    <table width="100%" border="0" cellpadding="2" cellspacing="0">
        <tr>
            <td align="center" class="txt-from-taomoi">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="3" style="height: 24px">
                            &nbsp;
                        </td>
                        <td width="125" class="txt-from-taomoi" style="height: 24px">
                            <asp:Label ID="Label1" runat="server" Text="Tên liên kết"></asp:Label>
                        </td>
                        <td width="617" style="height: 24px">
                            <asp:TextBox ID="txtBrandName" runat="server" Width="272px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBrandName"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label2" runat="server" Text="Link liên kết(url)"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBrandUrl" runat="server" Width="272px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBrandUrl"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label3" runat="server" Text="Icon"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="file_icon" runat="server" Width="310px"  onchange="PreviewImage();" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="file_icon"
                                ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
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
                        <td>
                            &nbsp;
                        </td>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label4" runat="server" Text="Mô tả ngắn gọn"></asp:Label>
                        </td>
                        <td>
                            <div style="padding-top: 3px;">
                                <asp:TextBox ID="txtShortDescribe" runat="server" TextMode="MultiLine" Width="272px"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="277" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="txt-from-taomoi">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 19px">
                                        <p>
                                            &nbsp;</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hddBrandID" runat="server" />
    <asp:HiddenField ID="hddIcon" runat="server" />
