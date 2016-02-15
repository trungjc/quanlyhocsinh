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
    public partial class ViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (!String.IsNullOrEmpty(Request.QueryString.Get("Id")))
                int.TryParse(Request.QueryString.Get("Id").Replace(",", ""), out Id);
            if (!IsPostBack)
                ViewPages(Id);
        }

        #region ViewPages
        private void ViewPages(int Id)
        {
            PagesBSO pagesBSO = new PagesBSO();
            Pages pages = pagesBSO.GetPagesById(Id);





            ltlTitle.Text = pages.PageTitle;
            //     LabelDate.Text = pages.PostDate.ToString("dd/MM/yyyy");

            ltlDescribe.Text = pages.Describe;
            FullDescirbe.Text = pages.PageContent;
            LabelAuthor.Text = pages.Author;

            if (pages.Imagethumb != "")
                ltlImageThumb.Text = @"<img src='../../Upload/BlogPage/" + pages.Imagethumb + "' align='left' class='border_image' width='240' style='margin-bottom:3px;'>";

        }
        #endregion
    }
}