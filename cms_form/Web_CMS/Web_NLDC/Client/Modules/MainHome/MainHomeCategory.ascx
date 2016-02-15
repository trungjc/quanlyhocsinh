<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeCategory.ascx.cs"
    Inherits="Web_NLDC.Client.Modules.MainHome.MainHomeCategory" %>
<div class="container">
    <div class="row categories">
        <div class="col-md-8">
            <div class="row">
                <asp:PlaceHolder ID="AreaMainHome" runat="server"></asp:PlaceHolder>
            </div>
        </div>
        <div class="col-md-4 categories-mangluoi">
            <div class="row categories-title">
                <h4>
                    Mạng lưới</h4>
            </div>
            <div>
                <div class="row">
                    <div id="dvMap" style="width: 100%; padding: 0px !important;">
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hdfPanelId" runat="server" />
