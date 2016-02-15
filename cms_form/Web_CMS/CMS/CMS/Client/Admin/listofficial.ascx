<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listofficial.ascx.cs"
    Inherits="CMS.Client.Admin.listofficial" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editofficial/Default.aspx">
			                    <span class="icon-32-publish" title="Đăng tin mới">
			                    </span>
			                    Thêm LXN con
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
            <td valign="top">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="search_panel" valign="middle">
                            <span class="txt-from-lable-search">
                                <asp:Label ID="Label11" runat="server" Text="Tìm kiếm :"></asp:Label></span>
                            <asp:TextBox ID="txtKeyword" runat="server" Width="250px" Height="22" CssClass="txt-form-list-input"></asp:TextBox>
                            &nbsp;trong:&nbsp;
                            <asp:DropDownList ID="ddlCateNewsSearch" runat="server" Width="220px" Height="24"
                                AppendDataBoundItems="True" CssClass="txt-form-list-input">
                                <asp:ListItem Value="0">~~~ Trong tất cả ~~~</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                        </td>
                        <td>
                            <asp:ImageButton ID="btn_search" runat="server" OnClick="btn_search_Click" ImageUrl="~/images/Admin_Theme/images/btn_Search.gif" />
                        </td>
                    </tr>
                </table>
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
                <asp:GridView ID="grvOfficial" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="gridviewBorder" OnPageIndexChanging="grvOfficial_PageIndexChanging"
                    OnRowCommand="grvOfficial_RowCommand" OnRowDataBound="grvOfficial_RowDataBound"
                    Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="OfficialID" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Height="22px" HorizontalAlign="Center" Width="20px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="#">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkId" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="NoCode" HeaderText="Số/k&#253; hiệu">
                            <ItemStyle HorizontalAlign="Justify" />
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="OfficialID" DataNavigateUrlFormatString="~/Admin/listofficialfiles/{0}/Default.aspx"
                            DataTextField="OfficialName" HeaderText="Tên văn bản">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:BoundField HeaderText="Cơ quan ban hành" DataField="Company">
                            <HeaderStyle Height="22px" HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Loại văn bản" DataField="Classify">
                            <HeaderStyle Height="22px" HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Người k&#253;" DataField="Writer">
                            <HeaderStyle Height="22px" HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:CheckBoxField DataField="IsApproval" HeaderText="Ph&#234; duyệt">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="35px" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="Status" HeaderText="Ph&#225;t h&#224;nh">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="35px" />
                        </asp:CheckBoxField>
                        <asp:TemplateField HeaderText="Files">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_files" runat="server" CommandArgument='<%# Eval("OfficialID") %>'
                                    CommandName="_addfiles" ImageUrl="~/images/Admin_Theme/images/btn_files.png" />&nbsp;
                                <asp:ImageButton ID="btn_listfiles" runat="server" CommandArgument='<%# Eval("OfficialID") %>'
                                    CommandName="_listfiles" ImageUrl="~/images/Admin_Theme/images/btn_listfile.png" />&nbsp;
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_view" runat="server" CommandName="_view" CommandArgument='<%# Eval("OfficialID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_view.png" />&nbsp;
                                <asp:ImageButton ID="btn_edit" runat="server" CommandArgument='<%# Eval("OfficialID") %>'
                                    CommandName="_edit" ImageUrl="~/images/Admin_Theme/images/btn_edit.png" />&nbsp;
                                <asp:ImageButton ID="btn_delete" runat="server" CommandArgument='<%# Eval("OfficialID") %>'
                                    CommandName="_delete" ImageUrl="~/images/Admin_Theme/images/btn_delete.png" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" CssClass="pagination-ys" />
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
