<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuFooter.ascx.cs" Inherits="Fomusa.Client.Modules.Menu.MenuFooter" %>
<div class="menufooter">
     <ul class="menufooter_select">
        <li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Default.aspx">
                <span><asp:Image ID="Image1" runat="server" ImageUrl="~/images/menu_bottom_icon_home.png" CssClass="menufooter_icon" /> Trang chủ</span>
            </asp:HyperLink>
        </li>
        <li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Contact/Default.aspx">
                <span><asp:Image ID="Image2" runat="server" ImageUrl="~/images/menu_bottom_icon_contact.png" CssClass="menufooter_icon" />Liên hệ</span>
            </asp:HyperLink>
        </li>
        <li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Faq/Default.aspx">
                <span><asp:Image ID="Image3" runat="server" ImageUrl="~/images/menu_bottom_icon_faq.png" CssClass="menufooter_icon" />Hỗ trợ kỹ thuật</span>
            </asp:HyperLink>
        </li>
        <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Sitemap/Default.aspx">
                <span><asp:Image ID="Image4" runat="server" ImageUrl="~/images/menu_bottom_icon_sitemap.png" CssClass="menufooter_icon" />Sơ đồ Website</span>
             </asp:HyperLink>
        </li>

    </ul>
</div>