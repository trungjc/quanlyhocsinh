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
    public partial class editmodules : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString(), out ID);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                BindDropDownList();
                initControl(ID);
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
        protected void initControl(int ID)
        {
            if (ID > 0)
            {
                txtModulesID.Value = Convert.ToString(ID);
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    ModulesBSO modulesBSO = new ModulesBSO();

                    Modules modulesRows = modulesBSO.GetModulesById(ID);
                    ddlModules.SelectedValue = modulesRows.ModulesParent.ToString();
                    txtModulesName.Text = modulesRows.ModulesName;
                    txtModulesUrl.Text = modulesRows.ModulesUrl;
                    txtRadHelp.Html = modulesRows.ModulesHelp;
                    hddIcon.Value = modulesRows.ModulesIcon;
                    uploadPreview.Src = ResolveUrl("~/Upload/Admin_Theme/Icons/") + modulesRows.ModulesIcon;
                }
                catch (Exception ex)
                {
                    error.Text = ex.Message.ToString();
                }
            }
            else
            {
                txtModulesID.Value = "";
                ddlModules.SelectedIndex = 0;
                btn_add.Visible = true;
                btn_edit.Visible = false;
            }
        }
        #endregion

        #region BindDropDownList
        protected void BindDropDownList()
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            DataTable table = modulesBSO.MixModules();
            commonBSO commonBSO = new commonBSO();
            ddlModules.Items.Clear();
            commonBSO.FillToDropDown(ddlModules, table, "~ Cấp độ modules ~", "0", "Modules_Name", "Modules_ID", "");
        }
        #endregion

        #region AddNews
        protected void Add()
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            Modules modules = ReceiveHtml();
            try
            {
                if (modulesBSO.CheckExist(modules.ModulesUrl))
                {
                    error.Text = String.Format(Resources.StringAdmin.CheckExist, modules.ModulesUrl);
                }
                else
                {
                    modulesBSO.AddModules(modules);
                    error.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
                }
            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }

        }
        #endregion

        #region Edit
        protected void Edit()
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            Modules modules = ReceiveHtml();
            try
            {
                modulesBSO.EditModules(modules);
                error.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Modules", modules.ModulesName);

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region ReceiveHtml
        public Modules ReceiveHtml()
        {
            Modules modules = new Modules();

            //      string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Admin/Admin_Theme/Icons/";
            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Admin_Theme/Icons/";
            commonBSO commonBSO = new commonBSO();
            string icon_upload = commonBSO.UploadImage(uploadIcon, path, 55, 55);

            modules.ModulesID = (txtModulesID.Value != "") ? Convert.ToInt32(txtModulesID.Value) : 0;
            modules.ModulesName = (txtModulesName.Text != "") ? txtModulesName.Text.Trim() : "";
            modules.ModulesOrder = 0;
            modules.ModulesParent = (ddlModules.SelectedValue != "") ? Convert.ToInt32(ddlModules.SelectedValue) : 0;
            modules.ModulesUrl = (txtModulesUrl.Text != "") ? txtModulesUrl.Text.Trim() : "";
            modules.ModulesHelp = txtRadHelp.Html;
            modules.ModulesIcon = (icon_upload != "") ? icon_upload : hddIcon.Value;


            return modules;
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Add();
            BindDropDownList();
        }
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Edit();
        }

    }
}