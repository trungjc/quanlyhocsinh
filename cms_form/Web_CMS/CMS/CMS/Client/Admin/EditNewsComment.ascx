<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditNewsComment.ascx.cs" Inherits="CMS.Client.Admin.EditNewsComment" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<link href="~\RadControls\Editor\Skins\Default\Editor.css" rel="stylesheet" type="text/css" />
    
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
                                      <asp:HyperLink ID="HyperLink2" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton1" runat=server ImageUrl="~/images/Admin_Theme/Icons/icon-32-menu.png" OnClick="btn_list" CssClass="toolbar" />
			                               <br />
			                                Danh mục Tin
			                           </asp:HyperLink>
                			            
		                            </td>
                                    
                                     <td  id="Td4" style="text-align:center">
                                      <asp:HyperLink ID="HyperLink4" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton2" runat=server ImageUrl="~/images/Admin_Theme/Icons/icon-32-new.png" OnClick="btn_editcomment"  CssClass="toolbar"/>
			                               <br />
			                                Tạo mới
			                           </asp:HyperLink>
                			            
		                            </td>
            		                
            		                 <td id="Td1" style="text-align: center">
                                        <asp:HyperLink ID="btn_add" runat="server" CssClass="toolbar">
                                            <asp:ImageButton ID="ImageButton4" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-save.png"
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
        </tr> </table>
<table width="100%" border="0" cellspacing="0" cellpadding="5">
    <tr>
        <td colspan="2"  height="22" align="center">
            <asp:Literal ID="clientview" runat="server"></asp:Literal></td>
    </tr>
     <tr>

            <td class="txt-from-taomoi" style="width:140px;" > 
                <asp:Label ID="Label2" runat="server" Text="Tiêu đề :"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="377px" CssClass="txt-form-create-input"></asp:TextBox>
                
            </td>
        </tr>
         <tr>

            <td class="txt-from-taomoi">
                <asp:Label ID="txtFullName1" runat="server" Text="Tên khách hàng :"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtFullName" runat="server" Width="277px" CssClass="txt-form-create-input"></asp:TextBox>
                
            </td>
        </tr> 
        <tr>
       
            <td class="txt-from-taomoi">
                <asp:Label ID="Label3" runat="server" Text="Email :"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="277px" CssClass="txt-form-create-input"></asp:TextBox>
               
            </td>
        </tr>
        <tr>
            
            <td class="txt-from-taomoi">
                <asp:Label ID="Label1" runat="server" Text="Nội dung chi tiết"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            
            <td colspan="2" class="txt-from-taomoi">
                <telerik:RadEditor ID="txtContent" runat="server" DeleteFlashPaths="~/UserFile/Media"
                    DeleteImagesPaths="~/UserFile/Images" DeleteMediaPaths="~/UserFile/Media" FlashPaths="~/UserFile/Media"
                    ImagesPaths="~/UserFile/Images" MediaPaths="~/UserFile/Media" UploadFlashPaths="~/UserFile/Media"
                    UploadImagesPaths="~/UserFile/Images" UploadMediaPaths="~/UserFile/Media" Height="250px"
                    Width="570px" ToolsFile="~/RadControls/Editor/BaseFile.xml" ShowSubmitCancelButtons="False"
                    ToolbarMode="ShowOnFocus" DocumentsPaths="~/UserFile/Media" UploadDocumentsPaths="~/UserFile/Media">
                </telerik:RadEditor>
            </td>
        </tr>
        <tr>
                                        
            <td class="txt-from-taomoi">
                <asp:Label ID="Label7" runat="server" Text="Date :"></asp:Label></td>

            <td>
                <telerik:RadDatePicker ID="txtDateCreated" runat="server" Width="150px" Culture="Vietnamese (Vietnam)">
                <DateInput CatalogIconImageUrl="" Description="" DisplayPromptChar="_" PromptChar=" " Title="" TitleIconImageUrl="" TitleUrl="" Width="80"></DateInput>
                </telerik:RadDatePicker>
            </td>
            </tr>
            <tr>
                <td class="txt-from-taomoi">
                    <asp:Label ID="Label5" runat="server" Text="Trạng thái"></asp:Label></td>
   
                <td>
                    <asp:RadioButtonList ID="rdbActive" runat="server" RepeatDirection="Vertical">
                        <asp:ListItem Selected="True" Value="True">Phê duyệt</asp:ListItem>
                        <asp:ListItem Value="False">Ngừng phê duyệt</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
</table>
</div>
 
<asp:HiddenField ID="hddCommentID" runat="server" />
<asp:HiddenField ID="hddNewsID" runat="server" />
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hddApprovalUserName" runat="server" />
<asp:HiddenField ID="hddApprovalDate" runat="server" />