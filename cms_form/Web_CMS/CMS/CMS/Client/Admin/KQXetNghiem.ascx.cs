using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using BSO;
using ETO;
using Telerik.Web.UI;
using System.Globalization;

namespace CMS.Client.Admin
{
    public partial class KQXetNghiem : System.Web.UI.UserControl
    {

        readonly Medi_PhieuXetNghiemBSO _md = new Medi_PhieuXetNghiemBSO();
        readonly Medi_QuanLyDoiTuongBSO _doituong = new Medi_QuanLyDoiTuongBSO();

        #region initialize
        // lấy số phiếu chưa xác nhận cho lên trên
        private string PhieuChuaXacNhan()
        {
            DataTable dtChuaXacNhan = new DataTable();
            dtChuaXacNhan = _doituong.GetPhieuChuaXetNghiem();
            if (dtChuaXacNhan.Rows.Count > 0 && dtChuaXacNhan != null)
            {
                int soPhieu = Convert.ToInt32(dtChuaXacNhan.Rows[0][0].ToString());
                return "Phiếu chưa xác nhận (" + soPhieu + ")";
            }
            else
            {
                return "Phiếu chưa xác nhận(0)";
            }
        }

        private int GetTrangThai(string maPhieu)
        {

            DataTable DtMaPhieu = new DataTable();

            DtMaPhieu = _md.GetTrangThai(maPhieu);
            return (Convert.ToInt32(DtMaPhieu.Rows[0]["State"].ToString()));
        }

