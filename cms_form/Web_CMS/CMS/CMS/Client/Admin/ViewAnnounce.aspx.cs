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
    public partial class ViewAnnounce : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (!String.IsNullOrEmpty(Request.QueryString.Get("Id")))
                int.TryParse(Request.QueryString.Get("Id").Replace(",", ""), out Id);
            if (!IsPostBack)
                ViewNews(Id);
        }

        #region ViewNews
        private void ViewNews(int Id)
        {
            AnnounceBSO announceBSO = new AnnounceBSO();
            Announce announce = announceBSO.GetAnnounceById(Id);
            ltlTitle.Text = announce.Title;
            LabelDate.Text = announce.PostDate.ToString("dd/MM/yyyy");// Convert.ToString(news.PostDate);
            ltlDescribe.Text = announce.ShortDescribe;
            FullDescirbe.Text = announce.FullDescribe;
            LabelAuthor.Text = announce.Author;

            if (announce.ImageThumb != "")
                ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Upload/Announce/AnnounceThumb/" + announce.ImageThumb + "' align='left' class='border_image' width='250'  >";


        }
        #endregion
    }
}