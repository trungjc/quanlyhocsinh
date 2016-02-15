<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BannerIntro.ascx.cs" Inherits="Fomusa.Client.BannerIntro" %>
<div class="intro">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"> 
    <asp:Literal ID="ltlIntro" runat="server"></asp:Literal>
    </asp:HyperLink>
</div>