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
    public partial class EditMenuLinks : System.Web.UI.UserControl
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
                txtMenuLinksID.Value = Convert.ToString(ID);
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    MenuLinksBSO menuLinksBSO = new MenuLinksBSO();

                    MenuLinks menuLinksRows = menuLinksBSO.GetMenuLinksById(ID);
                    ddlMenuLinks.SelectedValue = menuLinksRows.MenuLinksParent.ToString();
                    txtMenuLinksName.Text = menuLinksRows.MenuLinksName;
                    txtMenuLinksUrl.Text = menuLinksRows.MenuLinksUrl;
                    txtRadHelp.Html = menuLinksRows.MenuLinksHelp;
                    hddIcon.Value = menuLinksRows.MenuLinksIcon;
                    uploadPreview.Src = ResolveUrl("~/Upload/MenuLinks/") + menuLinksRows.MenuLinksIcon;
                    rdbStatus.SelectedValue = Convert.ToString(menuLinksRows.Status);
                    rdbIsView.SelectedValue = Convert.ToString(menuLinksRows.IsView);
                    ddlTarget.SelectedValue = menuLinksRows.Target.ToString();


                }
                catch (Exception ex)
                {
                    error.Text = ex.Message.ToString();
                }
            }
            else
            {
                txtMenuLinksID.Value = "";
                ddlMenuLinks.SelectedIndex = 0;
                btn_add.Visible = true;
                btn_edit.Visible = false;
            }
        }
        #endregion

        #region BindDropDownList
        protected void BindDropDownList()
        {
            MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
            //  DataTable table = menuLinksBSO.GetAllMenuLinks();
            DataTable table = menuLinksBSO.MixMenuLinks();
            commonBSO commonBSO = new commonBSO();
            ddlMenuLinks.Items.Clear();
            commonBSO.FillToDropDown(ddlMenuLinks, table, "~ Cấp độ menuLinks ~", "0", "MenuLinksName", "MenuLinksID", "");
        }
        #endregion

        #region AddNews
        protected void Add()
        {
            MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
            MenuLinks menuLinks = ReceiveHtml();
            try
            {
                //if (menuLinksBSO.CheckExist(menuLinks.MenuLinksUrl))
                //{
                //    error.Text = String.Format(Resources.StringAdmin.CheckExist, menuLinks.MenuLinksUrl);
                //}
                //else
                //{
                menuLinksBSO.AddMenuLinks(menuLinks);
                error.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
                //}
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
            MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
            MenuLinks menuLinks = ReceiveHtml();
            try
            {
                menuLinksBSO.EditMenuLinks(menuLinks);
                error.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "MenuLinks", menuLinks.MenuLinksName);

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region ReceiveHtml
        public MenuLinks ReceiveHtml()
        {
            MenuLinks menuLinks = new MenuLinks();

            //      string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Admin/Admin_Theme/Icons/";
            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/MenuLinks/";
            commonBSO commonBSO = new commonBSO();
            string icon_upload = commonBSO.UploadImage(uploadIcon, path, 80, 80);

            menuLinks.MenuLinksID = (txtMenuLinksID.Value != "") ? Convert.ToInt32(txtMenuLinksID.Value) : 0;
            menuLinks.MenuLinksName = (txtMenuLinksName.Text != "") ? txtMenuLinksName.Text.Trim() : "";
            menuLinks.MenuLinksOrder = 0;
            menuLinks.MenuLinksParent = (ddlMenuLinks.SelectedValue != "") ? Convert.ToInt32(ddlMenuLinks.SelectedValue) : 0;
            menuLinks.MenuLinksUrl = (txtMenuLinksUrl.Text != "") ? txtMenuLinksUrl.Text.Trim() : "";
            menuLinks.MenuLinksHelp = txtRadHelp.Html;
            menuLinks.MenuLinksIcon = (icon_upload != "") ? icon_upload : hddIcon.Value;

            menuLinks.Status = Convert.ToBoolean(rdbStatus.SelectedValue);
            menuLinks.IsView = Convert.ToBoolean(rdbIsView.SelectedValue);
            menuLinks.Target = ddlTarget.SelectedValue;


            return menuLinks;
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
            BindDropDownList();
        }

    }
}