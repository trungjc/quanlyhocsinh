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
    public partial class EditCateNewsGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cId = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out cId);

            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());


            if (rdbUrl.SelectedValue.Equals("True"))
            {
                txtUrl.Visible = true;
            }
            else
            {
                txtUrl.Visible = false;
            }


            if (!IsPostBack)
            {
                item_Drop();
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


        #region initControl
        private void initControl(int Id)
        {
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
                    CateNewsGroup catenewsGroup = catenewsGroupBSO.GetCateNewsGroupById(Id);
                    hddCateNewsGroupID.Value = Convert.ToString(catenewsGroup.CateNewsGroupID);

                    txtCateNewsGroupName.Text = catenewsGroup.CateNewsGroupName;
                    txtGroupCate.Text = catenewsGroup.GroupCate.ToString();
                    txtDescription.Text = catenewsGroup.Description;
                    hddOrder.Value = Convert.ToString(catenewsGroup.Order);

                    chkView.Checked = catenewsGroup.IsView;
                    chkHome.Checked = catenewsGroup.IsHome;
                    chkMenu.Checked = catenewsGroup.IsMenu;
                    chkNews.Checked = catenewsGroup.IsNew;
                    chkPage.Checked = catenewsGroup.IsPage;
                    NgonNgu.SelectedValue = catenewsGroup.Language;
                    hddIcon.Value = catenewsGroup.Icon;
                    uploadPreview.Src = ResolveUrl("~/Upload/Category/Group/") + catenewsGroup.Icon;
                    rdbUrl.SelectedValue = Convert.ToString(catenewsGroup.IsUrl);
                    txtUrl.Text = catenewsGroup.Url;

                    txtPosition.Text = Convert.ToString(catenewsGroup.Position);

                    if (catenewsGroup.IsUrl == true)
                    {
                        txtUrl.Visible = true;
                    }
                    else
                    {
                        txtUrl.Visible = false;
                    }

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
        private CateNewsGroup ReceiveHtml()
        {

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/Category/Group/";
            commonBSO commonBSO = new commonBSO();
            string image_icon = commonBSO.UploadImage(icon, path, 55, 55);

            CateNewsGroup catenewsGroup = new CateNewsGroup();
            catenewsGroup.CateNewsGroupID = (hddCateNewsGroupID.Value != "") ? Convert.ToInt32(hddCateNewsGroupID.Value) : 0;
            catenewsGroup.CateNewsGroupName = txtCateNewsGroupName.Text;
            catenewsGroup.GroupCate = (txtGroupCate.Text != "") ? Convert.ToInt32(txtGroupCate.Text) : 0;
            catenewsGroup.Order = (hddOrder.Value != "") ? Convert.ToInt32(hddOrder.Value) : 0;
            catenewsGroup.Description = txtDescription.Text;
            catenewsGroup.IsView = chkView.Checked;
            catenewsGroup.IsHome = chkHome.Checked;
            catenewsGroup.IsMenu = chkMenu.Checked;
            catenewsGroup.IsNew = chkNews.Checked;
            catenewsGroup.IsPage = chkPage.Checked;
            catenewsGroup.Language = NgonNgu.SelectedValue;
            catenewsGroup.Icon = (image_icon != "") ? image_icon : hddIcon.Value;
            catenewsGroup.IsUrl = Convert.ToBoolean(rdbUrl.SelectedValue);
            catenewsGroup.Url = txtUrl.Text;

            catenewsGroup.Position = (txtPosition.Text != "") ? Convert.ToInt32(txtPosition.Text) : 0;

            return catenewsGroup;
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                CateNewsGroup catenewsGroup = ReceiveHtml();
                CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();


                catenewsGroupBSO.CreateCateNewsGroup(catenewsGroup);
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
                CateNewsGroup catenewsGroup = ReceiveHtml();
                CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();

                catenewsGroupBSO.UpdateCateNewsGroup(catenewsGroup);

                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "danh mục", catenewsGroup.CateNewsGroupName);

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

        protected void rdbUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbUrl.SelectedValue.Equals("True"))
            {
                txtUrl.Visible = true;
            }
            else
            {
                txtUrl.Visible = false;
            }
        }
        protected void item_Drop()
        {

            NgonNgu.Items.Add(new ListItem("Tiếng Việt", "vi-VN"));
            NgonNgu.Items.Add(new ListItem("English", "en-US"));
        }
    }
}