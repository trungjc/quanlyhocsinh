<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditModulesFrontPanel.ascx.cs"
    Inherits="CMS.Client.Admin.EditModulesFrontPanel" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listmodulesfrontpanel/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editmodulesfrontpanel/Default.aspx">
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
    <div class="search_panel" style="text-align: center; vertical-align: middle;">
        <asp:Literal ID="error" runat="server"></asp:Literal>
    </div>
    <table width="99%" border="0" cellspacing="0" cellpadding="6">
        <tr>
            <td class="txt-from-taomoi" width="70%">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label13" runat="server" Text="Kiểu ngôn ngữ"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="NgonNgu" OnSelectedIndexChanged="NgonNgu_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label10" runat="server" Text="Khung (Panel)"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbPanel" runat="server" RepeatDirection="Vertical" AutoPostBack="True"
                                OnSelectedIndexChanged="rdbPanel_SelectedIndexChanged">
                                <asp:ListItem Value="Left">LeftPanel</asp:ListItem>
                                <asp:ListItem Value="Right">RightPanel</asp:ListItem>
                                <asp:ListItem Value="Main">MainPanel</asp:ListItem>
                                <%-- <asp:ListItem Selected="True" Value="">None</asp:ListItem>--%>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi" style="width: 140px">
                            <asp:Label ID="Label1" runat="server" Text="Cấp độ menu modules :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlModulesFrontPanel" runat="server" Width="300px" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label2" runat="server" Text="Tên menu modules :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtModulesFrontPanelName" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtModulesFrontPanelName"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label4" runat="server" Text="Control (Url) :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dropControl" runat="server" Width="300px">
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtModulesFrontPanelUrl" runat="server" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtModulesFrontPanelUrl"
                                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label7" runat="server" Text="Tiêu đề:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtModulesFrontPanelTitle" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtModulesFrontPanelTitle"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label5" runat="server" Text="Biểu tượng (Icon) :"></asp:Label>
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
                        <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="txtRadHelp"
                                SkinID="BasicTools" ToolsFile="~/RadControls/Editor/BasicTools.xml" Height="200px"
                                Width="600px" EditModes="Design, Html">
                                <Content>
                            
                            
                            
                                </Content>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi" colspan="2">
                            <asp:Label ID="Label11" runat="server" Text="Nội dung module: (nếu là module dạng HTML)"></asp:Label>
                        </td>                        
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi" colspan="2">
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="txtRadFull"
                                SkinID="FullSetOfTools" ToolsFile="~/RadControls/Editor/FullSetOfTools.xml" Height="600px"
                                Width="600px">
                                <MediaManager DeletePaths="~/UserFile/Modules/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Modules/Media"
                                    ViewPaths="~/UserFile/Modules/Media" />
                                <TemplateManager DeletePaths="~/UserFile/Modules" MaxUploadFileSize="20480000"
                                    UploadPaths="~/UserFile/Modules" ViewPaths="~/UserFile/Modules" />
                                <DocumentManager DeletePaths="~/UserFile/Modules/Doc" MaxUploadFileSize="20480000"
                                    UploadPaths="~/UserFile/Modules/Doc" ViewPaths="~/UserFile/Modules/Doc" />
                                <FlashManager DeletePaths="~/UserFile/Modules/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Modules/Media"
                                    ViewPaths="~/UserFile/Modules/Media" />
                                <Content>      
                                </Content>
                                <ImageManager DeletePaths="~/UserFile/Modules/Images" UploadPaths="~/UserFile/Modules/Images"
                                    MaxUploadFileSize="3048000" ViewPaths="~/UserFile/Modules/Images"></ImageManager>
                            </telerik:RadEditor>
                        </td>
                    </tr>

                </table>
            </td>
            <td align="left" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="6" class="bg-line-cham">
                    <tr>
                        <td valign="top" class="txt-from-taomoi" style="width: 80px;">
                            <asp:Label ID="Label8" runat="server" Text="Giá trị:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlValueCategory" runat="server" AppendDataBoundItems="true">
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="txtValue" runat="server" Width="100px"></asp:TextBox>--%>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label9" runat="server" Text="Số bản ghi"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRecord" runat="server" Width="100px" ValidationGroup="check"></asp:TextBox>
                            <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server"
                                ControlToValidate="txtValue" ErrorMessage="Nhập kiểu số!" ValidationExpression="^\d+$"
                                ValidationGroup="check"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt-from-taomoi">
                            <asp:Label ID="Label3" runat="server" Text="Hiển thị"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkStatus" runat="server" Checked />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="txtModulesFrontPanelID" runat="server" />
<asp:HiddenField ID="hddIcon" runat="server" />
