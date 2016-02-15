<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditVideo.ascx.cs" Inherits="CMS.Client.Admin.EditVideo" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listvideo/Default.aspx">
                                            <span class="icon-32-menus" title="Danh mục">
                                            </span>
                                            Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editvideo/Default.aspx">
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
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="3">
                                        &nbsp;
                                    </td>
                                    <td width="250" class="txt-from-taomoi">
                                        <asp:Label ID="Label13" runat="server" Text="Ngôn ngữ"></asp:Label>
                                    </td>
                                    <td width="617">
                                        <asp:DropDownList runat="server" ID="NgonNgu">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="3">
                                        &nbsp;
                                    </td>
                                    <td width="250" class="txt-from-taomoi">
                                        <asp:Label ID="Label1" runat="server" Text="Tên Video"></asp:Label>
                                    </td>
                                    <td width="617">
                                        <asp:TextBox ID="txtVideoName" runat="server" Width="272px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="txt-from-taomoi">
                                        <asp:Label ID="Label7" runat="server" Text="Kiểu Video"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdbType" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbType_SelectedIndexChanged"
                                            AutoPostBack="true">
                                            <asp:ListItem Selected="True" Value="True">Url (Internet)</asp:ListItem>
                                            <asp:ListItem Value="False">Upload File Video (.flv)</asp:ListItem>
                                        </asp:RadioButtonList>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="txt-from-taomoi">
                                        <asp:Label ID="Label2" runat="server" Text="Link liên kết(url)đến Video"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVideoUrl" TextMode="MultiLine" Rows="3" runat="server" Width="272px"></asp:TextBox>
                                        <asp:FileUpload ID="txtFileName" runat="server" Width="272px" />
                                    </td>
                                </tr>                                
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="txt-from-taomoi">
                                        <asp:Label ID="Label3" runat="server" Text="Image Video"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="file_icon" runat="server" onchange="PreviewImage();" Width="301px" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="file_icon"
                                            ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
                                        <br />
                                        <img id="uploadPreview" style="max-width: 100px" runat="server" alt="" />
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
                                                    <asp:Label ID="Label5" runat="server" Text="Hiển thị"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rdbIsHome" runat="server" RepeatDirection="Vertical">
                                                        <asp:ListItem Selected="True" Value="True">Trang chủ</asp:ListItem>
                                                        <asp:ListItem Value="False">Trang thường</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txt-from-taomoi">
                                                    <asp:Label ID="Label6" runat="server" Text="Ngày đăng :"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="txtRadDate" runat="server" Width="150px" Culture="Vietnamese (Vietnam)">
                                                        <DateInput runat="server" Width="80"></DateInput>
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                        </table>
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
<asp:HiddenField ID="hddVideoID" runat="server" />
<asp:HiddenField ID="hddIcon" runat="server" />
<asp:HiddenField ID="hddFileName" runat="server" />
