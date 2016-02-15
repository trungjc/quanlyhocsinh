<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditAdminAddRoles.ascx.cs" Inherits="CMS.Client.Admin.EditAdminAddRoles" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~//Admin/listadmin/Default.aspx">
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
        <telerik:radgrid id="RadGrid1" runat="server" pagesize="200" allowpaging="True" gridlines="None"
            autogeneratecolumns="False" style="border: 1; outline: none;" 
            onitemdatabound="RadGrid1_ItemDataBound">
                    <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                    <MasterTableView Width="100%" DataKeyNames="Roles_ID">
                       
                        <Columns>
                            
                           <telerik:GridBoundColumn HeaderText="rID" HeaderButtonType="TextButton"
                                DataField="Roles_ID" UniqueName="Roles_ID" Resizable="False" Visible="false">
                                <HeaderStyle Height="30px" />
                            </telerik:GridBoundColumn>
                           
                           <telerik:GridTemplateColumn HeaderText="#" UniqueName="TemplateColumn" Resizable="False">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkId" runat="server"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"  Width="31px" Height="30px" />
                           </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn SortExpression="Roles_Name" HeaderText="Tên nhóm quyền" HeaderButtonType="TextButton"
                                DataField="Roles_Name" UniqueName="Roles_Name" Resizable="False">
                                <HeaderStyle Height="30px" />
                            </telerik:GridBoundColumn>
                           
                          <%-- <telerik:GridTemplateColumn HeaderText="Quyền truy cập" UniqueName="TemplateColumn1" Resizable="False">
                                <ItemTemplate>
                                    <asp:CheckBoxList ID="chklist" runat="server" RepeatDirection="Horizontal" EnableTheming="False">
                                    </asp:CheckBoxList>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"  Width="310px" Height="30px" />
                           </telerik:GridTemplateColumn>--%>
                            
                        </Columns>
                        <RowIndicatorColumn Visible="True">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                       
   
     
                    </MasterTableView>
                    <ClientSettings ReorderColumnsOnClient="True" AllowDragToGroup="True" AllowColumnsReorder="True">
                        <Selecting AllowRowSelect="True"></Selecting>
                        <Resizing AllowRowResize="True" AllowColumnResize="True" EnableRealTimeResize="True"></Resizing>
                    </ClientSettings>
                    <HeaderContextMenu EnableTheming="True">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                    </HeaderContextMenu>
                    <FilterMenu EnableTheming="True">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                    </FilterMenu>
                    <AlternatingItemStyle BackColor="#F8F8F8" />
                    <HeaderStyle Font-Bold="True" Height="30px" />
                    
                </telerik:radgrid>
    </div>
</div>
<asp:HiddenField ID="hddUserName" runat="server" />