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
    public partial class EditNewsGroup : System.Web.UI.UserControl
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
                if (!int.TryParse(Page.RouteData.Values["group"].ToString().Replace(",", ""), out group))
                    Response.Redirect("~/Admin/home/Default.aspx");

            if (group == 0)
                Response.Redirect("~/Admin/home/Default.aspx");
            else
            {
                if (!IsPostBack)
                {
                    hddGroup.Value = Convert.ToString(group);
                    ViewCateNews(group);
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

        #region ViewCateNews
        private void ViewCateNews(int group)
        {
            ddlCateNews.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateNews, table, "", "", "CateNewsName", "CateNewsID", "");
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
                    NewsGroup newsgroup = new NewsGroup();
                    NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
                    newsgroup = newsgroupBSO.GetNewsGroupById(Id);
                    hddNewsGroupID.Value = Convert.ToString(newsgroup.NewsGroupID);
                    ddlCateNews.SelectedValue = Convert.ToString(newsgroup.CateNewsID);
                    hddParentNewsID.Value = Convert.ToString(newsgroup.ParentNewsID);

                    //rdbGroupCate.SelectedValue = Convert.ToString(newsgroup.GroupCate); //Thêm

                    txtTitle.Text = newsgroup.Title;
                    txtRadShort.Html = newsgroup.ShortDescribe;
                    txtRadFull.Html = newsgroup.FullDescribe;
                    hddImageThumb.Value = newsgroup.ImageThumb;
                    uploadPreview.Src = ResolveUrl("~/Upload/NewsGroup/NewsGroupThumb/") + newsgroup.ImageThumb;
                    hddImageLarge.Value = newsgroup.ImageLarge;
                    hddFileName.Value = newsgroup.FileName;

                    txtAuthor.Text = newsgroup.Author;
                    txtRadDate.SelectedDate = newsgroup.PostDate;
                    hddRelationTotal.Value = Convert.ToString(newsgroup.RelationTotal);
                    rdbStatus.SelectedValue = Convert.ToString(newsgroup.Status);
                    rdbIshot.SelectedValue = Convert.ToString(newsgroup.Ishot);
                    rdbIshome.SelectedValue = Convert.ToString(newsgroup.Ishome);


                    hddCommentTotal.Value = Convert.ToString(newsgroup.CommentTotal);
                    hddIsView.Value = Convert.ToString(newsgroup.Isview);
                    hddCreateUserName.Value = newsgroup.CreatedUserName;
                    hddApprovalUserName.Value = newsgroup.ApprovalUserName;
                    hddApprovalDate.Value = Convert.ToString(newsgroup.ApprovalDate);


                    rdbComment.SelectedValue = Convert.ToString(newsgroup.IsComment);

                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                    {
                        rdbApproval.SelectedValue = Convert.ToString(newsgroup.IsApproval);
                        rdbApproval.Enabled = true;
                    }
                    else
                    {
                        rdbApproval.SelectedValue = Convert.ToString(newsgroup.IsApproval);
                        rdbApproval.Enabled = false;
                    }

                    hddGroup.Value = newsgroup.GroupCate.ToString();
                    ViewCateNews(newsgroup.GroupCate);
                    rdbTypeNews.SelectedValue = Convert.ToString(newsgroup.TypeNews);

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
        private NewsGroup ReceiveHtml()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            CateNewsGroupBSO catgroup = new CateNewsGroupBSO();
            int thumb_w = Convert.ToInt32(config.New_thumb_w);
            int thumb_h = Convert.ToInt32(config.New_thumb_h);

            commonBSO commonBSO = new commonBSO();
            string path_thumb = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/NewsGroup/NewsGroupThumb/";
            string image_thumb = commonBSO.UploadImage(file_image_thumb, path_thumb, thumb_w, thumb_h);

            int large_w = Convert.ToInt32(config.New_large_w);
            int large_h = Convert.ToInt32(config.New_large_h);
            string path_large = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/NewsGroup/NewsGroupLarge/";
            string image_large = commonBSO.UploadImage(file_image_thumb, path_large, large_w, large_h);

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/NewsGroup/Files/";
            string file_upload = commonBSO.UploadFile(file_attached, path, 1800000000000);

            NewsGroup newsgroup = new NewsGroup();
            newsgroup.NewsGroupID = (hddNewsGroupID.Value != "") ? Convert.ToInt32(hddNewsGroupID.Value) : 0;
            newsgroup.CateNewsID = Convert.ToInt32(ddlCateNews.SelectedValue);
            newsgroup.ParentNewsID = (hddParentNewsID.Value != "") ? Convert.ToInt32(hddParentNewsID.Value) : 0;
            newsgroup.GroupCate = Convert.ToInt32(hddGroup.Value);

            newsgroup.Title = txtTitle.Text;
            newsgroup.ShortDescribe = txtRadShort.Html;
            newsgroup.FullDescribe = txtRadFull.Html;
            newsgroup.ImageThumb = (image_thumb != "") ? image_thumb : hddImageThumb.Value;
            newsgroup.ImageLarge = (image_large != "") ? image_large : hddImageLarge.Value;
            newsgroup.FileName = (file_upload != "") ? file_upload : hddFileName.Value;

            newsgroup.Author = txtAuthor.Text;
            newsgroup.PostDate = txtRadDate.SelectedDate.Value;
            newsgroup.RelationTotal = (hddRelationTotal.Value != "") ? Convert.ToInt32(hddRelationTotal.Value) : 0;
            newsgroup.Status = Convert.ToBoolean(rdbStatus.SelectedItem.Value);
            newsgroup.Language = catgroup.GetCateNewsGroupByGroupCate(Convert.ToInt32(hddGroup.Value)).Language;
            newsgroup.Ishot = Convert.ToBoolean(rdbIshot.SelectedValue);
            newsgroup.Ishome = Convert.ToBoolean(rdbIshome.SelectedValue);

            newsgroup.TypeNews = Convert.ToBoolean(rdbTypeNews.SelectedValue);

            newsgroup.IsComment = Convert.ToBoolean(rdbComment.SelectedValue);

            newsgroup.Isview = (hddIsView.Value != "") ? Convert.ToInt32(hddIsView.Value) : 0;
            newsgroup.CommentTotal = (hddCommentTotal.Value != "") ? Convert.ToInt32(hddCommentTotal.Value) : 0;

            newsgroup.CreatedUserName = (hddCreateUserName.Value != "") ? hddCreateUserName.Value : Session["Admin_UserName"].ToString();



            newsgroup.IsApproval = Convert.ToBoolean(rdbApproval.SelectedValue);
            if (hddApprovalUserName.Value != "")
            {
                newsgroup.ApprovalUserName = hddApprovalUserName.Value;
                newsgroup.ApprovalDate = Convert.ToDateTime(hddApprovalDate.Value);
            }
            else
                if (Convert.ToBoolean(rdbApproval.SelectedValue))
                {
                    newsgroup.ApprovalUserName = Session["Admin_UserName"].ToString();
                    newsgroup.ApprovalDate = DateTime.Now;
                }
                else
                {
                    newsgroup.ApprovalUserName = "";
                    newsgroup.ApprovalDate = DateTime.Now;
                }


            return newsgroup;

        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                NewsGroup newsgroup = ReceiveHtml();
                NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
                newsgroupBSO.CreateNewsGroup(newsgroup);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
                //ViewCateNews(Convert.ToInt32(hddGroup.Value));
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
                NewsGroup newsgroup = ReceiveHtml();
                NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
                newsgroupBSO.UpdateNewsGroup(newsgroup);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "tin", newsgroup.Title);
                //ViewCateNews(Convert.ToInt32(hddGroup.Value));
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

        protected void btn_create_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/editnewsgroup/" + hddGroup.Value + "/Default.aspx");

        }

    }
}