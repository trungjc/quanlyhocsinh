using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fomusa.Client.Modules.MainHome
{
    public partial class MainHomeTabGroupNews : System.Web.UI.UserControl
    {
        protected string MyTab;
        protected void Page_Load(object sender, EventArgs e)
        {
            MyTab = RadTabStrip1.InnerMostSelectedTab.Text;
        }
    }
}