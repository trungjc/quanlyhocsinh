<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactSucceed.ascx.cs" Inherits="Fomusa.Client.Modules.Contact.ContactSucceed" %>
<div class="main_home">
    <div class="cattitle">
        <div class="cattitle1">
            <div class="cattitle2">
                <div class="cattitlebg">
                    <asp:Literal ID="title_name" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
        <div class="cattitle_sub">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
            <div class="clear">
            </div>
        </div>
    </div>
    <%-- Main --%>
    <div class="cat_main_bg">
        <div style="padding: 10px; vertical-align: top">
            <div class="register_succeed">
                <asp:Literal ID="ltlSucceed1" runat="server"></asp:Literal>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Default.aspx" CssClass="ulink">
                    <asp:Literal ID="ltlSucceed2" runat="server"></asp:Literal></asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="cat_main_bottom">
    </div>
</div>