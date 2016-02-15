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
    public partial class ListCompanySelect : System.Web.UI.UserControl
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
            imgIcon.ImageUrl = "ImageHandler.aspx?image=Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }
        #endregion

        #region ViewCateNewsGroup
        public void ViewCateNewsGroup()
        {
            CateNewsGroupBSO cateNewsGroupBSO = new CateNewsGroupBSO();
            DataTable table = cateNewsGroupBSO.GetCateNewsGroupPageAll();
            
            DataList1.DataSource = table;
            DataList1.DataBind();
        }
        #endregion
    }
}