using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BSO;
using ETO;

namespace WebMedi.Client.Modules.Panel
{
    public partial class BlockWebLink : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewBrand(Language.language);
        }

        private void ViewBrand(string lang)
        {
            BrandBSO brandBSO = new BrandBSO();
            DataTable table = brandBSO.GetBrandAll(lang);
            Repeater1.DataSource = table;
            Repeater1.DataBind();
        }
    }
}