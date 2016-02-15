using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Data;

namespace WebMedi.Client
{
    public partial class ListServices : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewService(10);
        }

        protected void ViewService(int Group)
        {
            CateNewsBSO cate = new CateNewsBSO();
            DataTable dt = cate.GetCateGroup(Session["Lang"].ToString(), Group);

            rptService.DataSource = dt;
            rptService.DataBind();
        }
    }
}