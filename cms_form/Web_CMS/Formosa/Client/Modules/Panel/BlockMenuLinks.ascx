<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockMenuLinks.ascx.cs" Inherits="Fomusa.Client.Modules.Panel.BlockMenuLinks" %>
<div class="block_panel">
    <div class="block_top">
        <img src="<%= ResolveUrl("~/") %>images/block_menulinks.png" class="block_icon" />
         <asp:Label ID="Label2" runat="server" Text="<%$ Resources: resource, Quick_Links%>"
            CssClass="block_text_title" />
    </div>
    <div class="block_bg">
        <div class="block_body">
            <div id="cpanel_menulinks" style="text-align: center; padding-left: 3px;">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                    CellPadding="0">
                    <ItemTemplate>
                        <div style="float: left;">
                            <div class="icon_menulinks">
                                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%# Eval("MenuLinksUrl")%>'
                                    ToolTip='<%# Eval("MenuLinksName")%>' Target="_blank">
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Admin/Upload/MenuLinks/" + Eval("MenuLinksIcon")%>'
                                        Width="40px" />
                                    <br />
                                    <span>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("MenuLinksName")%>'></asp:Label></span>
                                </asp:HyperLink>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
    <div class="block_bottom">
    </div>
</div>