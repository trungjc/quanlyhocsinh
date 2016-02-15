using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using CMS;
using ETO;

namespace Web_NLDC.Client
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo(Language.lang);
                LoadMenuBottom(Language.lang);
            }
        }

        protected void LoadInfo(string lang)
        {
            var configBso = new ConfigBSO();
            var config = configBso.GetAllConfig(lang);
            ltrFooter.Text = config.Infocompany;
        }

        protected void LoadMenuBottom(string lang)
        {
            var menuBottom = "";
            // b1: Load menu cấp 1
            var parentMenu = new CateNewsGroupBSO();
            var dtParent = parentMenu.GetCateLanguage(lang);
            if (dtParent != null && dtParent.Rows.Count > 0)
            {
                dtParent = dtParent.Select("IsView=true and IsNew=true").CopyToDataTable();
                if (dtParent.Rows.Count > 4)
                    dtParent = dtParent.AsEnumerable().Take(4).CopyToDataTable();
                foreach (DataRow dr in dtParent.Rows)
                {
                    var g = dr["GroupCate"].ToString();

                    menuBottom += "<div class=\"col-md-3\"><div class=\"row\">";
                    if (Convert.ToBoolean(dr["IsUrl"]))
                        menuBottom += "<a href=\"" + dr["Url"] + "\" target=\"_blank\">";
                    else
                        if (Convert.ToBoolean(dr["IsPage"]))
                            menuBottom += "<a href=\"" + Page.ResolveUrl("FullPagesg/" + g + "/" + GetString(dr["CateNewsGroupName"]) + "/default.aspx\">");
                        else
                            menuBottom += "<a href=\"" + Page.ResolveUrl("FullNewsg/" + g + "/" + GetString(dr["CateNewsGroupName"]) + "/default.aspx\">");

                    menuBottom += "<img src=\"ImageHandler.aspx?image=Admin/Upload/Category/Group/" + dr["Icon"] + "\" alt=\"\" width=27 /><span><b>" + dr["CateNewsGroupName"] + "  </b></span></a></div>";
                    // B2: Load menu cấp 2 từ id của menu cấp 1
                    var childMenu = new CateNewsBSO();
                    var dtChild = childMenu.GetCateGroup(lang, Convert.ToInt32(dr["GroupCate"]));
                    if (dtChild != null && dtChild.Rows.Count > 0)
                    {
                        dtChild = dtChild.Select("ParentNewsID=0").CopyToDataTable();
                        menuBottom += "<div class=\"row list-new-footter\"><ul>";
                        foreach (DataRow drChild in dtChild.Rows)
                        {
                            var h = drChild["CateNewsID"].ToString();
                            menuBottom += "<li><a href=\"" + Page.ResolveUrl("~/CateNewsg/" + g + "/" + h + "/" + GetString(drChild["CateNewsName"]) + "/default.aspx\">") + drChild["CateNewsName"] + "</a></li>";
                        }
                        menuBottom += "</ul></div>";
                    }
                    menuBottom += "</div>";
                }

                ltrMenuBottom.Text = menuBottom;
            }
        }

        protected string GetString(object txt)
        {
            if (txt != null)
            {
                var objUtil = new Utils();
                return objUtil.Getstring(txt.ToString());
            }
            return "";
        }
    }
}