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
    public partial class listpage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
            {
                btn_editpage.Visible = true;
                btn_enable.Visible = true;
                btn_disable.Visible = true;
                btn_delall.Visible = true;

            }
            else
            {
                btn_editpage.Visible = false;
                btn_enable.Visible = false;
                btn_disable.Visible = false;
                btn_delall.Visible = false;
            }

            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
            {
                btn_enable_approval.Visible = true;
                btn_disable_approval.Visible = true;

            }
            else
            {
                btn_enable_approval.Visible = false;
                btn_disable_approval.Visible = false;
            }


            if (!IsPostBack)
            {
                string group = "1";
                PagesView(group);
                hddGroup.Value = group;
            }
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
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
                        Response.Redirect("~/Admin/editpage/" + Id + "/Default.aspx");

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
                        PagesBSO pagesBSO = new PagesBSO();
                        pagesBSO.DeletePages(Id);
                        PagesView(hddGroup.Value);

                    }
                    else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnews");
                    }

                    break;
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                //    image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");

                ImageButton image_view = (ImageButton)e.Row.FindControl("btn_view");
                image_view.Attributes.Add("onclick", "javascript:window.open('~/Client/Admin/ViewPage.aspx?Id=" + DataBinder.Eval(e.Row.DataItem, "PageID") + "','_blank','width=800,height=600');");

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

        #region PagesView
        protected void PagesView(string group)
        {
            PagesBSO pagesBSO = new PagesBSO();
            DataTable table = new DataTable();

            if (!Session["Admin_UserName"].Equals("administrator"))
            {
                table = pagesBSO.PagesSearchCate(group, Language.language);
            }
            else
            {
                table = pagesBSO.PagesSearchCate(group, Language.language);
            }


            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvPages, table);
        }
        #endregion

        #region PagesID
        private string PagesID()
        {
            string pagesId = "";
            foreach (GridViewRow rows in grvPages.Rows)
            {
                CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
                if (checkbox.Checked)
                    pagesId += rows.Cells[0].Text + ",";
            }
            return pagesId;
        }

        #endregion

        protected void grvPages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPages.PageIndex = e.NewPageIndex;
            PagesView(hddGroup.Value);
        }
        protected void btn_enable_Click(object sender, EventArgs e)
        {
            if (PagesID() != "")
            {
                PagesBSO pagesBSO = new PagesBSO();
                pagesBSO.PagesUpdate(PagesID(), "1");
            }
            PagesView(hddGroup.Value);
        }
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            if (PagesID() != "")
            {
                PagesBSO pagesBSO = new PagesBSO();
                pagesBSO.PagesUpdate(PagesID(), "0");
            }

            PagesView(hddGroup.Value);
        }

        protected void btn_enable_approval_Click(object sender, EventArgs e)
        {
            if (PagesID() != "")
            {
                PagesBSO pagesBSO = new PagesBSO();
                pagesBSO.PagesUpdate(PagesID(), "1", Session["Admin_UserName"].ToString(), DateTime.Now);
            }

            PagesView(hddGroup.Value);

        }
        protected void btn_disable_approval_Click(object sender, EventArgs e)
        {
            if (PagesID() != "")
            {
                PagesBSO pagesBSO = new PagesBSO();
                pagesBSO.PagesUpdate(PagesID(), "0", Session["Admin_UserName"].ToString(), DateTime.Now);
            }

            PagesView(hddGroup.Value);
        }
        protected void btn_delAll_Click(object sender, EventArgs e)
        {
            if (PagesID() != "")
            {
                PagesBSO pagesBSO = new PagesBSO();
                pagesBSO.DeletePages(PagesID());
            }
            PagesView(hddGroup.Value);
        }
        //protected void btn_search_Click(object sender, EventArgs e)
        //{
        //    if (txtKeyword.Text != "")
        //    {
        //        PagesBSO pagesBSO = new PagesBSO();
        //        string cId = ddlCatePageSearch.SelectedValue;
        //        DataTable table = pagesBSO.PagesSearch(txtKeyword.Text, cId, Language.language);
        //        commonBSO commonBSO = new commonBSO();
        //        commonBSO.FillToGridView(grvPages, table);
        //    }
        //    else
        //    {
        //        PagesBSO pagesBSO = new PagesBSO();
        //        string cId = ddlCatePageSearch.SelectedValue;
        //        DataTable table = pagesBSO.PagesSearchCate(cId, Language.language);
        //        commonBSO commonBSO = new commonBSO();
        //        commonBSO.FillToGridView(grvPages, table);
        //    }

        //}
        protected void rdbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = rdbGroup.SelectedValue;
            PagesView(value);
            hddGroup.Value = value;
        }
        protected void btn_list(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/listpagecomment/" + hddGroup.Value + "/Default.aspx");

        }

    }
}