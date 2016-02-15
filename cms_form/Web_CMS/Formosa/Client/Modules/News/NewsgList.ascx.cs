using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Data;
using CMS;
using ETO;

namespace Fomusa.Client.Modules.News
{
    public partial class NewsgList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["h"]!=null)
                int.TryParse(Page.RouteData.Values["h"].ToString(), out Id);
            int gId = 0;
            if (Page.RouteData.Values["g"]!=null)
                int.TryParse(Page.RouteData.Values["g"].ToString(), out gId);

            hddGroupCate.Value = Convert.ToString(gId);

            if (!IsPostBack)
            {
                GetNewsGroupByCate(Id);

                GetCateParentNewsGroup(Id);
            }
        }
        private void GetNewsGroupByCate(int cId)
        {
            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();

            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            DataTable table = newsGroupBSO.GetNewsGroupByCate(cId, Language.language, "1");

            DataView view = new DataView(table);
            view.Sort = "PostDate Desc";
            table = view.ToTable();

            DataTable tableClone = table.Clone();
            DataTable tblClone = table.Clone();

            for (int j = 0; j < table.Rows.Count; j++)
            {
                if (j < 10)
                    tableClone.ImportRow(table.Rows[j]);
                else if (j < 20)
                {
                    tblClone.ImportRow(table.Rows[j]);
                    Label1.Text = "<div class='gt_title'> <div class='title_article_top'>Các tin khác</div></div>";
                }
                else
                    break;

            }
            if (table.Rows.Count > 0)
            {
                DataListCateNews.Visible = true;
                DataListCateNews.DataSource = tableClone;
                DataListCateNews.DataBind();
                CateNewsPanel.Visible = true;
                Repeater1.DataSource = tblClone;
                Repeater1.DataBind();
            }
            else
            {
                DataListCateNews.Visible = false;
                CateNewsPanel.Visible = false;
            }


            CateNewsBSO catenewsBSO = new CateNewsBSO();
            CateNews catenews = catenewsBSO.GetCateNewsById(cId);
            //HyperLinkCate.NavigateUrl = "~/Default.aspx?go=cate&Id=" + catenews.CateNewsID;


            title_name.Text = catenews.CateNewsName;

            //    Label1.Text = "<div class='gt_title'> <div class='title_article_top'>" + Literal1.Text + "</div><div class='title_article_bg'></div></div>";

            string cate = "<a href='" + ResolveUrl("~/") + "FullNews/" + catenews.GroupCate + "/" + GetString(cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName) + "/default.aspx' class='content_Text_Cat'>";
            string s1 = "";
            while (catenews.ParentNewsID != 0)
            {
                int pId = catenews.ParentNewsID;
                catenews = catenewsBSO.GetCateNewsById(pId);
                s1 = "<a href='" + ResolveUrl("~/") + "Category/" + catenews.GroupCate + "/" + catenews.CateNewsID + "/" + GetString(catenews.CateNewsName) + "/default.aspx' class='content_Text_Cat'>" + catenews.CateNewsName + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;" + s1;
            }

            cate += cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName.ToUpper(); //Sửa lại
            cate += "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>";
            cate += s1;
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            title_cate.Text += cate;

            Page.Title = GetString(cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName);

        }


        protected void DataListCateNews_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string Imgthumb = DataBinder.Eval(e.Item.DataItem, "ImageThumb").ToString();
            Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlImageThumb");
            if (Imgthumb != "")
                ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Admin/Upload/NewsGroup/NewsGroupThumb/" + Imgthumb + "' align='left' class='border_image' width='140' >";
        }


        private void GetCateParentNewsGroup(int cId)
        {
            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table = cateNewsBSO.GetCateNewsParentAll(cId, Language.language);

            DataList1.DataSource = table;
            DataList1.DataBind();


        }
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            DataList dtl2 = (DataList)e.Item.FindControl("DataList2");

            int cateId;
            int.TryParse(DataBinder.Eval(e.Item.DataItem, "CateNewsID").ToString(), out cateId);
            //        int cateId =   ((int)e.Item).CateNewsID;

            string strCate = GetCateParentIDArrayByID(cateId, Convert.ToInt32(hddGroupCate.Value));

            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            DataTable table = newsGroupBSO.GetNewsGroupByCateHomeList(strCate, 5, "1", Convert.ToInt32(hddGroupCate.Value));

            DataView view = new DataView(table);
            view.Sort = "PostDate Desc";
            table = view.ToTable();

            dtl2.DataSource = table;
            dtl2.DataBind();
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
        private string GetCateParentIDArrayByID(int cID, int gID)
        {
            string strArrayID = Convert.ToString(cID) + ",";

            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table1 = cateNewsBSO.GetCateParentGroupAll(cID, Language.language, gID);

            if (table1.Rows.Count > 0)
            {
                foreach (DataRow subrow in table1.Rows)
                {
                    //    strArrayID += subrow["CateNewsID"].ToString() + ",";
                    strArrayID += GetCateParentIDArrayByID(Convert.ToInt32(subrow["CateNewsID"].ToString()), gID);
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
    }
}