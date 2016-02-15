<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MeDi_DoiTuong.ascx.cs"
    Inherits="CMS.Client.Admin.MeDi_DoiTuong" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .SelectedStyle
    {
        background-color: Black;
    }
</style>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        //popup form them moi nhom tai lieu
        function Open_Window_Delete(param) {
            try {
                var id = param;

                // alert(id);
                // var id = $("#txtgiatri").val();
                // var id = $('#txtgiatri').attr('value'); 
                // var id = $('#txtgiatri').val()
                var oWnd = $find("<%= RadWindow1.ClientID %>");
                oWnd.setSize(500, 200);
                oWnd.setUrl('<%=ResolveUrl("~/Client/Admin/MeDiXoaDoituong.aspx?ID=' + id + '")%>', "UserListDialog", "scrollbars = 1");
                oWnd.show();

            }
            catch (e) {
                alert(e.toString());
            }
        }
    </script>
    <script type="text/javascript">
        function refreshGridHSCV() {
            var button = document.getElementById('<%=btnTongDV.ClientID%>');
            button.click();
        }

        function Open_Window_ThemMoiHS() {
            try {
                var oWnd = $find("<%= RadWindow1.ClientID %>");
                oWnd.setSize(500, 300);
                oWnd.setUrl('<%=ResolveUrl("~/CONGVIEC/VBCV_CV_HSCV_NEW.aspx")%>', "UserListDialog");
                oWnd.show();
            } catch (e) {
                alert(e.toString());
            }
        }

    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
</telerik:RadAjaxManager>
<telerik:RadWindowManager ID="Singleton" RestrictionZoneID="wrapper" EnableEmbeddedSkins="true"
    runat="server" Skin="Default">
    <Windows>
        <telerik:RadWindow ID="RadWindow1" ShowContentDuringLoad="false" Modal="True" VisibleStatusbar="false"
            Behaviors="Move" RestrictionZoneID="NavigateUrlZone" EnableEmbeddedSkins="true"
            runat="server">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <div style="width: 800px !important; margin: auto;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <asp:Button ID="btnTongDV" runat="server" OnClick="btnTongDV_Click" Visible="true" />
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
        <asp:Panel ID="pnSearch" runat="server">
            <%--   <table width="100%">
                <tr style="right: 100px; text-align: right;">
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Thêm mới" />
                    </td>
                </tr>
            </table>--%>
        </asp:Panel>
        <table width="100%" border="0" cellspacing="0" cellpadding="5">
            <tr>
                <td align="center">
                    <h3>
                        Danh sách đối tượng</h3>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label runat="server" ID="Thongbao" Visible="false" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <telerik:RadGrid ID="Grd_Doituong" runat="server" CssClass="RadGrid" GridLines="None"
                        AllowPaging="True" PageSize="20" AllowSorting="True" AutoGenerateColumns="False"
                        ShowStatusBar="true" AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
                        AllowAutomaticUpdates="True" OnItemUpdated="RadGrid1_ItemUpdated" OnPreRender="RadGrid1_PreRender"
                        OnItemDataBound="RadGrid1_Databound" OnItemCommand="RadGrid1_ItemCommand" SelectedItemStyle-CssClass="SelectedStyle">
                        <MasterTableView DataKeyNames="ID" CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnCurrentPage">
                            <CommandItemSettings AddNewRecordText="Thêm mới" ShowRefreshButton="false" />
                            <Columns>
                                <%--<telerik:GridBoundColumn DataField="ID" HeaderText="Product ID" ReadOnly="true"
                                    ForceExtractValue="Always" ConvertEmptyStringToNull="true" />--%>
                                <telerik:GridBoundColumn DataField="STT" HeaderText="STT" />
                                <telerik:GridBoundColumn DataField="TenDoiTuong" HeaderText="Tên đối tượng" />
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" />
                                <%-- <telerik:GridButtonColumn ConfirmText="Delete this product?" ConfirmDialogType="RadWindow"
                                    ConfirmTitle="Xóa đối tượng" ButtonType="ImageButton" CommandName="Delete"  />--%>
                                <telerik:GridTemplateColumn>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="Btn_xoa" CssClass="Xoa tablectrl_small  tipS"
                                            Width="10px" Text="Xóa" Height="20px" CommandArgument='<%# Eval("ID") %>' OnClientClick='<%# "Open_Window_Delete("+ Eval("ID") + ");  return false;" %>'
                                            ToolTip="Xóa chỉ tiêu"></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn Text="Áp giá" CommandName="Apgia">
                                </telerik:GridButtonColumn>
                            </Columns>
                            <EditFormSettings EditFormType="Template">
                                <EditColumn UniqueName="EditCommandColumn" />
                                <FormTemplate>
                                    <table>
                                        <tr>
                                            <asp:Label runat="server" Text="Tên đối tượng: " Font-Size="15px"></asp:Label>
                                            <b style="color: Red; margin-right: 10px;">(*)</b>
                                            <asp:TextBox ID="txt_doituong" runat="server" Text='<%#Bind("TenDoiTuong") %>'>
                                            </asp:TextBox>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="Btn_Save" Text=" Lưu" runat="server" CommandName="Save" />
                                                <asp:Button ID="Btn_cancel" Text="Thoát" runat="server" CommandName="Cancel" />
                                            </td>
                                        </tr>
                                    </table>
                                </FormTemplate>
                            </EditFormSettings>
                        </MasterTableView>
                        <PagerStyle Mode="NextPrevAndNumeric" />
                        <ClientSettings>
                            <ClientEvents OnRowDblClick="rowDblClick" />
                        </ClientSettings>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
</div>
