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

namespace WebMedi.Client.Modules.MainHome
{
    public partial class MainHomeListUseJCarousel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int groupCate = Convert.ToInt32(hddValue.Value);
            ViewService(groupCate);
        }

        protected void ViewService(int Group)
        {
            CateNewsBSO cate = new CateNewsBSO();
            DataTable dt = cate.GetCateGroup(Language.lang, Group);

            rptService.DataSource = dt;
            rptService.DataBind();
        }

        public string GetString(object _txt)
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