using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BSO;
using CMS;
using ETO;

namespace Fomusa.Client.Modules.Official
{
    public partial class OfficialListGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int gId = 0;
            if (Page.RouteData.Values["g"]!=null)
                int.TryParse(Page.RouteData.Values["g"].ToString(), out gId);

            hddGroupCate.Value = Convert.ToString(gId);


            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> <img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>";
            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();

            title_name.Text = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(gId).CateNewsGroupName;

            if (!IsPostBack)
            {
                GetCateParentNews(0, gId);
            }
            Page.Title = GetString(title_name.Text);
        }
        private void GetCateParentNews(int cId, int group)
        {
            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table = cateNewsBSO.GetCateParentGroupAll(cId, Language.language, group);

            DataList1.DataSource = table;
            DataList1.DataBind();


        }
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView dtl2 = (GridView)e.Item.FindControl("GridView1");

            int cateId;
            int.TryParse(DataBinder.Eval(e.Item.DataItem, "CateNewsID").ToString(), out cateId);

            string strCate = GetCateParentIDArrayByID(cateId);

            OfficialBSO officeBSO = new OfficialBSO();
            DataTable table = officeBSO.GetOfficialByCateHomeList(strCate, 5, "1");

            dtl2.DataSource = table;
            dtl2.DataBind();
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

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string Imgthumb = DataBinder.Eval(e.Item.DataItem, "ImageThumb").ToString();
            Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlImageThumb");
            if (Imgthumb != "")
                ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Admin/Upload/NewsGroup/NewsGroupThumb/" + Imgthumb + "' class='border_image' width='140' align='left'>";
            //else
            //    ltlImageThumb.Text = @"<img src='images/image_demo.jpg' align='left' class='border_image_pro' width='70'>";
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            gv.DataBind();
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