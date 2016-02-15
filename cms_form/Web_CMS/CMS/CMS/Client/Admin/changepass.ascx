<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="changepass.ascx.cs" Inherits="CMS.Client.Admin.changepass" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar">
			                    <span class="icon-32-move" title="Nhập lại">
			                    </span>
			                   Làm lại
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
    <table width="90%" border="0" cellspacing="0" cellpadding="2">
        <tr>
            <td align="center" style="height: 23px">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="4">
        <tr>
            <td width="150" class="txt-from-taomoi">
                <asp:Label ID="Label1" runat="server" Text="Tài khoản :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAdminUser" runat="server" Width="200px" ReadOnly="True" CssClass="txt-form-create-input"
                    Height="20" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label7" runat="server" Text="Tên đầy đủ :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFullName" runat="server" Width="200px" CssClass="txt-form-create-input"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFullName"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label2" runat="server" Text="Email :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAdminEmail" runat="server" Width="200px" CssClass="txt-form-create-input"
                    Height="20" Enabled="false" ReadOnly="true"></asp:TextBox>&nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAdminEmail"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label3" runat="server" Text="Mật khẩu mới :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="News_Pass" runat="server" Width="200px" TextMode="Password" CssClass="txt-form-create-input"
                    Height="20"></asp:TextBox>&nbsp;
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"
                    ControlToCompare="News_Pass" ControlToValidate="Re_Pass">*</asp:CompareValidator>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="News_Pass"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top" class="txt-from-taomoi">
                <asp:Label ID="Label4" runat="server" Text="Nhắc lại mật khẩu :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Re_Pass" runat="server" Width="200px" TextMode="Password" CssClass="txt-form-create-input"
                    Height="20"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="Re_Pass"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="News_Pass"
                    ControlToValidate="Re_Pass" ErrorMessage="CompareValidator">mật khẩu chưa khớp</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <label for="imageField">
                </label>
            </td>
            <td>
                <asp:ImageButton ID="btn_Update" runat="server" OnClick="btn_Update_Click" ImageUrl="~/images/Admin_Theme/Icons/changepass_btn.gif" />
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hdd_Created" runat="server" />
<asp:HiddenField ID="hdd_log" runat="server" />
<asp:HiddenField ID="hddPass" runat="server" />
<asp:HiddenField ID="hddPermission" runat="server" />
<asp:HiddenField ID="hddRoles_ID" runat="server" />
<asp:HiddenField ID="hddActied" runat="server" />
<asp:HiddenField ID="hddAddress" runat="server" />
<asp:HiddenField ID="hddBirth" runat="server" />
<asp:HiddenField ID="hddSex" runat="server" />
<asp:HiddenField ID="hddNickYahoo" runat="server" />
<asp:HiddenField ID="hddNickSkype" runat="server" />
<asp:HiddenField ID="hddPhone" runat="server" />
<asp:HiddenField ID="hddImageThumb" runat="server" />
<asp:HiddenField ID="hddAdminLoginType" runat="server" />