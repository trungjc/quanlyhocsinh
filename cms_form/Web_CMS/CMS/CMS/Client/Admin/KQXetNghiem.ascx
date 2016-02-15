<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KQXetNghiem.ascx.cs"
    Inherits="CMS.Client.Admin.KQXetNghiem" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    //attempting to capture keypress for chrome here but this is not working
    $("#TuKhoa").keypress(function (e) {
        if (e.keyCode == '13') {
            e.preventDefault();
            doClick(buttonname, e);
            return false;
        }
    });

    function doClick(buttonName, e) {

        var key;
        if (window.event)
            key = window.event.keyCode;     //IE
        else
            key = e.which;     //firefox

        if (key == 13) {
            var btn = document.getElementById(buttonName);
            if (btn != null) {
                btn.click();
                event.keyCode = 0
            }
        }
    }
</script>
<style type="text/css">
    div.RadGrid .rgPager .rgAdvPart
    {
        display: none;
    }
</style>
<style type="text/css">
    div.AddBorders .rgHeader, div.AddBorders th.rgResizeCol, div.AddBorders .rgFilterRow td, div.AddBorders .rgRow td, div.AddBorders .rgAltRow td, div.AddBorders .rgEditRow td, div.AddBorders .rgFooter td
    {
        border-style: solid;
        border-color: #aaa;
        border-width: 0 0 1px 1px; /*top right bottom left*/
    }
    
    div.AddBorders .rgHeader:first-child, div.AddBorders th.rgResizeCol:first-child, div.AddBorders .rgFilterRow td:first-child, div.AddBorders .rgRow td:first-child, div.AddBorders .rgAltRow td:first-child, div.AddBorders .rgEditRow td:first-child, div.AddBorders .rgFooter td:first-child
    {
        border-left-width: 0;
    }
