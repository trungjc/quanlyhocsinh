<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ForgetPass.ascx.cs"
    Inherits="CMS.Client.Admin.ForgetPass" %>
<div class="headerText">
    <span class="MainNavLink">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Trang chủ</asp:HyperLink>
        / </span><span class="subNavLink">Quên mật khẩu</span>
</div>
<div class="container_ListProduct">
    <div class="main_panel_homepage">
        <div class="error_register_text">
            <asp:Literal ID="labMassege" runat="server"></asp:Literal></div>
    </div>
    <div class="main_panel_homepage">
        <center>
            <asp:Label ID="Label1" runat="server" Text="Địa chỉ Email của bạn :" CssClass="register_text"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="register_form_input" Width="270"></asp:TextBox>
            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
                ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
            &nbsp;<asp:Button ID="btn_GetPass" runat="server" Text="Lấy lại mật khẩu" OnClick="btn_GetPass_Click" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Sai kiểu Email</asp:RegularExpressionValidator>
        </center>
    </div>
</div>
