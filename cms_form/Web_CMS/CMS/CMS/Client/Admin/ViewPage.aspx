<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="CMS.Client.Admin.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Administrator - SONLA</title>
    <link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="margin-left: 5px; margin-right: 5px; vertical-align: top">
            <div class="main_title_news_bold">
                <asp:Label ID="ltlTitle" runat="server" CssClass="main_title_news_bold"></asp:Label></div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 100%">
                        <asp:Literal ID="ltlImageThumb" runat="server"></asp:Literal>
                        <div class="main_desc_news">
                            <strong>
                                <asp:Literal ID="ltlDescribe" runat="server"></asp:Literal></strong></div>
                        <div class="main_desc_news">
                            <asp:Label ID="FullDescirbe" runat="server" CssClass="main_desc_news"></asp:Label></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="main_content_author">
                            <asp:Label ID="LabelAuthor" runat="server" CssClass="main_content_product1" /></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
