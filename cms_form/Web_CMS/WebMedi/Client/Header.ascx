<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="WebMedi.Client.Header" %>
<div class="row header">
    <div class="col-md-6 col-xs-6 image-logo-left">
        <a href='<%= ResolveUrl("~/") %>Home'>
            <asp:Literal ID="ltrLogo" runat="server"></asp:Literal></a>
        <%-- <a href='<%= ResolveUrl("~/") %>Home'>
            <img src='<%# ResolveUrl("~/") %>/Img/logo_left.jpg' alt="" /></a>--%>
    </div>
    <div class="col-md-6 col-xs-6 pull-right contact">
        <div class="row contact-content">
            <div class="col-sm-5 col-xs-6">
            </div>
            <div class="col-sm-1 col-xs-4 logo_right">
            <img src='<%# ResolveUrl("~/") %>/Img/logo_right.jpg' alt="" />
            </div>
            <div class="col-sm-6 col-xs-9 phone pull-right">
                <asp:Literal ID="ltrCallCenter" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2 pull-right language">
                <asp:LinkButton ID="lbLang" runat="server" OnClick="lbLang_Click">
                    <asp:Image ID="imgFlag" runat="server" /></asp:LinkButton>
            </div>
        </div>
    </div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</div>
