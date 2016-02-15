<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="404.aspx.cs" Inherits="CMS._404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHomepage" runat="server">
    <div align="center" style="margin: 40px 0;">
        <p>
            Có lỗi xảy ra, hoặc trang web bạn yêu cầu không có</p>
        <p>
            bạn click vào <a href='<%= ResolveUrl("~/") %>Homepage.aspx'>đây</a> để quay lại
            trang chủ</p>
    </div>
</asp:Content>
