<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MeDi_PhieuXetNghiem.ascx.cs"
    Inherits="WebMedi.Client.Modules.KhachHang.MeDi_PhieuXetNghiem" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<script type="text/javascript">
    var treeView;

    function pageLoad() {
        treeView = $find("<%= rtvCtChung.ClientID %>");
    }

    function onNodeDragging(sender, args) {
        var target = args.get_htmlElement();

        if (!target) return;

        if (target.tagName == "INPUT") {
            target.style.cursor = "hand";
        }
    }

    function dropOnHtmlElement(args) {
        if (droppedOnInput(args))
            return;
    }

    function droppedOnGrid(args) {
        var target = args.get_htmlElement();

        while (target) {
            if (target.id == gridId) {
                args.set_htmlElement(target);
                return;
            }

            target = target.parentNode;
        }
        args.set_cancel(true);
    }

    function droppedOnInput(args) {
        var target = args.get_htmlElement();
        if (target.tagName == "INPUT") {
            target.style.cursor = "default";
            target.value = args.get_sourceNode().get_text();
            args.set_cancel(true);
            return true;
        }
    }

    function dropOnTree(args) {
        var text = "";

        if (args.get_sourceNodes().length) {
            var i;
            for (i = 0; i < args.get_sourceNodes().length; i++) {
                var node = args.get_sourceNodes()[i];
                text = text + ', ' + node.get_text();
            }
        }
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

    function insertBefore(destinationNode, sourceNode) {
        var destinationParent = destinationNode.get_parent();
        var index = destinationParent.get_nodes().indexOf(destinationNode);
        destinationParent.get_nodes().insert(index, sourceNode);
    }

    function insertAfter(destinationNode, sourceNode) {
        var destinationParent = destinationNode.get_parent();
        var index = destinationParent.get_nodes().indexOf(destinationNode);
        destinationParent.get_nodes().insert(index + 1, sourceNode);
    }

    function onNodeDropping(sender, args) {
        var dest = args.get_destNode();
        if (dest) {
            clientSideEdit(sender, args);
            args.set_cancel(true);
            return;

            dropOnTree(args);
        }
        else {
            dropOnHtmlElement(args);
        }
    }
</script>
<script type="text/javascript" language="javascript">

    function UpdateAllChildren(nodes, checked) {
        var i;
        var test;
        for (i = 0; i < nodes.get_count(); i++) {
            if (checked == true) {
                nodes.getNode(i).check();
            }
            else {
                nodes.getNode(i).set_checked(false);
            }

            $(".rtIn").click(function () {
                nodes.getNode(i).check();
            });

            if (nodes.getNode(i).get_nodes().get_count() > 0) {
                UpdateAllChildren(nodes.getNode(i).get_nodes(), checked);
            }
        }
    }
    function clientNodeChecked(sender, eventArgs) {
        var childNodes = eventArgs.get_node().get_nodes();
        var isChecked = eventArgs.get_node().get_checked();
        UpdateAllChildren(childNodes, isChecked);

        var node = eventArgs.get_node();
        var parentNode = node.get_parent();
        var isnext = true;
        while (isnext == true) {
            parentNode.set_checked(true);
            parentNode = parentNode.get_parent();
            if (parentNode == null) {
                isnext = false;
            }
        }
    }

</script>
<script type="text/javascript">
    $(window).load(function () {
        $(".RadTreeView").css("white-space", "inherit");
    });
</script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
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
</style>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <%--<telerik:AjaxSetting AjaxControlID="btnXoavanban">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdChiTietHS" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        <telerik:AjaxSetting AjaxControlID="LinkButton2">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ccJoin" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<div class="col-md-9 main-content">
    <asp:Panel ID="pnDangKy" runat="server">
        <div class="row navigater">
            <span class="content_Text_Cat">
                <asp:Literal ID="title_cate" runat="server"></asp:Literal>
            </span><span class="content_Text">
                <asp:Literal ID="title_name" runat="server" Text="<%$ Resources: resource, register_contact%>"></asp:Literal></span>
        </div>
        <div class="row" align="center">
            <h4>
                Đăng ký xét nghiệm online</h4>
        </div>
        <div class="row main-category">
            <asp:Label runat="server" ForeColor="Blue">Chào mừng quý khách đến với dịch vụ đăng ký xét nghiệm online của trung tâm</asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server">Quý khách có thể gọi điện tới số <b><i>hotline: 043 6654 132</i></b> hoặc cung cấp đầy đủ thông tin theo mẫu dưới đây. Các chuyên viên sẽ bố trí lịch và liên lạc lại với quý khách.
            <br />Vui lòng nhập đầy đủ thông tin vào những ô có dấu <b style="color:Red;">(*)</b>. Nhập chính xác Email và kiềm tra Email sau khi đăng ký.<br /><i>Cảm ơn quý khách đã sử dụng dịch vụ.</i></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lbl_Error" ForeColor="Red" Text="Đăng ký không thành công.Quý khách vui lòng kiểm tra lại thông tin vừa nhập."
                    Visible="false" runat="server"></asp:Label>
                <div class="row" align="center" style="border-bottom: 2px solid #018a44; margin-bottom: 5px;">
                    <h4>
                        Thông tin khách hàng</h4>
                </div>
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal7" runat="server" Text="Họ tên"></asp:Literal><b style="color: Red;">(*)</b>
                    </div>
                    <div class="col-sm-9 control_value">
                        <asp:TextBox ID="txt_HoTen" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Không được có ký tự đặc biệt và số"
                            Display="Dynamic" ForeColor="Red" ValidationGroup="send" ControlToValidate="txt_HoTen"
                            ValidationExpression="^[a-zA-Z'-'\sáàảãạăâắằấầặẵẫậéèẻ  êẽẹếềểễệóòỏõọôốồổỗộ ơớờởỡợíìỉĩịđùúủũụưứ�� �ửữựÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠ ƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼ� ��ỀỂỄỆỈỊỌỎỐỒỔỖỘỚỜỞ ỠỢỤỨỪỬỮỰỲỴÝỶỸửữựỵ ỷỹ]*$" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_HoTen"
                            ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="send">Tên không được để trống</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal1" runat="server" Text="Giới tính"></asp:Literal>
                    </div>
                    <div class="col-sm-9 control_value">
                        <asp:RadioButton Checked="true" ID="rdb_men" Text="Nam" GroupName="GioiTinh" runat="server">
                        </asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="rdb_women" Text="Nữ" GroupName="GioiTinh" runat="server"></asp:RadioButton>
                    </div>
                </div>
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal2" runat="server" Text="Tuổi"></asp:Literal><b style="color: Red;">(*)</b>
                    </div>
                    <div class="col-sm-9 control_value">
                        <asp:TextBox ID="txt_Tuoi" runat="server" class="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_Tuoi" ID="RegularExpressionValidator3"
                            CssClass="nNote nFailure" ValidationExpression="^[\s\S]{1,2}$" ForeColor="Red"
                            runat="server" ErrorMessage="Tối đa 2 ký tự và phải là số" ValidationGroup="send"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Tuoi"
                            ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="send">Tuổi không được trống</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal3" runat="server" Text="Số điện thoại"></asp:Literal><b style="color: Red;">(*)</b>
                    </div>
                    <div class="col-sm-9 control_value">
                        <asp:TextBox ID="txt_SDT" runat="server" class="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txt_SDT" ID="RegularExpressionValidator4"
                            ValidationGroup="send" CssClass="nNote nFailure" ValidationExpression="^[\s\S]{10,11}$"
                            runat="server" ErrorMessage="Số điện thoại là 10 hoặc 11 số" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_SDT"
                            ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="send">Số điện thoại không được trống</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal4" runat="server" Text="Địa chỉ"></asp:Literal><b style="color: Red;">(*)</b>
                    </div>
                    <div class="col-sm-9 control_value">
                        <asp:TextBox ID="txt_DiaChi" runat="server" class="form-control" Height="80px" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_DiaChi"
                            ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="send">Địa chỉ không được trống</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row dk_form">
                    <div class="col-md-3">
                        <asp:Literal ID="Literal9" runat="server" Text="Email"></asp:Literal><b style="color: Red;">(*)</b>
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ValidationGroup="send"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="RegularExpressionValidator" ForeColor="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            class="register_text_error1" ValidationGroup="send">Email không đúng</asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row dk_form">
                    <div class="col-md-3">
                        <asp:Literal ID="Literal10" runat="server" Text="Đối tượng"></asp:Literal>
                    </div>
                    <div class="col-md-9">
                        <asp:DropDownList ID="ddlDoiTuong" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDoiTuong_IndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal5" runat="server" Text="Ngày khám"></asp:Literal><b style="color: Red;">(*)</b>
                    </div>
                    <div class="col-sm-9 control_value">
                        <telerik:RadDatePicker ID="rdp_NgayKham" runat="server">
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="rdp_NgayKham"
                            ErrorMessage="Sai định dạng!" ForeColor="Red" ValidationGroup="send"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label runat="server" ID="lblErrorDate" ForeColor="Red" Visible="false" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <asp:Literal ID="Literal6" runat="server" Text="Giờ khám"></asp:Literal>
                    </div>
                    <div class="col-sm-9 control_value">
                        <telerik:RadTimePicker ID="rtp_GioKham" runat="server">
                        </telerik:RadTimePicker>
                    </div>
                </div>
                <div class="row dk_form">
                    <div class="col-sm-3">
                        Nhập mã captcha<b style="color: Red;">(*)</b></div>
                    <div class="col-sm-9 control_value">
                        <asp:TextBox ID="txt_MaPin" Visible="true" placeholder="Mã bảo mật" class="form-control"
                            runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row dk_form">
                    <div class="col-md-3">
                    </div>
                    <div class="col-sm-4">
                        <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaWidth="130" CaptchaHeight="34"
                            LineColor="DarkGreen" NoiseColor="Green" />
                    </div>
                    <div class="col-sm-5" align="center">
                        <asp:LinkButton ID="LinkButton2" runat="server" Visible="true" OnClick="LinkButton1_Click">Chọn mã khác</asp:LinkButton></div>
                </div>
            </div>
            <div class="col-md-6 dk_content_right">
                <div class="row dk_title" align="center" style="border-bottom: 2px solid #018a44;">
                    <h4>
                        Danh sách loại xét nghiệm</h4>
                </div>
                <div class="row dk_title">
                    <asp:Label runat="server"><i>Đơn giá xét nghiệm được tính theo "Đối tượng".</i></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="ThongBao" Visible="false" Text="Chưa có bảng áp giá loại đối tượng này!"></asp:Label>
                    <telerik:RadTreeView ID="rtvCtChung" runat="server" CheckBoxes="True" EnableDragAndDrop="true"
                        EnableDragAndDropBetweenNodes="true" OnClientNodeDropping="onNodeDropping" OnClientNodeDragging="onNodeDragging"
                        OnClientNodeChecked="clientNodeChecked">
                    </telerik:RadTreeView>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnXacNhan" runat="server" Visible="false">
        <asp:Label runat="server" ForeColor="Blue">Quý khách đang sử dụng dịch vụ đăng ký online tại trung tâm</asp:Label><br />
        <asp:Label ID="Label2" runat="server">Vui lòng kiểm tra lại thông tin bên dưới và chọn "xác nhận" để đăng ký<br /><i>Cảm ơn quý khách đã sử dụng dịch vụ.</i></asp:Label>
        <div class="row" align="center">
            <h4>
                Phiếu đăng ký của khách hàng</h4>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <b>
                            <asp:Literal ID="Literal11" runat="server" Text="Khách hàng: "></asp:Literal></b>
                    </div>
                    <div class="col-sm-9 control_value">
                        <asp:Label ID="lblKhachhang" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <b>
                            <asp:Literal ID="Literal14" runat="server" Text="Địa chỉ: "></asp:Literal></b>
                    </div>
                    <div class="col-sm-9 control_value">
                        <asp:Label ID="lblDiaChi" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <b>
                            <asp:Literal ID="Literal12" runat="server" Text="SĐT: "></asp:Literal>
                        </b>
                    </div>
                    <div class="col-sm-9 control_value">
                        <asp:Label ID="lblSDT" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <b>
                            <asp:Literal ID="Literal13" runat="server" Text="Đối tượng: "></asp:Literal></b>
                    </div>
                    <div class="col-sm-9 control_value">
                        <asp:Label ID="lblDoiTuong" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="row dk_form">
                    <div class="col-sm-3">
                        <b>
                            <asp:Literal ID="Literal15" runat="server" Text="Email: "></asp:Literal></b>
                    </div>
                    <div class="col-sm-9 control_value">
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row dk_form">
                    <div class="col-sm-4">
                        <b>
                            <asp:Literal ID="Literal16" runat="server" Text="Ngày tới khám: "></asp:Literal></b>
                    </div>
                    <div class="col-sm-8 control_value">
                        <asp:Label ID="lblNgayKham" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" align="center">
            <h5>
                <b>Danh mục xét nghiệm đã đăng ký</b></h5>
        </div>
        <div class="row" align="center">
            <i>
                <asp:Label runat="server" ID="lblChuaChonLXN" Text="Chưa chọn loại xét nghiệm"></asp:Label></i>
            <telerik:RadGrid ID="rgLoaiXN_DaChon" runat="server" AutoGenerateColumns="False"
                CellSpacing="0" GridLines="None">
                <MasterTableView>
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="LoaiXetNghiem" FilterControlAltText="Filter column column"
                            HeaderText="Loại xét nghiệm" UniqueName="column">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="GiaTien" FilterControlAltText="Filter column1 column"
                            HeaderText="Giá tiền (VNĐ)" UniqueName="column1">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                    <PagerStyle PageSizeControlType="RadComboBox" />
                </MasterTableView>
                <PagerStyle PageSizeControlType="RadComboBox" />
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
            </telerik:RadGrid>
        </div>
        <div class="row" style="margin-top: 10px;">
            <b>Tổng chi phí:
                <asp:Label runat="server" ID="lblSumPXN" ForeColor="Blue"></asp:Label></b></div>
    </asp:Panel>
    <asp:Panel ID="pnSussess" runat="server" Visible="false">
        <div class="row">
            <i>
                <asp:Label ID="lbl_success" ForeColor="Blue" runat="server"></asp:Label></div>
        </i>
        <asp:Label runat="server">Cảm ơn quý khách đã sử dụng dịch vụ xét nghiệm tại nhà online của phòng khám.
Phòng khám sẽ gọi điện liên hệ với quý khách trong thời gian sớm nhất. Kính chúc quý khách một ngày vui vẻ.
        </asp:Label>
    </asp:Panel>
    <div class="row" style="margin-top: 5px;">
        <div class="row" align="center">
            <asp:Button ID="btnSend" runat="server" Text="<%$ Resources:Resource, Send %>" CssClass="btn btn-primary"
                OnClick="btnSend_Click" ValidationGroup="send" />
            &nbsp;
            <asp:Button ID="btn_reset" runat="server" Text="<%$ Resources:Resource, Reset %>"
                CssClass="btn btn-primary" OnClick="btnReset_Click" />
            <asp:Button ID="btnXacNhan" Visible="false" runat="server" Text="Xác nhận" CssClass="btn btn-primary"
                OnClick="btnXacNhan_Click" />
            &nbsp;
            <asp:Button ID="btnQuayLai" Visible="false" runat="server" Text="Quay Lại" CssClass="btn btn-primary"
                OnClick="btnQuayLai_Click" />
        </div>
    </div>
</div>
