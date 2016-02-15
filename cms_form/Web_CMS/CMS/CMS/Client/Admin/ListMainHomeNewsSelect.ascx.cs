using System;
using BSO;

namespace CMS.Client.Admin
{
    public partial class ListMainHomeNewsSelect : System.Web.UI.UserControl
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
            var modulesBSO = new ModulesBSO();
            var modules = modulesBSO.GetModulesByUrl(url);
            imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }
        #endregion

        #region ViewCateNewsGroup
        public void ViewCateNewsGroup()
        {
            var cateNewsGroupBSO = new CateNewsGroupBSO();
            var table = cateNewsGroupBSO.GetCateNewsGroupHomeAll();

            DataList1.DataSource = table;
            DataList1.DataBind();
        }
        #endregion
    }
}