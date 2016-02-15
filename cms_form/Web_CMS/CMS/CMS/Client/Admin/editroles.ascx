<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editroles.ascx.cs" Inherits="CMS.Client.Admin.editroles" %>
<div class="headerText">
	<asp:Image ID="imgIcon" runat="server" CssClass="icon_image"/>
    <span class="subNavLink"><asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    
                    <td align="right">
                        <div class="toolbar" id="toolbar">
                                <table class="toolbar"><tbody><tr>
                                    <td  id="toolbar-unarchive">
                                        <asp:HyperLink ID="btn_home" runat="server" NavigateUrl="~/Admin/home/Default.aspx" CssClass="toolbar">
                                            <span class="icon-32-home" title="Trở về trang chủ">
                                            </span>
                                            Trang chủ
                                        </asp:HyperLink>
                                    </td>
                                    
                                   
                                    
                                     <td  id="Td2" style="text-align:center">
                                      <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listroles/Default.aspx">
                                            <span class="icon-32-menus" title="Danh mục">
                                            </span>
                                            Danh mục
                                        </asp:HyperLink>
                			            
                                    </td>
                	                
	                                <td  id="Td1" style="text-align:center">
                                      <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editroles/Default.aspx">
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
                                    
                                    <td  id="Td6">
                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/home/Default.aspx" CssClass="toolbar">
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

<table width="100%" border="0" cellspacing="0" cellpadding="5" >
    <tr>
        <td align="center" colspan="2">
            <asp:Literal ID="error" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td width="140" class="txt-from-taomoi">
            <asp:Label ID="Label1" runat="server" Text="Tên nhóm quyền "></asp:Label></td>
        <td >
            <asp:TextBox ID="txtRolesName" runat="server" Width="270" ></asp:TextBox>
            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRolesName"
                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>

        <td class="txt-from-taomoi" style="height: 20px">
            <asp:Label ID="Label2" runat="server" Text="Lựa chọn modules"></asp:Label></td>
        <td style="height: 20px">
        </td>
    </tr>
    <tr>

        <td class="txt-from-taomoi">
            &nbsp;</td>
        <td>
            <asp:CheckBoxList ID="chklist" runat="server">
            </asp:CheckBoxList>
        </td>
    </tr>

</table>
</div>
<asp:HiddenField ID="hddRoles_ID" runat="server" />