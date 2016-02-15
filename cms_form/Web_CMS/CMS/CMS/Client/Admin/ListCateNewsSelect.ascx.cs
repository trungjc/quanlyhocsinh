using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Data;

namespace CMS.Client.Admin
{
    public partial class ListCateNewsSelect : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());


            if (!IsPostBack)
            {
                ViewCateNewsGroup();

            }
        }

        #region NavigationTitle
        private void NavigationTitle(string url)
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            Modules modules = modulesBSO.GetModulesByUrl(url);
            imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }
        #endregion

        #region ViewCateNewsGroup
        public void ViewCateNewsGroup()
        {
            int Ngon_Ngu = Convert.ToInt32(ViewState["CauHinh_Viet"]);

            CateNewsGroupBSO cateNewsGroupBSO = new CateNewsGroupBSO();
            //DataTable table = cateNewsGroupBSO.GetCateNewsGroupViewAll();
            DataTable table = new DataTable();
            if (Ngon_Ngu == 1 || Ngon_Ngu == 0)
                table = cateNewsGroupBSO.GetCateLanguage(Language.language);
            else
                table = cateNewsGroupBSO.GetCateLanguage(Language.language_Eng);

            DataList1.DataSource = table;
            DataList1.DataBind();

        }
        #endregion

        protected void Viet_Check(object sender, EventArgs e)
        {
            ViewState["CauHinh_Viet"] = 1;
            ViewCateNewsGroup();
        }

        protected void Eng_Check(object sender, EventArgs e)
        {
            ViewState["CauHinh_Viet"] = 2;
            ViewCateNewsGroup();
        }
    }
}