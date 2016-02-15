<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listadmin.ascx.cs" Inherits="CMS.Client.Admin.listadmin" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editadmin/Default.aspx">
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
    <table width="100%" border="0" cellspacing="0" cellpadding="10">
        <tr>
            <td class="search_panel" valign="middle">
                <span class="txt-from-lable-search">
                    <asp:Label ID="Label11" runat="server" Text="Tìm kiếm :"></asp:Label></span>
                <asp:TextBox ID="txtKeyword" runat="server" Width="180px" Height="20" CssClass="txt-form-list-input"></asp:TextBox>
                &nbsp;trong:&nbsp;
                <asp:DropDownList ID="ddlRoles" runat="server" Width="150px" Height="24" AppendDataBoundItems="True"
                    CssClass="txt-form-list-input">
                </asp:DropDownList>
                <asp:ImageButton ID="btn_search" runat="server" OnClick="btn_search_Click" ImageUrl="~/Images/Admin_Theme/images/btn_Search.gif"
                    ImageAlign="AbsMiddle" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="grvAdmin" runat="server" AutoGenerateColumns="False" Width="100%"
                    OnRowCommand="grvAdmin_RowCommand" OnRowDataBound="grvAdmin_RowDataBound" OnRowDeleting="grvAdmin_RowDeleting"
                    CssClass="gridviewBorder" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="Admin_ID" HeaderText="#">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight"
                                Width="10px" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="25px" HorizontalAlign="Center"
                                Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Admin_Username" HeaderText="T&#234;n đăng nhập">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight"
                                Width="100px" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Admin_FullName" HeaderText="T&#234;n đầy đủ">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight"
                                Width="100px" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="100px" Wrap="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Admin_Email" HeaderText="Email quản trị">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Admin_Permission" HeaderText="Quyền" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-Width="200" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:BoundField>
                        <asp:CheckBoxField DataField="Admin_Actived" HeaderText="Trạng th&#225;i">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="40px" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="Admin_LoginType" HeaderText="Login Domain">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="40px" />
                        </asp:CheckBoxField>
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_user" runat="server" CommandName="user" CommandArgument='<%# Eval("Admin_Username") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_user.png" ToolTip="Thêm Nhóm quyền" />&nbsp;
                                <asp:ImageButton ID="btn_edit" runat="server" CommandName="edit" CommandArgument='<%# Eval("Admin_Username") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa" />&nbsp;
                                <asp:ImageButton ID="btn_delete" runat="server" CommandName="delete" CommandArgument='<%# Eval("Admin_Username") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="80px" />
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
</div>
