using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Data;
using ETO;

namespace Fomusa.Client.Modules.Video
{
    public partial class VideoList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a>  &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            title_name.Text = "Thư viện Video";

            int Id = 0;
            if (Page.RouteData.Values["Id"]!=null)
                int.TryParse(Page.RouteData.Values["Id"].ToString(), out Id);

            if (!IsPostBack)
            {
                if (Id == 0)
                {
                    CateNewsPanel.Visible = false;


                }
                else
                {
                    CateNewsPanel.Visible = true;
                    GetVideobyId(Id);


                }
                GetVideo();
            }


        }
        private void GetVideo()
        {
            VideoBSO videoBSO = new VideoBSO();
            DataTable table = videoBSO.GetVideoAll(Language.lang);

            DataList1.DataSource = table;
            DataList1.DataBind();


        }
        private void GetVideobyId(int Id)
        {
            VideoBSO videoBSO = new VideoBSO();
            ETO.Video video = videoBSO.GetVideoById(Id);

            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);

            if (video == null)
                Response.Redirect("~/Default.aspx");

            //if (video.VideoType == true)
            //    ltlVideo.Text = @"<object type='application/x-shockwave-flash' data='" + ResolveUrl("~/") 
            //        + "images/player_flv_multi.swf' width='480' height='320'><param name='movie' value='" 
            //        + ResolveUrl("~/") + "images/player_flv_multi.swf' /> <param name='allowFullScreen' value='true' /><param name='FlashVars' value='flv=" 
            //        + video.VideoUrl + "&title=" + video.VideoName + "&startimage=" + ResolveUrl("~/") + "Admin/Upload/Video/" 
            //        + video.Image + "&width=480&height=320&autoplay=0&autoload=0&margin=0&showstop=1&showvolume=1&showtime=2&showopen=2&showfullscreen=1&buffer=10&buffermessage=" 
            //        + video.ShortDescribe + "&shortcut=1&showtitleandstartimage=0' /></object>";
            //else
            //    ltlVideo.Text = @"<object type='application/x-shockwave-flash' data='" + ResolveUrl("~/") 
            //        + "images/player_flv_multi.swf' width='480' height='320'><param name='movie' value='" 
            //        + ResolveUrl("~/") + "images/player_flv_multi.swf' /> <param name='allowFullScreen' value='true' /><param name='FlashVars' value='flv=" 
            //        + ResolveUrl("~/") + "Admin/Upload/Video/Files/" + video.FileName + "&title=" + video.VideoName + "&startimage=" 
            //        + ResolveUrl("~/") + "Admin/Upload/Video/" + video.Image + "&width=480&height=320&autoplay=0&autoload=0&margin=0&showstop=1&showvolume=1&showtime=2&showopen=2&showfullscreen=1&buffer=10&buffermessage=" 
            //        + video.ShortDescribe + "&shortcut=1&showtitleandstartimage=0' /></object>";

            if (video.VideoType == true)
                ltlVideo.Text = @"<object width='480' height='320' data='" + (new commonBSO()).EmbedYoutubeLink(video.VideoUrl) + "'></object>";
            else
                ltlVideo.Text = @"<object type='application/x-shockwave-flash' data='http://flv-player.net/medias/player_flv_multi.swf' width='480' height='320'><param name='movie' value='http://flv-player.net/medias/player_flv_multi.swf' /> <param name='allowFullScreen' value='true' /><param name='FlashVars' value='flv="
                    + ResolveUrl("~/") + "Admin/Upload/Video/Files/" + video.FileName + "&title=" + video.VideoName + "&startimage="
                    + ResolveUrl("~/") + "Admin/Upload/Video/" + video.Image + "&width=480&height=320&autoplay=0&autoload=0&margin=0&showstop=1&showvolume=1&showtime=2&showopen=2&showfullscreen=1&buffer=10&buffermessage="
                    + video.ShortDescribe + "&shortcut=1&showtitleandstartimage=0' /></object>";

        }
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string Imgthumb = DataBinder.Eval(e.Item.DataItem, "Image").ToString();
            Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlImageThumb");
            if (Imgthumb != "")
                ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Admin/Upload/Video/" + Imgthumb + "' class='img_video'>";
            //else
            //    ltlImageThumb.Text = @"<img src='images/image_demo.jpg' align='left' class='border_image_pro' width='70'>";
        }
    }
}