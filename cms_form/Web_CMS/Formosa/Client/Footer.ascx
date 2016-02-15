<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Fomusa.Client.Footer" %>
<div class="footer_line">
    <asp:Literal ID="footerMenuItem" runat="server"></asp:Literal></div>
<div id="footer_container">
    <asp:Literal ID="ltlFooter" runat="server"></asp:Literal>
    <div style="text-align: left; font: Arial 12px bold;">
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/Login.aspx" CssClass="detail_announce">
            <asp:Label ID="lblLogin" runat="server" Text="<%$ Resources: resource, management%>"
                CssClass="block_text_title" Visible="false" />
        </asp:HyperLink>
    </div>
</div>