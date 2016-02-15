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

namespace Fomusa.Client.Modules.Company
{
    public partial class CompanyDetailGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (!String.IsNullOrEmpty(Request["Id"]))
                int.TryParse(Request["Id"], out Id);

            int gId = 0;
            if (!String.IsNullOrEmpty(Request["g"]))
                if (!int.TryParse(Request["g"].Replace(",", ""), out gId))
                    Response.Redirect("~/Default.aspx");

            hddGroupCate.Value = Convert.ToString(gId);
            if (!IsPostBack)
                ViewCompanyDetail(Id, gId);

            title_cate.Text = CateNavigator();

            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
            CateNewsGroup cateGroup = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(gId);
            title_name.Text = cateGroup.CateNewsGroupName;
            Page.Title = GetString(cateGroup.CateNewsGroupName);
        }
        private string CateNavigator()
        {
            string url = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            return url;
        }
        private void ViewCompanyDetail(int Id, int gId)
        {
            CompanyBSO companyBSO = new CompanyBSO();
            ETO.Company company = companyBSO.GetCompanyById(Id);
            ltlTitle.Text = company.Title;
            ltlDescribe.Text = company.Description;
            LabelAuthor.Text = company.Author;

            CompanyFollow(company.CompanyID, company.Categories, gId);


        }
        private void CompanyFollow(int Id, int cId, int gId)
        {
            CompanyBSO companyBSO = new CompanyBSO();
            DataTable table = companyBSO.CompanyFollow(Id, cId, 10, gId);
            if (table.Rows.Count > 0)
                Label1.Text = "<div class='gt_title'> <div class='title_article_top'>Các tin khác</div></div>";
            else
                Label1.Text = "";
            DataListNews.DataSource = table;
            DataListNews.DataBind();
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