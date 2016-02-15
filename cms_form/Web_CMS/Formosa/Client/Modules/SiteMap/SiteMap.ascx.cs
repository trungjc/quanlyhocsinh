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

namespace Fomusa.Client.Modules.SiteMap
{
    public partial class SiteMap : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ngonngu = Session["Lang"].ToString();
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a>  &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            GetCateNewsGroup(ngonngu);
        }

        private void GetCateNewsGroup(string _ngonNgu)
        {
            CateNewsGroupBSO cateNewsGroupBSO = new CateNewsGroupBSO();
            //DataTable table = cateNewsGroupBSO.GetCateNewsGroupAll();
            DataTable table = cateNewsGroupBSO.GetCateLanguage(_ngonNgu);

            DataList1.DataSource = table;
            DataList1.DataBind();
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //DataList dtl2 = (DataList)e.Item.FindControl("DataList2");

            int gId;
            int.TryParse(DataBinder.Eval(e.Item.DataItem, "GroupCate").ToString(), out gId);

            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table1 = cateNewsBSO.GetCateGroupBullet(Language.language, gId, "icon_18.png");


            Repeater rptCate = (Repeater)e.Item.FindControl("rptnewsg");
            rptCate.DataSource = table1;
            rptCate.DataBind();

        }


        //private void ViewLabel()
        //{
        //    CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();

        //    lblGroup1.Text = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(1).CateNewsGroupName;
        //    lblGroup2.Text = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(2).CateNewsGroupName;
        //    lblGroup3.Text = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(3).CateNewsGroupName;
        //    lblGroup4.Text = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(4).CateNewsGroupName;
        //    lblGroup5.Text = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(5).CateNewsGroupName;
        //    lblGroup6.Text = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(6).CateNewsGroupName;
        //    lblGroup7.Text = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(7).CateNewsGroupName;
        //}
        //private void ListMenuLinks()
        //{
        //    MenuLinksBSO menulinksBSO = new MenuLinksBSO();
        //    DataTable table = menulinksBSO.MixMenuLinksBullet("icon_18.png");
        //    DataView dataView = new DataView(table);
        //    dataView.RowFilter = "Status = true";

        //    rptMenuLinks.DataSource = dataView;
        //    rptMenuLinks.DataBind();
        //}
        //private DataTable ViewCateGroup(int group)
        //{
        //    CateNewsBSO catenewsBSO = new CateNewsBSO();
        //    DataTable table = catenewsBSO.GetCateGroupBullet(Language.language, group,"icon_18.png");


        //    return table;

        //}
        //private void BindRepeater(Repeater repeater, DataTable table1)
        //{
        //    repeater.DataSource = table1;
        //    repeater.DataBind();
        //}

        //private DataTable ViewMenuGroup1(string group)
        //{
        //    PagesBSO pagesBSO = new PagesBSO();

        //    DataTable table1 = pagesBSO.PageGetGroup(group, Language.language);
        //    return table1;

        //}

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