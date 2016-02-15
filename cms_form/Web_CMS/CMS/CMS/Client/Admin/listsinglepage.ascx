<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listsinglepage.ascx.cs"
    Inherits="CMS.Client.Admin.listsinglepage" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editsinglepage/Default.aspx">
		                            <span class="icon-32-publish" title="Đăng tin mới">
		                            </span>
		                            Đăng tin mới
                                    </asp:HyperLink>
                                </td>
                                <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="btn_enable" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"
                                            OnClick="btn_enable_Click" />
                                        <br />
                                        Phát hành
                                    </asp:HyperLink>
                                </td>
                                <td id="Td4" style="text-align: center">
                                    <asp:HyperLink ID="btn_disable" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="btn_disable1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply-1.png"
                                            OnClick="btn_disable_Click" />
                                        <br />
                                        Ngừng phát hành
                                    </asp:HyperLink>
                                </td>
                                <td id="Td5" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="btn_delAll" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-delete.png"
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
    <table border="0" cellpadding="5" cellspacing="0" width="100%">
        <tr>
            <td align="center">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="grvSinglePage" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="gridviewBorder" OnPageIndexChanging="grvSinglePage_PageIndexChanging"
                    OnRowCommand="grvSinglePage_RowCommand" OnRowDataBound="grvSinglePage_RowDataBound"
                    Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="SinglePageID" HeaderText="ID" HeaderStyle-Width="25px"
                            HeaderStyle-Height="20px">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SinglePageName" HeaderText="T&#234;n trang đơn">
                            <ItemStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Justify" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CreatedUserName" HeaderText="Người đăng bài">
                            <ItemStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="center" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="100px" />
                        </asp:BoundField>
                        <asp:CheckBoxField DataField="Status" HeaderText="Trạng th&#225;i">
                            <ItemStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="60px" />
                        </asp:CheckBoxField>
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                            <ItemTemplate>
                                &nbsp;
                                <asp:ImageButton ID="btn_edit" runat="server" CommandArgument='<%# Eval("SinglePageID") %>'
                                    CommandName="_edit" ImageUrl="~/images/Admin_Theme/images/btn_edit.png" />&nbsp;
                                <asp:ImageButton ID="btn_delete" runat="server" CommandArgument='<%# Eval("SinglePageID") %>'
                                    CommandName="_delete" ImageUrl="~/images/Admin_Theme/images/btn_delete.png" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="80px" />
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
                        </div></ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</div>
