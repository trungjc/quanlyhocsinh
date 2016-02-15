<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditMenuLinks.ascx.cs"
    Inherits="CMS.Client.Admin.EditMenuLinks" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listmenulinks/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editmenulinks/Default.aspx">
			                                <span class="icon-32-publish" title="Đăng tin mới">
			                                </span>
			                                Tạo mới
                                    </asp:HyperLink>
                                </td>
                                <td id="Td4" style="text-align: center">
                                    <asp:HyperLink ID="btn_add" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="toolbar" ImageUrl="~/Images/Admin_Theme/Icons/icon-32-save.png"
                                            OnClick="btn_add_Click" />
                                        <br />
                                        Lưu lại
                                    </asp:HyperLink>
                                </td>
                                <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="btn_edit" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/Images/Admin_Theme/Icons/icon-32-apply.png"
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
            <td align="center">
                <asp:Literal ID="error" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="txt-from-taomoi" style="width: 211px" align="right">
                            <asp:Label ID="Label1" runat="server" Text="Cấp độ Danh mục :"></asp:Label>
                        </td>
                        <td width="617">
                            <asp:DropDownList ID="ddlMenuLinks" runat="server" Width="300px" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi" align="right">
                            <asp:Label ID="Label2" runat="server" Text="Tên Danh mục :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMenuLinksName" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMenuLinksName"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi" style="height: 27px;" align="right">
                            <asp:Label ID="Label4" runat="server" Text="Địa chỉ liên kết (URL) :"></asp:Label>
                        </td>
                        <td style="height: 27px">
                            <div style="padding-top: 3px;">
                                <asp:TextBox ID="txtMenuLinksUrl" runat="server" Width="300px"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi" style="height: 27px;" align="right">
                            <asp:Label ID="Label5" runat="server" Text="Biểu tượng (Icon) :"></asp:Label>
                        </td>
                        <td style="height: 27px">
                            <asp:FileUpload ID="uploadIcon" runat="server" Width="281px" onchange="PreviewImage();" />&nbsp;
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="uploadIcon"
                                ErrorMessage="RegularExpressionValidator" ValidationExpression='^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp))$'>.gif , .jpeg, .jpg </asp:RegularExpressionValidator>
                            <br />
                            <img id="uploadPreview" style="max-width: 100px" runat="server" src="" alt="" />
                            <script type="text/javascript">
                                var oFReader = new FileReader();
                                var uploadImage = '<%=uploadIcon.ClientID%>';
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
                        <td class="txt-from-taomoi" valign="top" align="right">
                            <asp:Label ID="Label6" runat="server" Text="Mô tả danh mục :"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi" colspan="2" style="height: 27px" valign="top">
                            <telerik:RadEditor runat="server" Skin="Simple" ID="txtRadHelp" ToolsFile="~/RadControls/Editor/BasicTools.xml"
                                Height="200px" Width="600px" EditModes="Design, Html">
                                <Content>
                            
                            
                            
                                </Content>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="377" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="txt-from-taomoi" style="width: 80px">
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
                                    <td class="txt-from-taomoi" style="width: 80px">
                                        <asp:Label ID="Label9" runat="server" Text="Hiển thị (Trang chủ)"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdbIsView" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                                            CellSpacing="0">
                                            <asp:ListItem Selected="True" Value="False">Trang thường</asp:ListItem>
                                            <asp:ListItem Value="True">Trên trang chủ</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="txt-from-taomoi" style="width: 80px">
                                        <asp:Label ID="Label3" runat="server" Text="Target"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTarget" runat="server" Width="100px" AppendDataBoundItems="True">
                                            <asp:ListItem Value="_blank" Text="_blank"></asp:ListItem>
                                            <asp:ListItem Value="_parent" Text="_parent"></asp:ListItem>
                                            <asp:ListItem Value="_search" Text="_search"></asp:ListItem>
                                            <asp:ListItem Value="_self" Text="_self"></asp:ListItem>
                                            <asp:ListItem Value="_top" Text="_top"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtMenuLinksID" runat="server" />
    <asp:HiddenField ID="hddIcon" runat="server" />
