<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sendmail.ascx.cs" Inherits="CMS.Client.Admin.sendmail" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right" width="200">
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
            <td class="txt-from-taomoi" style="width: 120px;">
                <asp:Label ID="Label2" runat="server" Text="Tiêu đề thư:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label5" runat="server" Text="Nội dung thư :"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="txt-from-taomoi">
                <telerik:RadEditor ID="txtRadFull" Skin="Default" runat="server" DeleteFlashPaths="~/UserFile/Media"
                    DeleteImagesPaths="~/UserFile/Images" DeleteMediaPaths="~/UserFile/Media" FlashPaths="~/UserFile/Media"
                    ImagesPaths="~/UserFile/Images" MediaPaths="~/UserFile/Media" UploadFlashPaths="~/UserFile/Media"
                    UploadImagesPaths="~/UserFile/Images" UploadMediaPaths="~/UserFile/Media" Width="570px"
                    Height="500px" ShowSubmitCancelButtons="False">
                </telerik:RadEditor>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center;">
                <asp:ImageButton ID="btn_add" runat="server" OnClick="btn_add_Click" ImageUrl="~/images/Admin_Theme/images/bt-sendmail.png" />
            </td>
        </tr>
    </table>
</div>
