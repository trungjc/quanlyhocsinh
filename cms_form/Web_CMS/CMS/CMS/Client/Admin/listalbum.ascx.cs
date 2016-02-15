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
    public partial class listalbum : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
                ViewAlbum();
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

        #region ViewAlbum
        private void ViewAlbum()
        {
            AlbumBSO albumBSO = new AlbumBSO();
            DataTable table = albumBSO.GetAlbumAll();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvAlbum, table);
        }
        #endregion

        protected void grvAlbum_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAlbum.PageIndex = e.NewPageIndex;

            ViewAlbum();
        }
        protected void grvAlbum_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string nName = e.CommandName.ToLower();
            switch (nName)
            {
                case "_edit":
                    Response.Redirect("~/Admin/editalbum/" + Id + "/Default.aspx");
                    break;

                case "_delete":
                    AlbumBSO albumBSO = new AlbumBSO();
                    albumBSO.DeleteAlbum(Id);

                    ViewAlbum();
                    break;
            }
        }
        protected void grvAlbum_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
            }
        }

        protected void btn_Order_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in grvAlbum.Rows)
            {
                TextBox textOrder = (TextBox)row.FindControl("txtOrder");
                int cOrder = Convert.ToInt32(textOrder.Text);
                int cateID = Convert.ToInt32(row.Cells[0].Text);
                AlbumBSO albumBSO = new AlbumBSO();
                albumBSO.AlbumUpOrder(cateID, cOrder);
            }
            ViewAlbum();
        }

    }
}