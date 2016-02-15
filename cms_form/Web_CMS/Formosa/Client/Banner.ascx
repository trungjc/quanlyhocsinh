<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Banner.ascx.cs" Inherits="Fomusa.Client.Banner" %>
<%@ Register Src="~/Client/Modules/Menu/MenuBarTabJquery.ascx" TagName="MenuBarNews"
    TagPrefix="panelMenuBarNews" %>
<div id="banner">
    <div id="menutop">
        <ul class="MenuBarTop">
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/House.png" CssClass="icon" /><asp:Label
                        ID="Label1" runat="server"  Text="<%$ Resources: resource, Home%>" />
                </asp:HyperLink></li><li>
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Faq/Default.aspx">
                        <asp:Image ID="Image6" runat="server" ImageUrl="~/images/FAQ.png" CssClass="icon" /><asp:Label
                            ID="Label5" runat="server" Text="<%$ Resources: resource, Faq%>" />
                    </asp:HyperLink></li><li>
                        <%-- <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/LichTuan.aspx">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/menutop_webmail.png" CssClass="icon" /><asp:Label
                                ID="Label3" runat="server" Text="Lịch tuần" />
                        </asp:HyperLink></li><li>--%>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Contact/Default.aspx">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/images/Contact.png" CssClass="icon" /><asp:Label
                                ID="Label4" runat="server" Text="<%$ Resources: resource, register_contact%>" />
                        </asp:HyperLink></li><li>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Sitemap/Default.aspx">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Sitemap.png" CssClass="icon" /><asp:Label
                                    ID="Label2" runat="server" Text="<%$ Resources: resource, Sitemap%>" />
                            </asp:HyperLink></li><%-- <li>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/Index.html">
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/images/menutop_login.png" CssClass="icon" /><asp:Label ID="lblLogin" runat="server" Text="Đăng nhập" />
                </asp:HyperLink>
           </li>--%><%--<li>
                <asp:Image ID="Image5" runat="server" ImageUrl="~/images/menutop_login1.png" CssClass="icon" />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1" CssClass="icon_title">Đăng nhập</asp:LinkButton></li>--%></ul>
        <div id="lang-flag">
            <asp:ImageButton runat="server" ID="imgBtnLang" AlternateText="Tiếng Việt" ImageUrl="~/images/flag_vi.png"
                OnClick="imgBtnLang_Click" />&nbsp;&nbsp;<asp:ImageButton runat="server" ID="ImageButton1" AlternateText="English"
                    ImageUrl="~/images/flag_en.png" OnClick="ImageButton1_Click" /></div>
    </div>
</div>
<script language="javascript" type="text/javascript">
    function Confirm() {
        if (confirm != true)
            return false;
    }
    function Redirect() {
        RedirectUrl("http://www.google.com");
    }
</script>
