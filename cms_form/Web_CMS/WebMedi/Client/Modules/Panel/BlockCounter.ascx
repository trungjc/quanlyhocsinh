<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockCounter.ascx.cs"
    Inherits="WebMedi.Client.Modules.Panel.BlockCounter" %>
<div class="row sidebar-content">
    <h4>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </h4>
</div>
<div class="row sidebar-body">
    <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="#082daf" Text="<%$ Resources: resource, Counter%>"></asp:Label> :
    <span style="color: #018a44;">
        <asp:Literal ID="LiteralHitCounter" runat="server"></asp:Literal></span>
    <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="#082daf" Text="<%$ Resources: resource, Browsing_Users%>"></asp:Label> :
    <span style="color: #018a44;">
        <asp:Literal ID="LiteralOnline" runat="server"></asp:Literal></span>
</div>
