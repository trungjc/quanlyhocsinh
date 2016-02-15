using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS;
using BSO;
using ETO;
using System.Data;

namespace Fomusa.Client.Modules.Official
{
    public partial class OfficialDetail : System.Web.UI.UserControl
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
                ViewDetailOfficial(Id);
                ViewNavigator(Id);
                hddID.Value = Convert.ToString(Id);
            }
        }

        private void ViewDetailOfficial(int Id)
        {
            OfficialBSO officialBSO = new OfficialBSO();
            ETO.Official official = officialBSO.GetOfficialById(Id);
            litNoCode.Text = official.NoCode;
            litOfficialName.Text = official.OfficialName;
            litDatePublic.Text = official.DatePublic.ToString("dd/MM/yyyy");// Convert.ToString(official.DatePublic);
            litCompany.Text = official.Company;
            litClassify.Text = official.Classify;
            litWriter.Text = official.Writer;
            litQuote.Text = official.Quote;
            litKeyShort.Text = official.KeyShort;
            if (official.Attached != "")
            {
                litAttached.Text = "<a href='" + ResolveUrl("~/") + "Admin/Upload/Files/" + official.Attached + "'>Tải về</a>";
            }

            OfficialFileBSO officialFileBSO = new OfficialFileBSO();
            DataTable tableFile = officialFileBSO.GetOfficialFileByOfficial(official.OfficialID);
            if (tableFile.Rows.Count > 0)
            {
                Repeater1.DataSource = tableFile;
                Repeater1.DataBind();
            }


            OfficialFollow(official.OfficialID, official.CateOfficialID);
            //Page.Title = "Thủy điện Sơn La : " + GetString(official.OfficialName);
            Page.Title = GetString(official.OfficialName);
        }

        private void ViewNavigator(int Id)
        {
            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
            OfficialBSO officialBSO = new OfficialBSO();
            ETO.Official official = officialBSO.GetOfficialById(Id);

            CateNewsBSO catenewsBSO = new CateNewsBSO();
            CateNews catenews = catenewsBSO.GetCateNewsById(official.CateOfficialID);
            //HyperLinkCate.NavigateUrl = "~/Default.aspx?go=cate&Id=" + catenews.CateNewsID;
            title_name.Text = "<a href='" + ResolveUrl("~/") + "Category/" + catenews.GroupCate + "/" + catenews.CateNewsID + "/" + GetString(catenews.CateNewsName) + "/default.aspx'>" + catenews.CateNewsName + "</a>";

            string cate = "<a href='" + ResolveUrl("~/") + "FullNews/" + catenews.GroupCate + "/" + GetString(cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName) + "/default.aspx' class='content_Text_Cat'>";
            string s1 = "";
            while (catenews.ParentNewsID != 0)
            {
                int pId = catenews.ParentNewsID;
                catenews = catenewsBSO.GetCateNewsById(pId);
                s1 = "<a href='" + ResolveUrl("~/") + "Category/" + catenews.GroupCate + "/" + catenews.CateNewsID + "/" + GetString(catenews.CateNewsName) + "/default.aspx' class='content_Text_Cat'>" + catenews.CateNewsName + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png' > &nbsp;" + s1;
            }

            cate += cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate).CateNewsGroupName.ToUpper(); //Sửa lại
            cate += "</a>&nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png' >";
            cate += s1;
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a>&nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            title_cate.Text += cate;
        }

        private void OfficialFollow(int Id, int cId)
        {
            OfficialBSO officialBSO = new OfficialBSO();
            DataTable table = officialBSO.OfficialFollow(Id, cId, "1");
            if (table.Rows.Count > 0)
                Label1.Text = "<div class='gt_title'> <div class='title_article_top'>Các văn bản khác</div></div>";
            else
                Label1.Text = "";

            GridView1.DataSource = table;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            OfficialBSO officialBSO = new OfficialBSO();
            ETO.Official official = officialBSO.GetOfficialById(Convert.ToInt32(hddID.Value));
            OfficialFollow(official.OfficialID, official.CateOfficialID);
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