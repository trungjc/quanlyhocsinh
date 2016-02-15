<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListMenuLinks.ascx.cs"
    Inherits="CMS.Client.Admin.ListMenuLinks" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editmenulinks/Default.aspx">
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
                        <asp:GridView ID="grvMenuLink" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            OnPageIndexChanging="grvMenuLink_PageIndexChanging" PageSize="40" OnRowCommand="grvMenuLink_RowCommand"
                            OnRowDataBound="grvMenuLink_RowDataBound" Width="100%" OnRowDeleting="grvMenuLink_RowDeleting"
                            CssClass="gridviewBorder" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="MenuLinksID">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                        Width="30px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MenuLinksParent" HeaderText="Cấp độ">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="gridviewCellBottom gridviewCellRight" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Sắp xếp thứ tự">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ItemTemplate>
                                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMenuLinksOrder"
                                            Width="10px">*</asp:RequiredFieldValidator>&nbsp;
                                        <asp:TextBox ID="txtMenuLinksOrder" runat="server" Width="20px" Text='<%# Eval("MenuLinksOrder")%>'
                                            MaxLength="2"></asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtMenuLinksOrder"
                                            MaximumValue="100" MinimumValue="0" Type="Integer" Width="10px">*</asp:RangeValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MenuLinksName" HeaderText="T&#234;n Danh mục">
                                    <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MenuLinksUrl" HeaderText="Đường dẫn">
                                    <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="220px" />
                                </asp:BoundField>
                                <asp:ImageField DataImageUrlField="MenuLinksIcon" DataImageUrlFormatString="~/Upload/MenuLinks/{0}"
                                    HeaderText="Icon">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="80px" />
                                </asp:ImageField>
                                <asp:CheckBoxField DataField="Status" HeaderText="Trạng th&#225;i">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="60px" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="IsView" HeaderText="IsView">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="60px" />
                                </asp:CheckBoxField>
                                <asp:TemplateField HeaderText="Chức năng">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_edit" runat="server" CommandName="edit" CommandArgument='<%# Eval("MenuLinksID") %>'
                                            ImageUrl="~/Images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa" />&nbsp;
                                        <asp:ImageButton ID="btn_delete" runat="server" CommandName="delete" CommandArgument='<%# Eval("MenuLinksID") %>'
                                            ImageUrl="~/Images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="60px" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" HorizontalAlign="Center" CssClass="pagination-ys" />
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
