<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListCompanyGroup.ascx.cs"
    Inherits="CMS.Client.Admin.ListCompanyGroup" %>
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
                                <td id="Td6" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listcompanyselect/Default.aspx">
                                    <span class="icon-32-menus" title="Danh mục">
                                    </span>
                                    Nhóm Danh mục 
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="btn_listComment" runat="server" CssClass="toolbar" ToolTip="Danh mục Comment">
                                        <asp:ImageButton ID="btn_listComment1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-archive.png"
                                            OnClick="btn_comment_click" />
                                        <br />
                                        Comment
                                    </asp:HyperLink>
                                </td>
                                <%-- <td  id="Td2" style="text-align:center">
                          <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Homepage.aspx?dll=editnewsGroup">
			                    <span class="icon-32-publish" title="Đăng tin mới">
			                    </span>
			                    Đăng tin mới
                            </asp:HyperLink>
    			            
		                </td>--%>
                                <td id="Td2" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" ToolTip="Đăng tin mới">
                                        <asp:ImageButton ID="btn_editpage" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-publish.png"
                                            OnClick="btn_edit_click" />
                                        <br />
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
                                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-revert-1.png"
                                            OnClick="btn_disable_approval_Click" />
                                        <br />
                                        Ngừng phê duyệt
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
                                    <asp:HyperLink ID="btn_delall" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="btn_delAll1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-delete.png"
                                            OnClick="btn_delall_Click" />
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
    <table border="0" cellpadding="5" cellspacing="0">
        <tr>
            <td class="search_panel" valign="middle">
                <span class="txt-from-lable-search">
                    <asp:Label ID="Label11" runat="server" Text="Tìm kiếm :"></asp:Label></span>
                <asp:TextBox ID="txtKeyword" runat="server" CssClass="txt-form-list-input" Height="20"
                    Width="180px"></asp:TextBox>
                &nbsp;trong:&nbsp;
                <asp:DropDownList ID="ddlCateNewsSearch" runat="server" AppendDataBoundItems="True"
                    CssClass="txt-form-list-input" Height="24" Width="150px">
                </asp:DropDownList>
                &nbsp;
                <asp:ImageButton ID="btn_search" runat="server" ImageUrl="~/images/Admin_Theme/images/btn_Search.gif"
                    OnClick="btn_search_Click" ImageAlign="AbsMiddle" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvCompany" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CssClass="gridviewBorder" OnRowCommand="grvCompany_RowCommand" OnRowDataBound="grvCompany_RowDataBound"
                            Width="100%" OnPageIndexChanging="grvCompany_PageIndexChanging" CellPadding="4"
                            ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="CompanyID" HeaderText="ID">
                                    <ItemStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                        Width="20px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="#">
                                    <ItemStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkId" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="20px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Title" HeaderText="Ti&#234;u đề tin">
                                    <ItemStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Justify" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="505px" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="CompanyID" DataNavigateUrlFormatString="~/Admin/listnewscomment/2/{0}/Default.aspx"
                                    DataTextField="CommentTotal" HeaderText="Số lượng Comment">
                                    <ItemStyle HorizontalAlign="Center" Font-Underline="False" ForeColor="Blue" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ControlStyle Font-Underline="False" ForeColor="RoyalBlue" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="60px" />
                                </asp:HyperLinkField>
                                <asp:BoundField DataField="CreatedDate" HeaderText="Ngày đăng">
                                    <ItemStyle HorizontalAlign="center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="80px" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="IsApproval" HeaderText="Ph&#234; duyệt">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="35px" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="IsNormal" HeaderText="Ph&#225;t h&#224;nh">
                                    <ItemStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="35px" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="IsDefault" HeaderText="Mặc định">
                                    <ItemStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="35px" />
                                </asp:CheckBoxField>
                                <asp:TemplateField HeaderText="Chức năng">
                                    <ItemStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_default" runat="server" CommandName="_default" CommandArgument='<%# Eval("CompanyID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_default.png" ToolTip="Thiết lập mặc định" />&nbsp;
                                        <asp:ImageButton ID="btn_view" runat="server" CommandName="_view" CommandArgument='<%# Eval("CompanyID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_view.png" ToolTip="Xem nội dung" />&nbsp;
                                        <asp:ImageButton ID="btn_edit" runat="server" CommandArgument='<%# Eval("CompanyID") %>'
                                            CommandName="_edit" ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa nội dung" />&nbsp;
                                        <asp:ImageButton ID="btn_delete" runat="server" CommandArgument='<%# Eval("CompanyID") %>'
                                            CommandName="_delete" ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa tin" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="110px" />
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
<asp:HiddenField ID="hddGroup" runat="server" />
