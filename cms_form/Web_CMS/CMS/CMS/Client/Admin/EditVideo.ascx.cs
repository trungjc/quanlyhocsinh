using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;

namespace CMS.Client.Admin
{
    public partial class EditVideo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString(), out Id);


            txtFileName.Visible = false;
            txtVideoUrl.Visible = true;

            if (!IsPostBack)
            {
                initControl(Id);
                item_Drop();
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

        #region initControl
        private void initControl(int Id)
        {
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    VideoBSO videoBSO = new VideoBSO();
                    Video video = videoBSO.GetVideoById(Id);
                    hddVideoID.Value = Convert.ToString(video.VideoID);
                    hddIcon.Value = video.Image;
                    uploadPreview.Src = ResolveUrl("~/Upload/Video/") + video.Image;
                    txtVideoName.Text = video.VideoName;
                    txtVideoUrl.Text = video.VideoEmbed;                    
                    txtShortDescribe.Text = video.ShortDescribe;
                    txtRadDate.SelectedDate = video.PostDate;
                    rdbIsHome.SelectedValue = Convert.ToString(video.IsHome);
                    NgonNgu.SelectedValue = video.Language;
                    hddFileName.Value = video.FileName;
                    rdbType.SelectedValue = Convert.ToString(video.VideoType);
                    rdbType.Enabled = false;

                    if (video.VideoType == true)
                    {
                        txtFileName.Visible = false;
                        txtVideoUrl.Visible = true;
                    }
                    else
                    {
                        txtFileName.Visible = true;
                        txtVideoUrl.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    clientview.Text = ex.Message.ToString();
                }
            }
            else
            {
                txtRadDate.SelectedDate = DateTime.Now;
                btn_add.Visible = true;
                btn_edit.Visible = false;

                rdbType.Enabled = true;

            }
        }
        #endregion

        #region ReceiveHtml
        private Video ReceiveHtml()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.lang);
            int thumb_w = Convert.ToInt32(config.Product_large_w);
            int thumb_h = Convert.ToInt32(config.Product_large_h);


            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Video/";
            commonBSO commonBSO = new commonBSO();
            string icon = commonBSO.UploadImage(file_icon, path, thumb_w, thumb_h);

            string pathvideo = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Video/Files/";
            string file_upload = commonBSO.UploadVideo(txtFileName, pathvideo, 18000000000000);


            Video video = new Video();
            video.VideoID = (hddVideoID.Value != "") ? Convert.ToInt32(hddVideoID.Value) : 0;
            video.VideoName = txtVideoName.Text;
            video.VideoUrl = "";
            video.VideoEmbed = txtVideoUrl.Text;            
            video.Image = (icon != "") ? icon : hddIcon.Value;
            video.FileName = (file_upload != "") ? file_upload : hddFileName.Value;

            video.ShortDescribe = txtShortDescribe.Text;
            video.PostDate = txtRadDate.SelectedDate.Value;
            video.IsHome = Convert.ToBoolean(rdbIsHome.SelectedValue);
            video.VideoType = Convert.ToBoolean(rdbType.SelectedValue);
            video.Language = NgonNgu.SelectedValue;
            return video;
        }
        #endregion
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Video video = ReceiveHtml();
                VideoBSO videoBSO = new VideoBSO();
                videoBSO.CreateVideo(video);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
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
                Video video = ReceiveHtml();
                VideoBSO videoBSO = new VideoBSO();
                videoBSO.UpdateVideo(video);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Video", video.VideoName);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        protected void rdbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbType.SelectedValue.Equals("True"))
            {
                txtFileName.Visible = false;
                txtVideoUrl.Visible = true;
            }
            else
            {
                txtFileName.Visible = true;
                txtVideoUrl.Visible = false;
            }
        }
        protected void item_Drop()
        {

            NgonNgu.Items.Add(new ListItem("Tiếng Việt", "vi-VN"));
            NgonNgu.Items.Add(new ListItem("English", "en-US"));
        }

    }
}