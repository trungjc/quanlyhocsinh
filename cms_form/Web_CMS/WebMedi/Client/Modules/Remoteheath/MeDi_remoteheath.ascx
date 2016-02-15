<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MeDi_remoteheath.ascx.cs"
    Inherits="WebMedi.Client.Modules.Remoteheath.MeDi_remoteheath" %>
<div class="col-md-9 main-content">
    <div class="row navigater">
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server" Text="Remote Health "></asp:Literal></span>
    </div>
    <div>
        <div>
            <b>text 1:</b>
            <asp:Label runat="server" ID="lblHeader"></asp:Label>
        </div>
        <div>
            <b>text 2:</b>
            <asp:Label runat="server" ID="lblBody"></asp:Label>
        </div>
    </div>
    <div style="align: center;">
        <asp:Image ImageUrl="" ID="img" runat="server" Width="600" />
        <img runat="server" id="imgHtml" alt="" />
    </div>
</div>
