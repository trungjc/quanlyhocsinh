using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;
using System.Data;
using CMS;

namespace Fomusa.Client.Modules.MainHome
{
    public partial class MainHomeNewsActive : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (!String.IsNullOrEmpty(Request["id"]))
                int.TryParse(Request["id"], out Id);
            int groupcate = Convert.ToInt32(hddValue.Value);

            GetNewsActive(groupcate);
            //GetNewsGroupByCate(Id);

            //GetCateParentNewsGroup(gId);
            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
            string text = "<a href='" + ResolveUrl("~/") + "FullNews/" + groupcate + "/"
                + GetString(cateNewsgroupBSO.GetCateNewsGroupByGroupCate(groupcate).CateNewsGroupName) + "/default.aspx' >"
                + cateNewsgroupBSO.GetCateNewsGroupByGroupCate(groupcate).CateNewsGroupName + "</a>";
            ltlTitle.Text = text;
        }

        private void GetCateParentNewsGroup(int cId)
        {
            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table = cateNewsBSO.GetCateNewsParentAll(cId, Language.language);

            GridView1.DataSource = table;
            GridView1.DataBind();


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
                if (j < 1)
                    tableClone.ImportRow(table.Rows[j]);
                else if (j < 20)
                {
                    tblClone.ImportRow(table.Rows[j]);
                }
                else
                    break;

            }
            if (table.Rows.Count > 0)
            {
                DataListCateNews.Visible = true;
                DataListCateNews.DataSource = tableClone;
                DataListCateNews.DataBind();
            }
            else
            {
                DataListCateNews.Visible = false;
            }


            CateNewsBSO catenewsBSO = new CateNewsBSO();
            CateNews catenews = catenewsBSO.GetCateNewsById(cId);
            //HyperLinkCate.NavigateUrl = "~/Default.aspx?go=cate&Id=" + catenews.CateNewsID;


            //title_name.Text = catenews.CateNewsName;

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
            //title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            //title_cate.Text += cate;

            Page.Title = GetString(cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName);

        }

        private void GetNewsActive(int groupcate)
        {
            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
            NewsActiveBSO newsactiveBSO = new NewsActiveBSO();
            DataTable table = newsactiveBSO.GetNewsActive(groupcate, "1");
            //GridView1.DataSource = table;
            //GridView1.DataBind();
            DataView view = new DataView(table);
            view.Sort = "PostDate Desc";
            table = view.ToTable();

            DataTable tableClone = table.Clone();
            DataTable tblClone = table.Clone();
            for (int j = 0; j < table.Rows.Count; j++)
            {
                if (j < 1)
                    tableClone.ImportRow(table.Rows[j]);
                else if (j < 20)
                {
                    tblClone.ImportRow(table.Rows[j]);
                }
                else
                    break;

            }
            if (table.Rows.Count > 0)
            {
                DataListCateNews.Visible = true;
                DataListCateNews.DataSource = tableClone;
                DataListCateNews.DataBind();
                GridView1.DataSource = tblClone;
                GridView1.DataBind();
            }

            else
            {
                DataListCateNews.Visible = false;
            }

            //CateNewsBSO catenewsBSO = new CateNewsBSO();
            //CateNews catenews = catenewsBSO.GetCateNewsById(cId);
            ////HyperLinkCate.NavigateUrl = "~/Default.aspx?go=cate&Id=" + catenews.CateNewsID;


            ////title_name.Text = catenews.CateNewsName;

            ////    Label1.Text = "<div class='gt_title'> <div class='title_article_top'>" + Literal1.Text + "</div><div class='title_article_bg'></div></div>";

            //string cate = "<a href='" + ResolveUrl("~/") + "FullNews/" + catenews.GroupCate + "/" + GetString(cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName) + ".aspx' class='content_Text_Cat'>";
            //string s1 = "";
            //while (catenews.ParentNewsID != 0)
            //{
            //    int pId = catenews.ParentNewsID;
            //    catenews = catenewsBSO.GetCateNewsById(pId);
            //    s1 = "<a href='" + ResolveUrl("~/") + "Category/" + catenews.GroupCate + "/" + catenews.CateNewsID + "/" + GetString(catenews.CateNewsName) + ".aspx' class='content_Text_Cat'>" + catenews.CateNewsName + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;" + s1;
            //}

            //cate += cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName.ToUpper(); //Sửa lại
            //cate += "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>";
            //cate += s1;
            ////title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            ////title_cate.Text += cate;

            //Page.Title = "Thủy điện Sơn La : " + GetString(cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName);


            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table1 = cateNewsBSO.getCateClientGroup(0, Language.language, Convert.ToInt32(hddValue.Value), 3);


            rptCateNews.DataSource = table1;
            rptCateNews.DataBind();
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
            //   FullNewsGet(Language.language);
        }
        protected void DataListCateNews_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string Imgthumb = DataBinder.Eval(e.Item.DataItem, "ImageThumb").ToString();
            Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlImageThumb");
            if (Imgthumb != "")
                ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "admin/Upload/NewsGroup/NewsGroupThumb/" + Imgthumb + "' align='left' class='border_image' width='140' >";
        }
    }
}