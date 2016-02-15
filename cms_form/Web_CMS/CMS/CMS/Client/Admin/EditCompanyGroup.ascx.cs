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
    public partial class EditCompanyGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString(), out Id);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            //if (!IsPostBack)
            //    initControl(Id);
            //ViewCateCompany();

            int group = 0;
            if (!String.IsNullOrEmpty(Page.RouteData.Values["group"].ToString()))
                if (!int.TryParse(Page.RouteData.Values["group"].ToString().Replace(",", ""), out group))
                    Response.Redirect("~/Admin/home/Default.aspx");

            if (group == 0)
                Response.Redirect("~/Admin/home/Default.aspx");
            else
            {
                if (!IsPostBack)
                {
                    hddGroupCate.Value = Convert.ToString(group);
                    ViewCateCompany(group);
                    initControl(Id);
                }
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

        #region ViewCateCompany
        private void ViewCateCompany(int group)
        {
            //ddlCategories.Items.Clear();
            //CateNewsBSO catenewsBSO = new CateNewsBSO();
            //DataTable table = catenewsBSO.GetCateNews(Language.language);
            //DataView dataView = new DataView(table);
            //dataView.RowFilter = "GroupCate = 2";
            //ddlCategories.DataSource = dataView;
            //ddlCategories.DataTextField = "CateNewsName";
            //ddlCategories.DataValueField = "CateNewsID";
            //ddlCategories.DataBind();

            //int group = 2;
            ddlCategories.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCategories, table, "", "", "CateNewsName", "CateNewsID", "");
        }
        #endregion

        #region initControl
        private void initControl(int Id)
        {
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    CompanyBSO companyBSO = new CompanyBSO();
                    Company company = companyBSO.GetCompanyById(Id);
                    hddCompanyID.Value = Convert.ToString(company.CompanyID);
                    ddlCategories.SelectedValue = Convert.ToString(company.Categories);
                    txtTitle.Text = company.Title;
                    txtRadDescription.Html = company.Description;
                    txtAuthor.Text = company.Author;
                    rdbIsNormal.SelectedValue = Convert.ToString(company.IsNormal);
                    rdbIsHot.SelectedValue = Convert.ToString(company.IsHot);

                    hddCommentTotal.Value = Convert.ToString(company.CommentTotal);
                    hddVisitTotal.Value = Convert.ToString(company.VisitTotal);
                    hddCreateUserName.Value = company.CreatedUserName;
                    hddApprovalUserName.Value = company.ApprovalUserName;
                    hddApprovalDate.Value = Convert.ToString(company.ApprovalDate);
                    hddCreatedDate.Value = Convert.ToString(company.CreatedDate);

                    rdbComment.SelectedValue = Convert.ToString(company.IsComment);
                    rdbIsDefault.SelectedValue = Convert.ToString(company.IsDefault);

                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                    {
                        rdbApproval.SelectedValue = Convert.ToString(company.IsApproval);
                        rdbApproval.Enabled = true;
                    }
                    else
                    {
                        rdbApproval.SelectedValue = Convert.ToString(company.IsApproval);
                        rdbApproval.Enabled = false;
                    }

                    hddGroupCate.Value = company.GroupCate.ToString();

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
        private Company ReceiveHtml()
        {
            Company company = new Company();
            company.CompanyID = (hddCompanyID.Value != "") ? Convert.ToInt32(hddCompanyID.Value) : 0;
            company.Categories = Convert.ToInt32(ddlCategories.SelectedValue);
            company.Title = txtTitle.Text;
            company.Description = txtRadDescription.Html;
            company.Author = txtAuthor.Text;
            company.IsNormal = Convert.ToBoolean(rdbIsNormal.SelectedValue);
            company.IsHot = Convert.ToBoolean(rdbIsHot.SelectedValue);
            company.Language = Language.language;

            company.IsComment = Convert.ToBoolean(rdbComment.SelectedValue);
            company.IsDefault = Convert.ToBoolean(rdbIsDefault.SelectedValue);

            company.VisitTotal = (hddVisitTotal.Value != "") ? Convert.ToInt32(hddVisitTotal.Value) : 0;
            company.CommentTotal = (hddCommentTotal.Value != "") ? Convert.ToInt32(hddCommentTotal.Value) : 0;

            company.CreatedUserName = (hddCreateUserName.Value != "") ? hddCreateUserName.Value : Session["Admin_UserName"].ToString();
            company.CreatedDate = (hddCreatedDate.Value != "") ? Convert.ToDateTime(hddCreatedDate.Value) : DateTime.Now;

            company.GroupCate = Convert.ToInt32(hddGroupCate.Value);

            company.IsApproval = Convert.ToBoolean(rdbApproval.SelectedValue);
            if (hddApprovalUserName.Value != "")
            {
                company.ApprovalUserName = hddApprovalUserName.Value;
                company.ApprovalDate = Convert.ToDateTime(hddApprovalDate.Value);
            }
            else
                if (Convert.ToBoolean(rdbApproval.SelectedValue))
                {
                    company.ApprovalUserName = Session["Admin_UserName"].ToString();
                    company.ApprovalDate = DateTime.Now;
                }
                else
                {
                    company.ApprovalUserName = "";
                    company.ApprovalDate = DateTime.Now;
                }
            return company;
        }
        #endregion

        protected void btn_edit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Company company = ReceiveHtml();
                CompanyBSO companyBSO = new CompanyBSO();
                companyBSO.UpdateCompany(company);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Thong tin", company.Title);
                ViewCateCompany(Convert.ToInt32(hddGroupCate.Value));
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        protected void btn_add_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Company company = ReceiveHtml();
                CompanyBSO companyBSO = new CompanyBSO();
                companyBSO.CreateCompany(company);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
                ViewCateCompany(Convert.ToInt32(hddGroupCate.Value));
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        protected void btn_list_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/listcompanygroup/" + hddGroupCate.Value + "/Default.aspx");

        }
        protected void btn_create_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/editcompanygroup/" + hddGroupCate.Value + "/Default.aspx");

        }
    }
}