</style>
<style type="text/css">
    .dk_form
    {
        border-bottom: 1px dotted #d1d1d1;
    }
    .dk_form div
    {
        padding-left: 0 !important;
        padding-right: 0 !important;
        margin-top: 3px !important;
        margin-bottom: 3px !important;
    }
    .control_value
    {
        margin-top: 2px;
    }
    .dk_content_right .dk_title
    {
        margin-left: 5px;
    }
    .Textchung
    {
        padding-right: 29px;
    }
    .Textchung_Bacode
    {
        padding-right: 13px;
    }
    .Textchung_DiaChi
    {
        padding-right: 85px;
    }
    .Textchung_Drop
    {
        padding-right: 22px;
    }
    .Textchung_Drop_Datem
    {
        padding-right: 73px;
    }
    .Textchung_Time
    {
        padding-right: 2px;
    }
    .Buttuon_Search
    {
        padding-right: 2px;
        left: 60%;
    }
    .Buttuon
    {
        padding-right: 2px;
        left: 58%;
    }
    .Buttuon_SearchNC
    {
        padding-right: 2px;
        left: 82%;
    }
    .ButtuonNC
    {
        padding-right: 2px;
        left: 80%;
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
                            </tr>
                        </tbody>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="5">
        <tr>
            <td style="width: 800px; text-align: right;" align="center" class="txt-from-taomoi">
                <telerik:RadButton ID="RadButton_TongPhieu" runat="server" Text="Phiếu chưa xác nhận"
                    OnClick="btnTongPhieu_Click">
                    <Icon SecondaryIconUrl="images/eFind.png" SecondaryIconRight="4" SecondaryIconTop="4">
                    </Icon>
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td align="center" class="txt-from-taomoi" style="border-style: solid; border-color: rgb(207, 194, 237);
                border-width: 1px; width: 850px;">
                <telerik:RadTabStrip runat="server" ID="RadTabStrip1" SelectedIndex="0" MultiPageID="RadMultiPage1"
                    CssClass="tabs">
                    <Tabs>
                        <telerik:RadTab Text="tìm kiếm cơ bản">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Tìm kiếm nâng cao">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <div>
                    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="multiPage">
                        <telerik:RadPageView runat="server" ID="RadPageView1">
                            <table>
                                <tr>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 3200px;" align="center" class="txt-from-taomoi">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="TuKhoa_Label" Text="Từ khóa" CssClass="Textchung"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TuKhoa"></asp:TextBox>
                                                    (Mã phiếu, mã barcode,tên khách hàng,bảo hiểm, địa chỉ)
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 850px;" align="center" class="txt-from-taomoi">
                                        <asp:Label runat="server" ID="Label1" Text="Đối tượng" CssClass="Textchung_Drop"></asp:Label>
                                        <asp:DropDownList runat="server" ID="Drop_DoiTuong_CB">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 850px;" align="center" class="txt-from-taomoi">
                                        <asp:Label runat="server" ID="Label2" Text="Trạng thái" CssClass="Textchung_Drop"></asp:Label>
                                        <asp:DropDownList runat="server" ID="Drop_TrangThai_CB">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <telerik:RadButton ID="RadButton_Resert" runat="server" Text="Làm mới" OnClick="btn_LamMoi"
                                            CssClass="Buttuon">
                                            <Icon PrimaryIconCssClass="rbRefresh" SecondaryIconRight="4" SecondaryIconTop="3">
                                            </Icon>
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="RadButtonTimKiem" runat="server" Text="Tìm Kiếm" RenderMode="Classic"
                                            CssClass="Buttuon_Search" OnClick="btnTimKiem_Click">
                                            <Icon PrimaryIconCssClass="rbSearch" SecondaryIconRight="4" SecondaryIconTop="3">
                                            </Icon>
                                        </telerik:RadButton>
                                        <asp:Button runat="server" ID="Demo" Text="Demo" OnClick="DemoClick" />
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView runat="server" ID="RadPageView2">
                            <table>
                                <tr>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 850px;" align="center" class="txt-from-taomoi">
                                        Thông tin phiếu
                                    </td>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 850px;" align="center" class="txt-from-taomoi">
                                        Thông tin khách hàng
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 850px;" align="center" class="txt-from-taomoi">
                                        <asp:Label runat="server" ID="Label3" Text=" Mã phiếu" CssClass="Textchung"></asp:Label>
                                        <asp:TextBox runat="server" ID="MaPhieu"></asp:TextBox>
                                    </td>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 850px;" align="center" class="txt-from-taomoi">
                                        <asp:Label runat="server" ID="Label4" Text="Tên khách hàng" CssClass="Textchung"></asp:Label>
                                        <asp:TextBox runat="server" ID="TenKhachHang"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 850px;" align="center" class="txt-from-taomoi">
                                        <asp:Label runat="server" ID="Label5" Text="Mã Barcode" CssClass="Textchung_Bacode"></asp:Label>
                                        <asp:TextBox runat="server" ID="MaBaCode"></asp:TextBox>
                                    </td>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 850px;" align="center" class="txt-from-taomoi">
                                        <asp:Label runat="server" ID="Label6" Text="Sổ bảo hiểm thẻ" CssClass="Textchung"></asp:Label>
                                        <asp:TextBox runat="server" ID="TheBH"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 850px;" align="center" class="txt-from-taomoi">
                                        <asp:Label runat="server" ID="Label7" Text="Đối tượng" CssClass="Textchung_Drop"></asp:Label>
                                        <asp:DropDownList runat="server" ID="Drop_doiTuong_NC">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 850px;" align="center" class="txt-from-taomoi">
                                        <asp:Label runat="server" ID="Label8" Text=" Địa chỉ" CssClass="Textchung_DiaChi"></asp:Label>
                                        <asp:TextBox runat="server" ID="DiaChi"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                                        width: 850px;" align="center" class="txt-from-taomoi">
                                        <asp:Label runat="server" ID="Label9" Text="Trạng thái" CssClass="Textchung_Drop"></asp:Label>
                                        <asp:DropDownList runat="server" ID="TrangThai_NC">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Label runat="server" ID="Label10" Text="Đăng ký từ ngày" CssClass="Textchung_Time"></asp:Label>
                                        <telerik:RadDatePicker ID="txtBatDau" runat="server">
                                            <DateInput DateFormat="dd/MM/yyyy">
                                            </DateInput>
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ForeColor="Red" runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtBatDau"
                                            ErrorMessage="Sai định dạng!" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Label runat="server" ID="Label11" Text="đến" CssClass="Textchung_Drop_Datem"></asp:Label>
                                        <telerik:RadDatePicker ID="txtKetThuc" runat="server">
                                            <DateInput DateFormat="dd/MM/yyyy">
                                            </DateInput>
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ForeColor="Red" runat="server" ID="Requiredfieldvalidator2" ControlToValidate="txtKetThuc"
                                            ForeColor="Red" ErrorMessage="Sai định dạng!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <telerik:RadButton ID="RadButton_Resert_NC" runat="server" Text="Làm mới" OnClick="btn_LamMoi_NC"
                                            CssClass="ButtuonNC">
                                            <Icon PrimaryIconCssClass="rbRefresh" SecondaryIconRight="4" SecondaryIconTop="3">
                                            </Icon>
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="RadButtonTimKiem_NC" runat="server" Text="Tìm Kiếm" RenderMode="Classic"
                                            ValidationGroup="Save" CssClass="Buttuon_SearchNC" OnClick="btnTimKiem_Click_NC">
                                            <Icon PrimaryIconCssClass="rbSearch" SecondaryIconRight="4" SecondaryIconTop="3">
                                            </Icon>
                                        </telerik:RadButton>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <h3>
                    Danh sách phiếu xét nghiệm</h3>
            </td>
        </tr>
        <tr>
            <td style="width: 800px; text-align: right;" align="center" class="txt-from-taomoi">
                <telerik:RadButton ID="RadButton_Add" runat="server" Text="Đăng ký mới">
                    <Icon PrimaryIconCssClass="rbAdd" PrimaryIconLeft="4" PrimaryIconTop="3"></Icon>
                </telerik:RadButton>
                <telerik:RadButton ID="RadButton_Book" runat="server" Text="Book lịch" RenderMode="Classic">
                    <Icon PrimaryIconCssClass="rbAdd" PrimaryIconLeft="4" PrimaryIconTop="3"></Icon>
                </telerik:RadButton>
                <telerik:RadButton ID="RadButton_CapNhat" runat="server" Text="Cập nhật" RenderMode="Classic">
                    <Icon PrimaryIconCssClass="rbEdit" PrimaryIconLeft="4" PrimaryIconTop="3"></Icon>
                </telerik:RadButton>
                <telerik:RadButton ID="RadButton_Hoan" runat="server" Text="Hoãn" RenderMode="Classic">
                    <Icon PrimaryIconCssClass="rbAdd" PrimaryIconLeft="4" PrimaryIconTop="3"></Icon>
                </telerik:RadButton>
                <telerik:RadButton ID="RadButton_Huy" runat="server" Text="Hủy" RenderMode="Classic">
                    <Icon PrimaryIconCssClass="rbRemove" PrimaryIconLeft="4" PrimaryIconTop="3"></Icon>
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <%-- <table width="100%" border="0" cellspacing="0" cellpadding="5">
        <tr>
            <td align="center">
                <asp:GridView ID="grv_NhapKetQua" runat="server" AutoGenerateColumns="False" Width="100%"
                    OnRowCommand="grvPXN_RowCommand" CssClass="gridviewBorder" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnSelectedIndexChanged="grv_NhapKetQua_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="MaPhieu" HeaderText="Mã Phiếu">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                Width="31px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HoTen" HeaderText="Họ Tên KH">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tuoi" HeaderText="Tuổi">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SoDienThoai" HeaderText="Số điện thoại">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CreateDate" HeaderText="Ngày đăng ký">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ThoiGianToiKham" HeaderText="Ngày khám">
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Trạng thái">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:Label ID="lbl_TrangThai" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbl_value" runat="server" Text='<%# Eval("State") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("MaPhieu") %>'
                                    ImageUrl="~/images/Admin_Theme/images/btn_edit.png" />
                                &nbsp;
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="70px" />
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
    </table>--%>
</div>
<table>
    <tr>
        <td align="center">
            <telerik:RadGrid AutoGenerateColumns="False" ID="RadGrid1" runat="server" EnableEmbeddedSkins="true"
                Skin="Silk" CssClass="AddBorders" Width="100%" CellSpacing="0" GridLines="None"
                OnItemDataBound="grv_NhapKetQua_OnrowDataBound" PageSize="3" OnItemCommand="grv_NhapKetQua_ItemCommand"
                AllowSorting="True" AllowPaging="True" OnPageIndexChanged="Pageindex_change_DanhMuc"
                PagerStyle-PageSizeLabelText="Kích thước trang" PagerStyle-PagerTextFormat="Trang: {4} &amp;nbsp;Trang số {0} / {1}.Dòng từ {2} --&gt; {3} /tổng số {5}.">
                <MasterTableView TableLayout="Fixed" DataKeyNames="MaPhieu" NoMasterRecordsText="Chưa có loaị xét nghiệm nào"
                    InsertItemPageIndexAction="ShowItemOnCurrentPage">
                    <Columns>
                        <telerik:GridTemplateColumn DataField="MaPhieu" HeaderText="Mã phiếu" HeaderStyle-Width="80px">
                            <ItemTemplate>
                                <img src="/Images/demo.gif" alt="" style="vertical-align: middle; margin-right: 2px;" /><%# Eval("MaPhieu")%>
                            </ItemTemplate>
                            <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="MaBarCode" DataField="MaBarCode" UniqueName="DiaChi"
                            SortExpression="DiaChi" HeaderStyle-Width="100px" FilterControlWidth="80px" AutoPostBackOnFilter="true"
                            CurrentFilterFunction="Contains" ShowFilterIcon="false">
                            <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Họ Tên" DataField="HoTen" UniqueName="HoTen"
                            SortExpression="HoTen" HeaderStyle-Width="100px" FilterControlWidth="80px" AutoPostBackOnFilter="true"
                            CurrentFilterFunction="Contains" ShowFilterIcon="false">
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridDateTimeColumn DataField="CreateDate" HeaderText="Thời gian đăng ký"
                            FilterControlWidth="80px" SortExpression="CreateDate" PickerType="DatePicker"
                            EnableTimeIndependentFiltering="true" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                        </telerik:GridDateTimeColumn>
                        <telerik:GridDateTimeColumn DataField="ThoiGianToiKham" HeaderText="Thời gian  xét nghiệm"
                            FilterControlWidth="80px" SortExpression="ThoiGianToiKham" PickerType="DatePicker"
                            EnableTimeIndependentFiltering="true" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                        </telerik:GridDateTimeColumn>
                        <telerik:GridTemplateColumn HeaderText="Trạng thái" AllowFiltering="false">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lbl_TrangThai" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbl_value" runat="server" Text='<%# Eval("State") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Nhập kết quả">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ToolTip="Nhập kết quả" ID="btn_edit" runat="server" CommandName="_edit"
                                    CommandArgument='<%# Eval("MaPhieu") %>' ImageUrl="~/images/Admin_Theme/images/btn_edit.png" />
                                &nbsp;
                            </ItemTemplate>
                            <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                    <Selecting AllowRowSelect="true"></Selecting>
                    <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                </ClientSettings>
            </telerik:RadGrid>
        </td>
    </tr>
</table>
