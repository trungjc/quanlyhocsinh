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
    public partial class editpage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                string group = "1";
                ViewCate(group);
                initControl(Id);
                hddGroup.Value = group;
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

        protected void rdbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = rdbType1.SelectedValue;
            if (value.Equals("True"))
            {
                divFull.Visible = true;
                divTitle1.Visible = true;
                rdbType1.Enabled = false;

            }
            if (value.Equals("False"))
            {
                divFull.Visible = false;
                divTitle1.Visible = false;
                rdbType1.Enabled = false;
            }
        }

        #region ViewCate
        protected void ViewCate(string group)
        {
            PagesBSO pagesBSO = new PagesBSO();
            DataTable table = pagesBSO.PageGetGroup(group, Language.language);
            commonBSO commonBSO = new commonBSO();
            ddlPage.Items.Clear();
            commonBSO.FillToDropDown(ddlPage, table, "~~ Lựa chọn trang đã có ~~", "0", "PageName", "PageName", "");
        }
        #endregion

        #region initControl
        protected void initControl(int Id)
        {
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                hddPageID.Value = Convert.ToString(Id);
                try
                {
                    PagesBSO pagesBSO = new PagesBSO();
                    Pages pages = pagesBSO.GetPagesById(Id);
                    ddlPage.SelectedValue = pages.PageName;
                    txtPageName.Text = pages.PageName;
                    rdbGroup.SelectedValue = pages.Icon;
                    txtTitle.Text = pages.PageTitle;
                    rdbType1.SelectedValue = pages.PageType.ToString();
                    rdbType1.Enabled = false;
                    txtRadshort.Html = pages.Describe;
                    hddImage.Value = pages.Imagethumb;
                    txtRad_full.Html = pages.PageContent;
                    txtRadDate.SelectedDate = pages.PostDate;
                    txtAuthor.Text = pages.Author;
                    rdbActive.SelectedValue = pages.Status.ToString();
                    rdbIsView.SelectedValue = pages.IsView.ToString();
                    rdbComment.SelectedValue = pages.IsComment.ToString();

                    hddCommentTotal.Value = Convert.ToString(pages.CommentTotal);
                    hddVisitTotal.Value = Convert.ToString(pages.VisitTotal);
                    hddCreateUserName.Value = pages.CreatedUserName;
                    hddApprovalUserName.Value = pages.ApprovalUserName;
                    hddApprovalDate.Value = Convert.ToString(pages.ApprovalDate);



                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                    {
                        rdbApproval.SelectedValue = Convert.ToString(pages.IsApproval);
                        rdbApproval.Enabled = true;
                    }
                    else
                    {
                        rdbApproval.SelectedValue = Convert.ToString(pages.IsApproval);
                        rdbApproval.Enabled = false;
                    }

                    if (pages.PageType == true)
                    {
                        divFull.Visible = true;
                        divTitle1.Visible = true;
                    }
                    else
                    {
                        divFull.Visible = false;
                        divTitle1.Visible = false;
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

                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                {

                    rdbApproval.Enabled = true;
                }
                else
                {

                    rdbApproval.Enabled = false;
                }

            }
        }
        #endregion

        #region ReceiveHtml
        protected Pages ReceiveHtml()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int thumb_w = Convert.ToInt32(config.New_thumb_w);
            int thumb_h = Convert.ToInt32(config.New_thumb_h);

            commonBSO commonBSO = new commonBSO();
            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/BlogPage/";
            string image = commonBSO.UploadImage(file_image_thumb, path, thumb_w, thumb_h);


            Pages pages = new Pages();
            pages.PageID = (hddPageID.Value != "") ? Convert.ToInt32(hddPageID.Value) : 0;
            pages.PageName = (ddlPage.SelectedIndex != 0) ? ddlPage.SelectedValue.ToString() : txtPageName.Text;
            pages.Icon = rdbGroup.SelectedItem.Value;
            pages.PageTitle = (txtTitle.Text != "") ? txtTitle.Text : "";
            pages.PageType = Convert.ToBoolean(rdbType1.SelectedValue);
            pages.Describe = txtRadshort.Html;
            pages.Imagethumb = (image != "") ? image : hddImage.Value;
            pages.PageContent = txtRad_full.Html;
            pages.PostDate = txtRadDate.SelectedDate.Value;
            pages.Author = txtAuthor.Text;
            pages.Status = Convert.ToBoolean(rdbActive.SelectedItem.Value);
            pages.IsView = Convert.ToBoolean(rdbIsView.SelectedItem.Value);
            pages.Language = Language.language;
            pages.IsComment = Convert.ToBoolean(rdbComment.SelectedValue);

            pages.VisitTotal = (hddVisitTotal.Value != "") ? Convert.ToInt32(hddVisitTotal.Value) : 0;
            pages.CommentTotal = (hddCommentTotal.Value != "") ? Convert.ToInt32(hddCommentTotal.Value) : 0;

            pages.CreatedUserName = (hddCreateUserName.Value != "") ? hddCreateUserName.Value : Session["Admin_UserName"].ToString();


            pages.IsApproval = Convert.ToBoolean(rdbApproval.SelectedValue);
            if (hddApprovalUserName.Value != "")
            {
                pages.ApprovalUserName = hddApprovalUserName.Value;
                pages.ApprovalDate = Convert.ToDateTime(hddApprovalDate.Value);
            }
            else
                if (Convert.ToBoolean(rdbApproval.SelectedValue))
                {
                    pages.ApprovalUserName = Session["Admin_UserName"].ToString();
                    pages.ApprovalDate = DateTime.Now;
                }
                else
                {
                    pages.ApprovalUserName = "";
                    pages.ApprovalDate = DateTime.Now;
                }

            return pages;
        }
        #endregion
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Pages pages = ReceiveHtml();
                PagesBSO pagesBSO = new PagesBSO();
                pagesBSO.PageCreate(pages);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
                ViewCate(hddGroup.Value);
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
                Pages pages = ReceiveHtml();
                PagesBSO pagesBSO = new PagesBSO();
                pagesBSO.PagesUpdate(pages);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Trang", pages.PageName);
                ViewCate(hddGroup.Value);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

        protected void rdbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = rdbGroup.SelectedValue;
            ViewCate(value);
            hddGroup.Value = value;
        }

    }
}