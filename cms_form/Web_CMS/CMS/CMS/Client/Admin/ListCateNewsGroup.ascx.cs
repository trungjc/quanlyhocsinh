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
    public partial class ListCateNewsGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                ViewCateGroup();
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

        #region ViewCateGroup
        private void ViewCateGroup()
        {
            ConfigBSO configBSO = new ConfigBSO();
            int Ngon_Ngu = Convert.ToInt32(ViewState["CauHinh_Viet"]);
            if (Ngon_Ngu == 1 || Ngon_Ngu == 0)
            {
                CateNewsGroupBSO CateBSO = new CateNewsGroupBSO();
                DataTable table = CateBSO.GetCateLanguage(Language.language);
                commonBSO commonBSO = new commonBSO();
                commonBSO.FillToGridView(grvCateNewsGroup, table);
            }
            else
            {
                CateNewsGroupBSO CateBSO = new CateNewsGroupBSO();
                DataTable table = CateBSO.GetCateLanguage(Language.language_Eng);
                commonBSO commonBSO = new commonBSO();
                commonBSO.FillToGridView(grvCateNewsGroup, table);
            }
            //CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
            //DataTable table = catenewsGroupBSO.GetCateNewsGroupAll();
            //commonBSO commonBSO = new commonBSO();
            //commonBSO.FillToGridView(grvCateNewsGroup, table);

        }
        #endregion

        protected void grvCateNewsGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCateNewsGroup.PageIndex = e.NewPageIndex;
            ViewCateGroup();
        }
        protected void grvCateNewsGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string nName = e.CommandName.ToLower();
            switch (nName)
            {

                case "_edit":
                    Response.Redirect("~/Admin/editcatenewsgroup/" + Id + "/Default.aspx");
                    break;
                case "_delete":
                    CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
                    catenewsGroupBSO.DeleteCateNewsGroup(Id);
                    ViewCateGroup();
                    break;
            }
        }
        protected void grvCateNewsGroup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gridViewRow = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
            }
        }
        protected void btn_Order_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in grvCateNewsGroup.Rows)
            {
                TextBox textOrder = (TextBox)row.FindControl("txtOrder");
                int cOrder = Convert.ToInt32(textOrder.Text);
                int cateID = Convert.ToInt32(row.Cells[0].Text);
                CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
                catenewsGroupBSO.CateNewsGroupUpOrder(cateID, cOrder);
            }
            ViewCateGroup();
        }
        protected void Viet_Check(object sender, EventArgs e)
        {
            ViewState["CauHinh_Viet"] = 1;
            ViewCateGroup();
        }
        protected void Eng_Check(object sender, EventArgs e)
        {
            ViewState["CauHinh_Viet"] = 2;
            ViewCateGroup();
        }

    }
}