        #endregion
        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EventEnter();
                initialize_form();
                initControl();
                LoadDoiTuong();
                LoadTrangThai();
            }
            RadButton_TongPhieu.Text = PhieuChuaXacNhan();
        }

        protected void btn_LamMoi(object sender, EventArgs e)
        {
            initialize_form();

        }

        protected void btn_Order_Click(object sender, EventArgs e)
        {
        }

        protected void grv_NhapKetQua_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string Id = Convert.ToString(e.CommandArgument.ToString()).Trim();
            string nName = e.CommandName.ToLower();
            switch (nName)
            {
                case "_edit":
                    Response.Redirect("~/Admin/nhapkq_xetnghiem/" + Id + "/Default.aspx");
                    break;
                case "rowclick":
                    string maphieu = (e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["MaPhieu"].ToString().Trim();
                    int trangthai = GetTrangThai(maphieu);
                    LoadButton(trangthai);
                    break;
            }



        }

        protected void grv_NhapKetQua_OnrowDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                var lbl_value = (Label)item.FindControl("lbl_value");
                var lbl_TrangThai = (Label)item.FindControl("lbl_TrangThai");
                var Image = (ImageButton)item.FindControl("btn_edit");
                int TT = Convert.ToInt32(lbl_value.Text.Trim());
                if (TT == 1)
                {
                    lbl_TrangThai.Text = "Đã đăng ký chưa xác nhận";
                    Image.Visible = false;
                }
                if (TT == 2)
                {
                    lbl_TrangThai.Text = "Đã xác nhận";
                    Image.Visible = false;
                }
                if (TT == 3)
                {
                    lbl_TrangThai.Text = "Đã hoãn lịch";
                    Image.Visible = false;
                }
                if (TT == 4)
                {
                    lbl_TrangThai.Text = "Đã hủy lịch";
                    Image.Visible = false;
                }
                if (TT == 5)
                {
                    lbl_TrangThai.Text = "Đã lấy mẫu";
                    Image.Visible = true;
                }
                if (TT == 6)
                {
                    lbl_TrangThai.Text = "Có kết quả";
                    Image.Visible = true;
                }
            }
        }

        protected void Pageindex_change_DanhMuc(object source, GridPageChangedEventArgs e)
        {
            int trangThaiClick = Convert.ToInt32(Session["click"]);
            if (trangThaiClick == 1)
            {
                SearchNangCao();
            }
            else
            {
                SearchCoBan();
            }

        }

        protected void DemoClick(object sender, EventArgs e)
        {
            //Response.Redirect();
        }

        protected void btnTongPhieu_Click(object sender, EventArgs e)
        {
            DataTable dtTongPhieu = new DataTable();
            dtTongPhieu = _md.GetDanhSachPhieuChuaXacNhan();
            RadGrid1.DataSource = dtTongPhieu;
            RadGrid1.DataBind();
            LoadButton(1);

        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            Session["click"] = 2;
            SearchCoBan();
        }

        protected void grv_NhapKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btn_LamMoi_NC(object sender, EventArgs e)
        {
            initialize_form();
        }

        protected void btnTimKiem_Click_NC(object sender, EventArgs e)
        {
            Session["click"] = 1;
            SearchNangCao();
        }

        #endregion
        #region Custom Methods
        // Tìm kiếm cơ bản
        protected void SearchCoBan()
        {
            string txtTuKhoa = TuKhoa.Text.Trim();
            int doiTuong = Convert.ToInt32(Drop_DoiTuong_CB.SelectedValue.ToString());
            int trangThai = Convert.ToInt32(Drop_TrangThai_CB.SelectedValue.ToString());
            DataTable dtTimKiemCoBan = new DataTable();
            dtTimKiemCoBan = _doituong.TimKiemCoBan(txtTuKhoa, trangThai, doiTuong);
            RadGrid1.DataSource = dtTimKiemCoBan;
            RadGrid1.DataBind();
            LoadButton(trangThai);

        }
        //Tìm kiếm nâng cao
        protected void SearchNangCao()
        {
            int doiTuong = Convert.ToInt32(Drop_doiTuong_NC.SelectedValue.ToString());
            int trangThai = Convert.ToInt32(TrangThai_NC.SelectedValue.ToString());
            string maphieuNC = MaPhieu.Text.Trim();
            string tenKhachHang = TenKhachHang.Text.Trim();
            string maBaCode = MaBaCode.Text.Trim();
            string soTheBH = TheBH.Text.Trim();
            int doiTuongNC = Convert.ToInt32(Drop_doiTuong_NC.SelectedValue.ToString());
            string diaChi = DiaChi.Text.Trim();
            int trangThaiNangCao = Convert.ToInt32(TrangThai_NC.SelectedValue.ToString());

            var ngayKT = DateTime.Parse(Convert.ToString(txtKetThuc.SelectedDate), new CultureInfo("en-US", true));
            var ngayBD = DateTime.Parse(Convert.ToString(txtBatDau.SelectedDate), new CultureInfo("en-US", true));



            DataTable dtTimKiemNangCao = new DataTable();
            dtTimKiemNangCao = _doituong.TimKiemNangCao(maphieuNC, tenKhachHang, maBaCode, soTheBH, doiTuong, diaChi, trangThai, ngayBD, ngayKT);

            RadGrid1.DataSource = dtTimKiemNangCao;
            RadGrid1.DataBind();
            LoadButton(trangThai);

        }
        // làm mới form
        protected void Resert()
        {
            txtBatDau.SelectedDate = DateTime.Now.AddDays(-30);
            txtKetThuc.SelectedDate = DateTime.Now;
            Drop_doiTuong_NC.SelectedValue = "0";
            TrangThai_NC.SelectedValue = "0";
            MaPhieu.Text = "";
            TenKhachHang.Text = "";
            MaBaCode.Text = "";
            TheBH.Text = "";
            Drop_doiTuong_NC.SelectedValue = "0";
            DiaChi.Text = "";
            TrangThai_NC.SelectedValue = "0";
            TuKhoa.Text = "";
            Drop_DoiTuong_CB.SelectedValue = "0";
            Drop_TrangThai_CB.SelectedValue = "0";
        }

        protected void initialize_form()
        {
            TuKhoa.Focus();
            txtBatDau.SelectedDate = DateTime.Now.AddDays(-30);
            txtKetThuc.SelectedDate = DateTime.Now;
        }
        // Sự kiện ấn enter
        protected void EventEnter()
        {

            TuKhoa.Attributes.Add("onKeyPress", "doClick('" + RadButtonTimKiem.ClientID + "',event)");
            TuKhoa.Attributes.Add("onKeyPress", "doClick('" + RadButtonTimKiem.ClientID + "',event)");
            MaPhieu.Attributes.Add("onKeyPress", "doClick('" + RadButtonTimKiem_NC.ClientID + "',event)");
            TenKhachHang.Attributes.Add("onKeyPress", "doClick('" + RadButtonTimKiem_NC.ClientID + "',event)");
            MaBaCode.Attributes.Add("onKeyPress", "doClick('" + RadButtonTimKiem_NC.ClientID + "',event)");
            TheBH.Attributes.Add("onKeyPress", "doClick('" + RadButtonTimKiem_NC.ClientID + "',event)");
            DiaChi.Attributes.Add("onKeyPress", "doClick('" + RadButtonTimKiem_NC.ClientID + "',event)");
            TheBH.Attributes.Add("onKeyPress", "doClick('" + RadButtonTimKiem_NC.ClientID + "',event)");
        }

        protected void LoadButton(int trangThai)
        {
            switch (trangThai)
            {
                case 1:
                    RadButton_Add.Visible = false;
                    RadButton_Book.Visible = false;
                    RadButton_CapNhat.Visible = true;
                    RadButton_Hoan.Visible = false;
                    RadButton_Huy.Visible = true;
                    break;
                case 2:
                    RadButton_Add.Visible = false;
                    RadButton_Book.Visible = true;
                    RadButton_CapNhat.Visible = true;
                    RadButton_Hoan.Visible = true;
                    RadButton_Huy.Visible = true;
                    break;
                case 3:
                    RadButton_Add.Visible = false;
                    RadButton_Book.Visible = false;
                    RadButton_CapNhat.Visible = true;
                    RadButton_Hoan.Visible = false;
                    RadButton_Huy.Visible = true;
                    break;
                case 4:
                    RadButton_Add.Visible = false;
                    RadButton_Book.Visible = false;
                    RadButton_CapNhat.Visible = false;
                    RadButton_Hoan.Visible = false;
                    RadButton_Huy.Visible = false;
                    break;
                case 5:
                    RadButton_Add.Visible = false;
                    RadButton_Book.Visible = false;
                    RadButton_CapNhat.Visible = false;
                    RadButton_Hoan.Visible = false;
                    RadButton_Huy.Visible = false;
                    break;
                case 6:
                    RadButton_Add.Visible = false;
                    RadButton_Book.Visible = false;
                    RadButton_CapNhat.Visible = false;
                    RadButton_Hoan.Visible = false;
                    RadButton_Huy.Visible = false;

                    break;
                default: break;
            }
        }
        // lấy danh sách đối tượng
        protected void LoadDoiTuong()
        {
            DataTable dtDoiTuong = new DataTable();
            dtDoiTuong = _doituong.GetDanhSachDoiTuong();
            Drop_DoiTuong_CB.DataSource = dtDoiTuong;

            Drop_DoiTuong_CB.DataTextField = "TenDoiTuong";
            Drop_DoiTuong_CB.DataValueField = "ID";
            Drop_DoiTuong_CB.DataBind();
            Drop_DoiTuong_CB.Items.Add(new ListItem { Text = "- chọn tất cả -", Value = "0" });
            Drop_DoiTuong_CB.SelectedValue = "0";

            Drop_doiTuong_NC.DataSource = dtDoiTuong;
            Drop_doiTuong_NC.DataTextField = "TenDoiTuong";
            Drop_doiTuong_NC.DataValueField = "ID";
            Drop_doiTuong_NC.DataBind();
            Drop_doiTuong_NC.Items.Add(new ListItem { Text = "- chọn tất cả -", Value = "0" });
            Drop_doiTuong_NC.SelectedValue = "0";

        }

        protected void LoadTrangThai()
        {

            // thêm các trạng thái vào drop tìm kiếm cơ bản
            Drop_TrangThai_CB.Items.Add(new ListItem { Text = "- chọn tất cả -", Value = "0" });
            Drop_TrangThai_CB.Items.Add(new ListItem { Text = "Đã đăng ký, chưa xét ngiệm", Value = "1" });
            Drop_TrangThai_CB.Items.Add(new ListItem { Text = "Đã xác nhận", Value = "2" });
            Drop_TrangThai_CB.Items.Add(new ListItem { Text = "Đã hoãn lịch", Value = "3" });
            Drop_TrangThai_CB.Items.Add(new ListItem { Text = "Đã hủy lịch", Value = "4" });
            Drop_TrangThai_CB.Items.Add(new ListItem { Text = "Đã lấy mẫu", Value = "5" });
            Drop_TrangThai_CB.Items.Add(new ListItem { Text = " Có kết quả", Value = "6" });

            // thêm các trạng thái vào drop tìm kiếm nâng cao
            TrangThai_NC.Items.Add(new ListItem { Text = "- chọn tất cả -", Value = "0" });
            TrangThai_NC.Items.Add(new ListItem { Text = "Đã đăng ký, chưa xét ngiệm", Value = "1" });
            TrangThai_NC.Items.Add(new ListItem { Text = "Đã xác nhận", Value = "2" });
            TrangThai_NC.Items.Add(new ListItem { Text = "Đã hoãn lịch", Value = "3" });
            TrangThai_NC.Items.Add(new ListItem { Text = "Đã hủy lịch", Value = "4" });
            TrangThai_NC.Items.Add(new ListItem { Text = "Đã lấy mẫu", Value = "5" });
            TrangThai_NC.Items.Add(new ListItem { Text = " Có kết quả", Value = "6" });
            Drop_TrangThai_CB.SelectedValue = "0";
            TrangThai_NC.SelectedValue = "0";

        }

        protected void initControl()
        {


            DataTable dt = new DataTable();
            dt = _md.Get_pxn(Language.language);
            ConfigBSO configBSO = new ConfigBSO();
            int Ngon_Ngu = Convert.ToInt32(ViewState["CauHinh_Viet"]);
            if (Ngon_Ngu == 1 || Ngon_Ngu == 0)
            {
                VideoBSO videoBSO = new VideoBSO();
                DataTable table = videoBSO.GetVideoAll(Language.language);
                commonBSO commonBSO = new commonBSO();
                //commonBSO.FillToGridView(grv_NhapKetQua, dt);
                RadGrid1.DataSource = dt;
                RadGrid1.DataBind();

            }
            else
            {
                VideoBSO videoBSO = new VideoBSO();
                DataTable table = videoBSO.GetVideoAll(Language.language_Eng);
                commonBSO commonBSO = new commonBSO();
                //commonBSO.FillToGridView(grv_NhapKetQua, dt);
                RadGrid1.DataSource = dt;
                RadGrid1.DataBind();
            }
            //foreach (GridViewRow gdRow in grv_NhapKetQua.Rows)
            //{
            //    if (gdRow.RowType == DataControlRowType.DataRow)
            //    {
            //        var label1 = (Label)gdRow.Cells[8].FindControl("lbl_value");
            //        var lable2 = (Label)gdRow.Cells[8].FindControl("lbl_TrangThai");
            //        if (label1.Text == "1")
            //        {
            //            lable2.Text = "Đã có kết quả";
            //        }
            //        if (label1.Text == "0")
            //        {
            //            lable2.Text = "Chưa có kết quả";
            //        }
            //    }
            //}
        }
        #endregion
    }
}