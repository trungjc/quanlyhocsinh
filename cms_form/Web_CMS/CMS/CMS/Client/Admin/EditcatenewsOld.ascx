<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditcatenewsOld.ascx.cs" Inherits="CMS.Client.Admin.EditcatenewsOld" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listcatenews/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editcatenews/Default.aspx">
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
            <td width="140" class="txt-from-taomoi" style="height: 22px">
                <asp:Label ID="Label6" runat="server" Text="Nhóm danh mục"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:RadioButtonList ID="rdbGroupCate" runat="server" RepeatDirection="Vertical"
                    AutoPostBack="True" OnSelectedIndexChanged="rdbGroupCate_SelectedIndexChanged">
                </asp:RadioButtonList>
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
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi" style="height: 22px">
                <asp:Label ID="Label4" runat="server" Text="Icon (nếu có)"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:FileUpload ID="file_icon" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="file_icon"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
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
<asp:HiddenField ID="HddGroupCate" runat="server" />
<asp:HiddenField ID="hddRoles" runat="server" />
<asp:HiddenField ID="hddUserName" runat="server" />
<asp:HiddenField ID="hddCreated" runat="server" />
