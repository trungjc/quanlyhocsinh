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
    public partial class EditPageComment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

            string group = "";
            if (!String.IsNullOrEmpty(Page.RouteData.Values["group"].ToString()))
                group = Page.RouteData.Values["group"].ToString();

            hddGroup.Value = group;
            if (!IsPostBack)
            {

                initControl(Id);
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
        protected void initControl(int Id)
        {
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                hddCommentID.Value = Convert.ToString(Id);
                try
                {
                    PageCommentBSO pageCommentBSO = new PageCommentBSO();
                    PageComment pageComment = pageCommentBSO.GetPageCommentById(Id);
                    txtTitle.Text = pageComment.Title;
                    txtFullName.Text = pageComment.FullName;
                    hddNewsID.Value = Convert.ToString(pageComment.PageID);
                    txtContent.Html = pageComment.Content;
                    txtDateCreated.SelectedDate = pageComment.DateCreated;
                    rdbActive.SelectedValue = pageComment.Actived.ToString();
                    hddGroup.Value = pageComment.GroupCate;
                    txtEmail.Text = pageComment.Email;

                    hddApprovalUserName.Value = pageComment.ApprovalUserName;
                    hddApprovalDate.Value = Convert.ToString(pageComment.ApprovalDate);

                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                    {
                        rdbActive.SelectedValue = Convert.ToString(pageComment.Actived);
                        rdbActive.Enabled = true;
                    }
                    else
                    {
                        rdbActive.SelectedValue = Convert.ToString(pageComment.Actived);
                        rdbActive.Enabled = false;
                    }

                }
                catch (Exception ex)
                {
                    clientview.Text = ex.Message.ToString();

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                    {

                        rdbActive.Enabled = true;
                    }
                    else
                    {

                        rdbActive.Enabled = false;
                    }
                }
            }
            else
            {
                btn_add.Visible = true;
                btn_edit.Visible = false;
                //     hddNewsID = 0;
            }
        }
        #endregion

        #region ReceiveHtml
        protected PageComment ReceiveHtml()
        {


            PageComment pageComment = new PageComment();
            pageComment.CommentPageID = (hddCommentID.Value != "") ? Convert.ToInt32(hddCommentID.Value) : 0;
            pageComment.PageID = (hddNewsID.Value != "") ? Convert.ToInt32(hddNewsID.Value) : 0;
            pageComment.Title = txtTitle.Text;
            pageComment.Content = txtContent.Html;

            pageComment.FullName = txtFullName.Text;
            pageComment.Email = txtEmail.Text;
            pageComment.DateCreated = txtDateCreated.SelectedDate.Value;
            pageComment.Actived = Convert.ToBoolean(rdbActive.SelectedItem.Value);
            pageComment.GroupCate = hddGroup.Value;

            pageComment.Actived = Convert.ToBoolean(rdbActive.SelectedValue);
            if (hddApprovalUserName.Value != "")
            {
                pageComment.ApprovalUserName = hddApprovalUserName.Value;
                pageComment.ApprovalDate = Convert.ToDateTime(hddApprovalDate.Value);
            }
            else
                if (Convert.ToBoolean(rdbActive.SelectedValue))
                {
                    pageComment.ApprovalUserName = Session["Admin_UserName"].ToString();
                    pageComment.ApprovalDate = DateTime.Now;
                }
                else
                {
                    pageComment.ApprovalUserName = "";
                    pageComment.ApprovalDate = DateTime.Now;
                }

            return pageComment;
        }
        #endregion
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                PageComment pageComment = ReceiveHtml();
                PageCommentBSO pageCommentBSO = new PageCommentBSO();
                pageCommentBSO.CreatePageComment(pageComment);
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
                PageComment pageComment = ReceiveHtml();
                PageCommentBSO pageCommentBSO = new PageCommentBSO();
                pageCommentBSO.UpdatePageComment(pageComment);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Nhận xét", pageComment.Title);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

        protected void btn_list(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/listpagecomment/" + hddGroup.Value + "/Default.aspx");
        }
        protected void btn_editcomment(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/editpagecomment/" + hddGroup.Value + "/Default.aspx");

        }

    }
}