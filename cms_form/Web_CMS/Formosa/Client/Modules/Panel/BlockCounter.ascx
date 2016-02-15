<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockCounter.ascx.cs" Inherits="Fomusa.Client.Modules.Panel.BlockCounter" %>
<div class="block_panel">
    <div class="block_top">
        <img src="<%= ResolveUrl("~/") %>images/block_hitcounter.png" class="block_icon" />
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources: resource, Statistics%>"
            CssClass="block_text_title" />
    </div>
    <div class="block_bg">
        <div class="block_body">
            <div style="text-align: left">
                <span style="color: #0c4b92; font-size: 12px;">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources: resource, Counter%>" CssClass="block_text_title" /></span>
                <span style="color: Red; font-size: 13px;"><strong>
                    <asp:Literal ID="LiteralHitCounter" runat="server"></asp:Literal></strong></span>
                <br />
                <br />
                <span style="color: #0c4b92; font-size: 12px;"><asp:Label ID="Label3" runat="server" Text="<%$ Resources: resource, Browsing_Users%>" CssClass="block_text_title" /> </span>
                
                <span style="color: Red;
                    font-size: 13px;"><strong>
                        <asp:Literal ID="Literal1" runat="server">
                        </asp:Literal>
                    </strong></span>
            </div>
        </div>
    </div>
    <div class="block_bottom">
    </div>
</div>