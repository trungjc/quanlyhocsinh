<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditPhoneBook.ascx.cs" Inherits="CMS.Client.Admin.EditPhoneBook" %>
<link href="~\RadControls\Editor\Skins\Default\Editor.css" rel="stylesheet"
    type="text/css" />

<div class="headerText">
	<asp:Image ID="imgIcon" runat="server" CssClass="icon_image"/>
    <span class="subNavLink"><asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        
         <td align="right" >
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
                                      <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listphonebook/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                        </asp:HyperLink>
                			            
		                            </td>
            		                
            		                <td  id="Td1" style="text-align:center">
                                      <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editphonebook/Default.aspx">
			                                <span class="icon-32-publish" title="Đăng tin mới">
			                                </span>
			                                Tạo mới
                                        </asp:HyperLink>
                			            
		                            </td>
		                            
		                             <td id="Td4" style="text-align: center">
                                        <asp:HyperLink ID="btn_add" runat="server" CssClass="toolbar">
                                            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-save.png"
                                              OnClick="btn_add_Click"   />
                                            <br />
                                            Lưu lại
                                        </asp:HyperLink>
                                    </td>
                                    
		                            <td id="Td3" style="text-align: center">
                                        <asp:HyperLink ID="btn_edit" runat="server" CssClass="toolbar">
                                            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"  
                                              OnClick="btn_edit_Click"  />
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

    <div class="search_panel" style="text-align:center;vertical-align:middle;">
            
			    <asp:Literal ID="clientview" runat="server"></asp:Literal>
	</div>
	 <table width="100%" border="0" cellspacing="0" cellpadding="6">
        <tr>
           <td class="txt-from-taomoi" width="70%">   	
                <table width="100%" border="0" cellpadding="5" cellspacing="0">

                  <tr>

                    <td width="140" class="txt-from-taomoi" ><asp:Label ID="Label1" runat="server" Text="Phòng ban :"></asp:Label></td>
                    <td ><asp:DropDownList ID="ddlDepartment" runat="server" Width="300px" AppendDataBoundItems="True">
                    </asp:DropDownList></td>
                  </tr>
                  <tr>
                   
                    <td class="txt-from-taomoi" ><asp:Label ID="Label2" runat="server" Text="Họ và tên :"></asp:Label></td>
                    <td><asp:TextBox ID="txtFullName" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName"
                        ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                  </tr>
                 
                   <tr>
                   
                    <td class="txt-from-taomoi" ><asp:Label ID="Label3" runat="server" Text="Phone 1 :"></asp:Label></td>
                    <td><asp:TextBox ID="txtPhone1" runat="server" Width="300px"></asp:TextBox>
                    </td>
                  </tr>
                   <tr>
                   
                    <td class="txt-from-taomoi" ><asp:Label ID="Label4" runat="server" Text="Phone 2 :"></asp:Label></td>
                    <td><asp:TextBox ID="txtPhone2" runat="server" Width="300px"></asp:TextBox>
                    </td>
                  </tr>
                   <tr>
                   
                    <td class="txt-from-taomoi" ><asp:Label ID="Label7" runat="server" Text="Điện Thoại Nhà:"></asp:Label></td>
                    <td><asp:TextBox ID="txtHomePhone" runat="server" Width="300px"></asp:TextBox>
                    </td>
                  </tr>
                  
                   <tr>
                   
                    <td class="txt-from-taomoi" ><asp:Label ID="Label8" runat="server" Text="Điện thoại Cơ quan:"></asp:Label></td>
                    <td><asp:TextBox ID="txtofficePhone" runat="server" Width="300px"></asp:TextBox>
                    </td>
                  </tr>
                  <tr>
                   
                    <td class="txt-from-taomoi" ><asp:Label ID="Label5" runat="server" Text="Chức vụ:"></asp:Label></td>
                    <td><asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox>
                    </td>
                  </tr>
                  
                  <tr>
                   
                    <td class="txt-from-taomoi" ><asp:Label ID="Label6" runat="server" Text="Email:"></asp:Label></td>
                    <td><asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                    </td>
                  </tr>
                  
                  <tr>
                   
                    <td class="txt-from-taomoi" ><asp:Label ID="Label9" runat="server" Text="Thứ tự:"></asp:Label></td>
                    <td><asp:TextBox ID="txtOrder" runat="server" Width="300px"></asp:TextBox>
                    </td>
                  </tr>
                 
                </table>
          </td>
   
       </tr>
    </table>
    
</div>

