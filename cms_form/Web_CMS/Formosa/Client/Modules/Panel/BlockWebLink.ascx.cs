using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Data;

namespace Fomusa.Client.Modules.Panel
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
            DropDownList1.DataSource = table;
            DropDownList1.DataTextField = "BrandName";
            DropDownList1.DataValueField = "BrandUrl";
            DropDownList1.DataBind();
        }
    }
}