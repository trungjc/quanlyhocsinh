<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditDownload.ascx.cs" Inherits="CMS.Client.Admin.EditDownload" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listdownload/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editdownload/Default.aspx">
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
        <tr>
            <td width="140" class="txt-from-taomoi">
                <asp:Label ID="Label1" runat="server" Text="Lựa chọn danh mục :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCateDownload" runat="server" Width="300px" AppendDataBoundItems="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label2" runat="server" Text="Tiêu đề :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label3" runat="server" Text="Ảnh File Download  (nếu có) :"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="file_image_thumb" runat="server" Width="400px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="file_image_thumb"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label11" runat="server" Text="File Download (nếu có) :"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="file_attached" runat="server" Width="400px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="file_attached"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((doc)|(xls)|(pdf)|(rar)|(zip)|(ppt)|(DOC)|(XLS)|(PDF)|(RAR)|(ZIP)|(PPT))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label4" runat="server" Text="Mô tả ngắn gọn phiên bản download :"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <telerik:RadEditor ID="txtRadShort" Skin="Default" runat="server" DeleteFlashPaths="~/UserFile/Media"
                    DeleteImagesPaths="~/UserFile/Images" DeleteMediaPaths="~/UserFile/Media" FlashPaths="~/UserFile/Media"
                    Height="200px" ImagesPaths="~/UserFile/Images" MediaPaths="~/UserFile/Media"
                    ToolsFile="~/RadControls/Editor/BaseFile.xml" UploadFlashPaths="~/UserFile/Media"
                    UploadImagesPaths="~/UserFile/Images" UploadMediaPaths="~/UserFile/Media" Width="450px"
                    ShowSubmitCancelButtons="False" DeleteDocumentsPaths="~/UserFile/Files" DocumentsPaths="~/UserFile/Files"
                    MaxDocumentSize="51200000" UploadDocumentsPaths="~/UserFile/Files" MaxFlashSize="10240000"
                    MaxImageSize="20480000" MaxMediaSize="524288000">
                </telerik:RadEditor>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label5" runat="server" Text="Nội dung chi tiết :"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <telerik:RadEditor ID="txtRadFull" Skin="Default" runat="server" DeleteFlashPaths="~/UserFile/Media"
                    DeleteImagesPaths="~/UserFile/Images" DeleteMediaPaths="~/UserFile/Media" FlashPaths="~/UserFile/Media"
                    ImagesPaths="~/UserFile/Images" MediaPaths="~/UserFile/Media" UploadFlashPaths="~/UserFile/Media"
                    UploadImagesPaths="~/UserFile/Images" UploadMediaPaths="~/UserFile/Media" Width="580px"
                    Height="500px" ShowSubmitCancelButtons="False" MaxFlashSize="1024000" MaxImageSize="2048000"
                    MaxMediaSize="52428800" DeleteDocumentsPaths="~/UserFile/Files" DocumentsPaths="~/UserFile/Files"
                    MaxDocumentSize="51200000" UploadDocumentsPaths="~/UserFile/Files">
                </telerik:RadEditor>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label10" runat="server" Text="Loại tin"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbIshot" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                    CellSpacing="0">
                    <asp:ListItem Selected="True" Value="False">Kiểu thường</asp:ListItem>
                    <asp:ListItem Value="True">Kiểu hot</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label6" runat="server" Text="Ngày đăng :"></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="txtRadDate" runat="server" Width="150px" Culture="Vietnamese (Vietnam)">
                    <DateInput CatalogIconImageUrl="" Description="" DisplayPromptChar="_" PromptChar=" "
                        Title="" TitleIconImageUrl="" TitleUrl="" Width="80"></DateInput>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label7" runat="server" Text="Tác giả (nguồn) :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAuthor" runat="server" Width="140px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label8" runat="server" Text="Trạng thái :"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbStatus" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="True">Hiển thị</asp:ListItem>
                    <asp:ListItem Value="False">Ẩn</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label9" runat="server" Text="Hiển thị"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbIshome" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                    CellSpacing="0">
                    <asp:ListItem Value="False">Trang thường</asp:ListItem>
                    <asp:ListItem Selected="True" Value="True">Trên trang chủ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label12" runat="server" Text="Đăng Nhận xét (Comment)"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbComment" runat="server" RepeatDirection="Horizontal"
                    CellPadding="0" CellSpacing="0">
                    <asp:ListItem Value="False">Không đăng Comment</asp:ListItem>
                    <asp:ListItem Selected="True" Value="True">Đăng Comment</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label13" runat="server" Text="Duyệt bài"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbApproval" runat="server" RepeatDirection="Horizontal"
                    CellPadding="0" CellSpacing="0">
                    <asp:ListItem Value="False">Chưa duyệt</asp:ListItem>
                    <asp:ListItem Selected="True" Value="True">Duyệt bài</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddDownloadID" runat="server" />
<asp:HiddenField ID="hddImageThumb" runat="server" />
<asp:HiddenField ID="hddFileName" runat="server" />
<asp:HiddenField ID="hddRelationTotal" runat="server" />
<asp:HiddenField ID="hddParentDownloadID" runat="server" />
<asp:HiddenField ID="hddCommentTotal" runat="server" />
<asp:HiddenField ID="hddIsView" runat="server" />
<asp:HiddenField ID="hddCreateUserName" runat="server" />
<asp:HiddenField ID="hddApprovalUserName" runat="server" />
<asp:HiddenField ID="hddApprovalDate" runat="server" />
