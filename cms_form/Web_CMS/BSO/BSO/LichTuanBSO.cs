
namespace BSO
{
    using System;
    using System.Data;
    using DAO;

    public class LichTuanBSO
    {
        public DataTable LichTuan_GetByDate(DateTime Ngay)
        {
            LichTuanDAO lichTuanDAO = new LichTuanDAO();
            return lichTuanDAO.LichTuan_GetByDate(Ngay);
        }
    }
}
