<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListMainHomeNewsSelect.ascx.cs" Inherits="CMS.Client.Admin.ListMainHomeNewsSelect" %>
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
                            </tr>
                        </tbody>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <div style="margin: 10px 10px 10px 10px; padding-top: 10px;">
        <div id="cpanel">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="7" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div style="float: left;">
                        <div class="icon_admin">
                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%# "~/Admin/Group/ListMainHomeNewsGroup/" + Eval("GroupCate") +"/Default.aspx" %>'
                                ToolTip='<%# Eval("CateNewsGroupName")%>'>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.aspx?image=Upload/Category/Group/" + Eval("Icon")%>'
                                    Width="55px" />
                                <br />
                                <span>
                                    <asp:Label ID="Label1" runat="server" Text='<%# "Quản lý "+ Eval("CateNewsGroupName")%>'></asp:Label>
                                </span>
                            </asp:HyperLink>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</div>