<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Medi_ApGiaDoiTuong.ascx.cs"
    Inherits="CMS.Client.Admin.Medi_ApGiaDoiTuong" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    //attempting to capture keypress for chrome here but this is not working
    $("#TxtTimKiem").keypress(function (e) {
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
<style type="text/css">
    .RadMenu_Default .rmLink:hover
    {
        cursor: pointer;
    }
</style>
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <div style="width: 800px !important; margin: auto;">
      <table width="100%" style="margin: 10px;" border="0" cellspacing="0" cellpadding="0">
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
        <table width="100%" cellpadding="5">
            <tr>
                <td style="width: 800px; text-align: right;" align="center" class="txt-from-taomoi">
                    <telerik:RadButton ID="RadButton_Back" runat="server" Text="Quay lại" OnClick="btnBack_Click"
                        Visible="false">
                        <Icon PrimaryIconCssClass="rbCancel" PrimaryIconLeft="4" PrimaryIconTop="3"></Icon>
                    </telerik:RadButton>
                    <telerik:RadButton ID="RadButton_ApGia" runat="server" Text="Áp giá" RenderMode="Classic"
                        OnClick="btnApGia_Click">
                        <Icon PrimaryIconCssClass="rbAdd" PrimaryIconLeft="4" PrimaryIconTop="3"></Icon>
                    </telerik:RadButton>
                    <telerik:RadButton ID="RadButton_Save" runat="server" Text="Lưu áp giá" RenderMode="Classic"
                        OnClick="btnApGiaSaVe_Click">
                        <Icon PrimaryIconCssClass="rbAdd" PrimaryIconLeft="4" PrimaryIconTop="3"></Icon>
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="thongbao" Text="Áp giá thành công" ForeColor="Green"
                        Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="txt-from-taomoi" style="border-style: solid; border-color: rgb(207, 194, 237);
                    border-width: 1px; width: 850px;">
                    <h3>
                        Áp giá dối tượng:
                        <asp:Label runat="server" ID="Text_apgia" Text="Có bảo hiểm" ForeColor="Green"></asp:Label>
                    </h3>
                </td>
            </tr>
            <tr>
                <td align="center" class="txt-from-taomoi" style="border-style: solid; border-color: rgb(207, 194, 237);
                    border-width: 1px; width: 850px;">
                    <h3 style="border-color: Blue;" height="150px;">
                        Lịch sử áp giá
                    </h3>
                    <telerik:RadGrid ID="Grid_LichSu" runat="server" CssClass="RadGrid" GridLines="None"
                        EnableEmbeddedSkins="true" Skin="Silk" AllowPaging="True" PageSize="5" AllowSorting="True"
                        AutoGenerateColumns="False" ShowStatusBar="true" AllowAutomaticDeletes="True"
                        AllowAutomaticInserts="True" OnItemCommand="RadGrid1_ItemCommand" AllowAutomaticUpdates="True"
                        SelectedItemStyle-CssClass="SelectedStyle" OnPageIndexChanged="Pageindex_change"
                        PagerStyle-PageSizeLabelText="Kích thước trang" PagerStyle-PagerTextFormat="Trang: {4} &amp;nbsp;Trang số {0} / {1}.Dòng từ {2} --&gt; {3} /tổng số {5}.">
                        <MasterTableView DataKeyNames="ID" InsertItemPageIndexAction="ShowItemOnCurrentPage"
                            NoMasterRecordsText="Chưa có lịch sử cập nhật giá">
                            <Columns>
                                <telerik:GridBoundColumn DataField="Thoi_Gian" HeaderText="Thời gian" AllowSorting="false"
                                    DataFormatString="{0:hh:mm dd/MM/yy}">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Admin_FullName" HeaderText="Người cập nhật" AllowSorting="false">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Ly_Do" HeaderText="Lý do cập nhật" AllowSorting="false">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="true"></Selecting>
                            <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                        </ClientSettings>
                        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                    </telerik:RadGrid>
                </td>
            </tr>
            <asp:Panel runat="server" ID="thongTinEdit" Visible="false">
                <tr>
                    <td align="center" class="txt-from-taomoi" style="border-style: solid; border-color: rgb(207, 194, 237);
                        border-width: 1px; width: 850px;">
                        <h3>
                            Người sửa:
                            <asp:Label runat="server" ID="NguoiSua" ForeColor="Green"></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="txt-from-taomoi" style="border-style: solid; border-color: rgb(207, 194, 237);
                        border-width: 1px; width: 850px;">
                        <h3>
                            Lý do sửa
                            <asp:TextBox runat="server" ID="lydo"></asp:TextBox>
                        </h3>
                    </td>
                </tr>
            </asp:Panel>
            <tr>
                <asp:Panel runat="server" ID="TimKiem">
                    <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                        width: 850px;" align="center" class="txt-from-taomoi">
                        Loại xét nghiệm :
                        <asp:TextBox runat="server" ID="TxtTimKiem"></asp:TextBox>
                        <telerik:RadButton ID="RadButtonLamMoi" runat="server" Text="Làm mới" OnClick="RadButtonLamMoi_Click">
                            <Icon PrimaryIconCssClass="rbRefresh" SecondaryIconRight="4" SecondaryIconTop="3">
                            </Icon>
                        </telerik:RadButton>
                        <telerik:RadButton ID="RadButton_Timkiem" runat="server" Text="Search" OnClick="RadButton_Timkiem_Click">
                            <Icon PrimaryIconCssClass="rbSearch" SecondaryIconRight="4" SecondaryIconTop="3">
                            </Icon>
                        </telerik:RadButton>
                    </td>
                </asp:Panel>
            </tr>
            <tr>
                <td style="border-style: solid; border-color: rgb(207, 194, 237); border-width: 1px;
                    width: 850px;" align="center" class="txt-from-taomoi">
                    <telerik:RadGrid ID="DanhMuc" runat="server" CssClass="RadGrid" GridLines="None"
                        EnableEmbeddedSkins="true" Skin="Silk" AllowPaging="True" PageSize="20" AllowSorting="True"
                        AutoGenerateColumns="False" ShowStatusBar="true" AllowAutomaticDeletes="True"
                        AllowAutomaticInserts="True" OnPageIndexChanged="Pageindex_change_DanhMuc" AllowAutomaticUpdates="True"
                        SelectedItemStyle-CssClass="SelectedStyle" PagerStyle-PageSizeLabelText="Kích thước trang"
                        PagerStyle-PagerTextFormat="Trang: {4} &amp;nbsp;Trang số {0} / {1}.Dòng từ {2} --&gt; {3} /tổng số {5}.">
                        <HeaderContextMenu EnableTheming="True" Skin="Default">
                            <CollapseAnimation Type="OutQuint" Duration="100"></CollapseAnimation>
                        </HeaderContextMenu>
                        <MasterTableView DataKeyNames="ID" InsertItemPageIndexAction="ShowItemOnCurrentPage"
                            NoMasterRecordsText="Chưa có loaị xét nghiệm nào">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="TenLoaiXN" HeaderText="Tên loại xét nghiệm" AllowSorting="false">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Đơn vị (VNĐ)">
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ShowSpinButtons="false" IncrementSettings-InterceptArrowKeys="true"
                                            IncrementSettings-InterceptMouseWheel="false" Width="100px" ID="txt_tien" runat="server"
                                            Text='<%#Bind("Money") %>'>
                                            <NumberFormat AllowRounding="True" KeepNotRoundedValue="False"></NumberFormat>
                                        </telerik:RadNumericTextBox>
                                        <%--   <asp:RegularExpressionValidator ID="RegularCert" runat="server" ControlToValidate="txt_tien"
                                            ErrorMessage="Sai định dạng" ValidationExpression="^\d{0,9}$" Display="Dynamic"
                                            ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Đơn vị (VNĐ)">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbltien" Text='<%#Bind("Money","{0:n}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="false">
                            <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                        </ClientSettings>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
</div>
