<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListAlbumsCate.ascx.cs"
    Inherits="CMS.Client.Admin.ListAlbumsCate" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editalbumscate/Default.aspx">
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
    <table width="100%" border="0" cellspacing="0" cellpadding="5">
        <tr>
            <td valign="top" align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvAlbumsCate" runat="server" AutoGenerateColumns="False" Width="100%"
                            AllowPaging="True" OnPageIndexChanging="grvAlbumsCate_PageIndexChanging" OnRowCommand="grvAlbumsCate_RowCommand"
                            OnRowDataBound="grvAlbumsCate_RowDataBound" CssClass="gridviewBorder" PageSize="50"
                            CellPadding="4" ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="AlbumsCateID">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                        Width="31px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ParentCateID" HeaderText="Cấp độ">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="gridviewCellBottom gridviewCellRight" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Sắp xếp">
                                    <ItemStyle HorizontalAlign="Center" Width="60px" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ItemTemplate>
                                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAlbumsCateOrder"
                                            Width="10px">*</asp:RequiredFieldValidator>&nbsp;
                                        <asp:TextBox ID="txtAlbumsCateOrder" runat="server" Width="20px" Text='<%# Eval("AlbumsCateOrder")%>'
                                            MaxLength="2"></asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtAlbumsCateOrder"
                                            MaximumValue="100" MinimumValue="0" Type="Integer" Width="10px">*</asp:RangeValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:HyperLinkField DataNavigateUrlFields="AlbumsCateID" DataNavigateUrlFormatString="~/Admin/listalbums/{0}/Default.aspx"
                                    DataTextField="AlbumsCateName" HeaderText="Tên Albums">
                                    <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                                </asp:HyperLinkField>
                                <asp:ImageField DataImageUrlField="ImageThumb" DataImageUrlFormatString="~/Upload/Albums/AlbumsCate/ImgThumb/{0}"
                                    HeaderText="Hình ảnh" ControlStyle-Width="200px">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="120px" />
                                </asp:ImageField>
                                <asp:BoundField DataField="AlbumsCateTotal" HeaderText="Số lượng ảnh">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="90px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Chức năng">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_view_image" runat="server" CommandName="_viewimage" CommandArgument='<%# Eval("AlbumsCateID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_viewimg.png" ToolTip="Danh sách ảnh trong Albums" />&nbsp;
                                        <asp:ImageButton ID="btn_add_image" runat="server" CommandName="_addimage" CommandArgument='<%# Eval("AlbumsCateID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_addimg.png" ToolTip="Thêm ảnh vào Albums" />&nbsp;
                                        <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("AlbumsCateID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa danh mục" />&nbsp;
                                        <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("AlbumsCateID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="120px" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" CssClass="pagination-ys" />
                            <RowStyle BackColor="#EFF3FB" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
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
                        </div></ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</div>
