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
    public partial class ListPageComment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            string group = "";
            if (!String.IsNullOrEmpty(Page.RouteData.Values["group"].ToString()))
                group = Page.RouteData.Values["group"].ToString();

            hddGroup.Value = group;

            int Id = -1;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);
            hddPageID.Value = Convert.ToString(Id);

            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
            {
                btn_editpage.Visible = true;

                btn_delall.Visible = true;

            }
            else
            {
                btn_editpage.Visible = false;

                btn_delall.Visible = false;
            }

            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
            {
                btn_enable.Visible = true;
                btn_disable.Visible = true;

            }
            else
            {
                btn_enable.Visible = false;
                btn_disable.Visible = false;
            }

            if (!IsPostBack)
                PageCommentView(group);
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
        protected void grvPageComment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string cName = e.CommandName.ToLower();
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            switch (cName)
            {
                case "_view":
                    break;
                case "_edit":
                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        Response.Redirect("~/Admin/editpagecomment/" + Id + "/Default.aspx");

                    }
                    else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnews");
                    }

                    break;
                case "_delete":
                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        PageCommentBSO pageCommentBSO = new PageCommentBSO();
                        pageCommentBSO.DeletePageComment(Id);
                        PageCommentView(hddGroup.Value);

                    }
                    else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnews");
                    }

                    break;
            }
        }
        protected void grvPageComment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                //     image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");
                ImageButton image_edit = (ImageButton)e.Row.FindControl("btn_edit");

                AdminBSO adminBSO = new AdminBSO();
                ETO.Admin admin = new ETO.Admin();
                admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                {
                    image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
                }
                else
                {
                    image_edit.Attributes.Add("onclick", "javascript:return confirm('Bạn không có đủ quyền ???');");
                    image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn không có đủ quyền ???');");
                }
            }
        }

        #region PageCommentView
        protected void PageCommentView(string group)
        {
            PageCommentBSO pageCommentBSO = new PageCommentBSO();
            DataTable table = new DataTable();
            table = pageCommentBSO.GetAllGroupCateViewPageComment(group);


            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvPageComment, table);
        }
        #endregion

        #region PageCommentID
        private string PageCommentID()
        {
            string pageCommentId = "";
            foreach (GridViewRow rows in grvPageComment.Rows)
            {
                CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
                if (checkbox.Checked)
                    pageCommentId += rows.Cells[0].Text + ",";
            }
            return pageCommentId;
        }

        #endregion

        protected void grvPageComment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPageComment.PageIndex = e.NewPageIndex;
            PageCommentView(hddGroup.Value);
        }
        protected void btn_enable_Click(object sender, EventArgs e)
        {
            if (PageCommentID() != "")
            {
                PageCommentBSO pageCommentBSO = new PageCommentBSO();
                pageCommentBSO.UpdatePageComment(PageCommentID(), "1");
            }
            PageCommentView(hddGroup.Value);
        }
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            if (PageCommentID() != "")
            {
                PageCommentBSO pageCommentBSO = new PageCommentBSO();
                pageCommentBSO.UpdatePageComment(PageCommentID(), "0");
            }
            PageCommentView(hddGroup.Value);
        }


        protected void btn_delAll_Click(object sender, EventArgs e)
        {
            if (PageCommentID() != "")
            {
                PageCommentBSO pageCommentBSO = new PageCommentBSO();
                pageCommentBSO.DeletePageComment(PageCommentID());
            }
            PageCommentView(hddGroup.Value);
        }

        protected void btn_list(object sender, EventArgs e)
        {

            Response.Redirect("~/Admin/Group/listpage/" + hddGroup.Value + "/Default.aspx");

        }
        protected void btn_editcomment(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/editpagecomment/" + hddGroup.Value + "/Default.aspx");

        }

    }
}