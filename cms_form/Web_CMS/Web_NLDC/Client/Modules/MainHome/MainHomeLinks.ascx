<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeLinks.ascx.cs"
    Inherits="Web_NLDC.Client.Modules.MainHome.MainHomeLinks" %>
<div class="container">
    <div class="row links news-title">
        <h3>
            Link liên kết
        </h3>
    </div>
    <div class="row links-content">
        <asp:Repeater ID="rptLinks" runat="server">
            <ItemTemplate>
                <div class="col-md-4 links-item">
                    <h3>
                        <a href="<%# Eval("MenuLinksUrl") %>" target="<%# Eval("Target") %>">
                            <img src="ImageHandler.aspx?image=Admin/Upload/MenuLinks/<%# Eval("MenuLinksIcon") %>" width="28" height="28" alt="<%# Eval("MenuLinksName") %>" />
                            <span><%# Eval("MenuLinksName")%></span> </a>
                    </h3>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
