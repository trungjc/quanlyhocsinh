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
    public partial class AlbumsList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.Resource.Home + "</a>  &nbsp;>&nbsp;";
            GetAlbumsCate();
        }

        private void GetAlbumsCate()
        {            
            AlbumsCateBSO albumscateBSO = new AlbumsCateBSO();
            DataTable table = albumscateBSO.GetAlbumsCate();

            Repeater1.DataSource = table;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string Imgthumb = DataBinder.Eval(e.Item.DataItem, "ImageThumb").ToString();
            Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlImageThumb");
            if (Imgthumb != "")
                ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Admin/Upload/Albums/AlbumsCate/ImgThumb/" + Imgthumb + "' class='img_albums'>";
        }
    }
}