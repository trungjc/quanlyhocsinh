<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockMenuLinks.ascx.cs"
    Inherits="WebMedi.Client.Modules.Panel.BlockMenuLinks" %>
<div class="row sidebar-content">
    <h4>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </h4>
</div>
<div class="row sidebar-body">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div class="col-sm-6">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("MenuLinksUrl") %>'
                    ToolTip='<%# Eval("MenuLinksName") %>' Target='<%# Eval("Target") %>'>
                    <img src='/Admin/Upload/MenuLinks/<%# Eval("MenuLinksIcon")%>' alt="" />
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
