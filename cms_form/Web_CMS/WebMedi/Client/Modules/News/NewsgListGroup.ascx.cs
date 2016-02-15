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

namespace WebMedi.Client.Modules.News
{
    public partial class NewsgListGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int gId = Convert.ToInt32(Page.RouteData.Values["Id"].ToString());
            int gId = 0;
            if (!String.IsNullOrEmpty(Page.RouteData.Values["g"].ToString()))
                int.TryParse(Page.RouteData.Values["g"].ToString(), out gId);

            hddGroupCate.Value = Convert.ToString(gId);
            if (!IsPostBack)
            {
                GetCateParentNewsGroup(0, gId);
            }
            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>"+Resources.Resource.Home+"</a> &nbsp;>&nbsp;" + cateNewsgroupBSO.GetCateNewsGroupByGroupCate(gId).CateNewsGroupName;
            
            //title_name.Text = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(gId).CateNewsGroupName;

            //Page.Title = "" + GetString(title_name.Text);
        }
        private void GetCateParentNewsGroup(int cId, int gId)
        {
            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table = cateNewsBSO.GetCateParentGroupAll(cId, Language.language, gId);

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

            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            DataTable table = newsgroupBSO.GetNewsGroupByCateHomeList(strCate, 5, "1", Convert.ToInt32(hddGroupCate.Value));

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
                ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Upload/NewsGroup/NewsGroupThumb/" + Imgthumb + "' class='border_image' width='140' align='left'>";
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