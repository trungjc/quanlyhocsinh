<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Medi_QLXetNghiem.ascx.cs"
    Inherits="CMS.Client.Admin.Medi_QLXetNghiem" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    //attempting to capture keypress for chrome here but this is not working
    $("#txtSearch").keypress(function (e) {
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
<script type="text/javascript">
    var treeView;

    function pageLoad() {
        treeView = $find("<%= rtvCtChung.ClientID %>");
    }
    function clientSideEdit(sender, args) {
        var destinationNode = args.get_destNode();

        if (destinationNode) {
            treeView.trackChanges();
            var sourceNodes = args.get_sourceNodes();

            for (var i = 0; i < sourceNodes.length; i++) {
                var sourceNode = sourceNodes[i];
                sourceNode.get_parent().get_nodes().remove(sourceNode);

                if (args.get_dropPosition() == "over")
                    destinationNode.get_nodes().add(sourceNode);
                if (args.get_dropPosition() == "above")
                    insertBefore(destinationNode, sourceNode);
                if (args.get_dropPosition() == "below")
                    insertAfter(destinationNode, sourceNode);
            }
            destinationNode.set_expanded(true);
            treeView.commitChanges();
        }
    }
</script>
<script type="text/javascript">
    $(window).load(function () {
        $(".RadTreeView").css("white-space", "inherit");
    });
</script>
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<asp:HiddenField ID="hdfId_Cha" runat="server" />
<asp:HiddenField ID="hdfID" runat="server" />
<%--<asp:HiddenField ID="hdfvalue_id" runat="server" Value="11111111111111111111" />
<asp:HiddenField ID="hdfid_now" runat="server" />
<asp:HiddenField ID="hdfposition" runat="server" />
<asp:Label runat="server" ID="lbltest" ForeColor="Red"></asp:Label>--%>
<p id="demo">
</p>
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
                                    <td>
                                        <div align="center">
                                            <asp:HyperLink ID="hpl_AddChild" runat="server" CssClass="toolbar">
                                                <asp:ImageButton ID="btn_AddChild" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/Document-Add-icon-1281.png"
                                                    OnClick="btn_AddChild_Click" />
                                                <br />
                                                Thêm Node(con)
                                            </asp:HyperLink>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar">
                                            <div align="center">
                                                <asp:ImageButton ID="ImageButton2" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/file_add.png"
                                                    OnClick="btn_AddBefore_Click" />
                                                <br />
                                                Thêm Node<br />
                                                (cùng cấp - trước)
                                            </div>
                                        </asp:HyperLink>
                                    </td>
                                    <td>
                                        <div align="center">
                                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="toolbar">
                                                <asp:ImageButton ID="ImageButton4" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/file_add.png"
                                                    OnClick="btn_AddAffter_Click" />
                                                <br />
                                                Thêm Node<br />
                                                (cùng cấp - sau)
                                            </asp:HyperLink>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="center">
                                            <asp:HyperLink ID="HyperLink4" runat="server" CssClass="toolbar">
                                                <asp:ImageButton ID="ImageButton5" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/file_edit.png"
                                                    OnClick="btn_Edit_Click" />
                                                <br />
                                                chỉnh sửa
                                            </asp:HyperLink>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="center">
                                            <asp:HyperLink ID="btn_enable" runat="server" CssClass="toolbar">
                                                <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"
                                                    OnClick="btn_Save_Click" />
                                                <br />
                                                Cập nhật
                                            </asp:HyperLink>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="center">
                                            <asp:HyperLink ID="HyperLink5" runat="server" CssClass="toolbar">
                                                <asp:ImageButton ID="btnCencel" runat="server" ToolTip=" Quay lại" CssClass="toolbar"
                                                    ImageUrl="~/images/Admin_Theme/Icons/go-back-icon.png" OnClick="btn_Cancel_Click" />
                                                <br />
                                                Quay lại
                                            </asp:HyperLink>
                                        </div>
                                    </td>
                                    <td>
                                        <div align="center">
                                            <asp:HyperLink ID="btn_delall" runat="server" CssClass="toolbar">
                                                <asp:ImageButton ID="btn_delAll1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-delete.png"
                                                    OnClick="btn_delete_Click" />
                                                <br />
                                                Xóa
                                            </asp:HyperLink>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <div style="border: 1px #8a8a8a solid;" align="center">
            <asp:Panel ID="pnSearch" runat="server">
                <table width="40%">
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtSearch" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" ImageUrl="~/images/Admin_Theme/images/btn_Search.gif" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div align="center">
            <h3>
                <asp:Label runat="server" ID="lblTrangThaiChucNang"></asp:Label></h3>
        </div>
        <div>
            <asp:Label runat="server" ID="lblThongbao"></asp:Label></div>
        <div style="float: right; padding-top: 185px; padding-bottom: 185px; border: 1px #8a8a8a solid;
            width: 39%; margin-top: 57px;">
            <table width="100%">
                <tr>
                    <asp:Panel ID="pnThongTin" runat="server">
                        <td>
                            <b style="color: #000">Loại xét nghiệm</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTenLXN" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </asp:Panel>
                    <asp:Panel ID="pnAddChild" runat="server" Visible="false">
                        <td>
                            <b>Nhập tên xét nghiệm<span style="color: Red">(*)</span></b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTenLXN_add" runat="server" MaxLength="100"></asp:TextBox>
                        </td>
                    </asp:Panel>
                </tr>
            </table>
        </div>
        <div>
            <table width="60%" style="margin-bottom: 20px;">
                <tr>
                    <td>
                        <div align="left">
                            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="toolbar">
                                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="toolbar" ToolTip="cập nhật tree"
                                    ImageUrl="~/images/Admin_Theme/Icons/interact.png" OnClick="btn_Save_Node_Click" />
                                <br />
                            </asp:HyperLink>
                            <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="cập nhật tree"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <asp:Panel ID="pnTree" runat="server">
                        <td>
                            <telerik:RadSplitter ID="RadSplitter1" runat="server" Height="400px" Width="100%"
                                Orientation="Horizontal">
                                <telerik:RadPane ID="RadPane1" runat="server" Scrolling="X" Width="100%">
                                    <telerik:RadTreeView Height="100%" Width="100%" ID="rtvCtChung" runat="server" EnableDragAndDrop="true"
                                        EnableDragAndDropBetweenNodes="true" IsDragDropEnabled="True" OnNodeClick="treeView1_NodeMouseClick"
                                        OnNodeDrop="rtvCtChung_OnNodeDrop">
                                    </telerik:RadTreeView>
                                    <%--<telerik:RadTreeView Height="100%" Width="100%" ID="rtvCtChung" runat="server" OnNodeDrop="RadTreeView1_NodeDrop"
                                        EnableDragAndDrop="true" EnableDragAndDropBetweenNodes="true" IsDragDropEnabled="True"
                                        SelectionMode="Multiple" MultipleSelect="true" OnClientNodeDropping="ClientNodeDropping"
                                        OnClientNodeDragging="onNodeDragging" OnClientNodeChecked="clientNodeChecked">
                                    </telerik:RadTreeView>--%>
                                </telerik:RadPane>
                            </telerik:RadSplitter>
                        </td>
                    </asp:Panel>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtIndex" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
