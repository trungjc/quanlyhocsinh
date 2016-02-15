namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;
    public class Medi_PhieuXetNghiemBSO
    {
        public void Createpxn(Medi_PhieuXetNghiem pxn)
        {
            new Medi_PhieuXetNghiemDAO().CreatePhieuXetNghiem(pxn);
        }
        public void update_PhieuXetNghiem(string maPhieu, string filePath, int state, DateTime lastUpdate, string lastUpdateBy)
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            md.Update_PhieuXN(maPhieu, filePath, state, lastUpdate, lastUpdateBy);
        }
        #region Get value BSO
        public DataTable Get_pxn(string language)
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_PhieuXetNghiem(language);
            return dt;
        }
        public DataTable Get_ThongTinKH(string maPhieu)
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_ThongTinKhachHang(maPhieu);
            return dt;
        }
     
        public DataTable Get_Data_LoadTree_DoiTuong(int kyapdung)
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_Data_LoadTree_DoiTuong(kyapdung);
            return dt;
        }
        public DataTable Get_Money_Cha(int kyapdung, int id_Cha)
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_Money_Cha(kyapdung, id_Cha);
            return dt;
        }
        public DataTable Get_PXN_Money(int maDoiTuong, int id_LoaiXN)
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_PXN_Money(maDoiTuong, id_LoaiXN);
            return dt;
        }
        //lay ki ap gia moi nhat
        public DataTable Get_KyApGiaMoiNhat(int maDoiTuong)
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_KyApGiaMoiNhat(maDoiTuong);
            return dt;
        }
        // lấy trạng thái theo mã phiếu
        public DataTable GetTrangThai(string maphieu)
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_TrangThai(maphieu);
            return dt;
        }
        // lấy danh sachs phiếu theo trạng thái chưa xác nhận
        public DataTable GetDanhSachPhieuChuaXacNhan()
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_DanhSachPhieuChuaXacNhan();
            return dt;
        }
        //lấy danh sách phiếu xét nghiệm có trong ngày
        public DataTable Get_PXN_Date_Now(string dateNow, string dateNext)
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_PXN_Date_Now(dateNow, dateNext);
            return dt;
        }
        #endregion
        #region phần tra cứu
        public DataTable GetKQ_XetNghiem(string maphieu, string mapin )
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.GetKQ_XetNghiem(maphieu, mapin);
            return dt;
        }
        #endregion 

        #region get data service
        public DataTable Get_Data_Service()
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_Data_Service();
            return dt;
        }
        public DataTable Get_DoiTuong()
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_DoiTuong();
            return dt;
        }

        // lấy id kỳ áp giá mới nhất của đối tượng

        public DataTable Get_KyApGia(int iddoituong)
        {
            Medi_PhieuXetNghiemDAO md = new Medi_PhieuXetNghiemDAO();
            DataTable dt = new DataTable();
            dt = md.Get_KyApGia(iddoituong);
            return dt;
        }

        #endregion
    }
}
