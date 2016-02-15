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
    public partial class EditAlbumsCate : System.Web.UI.UserControl
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
                ViewCateGroup();

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

        #region ViewCateGroup
        private void ViewCateGroup()
        {
            ddlAlbumsCate.Items.Clear();
            AlbumsCateBSO albumscateBSO = new AlbumsCateBSO();
            DataTable table = albumscateBSO.GetAlbumsCate();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlAlbumsCate, table, "~~ Danh mục gốc ~~", "0", "AlbumsCateName", "AlbumsCateID", "");
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
                    AlbumsCateBSO albumscateBSO = new AlbumsCateBSO();
                    AlbumsCate albumscate = albumscateBSO.GetAlbumsCateById(Id);

                    hddAlbumsCateID.Value = Convert.ToString(albumscate.AlbumsCateID);
                    hddParentID.Value = Convert.ToString(albumscate.ParentCateID);
                    ddlAlbumsCate.SelectedValue = Convert.ToString(albumscate.ParentCateID);

                    ddlAlbumsCate.Items.Remove(new ListItem(albumscate.AlbumsCateName, Convert.ToString(albumscate.AlbumsCateID)));

                    txtAlbumsCateName.Text = albumscate.AlbumsCateName;
                    hddAlbumsCateOrder.Value = Convert.ToString(albumscate.AlbumsCateOrder);
                    hddAlbumsCateTotal.Value = Convert.ToString(albumscate.AlbumsCateTotal);
                    hddImageThumb.Value = albumscate.ImageThumb;
                    hddImageLarge.Value = albumscate.ImageLarge;
                    txtSlogan.Text = albumscate.Description;
                    hddUserName.Value = Session["Admin_UserName"].ToString();
                    hddCreated.Value = DateTime.Now.ToString();



                    //  ViewCateGroup();
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
        private AlbumsCate ReceiveHtml()
        {

            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int thumb_w = Convert.ToInt32(config.New_thumb_w);
            int thumb_h = Convert.ToInt32(config.New_thumb_h);

            //int large_w = Convert.ToInt32(config.New_large_w);
            //int large_h = Convert.ToInt32(config.New_large_h);


            string path_thumb = Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/Albums/AlbumsCate/ImgThumb/";
            //string path_large = Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/Albums/AlbumsCate/ImgLarge/";

            commonBSO commonBSO = new commonBSO();
            string image_thumb = commonBSO.UploadImage(file_icon, path_thumb, thumb_w, thumb_h);
            //string image_large = commonBSO.UploadImage(file_icon, path_large, large_w, large_h);


            AlbumsCate albumscate = new AlbumsCate();
            albumscate.AlbumsCateID = (hddAlbumsCateID.Value != "") ? Convert.ToInt32(hddAlbumsCateID.Value) : 0;
            albumscate.ParentCateID = (ddlAlbumsCate.SelectedValue != "") ? Convert.ToInt32(ddlAlbumsCate.SelectedValue) : 0;
            albumscate.AlbumsCateName = txtAlbumsCateName.Text;
            albumscate.AlbumsCateOrder = (hddAlbumsCateOrder.Value != "") ? Convert.ToInt32(hddAlbumsCateOrder.Value) : 0;
            albumscate.AlbumsCateTotal = (hddAlbumsCateTotal.Value != "") ? Convert.ToInt32(hddAlbumsCateTotal.Value) : 0;


            albumscate.ImageThumb = (image_thumb != "") ? image_thumb : hddImageThumb.Value;
            //albumscate.ImageLarge = (image_large != "") ? image_large : hddImageLarge.Value;
            albumscate.ImageLarge = "";

            albumscate.Description = txtSlogan.Text;

            albumscate.UserName = (hddUserName.Value != "") ? hddUserName.Value : Session["Admin_UserName"].ToString();
            albumscate.Created = (hddCreated.Value != "") ? Convert.ToDateTime(hddCreated.Value) : DateTime.Now;


            return albumscate;
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                AlbumsCate albumscate = ReceiveHtml();
                AlbumsCateBSO albumscateBSO = new AlbumsCateBSO();

                albumscateBSO.CreateCateNew(albumscate);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);

                ViewCateGroup();
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
                AlbumsCate albumscate = ReceiveHtml();

                AlbumsCateBSO albumscateBSO = new AlbumsCateBSO();

                albumscateBSO.UpdateAlbumsCate(albumscate);

                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "danh mục", albumscate.AlbumsCateName);

                ViewCateGroup();

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

    }
}