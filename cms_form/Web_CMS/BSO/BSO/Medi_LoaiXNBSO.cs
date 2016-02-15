
namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;
    public class Medi_LoaiXNBSO
    {
        public void Createlxn(Medi_LoaiXN pxn)
        {
            new Medi_LoaiXNDAO().CreateLoaiXetNghiem(pxn);
        }
        #region get value BSO
        public DataTable Get_Item_LXN(int idLXN)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            DataTable dt = new DataTable();
            dt = md.Get_Item_LXN(idLXN);
            return dt;
        }
        public DataTable Get_Before_Data(float index, int id_cha)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            DataTable dt = new DataTable();
            dt = md.Get_Before_Data(index, id_cha);
            return dt;
        }
        public DataTable Get_Affter_Data(float index, int id_cha)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            DataTable dt = new DataTable();
            dt = md.Get_Affter_Data(index, id_cha);
            return dt;
        }
        public DataTable Get_Data_LoadTree()
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            DataTable dt = new DataTable();
            dt = md.Get_Data_LoadTree();
            return dt;
        }
        public DataTable Get_Affter_Data_NodeChild(int id_cha)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            DataTable dt = new DataTable();
            dt = md.Get_Affter_Data_NodeChild(id_cha);
            return dt;
        }
        public void Update_LXN(int id, string tenLXN)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            md.Update_LXN(id, tenLXN);
        }
        public void Delete_LXN(int id)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            md.Delete_LXN(id);
        }
        public DataTable Get_List_LXN(string key_value)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            DataTable dt = new DataTable();
            dt = md.Get_List_LXN(key_value);
            return dt;
        }
        public DataTable Get_Parent_Data(int id_cha)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            DataTable dt = new DataTable();
            dt = md.Get_Parent_Data(id_cha);
            return dt;
        }
        public bool Update_Node_THop(int id, string tentheloai, int id_cha, float index)
        {
            try
            {
                Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
                md.Update_Node_THop(id, tentheloai, id_cha, index);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable Get_Data_LXN_TheoID(int id_LXN)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            DataTable dt = new DataTable();
            dt = md.Get_Data_LXN_TheoID(id_LXN);
            return dt;
        }
        public void Delete_GiaLXN(int id)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            md.Delete_GiaLXN(id);
        }
        public int Get_ID_LXN_New()
        {
            int id_LXNNEW = 0;
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            DataTable dt = new DataTable();
            dt = md.Get_LXN_New();
            id_LXNNEW = Convert.ToInt32(dt.Rows[0]["ID"].ToString().Trim());
            return id_LXNNEW;
        }
        public void Update_Index_LXN(int id,float index)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            md.Update_Index_LXN(id, index);
        }
        // 
        public DataTable Check_CungTen(int idCha, string ten)
        {
            Medi_LoaiXNDAO md = new Medi_LoaiXNDAO();
            DataTable dt = new DataTable();
            dt = md.Check_TrungTen(idCha,ten);
            return dt;
        }
        #endregion

    }
}
