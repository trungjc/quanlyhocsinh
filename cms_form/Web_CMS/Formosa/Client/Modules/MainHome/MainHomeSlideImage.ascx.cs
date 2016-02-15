using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Data;

namespace Fomusa.Client.Modules.MainHome
{
    public partial class MainHomeSlideImage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewAdv();
        }
        private void ViewAdv()
        {
            LinkBSO advBSO = new LinkBSO();
            DataTable table = advBSO.GetLinkAll();
            DataView dataView = new DataView(table);
            dataView.RowFilter = "LinkStatus = 'True' and LinkType=1";

            //  RadRotator1.RotatorType = RotatorType.AutomaticAdvance;
            RadRotator1.DataSource = dataView;
            RadRotator1.DataBind();
        }

        protected Unit UnitNum(object obj)
        {
            Unit un = 0;
            un = Convert.ToUInt16(obj.ToString());
            return un;
        }
    }
}