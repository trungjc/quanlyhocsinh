using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.WebControls;
using BSO;
using ETO;
using System.Data;
using System.Text;
using CMS;

namespace Fomusa.Client.Modules.Menu
{
    public partial class MenuBarTabJquery : System.Web.UI.UserControl
    {
        protected string MyTab;
        int gId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["g"]!=null)
                if (!int.TryParse(Page.RouteData.Values["g"].ToString(), out gId))
                    Response.Redirect("~/Default.aspx");


            if (!Page.IsPostBack)
            {


                BindTabStrip();
                // ViewTextMarquee();


                if (gId != 0)
                {
                    CateNewsGroupBSO categroupBSO = new CateNewsGroupBSO();
                    CateNewsGroup categroup = categroupBSO.GetCateNewsGroupByGroupCate(gId);
                    if (categroup == null)
                        Response.Redirect("~/Default.aspx");

                    if (categroup.IsMenu == true)
                    {
                        RadTabStrip1.SelectedIndex = categroup.Order - 1;
                        RadMultiPage1.SelectedIndex = categroup.Order - 1;
                    }


                }


                MyTab = RadTabStrip1.InnerMostSelectedTab.Text;

            }
        }
        private void BindTabStrip()
        {
            CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
            DataTable table = catenewsGroupBSO.GetCateNewsGroupMenuAll();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Tab rootTab = CreateRootTab(table.Rows[i]["CateNewsGroupName"].ToString(), table.Rows[i]["GroupCate"].ToString());
                PageView pv = BuildPageViewContents(Convert.ToInt32(table.Rows[i]["GroupCate"].ToString()));
                RadMultiPage1.PageViews.Add(pv);


            }
        }
        //Tab
        private Tab CreateRootTab(string index, string g)
        {
            Tab tab = new Tab();
            tab.Text = index;
            CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
            CateNewsGroup cateGroup = catenewsGroupBSO.GetCateNewsGroupByGroupCate(Convert.ToInt32(g));
            if (cateGroup.IsUrl == true)
                tab.NavigateUrl = cateGroup.Url;
            else
                //  tab.NavigateUrl = "~/Default.aspx?go=fullnewsg&g=" + g;
                if (cateGroup.IsPage == true)
                    tab.NavigateUrl = "~/FullPages/" + g + "/" + GetString(cateGroup.CateNewsGroupName) + "/default.aspx";
                else
                    tab.NavigateUrl = "~/FullNews/" + g + "/" + GetString(cateGroup.CateNewsGroupName) + "/default.aspx";

            RadTabStrip1.Tabs.Add(tab);
            return tab;
        }


        private PageView BuildPageViewContents(int gId)
        {
            PageView pageView = new PageView();


            StringBuilder returnString = new StringBuilder();
            string str = "";

            CateNewsBSO catenewsBSO = new CateNewsBSO();

            CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
            CateNewsGroup cateGroup = catenewsGroupBSO.GetCateNewsGroupByGroupCate(gId);
            if (cateGroup.IsPage == true)
                catenewsBSO.MenuJqueryCateGroupUrl(returnString, 0, Language.language, "", gId, ResolveUrl("~/") + "CategoryPages/" + gId + "/", "/default.aspx");
            else
                catenewsBSO.MenuJqueryCateGroupUrl(returnString, 0, Language.language, "", gId, ResolveUrl("~/") + "Category/" + gId + "/", "/default.aspx");

            //str = "<div id='menu'>" + returnString.ToString() + "</div>";

            str = "<div style='position:absolute;left:" + cateGroup.Position + "px;white-space: nowrap;'><div id='menu'>" + returnString.ToString() + "</div></div>";


            pageView.Controls.Add(new LiteralControl(str));


            return pageView;
        }
        //private void ViewTextMarquee()
        //{
        //    ConfigBSO configBSO = new ConfigBSO();
        //    Config config = configBSO.GetAllConfig(Language.language);

        //    ltlTextMarquee.Text = config.Intro_desc;
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