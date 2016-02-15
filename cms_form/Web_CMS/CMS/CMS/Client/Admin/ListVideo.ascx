<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListVideo.ascx.cs" Inherits="CMS.Client.Admin.ListVideo" %>
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
                                    <asp:RadioButton runat="server" ID="Check_Viet" Text="Tiếng Việt" Checked="true"
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editvideo/Default.aspx">
			                    <span class="icon-32-publish" title="Đăng tin mới">
			                    </span>
			                    Tạo mới
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
    <table width="100%" border="0" cellspacing="0" cellpadding="10">
        <tr>
            <td>
                <asp:GridView ID="grvVideo" runat="server" AutoGenerateColumns="False" Width="100%"
                    OnRowCommand="grvVideo_RowCommand" OnRowDataBound="grvVideo_RowDataBound" CssClass="gridviewBorder">
                    <Columns>
                        <asp:BoundField DataField="VideoID" HeaderText="ID" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-Width="31" HeaderStyle-Height="22" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VideoName" HeaderText="T&#234;n h&#227;ng" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="300">
                            <ItemStyle HorizontalAlign="left" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VideoEmbed" HeaderText="Url" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="300">
                            <ItemStyle HorizontalAlign="left" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="Image" DataImageUrlFormatString="~/Upload/Video/{0}"
                            HeaderText="H&#236;nh ảnh" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="200px">
                            <ItemStyle HorizontalAlign="center" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:ImageField>
                        <asp:CheckBoxField DataField="IsHome" HeaderText="Trang chủ" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-Width="91" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="VideoType" HeaderText="Video File" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-Width="91" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:CheckBoxField>
                        <asp:TemplateField HeaderText="Chức năng" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"
                            HeaderStyle-Width="91" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("VideoID") %>'
                                    ImageUrl="~/images//Admin_Theme/images/btn_edit.png" />&nbsp;
                                <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("VideoID") %>'
                                    ImageUrl="~/images//Admin_Theme/images/btn_delete.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
