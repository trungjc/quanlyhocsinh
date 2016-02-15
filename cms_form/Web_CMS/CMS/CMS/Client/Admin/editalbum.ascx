<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editalbum.ascx.cs" Inherits="CMS.Client.Admin.editalbum" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listalbum/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục tin">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editalbum/Default.aspx">
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
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="txt-from-taomoi" align="center">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="3">
                            &nbsp;
                        </td>
                        <td width="125" class="txt-from-taomoi">
                            <asp:Label ID="Label1" runat="server" Text="Danh mục"></asp:Label>
                        </td>
                        <td width="617">
                            <asp:DropDownList ID="ddlCateNews" runat="server" Width="276px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCateNews"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--                            <tr>
                        <td>
                            &nbsp;</td>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label2" runat="server" Text="Ảnh nhỏ"></asp:Label></td>
                        <td>
                            <asp:FileUpload ID="file_image_thumb" runat="server" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="file_image_thumb"
                                ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator></td>
                    </tr>--%>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label3" runat="server" Text="Ảnh đại diện"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="file_image_large" runat="server" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="file_image_large"
                                ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="277" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="bg-line-cham">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="txt-from-taomoi">
                                        <asp:Label ID="Label4" runat="server" Text="Hiển thị"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rdbIsHome" runat="server" RepeatDirection="Vertical">
                                            <asp:ListItem Selected="True" Value="True">Trang chủ</asp:ListItem>
                                            <asp:ListItem Value="Flase">Trang thường</asp:ListItem>
                                        </asp:RadioButtonList>
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
</div>
<asp:HiddenField ID="hddAlbumID" runat="server" />
<asp:HiddenField ID="hddCateNewsID" runat="server" />
<asp:HiddenField ID="hddImageLarge" runat="server" />
<asp:HiddenField ID="hddImageThumb" runat="server" />
<asp:HiddenField ID="hddOrder" runat="server" />
