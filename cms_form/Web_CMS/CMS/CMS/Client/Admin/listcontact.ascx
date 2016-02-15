<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listcontact.ascx.cs"
    Inherits="CMS.Client.Admin.listcontact" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editcontact/Default.aspx">
			                    <span class="icon-32-publish" title="Tạo mới">
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
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                        <asp:GridView ID="grvContact" runat="server" AutoGenerateColumns="False" Width="100%"
                            AllowPaging="True" OnRowCommand="grvContact_RowCommand" OnRowDataBound="grvContact_RowDataBound"
                            CssClass="gridviewBorder" PageSize="15" CellPadding="4" ForeColor="#333333" GridLines="None"
                            OnPageIndexChanging="grvContact_OnPageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="ContactID" HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                        Width="31px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Name" HeaderText="Họ t&#234;n kh&#225;ch h&#224;ng">
                                    <ItemStyle HorizontalAlign="Justify" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Tel" HeaderText="Điện thoại">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email">
                                    <ItemStyle HorizontalAlign="Justify" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Date" HeaderText="Ng&#224;y gửi">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SendMail" HeaderText="Send Mail">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="80px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Chức năng">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight"
                                        Width="70px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_print" runat="server" CommandName="_print" CommandArgument='<%# Eval("ContactID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btnPrint.png" />&nbsp;
                                        <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ContactID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_edit.png" />&nbsp;
                                        <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("ContactID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_delete.png" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="70px" />
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
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</div>
