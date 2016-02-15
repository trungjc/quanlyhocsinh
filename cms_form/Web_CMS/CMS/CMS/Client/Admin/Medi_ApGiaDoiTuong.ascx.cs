using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using BSO;
using System.Data;
using Telerik.Web.UI;
using System.Drawing;
using ETO;
namespace CMS.Client.Admin
{
    public partial class Medi_ApGiaDoiTuong : System.Web.UI.UserControl
    {
        readonly Medi_QuanLyDoiTuongBSO _doiTuong = new Medi_QuanLyDoiTuongBSO();
        enum PageAction { Default, Cancel, ApGia, Save }
        public int IdND()
        {
            string tenDN = Session["Admin_UserName"].ToString();
            DataTable DtTen = new DataTable();
            DtTen = _doiTuong.GetID(tenDN);
            return (Convert.ToInt32(DtTen.Rows[0][0].ToString()));
        }

        #region initialize
        private void NavigationTitle(string url)
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            Modules modules = modulesBSO.GetModulesByUrl(url);
            imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }
        #endregion

        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

            if (!IsPostBack)
            {
                EventEnter();
                int idDoituong = GetNhomDoiTuong();
                Loadtendoituong(idDoituong);
                LoadLichSu();
                LoadTimKiem();
                LoadDefault();
                ShowControl(PageAction.Default);
            }
        }

        protected void Pageindex_change(object source, GridPageChangedEventArgs e)
        {
            LoadLichSu();

        }

        protected void Pageindex_change_DanhMuc(object source, GridPageChangedEventArgs e)
        {
            LoadTimKiem();
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            thongbao.Visible = false;
            string comand = e.CommandName;
            switch (comand)
            {
                case "RowClick":
                    TxtTimKiem.Text = "";
                    int iD = Convert.ToInt32((e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString());
                    LoadDonViRow(iD);
                    ShowControl(PageAction.Cancel);
                    break;
                default: break;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            DanhMuc.AllowPaging = true;
            DanhMuc.PageSize = 20;
            DanhMuc.AllowSorting = true;
            int checkNullRadGrid = Grid_LichSu.MasterTableView.Items.Count;
            if (checkNullRadGrid != 0)
            {
                Grid_LichSu.MasterTableView.Items[0].Selected = true;
            }

            int idnew = GetIDKy();
            DataTable loadGiaThanhEdit = new DataTable();
            loadGiaThanhEdit = _doiTuong.Get_GiaTien(idnew);
            DanhMuc.DataSource = loadGiaThanhEdit;
            DanhMuc.DataBind();
            ShowControl(PageAction.Cancel);

        }

        protected void btnApGia_Click(object sender, EventArgs e)
        {
            DanhMuc.AllowPaging = false;
            DanhMuc.AllowSorting = false;
            LoadTimKiem();
            ShowControl(PageAction.ApGia);
        }
        protected void btnApGiaSaVe_Click(object sender, EventArgs e)
        {
            Save();
            int idnew = GetIDKy();
            DataTable loadGiaThanhEdit = new DataTable();
            loadGiaThanhEdit = _doiTuong.Get_GiaTien(idnew);
            DanhMuc.DataSource = loadGiaThanhEdit;
            DanhMuc.DataBind();
            ShowControl(PageAction.Save);
        }

        protected void RadButton_Timkiem_Click(object sender, EventArgs e)
        {
            thongbao.Visible = false;
            int checkNullRadGrid = Grid_LichSu.MasterTableView.Items.Count;
            if (checkNullRadGrid != 0)
            {
                Grid_LichSu.MasterTableView.Items[0].Selected = true;
            }
            LoadTimKiem();
            thongbao.Visible = false;
        }

        protected void RadButtonLamMoi_Click(object sender, EventArgs e)
        {
            int checkNullRadGrid = Grid_LichSu.MasterTableView.Items.Count;
            if (checkNullRadGrid != 0)
            {
                Grid_LichSu.MasterTableView.Items[0].Selected = true;
            }
            thongbao.Visible = false;
            TxtTimKiem.Text = "";
            LoadTimKiem();
            TxtTimKiem.Focus();
        }

        #endregion

        #region Custom Methods
        private int GetIDKy()
        {
            DataTable getIDKy = new DataTable();
            getIDKy = _doiTuong.GET_ID_KY();

            if (getIDKy.Rows.Count > 0 && getIDKy != null)
            {
                return (Convert.ToInt32(getIDKy.Rows[0]["ID"].ToString()));
            }
            else
            {
                return 0;
            }
        }

        protected void LoadDefault()
        {
            TxtTimKiem.Focus();
            Grid_LichSu.SelectedIndexes.Add(0);
            DanhMuc.Columns[1].Visible = false;
            DanhMuc.Columns[2].Visible = true;
            NguoiSua.Text = Session["Admin_UserName"].ToString();
        }

        protected void Save()
        {

            thongbao.Visible = true;
            this.Grid_LichSu.CurrentPageIndex = 0;
            string lyDoLuu = lydo.Text.Trim();




            int idNd = IdND();
            // lấy đối tượng
            int Iddoituong = GetNhomDoiTuong();
            DateTime thoiGianSave = DateTime.Now;

            // Insert kỳ báo cáo vào trước.
            DataTable dtCreateKy = new DataTable();
            dtCreateKy = _doiTuong.CREATE_KY(thoiGianSave, idNd, lyDoLuu, Iddoituong);
            // lấy id kỳ áp giá đã lưu
            int idKeyCreate = 0;
            if (dtCreateKy != null && dtCreateKy.Rows.Count > 0)
            {
                idKeyCreate = Convert.ToInt32(dtCreateKy.Rows[0][0].ToString());
            }
            foreach (GridDataItem item in DanhMuc.Items)
            {
                int ID = Convert.ToInt32(item.GetDataKeyValue("ID").ToString());
                RadNumericTextBox donGia = (RadNumericTextBox)item.FindControl("txt_tien");
                int donGiaSave = donGia.Text == "" ? 0 : Convert.ToInt32(donGia.Text.ToString().Trim());
                DataTable saveDonGia = new DataTable();
                _doiTuong.Save_dongia(ID, donGiaSave, idKeyCreate);
            }

            LoadLichSu();
            LoadTimKiem();

            Grid_LichSu.SelectedIndexes.Add(0);

        }

        private int GetNhomDoiTuong()
        {
            int Iddoituong = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Iddoituong);
            return Iddoituong;
        }

        // lấy danh sách áp giá theo kỳ báo
        protected void LoadDonVi()
        {
            int id = GetIDKy();
            DataTable giaTien = new DataTable();
            giaTien = _doiTuong.Get_GiaTien(id);
            DanhMuc.DataSource = giaTien;
            DanhMuc.DataBind();

            // set độ  rộng scorl theo từng trường hợp
            if (giaTien.Rows.Count > 0 && giaTien != null)
            {
                DanhMuc.ClientSettings.Scrolling.ScrollHeight = 300;
            }
            else
            {
                DanhMuc.ClientSettings.Scrolling.ScrollHeight = 30;

            }
        }
        // lấy đơn vị theo kỳ báo cáo và tên text tìm kiếm
        protected void LoadDonViTimKiem(string ten)
        {

            int id = GetIDKy();
            DataTable giaTien = new DataTable();
            giaTien = _doiTuong.Get_GiaTien_TimKiem(id, ten);
            DanhMuc.DataSource = giaTien;
            DanhMuc.DataBind();

            // set độ  rộng scorl theo từng trường hợp
            if (giaTien.Rows.Count > 0 && giaTien != null)
            {
                DanhMuc.ClientSettings.Scrolling.ScrollHeight = 300;
            }
            else
            {
                DanhMuc.ClientSettings.Scrolling.ScrollHeight = 30;

            }
        }

        protected void Loadtendoituong(int iddoituong)
        {
            int idDoiTuong = GetNhomDoiTuong();
            DataTable dtTenDoiTuong = new DataTable();
            dtTenDoiTuong = _doiTuong.getTenDoiTuong(idDoiTuong);
            Text_apgia.Text = dtTenDoiTuong.Rows[0][0].ToString();

        }

        // lấy dữ liệu khi load 1 row trên hàng
        protected void LoadDonViRow(int id)
        {

            DataTable giaTien = new DataTable();
            giaTien = _doiTuong.Get_GiaTien(id);
            DanhMuc.DataSource = giaTien;
            DanhMuc.DataBind();

            // set độ  rộng scorl theo từng trường hợp
            if (giaTien.Rows.Count > 0 && giaTien != null)
            {
                DanhMuc.ClientSettings.Scrolling.ScrollHeight = 300;
            }
            else
            {
                DanhMuc.ClientSettings.Scrolling.ScrollHeight = 30;

            }
        }

        protected void LoadTimKiem()
        {
            string tenloaiXN = TxtTimKiem.Text.Trim();

            if (tenloaiXN.Length == 0)
            {
                LoadDonVi();
            }
            else
            {
                LoadDonViTimKiem(tenloaiXN);
            }
            thongbao.Visible = false;
        }

        protected void LoadLichSu()
        {
            DataTable dtLichsu = new DataTable();
            dtLichsu = _doiTuong.Get_Lichsu_apgia();
            Grid_LichSu.DataSource = dtLichsu;
            Grid_LichSu.DataBind();

            // set độ  rộng scorl theo từng trường hợp
            if (dtLichsu.Rows.Count > 0 && dtLichsu != null)
            {
                Grid_LichSu.ClientSettings.Scrolling.ScrollHeight = 130;
            }
            else
            {
                Grid_LichSu.ClientSettings.Scrolling.ScrollHeight = 30;

            }
        }
        private void ShowControl(PageAction pageAction)
        {
            switch (pageAction)
            {
                case PageAction.Default:
                    RadButton_Save.Visible = false;
                    RadButton_ApGia.Visible = true;
                    thongbao.Visible = false;
                    break;
                case PageAction.ApGia:

                    lydo.Focus();
                    RadButton_Save.Visible = true;
                    RadButton_ApGia.Visible = false;
                    RadButton_Back.Visible = true;
                    DanhMuc.Columns[1].Visible = true;
                    DanhMuc.Columns[2].Visible = false;
                    thongTinEdit.Visible = true;
                    TimKiem.Visible = false;

                    //todo: cuonglt 4/21/15
                    int checkNullRadGrid = Grid_LichSu.MasterTableView.Items.Count;
                    if (checkNullRadGrid != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Grid_LichSu.MasterTableView.Items[i].Selected = false;
                        }

                    }
                    break;
                case PageAction.Save:
                    lydo.Text = "";
                    DanhMuc.AllowPaging = false;
                    DanhMuc.AllowSorting = false;
                    RadButton_Back.Visible = true;
                    RadButton_Back.Text = "Hủy";
                    RadButton_ApGia.Visible = false;
                    thongbao.Visible = true;

                    break;
                case PageAction.Cancel:
                    this.Grid_LichSu.CurrentPageIndex = 0;
                    RadButton_ApGia.Visible = true;
                    thongbao.Visible = false;
                    DanhMuc.AllowPaging = true;
                    DanhMuc.PageSize = 20;
                    DanhMuc.AllowSorting = true;
                    RadButton_Back.Visible = false;
                    // RadButton_Back.Text = "Quay lại";
                    RadButton_Save.Visible = true;
                    RadButton_Save.Visible = false;
                    thongTinEdit.Visible = false;
                    TimKiem.Visible = true;
                    DanhMuc.Columns[2].Visible = true;
                    DanhMuc.Columns[1].Visible = false;
                    thongTinEdit.Visible = false;
                    thongbao.Visible = false;
                    break;
            }
        }
        protected void EventEnter()
        {
            TxtTimKiem.Attributes.Add("onKeyPress", "doClick('" + RadButton_Timkiem.ClientID + "',event)");

        }
        #endregion
    }
}