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
    public partial class EditNewsComment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

            int group = 0;
            if (!String.IsNullOrEmpty(Page.RouteData.Values["group"].ToString()))
                int.TryParse(Page.RouteData.Values["group"].ToString().Replace(",", ""), out group);

            hddGroup.Value = Convert.ToString(group);
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
                    NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
                    NewsComment newsComment = newsCommentBSO.GetNewsCommentById(Id);
                    txtTitle.Text = newsComment.Title;
                    txtFullName.Text = newsComment.FullName;
                    hddNewsID.Value = Convert.ToString(newsComment.NewsID);
                    txtContent.Html = newsComment.Content;
                    txtDateCreated.SelectedDate = newsComment.DateCreated;
                    txtEmail.Text = newsComment.Email;
                    //       rdbActive.SelectedValue = newsComment.Actived.ToString();
                    hddGroup.Value = newsComment.GroupCate.ToString();

                    hddApprovalUserName.Value = newsComment.ApprovalUserName;
                    hddApprovalDate.Value = Convert.ToString(newsComment.ApprovalDate);

                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                    {
                        rdbActive.SelectedValue = Convert.ToString(newsComment.Actived);
                        rdbActive.Enabled = true;
                    }
                    else
                    {
                        rdbActive.SelectedValue = Convert.ToString(newsComment.Actived);
                        rdbActive.Enabled = false;
                    }

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
                //     hddNewsID = 0;

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
        #endregion

        #region ReceiveHtml
        protected NewsComment ReceiveHtml()
        {


            NewsComment newsComment = new NewsComment();
            newsComment.CommentNewsID = (hddCommentID.Value != "") ? Convert.ToInt32(hddCommentID.Value) : 0;
            newsComment.NewsID = (hddNewsID.Value != "") ? Convert.ToInt32(hddNewsID.Value) : 0;
            newsComment.Title = txtTitle.Text;
            newsComment.Content = txtContent.Html;

            newsComment.FullName = txtFullName.Text;
            newsComment.Email = txtEmail.Text;
            newsComment.DateCreated = txtDateCreated.SelectedDate.Value;
            //    newsComment.Actived = Convert.ToBoolean(rdbActive.SelectedItem.Value);
            newsComment.GroupCate = Convert.ToInt32(hddGroup.Value);

            newsComment.Actived = Convert.ToBoolean(rdbActive.SelectedValue);
            if (hddApprovalUserName.Value != "")
            {
                newsComment.ApprovalUserName = hddApprovalUserName.Value;
                newsComment.ApprovalDate = Convert.ToDateTime(hddApprovalDate.Value);
            }
            else
                if (Convert.ToBoolean(rdbActive.SelectedValue))
                {
                    newsComment.ApprovalUserName = Session["Admin_UserName"].ToString();
                    newsComment.ApprovalDate = DateTime.Now;
                }
                else
                {
                    newsComment.ApprovalUserName = "";
                    newsComment.ApprovalDate = DateTime.Now;
                }

            return newsComment;
        }
        #endregion
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                NewsComment newsComment = ReceiveHtml();
                NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
                newsCommentBSO.CreateNewsComment(newsComment);
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
                NewsComment newsComment = ReceiveHtml();
                NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
                newsCommentBSO.UpdateNewsComment(newsComment);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Nhận xét", newsComment.Title);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

        protected void btn_list(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/listnewscomment/" + hddGroup.Value + "/Default.aspx");
        }
        protected void btn_editcomment(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/editnewscomment/" + hddGroup.Value + "/Default.aspx");

        }

    }
}