using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Data;

namespace Fomusa.Client.Modules.Albums
{
    public partial class AlbumsList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a>  &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            // title_name.Text = "Thư viện ảnh";
            GetAlbumsCate();


        }
        private void GetAlbumsCate()
        {
            AlbumsCateBSO albumscateBSO = new AlbumsCateBSO();
            DataTable table = albumscateBSO.GetAlbumsCate();

            DataList1.DataSource = table;
            DataList1.DataBind();


        }
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string Imgthumb = DataBinder.Eval(e.Item.DataItem, "ImageThumb").ToString();
            Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlImageThumb");
            if (Imgthumb != "")
                ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "/Admin/Upload/Albums/AlbumsCate/ImgThumb/" + Imgthumb + "' class='img_albums'>";
            //else
            //    ltlImageThumb.Text = @"<img src='images/image_demo.jpg' align='left' class='border_image_pro' width='70'>";
        }

    
    }
}