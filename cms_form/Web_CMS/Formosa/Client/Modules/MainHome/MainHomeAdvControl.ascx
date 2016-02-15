<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeAdvControl.ascx.cs" Inherits="Fomusa.Client.Modules.MainHomeAdvControl" %>
<%@ Register Assembly="RadRotator.Net2" Namespace="Telerik.WebControls" TagPrefix="radR" %>
<div class="block_panel">
    <div class="block_top">
        <img src="<%= ResolveUrl("~/") %>images/icon_contact.png" class="block_icon" />
        <span class="block_text_title">Đối tác</span>
    </div>
    <div class="block_bg">
        <div class="block_body">
            <radR:RadRotator ID="RadRotator1" runat="server" Width="175px" Height="500px" FramesToShow="5"
                CssClass="horizontalRotator" ScrollDuration="2000" FrameDuration="2000" ItemHeight="110"
                TransitionType="Scroll" AutoAdvance="true" ScrollDirection="Down">
                <FrameTemplate>
                    <div class="itemTemplate">
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%# Eval("LinkUrl")%>'
                            Target="_blank">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Upload/Link/" + Eval("LinkImage")%>'
                                CssClass="adv_img" Width="144px" Height="90px" /></asp:HyperLink>
                    </div>
                </FrameTemplate>
            </radR:RadRotator>
        </div>
    </div>
    <div class="block_bottom">
    </div>
</div>