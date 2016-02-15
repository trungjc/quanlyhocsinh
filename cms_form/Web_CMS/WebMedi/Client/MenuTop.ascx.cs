using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ETO;
using BSO;
using CMS;

namespace WebMedi.Client
{
    public partial class MenuTop : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildMenu();
        }

        public void BuildMenu()
        {
            string menu = "";
            CateNewsGroupBSO cateNewsGroupBSO = new CateNewsGroupBSO();
            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable dt = cateNewsGroupBSO.GetCateNewsGroupMenuAll();
            if (dt != null)
            {
                DataView view = new DataView(dt)
                {
                    RowFilter = "language = '" + Language.lang + "' and IsView='True'",
                    Sort = "[Order] ASC"
                };
                dt = view.ToTable();
            }
            if (dt.Rows.Count > 8)
                dt = dt.AsEnumerable().Take(8).CopyToDataTable();
            menu += "<ul class=\"nav navbar-nav\">";
            foreach (DataRow row in dt.Rows)
            {
                menu += "<li>";
                string g = row["GroupCate"].ToString();

                CateNewsGroup cateGroup = cateNewsGroupBSO.GetCateNewsGroupByGroupCate(Convert.ToInt32(g));
                DataTable dtSub = cateNewsGroupBSO.CateNewsGetByGroup(Convert.ToInt32(g));

                if (cateGroup.IsUrl == true)
                    menu += "<a href=\"" + row["Url"] + "\">";
                else
                    if (cateGroup.IsPage == true)
                        menu += "<a href=\"" + Page.ResolveUrl("FullPagesg/" + g + "/" + GetString(cateGroup.CateNewsGroupName) + "/default.aspx\">");
                    else
                        menu += "<a href=\"" + Page.ResolveUrl("FullNewsg/" + g + "/" + GetString(cateGroup.CateNewsGroupName) + "/default.aspx\">");

                if (dtSub != null && dtSub.Rows.Count > 0)
                    menu += row["CateNewsGroupName"].ToString() + "&nbsp;<span class=\"caret\"></span></a>";
                else
                    menu += row["CateNewsGroupName"].ToString() + "</a>";

                if (dtSub != null && dtSub.Rows.Count > 0)
                {
                    menu += "<ul class=\"dropdown-menu\" role=\"menu\">";
                    foreach (DataRow dr in dtSub.Rows)
                    {
                        if (Convert.ToBoolean(dr["IsUrl"].ToString()))
                            menu += "<li><a href=" + dr["Url"] + ">";
                        else
                            menu += "<li><a href=" + Page.ResolveUrl("CateNewsg/" + dr["GroupCate"] + "/" + dr["CateNewsID"] + "/" + GetString(dr["CateNewsName"]) + "/default.aspx>");
                        menu += dr["CateNewsName"].ToString() + "</a></li>";
                    }
                    menu += "</ul>";
                }
                menu += "</li>";
            }
            menu += "</ul>";
            ltrMenuFull.Text = menu;
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