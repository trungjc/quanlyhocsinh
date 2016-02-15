<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editsinglepage.ascx.cs" Inherits="CMS.Client.Admin.editsinglepage" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="headerText">
	<asp:Image ID="imgIcon" runat="server" CssClass="icon_image"/>
    <span class="subNavLink"><asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    
                     <td align="right" width="200">
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
                                      <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listsinglepage/Default.aspx">
                                            <span class="icon-32-menus" title="Danh mục">
                                            </span>
                                            Danh mục
                                        </asp:HyperLink>
                			            
                                    </td>
                	                
	                                <td  id="Td1" style="text-align:center">
                                      <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editsinglepage/Default.aspx">
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
        </tr> </table> 
 
 <div class="search_panel" style="text-align:center;vertical-align:middle;">
        
		    <asp:Literal ID="clientview" runat="server"></asp:Literal>
</div>
 <table width="100%" border="0" cellspacing="0" cellpadding="6">
    <tr>
       <td class="txt-from-taomoi" width="70%">  
           
            <table width="100%" border="0" cellpadding="5" cellspacing="0">
             
                 <tr>

                    <td class="txt-from-taomoi" style="width: 140px; ">
                        <asp:Label ID="Label1" runat="server" Text="Tên trang đơn :"></asp:Label></td>
                    <td  style="height: 24px">
                        <asp:TextBox ID="txtSinglePageName" runat="server" Width="299px"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSinglePageName"
                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>

                    <td class="txt-from-taomoi" style="width: 174px; height: 24px">
                        <asp:Label ID="Label3" runat="server" Text="Hình ảnh (Nếu có) :"></asp:Label></td>
                    <td style="height: 24px" width="613">
                        <asp:FileUpload ID="fileIcon" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fileIcon"
                            ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator></td>
                </tr>
                <tr>

                    <td class="txt-from-taomoi" style="height: 19px; width: 174px;">
                        <asp:Label ID="Label4" runat="server" Text="Nội dung ngắn gọn :"></asp:Label>
                    </td>
                    <td style="height: 19px">
                        &nbsp;</td>
                </tr>
                <tr>

                    <td colspan="2" class="txt-from-taomoi">
                         <telerik:RadEditor ID="txtRadSinglePageDesc" Skin="Default" runat="server" DeleteFlashPaths="~/UserFile/Media" DeleteImagesPaths="~/UserFile/Images" DeleteMediaPaths="~/UserFile/Media" FlashPaths="~/UserFile/Media" Height="200px" ImagesPaths="~/UserFile/Images" MediaPaths="~/UserFile/Media" ToolsFile="~/RadControls/Editor/BaseFile.xml" UploadFlashPaths="~/UserFile/Media" UploadImagesPaths="~/UserFile/Images" UploadMediaPaths="~/UserFile/Media" Width="450px" ShowSubmitCancelButtons="False" DeleteDocumentsPaths="~/UserFile/Files" DocumentsPaths="~/UserFile/Files" MaxDocumentSize="512000000" UploadDocumentsPaths="~/UserFile/Files" MaxFlashSize="102400000" MaxImageSize="204800000" MaxMediaSize="524288000" >
                        </telerik:RadEditor>                       
                        
                    </td>
                </tr>
                <tr>

                    <td class="txt-from-taomoi" colspan="2">
                        <telerik:RadEditor ID="txtRadSinglePageContent" Skin="Default" runat="server" DeleteFlashPaths="~/UserFile/Media" 
                            DeleteImagesPaths="~/UserFile/Images" DeleteMediaPaths="~/UserFile/Media" FlashPaths="~/UserFile/Media" 
                            ImagesPaths="~/UserFile/Images" MediaPaths="~/UserFile/Media" UploadFlashPaths="~/UserFile/Media" 
                            UploadImagesPaths="~/UserFile/Images" UploadMediaPaths="~/UserFile/Media" Width="570px" Height="500px" 
                            ShowSubmitCancelButtons="False" MaxFlashSize="10240000" MaxImageSize="20480000" MaxMediaSize="524288000" 
                            DeleteDocumentsPaths="~/UserFile/Files" DocumentsPaths="~/UserFile/Files" MaxDocumentSize="512000000" 
                            UploadDocumentsPaths="~/UserFile/Files" >
                        
                        
                        </telerik:RadEditor>
                    
                    
                        
                    </td>
                </tr>
                 
            </table>
            
        </td>
        
         <td align="left" valign="top">
             <table width="100%" border="0" cellspacing="0" cellpadding="6" class="bg-line-cham">
                    <tr>
                        <td class="txt-from-taomoi" >
                            <asp:Label ID="Label10" runat="server" Text="Trạng thái :"></asp:Label></td>
                        <td>
                            <asp:RadioButtonList ID="rdbStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="True">Hiển thị</asp:ListItem>
                                <asp:ListItem Value="False">Ẩn</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>  
                
              </table>
            </td>
                
   </tr>
</table>            
            
</div>
<asp:HiddenField ID="hddSinglePageID" runat="server" />
<asp:HiddenField ID="hddIcon" runat="server"/>
