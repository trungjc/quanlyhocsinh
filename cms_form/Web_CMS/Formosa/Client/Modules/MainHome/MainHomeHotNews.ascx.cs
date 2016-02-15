using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Data;
using ETO;
using CMS;

namespace Fomusa
{
    public partial class MainHomeHotNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewNewsHot(1);
        }
        private void ViewNewsHot(int groupcate)
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            DataTable table = newsGroupBSO.GetNewsGroupHot(Language.lang, 5, "1", groupcate);


            DataListCateNews.DataSource = table;
            DataListCateNews.DataBind();

            DataListNewsHot.DataSource = table;
            DataListNewsHot.DataBind();



        }
        protected void DataListCateNews_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string Imgthumb = DataBinder.Eval(e.Item.DataItem, "ImageThumb").ToString();
            Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlImageThumb");
            if (Imgthumb != "")
                ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "admin/Upload/NewsGroup/NewsGroupThumb/" + Imgthumb + "' align='left' class='image_new_hot' width='390px' height='285px' >";

            string title = DataBinder.Eval(e.Item.DataItem, "Title").ToString();
            string desc = DataBinder.Eval(e.Item.DataItem, "ShortDescribe").ToString();
            int newsId = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "NewsGroupID").ToString());
            int categ = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "GroupCate").ToString());

            Literal ltrText = (Literal)e.Item.FindControl("ltlText");
            ltrText.Text = @"<span style='display: none;' class='bottom'><h1 class='cssTitle'><a href='" + ResolveUrl("~/") + "News/" + categ + "/" + Convert.ToString(newsId) + "/" + GetString(title) + ".aspx'>" + title + "</a></h1></span>";

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