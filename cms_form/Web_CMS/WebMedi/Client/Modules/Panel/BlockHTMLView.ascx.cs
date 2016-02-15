using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;

namespace WebMedi.Client.Modules.Panel
{
    public partial class BlockHTMLView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrContent.Text = hddContent.Value;
        }
    }
}