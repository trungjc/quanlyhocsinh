<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listpage.ascx.cs" Inherits="CMS.Client.Admin.listpage" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editpage/Default.aspx">
			                    <span class="icon-32-publish" title="Đăng tin mới">
			                    </span>
			                    Đăng tin mới
                                    </asp:HyperLink>
                                </td>
                                <td id="Td7" style="text-align: center">
                                    <asp:HyperLink ID="btn_enable_approval" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-revert.png"
                                            OnClick="btn_enable_approval_Click" />
                                        <br />
                                        Phê duyệt
                                    </asp:HyperLink>
                                </td>
                                <td id="Td8" style="text-align: center">
                                    <asp:HyperLink ID="btn_disable_approval" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-revert-1.png"
                                            OnClick="btn_disable_approval_Click" />
                                        <br />
                                        Ngừng phê duyệt
                                    </asp:HyperLink>
                                </td>
                                <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="btn_enable" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton4" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"
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
                                    <asp:HyperLink ID="btn_delall" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="btn_delAll1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-delete.png"
                                            OnClick="btn_delAll_Click" />
                                        <br />
                                        Xóa tất cả
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
            <td valign="middle" style="height: 53px" align="center">
                <asp:RadioButtonList ID="rdbGroup" runat="server" RepeatDirection="Horizontal" Height="22px"
                    OnSelectedIndexChanged="rdbGroup_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="1">Sổ tay kinh nghiệm</asp:ListItem>
                    <asp:ListItem Value="2">Danh bạ</asp:ListItem>
                    <asp:ListItem Value="3">Tiện ích</asp:ListItem>
                    <%--   <asp:ListItem Value="4">Sổ tay kinh nghiệm</asp:ListItem>--%>
                </asp:RadioButtonList>
                <div style="padding-left: 20px; padding-bottom: 5px;">
                    <asp:HyperLink ID="btn_comment" runat="server" CssClass="toolbar">
                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-revert.png"
                            OnClick="btn_list" />
                        <br />
                        Danh sách Comment
                    </asp:HyperLink>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvPages" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                            OnRowDataBound="GridView1_RowDataBound" Width="100%" AllowPaging="True" OnPageIndexChanging="grvPages_PageIndexChanging"
                            CssClass="gridviewBorder" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="PageID" HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                        Width="25px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="#">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkId" runat="server" Checked="false" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="25px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="PageName" HeaderText="T&#234;n trang">
                                    <ItemStyle HorizontalAlign="Justify" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PageTitle" HeaderText="Ti&#234;u đề">
                                    <ItemStyle HorizontalAlign="Justify" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="PageID" DataNavigateUrlFormatString="~/Admin/listpagecomment/{0}/Default.aspx"
                                    DataTextField="CommentTotal" HeaderText="Số lượng Comment">
                                    <ItemStyle HorizontalAlign="Center" Font-Underline="False" ForeColor="Blue" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ControlStyle Font-Underline="False" ForeColor="RoyalBlue" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="50px" />
                                </asp:HyperLinkField>
                                <asp:BoundField DataField="PostDate" HeaderText="Ng&#224;y đăng" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                                    HeaderStyle-Width="80" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="IsApproval" HeaderText="Ph&#234; duyệt">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="50px" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="Status" HeaderText="Ph&#225;t h&#224;nh">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="60px" />
                                </asp:CheckBoxField>
                                <asp:TemplateField HeaderText="Chức năng">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_view" runat="server" CommandName="_view" CommandArgument='<%# Eval("PageID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_view.png" ToolTip="Xem chi tiết" />&nbsp;
                                        <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("PageID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa chữa" />
                                        &nbsp;<asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("PageID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="80px" />
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
<asp:HiddenField ID="hddGroup" runat="server" />
