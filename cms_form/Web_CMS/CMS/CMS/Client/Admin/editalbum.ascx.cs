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
    public partial class editalbum : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cId = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out cId);

            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                BindCateNews();
                initControl(cId);
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

        #region BindCateNews
        private void BindCateNews()
        {
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateNews(Language.language);
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateNews, table, "", "", "CateNewsName", "CateNewsID", "");
        }
        #endregion

        #region initControl
        private void initControl(int Id)
        {
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    AlbumBSO albumBSO = new AlbumBSO();
                    Album album = albumBSO.GetAlbumByID(Id);
                    hddAlbumID.Value = Convert.ToString(album.AlbumID);
                    hddCateNewsID.Value = Convert.ToString(album.CateNewsID);
                    ddlCateNews.SelectedValue = Convert.ToString(album.CateNewsID);

                    hddImageLarge.Value = album.ImageLarge;
                    hddImageThumb.Value = album.ImageThumb;
                    hddOrder.Value = album.Order.ToString();
                    rdbIsHome.SelectedValue = Convert.ToString(album.IsHome);


                }
                catch (Exception ex)
                {
                    clientview.Text = ex.Message.ToString();
                }
            }
            else
            {
                btn_edit.Visible = false;
                btn_add.Visible = true;


            }
        }
        #endregion

        #region ReceiveHtml
        private Album ReceiveHtml()
        {

            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);

            int thumb_w = Convert.ToInt32(config.New_thumb_w);
            int thumb_h = Convert.ToInt32(config.New_thumb_h);
            string path_thumb = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Album/AlbumThumb/";


            int large_w = Convert.ToInt32(config.New_large_w);
            int large_h = Convert.ToInt32(config.New_large_h);
            string path_large = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Album/AlbumLarge/";


            commonBSO commonBSO = new commonBSO();
            string image_thumb = commonBSO.UploadImage(file_image_large, path_thumb, thumb_w, thumb_h);
            string image_large = commonBSO.UploadImage(file_image_large, path_large, large_w, large_h);


            Album album = new Album();
            album.AlbumID = (hddAlbumID.Value != "") ? Convert.ToInt32(hddAlbumID.Value) : 0;
            album.CateNewsID = (ddlCateNews.SelectedValue != "") ? Convert.ToInt32(ddlCateNews.SelectedValue) : 0;
            album.ImageThumb = (image_thumb != "") ? image_thumb : hddImageThumb.Value;
            album.ImageLarge = (image_large != "") ? image_large : hddImageLarge.Value;
            album.IsHome = Convert.ToBoolean(rdbIsHome.SelectedValue);
            album.Order = (hddOrder.Value != "") ? Convert.ToInt32(hddOrder.Value) : 0;



            return album;
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {

            try
            {
                //if (String.IsNullOrEmpty(image_thumb) || String.IsNullOrEmpty(image_large))
                //{

                //    BindCateNews();
                //    clientview.Text = String.Format(Resources.StringAdmin.CheckImage);

                //}
                //else
                //{
                Album album = new Album();
                album = ReceiveHtml();


                AlbumBSO albumBSO = new AlbumBSO();
                albumBSO.CreateAlbum(album);

                BindCateNews();
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);

                //}


            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }

        }
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                Album album = new Album();
                album = ReceiveHtml();


                AlbumBSO albumBSO = new AlbumBSO();
                albumBSO.UpdateAlbum(album);

                BindCateNews();
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

    }
}