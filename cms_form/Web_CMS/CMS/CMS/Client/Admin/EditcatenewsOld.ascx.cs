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
    public partial class EditcatenewsOld : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cId = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out cId);

            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

            if (rdbType.SelectedValue.Equals("True"))
            {
                txtUrl.Visible = true;
            }
            else
            {
                txtUrl.Visible = false;
            }

            if (!IsPostBack)
            {
                ViewCateNewsGroup();
                HddGroupCate.Value = rdbGroupCate.SelectedValue;
                ViewCateGroup(Convert.ToInt32(rdbGroupCate.SelectedValue));

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
        private void ViewCateGroup(int group)
        {
            ddlCateNews.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateGroupRolesUrl(Language.language, group, Session["Admin_UserName"].ToString());
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateNews, table, "~~ Danh mục gốc ~~", "0", "CateNewsName", "CateNewsID", "");
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
                    CateNewsBSO catenewsBSO = new CateNewsBSO();
                    CateNews catenews = catenewsBSO.GetCateNewsById(Id);
                    hddCateNewsID.Value = Convert.ToString(catenews.CateNewsID);
                    hddParentID.Value = Convert.ToString(catenews.ParentNewsID);
                    ddlCateNews.SelectedValue = Convert.ToString(catenews.ParentNewsID);

                    ddlCateNews.Items.Remove(new ListItem(catenews.CateNewsName, Convert.ToString(catenews.CateNewsID)));

                    txtCateNewsName.Text = catenews.CateNewsName;
                    hddCateNewsOrder.Value = Convert.ToString(catenews.CateNewsOrder);
                    hddCateNewsTotal.Value = Convert.ToString(catenews.CateNewsTotal);
                    rdbGroupCate.SelectedValue = Convert.ToString(catenews.GroupCate);
                    hddIcon.Value = catenews.Icon;
                    txtSlogan.Text = catenews.Slogan;
                    hddUserName.Value = Session["Admin_UserName"].ToString();
                    hddCreated.Value = DateTime.Now.ToString();

                    HddGroupCate.Value = Convert.ToString(catenews.GroupCate);

                    rdbType.SelectedValue = Convert.ToString(catenews.isUrl);
                    txtUrl.Text = catenews.Url;

                    if (catenews.isUrl == true)
                    {
                        txtUrl.Visible = true;
                    }
                    else
                    {
                        txtUrl.Visible = false;
                    }

                    ViewCateGroup(catenews.GroupCate);
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
        private CateNews ReceiveHtml()
        {

            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int icon_w = Convert.ToInt32(config.New_icon_w);
            int icon_h = Convert.ToInt32(config.New_icon_h);


            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/Category/";
            commonBSO commonBSO = new commonBSO();
            string image_icon = commonBSO.UploadImage(file_icon, path, icon_w, icon_h);


            CateNews catenews = new CateNews();
            catenews.CateNewsID = (hddCateNewsID.Value != "") ? Convert.ToInt32(hddCateNewsID.Value) : 0;
            catenews.ParentNewsID = (ddlCateNews.SelectedValue != "") ? Convert.ToInt32(ddlCateNews.SelectedValue) : 0;
            catenews.CateNewsName = txtCateNewsName.Text;
            catenews.CateNewsOrder = (hddCateNewsOrder.Value != "") ? Convert.ToInt32(hddCateNewsOrder.Value) : 0;
            catenews.CateNewsTotal = (hddCateNewsTotal.Value != "") ? Convert.ToInt32(hddCateNewsTotal.Value) : 0;
            catenews.Language = Language.language;
            catenews.GroupCate = Convert.ToInt32(rdbGroupCate.SelectedValue);
            catenews.Icon = (image_icon != "") ? image_icon : hddIcon.Value;
            catenews.Slogan = txtSlogan.Text;

            catenews.UserName = (hddUserName.Value != "") ? hddUserName.Value : Session["Admin_UserName"].ToString();
            catenews.Created = (hddCreated.Value != "") ? Convert.ToDateTime(hddCreated.Value) : DateTime.Now;

            catenews.isUrl = Convert.ToBoolean(rdbType.SelectedValue);
            catenews.Url = txtUrl.Text;

            catenews.Roles = "";
            return catenews;
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                CateNews catenews = ReceiveHtml();
                CateNewsBSO catenewsBSO = new CateNewsBSO();


                catenewsBSO.CreateCateNew(catenews);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);

                ViewCateGroup(Convert.ToInt32(HddGroupCate.Value));

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
                CateNews catenews = ReceiveHtml();

                CateNewsBSO catenewsBSO = new CateNewsBSO();

                catenewsBSO.UpdateCateNews(catenews);

                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "danh mục", catenews.CateNewsName);

                ViewCateGroup(Convert.ToInt32(HddGroupCate.Value));

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        protected void rdbGroupCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = rdbGroupCate.SelectedValue;
            ViewCateGroup(Convert.ToInt32(value));
            HddGroupCate.Value = value;
        }
        #region ViewCateNewsGroup
        public void ViewCateNewsGroup()
        {
            CateNewsGroupBSO cateNewsGroupBSO = new CateNewsGroupBSO();
            DataTable table = cateNewsGroupBSO.GetCateNewsGroupAll();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToRadioList(rdbGroupCate, table, "CateNewsGroupName", "GroupCate", "1");


        }
        #endregion

        protected void rdbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbType.SelectedValue.Equals("True"))
            {
                txtUrl.Visible = true;
            }
            else
            {
                txtUrl.Visible = false;
            }
        }
    }
}