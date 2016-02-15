<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockWebLink.ascx.cs"
    Inherits="Fomusa.Client.Modules.Panel.BlockWebLink" %>
<div class="block_panel">
    <div class="block_top">
        <img src="<%= ResolveUrl("~/") %>images/block_weblink.png" class="block_icon" />
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources: resource, Website_Links%>"
            CssClass="block_text_title" />
    </div>
    <div class="block_bg">
        <div class="block_body">
            <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" CssClass="text_combo"
                Width="125px" Height="22px"
                onchange="if(this.options[this.selectedIndex].value != '') window.open(this.options[this.selectedIndex].value,'_blank')">
                <asp:ListItem Value="default" Text="<%$ Resources: resource, Website_Links_drop%>"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="block_bottom">
    </div>
</div>
