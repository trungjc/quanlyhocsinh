<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockWebLink.ascx.cs"
    Inherits="WebMedi.Client.Modules.Panel.BlockWebLink" %>
<div class="row sidebar-content">
    <h4>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </h4>
</div>
<div class="row sidebar-body">
    <div class="dropdown">
        <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1"
            data-toggle="dropdown" aria-expanded="true" style="width:100%;">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: resource, WebLink%>"></asp:Literal> <span class="caret"></span>
        </button>
        <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1" style="width:100%;">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <li role="presentation"><a role="menuitem" tabindex="-1" href="<%# Eval("BrandUrl") %>"
                        target="_blank">
                        <%# Eval("BrandName")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
