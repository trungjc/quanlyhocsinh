<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listDetailQuestion.ascx.cs" Inherits="CMS.Client.Admin.listDetailQuestion" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div class="container_ListProduct">
    <div style="padding: 10px;">
        <span style="font-size: 10pt; font-weight: bold;">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></span>
        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="right">
                    <div class="toolbar" id="toolbar">
                        <table class="toolbar">
                            <tbody>
                                <tr>
                                    <td id="toolbar-unarchive" style="height: 21px">
                                        <asp:HyperLink ID="btn_home" runat="server" NavigateUrl="~/Admin/home/Default.aspx"
                                            CssClass="toolbar">
			                    <span class="icon-32-home" title="Trở về trang chủ">
			                    </span>
			                    Trang chủ
                                        </asp:HyperLink>
                                    </td>
                                    <td id="Td2" style="text-align: center; height: 21px;">
                                        <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editquestion/Default.aspx">
			                    <span class="icon-32-publish" title="Gửi yêu cầu"></span>
			                    Gửi yêu cầu mới
                                        </asp:HyperLink>
                                    </td>
                                    <td id="Td3" style="text-align: center; height: 21px;">
                                        <asp:HyperLink ID="btn_enable" runat="server" CssClass="toolbar">
                                            <asp:ImageButton ID="ImageButton4" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"
                                                OnClick="btn_enable_Click" />
                                            <br />
                                            Tiếp nhận
                                        </asp:HyperLink>
                                    </td>
                                    <td id="Td4" style="text-align: center; height: 21px;">
                                        <asp:HyperLink ID="btn_disable" runat="server" CssClass="toolbar">
                                            <asp:ImageButton ID="btn_disable1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply-1.png"
                                                OnClick="btn_disable_Click" />
                                            <br />
                                            Khoá câu hỏi
                                        </asp:HyperLink>
                                    </td>
                                    <td id="Td5" style="text-align: center; height: 21px;">
                                        <asp:HyperLink ID="btn_delall" runat="server" CssClass="toolbar">
                                            <asp:ImageButton ID="btn_delAll1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-delete.png"
                                                OnClick="btn_delAll_Click" />
                                            <br />
                                            Xóa tất cả
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <asp:GridView ID="grvListQuestion" runat="server" AutoGenerateColumns="False" Width="100%"
            AllowPaging="True" CssClass="gridviewBorder" OnRowDataBound="grvListQuestion_RowDataBound"
            OnRowCommand="grvListQuestion_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Question_ID">
                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                        Width="31px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="#">
                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                    <ItemTemplate>
                        <asp:CheckBox ID="chkId" runat="server" Checked="false" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                        Width="25px" />
                </asp:TemplateField>
                <asp:HyperLinkField DataNavigateUrlFields="Question_ID" DataNavigateUrlFormatString="~/Admin/listdetailquestion/{0}/Default.aspx"
                    DataTextField="Question_Title" HeaderText="C&#226;u hỏi">
                    <ItemStyle HorizontalAlign="Left" Font-Underline="False" ForeColor="Blue" CssClass="gridviewCellBottom gridviewCellRight" />
                    <ControlStyle Font-Underline="False" ForeColor="RoyalBlue" />
                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                        Width="200px" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="CreateDate" HeaderText="Thời gian gửi">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="115px" />
                </asp:BoundField>
                <asp:BoundField DataField="CateNewsName" HeaderText="Gửi đến" />
                <asp:BoundField DataField="QuestionStatus" HeaderText="Trạng th&#225;i" />
                <asp:TemplateField HeaderText="Publish" Visible="true">
                    <ItemTemplate>
                    <asp:ImageButton ID="btn_publish" runat="server" CommandName="_publish" CommandArgument='<%# Eval("Question_ID") %>'
                            ImageUrl="~/images/Admin_Theme/images/disable.png" ToolTip="Xuất bản" />
                        <asp:ImageButton ID="btn_unPublish" runat="server" CommandName="_unpublish" CommandArgument='<%# Eval("Question_ID") %>'
                            ImageUrl="~/images/Admin_Theme/images/enable.png" ToolTip="Ngừng xuất bản" />
                        <asp:Label ID="lb_IsPublish" runat="server" Text='<%# Eval("isPublish") %>' Visible="false"></asp:Label>
                        <asp:Literal ID="Literal_publish" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Chức năng">
                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                    <ItemTemplate>
                        
                        <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Question_ID") %>'
                            ImageUrl="~/images/Admin_Theme/images/btn_edit.jpg" ToolTip="Sửa nội dung" />&nbsp;
                        <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Question_ID") %>'
                            ImageUrl="~/images/Admin_Theme/images/btn_delete.gif" ToolTip="Xóa ???" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                        Width="80px" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle HorizontalAlign="Right" />
            <EmptyDataTemplate>
                Chưa có dữ liệu
            </EmptyDataTemplate>
        </asp:GridView>
        <br />
        <table class="box-vang" style="margin-top: 10px;" width="100%" border="0" cellpadding="0"
            cellspacing="0">
            <tbody>
                <tr>
                    <td class="t-l" style="width: 8px; height: 19px;">
                    </td>
                    <td class="t-c" style="height: 19px">
                    </td>
                    <td class="t-r" width="8px" style="height: 19px">
                    </td>
                </tr>
                <tr>
                    <td class="c-l" style="width: 8px">
                    </td>
                    <td class="c-c">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td style="vertical-align: top;">
                                        <div style="width: auto;">
                                            <div class="title_require">
                                                <img src="images/Admin_Theme/Icons/question_icon.jpeg" alt="?" align="absmiddle" />
                                                <b><span style="color: #ff0000;">NỘI DUNG YÊU CẦU</span></b>
                                            </div>
                                            <div class="content_require">
                                                <span style="">
                                                    <asp:Label ID="lbUserPost" runat="server" Text="lbUserPost"></asp:Label>
                                                </span><span class="height: 22px;">
                                                    <asp:Label ID="lbDatePostQuestion" runat="server" Text="lbDatePostQuestion" Font-Italic="False"></asp:Label>
                                                    <br />
                                                    <br />
                                                    <asp:Label ID="lbQuestionTitle" runat="server" Text="lbQuestionTitle" Font-Bold="True"></asp:Label>
                                                </span>
                                                <p>
                                                    <asp:Label ID="lbContentQuestion" runat="server" Text="lbContentQuestion" ForeColor="#990033"></asp:Label>
                                                </p>
                                                <div style="float: left; width: 200px;">
                                                    <asp:Literal ID="Literal_images" runat="server"></asp:Literal>
                                                </div>
                                                <div style="float: right; width: 200px;">
                                                    <asp:Literal ID="Literal_file" runat="server"></asp:Literal>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td class="c-r">
                    </td>
                </tr>
                <tr>
                    <td class="b-l" style="width: 8px">
                    </td>
                    <td class="b-c">
                    </td>
                    <td class="b-r">
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="margin: 10px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
            ShowHeader="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None"
            OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Tra loi">
                    <ItemTemplate>
                        <table class="box-hong" style="margin-top: 10px;" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td class="text-l">
                                    </td>
                                    <td class="text-c">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("ApprovalUserName") %>'></asp:Label>
                                        &nbsp; &nbsp;
                                        <asp:Label ID="Label3" runat="server" Text='Full Name' Font-Bold="True" Visible="false"></asp:Label>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("ApprovalDate") %>'></asp:Label>
                                    </td>
                                    <td class="text-r">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="box-hong" width="100%" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td class="t-l">
                                    </td>
                                    <td class="t-c">
                                    </td>
                                    <td class="t-r">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="c-l">
                                    </td>
                                    <td class="c-c" valign="top">
                                        <div style="padding: 5px;">
                                            <p style="margin: 10px 0px 10px 0px;">
                                                <asp:Label ID="lbContent" runat="server" Text='<%# Eval("Question_Content") %>'></asp:Label>
                                            </p>
                                            <div style="float: left; width: 200px;">
                                                <asp:Label ID="Literal_images11" runat="server" Text='<%# Eval("Question_image") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Literal ID="Literal_images1" runat="server"></asp:Literal>
                                            </div>
                                            <div style="float: right; width: 200px;">
                                                <asp:Label ID="lb_files" runat="server" Text='<%# Eval("Question_fileattach") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Literal ID="Literal_files" runat="server"></asp:Literal>
                                            </div>
                                            <br class="clearfloat" />
                                    </td>
                                    <td class="c-r">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="b-l">
                                    </td>
                                    <td class="b-c">
                                    </td>
                                    <td class="b-r">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="Publish" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lb_IsPublish" runat="server" Text='<%# Eval("isPublish") %>' Visible="true"></asp:Label>
                        <asp:Literal ID="Literal_publish" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Chức năng">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="btn_publish" runat="server" CommandName="_publish" CommandArgument='<%# Eval("Question_ID") %>'
                            ImageUrl="~/images/Admin_Theme/images/disable.png" ToolTip="Hiện bài viết" />
                        <asp:ImageButton ID="btn_unPublish" runat="server" CommandName="_unPublish" CommandArgument='<%# Eval("Question_ID") %>'
                            ImageUrl="~/images/Admin_Theme/images/enable.png" ToolTip="Ẩn bài viết" />
                        <asp:ImageButton ID="btn_edit_sub" runat="server" CommandName="_edit_sub" CommandArgument='<%# Eval("Question_ID") %>'
                            ImageUrl="~/images/Admin_Theme/images/btn_edit.jpg" ToolTip="Sửa nội dung" />&nbsp;
                        <asp:ImageButton ID="btn_delete_sub" runat="server" CommandName="_delete_sub" CommandArgument='<%# Eval("Question_ID") %>'
                            ImageUrl="~/images/Admin_Theme/images/btn_delete.gif" ToolTip="Xóa ???" />
                    </ItemTemplate>
                    <HeaderStyle CssClass=" " HorizontalAlign="Center" Width="60px" BorderColor="Silver" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                Chưa có câu trả lời
            </EmptyDataTemplate>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" HorizontalAlign="Center" CssClass="pagination-ys" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <table class="box-vang" style="margin-top: 10px;" width="100%" border="0" cellpadding="0"
            cellspacing="0">
            <tbody>
                <tr>
                    <td class="t-l" width="8px">
                    </td>
                    <td class="t-c">
                    </td>
                    <td class="t-r" width="8px">
                    </td>
                </tr>
                <tr>
                    <td class="c-l">
                    </td>
                    <td class="c-c">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td style="vertical-align: top;">
                                        <span style="padding-top: 5px; display: block; text-indent: 10px; color: Green;">+ Nếu
                                            câu trả lời của chúng tôi chưa thoả đáng, xin vui lòng tiếp tục phản hồi bằng cách
                                            gửi tiếp câu hỏi ở ô bên dưới, để chúng tôi tiện theo dõi.</span> <span style="padding-top: 5px;
                                                display: block; text-indent: 10px;">+ Nhưng nếu quý khách có câu hỏi mới về một
                                                vấn đề khác, xin hãy gửi yêu cầu mới. Đừng gửi vào mục này!</span> <span style="padding-top: 5px;
                                                    display: block; text-indent: 10px;">+ Trong vòng 7 ngày, nếu quý khách không phản
                                                    hồi lại, hệ thống sẽ tự động chuyển câu hỏi của quý khách sang trạng thái khoá.</span>
                                        <span style="padding-top: 5px; display: block; text-indent: 10px; color: Red;">Nếu gặp
                                            vấn đề khác vui lòng gửi câu hỏi mới</span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td class="c-r">
                    </td>
                </tr>
                <tr>
                    <td class="b-l">
                    </td>
                    <td class="b-c">
                    </td>
                    <td class="b-r">
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <table width="100%" border="0" cellpadding="5" cellspacing="0">       
        <tr>
            <td class="txt-from-taomoi" style="width: 186px">
            <div style="text-align:center;">
                 <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </div>
                <asp:Label ID="Label4" runat="server" Text="Trả lời :"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="txt-from-taomoi">
                <telerik:RadEditor ID="txtRadShort" Skin="Default" runat="server" DeleteFlashPaths="~/UserFile/Media"
                    DeleteImagesPaths="~/UserFile/Images" DeleteMediaPaths="~/UserFile/Media" FlashPaths="~/UserFile/Media"
                    Height="200px" ImagesPaths="~/UserFile/Images" MediaPaths="~/UserFile/Media"
                    ToolsFile="~/RadControls/Editor/small.xml" UploadFlashPaths="~/UserFile/Media"
                    UploadImagesPaths="~/UserFile/Images" UploadMediaPaths="~/UserFile/Media" Width="450px"
                    ShowSubmitCancelButtons="False" DeleteDocumentsPaths="~/UserFile/Files" DocumentsPaths="~/UserFile/Files"
                    MaxDocumentSize="51200000" UploadDocumentsPaths="~/UserFile/Files" ShowHtmlMode="False"
                    ShowPreviewMode="False">
                </telerik:RadEditor>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRadShort"
                    ErrorMessage="RequiredFieldValidator">* Chưa nhập nội dung</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="txt-from-taomoi" style="width: 186px">
                <asp:Label ID="Label6" runat="server" Text="Tệp tin đính kèm"></asp:Label></td>
            <td>
                <asp:FileUpload ID="file_Attach" runat="server" Width="301px" Enabled="true" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="file_Attach"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((rar)|(zip)|(doc)|(docx)|(xls)|(xlsx)|(pdf))$">.rar,.zip,.doc,docx,xls,xlsx,pdf</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td class="txt-from-taomoi" style="width: 186px; height: 32px;">
                <asp:Label ID="Label11" runat="server" Text="Hình ảnh đính kèm "></asp:Label></td>
            <td style="height: 32px">
                <asp:FileUpload ID="image_Attach" runat="server" Width="301px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="image_Attach"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td class="txt-from-taomoi" style="width: 186px">
            </td>
            <td>
                <asp:Button ID="btnSend" runat="server" Text="Gửi" OnClick="btnSend_Click" Width="58px" />
                <asp:Button ID="btnCancel" runat="server" Text="Huỷ bỏ" /></td>
        </tr>
    </table>
    <asp:HiddenField ID="HiddenField_QuestionID" runat="server" />
    <asp:HiddenField ID="HiddenField_ImageAttach" runat="server" />
    <asp:HiddenField ID="HiddenField_FileAttach" runat="server" />
    <asp:HiddenField ID="HiddenField_QuestionStatus" runat="server" />
    <asp:HiddenField ID="HiddenField_CreateDate" runat="server" />
    <asp:HiddenField ID="HiddenField_CateNewsID" runat="server" />
    <asp:HiddenField ID="HiddenField_Question_Title" runat="server" />
    <asp:HiddenField ID="HiddenField_CreateUserName" runat="server" />
</div>
<!-- end container_ListProduct -->
