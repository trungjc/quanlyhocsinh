using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS;
using System.Data;
using BSO;
using ETO;

namespace Fomusa.Client.Modules.Official
{
    public partial class OfficialList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["h"] != null)
                int.TryParse(Page.RouteData.Values["h"].ToString(), out Id);

            int gId = 0;
            if (Page.RouteData.Values["g"] != null)
                int.TryParse(Page.RouteData.Values["g"].ToString(), out gId);

            hddGroupCate.Value = Convert.ToString(gId);

            if (!IsPostBack)
            {
                GetOfficialByCate(Id);
                ViewNavigator(Id);
                hddID.Value = Convert.ToString(Id);

                GetCateParentNews(Id);
            }
        }
        private void GetOfficialByCate(int Id)
        {
            OfficialBSO officialBSO = new OfficialBSO();
            DataTable table = officialBSO.GetOfficialByCate(Id, "1");
            GridView1.DataSource = table;
            GridView1.DataBind();
        }

        private void ViewNavigator(int Id)
        {
            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            CateNews catenews = catenewsBSO.GetCateNewsById(Id);
            //HyperLinkCate.NavigateUrl = "~/Default.aspx?go=cate&Id=" + catenews.CateNewsID;


            title_name.Text = catenews.CateNewsName;

            //    Label1.Text = "<div class='gt_title'> <div class='title_article_top'>" + Literal1.Text + "</div><div class='title_article_bg'></div></div>";

            string cate = "<a href='" + ResolveUrl("~/") + "FullNews/" + catenews.GroupCate + "/" + GetString(cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName) + "/default.aspx' class='content_Text_Cat'>";
            string s1 = "";
            while (catenews.ParentNewsID != 0)
            {
                int pId = catenews.ParentNewsID;
                catenews = catenewsBSO.GetCateNewsById(pId);
                s1 = "<a href='" + ResolveUrl("~/") + "Category/" + catenews.GroupCate + "/" + catenews.CateNewsID + "/" + GetString(catenews.CateNewsName) + "/default.aspx' class='content_Text_Cat'>" + catenews.CateNewsName + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png' >" + s1;
            }


            cate += cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName.ToUpper(); //Sửa lại
            cate += "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png' >&nbsp;";
            cate += s1;
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png' > &nbsp;";
            title_cate.Text += cate;

            Page.Title = "Thủy điện Sơn La : " + GetString(catenews.CateNewsName);

        }

        private void GetCateParentNews(int cId)
        {
            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table = cateNewsBSO.GetCateParentGroupAll(cId, Language.language, 4);

            DataList1.DataSource = table;
            DataList1.DataBind();


        }
        protected void DataListCateNews_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string Imgthumb = DataBinder.Eval(e.Item.DataItem, "ImageThumb").ToString();
            Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlImageThumb");
            if (Imgthumb != "")
                ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Admin/Upload/NewsGroup/NewsGroupThumb/" + Imgthumb + "' align='left' class='border_image' width='140' >";
        }

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string Imgthumb = DataBinder.Eval(e.Item.DataItem, "ImageThumb").ToString();
            Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlImageThumb");
            if (Imgthumb != "")
                ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Admin/Upload/NewsGroup/NewsGroupThumb/" + Imgthumb + "' class='border_image' width='140' align='left'>";
            //else
            //    ltlImageThumb.Text = @"<img src='images/image_demo.jpg' align='left' class='border_image_pro' width='70'>";
        }
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView dtl2 = (GridView)e.Item.FindControl("GridView2");

            int cateId;
            int.TryParse(DataBinder.Eval(e.Item.DataItem, "CateNewsID").ToString(), out cateId);
            //        int cateId =   ((int)e.Item).CateNewsID;

            string strCate = GetCateParentIDArrayByID(cateId);

            OfficialBSO officeBSO = new OfficialBSO();
            DataTable table = officeBSO.GetOfficialByCateHomeList(strCate, 5, "1");

            //DataView view1 = new DataView(table);
            //view1.Sort = "NewsID DESC";

            dtl2.DataSource = table;
            dtl2.DataBind();
        }

        private string GetCateParentIDArrayByID(int cID)
        {
            string strArrayID = Convert.ToString(cID) + ",";

            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table1 = cateNewsBSO.GetCateNewsParentAll(cID, Language.language);

            if (table1.Rows.Count > 0)
            {
                foreach (DataRow subrow in table1.Rows)
                {
                    //    strArrayID += subrow["CateNewsID"].ToString() + ",";
                    strArrayID += GetCateParentIDArrayByID(Convert.ToInt32(subrow["CateNewsID"].ToString()));
                }

            }

            return strArrayID;

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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}