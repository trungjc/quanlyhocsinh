<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListChart24h.ascx.cs"
    Inherits="CMS.Client.Admin.ListChart24h" %>
<asp:HiddenField ID="hdnUrl" runat="server" />
<asp:HiddenField ID="hdnUrl1" runat="server" />
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
                                    <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editchart24h/Default.aspx">
                                        <span class="icon-32-publish" title="Đăng tin mới">
                                        </span>
                                        Tạo mới
                                    </asp:HyperLink>
                                </td>
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="linkImport" runat="server" CssClass="toolbar" ToolTip="Đăng ảnh mới">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-publish.png"
                                            OnClientClick="SelectUrl();" OnClick="linkImport_Click" />
                                        <br />
                                        Import File
                                    </asp:HyperLink>
                                </td>
                                <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" ToolTip="Config">
                                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-publish.png"
                                            OnClientClick="SelectUrl1();" />
                                        <br />
                                        TitleChart
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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvChart24h" runat="server" AutoGenerateColumns="False" Width="100%"
                            OnRowCommand="grvChart24h_RowCommand" OnRowDataBound="grvChart24h_RowDataBound"
                            CssClass="gridviewBorder" CellPadding="4" ForeColor="#333333" GridLines="None"
                            AllowPaging="True" PageSize="20" OnPageIndexChanging="grvChart24h_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="ChartID" HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                        Width="31px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ChartName" HeaderText="Tên Biểu đồ">
                                    <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ChartPostDate" HeaderText="Ngày đăng">
                                    <ItemStyle HorizontalAlign="center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="200px" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="ChartStatus" HeaderText="Trạng th&#225;i">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                        Width="60px" />
                                </asp:CheckBoxField>
                                <asp:TemplateField HeaderText="Chức năng">
                                    <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ChartID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_edit.png" />
                                        &nbsp;
                                        <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("ChartID") %>'
                                            ImageUrl="~/images/Admin_Theme/images/btn_delete.png" />
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
<script language="javascript" type="text/javascript">

    function SelectUrl() {
        var _url = document.getElementById("<%=hdnUrl.ClientID%>").value;
        return window.open(_url, '_blank', 'scrollbars=no,resizable=no,locationbar=no,width=500,height=250,left='.concat((screen.width - 800) / 2).concat(',top=').concat((screen.height - 250) / 2));
    }
    function SelectUrl1() {
        var _url = document.getElementById("<%=hdnUrl1.ClientID%>").value;
        return window.open(_url, '_blank', 'scrollbars=no,resizable=no,locationbar=no,width=500,height=250,left='.concat((screen.width - 800) / 2).concat(',top=').concat((screen.height - 250) / 2));
    }
    function SubmitForm() {
        var objLink = document.getElementById("<%=linkImport.ClientID%>");
        //    alert('aaaaabbbbb');
        if (objLink) {
            //        alert('aaaaa');
            objLink.submit();
        }
    }
</script>
