<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactSucceed.ascx.cs"
    Inherits="WebMedi.Client.Modules.Contact.ContactSucceed" %>
<div class="col-md-9 main-content">
    <div class="row navigater">        
        <asp:Literal ID="title_cate" runat="server"></asp:Literal>&nbsp; &gt;&nbsp;
        <asp:Literal ID="title_name" runat="server"></asp:Literal>
    </div>
    <div class="row main-category">
        <asp:Literal ID="ltlSucceed1" runat="server"></asp:Literal>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Home" CssClass="ulink">
            <asp:Literal ID="ltlSucceed2" runat="server"></asp:Literal></asp:HyperLink>
    </div>
</div>
