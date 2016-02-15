<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeSlideImage.ascx.cs" Inherits="Fomusa.Client.Modules.MainHome.MainHomeSlideImage" %>
<%@ Register Assembly="RadRotator.Net2" Namespace="Telerik.WebControls" TagPrefix="radR" %>
<div class="main_homepage">
    <div class="cattitle">
        <div class="cattitle1">
            <div class="cattitle2">
                <div class="cattitlebg">
                    <img src="<%= ResolveUrl("~/") %>images/icon_albums.png" class="block_icon" style="display:none;" />
                    <span class="block_text_title">Hình ảnh công ty</span>
                </div>
            </div>
        </div>
    </div>
    <div class="cat_main_bg">
        <radR:RadRotator ID="RadRotator1" runat="server" Width="800" Height="140px" FramesToShow="5"
            CssClass="horizontalRotator" ScrollDuration="2000" FrameDuration="2000" ItemHeight="144"
            TransitionType="Scroll" AutoAdvance="true" ScrollDirection="Right">
            <FrameTemplate>
                <div class="itemTemplate">
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%# Eval("LinkUrl")%>'
                        Target="_blank">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Upload/Link/" + Eval("LinkImage")%>'
                            CssClass="adv_img" Width='<%# UnitNum(Eval("LinkWidth")) %>' Height='<%# UnitNum(Eval("LinkHeight")) %>' /></asp:HyperLink>
                </div>
            </FrameTemplate>
        </radR:RadRotator>
    </div>
    <div class="cat_main_bottom">
    </div>
</div>