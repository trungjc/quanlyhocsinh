<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditAlbums.ascx.cs"
    Inherits="CMS.Client.Admin.EditAlbums" %>
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listalbumscate/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục tin">
			                                </span>
			                                Danh mục
                                    </asp:HyperLink>
                                </td>
                                <%--<td  id="Td1" style="text-align:center">
                                      <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editalbums/Default.aspx">
			                                <span class="icon-32-publish" title="Đăng tin mới">
			                                </span>
			                                Tạo mới
                                        </asp:HyperLink>
                			            
		                            </td>--%>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="toolbar" ToolTip="Đăng ảnh mới">
                                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-publish.png"
                                            OnClick="btn_edit_click" />
                                        <br />
                                        Đăng ảnh mới
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
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="txt-from-taomoi" align="center">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="6">
        <tr>
            <td class="txt-from-taomoi" width="65%" valign="top">
                <table width="100%" border="0" cellpadding="5" cellspacing="0">
                    <tr>
                        <td width="180" class="txt-from-taomoi">
                            <asp:Label ID="Label1" runat="server" Text="Lựa chọn danh mục Albums :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAlbumsCate" runat="server" Width="300px" AppendDataBoundItems="True"
                                OnSelectedIndexChanged="ddlAlbumsCate_SelectedIndexChanged" OnTextChanged="ddlAlbumsCate_TextChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi" style="height: 22px">
                            <asp:Label ID="Label3" runat="server" Text="Hình ảnh (ảnh nhỏ) :"></asp:Label>
                        </td>
                        <td style="height: 22px">
                            <asp:FileUpload ID="file_image_thumb" runat="server" Width="301px" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="file_image_thumb"
                                ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi" style="height: 22px">
                            <asp:Label ID="Label5" runat="server" Text="Hình ảnh (ảnh to) :"></asp:Label>
                        </td>
                        <td style="height: 22px">
                            <asp:FileUpload ID="file_image_large" runat="server" Width="301px" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="file_image_thumb"
                                ErrorMessage="RegularExpressionValidator" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(JPG)|(GIF)|(JPEG)|(PNG)|(BMP))$">.gif,.jpeg,.jpg,.png,.bmp</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label2" runat="server" Text="Tiêu đề ảnh (nếu có) :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label4" runat="server" Text="Mô tả ngắn gọn (nếu có) :"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="txt-from-taomoi">
                            <telerik:RadEditor ID="txtRadShort" runat="server" EnableEmbeddedSkins="true" Skin="Simple"
                                SkinID="BasicTools" ToolsFile="~/RadControls/Editor/BasicTools.xml" Height="200px"
                                Width="500px" EditModes="Design, Html">
                                <Content></Content>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="6" class="bg-line-cham" style="width: 400px;">
                    <tr>
                        <td class="txt-from-taomoi" style="width: 100px;">
                            <asp:Label ID="Label10" runat="server" Text="Loại tin"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbIshot" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                                CellSpacing="0">
                                <asp:ListItem Selected="True" Value="False">Kiểu thường</asp:ListItem>
                                <asp:ListItem Value="True">Kiểu hot</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label6" runat="server" Text="Ngày đăng :"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="txtRadDate" runat="server" Width="150px" Culture="Vietnamese (Vietnam)">
                                <DateInput runat="server" Width="80">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label7" runat="server" Text="Tác giả :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAuthor" runat="server" Width="140px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label8" runat="server" Text="Trạng thái :"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="True">Hiển thị</asp:ListItem>
                                <asp:ListItem Value="False">Ẩn</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="txt-from-taomoi">
                            <asp:Label ID="Label9" runat="server" Text="Hiển thị"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdbIshome" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                                CellSpacing="0">
                                <asp:ListItem Value="False">Trang thường</asp:ListItem>
                                <asp:ListItem Selected="True" Value="True">Trang chủ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="txt-from-taomoi" ><asp:Label ID="Label12" runat="server" Text="Đăng Nhận xét (Comment)"></asp:Label></td>
                        <td>
                            <asp:RadioButtonList ID="rdbComment" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" >
                                <asp:ListItem Value="False">Không đăng Comment</asp:ListItem>
                                <asp:ListItem Selected="True" Value="True">Đăng Comment</asp:ListItem>
                            </asp:RadioButtonList></td>
                        </tr>
                        
                        
                        <tr>
                        <td class="txt-from-taomoi" ><asp:Label ID="Label13" runat="server" Text="Duyệt bài"></asp:Label></td>
                        <td>
                            <asp:RadioButtonList ID="rdbApproval" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" >
                                <asp:ListItem Value="False">Chưa duyệt</asp:ListItem>
                                <asp:ListItem Selected="True" Value="True">Duyệt bài</asp:ListItem>
                            </asp:RadioButtonList></td>
                        </tr>--%>
                </table>
            </td>
            <td align="left" valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvAlbum" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            Width="100%" OnPageIndexChanging="grvAlbum_PageIndexChanging" OnRowCommand="grvAlbum_RowCommand"
                            OnRowDataBound="grvAlbum_RowDataBound" CssClass="gridviewBorder" CellPadding="4"
                            ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:BoundField DataField="AlbumsID" HeaderText="ID" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                                    HeaderStyle-Width="30" HeaderStyle-Height="22" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                </asp:BoundField>
                                <asp:ImageField DataImageUrlField="ImageThumb" DataImageUrlFormatString="~/Upload/Albums/AlbumsImg/ImgThumb/{0}"
                                    HeaderText="H&#236;nh ảnh" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                                    HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="75px">
                                    <ItemStyle HorizontalAlign="center" CssClass="gridviewCellBottom gridviewCellRight" />
                                </asp:ImageField>
                                <asp:TemplateField HeaderText="Chức năng " HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                                    HeaderStyle-Width="60" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("AlbumsID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa ảnh" />&nbsp;
                                        <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("AlbumsID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <div class="loading">
                            <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1"
                                DynamicLayout="True">
                                <ProgressTemplate>
                                        <img src="../../../../Images/icons/loading.gif" alt="Đang tải dữ liệu..." />
                                        <span>Đang tải dữ liệu...</span>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddAlbumID" runat="server" />
<asp:HiddenField ID="hddAlbumsCateID" runat="server" />
<asp:HiddenField ID="hddImageLarge" runat="server" />
<asp:HiddenField ID="hddImageThumb" runat="server" />
<asp:HiddenField ID="hddCommentTotal" runat="server" />
<asp:HiddenField ID="hddIsView" runat="server" />
<asp:HiddenField ID="hddCreateUserName" runat="server" />
<asp:HiddenField ID="hddApprovalUserName" runat="server" />
<asp:HiddenField ID="hddApprovalDate" runat="server" />
<asp:HiddenField ID="hddIsApproval" runat="server" />
<asp:HiddenField ID="hddIsComment" runat="server" />
