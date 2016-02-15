<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditLink.ascx.cs" Inherits="CMS.Client.Admin.EditLink" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listlink/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editlink/Default.aspx">
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
    <table width="100%" border="0" cellpadding="5" cellspacing="0">
        <tr>
            <td align="center" colspan="2">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="140" class="txt-from-taomoi">
                <asp:Label ID="Label1" runat="server" Text="Url liên kết"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLinkUrl" runat="server" Width="270px" CssClass="txt-form-create-input"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLinkUrl"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label2" runat="server" Text="Hình ảnh"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="file_image_thumb" runat="server" onchange="PreviewImage();" />&nbsp;<asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1" runat="server" ControlToValidate="file_image_thumb"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
                <br />
                <img id="uploadPreview" style="max-width: 100px" runat="server" src="" alt="" />
                <script type="text/javascript">
                    var oFReader = new FileReader();
                    var uploadImage = '<%=file_image_thumb.ClientID%>';
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
            <td class="txt-from-taomoi">
                <asp:Label ID="Label3" runat="server" Text="Kích thước"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="chiều rộng :"></asp:Label>
                <asp:TextBox ID="txtLinkWidth" runat="server" Width="30px">80</asp:TextBox>&nbsp;<asp:RangeValidator
                    ID="RangeValidator1" runat="server" ControlToValidate="txtLinkWidth" ErrorMessage="RangeValidator"
                    MaximumValue="350" MinimumValue="30" Type="Integer">(từ 30-350 px)</asp:RangeValidator>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLinkWidth"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                <asp:Label ID="Label5" runat="server" Text="chiều cao"></asp:Label>
                <asp:TextBox ID="txtLinkHeight" runat="server" Width="30px">30</asp:TextBox>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtLinkHeight"
                    ErrorMessage="RangeValidator" MaximumValue="300" MinimumValue="10" Type="Integer">(từ 10-300px)</asp:RangeValidator>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLinkHeight"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi" valign="top">
                <asp:Label ID="Label6" runat="server" Text="Trạng thái"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbLinkStatus" runat="server" RepeatDirection="Vertical">
                    <asp:ListItem Selected="True" Value="True">Hiển thị</asp:ListItem>
                    <asp:ListItem Value="False">Ẩn</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddLinkID" runat="server" />
<asp:HiddenField ID="hddLinkImageThumb" runat="server" />
