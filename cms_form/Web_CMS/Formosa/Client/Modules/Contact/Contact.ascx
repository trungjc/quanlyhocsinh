<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact.ascx.cs" Inherits="Fomusa.Client.Modules.Contact.Contact" %>
<div class="mainContent_panel2">
    <div class="mainContent_mainTitle">
        <asp:Image ID="Image2" ImageUrl="~/images/icon_contact.png" runat="server" CssClass="icon"
            Width="32px" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server" Text="<%$ Resources: resource, register_contact%>"></asp:Literal></span>
    </div>
    <div class="main_home">
        <div style="margin: 0 10px; vertical-align: top">
            <div class="contact_text">
                <asp:Literal ID="LiteralContact" runat="server"></asp:Literal>
            </div>
            <div class="main_register_panel">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="3" class="txt-contact">
                                <tr>
                                    <td width="130" style="height: 24px;">
                                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Resource, Name %>"></asp:Literal>
                                    </td>
                                    <td style="height: 24px; text-align: left">
                                        <input type="text" name="textfield2" id="NameContact" runat="server" style="width: 325px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NameContact"
                                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 24px;">
                                        <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Resource, Company %>"></asp:Literal>
                                    </td>
                                    <td style="height: 24px; text-align: left">
                                        <input type="text" name="textfield3" id="Company" runat="server" style="width: 325px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Company"
                                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 24px;">
                                        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Resource, Address %>"></asp:Literal>
                                    </td>
                                    <td style="height: 24px; text-align: left">
                                        <input type="text" name="textfield4" id="Address" runat="server" style="width: 325px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Address"
                                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 24px;">
                                        <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:Resource, City %>"></asp:Literal>
                                    </td>
                                    <td style="height: 24px; text-align: left">
                                        <input type="text" name="textfield5" id="City" runat="server" style="width: 325px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="City"
                                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 25px;">
                                        <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:Resource, Telephone %>"></asp:Literal>
                                    </td>
                                    <td style="height: 25px; text-align: left">
                                        <input type="text" name="textfield7" id="Telephone" runat="server" style="width: 325px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Telephone"
                                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 24px;">  
                                        <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:Resource, Fax %>"></asp:Literal>
                                    </td>
                                    <td style="height: 24px; text-align: left">
                                        <input type="text" name="textfield7" id="Fax" runat="server" style="width: 325px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Fax"
                                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 24px;">
                                        <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:Resource, Email %>"></asp:Literal>
                                    </td>
                                    <td style="height: 24px; text-align: left">
                                        <input type="text" name="textfield8" id="Email" runat="server" style="width: 325px" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email"
                                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 24px;">
                                        <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:Resource, Require %>"></asp:Literal>
                                    </td>
                                    <td style="height: 24px; text-align: left">
                                        <textarea name="textarea" id="Require" rows="5" runat="server" style="width: 325px"></textarea>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td id="Td1" align="center" runat="server">
                            &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/btn_send.png"
                                OnClick="ImageButton1_Click" />&nbsp;
                            <asp:ImageButton ID="btn_reset" runat="server" ImageUrl="~/images/btn_reset.png" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>
