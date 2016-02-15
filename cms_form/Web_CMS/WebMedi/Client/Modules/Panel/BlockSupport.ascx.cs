using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;

namespace WebMedi.Client.Modules.Panel
{
    public partial class BlockSupport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewSupport();
        }

        private void ViewSupport()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            ltlSupport.Text = config.Support;
        }
    }
}