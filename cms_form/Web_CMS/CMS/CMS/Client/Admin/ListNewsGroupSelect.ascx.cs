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
    public partial class ListNewsGroupSelect : System.Web.UI.UserControl
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
            CateNewsGroupBSO cateNewsGroupBSO = new CateNewsGroupBSO();
            DataTable table = new DataTable();
            int Ngon_Ngu = Convert.ToInt32(ViewState["CauHinh_Viet"]);
            if (Ngon_Ngu == 1 || Ngon_Ngu == 0)
                table = cateNewsGroupBSO.GetCateLanguage(Language.language);
            else
                table = cateNewsGroupBSO.GetCateLanguage(Language.language_Eng);

            DataView dv = new DataView(table);
            dv.RowFilter = "GroupCate <> 4";
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    if (Convert.ToInt32(table.Rows[i]["GroupCate"]) == 4)
            //    {
            //        table.Rows[i].Delete();
            //    }
            //}
            //table.AcceptChanges();
            DataList1.DataSource = dv.ToTable();
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