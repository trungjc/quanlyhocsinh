<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Medi_TraCuu.ascx.cs"
    Inherits="WebMedi.Client.Modules.DangKy_TraCuu.Medi_TraCuu" %>
<style type="text/css">
    .remove-padding
    {
        padding-left: 0px;
        padding-right: 0px;
        line-height: 36px;
    }
    .chucnang
    {
        margin-top: 10px;
    }
</style>
<div class="col-md-9 main-content">
    <div class="row navigater">
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server" Text="<%$ Resources: resource, register_contact%>"></asp:Literal></span>
    </div>
    <div class="row" align="center">
        <h4>
            Tra cứu xét nghiệm online</h4>
    </div>
    <div class="row main-category">
        <asp:Label ID="Label1" runat="server" ForeColor="Blue">Chào mừng quý khách đến với dịch vụ tra cứu xét nghiệm online của trung tâm</asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server">Để tra cứu kết quả quý khách vui lòng nhập đầy đủ thông tin mã phiếu và mã pin vào các ô bên dưới.
        Nếu không nhớ thông tin về mã phiếu và mã pin khách hàng có thể vào Email đã cung cấp cho hệ thống để lấy lại thông tin hoặc gọi 
        điện tới số hotline: 043 6654 132 để nhận tư vấn.
         <br /><i>Cảm ơn quý khách đã sử dụng dịch vụ.</i></asp:Label>
    </div>
    <div class="row">
        <asp:Label runat="server" ID="lblThongBao"></asp:Label>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-5 remove-padding">
                    Nhập mã phiếu <b style="color: Red;">(*)</b>
                </div>
                <div class="col-md-7">
                    <asp:TextBox ID="txt_MaPhieu" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-5 remove-padding">
                    Nhập mã pin<b style="color: Red;">(*)</b>
                </div>
                <div class="col-md-7">
                    <asp:TextBox ID="txt_MaPin" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row chucnang" align="center">
        <asp:Button ID="btnTraCuu" class="btn btn-primary" runat="server" Text="Tra cứu"
            OnClick="btnTraCuu_Click" />
        <asp:Button ID="btnQuayLai" class="btn btn-primary" runat="server" Text="Nhập lại"
            OnClick="btnQuayLai_Click" />
    </div>
    <div class="row">
    <asp:Panel runat="server" ID="pn_KQXN" Visible="false">
        <div align="center" style="padding:15px 0;">
            <b>Kết quả xét nghiệm</b></div>
        <iframe src="../../../Admin/<%= this.InputValue %>" width="100%" height="800px"></iframe>
    </asp:Panel>
    </div>
</div>
