<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockSearch.ascx.cs" Inherits="Fomusa.Client.Modules.Panel.BlockSearch" %>
<div class="mainContent_mainTitle_search_panel">
    
    <asp:Label ID="Label2" runat="server" Text="<%$ Resources: resource, Search%>" />
    <asp:TextBox ID="txtSearch" runat="server" CssClass="search_input_panel" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
</div>