<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact.ascx.cs" Inherits="WebMedi.Client.Modules.Contact.Contact" %>
<div class="col-md-9 main-content">
    <div class="row navigater">
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server" Text="<%$ Resources: resource, register_contact%>"></asp:Literal></span>
    </div>
    <div class="row main-category">
        <asp:Literal ID="LiteralContact" runat="server"></asp:Literal>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="col-sm-3">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Resource, Name %>"></asp:Literal>
        </div>
        <div class="col-sm-8">
            <input type="text" name="textfield2" id="NameContact" runat="server" class="form-control" />
        </div>
        <div class="col-sm-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NameContact"
                ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="send">Bạn ch</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="col-sm-3">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Resource, Company %>"></asp:Literal>
        </div>
        <div class="col-sm-8">
            <input type="text" name="textfield3" id="Company" runat="server" class="form-control" />
        </div>
        <div class="col-sm-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Company"
                ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="send">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="col-sm-3">
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Resource, Address %>"></asp:Literal>
        </div>
        <div class="col-sm-8">
            <input type="text" name="textfield4" id="Address" runat="server" class="form-control" />
        </div>
        <div class="col-sm-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Address"
                ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="send">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="col-sm-3">
            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:Resource, City %>"></asp:Literal>
        </div>
        <div class="col-sm-8">
            <input type="text" name="textfield5" id="City" runat="server" class="form-control" />
        </div>
        <div class="col-sm-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="City"
                ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="send">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="col-sm-3">
            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:Resource, Telephone %>"></asp:Literal>
        </div>
        <div class="col-sm-8">
            <input type="text" name="textfield7" id="Telephone" runat="server" class="form-control" />
        </div>
        <div class="col-sm-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Telephone"
                ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="send">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="col-sm-3">
            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:Resource, Fax %>"></asp:Literal>
        </div>
        <div class="col-sm-8">
            <input type="text" name="textfield7" id="Fax" runat="server" class="form-control" />
        </div>
        <div class="col-sm-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Fax"
                ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="send">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="col-sm-3">
            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:Resource, Email %>"></asp:Literal>
        </div>
        <div class="col-sm-8">
            <input type="text" name="textfield8" id="Email" runat="server" class="form-control" />
        </div>
        <div class="col-sm-1">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email"
                ErrorMessage="RegularExpressionValidator" ValidationGroup="send" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red">*</asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="col-sm-3">
            <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:Resource, Require %>"></asp:Literal>
        </div>
        <div class="col-sm-8">
            <textarea name="textarea" id="Require" rows="5" runat="server" class="form-control"></textarea>
        </div>
        <div class="col-sm-1">
        </div>
    </div>
    <div class="row" style="margin-top: 5px;">
        <div class="row" align="center">
            <asp:Button ID="btnSend" runat="server" Text="<%$ Resources:Resource, Send %>" CssClass="btn btn-primary"
                OnClick="btnSend_Click" ValidationGroup="send" />
            &nbsp;
            <asp:Button ID="btn_reset" runat="server" Text="<%$ Resources:Resource, Reset %>"
                CssClass="btn btn-primary" />
        </div>
    </div>
</div>
