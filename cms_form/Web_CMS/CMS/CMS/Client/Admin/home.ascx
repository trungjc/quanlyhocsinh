<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="home.ascx.cs" Inherits="CMS.Client.Admin.home" %>
<div class="headerText">
    <span class="MainNavLink">Trang chủ/</span> <span class="subNavLink">Quản trị hệ thống</span>
</div>
<div class="container_ListProduct">
    <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
        <ItemTemplate>
            <div class="main_title_catenews">
                <%#Eval("Modules_Name")%></div>
            <div class="main_linecate">
            </div>
            <div style="margin: 10px 10px 10px 10px; padding-top: 10px;">
                <div id="cpanel">
                    <asp:DataList ID="DataList2" runat="server" RepeatColumns="7" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <div style="float: left;">
                                <div class="icon_admin">
                                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%# "~/Admin/" + Eval("Modules_Url") +"/Default.aspx"%>'
                                        ToolTip='<%# Eval("Modules_Name")%>'>
                                        <img src='ImageHandler.aspx?image=Upload/Admin_Theme/Icons/<%# Eval("Modules_Icon") %>' width="55px" alt="" />
                                        <br />
                                        <span>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Modules_Name")%>'></asp:Label>
                                        </span>
                                    </asp:HyperLink>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>
