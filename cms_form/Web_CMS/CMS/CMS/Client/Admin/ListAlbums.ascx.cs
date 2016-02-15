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
    public partial class ListAlbums : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

            int cId = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out cId);

            //int cId = 0;
            //if (!String.IsNullOrEmpty(Page.RouteData.Values["group"].ToString()))
            //    int.TryParse(Page.RouteData.Values["group"].ToString().Replace(",", ""), out cId);

            hddAlbumsCate.Value = Convert.ToString(cId);

            if (!IsPostBack)
                ViewAlbum(cId);
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
        private void ViewAlbum(int cId)
        {
            AlbumsBSO albumBSO = new AlbumsBSO();
            DataTable table = new DataTable();
            if (cId != 0)
                table = albumBSO.GetAlbumsByCate(cId);
            else
                table = albumBSO.GetAlbumsAll();

            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvAlbum, table);
        }
        #endregion

        protected void grvAlbum_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAlbum.PageIndex = e.NewPageIndex;

            ViewAlbum(Convert.ToInt32(hddAlbumsCate.Value));
        }
        protected void grvAlbum_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string nName = e.CommandName.ToLower();
            switch (nName)
            {
                case "_edit":
                    //Response.Redirect("~/Admin/editalbums/" + Id + "/Default.aspx");
                    Response.Redirect("~/Admin/Group/editalbums/" + Id + "/" + hddAlbumsCate.Value + "/Default.aspx");
                    break;

                case "_delete":
                    AlbumsBSO albumBSO = new AlbumsBSO();
                    albumBSO.DeleteAlbums(Id);

                    ViewAlbum(Convert.ToInt32(hddAlbumsCate.Value));
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

        protected void btn_delall_Click(object sender, EventArgs e)
        {
            if (AlbumsID() != "")
            {
                AlbumsBSO albumsBSO = new AlbumsBSO();
                albumsBSO.DeleteAlbums(AlbumsID());
            }
            ViewAlbum(Convert.ToInt32(hddAlbumsCate.Value));
        }

        #region AlbumsID
        private string AlbumsID()
        {
            string albumsId = "";
            foreach (GridViewRow rows in grvAlbum.Rows)
            {
                CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
                if (checkbox.Checked)
                    albumsId += rows.Cells[0].Text + ",";
            }
            return albumsId;
        }

        #endregion

        protected void btn_edit_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/editalbums/" + hddAlbumsCate.Value + "/Default.aspx");

        }

    }
}