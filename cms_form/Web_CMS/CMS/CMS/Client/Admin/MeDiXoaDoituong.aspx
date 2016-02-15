<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeDiXoaDoituong.aspx.cs"
    Inherits="CMS.Client.Admin.MeDiXoaDoituong" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Xóa đối tượng </title>
    <style type="text/css">
        .Grid
        {
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Calibri;
            color: #474747;
        }
        .Grid td
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
        }
        .Grid th
        {
            padding: 4px 2px;
            color: #fff;
            background: #90D498 url(Images/grid-header.png) repeat-x top;
            border-left: solid 1px #525252;
            font-size: 0.9em;
        }
        .Grid .alt
        {
            background: #fcfcfc url(Images/grid-alt.png) repeat-x top;
        }
        .Grid .pgr
        {
            background: #363670 url(Images/grid-pgr.png) repeat-x top;
        }
        .Grid .pgr table
        {
            margin: 3px 0;
        }
        .Grid .pgr td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        .Grid .pgr a
        {
            color: Gray;
            text-decoration: none;
        }
        .Grid .pgr a:hover
        {
            color: #000;
            text-decoration: none;
        }
        .Back
        {
            border: -4px groove #174f88;
            box-shadow: 0 1px 2px 0 #66b2d2 inset;
            min-width: 78px;
        }
    </style>
    <script type="text/javascript">
        function CloseAndRebind() {
            try {
                GetRadWindow().BrowserWindow.refreshGridHSCV(); // Call the function in parent page                    
                //GetRadWindow().close(); // Close the window
            } catch (e) {
                alert(e);
            }
        }

    </script>
    <script type="text/javascript">
        function GetRadWindow() {
            try {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog 
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well) 

                return oWindow;
            } catch (e) {
                alert(e);
                return null;
            }
        }
        function confixoa() {
            submitFormOkay = true;
            return confirm("Bạn có chắc chắn muốn xóa đối tượng này");
        }

    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width: 100% !important; margin: calc();">
            <table>
                <tr>
                    <td align="center">
                        <div class="toolbar" id="toolbar">
                            <table>
                                <asp:Label ID="ThongBao" runat="server" Text="Thong báo"></asp:Label>
                            </table>
                            <br />
                            <table>
                                <asp:LinkButton runat="server" ID="Btn_Chitiet" Text="Danh sách phiếu xét nghiệm"
                                    OnClick="Btn_ChiTiet"></asp:LinkButton>
                            </table>
                            <br />
                            <table>
                                <tr>
                                    <asp:Panel runat="server" ID="Danhmuc" Visible="false">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="DanhMucPhieu" AutoGenerateColumns="False" CssClass="Grid" Width="100%"
                                                    runat="server" OnPageIndexChanging="gvChiTieu_PageIndexChanging" PageSize="5"
                                                    OnRowCommand="gvUserManager_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Người đăng ký" DataField="HoTen" Visible="true" HeaderStyle-Font-Bold="true"
                                                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-VerticalAlign="Middle" />
                                                        <asp:BoundField HeaderText="SĐT" DataField="SoDienThoai" HeaderStyle-Font-Bold="true"
                                                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-VerticalAlign="Middle" />
                                                    </Columns>
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
                                    </asp:Panel>
                                </tr>
                                <tr style="text-align: center;">
                                    <td>
                                        <asp:Button runat="server" ID="Btn_Thoat" Height="30px" Width="80px" ForeColor="blue"
                                            Text="Thoát" OnClick="btnBack_Click" />
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="Btn_Save" Height="30px" Width="80px" ForeColor="blue"
                                            OnClick="btnSave_Click" Text="Đồng ý" OnClientClick="return confixoa()" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
