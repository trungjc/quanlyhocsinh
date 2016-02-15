<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomePartners.ascx.cs"
    Inherits="Web_NLDC.Client.Modules.MainHome.MainHomePartners" %>
<div class="container">
    <div class="row links news-title">
        <h3>
            <a href="#">Đối tác</a>
        </h3>
    </div>
    <div class="row partners">
        <asp:Repeater ID="cdcatalog" runat="server">
            <ItemTemplate>
                <div class="col-md-2">
                    <a href="<%# Eval("LinkUrl") %>">
                        <img src="<%# Eval("LinkImage") %>" alt="không ảnh" /></a></div>
            </ItemTemplate>
        </asp:Repeater>
       <%-- <div class="col-md-2">
            <a href="#">
                <img src="/Styles/img/logo1.jpg" alt="không ảnh" /></a></div>
        <div class="col-md-2">
            <a href="#">
                <img src="/Styles/img/logo2.jpg" alt="không ảnh" /></a></div>
        <div class="col-md-2">
            <a href="#">
                <img src="/Styles/img/logo3.jpg" alt="không ảnh" /></a></div>
        <div class="col-md-2">
            <a href="#">
                <img src="/Styles/img/logo4.jpg" alt="không ảnh" /></a></div>
        <div class="col-md-2">
            <a href="#">
                <img src="/Styles/img/logo5.jpg" alt="không ảnh" /></a></div>
        <div class="col-md-2">
            <a href="#">
                <img src="/Styles/img/logo6.jpg" alt="không ảnh" /></a></div>--%>
    </div>
</div>
