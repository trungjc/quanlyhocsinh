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
    public partial class listmember : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
                ViewMember();
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

        #region ViewMember
        protected void ViewMember()
        {
            MemberBSO memberBSO = new MemberBSO();
            DataTable table = memberBSO.GetAllMember();

            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvMember, table);
        }
        #endregion

        protected void grvMember_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn chắc chắn muốn xóa ??');");

            }
        }
        protected void grvMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string aId = e.CommandArgument.ToString();
            string aName = e.CommandName.ToLower();
            switch (aName)
            {
                case "view":
                    Response.Redirect("~/Admin/listorder/" + aId + "/Default.aspx");
                    break;
                case "edit":
                    Response.Redirect("~/Admin/editmember/" + aId + "/Default.aspx");
                    break;
                case "delete":
                    MemberBSO memberBSO = new MemberBSO();
                    memberBSO.DeleteMember(aId);
                    ViewMember();
                    break;
            }
        }
        protected void grvMember_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

    }
}