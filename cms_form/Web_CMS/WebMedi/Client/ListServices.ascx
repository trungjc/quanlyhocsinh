<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListServices.ascx.cs"
    Inherits="WebMedi.Client.ListServices" %>
<div class="row jcarousel-wrapper">
    <div class="jcarousel">
        <ul>
            <asp:Repeater runat="server" ID="rptService">
                <ItemTemplate>
                    <li><a href="#">
                        <img src="<%# ResolveUrl("~/Admin/Upload/Category/") + Eval("Image") %>" alt='<%# Eval("CateNewsName") %>'
                            width="100%"><div align="center">
                                <%# Eval("CateNewsName") %></div>
                    </a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <a href="#" class="jcarousel-control-prev">&lsaquo;</a> <a href="#" class="jcarousel-control-next">
        &rsaquo;</a>
</div>
