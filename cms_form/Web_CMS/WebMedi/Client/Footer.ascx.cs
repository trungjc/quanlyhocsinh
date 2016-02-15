using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Data;
using CMS;

namespace WebMedi.Client
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewInfomation(Language.lang);
            BuildFooterMenu();
        }

        protected void ViewInfomation(string lang)
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(lang);
            ltrInfomation.Text = config.Infocompany;
        }

        public void BuildFooterMenu()
        {
            string menu = "";            

            CateNewsGroupBSO cateNewsGroupBSO = new CateNewsGroupBSO();
            CateNewsBSO cateNewsBSO = new CateNewsBSO();

            DataTable dt = cateNewsGroupBSO.GetCateLanguage(Language.lang);

            DataTable dtCate = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                dt = dt.Select("IsView=true and IsNew=true").CopyToDataTable();
                if (dt.Rows.Count > 4)
                    dt = dt.AsEnumerable().Take(4).CopyToDataTable();
                foreach (DataRow dr in dt.Rows)
                {
                    string g = dr["GroupCate"].ToString();
                    menu += "<div class=\"col-md-1 f-colum\"><div class=\"row title\"><a href=\"" + Page.ResolveUrl("fullnewsg/" + g + "/" + GetString(dr["CateNewsGroupName"].ToString()) + "/default.aspx\">") + dr["CateNewsGroupName"].ToString() + "</a></div>";
                    dtCate = cateNewsBSO.GetCateGroup(Language.lang, Convert.ToInt32(dr["GroupCate"].ToString()));
                    if (dtCate != null && dtCate.Rows.Count > 0)
                    {
                        foreach (DataRow drChild in dtCate.Rows)
                        {
                            string h = drChild["CateNewsId"].ToString();
                            menu += "<div class=\"row content\"> <a href=\"" + Page.ResolveUrl("catenewsg/" + g + "/" + h + "/" + GetString(drChild["CateNewsName"].ToString()) + "/default.aspx\">") + drChild["CateNewsName"].ToString() + "</a></div>";
                        }
                    }
                    menu += "</div>";
                }
                ltrMenu.Text = menu;
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