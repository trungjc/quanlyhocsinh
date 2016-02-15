<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListCateNewsGroup.ascx.cs"
    Inherits="CMS.Client.Admin.ListCateNewsGroup" %>
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right" width="30%">
                <div class="toolbar" id="Div1">
                    <table class="toolbar">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:RadioButton runat="server" ID="Check_Viet" Text="Tiếng Việt" GroupName="Check"
                                        AutoPostBack="true" OnCheckedChanged="Viet_Check" Checked="true" />
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RadioButton runat="server" ID="Check_Eng" Checked="false" Text="English" GroupName="Check"
                                        AutoPostBack="true" OnCheckedChanged="Eng_Check" />
                                </td>
                            </tr>
                        </tbody>
                    </table>                    
                </div>
            </td>
            <td align="right" width="70%">
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editcatenewsgroup/Default.aspx">
                                    <span class="icon-32-publish" title="Đăng tin mới">
                                    </span>
                                    Tạo mới
                                    </asp:HyperLink>
                                </td>
                                <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="btn_Order" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"
                                            OnClick="btn_Order_Click" />
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
    <table width="100%" border="0" cellspacing="0" cellpadding="5">
        <tr>
            <td valign="top" align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="grvCateNewsGroup" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="True" OnPageIndexChanging="grvCateNewsGroup_PageIndexChanging" OnRowCommand="grvCateNewsGroup_RowCommand"
                    OnRowDataBound="grvCateNewsGroup_RowDataBound" CssClass="gridviewBorder" PageSize="50"
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="CateNewsGroupID">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                Width="31px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Sắp xếp">
                            <ItemStyle HorizontalAlign="Center" Width="60px" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOrder"
                                    Width="10px">*</asp:RequiredFieldValidator>&nbsp;
                                <asp:TextBox ID="txtOrder" runat="server" Width="20px" Text='<%# Eval("Order")%>'
                                    MaxLength="2"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtOrder"
                                    MaximumValue="100" MinimumValue="0" Type="Integer" Width="10px">*</asp:RangeValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CateNewsGroupName" HeaderText="Tên nhóm danh mục">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GroupCate" HeaderText="Value">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="90px" />
                        </asp:BoundField>
                        <asp:CheckBoxField DataField="IsView" HeaderText="Hiển thị">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="35px" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="IsHome" HeaderText="Home">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="35px" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="IsMenu" HeaderText="Menu">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="35px" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="IsNew" HeaderText="Menu bottom">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="35px" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="IsPage" HeaderText="Page">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="35px" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="IsUrl" HeaderText="Url">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="35px" />
                        </asp:CheckBoxField>
                        <asp:BoundField DataField="Position" HeaderText="Position">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="50px" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="Icon" DataImageUrlFormatString="~/Upload/Category/Group/{0}"
                            HeaderText="Icon" ControlStyle-Width="48px">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="60px" />
                        </asp:ImageField>
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("CateNewsGroupID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa nhóm danh mục" />&nbsp;
                                <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("CateNewsGroupID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="90px" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" CssClass="pagination-ys" />
                    <RowStyle BackColor="#EFF3FB" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
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
                        </div></ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</div>
