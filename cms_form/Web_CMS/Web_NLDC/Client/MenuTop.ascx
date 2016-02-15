<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuTop.ascx.cs" Inherits="Web_NLDC.Client.MenuTop" %>
<div class="menu">
    <div class="container menu-content">
        <div class="navbar navbar-default" role="navigation">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
            </div>
            <div class="navbar-collapse collapse">
                 <asp:Literal ID="ltrMenuFull" runat="server"></asp:Literal>
            </div>
            <!--/.nav-collapse -->
        </div>
    </div>
</div>
