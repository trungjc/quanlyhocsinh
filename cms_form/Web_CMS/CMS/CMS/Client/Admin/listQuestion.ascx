<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listQuestion.ascx.cs"
    Inherits="CMS.Client.Admin.listQuestion" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div class="container_ListProduct">
    <div style="padding: 10px;">
        <span style="font-weight: bold; font-size: 10pt;">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </span>
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
			                    Gửi yêu cầu
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
            OnRowCommand="grvListQuestion_RowCommand" PageSize="20">
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
                    <HeaderStyle HorizontalAlign="Center" Width="115px" />
                </asp:BoundField>
                <asp:BoundField DataField="CateNewsName" HeaderText="Gửi đến">
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="QuestionStatus" HeaderText="Trạng thái">
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Chức năng">
                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                    <ItemTemplate>
                        <asp:ImageButton ID="btn_unLockQuestion" runat="server" CommandName="_unLockQuestion"
                            CommandArgument='<%# Eval("Question_ID") %>' ImageUrl="~/images/Admin_Theme/images/unlock.jpeg"
                            ToolTip="Mở khoá" />
                        <asp:ImageButton ID="btn_lockQuestion" runat="server" CommandName="_lockQuestion"
                            CommandArgument='<%# Eval("Question_ID") %>' ImageUrl="~/images/Admin_Theme/images/lock.jpeg"
                            ToolTip="Khoá" />
                        <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Question_ID") %>'
                            ImageUrl="~/images/Admin_Theme/images/btn_edit.jpg" ToolTip="Sửa câu hỏi" />&nbsp;
                        <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Question_ID") %>'
                            ImageUrl="~/images/Admin_Theme/images/btn_delete.gif" ToolTip="Xóa ???" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                        Width="70px" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle HorizontalAlign="Right" />
            <EmptyDataTemplate>
                Chưa có dữ liệu
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</div>
<!-- end container_ListProduct -->
