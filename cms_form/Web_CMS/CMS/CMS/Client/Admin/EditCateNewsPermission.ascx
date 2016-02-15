<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCateNewsPermission.ascx.cs" Inherits="CMS.Client.Admin.EditCateNewsPermission" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right" style="height: 44px">
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listroles/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td4" style="text-align: center">
                                    <asp:HyperLink ID="btn_add" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-save.png"
                                            OnClick="btn_add_Click" />
                                        <br />
                                        Lưu lại
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
    <div class="title_User">
        Nhóm:
        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal></div>
    <div class="search_panel" style="height: 30px; text-align: center; line-height: 30px;
        vertical-align: middle;">
        <asp:Literal ID="error" runat="server"></asp:Literal>
    </div>
    <div style="width: 98%; padding-left: 10px;">        
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" PageSize="200" AllowPaging="true" GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound">
            <PagerStyle Mode="NextPrevNumericAndAdvanced" />
            <MasterTableView Width="100%">
                <GroupByExpressions>
                    <telerik:GridGroupByExpression>
                        <SelectFields>
                            <telerik:GridGroupByField FieldAlias="&#160;" FieldName="GroupCateName" HeaderValueSeparator="Nhóm danh mục: "
                            FormatString="" HeaderText="" />
                        </SelectFields>
                        <GroupByFields>
                            <telerik:GridGroupByField FieldName="GroupCate" FieldAlias="GroupCate" FormatString="" HeaderText="" />
                        </GroupByFields>
                    </telerik:GridGroupByExpression>
                </GroupByExpressions>
                <Columns>                
                    <telerik:GridBoundColumn HeaderText="CateNewsID" HeaderButtonType="TextButton"
                                DataField="CateNewsID" UniqueName="CateNewsID" Resizable="False" Visible="false">
                                <HeaderStyle Height="30px" />
                            </telerik:GridBoundColumn>
                           
                           <telerik:GridTemplateColumn HeaderText="#" UniqueName="TemplateColumn" Resizable="False">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkId" runat="server"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"  Width="31px" Height="30px" />
                           </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn SortExpression="CateNewsName" HeaderText="T&#234;n danh mục" HeaderButtonType="TextButton"
                                DataField="CateNewsName" UniqueName="CateNewsName" Resizable="False">
                                <HeaderStyle Height="30px" />
                            </telerik:GridBoundColumn>
                </Columns>
                <RowIndicatorColumn Visible="true">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn>
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
            </MasterTableView>
            <ClientSettings ReorderColumnsOnClient="true" AllowDragToGroup="true" AllowColumnsReorder="true">
                <Selecting AllowRowSelect="true" />
            </ClientSettings>
            <AlternatingItemStyle BackColor="#F8F8F8" />
                    <HeaderStyle Font-Bold="True" Height="30px" />
        </telerik:RadGrid>
    </div>
</div>
<asp:HiddenField ID="hddRoles" runat="server" />
