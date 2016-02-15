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
using System.Drawing;

namespace CMS.Client.Admin
{
    public partial class NhapKQ_XetNghiem : System.Web.UI.UserControl
    {
        protected string InputValue { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadTTKH();
            }
        }

        public void Delete(string url)
        {
            var filePath = Path.Combine(Server.MapPath("~/"), url);
            System.IO.File.Delete(filePath);

        }
        protected void btn_Order_Click(object sender, EventArgs e)
        {
            string fileuploadDir = Server.MapPath("~/Upload/uploadKQ/");
            if (!System.IO.Directory.Exists(fileuploadDir))
            {
                System.IO.Directory.CreateDirectory(fileuploadDir);
            }
            string fileName = fuSample.FileName;
            if (fileName.Contains(".pdf"))
            {
                string fileuploadpath = Server.MapPath("~/Upload/uploadKQ/") + Path.GetFileName(fuSample.FileName);
                fuSample.SaveAs(fileuploadpath);

                string maPhieu = Page.RouteData.Values["id"].ToString().Trim();
                string filePath = "Upload/uploadKQ/" + fileName;
                DateTime ngayCapNhat = DateTime.Now;
                string nguoiCapNhat = Convert.ToString(Session["Admin_Username"]);
                Medi_PhieuXetNghiemBSO md = new Medi_PhieuXetNghiemBSO();
                try
                {
                    DataTable dt_PXN = md.Get_ThongTinKH(maPhieu);
                    if (dt_PXN.Rows.Count > 0)
                    {
                        if (dt_PXN.Rows[0]["Filepath"].ToString().Trim() != "")
                        {
                            Delete(dt_PXN.Rows[0]["Filepath"].ToString().Trim());
                        }
                    }
                    md.update_PhieuXetNghiem(maPhieu, filePath, 6, ngayCapNhat, nguoiCapNhat);
                    this.InputValue = filePath;
                    pn_PDF.Visible = true;
                    lblMessage.ForeColor = Color.Blue;
                    lblMessage.Text = "Nhập kết quả thành công";
                }
                catch
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = "Nhập kết quả không thành công";
                }

            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Tải file không thành công. Kiểm tra lại định dạng file";
            }
        }
        protected void loadTTKH()
        {
            string maPhieu = Page.RouteData.Values["id"].ToString().Trim();
            Medi_PhieuXetNghiemBSO md = new Medi_PhieuXetNghiemBSO();
            DataTable dt = new DataTable();
            dt = md.Get_ThongTinKH(maPhieu);
            if (dt.Rows.Count > 0)
            {
                lbl_MaPhieu.Text = dt.Rows[0]["MaPhieu"].ToString().Trim();
                lbl_HoTen.Text = dt.Rows[0]["HoTen"].ToString().Trim();
                if (Convert.ToBoolean(dt.Rows[0]["GioiTinh"]) == true)
                {
                    lbl_GioiTinh.Text = "Nam";
                }
                else
                {
                    lbl_GioiTinh.Text = "Nữ";
                }
                lbl_Tuoi.Text = dt.Rows[0]["Tuoi"].ToString().Trim();
                lbl_SDT.Text = dt.Rows[0]["SoDienThoai"].ToString().Trim();
                lbl_NgayKham.Text = dt.Rows[0]["ThoiGianToiKham"].ToString().Trim();
                lbl_NgayDangKy.Text = dt.Rows[0]["CreateDate"].ToString().Trim();
                if (dt.Rows[0]["State"].ToString().Trim() == "6")
                {
                    pn_PDF.Visible = true;
                    System.IO.Path.GetFileNameWithoutExtension(dt.Rows[0]["Filepath"].ToString().Trim());
                    //Path.GetFileName(dt.Rows[0]["Filepath"].ToString().Trim());
                    this.InputValue = dt.Rows[0]["Filepath"].ToString().Trim();
                }
                else
                {
                    pn_PDF.Visible = false;
                }

            }
        }
    }
}