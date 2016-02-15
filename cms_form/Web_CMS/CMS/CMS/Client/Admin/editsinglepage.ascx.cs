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
    public partial class editsinglepage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            int Id = 0;
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
                    SinglePageBSO singlepageBSO = new SinglePageBSO();
                    SinglePage singlepage = singlepageBSO.GetSinglePageById(Id);
                    hddSinglePageID.Value = Convert.ToString(singlepage.SinglePageID);
                    txtSinglePageName.Text = singlepage.SinglePageName;
                    hddIcon.Value = singlepage.Icon;
                    txtRadSinglePageDesc.Html = singlepage.SinglePageDesc;
                    txtRadSinglePageContent.Html = singlepage.SinglePageContent;
                    rdbStatus.SelectedValue = Convert.ToString(singlepage.Status);

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
        private SinglePage ReceiveHtml()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int icon_w = Convert.ToInt32(config.New_thumb_w);
            int icon_h = Convert.ToInt32(config.New_thumb_h);

            commonBSO commonBSO = new commonBSO();
            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/SinglePage/";
            string imgIcon = commonBSO.UploadImage(fileIcon, path, icon_w, icon_h);


            SinglePage singlepage = new SinglePage();
            singlepage.SinglePageID = (hddSinglePageID.Value != "") ? Convert.ToInt32(hddSinglePageID.Value) : 0;
            singlepage.SinglePageName = txtSinglePageName.Text;
            singlepage.Icon = (imgIcon != "") ? imgIcon : hddIcon.Value;
            singlepage.SinglePageDesc = txtRadSinglePageDesc.Html;
            singlepage.SinglePageContent = txtRadSinglePageContent.Html;
            singlepage.Language = Language.language;
            singlepage.Status = Convert.ToBoolean(rdbStatus.SelectedValue);
            singlepage.CreateDate = DateTime.Now;
            singlepage.CreatedUserName = Session["Admin_UserName"].ToString();
            return singlepage;
        }
        #endregion

        protected void btn_add_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                SinglePage singlepage = ReceiveHtml();
                SinglePageBSO singlepageBSO = new SinglePageBSO();
                singlepageBSO.CreateSinglePage(singlepage);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        protected void btn_edit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                SinglePage singlepage = ReceiveHtml();
                SinglePageBSO singlepageBSO = new SinglePageBSO();
                singlepageBSO.UpdateSinglePage(singlepage);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Trang ", singlepage.SinglePageName);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

    }
}