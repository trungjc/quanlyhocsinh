using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS;
using BSO;
using System.Data;
using ETO;

namespace Fomusa.Client
{
    public partial class BannerMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
                CateNewsBSO cateNewsBSO = new CateNewsBSO();
                DataTable table = catenewsGroupBSO.GetCateNewsGroupMenuAll();
                if (table != null)
                {
                    DataView view = new DataView(table)
                    {
                        RowFilter = "language = '" + Language.lang + "'",
                        Sort = "[Order] ASC"
                    };
                    table = view.ToTable();
                }
                string menuItemText = "<ul id=topnav>";
                foreach (DataRow row in table.Rows)
                {
                    //menuItemText = row["CateNewsGroupName"].ToString();
                    menuItemText += "<li>";
                    string g = row["GroupCate"].ToString();
                    CateNewsGroup cateGroup = catenewsGroupBSO.GetCateNewsGroupByGroupCate(Convert.ToInt32(g));
                    if (cateGroup.IsUrl == true)
                        menuItemText += "<a class=bannermenuitem href=" + cateGroup.Url;
                    else
                        if (cateGroup.IsPage == true)
                            menuItemText += "<a class=bannermenuitem href=" + Page.ResolveUrl("FullPages/" + g + "/" + GetString(cateGroup.CateNewsGroupName) + "/default.aspx>");
                        else
                            menuItemText += "<a class=bannermenuitem href=" + Page.ResolveUrl("FullNews/" + g + "/" + GetString(cateGroup.CateNewsGroupName) + "/default.aspx>");
                    menuItemText += row["CateNewsGroupName"].ToString() + "</a>";

                    DataTable dtSub = catenewsGroupBSO.CateNewsGetByGroup(Convert.ToInt32(g));
                    if (dtSub != null && dtSub.Rows.Count > 0)
                    {
                        menuItemText += "<ul>";
                        foreach (DataRow dr in dtSub.Rows)
                        {
                            if (Convert.ToBoolean(dr["IsUrl"].ToString()))
                                menuItemText += "<li><a class=bannermenuitem href='" + dr["Url"] + "'>";
                            else
                                menuItemText += "<li><a class=bannermenuitem href=" + Page.ResolveUrl("Category/" + dr["GroupCate"] + "/" + dr["CateNewsID"] + "/" + GetString(dr["CateNewsName"]) + "/default.aspx>");
                            menuItemText += dr["CateNewsName"].ToString() + "</a></li>";
                        }
                        menuItemText += "</ul>";
                    }
                    menuItemText += "</li>";
                }
                menuItemText += "</ull>";
                menuItem.Text = menuItemText;
            }
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