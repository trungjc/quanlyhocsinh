using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;
using System.Data;
using Telerik.Web.UI;
using System.Globalization;

namespace WebMedi.Client.Modules.KhachHang
{
    public partial class MeDi_PhieuXetNghiem : System.Web.UI.UserControl
    {
        Medi_PhieuXetNghiemBSO pxnBSO = new Medi_PhieuXetNghiemBSO();
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewWelcome(Language.language);
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Home' class='content_Text_Cat'>" + Resources.Resource.Home + "</a>  &nbsp;>&nbsp;";

            if (!IsPostBack)
            {
                initialize_form();
            }
        }
        #region ReceiveHtml
        public ETO.Medi_PhieuXetNghiem ReceiveHtml()
        {
            ETO.Medi_PhieuXetNghiem Medi_pxn = new ETO.Medi_PhieuXetNghiem();
            Medi_pxn.HoTen = txt_HoTen.Text.Trim();
            if (rdb_men.Checked == true)
            {
                Medi_pxn.GioiTinh = true;
            }
            else
            {
                Medi_pxn.GioiTinh = false;
            }
            Medi_pxn.Tuoi = Convert.ToInt32(txt_Tuoi.Text.Trim());
            Medi_pxn.SoDienThoai = txt_SDT.Text.Trim();
            Medi_pxn.DiaChi = txt_DiaChi.Text.Trim();
            Medi_pxn.Email = txtEmail.Text.Trim();
            Medi_pxn.Id_DoiTuong = Convert.ToInt32(ddlDoiTuong.SelectedValue.Trim());
            DateTime date1, time1, TG_BatDau;
            date1 = rdp_NgayKham.SelectedDate.Value;
            if (!rtp_GioKham.DateInput.IsEmpty)
            {
                time1 = rtp_GioKham.SelectedDate.Value;
                TG_BatDau = new DateTime(date1.Year, date1.Month, date1.Day, time1.Hour, time1.Minute, 0);
                Medi_pxn.ThoiGianToiKham = TG_BatDau;
            }
            else
            {
                TG_BatDau = new DateTime(date1.Year, date1.Month, date1.Day, 0, 0, 0);
                Medi_pxn.ThoiGianToiKham = TG_BatDau;
            }
            Medi_pxn.MaPin = txt_MaPin.Text.Trim().Substring(0,4);
            DateTime now = DateTime.Today;
            DateTime answer = now.AddDays(1);
            string datenow_kq = now.ToString().Replace("12:00:00 SA", "");
            string datenext = answer.ToString().Replace("12:00:00 SA", "");
            DataTable pxn_timenow = new DataTable();
            pxn_timenow = pxnBSO.Get_PXN_Date_Now(datenow_kq, datenext);
            if (pxn_timenow.Rows.Count > 0)
            {
                string kq_datenow = ConvertDate(datenow_kq);
                string maphieu = pxn_timenow.Rows[0]["MaPhieu"].ToString();
                string kq_maphieu = kq_datenow + (Convert.ToUInt32(maphieu.Substring(8)) + 1);
                Medi_pxn.MaPhieu = kq_maphieu;

            }
            else
            {
                string kq_datenow = ConvertDate(datenow_kq);
                string kq_maphieu = kq_datenow + "1";
                Medi_pxn.MaPhieu = kq_maphieu;
            }
            Medi_pxn.CreateDate = DateTime.Now;
            Medi_pxn.State = 0;
            Medi_pxn.Language = Language.language;

            return Medi_pxn;
        }
        #endregion
        #region xử lý ngày thành mã phiếu
        private string ConvertDate(string date)
        {
            string kq = "";
            kq = date.Replace("/", "");
            kq = kq.Substring(0, 8);
            return kq;
        }
        #endregion
        #region event
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                ccJoin.ValidateCaptcha(txt_MaPin.Text.Trim());

