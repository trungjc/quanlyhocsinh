<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editpage.ascx.cs" Inherits="CMS.Client.Admin.editpage" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
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
                                      <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listpage/Default.aspx">
                                            <span class="icon-32-menus" title="Danh mục">
                                            </span>
                                            Danh mục
                                        </asp:HyperLink>
                			            
                                    </td>
                	                
	                                <td  id="Td1" style="text-align:center">
                                      <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editpage/Default.aspx">
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
            
            <div class="search_panel" style="height:30px; text-align:center;line-height:30px;vertical-align:middle;">
	            
				    <asp:Literal ID="clientview" runat="server"></asp:Literal>
		</div>
		
         <table width="100%" border="0" cellspacing="0" cellpadding="6">
            <tr>
               <td class="txt-from-taomoi" width="65%"> 
               

                    <table width="100%" border="0" cellpadding="5" cellspacing="0">

                        <tr>

                            <td class="txt-from-taomoi" style="width:140px;">
                                <asp:Label ID="Label11" runat="server" Text="Nhóm (loại)"></asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rdbGroup" runat="server" RepeatDirection="Horizontal" Height="22px" OnSelectedIndexChanged="rdbGroup_SelectedIndexChanged" AutoPostBack="True">
                                       <asp:ListItem Selected="True" Value="1">Sổ tay kinh nghiệm</asp:ListItem>
                                       <asp:ListItem Value="2">Danh bạ</asp:ListItem>
                                        <asp:ListItem Value="3">Tiện ích</asp:ListItem>
                                      <%--   <asp:ListItem Value="4">Sổ tay kinh nghiệm</asp:ListItem>--%>
                                </asp:RadioButtonList></td>
                        </tr>
                        
                        
                        <tr>

                            <td width="140" class="txt-from-taomoi" >
                                <asp:Label ID="Label1" runat="server" Text="Trang đã có"></asp:Label></td>
                            <td style="height: 22px">
                                <asp:DropDownList ID="ddlPage" runat="server" Width="277px" AppendDataBoundItems="True">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>

                            <td class="txt-from-taomoi">
                                <asp:Label ID="Label2" runat="server" Text="Tên trang mới"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtPageName" runat="server" Width="270px" CssClass="txt-form-create-input"></asp:TextBox></td>
                        </tr>
                       
                        <tr>
                            <td colspan="2">
                               
                                    
                                <asp:Panel ID="PanelTitle" runat="server" >
                                    <div id="divTitle1" runat="server">   
                                    
                                      <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            
                                            <td class="txt-from-taomoi" style="width:140px;">
                                                <asp:Label ID="Label3" runat="server" Text="Tiêu đề"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtTitle" runat="server" Width="270px" CssClass="txt-form-create-input"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                                                 ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        </table>
                                    </div>
                                 </asp:Panel> 
                            
                            </td>
                        
                        </tr>
                                 

                                           
                        <tr>

                            <td class="txt-from-taomoi">
                                <asp:Label ID="Label6" runat="server" Text="Ảnh đại diện (nếu có)"></asp:Label></td>
                            <td>
                                <asp:FileUpload ID="file_image_thumb" runat="server" Width="274px" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="file_image_thumb"
                                    ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>

                            <td class="txt-from-taomoi">
                                <asp:Label ID="Label5" runat="server" Text="Nội dung ngắn gọn"></asp:Label></td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>

                            <td colspan="2" class="txt-from-taomoi">
                                <telerik:RadEditor ID="txtRadshort" runat="server" DeleteFlashPaths="~/UserFile/Media"
                                    DeleteImagesPaths="~/UserFile/Images" DeleteMediaPaths="~/UserFile/Media" FlashPaths="~/UserFile/Media"
                                    ImagesPaths="~/UserFile/Images" MediaPaths="~/UserFile/Media" UploadFlashPaths="~/UserFile/Media"
                                    UploadImagesPaths="~/UserFile/Images" UploadMediaPaths="~/UserFile/Media" Height="250px"
                                    Width="450px" ToolsFile="~/RadControls/Editor/BaseFile.xml" ShowSubmitCancelButtons="False"
                                    ToolbarMode="Default" DocumentsPaths="~/UserFile/Media" UploadDocumentsPaths="~/UserFile/Media" MaxDocumentSize="5120000" MaxFlashSize="1024000" MaxImageSize="2048000" MaxMediaSize="52428800">
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="2">
                            <asp:Panel ID="PanelContent" runat="server" Width="620px">
                                <div id="divFull" runat="server">
                                    <table border="0" width="100" cellpadding="0" cellspacing="0">
                                        <tr>
                                           
                                            <td class="txt-from-taomoi" style="width:140px;">
                                                <asp:Label ID="Label7" runat="server" Text="Nội dung chi tiết"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                           
                                            <td colspan="2" class="txt-from-taomoi">
                                                <telerik:RadEditor ID="txtRad_full" runat="server" DeleteFlashPaths="~/UserFile/Media"
                                                    DeleteImagesPaths="~/UserFile/Images" DeleteMediaPaths="~/UserFile/Media" FlashPaths="~/UserFile/Media"
                                                    ImagesPaths="~/UserFile/Images" MediaPaths="~/UserFile/Media" UploadFlashPaths="~/UserFile/Media"
                                                    UploadImagesPaths="~/UserFile/Images" UploadMediaPaths="~/UserFile/Media" Height="550px"
                                                    Width="550px" ToolsFile="~/RadControls/Editor/ToolsFile.xml" ShowSubmitCancelButtons="False"
                                                    ToolbarMode="Default" DocumentsPaths="~/UserFile/Media" UploadDocumentsPaths="~/UserFile/Media" MaxDocumentSize="5120000" MaxFlashSize="1024000" MaxImageSize="2048000" MaxMediaSize="52428800">
                                                </telerik:RadEditor>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                    </td>
                </tr>
             </table>
           </td>
           <td align="left" valign="top">
                <table width="100%" border="0" cellpadding="5" cellspacing="0"  class="bg-line-cham">
                        <tr>
                            <td class="txt-from-taomoi" style="width:90px">
                                <asp:Label ID="Label4" runat="server" Text="Kiểu"></asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rdbType1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                    OnSelectedIndexChanged="rdbType_SelectedIndexChanged" Enabled="true">
                                    <asp:ListItem Selected="True" Value="True">Đầy đủ</asp:ListItem>
                                    <asp:ListItem Value="False">Ngắn gọn</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td class="txt-from-taomoi">
                                <asp:Label ID="Label8" runat="server" Text="Ngày đăng"></asp:Label></td>
                            <td>
                                <telerik:RadDatePicker ID="txtRadDate" runat="server" Culture="Vietnamese (Vietnam)" SelectedDate="2009-05-26">
                                    <DateInput CatalogIconImageUrl="" Description="" DisplayPromptChar="_" PromptChar=" "
                                        Title="" TitleIconImageUrl="" TitleUrl="" Width="100px"></DateInput>
                                    <Calendar FocusedDate="2008-07-31">
                                    </Calendar>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td class="txt-from-taomoi" >
                                <asp:Label ID="Label9" runat="server" Text="Tác giả (nguồn)"></asp:Label></td>
                            <td >
                                <asp:TextBox ID="txtAuthor" runat="server" Width="130px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="txt-from-taomoi">
                                <asp:Label ID="Label10" runat="server" Text="Trạng thái"></asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rdbActive" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="True">Hiển thị</asp:ListItem>
                                    <asp:ListItem Value="False">Ẩn</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td class="txt-from-taomoi">
                                <asp:Label ID="Label12" runat="server" Text="Hiển thị"></asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rdbIsView" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem  Value="True">Trang chủ(Hot)</asp:ListItem>
                                    <asp:ListItem Value="False" Selected="True">Trang thường</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td class="txt-from-taomoi" ><asp:Label ID="Label13" runat="server" Text="Đăng Nhận xét (Comment)"></asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rdbComment" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" >
                                    <asp:ListItem Selected="True" Value="False">Không đăng Comment</asp:ListItem>
                                    <asp:ListItem Value="True">Đăng Comment</asp:ListItem>
                                </asp:RadioButtonList></td>
                            </tr>
                        
                        <tr>
                            <td class="txt-from-taomoi" ><asp:Label ID="Label14" runat="server" Text="Duyệt bài"></asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="rdbApproval" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" >
                                    <asp:ListItem Value="False" Selected="True">Chưa duyệt</asp:ListItem>
                                    <asp:ListItem  Value="True">Duyệt bài</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr> 
                    </table>
                </td>
           </tr>
        </table>
</div>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>    
        <telerik:AjaxSetting AjaxControlID="rdbType">
            <UpdatedControls>            
                <telerik:AjaxUpdatedControl ControlID="PanelContent" LoadingPanelID="Loading" />
                <telerik:AjaxUpdatedControl ControlID="PanelTitle" LoadingPanelID="Loading" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hddCommentTotal" runat="server" />
<asp:HiddenField ID="hddVisitTotal" runat="server" />
<asp:HiddenField ID="hddCreateUserName" runat="server" />
<asp:HiddenField ID="hddApprovalUserName" runat="server" />
<asp:HiddenField ID="hddApprovalDate" runat="server" />
 <asp:HiddenField ID="hddPageID" runat="server" />
<asp:HiddenField ID="hddImage" runat="server" />
<%--<asp:HiddenField ID="hddIcon" runat="server" />--%>