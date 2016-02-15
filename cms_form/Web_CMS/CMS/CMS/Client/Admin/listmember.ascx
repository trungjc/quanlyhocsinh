<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listmember.ascx.cs"
    Inherits="CMS.Client.Admin.listmember" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editmember/Default.aspx">
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
    <table width="100%" border="0" cellspacing="0" cellpadding="5">
        <tr>
            <td align="center">
                <asp:GridView ID="grvMember" runat="server" AutoGenerateColumns="False" Width="100%"
                    OnRowCommand="grvMember_RowCommand" OnRowDataBound="grvMember_RowDataBound" OnRowDeleting="grvMember_RowDeleting"
                    CssClass="gridviewBorder" PageSize="50">
                    <Columns>
                        <asp:BoundField DataField="MemberID" HeaderText="#">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                Width="31px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Username" HeaderText="User Th&#224;nh vi&#234;n">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FullName" HeaderText="T&#234;n Th&#224;nh vi&#234;n">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Email" HeaderText="Email th&#224;nh vi&#234;n">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NickYahoo" HeaderText="Nick Yahoo">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="90px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_view" runat="server" CommandName="view" CommandArgument='<%# Eval("MemberID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_view.png" />&nbsp;
                                <asp:ImageButton ID="btn_edit" runat="server" CommandName="edit" CommandArgument='<%# Eval("Username") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa" />&nbsp;
                                <asp:ImageButton ID="btn_delete" runat="server" CommandName="delete" CommandArgument='<%# Eval("Username") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
