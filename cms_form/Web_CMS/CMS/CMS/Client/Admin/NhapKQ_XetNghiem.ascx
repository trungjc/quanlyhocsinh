<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NhapKQ_XetNghiem.ascx.cs"
    Inherits="CMS.Client.Admin.NhapKQ_XetNghiem" %>
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <div style="width: 800px !important; margin: auto;">
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
                                        <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/KQXetNghiem/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
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
        <table width="100%">
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th style="text-align: center; width: 600px;">
                    <h2>
                        Thông tin khách hàng</h2>
                </th>
                <th style="color: #0011AD;">
                    Mã phiếu:<asp:Label ID="lbl_MaPhieu" runat="server"></asp:Label>
                </th>
            </tr>
        </table>
        <table width="100%" style="margin-bottom: 20px;">
            <tr>
                <td style="text-align: left; width: 100px; font-weight: bold;">
                    Họ tên:
                </td>
                <td>
                    <asp:Label ID="lbl_HoTen" runat="server"></asp:Label>
                </td>
                <td style="text-align: left; width: 100px; font-weight: bold;">
                    Giới tính:
                </td>
                <td>
                    <asp:Label ID="lbl_GioiTinh" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; width: 100px; font-weight: bold;">
                    Tuổi:
                </td>
                <td>
                    <asp:Label ID="lbl_Tuoi" runat="server"></asp:Label>
                </td>
                <td style="text-align: left; width: 100px; font-weight: bold;">
                    Số điện thoại:
                </td>
                <td>
                    <asp:Label ID="lbl_SDT" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; width: 100px; font-weight: bold;">
                    Ngày khám:
                </td>
                <td>
                    <asp:Label ID="lbl_NgayKham" runat="server"></asp:Label>
                </td>
                <td style="text-align: left; width: 100px; font-weight: bold;">
                    Ngày đăng ký:
                </td>
                <td>
                    <asp:Label ID="lbl_NgayDangKy" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div>
            <asp:FileUpload runat="server" ID="fuSample" />
        </div>
        <div style="color: Blue;">
            <%= this.InputValue %></div>
        <h2 align="center" style="margin-top: 20px;">
            Kết quả xét nghiệm</h2>
        <asp:Panel ID="pn_PDF" Visible="false" runat="server">
            <object data="../../../<%= this.InputValue %>" type="application/pdf" width="800"
                height="880">
            </object>
        </asp:Panel>
    </div>
</div>
