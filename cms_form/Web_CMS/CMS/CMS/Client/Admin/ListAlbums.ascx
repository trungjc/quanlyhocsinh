<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListAlbums.ascx.cs"
    Inherits="CMS.Client.Admin.ListAlbums" %>
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
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listalbumscate/Default.aspx">
	                                <span class="icon-32-menus" title="Danh mục">
	                                </span>
	                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <%--<td  id="Td2" style="text-align:center">
                          <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editalbums/Default.aspx">
			                    <span class="icon-32-publish" title="Đăng tin mới">
			                    </span>
			                    Tạo mới
                            </asp:HyperLink>
    			            
		                </td>--%>
                                <td id="Td2" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="toolbar" ToolTip="Đăng ảnh mới">
                                        <asp:ImageButton ID="btn_editpage" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-publish.png"
                                            OnClick="btn_edit_click" />
                                        <br />
                                        Đăng ảnh mới
                                    </asp:HyperLink>
                                </td>
                                <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="btn_delall" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="btn_delAll1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-delete.png"
                                            OnClick="btn_delall_Click" />
                                        <br />
                                        Xóa tất cả
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
                            OnRowDataBound="grvAlbum_RowDataBound" CssClass="gridviewBorder" CellPadding="4"
                            ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:BoundField DataField="AlbumsID" HeaderText="ID" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                                    HeaderStyle-Width="31" HeaderStyle-Height="22" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="#">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkId" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="31px" />
                                </asp:TemplateField>
                                <asp:ImageField DataImageUrlField="ImageThumb" DataImageUrlFormatString="~/Upload/Albums/AlbumsImg/ImgThumb/{0}"
                                    HeaderText="H&#236;nh ảnh" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                                    HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="75px" HeaderStyle-Width="100px">
                                    <ItemStyle HorizontalAlign="center" CssClass="gridviewCellBottom gridviewCellRight" />
                                </asp:ImageField>
                                <asp:BoundField DataField="Title" HeaderText="Ti&#234;u đề ảnh">
                                    <ItemStyle HorizontalAlign="Justify" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Mô tả ảnh">
                                    <ItemStyle HorizontalAlign="Justify" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="IsHot" HeaderText="Ảnh Hot" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                                    HeaderStyle-Width="40" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="IsHome" HeaderText="Hiển thị" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                                    HeaderStyle-Width="40" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                </asp:CheckBoxField>
                                <asp:TemplateField HeaderText="Chức năng " HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                                    HeaderStyle-Width="60" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("AlbumsID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa ảnh" />&nbsp;
                                        <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("AlbumsID") %>'
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
<asp:HiddenField ID="hddAlbumsCate" runat="server" />
