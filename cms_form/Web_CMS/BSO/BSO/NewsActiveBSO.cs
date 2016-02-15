
namespace BSO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DAO;
    using ETO;
    using System.Data;

	public class NewsActiveBSO
	{
        public DataTable GetNewsActive(int num, string approval)
        {
            NewsActiveDAO newsactiveDAO = new NewsActiveDAO();
            return newsactiveDAO.GetNewsActive(num, approval);
        }
	}
}
