using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using BSO;
using System.Globalization;
using System.Drawing;

namespace CMS.Client.Admin
{
    public partial class MeDiXoaDoituong : System.Web.UI.Page
    {

        public int id
        {
            get { return Convert.ToInt32(Request["ID"]); }
        }
        readonly Medi_QuanLyDoiTuongBSO _doituong = new Medi_QuanLyDoiTuongBSO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                xoaDoiTuong();
            }


        }
        protected void xoaDoiTuong()
        {
            DataTable dtTenDoiTuong = new DataTable();
            dtTenDoiTuong = _doituong.getTenDoiTuong(id);


            DataTable checkDoiTuong = new DataTable();
            checkDoiTuong = _doituong.checkDoiTuong(id);
            if (checkDoiTuong.Rows.Count > 0 && checkDoiTuong != null)
            {
                Btn_Chitiet.Visible = true;
                ThongBao.Text = "Không thể xóa đối tượng: " + "<span style='color: #018a44;'>" + (dtTenDoiTuong.Rows[0][0].ToString()) + "</span>" + " vì đã có phiếu xét nghiệm áp dụng loại đối tượng này !";
                Btn_Save.Visible = false;
            }
            else
            {

                Btn_Chitiet.Visible = false;

                ThongBao.Text = "Bạn muốn xóa đối tượng: " + "<span style='color: #018a44;'>" + (dtTenDoiTuong.Rows[0][0].ToString()) + "</span>" + " .Các bảng giá áp cho đối tượng sẽ được xóa khỏi hệ thống !";


            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true); // Call client method in radwindow page


        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            _doituong.Delete_DoiTuong(id);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true); // Call client method in radwindow page

        }
        protected void Btn_ChiTiet(object sender, EventArgs e)
        {
            Danhmuc.Visible = true;
            loadDanhMucPhieu();
        }
        protected void loadDanhMucPhieu()
        {
            DataTable dtDanhMucPhieu = new DataTable();
            dtDanhMucPhieu = _doituong.getDanhMucPhieu(id);
            DanhMucPhieu.DataSource = dtDanhMucPhieu;
            DanhMucPhieu.DataBind();
        }
        protected void gvChiTieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            loadDanhMucPhieu();
        }
        protected void gvUserManager_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
        }
    }
}