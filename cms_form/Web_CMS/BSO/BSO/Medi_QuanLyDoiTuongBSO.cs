
namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;
    public class Medi_QuanLyDoiTuongBSO
    {
        //lầyull đối tượng
        public DataTable Get_DoiTuong()
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.Get_ThongTin_DoiTuong();
            return dt;
        }
        //update đối tượng
        public void update_DoiTuong(int ID, string tendoituong)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            md.Update_doituong(ID, tendoituong);
        }
        // lấy tên đối tượng theo id

        //save đối tượng
        public void Insert_DoiTuong(string tendoituong)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            md.Insert_doituong(tendoituong);
        }
        //xóa đối tượng
        public void Delete_DoiTuong(int ID)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            md.Delete_doituong(ID);
        }

        // lấy danh sách lịch sử người dùng đã áp giá
        public DataTable Get_Lichsu_apgia()
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.Get_Lichsu_apgia();
            return dt;
        }
        // lấy bảng giá tiền
        // lấy danh sách lịch sử người dùng đã áp giá
        public DataTable Get_GiaTien(int ID)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.Get_GiaTien(ID);
            return dt;
        }

        // lấy giá tiền khi tìm kiếm
        public DataTable Get_GiaTien_TimKiem(int ID, string ten)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.Get_GiaTien_timKiem(ID, ten);
            return dt;
        }


        // lấy id kỳ
        public DataTable GET_ID_KY()
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.Get_ID_KY();
            return dt;
        }

        // Save đơn giá
        public void Save_dongia(int idLoaiXetNghiem, int money, int idkey)
        {

            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();

            DataTable dt = new DataTable();
            dt = md.Save_dongia(idkey, idLoaiXetNghiem, money);
        }
        //create kỳ
        public DataTable CREATE_KY(DateTime thoiGian, int ndID, string lydo, int idDoituong)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.getKeysave_dongia(thoiGian, ndID, lydo, idDoituong);

            return dt;
        }


        // lấy tên đối tượng
        public DataTable getTenDoiTuong(int idDoiTuong)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.getTenDoiTuong(idDoiTuong);

            return dt;
        }


        // check dối tượng đã được dùng hay chưa
        public DataTable checkDoiTuong(int ID)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.checkDoiTuong(ID);
            return dt;
        }

        // lấy danh sách laoij phiếu
        public DataTable getDanhMucPhieu(int ID)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.getDanhMucPhieu(ID);
            return dt;
        }


        // lấy id người dung
        public DataTable GetID(string ten)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.GetID(ten);
            return dt;
        }

        // lấy danh sách các đối tượng
        public DataTable GetDanhSachDoiTuong()
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.GetDanhSachDoiTuong();
            return dt;
        }


        // lấy Số phiếu chưa xét nghiệm
        public DataTable GetPhieuChuaXetNghiem()
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.GetPhieuChuaXetNghiem();
            return dt;
        }

        // Chức năng tìm kiếm cơ bản phiếu xét nghiệm
        public DataTable TimKiemCoBan(string dauvao, int trangthai, int idDoiTuong)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.TimKiemCoBan(dauvao,trangthai,idDoiTuong);
            return dt;
        }
        // tìm kiếm nâng cao phiếu xét nghiệm
        public DataTable TimKiemNangCao(string maphieu, string hoten, string mabacode, string sothebh, int iddt, string diachi, int state, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.TimKiemNangCao(maphieu,hoten,mabacode,sothebh,iddt,diachi,state,ngaybatdau,ngayketthuc);
            return dt;
        }
        //lấy tên đối tượng
        public DataTable Get_DoiTuong( string tenDoiTuong)
        {
            Medi_QuanLyDoiTuong md = new Medi_QuanLyDoiTuong();
            DataTable dt = new DataTable();
            dt = md.GetTenDoiTuong(tenDoiTuong);
            return dt;
        }

    }
}

