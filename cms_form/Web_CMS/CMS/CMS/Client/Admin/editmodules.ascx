<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editmodules.ascx.cs"
    Inherits="CMS.Client.Admin.editmodules" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listmodules/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editmodules/Default.aspx">
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
                <asp:Literal ID="error" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi" style="width: 140px">
                <asp:Label ID="Label1" runat="server" Text="Cấp độ menu modules :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlModules" runat="server" Width="300px" AppendDataBoundItems="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label2" runat="server" Text="Tên menu modules :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtModulesName" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtModulesName"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top" class="txt-from-taomoi">
                <asp:Label ID="Label4" runat="server" Text="Code URL :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtModulesUrl" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtModulesUrl"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label5" runat="server" Text="Icon :"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="uploadIcon" runat="server" Width="326px" onchange="PreviewImage();" />&nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="uploadIcon"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression='^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$'>.gif , .jpeg, .jpg </asp:RegularExpressionValidator>
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
            <td class="txt-from-taomoi">
                <asp:Label ID="Label6" runat="server" Text="Mô tả :"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi" colspan="2">
                <telerik:RadEditor ID="txtRadHelp" EnableEmbeddedSkins="true" Skin="Simple" runat="server"
                    ToolsFile="~/RadControls/Editor/BasicTools.xml" Height="200px" Width="600px"
                    EditModes="Design, Html">
                </telerik:RadEditor>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="txtModulesID" runat="server" />
<asp:HiddenField ID="hddIcon" runat="server" />
