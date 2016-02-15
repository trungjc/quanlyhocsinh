using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BSO;

namespace WebMedi.Client.Modules.Albums
{
    public partial class AlbumsView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cId = 0;
            if (Page.RouteData.Values["cId"] != null)
                int.TryParse(Page.RouteData.Values["cId"].ToString(), out cId);
            if (!IsPostBack)
            {
                ViewAlbums(cId);
            }
        }

        private void ViewAlbums(int cID)
        {
            AlbumsBSO albumBSO = new AlbumsBSO();
            DataTable table = albumBSO.GetAlbumsByCate(cID);
            int i = 0;
            string str = "<div class='msg_thumb_wrapper'>";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {

                    if ((i % 6) == 0 & i != 0)
                    {
                        str += "</div><div class='msg_thumb_wrapper' style='display:none;'>";
                    }
                    str += "<a href='" + ResolveUrl("~/") + "Admin/Upload/Albums/AlbumsImg/ImgLarge/" + row["ImageLarge"].ToString() + "'><img src='" + ResolveUrl("~/") + "Admin/Upload/Albums/AlbumsImg/ImgThumb/" + row["ImageThumb"].ToString() + "' alt='" + ResolveUrl("~/") + "Admin/Upload/Albums/AlbumsImg/ImgLarge/" + row["ImageLarge"].ToString() + "'/></a>";
                    i++;
                }
            }
            str += "</div>";

            ltlAlbums.Text = str;
        }
    }
}