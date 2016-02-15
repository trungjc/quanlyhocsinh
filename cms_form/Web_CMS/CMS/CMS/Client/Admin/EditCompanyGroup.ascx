<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCompanyGroup.ascx.cs"
    Inherits="CMS.Client.Admin.EditCompanyGroup" %>
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
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="toolbar" ToolTip="Danh mục tin">
                                        <asp:ImageButton ID="btn_editpage" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-menu.png"
                                            OnClick="btn_list_click" />
                                        <br />
                                        Danh mục tin
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" ToolTip="Đăng tin mới">
                                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-publish.png"
                                            OnClick="btn_create_click" />
                                        <br />
                                        Đăng tin mới
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
        <asp:Literal ID="clientview" runat="server"></asp:Literal>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="6">
        <tr>
            <td class="txt-from-taomoi" width="70%">
                <table width="100%" border="0" cellspacing="0" cellpadding="5">
                    <tr>
                        <td width="140" class="txt-from-taomoi">
                            <asp:Label ID="Label1" runat="server" Text="Lựa chọn danh mục :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategories" runat="server" Width="370px" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label2" runat="server" Text="Tiêu đề :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" Width="370px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label4" runat="server" Text="Nội dung thông tin :"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="txtRadDescription"
                                ToolsFile="~/RadControls/Editor/FullSetOfTools.xml" Height="600px" Width="560px">
                                <MediaManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <TemplateManager DeletePaths="~/UserFile/Files/News" MaxUploadFileSize="20480000"
                                    UploadPaths="~/UserFile/Files/News" ViewPaths="~/UserFile/Files/News" />
                                <DocumentManager DeletePaths="~/UserFile/Files/News" MaxUploadFileSize="20480000"
                                    UploadPaths="~/UserFile/Files/News" ViewPaths="~/UserFile/Files/News" />
                                <FlashManager DeletePaths="~/UserFile/Media/News" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media/News"
                                    ViewPaths="~/UserFile/Media/News" />
                                <Content>
                            
                            
                            
                                </Content>
                                <ImageManager ViewPaths="~/UserFile/Images/News" DeletePaths="~/UserFile/Images/News"
                                    MaxUploadFileSize="3048000" UploadPaths="~/UserFile/Images/News"></ImageManager>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top" width="30%">
                <table width="100%" border="0" cellspacing="0" cellpadding="6" class="bg-line-cham">
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label10" runat="server" Text="Hiển thị"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbIsNormal" runat="server" CellPadding="0" CellSpacing="0"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="True">B&#236;nh thường</asp:ListItem>
                                <asp:ListItem Value="False">Ẩn</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label3" runat="server" Text="Tin Hot"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbIsHot" runat="server" CellPadding="0" CellSpacing="0"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="True">Tin Hot</asp:ListItem>
                                <asp:ListItem Value="False" Selected="True">Bình thường</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label5" runat="server" Text="Tin mặc định"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbIsDefault" runat="server" CellPadding="0" CellSpacing="0"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="True">Mặc định</asp:ListItem>
                                <asp:ListItem Value="False" Selected="True">Bình thường</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label7" runat="server" Text="Tác giả (nguồn) :"></asp:Label>
                        </td>
                        <td style="height: 24px">
                            <asp:TextBox ID="txtAuthor" runat="server" Width="240px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label12" runat="server" Text="Đăng Nhận xét (Comment)"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbComment" runat="server" RepeatDirection="Horizontal"
                                CellPadding="0" CellSpacing="0">
                                <asp:ListItem Selected="True" Value="False">Không đăng Comment</asp:ListItem>
                                <asp:ListItem Value="True">Đăng Comment</asp:ListItem>
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
                                <asp:ListItem Selected="True" Value="False">Chưa duyệt</asp:ListItem>
                                <asp:ListItem Value="True">Duyệt bài</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddCompanyID" runat="server" />
<asp:HiddenField ID="hddCommentTotal" runat="server" />
<asp:HiddenField ID="hddVisitTotal" runat="server" />
<asp:HiddenField ID="hddCreateUserName" runat="server" />
<asp:HiddenField ID="hddApprovalUserName" runat="server" />
<asp:HiddenField ID="hddApprovalDate" runat="server" />
<asp:HiddenField ID="hddCreatedDate" runat="server" />
<asp:HiddenField ID="hddGroupCate" runat="server" />
