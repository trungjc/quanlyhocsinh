<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editfaq.ascx.cs" Inherits="CMS.Client.Admin.editfaq" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listfaq/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editfaq/Default.aspx">
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
            <td colspan="2" align="center">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="140" class="txt-from-taomoi">
                <asp:Label ID="Label6" runat="server" Text="Tiêu đề câu hỏi :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtQuestion" runat="server" Width="297px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label7" runat="server" Text="Trả lời :"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="txt-from-taomoi">
                <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="txtRadAnswer"
                    SkinID="BasicTools" ToolsFile="~/RadControls/Editor/BasicTools.xml" Height="200px"
                    Width="510px" EditModes="Design, Html">
                    <Content>
                            
                            
                            
                    </Content>
                </telerik:RadEditor>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label8" runat="server" Text="Ngày trả lời :"></asp:Label><label for="radiobutton"><br />
                </label>
            </td>
            <td class="txt-from-taomoi">
                <telerik:RadDatePicker ID="txtRadPostDate" runat="server" Culture="Vietnamese (Vietnam)">
                    <DateInput Width="100">
                    </DateInput>
                    <Calendar FocusedDate="2008-07-18">
                    </Calendar>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi">
                <asp:Label ID="Label9" runat="server" Text="Trạng thái :"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbStatus" runat="server" RepeatDirection="Vertical">
                    <asp:ListItem Selected="True" Value="True">Hiển thị</asp:ListItem>
                    <asp:ListItem Value="Flase">Ẩn</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddFaqID" runat="server" />
