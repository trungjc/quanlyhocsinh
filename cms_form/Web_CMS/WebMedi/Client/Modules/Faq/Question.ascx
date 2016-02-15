<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Question.ascx.cs" Inherits="WebMedi.Client.Modules.Faq.Question" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<div class="col-md-9" style="padding-right: 40px;">
    <div class="row navigater">
        <asp:Image ID="Image2" ImageUrl="~/Img/questions.png" runat="server" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server" Text="Phần đặt câu hỏi"></asp:Literal></span>
    </div>
    <div class="row">
        <asp:Literal ID="LiteralContact" runat="server"></asp:Literal>
        <asp:Literal ID="clientview" runat="server"></asp:Literal>
    </div>
    <div role="alert" class="row alert alert-success">
        <asp:Label ID="lblSucess" runat="server" Visible="false"></asp:Label>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="col-md-3">
            Họ tên
        </div>
        <div class="col-md-9">
            <input type="text" name="txt_TennguoiDung" id="txt_TennguoiDung" runat="server" class="form-control" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_TennguoiDung"
                ErrorMessage="RequiredFieldValidator" ForeColor="Red">Bạn chưa nhập họ tên</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="col-md-3">
            Email
        </div>
        <div class="col-md-9">
            <input type="text" name="txt_Email" id="txt_Email" runat="server" class="form-control" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Email"
                ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ForeColor="Red">Email không đúng</asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="col-md-3">
            Nội dung
        </div>
        <div class="col-md-9">
            <textarea class="form-control" name="ttr_NoiDung" id="ttr_NoiDung" rows="5" runat="server"></textarea>
        </div>
    </div>
    <%--xử lý captchar--%>
    <div class="row" style="margin-top: 5px;">
        <div class="col-sm-3">
            Nhập mã captcha</div>
        <div class="col-sm-3">
            <asp:TextBox ID="txtCapcha" Visible="true" placeholder="Mã bảo mật" class="form-control"
                runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-3">
            <cc1:CaptchaControl ID="ccJoin" runat="server" />
        </div>
        <div class="col-sm-3">
            <asp:LinkButton ID="LinkButton1" runat="server" Visible="true" OnClick="LinkButton1_Click">Chọn mã khác</asp:LinkButton></div>
    </div>
    <div id="ErrorMess" runat="server" class="row nNote nFailure" align="center" style="margin-top: 5px;">
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </div>
    <%------------------%>
    <div class="row" style="margin-top: 5px;">
        <div class="row" align="center">
            <asp:Button ID="ImageButton1" runat="server" Text="<%$ Resources:Resource, Send %>"
                OnClick="ImageButton1_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btn_reset" runat="server" Text="<%$ Resources:Resource, Refresh%>"
                OnClick="btn_reset_Click" CssClass="btn btn-primary" />
            <%--<asp:Button ID="btn_reset" runat="server" Text="<%$ Resources:Resource, Refresh%>"
                OnClick="btn_reset_Click" CssClass="btn btn-primary"/>--%>
            <%-- &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/btn_send.png"
                OnClick="ImageButton1_Click" />&nbsp;
            <asp:ImageButton ID="btn_reset" runat="server" ImageUrl="~/images/btn_reset.png"
                OnClick="btn_reset_Click" />--%>
        </div>
    </div>
    <div class="row" style="border-bottom: 2px solid #018a44; margin-top:10px;"></div>
</div>
