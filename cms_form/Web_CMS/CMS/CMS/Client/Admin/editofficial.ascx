<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editofficial.ascx.cs"
    Inherits="CMS.Client.Admin.editofficial" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right">
                <div class="toolbar" id="toolbar">
                    <table class="toolbar">
                        <tbody>
                            <tr>
                                <td id="toolbar-unarchive">
                                    <asp:HyperLink ID="btn_home" runat="server" NavigateUrl="~/Admin/home/Default.aspx"
                                        CssClass="toolbar">
                                        <span class="icon-32-home" title="Trở về trang chủ">
                                        </span>
                                        Trang chủ
                                    </asp:HyperLink>
                                </td>
                                <td id="Td2" style="text-align: center">
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listofficial/Default.aspx">
                                        <span class="icon-32-menus" title="Danh mục">
                                        </span>
                                        Danh mục
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editofficial/Default.aspx">
                                        <span class="icon-32-publish" title="Đăng tin mới">
                                        </span>
                                        Tạo mới
                                    </asp:HyperLink>
                                </td>
                                <td id="Td4" style="text-align: center">
                                    <asp:HyperLink ID="btn_add" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-save.png"
                                            OnClick="btn_add_Click" />
                                        <br />
                                        Lưu lại
                                    </asp:HyperLink>
                                </td>
                                <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="btn_edit" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"
                                            OnClick="btn_edit_Click" />
                                        <br />
                                        Cập nhật
                                    </asp:HyperLink>
                                </td>
                                <td id="Td6">
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/home/Default.aspx"
                                        CssClass="toolbar">
                                        <span class="icon-32-help" title="Trợ giúp">
                                        </span>
                                        Trợ giúp
                                    </asp:HyperLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="2" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="5">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="150" class="txt-from-taomoi">
                            <asp:Label ID="Label4" runat="server" Text="Danh mục văn bản :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCateNews" runat="server" Width="300px" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label9" runat="server" Font-Bold="true" Text="Số hiệu"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNoCode" runat="server" Width="294px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoCode"
                                ErrorMessage="giá trị bắt buộc"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label11" runat="server" Text="Tên văn bản :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOfficialName" runat="server" Height="50px" TextMode="MultiLine"
                                Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOfficialName"
                                ErrorMessage="giá trị bắt buộc"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label12" runat="server" Text="Cơ quan ban hành"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompany" runat="server" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCompany"
                                ErrorMessage="bắt buộc"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label1" runat="server" Text="Loại văn bản :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtClassify" runat="server" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCompany"
                                ErrorMessage="bắt buộc"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label2" runat="server" Text="Trích yếu :"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="txtQuote" SkinID="BasicTools" ToolsFile="~/RadControls/Editor/BasicTools.xml"
                                Height="200px" Width="600px" EditModes="Design, Html">
                                <Content>
                            
                            
                            
                                </Content>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label10" runat="server" Text="Từ khóa :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtKeyShort" runat="server" TextMode="MultiLine" Width="500px" Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label3" runat="server" Text="File đính kèm :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Lưu lại bản ghi, và chọn mục attach File ở danh mục văn bản"></asp:Label>
                        </td>
                        <%--<asp:FileUpload ID="file_attached" runat="server" Width="350px" />--%>
                    </tr>
                </table>
            </td>
            <td width="285" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="5" class="bg-line-cham">
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label6" runat="server" Text="Ngày phát hành :"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="txtRadDate" runat="server" Width="150px" Culture="Vietnamese (Vietnam)">
                                <DateInput Width="80">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label7" runat="server" Text="Người ký :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAuthor" runat="server" Width="140px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi" style="height: 45px" valign="top">
                            <asp:Label ID="Label8" runat="server" Text="Trạng thái :"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="True">Hiệu lực</asp:ListItem>
                                <asp:ListItem Value="False">Tạm ngưng</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hddOfficialID" runat="server" />
    <asp:HiddenField ID="hddfile_attached" runat="server" />
