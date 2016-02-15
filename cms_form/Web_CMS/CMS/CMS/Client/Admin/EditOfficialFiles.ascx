<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditOfficialFiles.ascx.cs"
    Inherits="CMS.Client.Admin.EditOfficialFiles" %>
<%@ Register Assembly="RadEditor.Net2" Namespace="Telerik.WebControls" TagPrefix="radE" %>
<%@ Register Assembly="RadCalendar.Net2" Namespace="Telerik.WebControls" TagPrefix="radCln" %>
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
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Admin_Theme/Icons/icon-32-menu.png"
                                            OnClick="btn_listfile" CssClass="toolbar" />
                                        <br />
                                        Danh mục Tin
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/Admin_Theme/Icons/icon-32-new.png"
                                            OnClick="btn_editfile" CssClass="toolbar" />
                                        <br />
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
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="txt-from-taomoi" align="center">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="6">
        <tr>
            <td class="txt-from-taomoi" width="65%" valign="top">
                <table width="100%" border="0" cellpadding="5" cellspacing="0">
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label2" runat="server" Text="Tên File :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi" style="height: 22px">
                            <asp:Label ID="Label3" runat="server" Text="File văn bản :"></asp:Label>
                        </td>
                        <td style="height: 22px">
                            <asp:FileUpload ID="file_attached" runat="server" Width="350px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="grvFiles" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" OnPageIndexChanging="grvFiles_PageIndexChanging" OnRowCommand="grvFiles_RowCommand"
                    OnRowDataBound="grvFiles_RowDataBound" CssClass="gridviewBorder" CellPadding="4"
                    ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="OfficialFileID" HeaderText="ID" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-Width="30" HeaderStyle-Height="22" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="FileName" DataNavigateUrlFormatString="~/Upload/Official/Files/{0}"
                            DataTextField="Title" HeaderText="Tên file Văn bản">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:TemplateField HeaderText="Chức năng " HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-Width="60" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("OfficialFileID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa ảnh" />&nbsp;
                                <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("OfficialFileID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <div class="loading">
                            <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1"
                                DynamicLayout="True">
                                <ProgressTemplate>
                                        <img src="../../../../Images/icons/loading.gif" alt="Đang tải dữ liệu..." />
                                        <span>Đang tải dữ liệu...</span>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddOfficialFileID" runat="server" />
<asp:HiddenField ID="hddOfficialID" runat="server" />
<asp:HiddenField ID="hddFileName" runat="server" />
<asp:HiddenField ID="hddTitle" runat="server" />
