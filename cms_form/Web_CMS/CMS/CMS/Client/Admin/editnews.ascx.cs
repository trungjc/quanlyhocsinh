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
    public partial class editnews : System.Web.UI.UserControl
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
                ViewCateNews();
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

        #region ViewCateNews
        private void ViewCateNews()
        {
            //ddlCateNews.Items.Clear();
            //CateNewsBSO catenewsBSO = new CateNewsBSO();
            //DataTable table = catenewsBSO.GetCateNews(Language.language);
            //DataView dataView = new DataView(table);
            //dataView.RowFilter = "GroupCate = 1";
            //ddlCateNews.DataSource = dataView;
            //ddlCateNews.DataTextField = "CateNewsName";
            //ddlCateNews.DataValueField = "CateNewsID";
            //ddlCateNews.DataBind();
            //commonBSO commonBSO = new commonBSO();
            //commonBSO.FillToDropDown(ddlCateNews, table, "", "", "CateNewsName", "CateNewsID", "");

            int group = 1;

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
                    News news = new News();
                    NewsBSO newsBSO = new NewsBSO();
                    news = newsBSO.GetNewsById(Id);
                    hddNewsID.Value = Convert.ToString(news.NewsID);
                    ddlCateNews.SelectedValue = Convert.ToString(news.CateNewsID);
                    hddParentNewsID.Value = Convert.ToString(news.ParentNewsID);
                    txtTitle.Text = news.Title;
                    txtRadShort.Html = news.ShortDescribe;
                    txtRadFull.Html = news.FullDescribe;
                    hddImageThumb.Value = news.ImageThumb;
                    hddImageLarge.Value = news.ImageLarge;
                    txtAuthor.Text = news.Author;
                    txtRadDate.SelectedDate = news.PostDate;
                    hddRelationTotal.Value = Convert.ToString(news.RelationTotal);
                    rdbStatus.SelectedValue = Convert.ToString(news.Status);
                    rdbIshot.SelectedValue = Convert.ToString(news.Ishot);
                    rdbIshome.SelectedValue = Convert.ToString(news.Ishome);


                    hddCommentTotal.Value = Convert.ToString(news.CommentTotal);
                    hddIsView.Value = Convert.ToString(news.Isview);
                    hddCreateUserName.Value = news.CreatedUserName;
                    hddApprovalUserName.Value = news.ApprovalUserName;
                    hddApprovalDate.Value = Convert.ToString(news.ApprovalDate);


                    rdbComment.SelectedValue = Convert.ToString(news.IsComment);

                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                    {
                        rdbApproval.SelectedValue = Convert.ToString(news.IsApproval);
                        rdbApproval.Enabled = true;
                    }
                    else
                    {
                        rdbApproval.SelectedValue = Convert.ToString(news.IsApproval);
                        rdbApproval.Enabled = false;
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
        private News ReceiveHtml()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int thumb_w = Convert.ToInt32(config.New_thumb_w);
            int thumb_h = Convert.ToInt32(config.New_thumb_h);

            commonBSO commonBSO = new commonBSO();
            string path_thumb = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/News/NewsThumb/";
            string image_thumb = commonBSO.UploadImage(file_image_thumb, path_thumb, thumb_w, thumb_h);

            int large_w = Convert.ToInt32(config.New_large_w);
            int large_h = Convert.ToInt32(config.New_large_h);
            string path_large = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/News/NewsLarge/";
            string image_large = commonBSO.UploadImage(file_image_large, path_large, large_w, large_h);

            News news = new News();
            news.NewsID = (hddNewsID.Value != "") ? Convert.ToInt32(hddNewsID.Value) : 0;
            news.CateNewsID = Convert.ToInt32(ddlCateNews.SelectedValue);
            news.ParentNewsID = (hddParentNewsID.Value != "") ? Convert.ToInt32(hddParentNewsID.Value) : 0;
            news.Title = txtTitle.Text;
            news.ShortDescribe = txtRadShort.Html;
            news.FullDescribe = txtRadFull.Html;
            news.ImageThumb = (image_thumb != "") ? image_thumb : hddImageThumb.Value;
            news.ImageLarge = (image_large != "") ? image_large : hddImageLarge.Value;
            news.Author = txtAuthor.Text;
            news.PostDate = txtRadDate.SelectedDate.Value;
            news.RelationTotal = (hddRelationTotal.Value != "") ? Convert.ToInt32(hddRelationTotal.Value) : 0;
            news.Status = Convert.ToBoolean(rdbStatus.SelectedItem.Value);
            news.Language = Language.language;
            news.Ishot = Convert.ToBoolean(rdbIshot.SelectedValue);
            news.Ishome = Convert.ToBoolean(rdbIshome.SelectedValue);
            news.IsComment = Convert.ToBoolean(rdbComment.SelectedValue);

            news.Isview = (hddIsView.Value != "") ? Convert.ToInt32(hddIsView.Value) : 0;
            news.CommentTotal = (hddCommentTotal.Value != "") ? Convert.ToInt32(hddCommentTotal.Value) : 0;

            news.CreatedUserName = (hddCreateUserName.Value != "") ? hddCreateUserName.Value : Session["Admin_UserName"].ToString();

            news.GroupCate = 1;

            news.IsApproval = Convert.ToBoolean(rdbApproval.SelectedValue);
            if (hddApprovalUserName.Value != "")
            {
                news.ApprovalUserName = hddApprovalUserName.Value;
                news.ApprovalDate = Convert.ToDateTime(hddApprovalDate.Value);
            }
            else
                if (Convert.ToBoolean(rdbApproval.SelectedValue))
                {
                    news.ApprovalUserName = Session["Admin_UserName"].ToString();
                    news.ApprovalDate = DateTime.Now;
                }
                else
                {
                    news.ApprovalUserName = "";
                    news.ApprovalDate = DateTime.Now;
                }


            return news;

        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                News news = ReceiveHtml();
                NewsBSO newsBSO = new NewsBSO();
                newsBSO.CreateNews(news);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
                ViewCateNews();
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
                News news = ReceiveHtml();
                NewsBSO newsBSO = new NewsBSO();
                newsBSO.UpdateNews(news);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "tin", news.Title);
                ViewCateNews();
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

    }
}