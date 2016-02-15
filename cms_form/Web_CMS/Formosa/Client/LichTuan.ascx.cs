using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BSO;

namespace Fomusa.Client
{
    public partial class LichTuan : System.Web.UI.UserControl
    {
        DataTable dtLichTuan;
        LichTuanBSO lichTuanBSO = new LichTuanBSO();
        protected void Page_Load(object sender, EventArgs e)
        {
            dtLichTuan = lichTuanBSO.LichTuan_GetByDate(DateTime.Now);
        }
        protected void rgMain_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            rgMain.DataSource = dtLichTuan;
        }
    }
}