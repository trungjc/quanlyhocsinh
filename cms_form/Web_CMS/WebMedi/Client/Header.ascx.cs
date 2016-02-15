using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;

namespace WebMedi.Client
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitValue(Language.lang);
        }

        protected void InitValue(string lang)
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(lang);
            ltrCallCenter.Text = config.Info1;
            ltrLogo.Text = config.Info2;

            if (lang == Language.language)
                imgFlag.ImageUrl = "~/Img/flag-en.png";
            else if (lang == Language.language_Eng)
                imgFlag.ImageUrl = "~/Img/flag-vn.png";
        }

        protected void lbLang_Click(object sender, EventArgs e)
        {
            if (Session["Lang"].ToString() == Language.language)
            {
                Session["Lang"] = Language.language_Eng;
                Response.Redirect(ResolveUrl("~/") + "home");
            }
            else
            {
                Session["Lang"] = Language.language;
                Response.Redirect(ResolveUrl("~/") + "home");
            }
        }
    }
}