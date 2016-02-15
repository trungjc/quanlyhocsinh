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
    public partial class ViewNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (!String.IsNullOrEmpty(Request.QueryString.Get("Id")))
                int.TryParse(Request.QueryString.Get("Id").Replace(",", ""), out Id);
            if (!IsPostBack)
                ViewNew(Id);
        }

        private void ViewNew(int Id)
        {
            NewsBSO newsBSO = new NewsBSO();
            News news = newsBSO.GetNewsById(Id);
            ltlTitle.Text = news.Title;
            LabelDate.Text = news.PostDate.ToString("dd/MM/yyyy");// Convert.ToString(news.PostDate);
            ltlDescribe.Text = news.ShortDescribe;
            FullDescirbe.Text = news.FullDescribe;
            LabelAuthor.Text = news.Author;

            if (news.ImageThumb != "")
                ltlImageThumb.Text = @"<img src='../../Upload/News/NewsThumb/" + news.ImageThumb + "' align='left' class='border_image' width='250'  >";


        }
    }
}