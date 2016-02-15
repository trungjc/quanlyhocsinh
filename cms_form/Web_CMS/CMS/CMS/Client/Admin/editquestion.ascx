<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editquestion.ascx.cs" Inherits="CMS.Client.Admin.editquestion" %>
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
                                    <td id="Td2" style="text-align:center">
                                          			            
		                            </td>
            		                
            		                <td id="Td1" style="text-align:center">
                                      <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editquestion/Default.aspx">
			                                <span class="icon-32-publish" title="Đăng tin mới">
			                                </span>
			                                Gửi yêu cầu mới
                                        </asp:HyperLink>                			            
		                            </td>		                            
		                             <td id="Td4" style="text-align: center; width: 7px;">
                                         &nbsp;</td>
                                    
		                            <td id="Td3" style="text-align: center">
                                        &nbsp;</td>
                                    
                                    <td  id="Td6">
                                        &nbsp;</td>                                    
                                
                                  </tr>
                              </tbody>
                        </table>
                    </div>
        
        </td>
      </tr>
    </table>

<table width="100%" border="0" cellpadding="5" cellspacing="0">
  <tr>
    <td align="center" colspan="2"> <asp:Literal ID="clientview" runat="server"></asp:Literal></td>
  </tr>
    <tr>
        <td class="txt-from-taomoi" style="width: 167px">
            <asp:Label ID="Label5" runat="server" Text="Khách hàng :"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbFullName" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            &nbsp;&nbsp;&nbsp; -&nbsp;
            <asp:Label ID="lbEmail" runat="server" Text="Label"></asp:Label></td>
    </tr>
  <tr>
            <td class="txt-from-taomoi" style="width: 167px" ><asp:Label ID="Label1" runat="server" Text="Sản phẩm hỗ trợ :"></asp:Label></td>
            <td ><asp:DropDownList ID="ddlCateNews" runat="server" Width="316px" AppendDataBoundItems="True">
            </asp:DropDownList></td>
            </tr>
          <tr>
           
            <td class="txt-from-taomoi" style="width: 167px; height: 34px;" ><asp:Label ID="Label2" runat="server" Text="Tiêu đề yêu cầu:"></asp:Label></td>
            <td style="height: 34px"><asp:TextBox ID="txtTitle" runat="server" Width="313px"></asp:TextBox>
            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                ErrorMessage="RequiredFieldValidator">* Chưa nhập tiêu đề</asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            
            <td class="txt-from-taomoi" style="width: 167px" ><asp:Label ID="Label4" runat="server" Text="Nội dung:"></asp:Label> </td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            
            <td colspan="2" class="txt-from-taomoi" >
                <telerik:RadEditor ID="txtRadShort" Skin="Default" runat="server" DeleteFlashPaths="~/UserFile/Media" DeleteImagesPaths="~/UserFile/Images" DeleteMediaPaths="~/UserFile/Media" FlashPaths="~/UserFile/Media" Height="200px" ImagesPaths="~/UserFile/Images" MediaPaths="~/UserFile/Media" ToolsFile="~/RadControls/Editor/small.xml" UploadFlashPaths="~/UserFile/Media" UploadImagesPaths="~/UserFile/Images" UploadMediaPaths="~/UserFile/Media" Width="450px" ShowSubmitCancelButtons="False" DeleteDocumentsPaths="~/UserFile/Files" DocumentsPaths="~/UserFile/Files" MaxDocumentSize="51200000" UploadDocumentsPaths="~/UserFile/Files" >
                </telerik:RadEditor>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRadShort"
                ErrorMessage="RequiredFieldValidator">* Chưa nhập nội dung</asp:RequiredFieldValidator>
            </td>
            </tr>
            <tr>
                <td class="txt-from-taomoi" style="width: 167px" ><asp:Label ID="Label3" runat="server" Text="Tệp tin đính kèm (nếu có) :"></asp:Label></td>
                <td>
                    <asp:FileUpload ID="file_Attach" runat="server" Width="301px" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="file_Attach"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((rar)|(zip))$">.rar,.zip</asp:RegularExpressionValidator></td>
                </tr>

              <tr>
                <td class="txt-from-taomoi" style="width: 167px" ><asp:Label ID="Label11" runat="server" Text="Hình ảnh đính kèm :"></asp:Label></td>
                <td>
                  <asp:FileUpload ID="image_Attach" runat="server" Width="301px" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="image_Attach"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator></td>
                </tr>
    <tr>
        <td class="txt-from-taomoi" style="width: 167px">
        </td>
        <td>
            <asp:Button ID="btnSend" runat="server" Text="Gửi" OnClick="btnSend_Click" Width="58px" />
            <asp:Button ID="btnCancel" runat="server" Text="Huỷ bỏ" OnClick="btnCancel_Click" /></td>
    </tr>
</table>
    
</div>
<asp:HiddenField ID="HiddenField_QuestionID" runat="server" />
<asp:HiddenField ID="HiddenField_ImageAttach" runat="server" />
<asp:HiddenField ID="HiddenField_FileAttach" runat="server" />
<asp:HiddenField ID="HiddenField_QuestionStatus" runat="server" />
<asp:HiddenField ID="HiddenField_CreateUserName" runat="server" />
<asp:HiddenField ID="HiddenField_CreateDate" runat="server" />


