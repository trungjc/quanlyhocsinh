using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using CMS;
using System.Data;

namespace Fomusa.Client.Modules.News
{
    public partial class NewsgDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["h"]!=null)
                if (!int.TryParse(Page.RouteData.Values["h"].ToString().Replace(",", ""), out Id))
                    Response.Redirect("~/Default.aspx");

            int gId = 0;
            if (Page.RouteData.Values["g"]!=null)
                if (!int.TryParse(Page.RouteData.Values["g"].ToString().Replace(",", ""), out gId))
                    Response.Redirect("~/Default.aspx");

            hddGroupCate.Value = Convert.ToString(gId);
            if (!IsPostBack)
                ViewNewsGroupDetail(Id);
        }
        private void ViewNewsGroupDetail(int Id)
        {
            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            NewsGroup newsgroup = newsgroupBSO.GetNewsGroupById(Id);
            if (newsgroup == null)
                Response.Redirect("~/Default.aspx");

            ltlTitle.Text = newsgroup.Title;
            LabelDate.Text = newsgroup.PostDate.ToString("dd/MM/yyyy");// Convert.ToString(newsgroup.PostDate);
            ltlDescribe.Text = newsgroup.ShortDescribe;
            FullDescirbe.Text = newsgroup.FullDescribe;
            LabelAuthor.Text = newsgroup.Author;
            txtNewsGroupID.Value = Convert.ToString(newsgroup.NewsGroupID);
            //if (newsgroup.ImageThumb != "")
            //    ltlImageThumb.Text = @"<img src='"+ResolveUrl("~/")+"Admin/Upload/NewsGroup/NewsGroupThumb/" + newsgroup.ImageThumb + "' align='left' class='border_image' width='250'  >";
            //Page.Title = newsgroup.Title;
            if (newsgroup.FileName != "")
                ltlFile.Text = @"<a href='" + ResolveUrl("~/") + "Admin/Upload/NewsGroup/Files/" + newsgroup.FileName + "'><img src='" + ResolveUrl("~/") + "images/icon_file.png' width='30' class='icon_bullet'/> Tải File đính kèm</a>";
            newsgroupBSO.NewsGroupClickUpdate(Id);
            NewsGroupFollow(newsgroup.NewsGroupID, newsgroup.CateNewsID);

            CateNewsBSO catenewsBSO = new CateNewsBSO();
            CateNews catenews = catenewsBSO.GetCateNewsById(newsgroup.CateNewsID);
            //HyperLinkCate.NavigateUrl = "~/Default.aspx?go=cate&Id=" + catenews.CateNewsID;
            title_name.Text = "<a href='" + ResolveUrl("~/") + "Category/" + catenews.GroupCate + "/" + catenews.CateNewsID + "/" + GetString(catenews.CateNewsName) + ".aspx'>" + catenews.CateNewsName + "</a>";

            string cate = "<a href='" + ResolveUrl("~/") + "FullNews/" + catenews.GroupCate + "/" + GetString(cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName) + ".aspx' class='content_Text_Cat'>";
            string s1 = "";
            while (catenews.ParentNewsID != 0)
            {
                int pId = catenews.ParentNewsID;
                catenews = catenewsBSO.GetCateNewsById(pId);
                s1 = "<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'><a href='" + ResolveUrl("~/") + "Category/" + catenews.GroupCate + "/" + catenews.CateNewsID + "/" + GetString(catenews.CateNewsName) + ".aspx'' class='content_Text_Cat'>" + catenews.CateNewsName + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;" + s1;
            }
            cate += cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName.ToUpper(); //Sửa lại
            cate += "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>";
            cate += s1;
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + String.Format(Resources.resource.Home) + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp; ";
            title_cate.Text += cate;

            if (!String.IsNullOrEmpty(Request["error"]))
                error.Text = "<div class='error_register_text'>" + String.Format(Resources.resource.ThanksComment) + "</div>";

            if (!newsgroup.IsComment)
            {
                CommentPanel.Visible = false;
            }
            else
            {
                CommentPanel.Visible = true;
                GetNewsCommentById(Id);
            }

            Page.Title = GetString(newsgroup.Title);
        }
        private void NewsGroupFollow(int Id, int cId)
        {
            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            DataTable table = newsgroupBSO.NewsGroupFollow(Id, cId, 10, "1");
            if (table.Rows.Count > 0)
                Label1.Text = "<div class='title_article_top'>" + String.Format(Resources.resource.OtherNews) + "</div>";
            else
                Label1.Text = "";

            DataView view = new DataView(table);
            view.Sort = "PostDate Desc";
            table = view.ToTable();

            DataListNews.DataSource = table;
            DataListNews.DataBind();
        }
        protected void Send_email(object sender, EventArgs e)
        {
            Response.Redirect("~/MailNews/" + txtNewsGroupID.Value + "/Default.aspx");
        }
        protected void Print(object sender, EventArgs e)
        {
            Response.Redirect("~/News/PrintNews/" + txtNewsGroupID.Value + "/Default.aspx");
        }

        private void GetNewsCommentById(int cId)
        {
            NewsCommentBSO newsCommentBSO = new NewsCommentBSO();



            DataTable table = newsCommentBSO.GetNewsCommentByNewsID(cId);

            DataView view = new DataView(table);
            view.RowFilter = "Actived = 1";
            table = view.ToTable();


            if (table.Rows.Count > 0)
                lblComment.Text = "<div class='gt_title'> <div class='title_article_top_comment'>Ý kiến nhận xét (" + table.Rows.Count.ToString() + " ý kiến)</div></div>";
            else
                lblComment.Text = "";


            DataListProductComment.DataSource = table;
            DataListProductComment.DataBind();


        }

        #region ReceiveHtml
        protected NewsComment ReceiveHtml()
        {


            NewsComment newsComment = new NewsComment();
            newsComment.CommentNewsID = 0;
            newsComment.NewsID = Convert.ToInt32(txtNewsGroupID.Value);
            newsComment.Title = txtTitle.Text;
            newsComment.Content = txtContent.Text;

            newsComment.FullName = txtFullName.Text;
            newsComment.Email = txtEmail.Text;
            newsComment.DateCreated = DateTime.Now;
            newsComment.Actived = false;
            newsComment.GroupCate = Convert.ToInt32(hddGroupCate.Value);
            newsComment.ApprovalDate = DateTime.Now;
            newsComment.ApprovalUserName = "";

            return newsComment;
        }
        #endregion

        protected void Send_Click(object sender, EventArgs e)
        {

            NewsComment newsComment = ReceiveHtml();
            NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
            newsCommentBSO.CreateNewsComment(newsComment);

            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);

            string strBody = "Thông tin nhận xét đánh giá về bài viết trên trang Website " + config.WebName + " (" + config.WebDomain + ") : <br>";
            strBody += "<b>Tiêu đề: </b> " + newsComment.Title + "<br>";
            strBody += "<b>Họ tên khách hàng : </b> " + newsComment.FullName + "<br>";

            strBody += "<b>Email : </b> " + newsComment.Email + "<br>";
            strBody += "<b>Mã bài viết : </b> " + newsComment.NewsID + "<br>";
            strBody += "<b>Nội dung : </b> <br>" + newsComment.Content + "<br>";

            NewsGroupBSO newsBSO = new NewsGroupBSO();
            NewsGroup news = newsBSO.GetNewsGroupById(newsComment.NewsID);

            strBody += "<b>Tiêu đề bài viết : </b>  <a href='" + config.WebDomain + "/News/" + hddGroupCate.Value + "/" + newsComment.NewsID + "/" + GetString(news.Title) + ".aspx'>" + news.Title + "</a><br>";

            MailBSO mailBSO = new MailBSO();
            mailBSO.EmailFrom = newsComment.Email;




            mailBSO.EmailFrom = config.Email_from;

            string strObj = "Thông tin nhận xét về bài viết trên trang Web " + config.WebName + " (" + config.WebDomain + ") - Ngày " + DateTime.Now.ToString("dd:MM:yyyy");
            mailBSO.SendMail(config.Email_to, strObj, strBody);



            int Id = Convert.ToInt32(txtNewsGroupID.Value);
            Response.Redirect("~/News/" + hddGroupCate.Value + "/" + Id + "/2/Default.aspx");


        }

        protected string GetString(object _txt)
        {
            if (_txt != null)
            {
                Utils objUtil = new Utils();
                return objUtil.Getstring(_txt.ToString());
            }
            return "";
        }
    }
}