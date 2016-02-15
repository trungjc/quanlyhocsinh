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
    public partial class ViewNewsGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);
            if (!IsPostBack)
                ViewNews(Id);
        }

        #region ViewNews
        private void ViewNews(int Id)
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            NewsGroup newsGroup = newsGroupBSO.GetNewsGroupById(Id);
            if (newsGroup != null)
            {
                ltlTitle.Text = newsGroup.Title;
                LabelDate.Text = newsGroup.PostDate.ToString("dd/MM/yyyy");// Convert.ToString(newsGroup.PostDate);
                ltlDescribe.Text = newsGroup.ShortDescribe;
                FullDescirbe.Text = newsGroup.FullDescribe;
                LabelAuthor.Text = newsGroup.Author;

                if (newsGroup.ImageThumb != "")
                    ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Upload/NewsGroup/NewsGroupThumb/" + newsGroup.ImageThumb + "' align='left' class='border_image' width='250'  >";

            }
        }
        #endregion
    }
}