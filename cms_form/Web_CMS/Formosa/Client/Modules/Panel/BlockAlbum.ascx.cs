using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;

namespace Fomusa.Client.Modules.Panel
{
    public partial class BlockAlbum : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
            int groupcate = Convert.ToInt32(hddValue.Value);
        }
    }
}