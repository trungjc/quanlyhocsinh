<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeListUseJCarousel.ascx.cs"
    Inherits="WebMedi.Client.Modules.MainHome.MainHomeListUseJCarousel" %>
<div class="jcarousel-wrapper">
    <div class="jcarousel">
        <ul>
            <asp:Repeater runat="server" ID="rptService">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/CateNewsg/" + Eval("GroupCate") + "/" + Eval("CateNewsId") + "/services/default.aspx" %>'>
                        <img src="<%# ResolveUrl("~/Admin/Upload/Category/") + Eval("Image") %>" alt='<%# Eval("CateNewsName") %>'
                            width="100%"><div align="center">
                                <%# Eval("CateNewsName") %></div>
                        </asp:HyperLink></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <a href="#" class="jcarousel-control-prev">&lsaquo;</a> <a href="#" class="jcarousel-control-next">
        &rsaquo;</a>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
