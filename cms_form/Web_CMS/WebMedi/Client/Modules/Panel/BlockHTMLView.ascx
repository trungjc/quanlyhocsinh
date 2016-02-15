<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockHTMLView.ascx.cs"
    Inherits="WebMedi.Client.Modules.Panel.BlockHTMLView" %>
<div class="row sidebar-content">
    <h4>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </h4>
</div>
<div class="row sidebar-body">
    <asp:Literal ID="ltrContent" runat="server"></asp:Literal>
</div>
<asp:HiddenField ID="hddContent" runat="server" />
