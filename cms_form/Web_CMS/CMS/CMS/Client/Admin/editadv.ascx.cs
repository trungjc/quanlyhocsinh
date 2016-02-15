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
    public partial class editadv : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);
            if (!IsPostBack)
                initControl(Id);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
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
                    AdvBSO advBSO = new AdvBSO();
                    Adv adv = advBSO.GetAdvById(Id);
                    hddAdvID.Value = Convert.ToString(adv.AdvID);
                    hddAdvImageThumb.Value = adv.AdvImage;
                    uploadPreview.Src = ResolveUrl("~/Upload/Advertising/") + adv.AdvImage;
                    txtAdvUrl.Text = adv.AdvUrl;
                    txtAdvWidth.Text = Convert.ToString(adv.AdvWidth);
                    txtAdvHeight.Text = Convert.ToString(adv.AdvHeight);
                    rdbAdvStatus.SelectedValue = Convert.ToString(adv.AdvStatus);
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
        private Adv ReceiveHtml()
        {
            int thumb_w = Convert.ToInt32(txtAdvWidth.Text);
            int thumb_h = Convert.ToInt32(txtAdvHeight.Text);

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Advertising/";

            commonBSO commonBSO = new commonBSO();
            string image_thumb = commonBSO.UploadImage(file_image_thumb, path, thumb_w, thumb_h);

            Adv adv = new Adv();
            adv.AdvID = (hddAdvID.Value != "") ? Convert.ToInt32(hddAdvID.Value) : 0;
            adv.AdvUrl = txtAdvUrl.Text;
            adv.AdvImage = (image_thumb != "") ? image_thumb : hddAdvImageThumb.Value;
            adv.AdvWidth = Convert.ToInt32(txtAdvWidth.Text);
            adv.AdvHeight = Convert.ToInt32(txtAdvHeight.Text);
            adv.AdvPostDate = DateTime.Now;
            adv.AdvEndDate = DateTime.Now;
            adv.AdvStatus = Convert.ToBoolean(rdbAdvStatus.SelectedValue);
            return adv;

        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Adv adv = ReceiveHtml();
                if (String.IsNullOrEmpty(adv.AdvImage))
                {
                    clientview.Text = String.Format(Resources.StringAdmin.CheckImage);
                }
                else
                {
                    AdvBSO advBSO = new AdvBSO();
                    advBSO.CreateAdv(adv);
                    clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
                }
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
                Adv adv = ReceiveHtml();
                if (String.IsNullOrEmpty(adv.AdvImage))
                {
                    clientview.Text = String.Format(Resources.StringAdmin.CheckImage);
                }
                else
                {
                    AdvBSO advBSO = new AdvBSO();
                    advBSO.UpdateAdv(adv);
                    clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "ảnh logo", adv.AdvUrl);
                }
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }

        }
    }
}