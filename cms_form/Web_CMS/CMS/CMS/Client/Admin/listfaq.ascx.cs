using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Data;

namespace CMS.Client.Admin
{
    public partial class listfaq : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
                ViewFaq();

        }

        #region NavigationTitle
        private void NavigationTitle(string url)
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            Modules modules = modulesBSO.GetModulesByUrl(url);
            imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }
        #endregion

        #region ViewFaq
        private void ViewFaq()
        {
            FaqBSO faqBSO = new FaqBSO();
            DataTable table = faqBSO.GetFaqAll(Language.language);
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvFaq, table);
        }
        #endregion

        protected void grvFaq_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string cName = e.CommandName.ToLower();
            switch (cName)
            {
                case "_edit":
                    Response.Redirect("~/Admin/editfaq/" + Id + "/Default.aspx");
                    break;
                case "_delete":
                    FaqBSO faqBSO = new FaqBSO();
                    faqBSO.DeleteFaq(Id);
                    ViewFaq();
                    break;
            }
        }
        protected void grvFaq_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");

            }
        }
        protected void btn_Order_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in grvFaq.Rows)
            {
                TextBox textOrder = (TextBox)row.FindControl("txtFaqOrder");
                int cOrder = Convert.ToInt32(textOrder.Text);
                int faqID = Convert.ToInt32(row.Cells[0].Text);
                FaqBSO faqBSO = new FaqBSO();
                faqBSO.FaqUpOrder(faqID, cOrder);
            }
            ViewFaq();
        }

    }
}