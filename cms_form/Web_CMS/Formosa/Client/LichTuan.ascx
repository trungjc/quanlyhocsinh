<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LichTuan.ascx.cs" Inherits="Fomusa.Client.LichTuan" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div style="font-family: Arial; font-size: smaller">
    <div>
        <h1>
            Lịch tuần công ty</h1>
    </div>
    <div>
        <telerik:RadGrid ID="rgMain" runat="server" AutoGenerateColumns="False" GridLines="None"
            Skin="Office2007" OnNeedDataSource="rgMain_NeedDataSource" Width="977px">
            <HeaderContextMenu EnableTheming="True">
                <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
            </HeaderContextMenu>
            <MasterTableView NoDetailRecordsText="Không có dữ liệu" NoMasterRecordsText="Không có dữ liệu"
                TableLayout="Fixed" Width="100%">
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="LichTuanID" HeaderText="ID" UniqueName="ID">
                        <HeaderStyle HorizontalAlign="Center" Width="20px" />
                        <ItemStyle Width="20px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridDateTimeColumn DataField="Ngay" HeaderText="Ngày" UniqueName="Ngay"
                        DataFormatString="{0:dd/MM/yy}">
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle Width="80px" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridDateTimeColumn DataField="ThoiGian" HeaderText="Thời gian" UniqueName="ThoiGian"
                        DataFormatString="{0:HH:mm}">
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle Width="80px" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridBoundColumn DataField="DiaDiem" HeaderText="Địa điểm" UniqueName="DiaDiem">
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle Width="80px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ChuTri" HeaderText="Chủ trì" UniqueName="ChuTri">
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle Width="80px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NoiDung" HeaderText="Nội dung" UniqueName="NoiDung">
                        <HeaderStyle HorizontalAlign="Center" Width="250px" />
                        <ItemStyle Width="250px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ChuanBi" HeaderText="Chuẩn bị" UniqueName="ChuanBi">
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle Width="80px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ThanhPhan" HeaderText="Thành phần" UniqueName="ThanhPhan">
                        <HeaderStyle HorizontalAlign="Center" Width="227px" />
                        <ItemStyle Width="227px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TinhTrang" HeaderText="Tình trạng" UniqueName="TinhTrang">
                        <HeaderStyle HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <FilterMenu EnableTheming="True">
                <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
            </FilterMenu>
        </telerik:RadGrid>
    </div>
</div>
