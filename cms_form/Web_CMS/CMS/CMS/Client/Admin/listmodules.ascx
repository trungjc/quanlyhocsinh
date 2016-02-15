<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listmodules.ascx.cs"
    Inherits="CMS.Client.Admin.listmodules" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editmodules/Default.aspx">
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
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                    OnRowDataBound="GridView1_RowDataBound" Width="100%" OnRowDeleting="GridView1_RowDeleting"
                    CssClass="gridviewBorder" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="Modules_ID" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Modules_Parent" HeaderText="Cấp độ">
                            <ItemStyle HorizontalAlign="Center" Width="20px" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Sắp xếp">
                            <ItemStyle HorizontalAlign="Center" Width="30px" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtModulesOrder"
                                    Width="10px">*</asp:RequiredFieldValidator>&nbsp;
                                <asp:TextBox ID="txtModulesOrder" runat="server" Width="20px" Text='<%# Eval("Modules_Order")%>'
                                    MaxLength="2"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtModulesOrder"
                                    MaximumValue="100" MinimumValue="0" Type="Integer" Width="10px">*</asp:RangeValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Modules_Name" HeaderText="T&#234;n modules">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Modules_Url" HeaderText="Đường dẫn">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="100px" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="Modules_Icon" DataImageUrlFormatString="ImageHandler.aspx?image=Upload/Admin_Theme/Icons/{0}"
                            HeaderText="Icon">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="80px" />
                        </asp:ImageField>
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_edit" runat="server" CommandName="edit" CommandArgument='<%# Eval("Modules_ID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa" />&nbsp;
                                <asp:ImageButton ID="btn_delete" runat="server" CommandName="delete" CommandArgument='<%# Eval("Modules_ID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="50px" />
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
