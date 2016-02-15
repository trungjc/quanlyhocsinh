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
    public partial class ListAlbumsCate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {

                ViewAlbumsCate();

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

        #region ViewAlbumsCate
        private void ViewAlbumsCate()
        {
            AlbumsCateBSO albumcateBSO = new AlbumsCateBSO();
            DataTable table = albumcateBSO.GetAlbumsCate();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvAlbumsCate, table);

        }
        #endregion

        protected void grvAlbumsCate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAlbumsCate.PageIndex = e.NewPageIndex;
            ViewAlbumsCate();
        }
        protected void grvAlbumsCate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string nName = e.CommandName.ToLower();
            switch (nName)
            {
                case "_viewimage":
                    Response.Redirect("~/Admin/listalbums/" + Id + "/Default.aspx");
                    break;

                case "_addimage":
                    Response.Redirect("~/Admin/Group/editalbums/" + Id + "/Default.aspx");
                    break;

                case "_edit":
                    Response.Redirect("~/Admin/editalbumscate/" + Id + "/Default.aspx");
                    break;
                case "_delete":
                    AlbumsCateBSO albumcateBSO = new AlbumsCateBSO();
                    albumcateBSO.DeleteAlbumsCateAll(Id);
                    ViewAlbumsCate();
                    break;
            }
        }
        protected void grvAlbumsCate_RowDataBound(object sender, GridViewRowEventArgs e)
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
            foreach (GridViewRow row in grvAlbumsCate.Rows)
            {
                TextBox textOrder = (TextBox)row.FindControl("txtAlbumsCateOrder");
                int cOrder = Convert.ToInt32(textOrder.Text);
                int cateID = Convert.ToInt32(row.Cells[0].Text);
                AlbumsCateBSO albumcateBSO = new AlbumsCateBSO();
                albumcateBSO.AlbumsCateUpOrder(cateID, cOrder);
            }
            ViewAlbumsCate();
        }
        protected void rdbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

            ViewAlbumsCate();
        }

    }
}