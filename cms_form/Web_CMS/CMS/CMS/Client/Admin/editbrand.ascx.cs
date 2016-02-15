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
    public partial class editbrand : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString(), out Id);
            if (!IsPostBack)
                initControl(Id);
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
                    BrandBSO brandBSO = new BrandBSO();
                    Brand brand = brandBSO.GetBrandById(Id);
                    hddBrandID.Value = Convert.ToString(brand.BrandID);
                    hddIcon.Value = brand.Image;
                    uploadPreview.Src = ResolveUrl("~/Upload/Brand/") + brand.Image;
                    txtBrandName.Text = brand.BrandName;
                    txtBrandUrl.Text = brand.BrandUrl;
                    txtShortDescribe.Text = brand.ShortDescribe;
                }
                catch (Exception ex)
                {
                    clientview.Text = ex.Message.ToString();
                }
            }
            else
            {
                btn_add.Visible = true;
                btn_edit.Visible = false;
            }
        }
        #endregion

        #region ReceiveHtml
        private Brand ReceiveHtml()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int thumb_w = Convert.ToInt32(config.Product_thumb_w);
            int thumb_h = Convert.ToInt32(config.Product_thumb_h);

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Brand/";
            commonBSO commonBSO = new commonBSO();
            string icon = commonBSO.UploadImage(file_icon, path, thumb_w, thumb_h);
            Brand brand = new Brand();
            brand.BrandID = (hddBrandID.Value != "") ? Convert.ToInt32(hddBrandID.Value) : 0;
            brand.BrandName = txtBrandName.Text;
            brand.BrandUrl = txtBrandUrl.Text;
            brand.Image = icon;
            brand.ShortDescribe = txtShortDescribe.Text;
            brand.Language = Language.language;
            return brand;
        }
        #endregion
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Brand brand = ReceiveHtml();
                BrandBSO brandBSO = new BrandBSO();
                brandBSO.CreateBrand(brand);
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
                Brand brand = ReceiveHtml();
                BrandBSO brandBSO = new BrandBSO();
                brandBSO.UpdateBrand(brand);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "hãng", brand.BrandName);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
    }
}