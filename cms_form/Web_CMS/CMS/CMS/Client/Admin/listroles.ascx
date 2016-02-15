<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listroles.ascx.cs" Inherits="CMS.Client.Admin.listroles" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editroles/Default.aspx">
			                    <span class="icon-32-publish" title="Đăng tin mới">
			                    </span>
			                    Tạo mới
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
    <center>
        <table width="100%" border="0" cellspacing="0" cellpadding="5">
            <tr>
                <td align="center">
                    <asp:GridView ID="grvRoles" runat="server" AutoGenerateColumns="False" Width="100%"
                        OnRowCommand="grvRoles_RowCommand" OnRowDataBound="grvRoles_RowDataBound" CssClass="gridviewBorder"
                        CellPadding="4" ForeColor="#333333" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="Roles_ID" HeaderText="ID">
                                <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                    Width="31px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Roles_Name" HeaderText="T&#234;n nh&#243;m quyền">
                                <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                                <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Chức năng">
                                <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btn_rules" runat="server" CommandName="rules" CommandArgument='<%# Eval("Roles_ID") %>'
                                        ImageUrl="~/images/Admin_Theme/images/btn_rules.png" ToolTip="Phân quyền" />&nbsp;
                                    <asp:ImageButton ID="btn_user" runat="server" CommandName="user" CommandArgument='<%# Eval("Roles_ID") %>'
                                        ImageUrl="~/images/Admin_Theme/images/btn_user.png" ToolTip="Thêm Tài khoản" />&nbsp;
                                    <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Roles_ID") %>'
                                        ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa" />&nbsp;
                                    <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Roles_ID") %>'
                                        ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                    Width="120px" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" HorizontalAlign="Center" CssClass="pagination-ys" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </center>
</div>
