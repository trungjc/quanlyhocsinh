<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listalbum.ascx.cs" Inherits="CMS.Client.Admin.listalbum" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editalbum/Default.aspx">
			                    <span class="icon-32-publish" title="Đăng tin mới">
			                    </span>
			                    Tạo mới
                                    </asp:HyperLink>
                                </td>
                                <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="btn_Order" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"
                                            OnClick="btn_Order_Click" />
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
    <table width="100%" border="0" cellspacing="0" cellpadding="10">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="grvAlbum" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" OnPageIndexChanging="grvAlbum_PageIndexChanging" OnRowCommand="grvAlbum_RowCommand"
                    OnRowDataBound="grvAlbum_RowDataBound" CssClass="gridviewBorder">
                    <Columns>
                        <asp:BoundField DataField="AlbumID" HeaderText="ID" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-Width="31" HeaderStyle-Height="22" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Sắp xếp">
                            <ItemStyle HorizontalAlign="Center" Width="60px" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOrder"
                                    Width="10px">*</asp:RequiredFieldValidator>&nbsp;
                                <asp:TextBox ID="txtOrder" runat="server" Width="20px" Text='<%# Eval("Order")%>'
                                    MaxLength="2"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtOrder"
                                    MaximumValue="100" MinimumValue="0" Type="Integer" Width="10px">*</asp:RangeValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ImageField DataImageUrlField="ImageThumb" DataImageUrlFormatString="~/Upload/Album/AlbumThumb/{0}"
                            HeaderText="H&#236;nh ảnh" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="center" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:ImageField>
                        <asp:CheckBoxField DataField="IsHome" HeaderText="Trang chủ" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-Width="91" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:CheckBoxField>
                        <asp:TemplateField HeaderText="Chức năng " HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-Width="91" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("AlbumID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa danh mục" />&nbsp;
                                <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("AlbumID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
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
