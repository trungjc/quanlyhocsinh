using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;

namespace Fomusa.Client
{
    public partial class BannerIntro : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewIntro();
        }
        private void ViewIntro()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.lang);
            ltlIntro.Text = config.Counter;
        }
    }
}