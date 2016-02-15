<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListModulesFrontPanel.ascx.cs" Inherits="CMS.Client.Admin.ListModulesFrontPanel" %>
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr align="right">
            <td style="width: 40%;">
                <div class="toolbar">
                    <table class="toolbar">
                        <tbody>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </td>
            <td style="width: 18%;">
                <div class="toolbar">
                    <table class="toolbar">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:RadioButton runat="server" ID="Check_Viet" Checked="true" Text="Tiếng Việt"
                                        GroupName="Check" AutoPostBack="true" OnCheckedChanged="Viet_Check"  />
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RadioButton runat="server" ID="Check_Eng" Text="English" GroupName="Check" AutoPostBack="true"  OnCheckedChanged="Eng_Check"  />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </td>
            <td style="width: 42%;">
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editmodulesfrontpanel/Default.aspx">
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
            <td align="center">
                <div style="text-align: center; height: 30px; vertical-align: middle;">
                    <asp:RadioButtonList ID="rdbPanel" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                        OnSelectedIndexChanged="rdbPanel_SelectedIndexChanged" RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="All">Tất cả</asp:ListItem>
                        <asp:ListItem Value="Left">LeftPanel</asp:ListItem>
                        <asp:ListItem Value="Right">RightPanel</asp:ListItem>
                        <asp:ListItem Value="Main">MainPanel</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                    OnRowDataBound="GridView1_RowDataBound" Width="100%" OnRowDeleting="GridView1_RowDeleting"
                    CssClass="gridviewBorder" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="ModulesFrontPanel_ID" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ModulesFrontPanel_Parent" HeaderText="Cấp độ">
                            <ItemStyle HorizontalAlign="Center" Width="20px" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Sắp xếp">
                            <ItemStyle HorizontalAlign="Center" Width="30px" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtModulesFrontPanelOrder"
                                    Width="10px">*</asp:RequiredFieldValidator>&nbsp;
                                <asp:TextBox ID="txtModulesFrontPanelOrder" runat="server" Width="20px" Text='<%# Eval("ModulesFrontPanel_Order")%>'
                                    MaxLength="2"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtModulesFrontPanelOrder"
                                    MaximumValue="100" MinimumValue="0" Type="Integer" Width="10px">*</asp:RangeValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ModulesFrontPanel_Name" HeaderText="T&#234;n modules">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ModulesFrontPanel_Url" HeaderText="Đường dẫn">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ModulesFrontPanel_Title" HeaderText="Tiêu đề Modules">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ModulesFrontPanel_Panel" HeaderText="Panel">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ModulesFrontPanel_Value" HeaderText="Giá trị">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="80px" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="ModulesFrontPanel_Icon" DataImageUrlFormatString="~/Upload/Admin_Theme/Icons/{0}"
                            HeaderText="Icon" ControlStyle-Width="32px">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="80px" />
                        </asp:ImageField>
                        <asp:CheckBoxField DataField="ModulesFrontPanel_Status" HeaderText="Trạng th&#225;i">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="60px" />
                        </asp:CheckBoxField>
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_edit" runat="server" CommandName="edit" CommandArgument='<%# Eval("ModulesFrontPanel_ID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa" />&nbsp;
                                <asp:ImageButton ID="btn_delete" runat="server" CommandName="delete" CommandArgument='<%# Eval("ModulesFrontPanel_ID") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="50px" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" HorizontalAlign="Center" CssClass="pagination-ys" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
