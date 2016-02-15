using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;

namespace CMS.Client.Admin
{
    public partial class EditImageSlideShow : System.Web.UI.UserControl
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
                    LinkBSO linkBSO = new LinkBSO();
                    Link link = linkBSO.GetLinkById(Id);
                    hddLinkID.Value = Convert.ToString(link.LinkID);
                    hddLinkImageThumb.Value = link.LinkImage;
                    uploadPreview.Src = ResolveUrl("~/Upload/Link/") + link.LinkImage;
                    txtLinkUrl.Text = link.LinkUrl;
                    txtLinkWidth.Text = Convert.ToString(link.LinkWidth);
                    txtLinkHeight.Text = Convert.ToString(link.LinkHeight);
                    rdbLinkStatus.SelectedValue = Convert.ToString(link.LinkStatus);
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
        private Link ReceiveHtml()
        {
            int thumb_w = Convert.ToInt32(txtLinkWidth.Text);
            int thumb_h = Convert.ToInt32(txtLinkHeight.Text);

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Link/";

            commonBSO commonBSO = new commonBSO();
            string image_thumb = commonBSO.UploadImage(file_image_thumb, path, thumb_w, thumb_h);

            Link link = new Link();
            link.LinkID = (hddLinkID.Value != "") ? Convert.ToInt32(hddLinkID.Value) : 0;
            link.LinkUrl = txtLinkUrl.Text;
            link.LinkImage = (image_thumb != "") ? image_thumb : hddLinkImageThumb.Value;
            link.LinkWidth = Convert.ToInt32(txtLinkWidth.Text);
            link.LinkHeight = Convert.ToInt32(txtLinkHeight.Text);
            link.LinkType = 1;

            link.LinkStatus = Convert.ToBoolean(rdbLinkStatus.SelectedValue);
            return link;

        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Link link = ReceiveHtml();
                if (String.IsNullOrEmpty(link.LinkImage))
                {
                    clientview.Text = String.Format(Resources.StringAdmin.CheckImage);
                }
                else
                {
                    LinkBSO linkBSO = new LinkBSO();
                    linkBSO.CreateLink(link);
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
                Link link = ReceiveHtml();
                if (String.IsNullOrEmpty(link.LinkImage))
                {
                    clientview.Text = String.Format(Resources.StringAdmin.CheckImage);
                }
                else
                {
                    LinkBSO linkBSO = new LinkBSO();
                    linkBSO.UpdateLink(link);
                    clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "ảnh công ty", link.LinkUrl);
                }
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }

        }
    }
}