                if (!ccJoin.UserValidated)
                {
                    txt_MaPin.Focus();
                    lbl_Error.Visible = true;
                    lblErrorDate.Visible = false;
                    lblError.Text = "Mã bảo mật chưa chính xác";
                    return;
                }
                else
                {
                    if (CheckInput())
                    {
                        int sumPXN = 0;
                        pnDangKy.Visible = false;
                        btn_reset.Visible = false;
                        btnSend.Visible = false;
                        pnXacNhan.Visible = true;
                        btnQuayLai.Visible = true;
                        btnXacNhan.Visible = true;
                        ETO.Medi_PhieuXetNghiem pxn = ReceiveHtml();
                        lblKhachhang.Text = pxn.HoTen.Trim();
                        lblDiaChi.Text = pxn.DiaChi.Trim();
                        lblDoiTuong.Text = ddlDoiTuong.SelectedItem.ToString().Trim();
                        lblEmail.Text = pxn.Email.Trim();
                        lblSDT.Text = pxn.SoDienThoai.Trim();
                        lblNgayKham.Text = pxn.ThoiGianToiKham.ToString().Trim();
                        List<string> checkerNode = rtvCtChung.CheckedNodes.Select(o => o.Value).ToList();
                        if (checkerNode.Count() > 0)
                        {
                            lblChuaChonLXN.Visible = false;
                            DataTable dt2 = new DataTable();
                            dt2.Columns.Add("LoaiXetNghiem");
                            dt2.Columns.Add("GiaTien");
                            foreach (var item in checkerNode)
                            {
                                DataTable dt1 = new DataTable();
                                DataTable tb_kiApGia;
                                tb_kiApGia = pxnBSO.Get_KyApGiaMoiNhat(pxn.Id_DoiTuong);
                                int id_kyApGia = Convert.ToInt32(tb_kiApGia.Rows[0]["ID"].ToString());
                                dt1 = pxnBSO.Get_PXN_Money(id_kyApGia, Convert.ToInt32(item));
                                if (Convert.ToInt32(dt1.Rows[0]["ID_Cha"]) != 0)
                                {
                                    dt2.Rows.Add(dt1.Rows[0]["TenLoaiXN"], dt1.Rows[0]["Money"]);
                                    sumPXN = sumPXN + Convert.ToInt32(dt1.Rows[0]["Money"]);
                                }
                            }
                            rgLoaiXN_DaChon.DataSource = dt2;
                            rgLoaiXN_DaChon.DataBind();
                            lblSumPXN.Text = fomartNumberTV(sumPXN.ToString().Trim()) + " VNĐ";
                        }
                        else
                        {
                            lblChuaChonLXN.Visible = true;
                            btnXacNhan.Visible = false;
                        }
                    }
                    else
                    {
                        lbl_Error.Visible = true;
                        lblErrorDate.Visible = true;
                        lblErrorDate.Text = "Thời gian tới khám đang nhỏ hơn ngày hiện tại.";
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        protected bool CheckInput()
        {
            DateTime date1, time1, TG_BatDau;
            date1 = rdp_NgayKham.SelectedDate.Value;
            if (!rtp_GioKham.DateInput.IsEmpty)
            {
                time1 = rtp_GioKham.SelectedDate.Value;
                TG_BatDau = new DateTime(date1.Year, date1.Month, date1.Day, time1.Hour, time1.Minute, 0);
            }
            else
            {
                TG_BatDau = new DateTime(date1.Year, date1.Month, date1.Day, 0, 0, 0);
            }
            int soSanhNgayBD_KT = DateTime.Compare(TG_BatDau, DateTime.Now);
            if (soSanhNgayBD_KT < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txt_HoTen.Focus();
            txt_DiaChi.Text = "";
            txt_HoTen.Text = "";
            txt_MaPin.Text = "";
            txt_SDT.Text = "";
            txt_Tuoi.Text = "";
            txtEmail.Text = "";
            rdp_NgayKham.SelectedDate = DateTime.Now;
            rtp_GioKham.SelectedDate = DateTime.Now;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
        protected void btnXacNhan_Click(object sender, EventArgs e)
        {
            pnDangKy.Visible = false;
            btn_reset.Visible = false;
            btnSend.Visible = false;
            pnXacNhan.Visible = false;
            btnQuayLai.Visible = false;
            btnXacNhan.Visible = false;
            ETO.Medi_PhieuXetNghiem pxn = ReceiveHtml();
            pxnBSO.Createpxn(pxn);
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);

            string strBody = "Thông tin liên hệ tới Website " + config.WebName + " (" + config.WebDomain + "): <br>";

            MailBSO mailBSO = new MailBSO();
            //       mailBSO.EmailFrom = Email.Value;
            mailBSO.EmailFrom = config.Email_from;
            string strObj = "Thông tin liên hệ tới quản trị viên website " + config.WebName + " (" + config.WebDomain + ") - Ngày " + DateTime.Now.ToString("dd:MM:yyyy");
            mailBSO.SendMail(config.Email_to, strObj, strBody);
            pnSussess.Visible = true;
            lbl_success.Text = "Đăng ký xét nghiệm tại phòng khám thành công!";
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            btnQuayLai.Visible = false;
            btnXacNhan.Visible = false;
            pnXacNhan.Visible = false;
            pnDangKy.Visible = true;
            btnSend.Visible = true;
            btn_reset.Visible = true;
            txt_MaPin.Text = "";
        }
        #endregion

        #region initialize
        protected void initialize_form()
        {
            rdp_NgayKham.SelectedDate = DateTime.Now;
            rtp_GioKham.SelectedDate = DateTime.Now;
            txt_HoTen.Focus();
            ddlDoiTuong.DataSource = pxnBSO.Get_DoiTuong();
            ddlDoiTuong.DataTextField = "TenDoiTuong";
            ddlDoiTuong.DataValueField = "ID";
            ddlDoiTuong.DataBind();
            loadTree();
        }

        public static string fomartNumberTV(object obj)
        {
            string strNum = obj.ToString().Trim() == "" ? "0" : Convert.ToDecimal(obj).ToString("### ### ##0").Trim();
            strNum = strNum.Replace(" ", ",");
            return strNum;
        }
        protected void loadTree()
        {
            DataTable dt = new DataTable();
            int maDoiTuong = Convert.ToInt32(ddlDoiTuong.SelectedValue.Trim());
            dt = pxnBSO.Get_Data_LoadTree_DoiTuong(GetKyID());

            if (dt.Rows.Count > 0 && dt != null)
            {
                CreateTree(dt, maDoiTuong);
                ThongBao.Visible = false;
            }
            else
            {
                ThongBao.Visible = true;
            }
        }
        private void CreateTree(DataTable dt, int maDoiTuong)
        {
            rtvCtChung.Nodes.Clear();

            var roots = dt.Select("ID_Cha = 0");

            foreach (var dataRow in roots)
            {
                var rootNode = new RadTreeNode();
                var value = dataRow["ID_LoaiXetNghiem"].ToString().Trim();
                var text = "";
                //tính tổng tiền của menu cha
                DataTable dt_moneyCha = new DataTable();
                dt_moneyCha = pxnBSO.Get_Money_Cha(maDoiTuong, GetKyID());
                var sum = dt_moneyCha.Compute("Sum(Money)", "");
                //the end
                string cv = Convert.ToString(sum).Trim();
                //the end
                if (cv != "")
                {
                    text = dataRow["TenLoaiXN"].ToString().Trim() + " - " + "<span style='color: blue;'>" + fomartNumberTV(sum) + "(VNĐ)</span>";
                }
                else
                {
                    text = dataRow["TenLoaiXN"].ToString().Trim() + " - " + "<span style='color: blue;'>" + fomartNumberTV(dataRow["Money"]) + "(VNĐ)</span>";
                }
                rootNode.Value = value;
                rootNode.Text = text;

                rootNode.Expanded = true;

                CreateNode(rootNode, dt, maDoiTuong);
                rtvCtChung.Nodes.Add(rootNode);
            }
        }
        private void CreateNode(RadTreeNode rootNode, DataTable dt, int maDoiTuong)
        {
            var childs = dt.Select("ID_Cha = " + rootNode.Value);
            if (childs.Any())
            {
                foreach (var dataRow in childs)
                {
                    var childNode = new RadTreeNode();
                    childNode.Value = dataRow["ID_LoaiXetNghiem"].ToString().Trim();
                    var value = dataRow["ID_LoaiXetNghiem"].ToString().Trim();
                    var text = "";
                    //tính tổng tiền của menu cha
                    DataTable dt_moneyCha = new DataTable();
                    dt_moneyCha = pxnBSO.Get_Money_Cha(maDoiTuong, Convert.ToInt32(value));
                    var sum = dt_moneyCha.Compute("Sum(Money)", "");
                    string cv = Convert.ToString(sum).Trim();
                    //the end
                    if (cv != "")
                    {

                        text = dataRow["TenLoaiXN"].ToString().Trim() + " - " + "<span style='color: #018a44;'>" + fomartNumberTV(sum) + "(VNĐ)</span>";
                    }
                    else
                    {
                        text = dataRow["TenLoaiXN"].ToString().Trim() + " - " + "<span style='color: #018a44;'>" + fomartNumberTV(dataRow["Money"]) + "(VNĐ)</span>";
                    }
                    childNode.Value = value;
                    childNode.Text = text;
                    childNode.Expanded = true;
                    CreateNode(childNode, dt, maDoiTuong);
                    rootNode.Nodes.Add(childNode);
                }
            }
        }
        protected void ddlDoiTuong_IndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int maDoiTuong = Convert.ToInt32(ddlDoiTuong.SelectedValue.Trim());
            dt = pxnBSO.Get_Data_LoadTree_DoiTuong(GetKyID());
            CreateTree(dt, maDoiTuong);
        }
        private void ViewWelcome(string lang)
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(lang);
        }
        private int GetKyID()
        {
            DataTable dtky = new DataTable();
            dtky = pxnBSO.Get_KyApGia(Convert.ToInt32(ddlDoiTuong.SelectedValue));
            if (dtky.Rows.Count > 0 && dtky != null)
            {
                return (Convert.ToInt32(dtky.Rows[0][0].ToString()));

            }
            else
            {
                return 0;
            }
        }
        #endregion


    }
}