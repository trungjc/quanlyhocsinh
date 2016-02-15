using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;
using CMS;
using System.Data;

namespace Fomusa.Client
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewCopy(Language.lang);
            HttpCookie cookie = Request.Cookies["UserInfor_EVNTIT"];
            if (cookie != null && cookie["UserName"] != null && cookie["UserName"].Trim() != string.Empty)
            {
                lblLogin.Visible = true;

            }
            else
            {
                lblLogin.Visible = false;
                lblLogin.Text = "Đăng nhập";
            }
            BuildFooterMenu();
        }
        private void ViewCopy(string lang)
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(lang);
            ltlFooter.Text = config.Infocompany;
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
        public void BuildFooterMenu()
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
                foreach (DataRow row in table.Rows)
                {
                    string footerMenuItemText = "";
                    //menuItemText = row["CateNewsGroupName"].ToString();

                    string g = row["GroupCate"].ToString();
                    CateNewsGroup cateGroup = catenewsGroupBSO.GetCateNewsGroupByGroupCate(Convert.ToInt32(g));
                    if (cateGroup.IsUrl == true)
                        footerMenuItemText = "<a class=bannermenuitem href=" + cateGroup.Url;
                    else
                        if (cateGroup.IsPage == true)
                            footerMenuItemText = "<a class=bannermenuitem href=" + Page.ResolveUrl("FullPages/" + g + "/" + GetString(cateGroup.CateNewsGroupName) + "/default.aspx>");
                        else
                            footerMenuItemText = "<a class=bannermenuitem href=" + Page.ResolveUrl("FullNews/" + g + "/" + GetString(cateGroup.CateNewsGroupName) + "/default.aspx>");
                    footerMenuItemText += row["CateNewsGroupName"].ToString() + "</a>";
                    footerMenuItem.Text += footerMenuItemText;
                }
            }
        }
    }
}