<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="config.ascx.cs" Inherits="CMS.Client.Admin.config" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<style type="text/css">
    .style1
    {
        height: 39px;
    }
    .style2
    {
        width: 294px;
    }
    .style3
    {
        width: 108px;
    }
    .radio
    {
    }
</style>
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right" width="30%">
                <div class="toolbar" id="toolbar">
                    <table class="toolbar">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:RadioButton runat="server" ID="Check_Viet" Checked="true" Text="Tiếng Việt"
                                        GroupName="Check" AutoPostBack="true" OnCheckedChanged="Viet_Check" />
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RadioButton runat="server" ID="Check_Eng" Text="English" GroupName="Check" AutoPostBack="true"
                                        OnCheckedChanged="Eng_Check" />
                                </td>
                            </tr>
                        </tbody>
                    </table>                    
                </div>
            </td>
            <td align="right" width="70%">
                <div class="toolbar" id="Div1">
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
    <div align="center">
        <telerik:RadTabStrip id="RadTabStrip1" multipageid="RadMultiPage1"
            selectedindex="0" width="850px" runat="server" EnableEmbeddedSkins="true" Skin="Sitefinity">
            <Tabs>
                <telerik:RadTab ID="Tab1" runat="server" Text="Cấu hình chung" 
                    Selected="True">
                </telerik:RadTab>
                <telerik:RadTab ID="Tab9" runat="server" Text="Server">
                </telerik:RadTab>
                <telerik:RadTab ID="Tab2" runat="server" Text="Cấu hình tin">
                </telerik:RadTab>
                <telerik:RadTab ID="Tab5" runat="server" Text="Support">
                </telerik:RadTab>
                <telerik:RadTab ID="Tab6" runat="server" Text="Contact">
                </telerik:RadTab>
                <telerik:RadTab ID="Tab7" runat="server" Text="Email liên hệ">
                </telerik:RadTab>
                <telerik:RadTab ID="Tab8" runat="server" Text="Thông tin khác">
                </telerik:RadTab>
                <telerik:RadTab ID="Tab10" runat="server" Text="Cấu hình Popup">
                </telerik:RadTab>
                <telerik:RadTab ID="Tab3" runat="server" Text="Cấu hình sản phẩm" Visible="false">
                </telerik:RadTab>
                <telerik:RadTab ID="Tab4" runat="server" Text="Trạng thái" Visible="false">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>        
        <telerik:radmultipage id="RadMultiPage1" runat="server" selectedindex="0" width="850"
            borderstyle="Solid" bordercolor="#cfc2ed" borderwidth="1px">
            <telerik:RadPageView ID="PageView1" runat="server">
                <table width="100%" cellpadding="5">
                    <tr>
                        <td style="width: 800px;" align="center" class="txt-from-taomoi">
                            <asp:Literal ID="ltlcommon" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px;" align="left" class="txt-from-taomoi">
                            <asp:Label ID="Label1" runat="server" Text="Tiêu đề website"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px;" align="center">
                            <asp:TextBox ID="txttitleweb" runat="server" Width="750px" Height="22px" CssClass="txt-form-create-input"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttitleweb"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px" align="left" class="txt-from-taomoi">
                            <asp:Label ID="Label2" runat="server" Text="Từ khóa cung cấp goolge tìm kiếm"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px" align="center" cssclass="txt-form-create-input">
                            <asp:TextBox ID="txtgoogle" runat="server" Height="74px" TextMode="MultiLine" Width="750px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px" align="left" class="txt-from-taomoi">
                            <asp:Label ID="Label17" runat="server" Text="Lời giới thiệu"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 750px" align="center">
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="txtIntro_desc" SkinID="DefaultTools"
                                Width="750px" >
                                <MediaManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <TemplateManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <DocumentManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <FlashManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <Content>
                            
                            
                            
                                
                                </Content>
                                <ImageManager ViewPaths="~/UserFile/Images" DeletePaths="~/UserFile/Images" MaxUploadFileSize="3048000"
                                    UploadPaths="~/UserFile/Images"></ImageManager>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px" align="left" class="txt-from-taomoi">
                            <asp:Label ID="Label3" runat="server" Text="Nội dung giới thiệu"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px" align="center">
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="txtIntroduction" SkinID="DefaultTools" Height="500px"
                                Width="750px">
                                <MediaManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <TemplateManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <DocumentManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <FlashManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <Content>
                            
                            
                            
                                
                                </Content>
                                <ImageManager ViewPaths="~/UserFile/Images" DeletePaths="~/UserFile/Images" MaxUploadFileSize="3048000"
                                    UploadPaths="~/UserFile/Images"></ImageManager>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px" align="left" class="txt-from-taomoi">
                            <asp:Label ID="Label4" runat="server" Text="Thông tin công ty"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px" align="center">
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="txtInfocompany" SkinID="DefaultTools"
                                Width="750px">
                                <MediaManager MaxUploadFileSize="20480000" />
                                <TemplateManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <DocumentManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <FlashManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <Content>
                            
                            
                            
                                
                                </Content>
                                <ImageManager ViewPaths="~/UserFile/Images" DeletePaths="~/UserFile/Images" MaxUploadFileSize="3048000"
                                    UploadPaths="~/UserFile/Images"></ImageManager>
                            </telerik:RadEditor>

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px;" align="center">
                            <asp:ImageButton ID="btn_common" runat="server" OnClick="btn_common_Click" ImageUrl="~/images/Admin_Theme/images/btn_save.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px">
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="PageView9" runat="server">
                <table>
                    <tr>
                        <td align="center" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Literal ID="ltlServer" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label24" runat="server" Text="Tên Website"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWebName" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label25" runat="server" Text="IP Máy chủ"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWebServerIP" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label26" runat="server" Text="IP Mail Server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWebMailServer" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label27" runat="server" Text="Domain"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWebDomain" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/Admin_Theme/images/btn_save.gif"
                                OnClick="btnServer_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td class="style2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="PageView2" runat="server">
                <table cellpadding="5" align="center" style="width: 60%">
                    <tr>
                        <td align="center" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="txt-from-taomoi">
                            <asp:Literal ID="ltlnews" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px" class="txt-from-taomoi" align="left">
                            <asp:Label ID="Label5" runat="server" Text="Icons"></asp:Label>
                        </td>
                        <td style="width: 750px">
                            <asp:Literal ID="Literal1" runat="server" Text="Chiều rộng (px) "></asp:Literal>
                            <asp:TextBox ID="new_icon_w" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="new_icon_w"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            <asp:Literal ID="Literal2" runat="server" Text="Chiều cao (px)"></asp:Literal>
                            <asp:TextBox ID="new_icon_h" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ControlToValidate="new_icon_h"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px" class="txt-from-taomoi" align="left">
                            <asp:Label ID="Label6" runat="server" Text="Ảnh nhỏ"></asp:Label>
                        </td>
                        <td style="width: 750px">
                            <asp:Literal ID="Literal3" runat="server" Text="Chiều rộng (px)"></asp:Literal>
                            <asp:TextBox ID="new_thumb_w" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ControlToValidate="new_thumb_w"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            <asp:Literal ID="Literal4" runat="server" Text="Chiều cao (px)"></asp:Literal>
                            <asp:TextBox ID="new_thumb_h" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator5" runat="server" ControlToValidate="new_thumb_h"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px; height: 26px;" class="txt-from-taomoi" align="left">
                            <asp:Label ID="Label7" runat="server" Text="Ảnh to"></asp:Label>
                        </td>
                        <td style="width: 750px; height: 26px;">
                            <asp:Literal ID="Literal5" runat="server" Text="Chiều rộng (px)"></asp:Literal>
                            <asp:TextBox ID="new_large_w" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator6" runat="server" ControlToValidate="new_large_w"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            <asp:Literal ID="Literal6" runat="server" Text="Chiều cao (px)"></asp:Literal>
                            <asp:TextBox ID="new_large_h" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator7" runat="server" ControlToValidate="new_large_h"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="style1" colspan="2">
                            <asp:ImageButton ID="btn_news" runat="server" ImageUrl="~/images/Admin_Theme/images/btn_save.gif"
                                OnClick="btn_news_Click" Width="106px" />
                        </td>
                        <tr>
                            <td style="width: 150px; height: 21px;">
                            </td>
                            <td style="width: 750px; height: 21px;">
                            </td>
                        </tr>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="PageView5" runat="server">
                <table style="width: 850px">
                    <tr>
                        <td align="center" style="height: 21px">
                            <asp:Literal ID="litSupport" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label16" runat="server" Text="Trang hỗ trợ trực tuyến"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">                            
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="txtRadSupport" SkinID="DefaultTools" 
                                Width="750px">
                                <MediaManager MaxUploadFileSize="20480000" />
                                <TemplateManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <DocumentManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <FlashManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <Content>
                            
                            
                            
                                
                                </Content>
                                <ImageManager ViewPaths="~/UserFile/Images" DeletePaths="~/UserFile/Images" MaxUploadFileSize="3048000"
                                    UploadPaths="~/UserFile/Images"></ImageManager>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px;" align="center">
                            <asp:ImageButton ID="btn_Support" runat="server" OnClick="btn_Support_Click" ImageUrl="~/images/Admin_Theme/images/btn_save.gif" />
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="PageView6" runat="server">
                <table style="width: 850px">
                    <tr>
                        <td align="center" style="height: 21px">
                            <asp:Literal ID="litContact" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label18" runat="server" Text="Thông tin liên hệ :"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">                            
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="txtRadContact" SkinID="BasicTools" ToolsFile="~/RadControls/Editor/BasicTools.xml"
                                Height="400px" Width="750px">
                                <Content>
                            
                            
                            
                                </Content>                                
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 800px;" align="center">
                            <asp:ImageButton ID="btn_Contact" runat="server" OnClick="btn_Contact_Click" ImageUrl="~/images/Admin_Theme/images/btn_save.gif" />
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="PageView7" runat="server">
                <table>
                    <tr>
                        <td align="center" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Literal ID="ltlEmail" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label19" runat="server" Text="Email gửi thư"></asp:Label>
                        </td>
                        <td class="style2">
                            &nbsp;<asp:TextBox ID="txtEmailFrom" runat="server" Width="250px"></asp:TextBox>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label20" runat="server" Text="Email nhận thư"></asp:Label>
                        </td>
                        <td class="style2">
                            &nbsp;<asp:TextBox ID="txtEmailTo" runat="server" Width="250px"></asp:TextBox>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Admin_Theme/images/btn_save.gif"
                                OnClick="btnemail_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td class="style2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="PageView8" runat="server">
                <table style="width: 750px; margin-left: 35px;" align="center">
                    <tr>
                        <td align="center" colspan="2" style="height: 21px">
                            <asp:Literal ID="ltlOther" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <asp:Label ID="Label21" runat="server" Text="Banner Flash"></asp:Label>
                        </td>
                        <td style="width: 750px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">                            
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="RadCounter" SkinID="DefaultTools" 
                                Width="750px">
                                <MediaManager MaxUploadFileSize="20480000" />
                                <TemplateManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <DocumentManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <FlashManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <Content>
                            
                            
                            
                                
                                </Content>
                                <ImageManager ViewPaths="~/UserFile/Images" DeletePaths="~/UserFile/Images" MaxUploadFileSize="3048000"
                                    UploadPaths="~/UserFile/Images"></ImageManager>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <asp:Label ID="Label22" runat="server" Text="Bảng thông số 1"></asp:Label>
                        </td>
                        <td style="width: 750px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">                           
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="RadInfo1" SkinID="DefaultTools" 
                                Width="750px">
                                <MediaManager MaxUploadFileSize="20480000" />
                                <TemplateManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <DocumentManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <FlashManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <Content>
                            
                            
                            
                                
                                </Content>
                                <ImageManager ViewPaths="~/UserFile/Images" DeletePaths="~/UserFile/Images" MaxUploadFileSize="3048000"
                                    UploadPaths="~/UserFile/Images"></ImageManager>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <asp:Label ID="Label23" runat="server" Text="Bảng thông số 2"></asp:Label>
                        </td>
                        <td style="width: 750px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">                            
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="RadInfo2" SkinID="DefaultTools" 
                                Width="750px">
                                <MediaManager MaxUploadFileSize="20480000" />
                                <TemplateManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <DocumentManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <FlashManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <Content>
                                </Content>
                                <ImageManager ViewPaths="~/UserFile/Images" DeletePaths="~/UserFile/Images" MaxUploadFileSize="3048000"
                                    UploadPaths="~/UserFile/Images"></ImageManager>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:ImageButton ID="ImageButton2" runat="server" OnClick="btn_Other_Click" ImageUrl="~/images/Admin_Theme/images/btn_save.gif" />
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="PageView10" runat="server">
                <table style="width: 700px; margin-left: 35px;" align="center">
                    <tr>
                        <td align="center" colspan="2" style="height: 21px">
                            <asp:Literal ID="ltlPopup" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <asp:Label ID="Label28" runat="server" Text="Trạng thái"></asp:Label>
                        </td>
                        <td style="width: 750px">
                            <asp:RadioButtonList ID="rdbPopup" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="True">Bật</asp:ListItem>
                                <asp:ListItem Value="False">Tắt</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <asp:Label ID="Label29" runat="server" Text="Nội dung Popup 1"></asp:Label>
                        </td>
                        <td style="width: 750px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">                            
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="radPopup" SkinID="DefaultTools" Height="500px"
                                Width="750px">
                                <MediaManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <TemplateManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <DocumentManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <FlashManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <Content>
                            
                            
                            
                                
                                </Content>
                                <ImageManager ViewPaths="~/UserFile/Images" DeletePaths="~/UserFile/Images" MaxUploadFileSize="3048000"
                                    UploadPaths="~/UserFile/Images"></ImageManager>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <asp:Label ID="Label30" runat="server" Text="Nội dung Popup 2"></asp:Label>
                        </td>
                        <td style="width: 750px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">                            
                            <telerik:RadEditor runat="server" EnableEmbeddedSkins="true" Skin="Simple" ID="radPopup2" SkinID="DefaultTools" Height="500px"
                                Width="750px">
                                <MediaManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <TemplateManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <DocumentManager DeletePaths="~/UserFile/Files" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Files"
                                    ViewPaths="~/UserFile/Files" />
                                <FlashManager DeletePaths="~/UserFile/Media" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media"
                                    ViewPaths="~/UserFile/Media" />
                                <Content>
                            
                            
                            
                                
                                </Content>
                                <ImageManager ViewPaths="~/UserFile/Images" DeletePaths="~/UserFile/Images" MaxUploadFileSize="3048000"
                                    UploadPaths="~/UserFile/Images"></ImageManager>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:ImageButton ID="ImageButton4" runat="server" OnClick="btn_popup_Click" ImageUrl="~/images/Admin_Theme/images/btn_save.gif" />
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="PageView3" runat="server" Visible="false">
                <table style="width: 850px">
                    <tr>
                        <td align="center" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Literal ID="ltlproduct" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <asp:Label ID="Label8" runat="server" Text="Icons"></asp:Label>
                        </td>
                        <td style="width: 750px">
                            <asp:Literal ID="Literal8" runat="server" Text="chiều rộng (px) "></asp:Literal>
                            <asp:TextBox ID="product_icon_w" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator8" runat="server" ControlToValidate="product_icon_w"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            <asp:Literal ID="Literal9" runat="server" Text="chiều cao (px)"></asp:Literal>
                            <asp:TextBox ID="product_icon_h" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator9" runat="server" ControlToValidate="product_icon_h"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <asp:Label ID="Label9" runat="server" Text="Ảnh nhỏ"></asp:Label>
                        </td>
                        <td style="width: 750px">
                            <asp:Literal ID="Literal10" runat="server" Text="chiều rộng (px)"></asp:Literal>
                            <asp:TextBox ID="product_thumb_w" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator10" runat="server" ControlToValidate="product_thumb_w"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            <asp:Literal ID="Literal11" runat="server" Text="chiều cao (px)"></asp:Literal>
                            <asp:TextBox ID="product_thumb_h" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator11" runat="server" ControlToValidate="product_thumb_h"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px; height: 26px;">
                            <asp:Label ID="Label10" runat="server" Text="Ảnh to"></asp:Label>
                        </td>
                        <td style="width: 750px; height: 26px;">
                            <asp:Literal ID="Literal12" runat="server" Text="chiều rộng (px)"></asp:Literal>
                            <asp:TextBox ID="product_large_w" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator12" runat="server" ControlToValidate="product_large_w"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            <asp:Literal ID="Literal13" runat="server" Text="chiều cao (px)"></asp:Literal>
                            <asp:TextBox ID="product_large_h" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator13" runat="server" ControlToValidate="product_large_h"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px; height: 26px">
                            <asp:Label ID="Label11" runat="server" Text="Số sản phẩm"></asp:Label>
                        </td>
                        <td style="width: 750px; height: 26px">
                            <asp:TextBox ID="txtNoproduct" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtNoproduct"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>sản phẩm
                            / 1 dòng
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px; height: 26px">
                            <asp:Label ID="Label12" runat="server" Text="Phân trang"></asp:Label>
                        </td>
                        <td style="width: 750px; height: 26px">
                            <asp:TextBox ID="txtNoPage" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtNoPage"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>sản phẩm
                            / 1 trang
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px; height: 26px">
                            <asp:Label ID="Label13" runat="server" Text="Đơn vị tiền tệ"></asp:Label>
                        </td>
                        <td style="width: 750px; height: 26px">
                            <asp:TextBox ID="txtCurrency" runat="server" Width="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtCurrency"
                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                        </td>
                        <td style="width: 750px">
                            <asp:Button ID="btnproduct" runat="server" Text="Lưu cấu hình" OnClick="btnproduct_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px; height: 21px;">
                        </td>
                        <td style="width: 750px; height: 21px;">
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="PageView4" runat="server" Visible="false">
                <table style="width: 850px">
                    <tr>
                        <td align="center" colspan="2" style="height: 21px">
                            <asp:Literal ID="ltlCloseweb" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <asp:Label ID="Label14" runat="server" Text="Trạng thái"></asp:Label>
                        </td>
                        <td style="width: 750px">
                            <asp:RadioButtonList ID="rdblistClose" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="true">Mở</asp:ListItem>
                                <asp:ListItem Value="False">Đ&#243;ng</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <asp:Label ID="Label15" runat="server" Text="Lý do"></asp:Label>
                        </td>
                        <td style="width: 750px">
                            <asp:TextBox ID="txtCloseComment" runat="server" Height="72px" TextMode="MultiLine"
                                Width="299px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                        </td>
                        <td style="width: 750px">
                            <asp:Button ID="btnCloseweb" runat="server" Text="Lưu thay đổi" OnClick="btnCloseweb_Click" />
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>            
        </telerik:radmultipage>
    </div>
</div>
