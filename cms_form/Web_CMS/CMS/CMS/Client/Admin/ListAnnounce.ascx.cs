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
    public partial class ListAnnounce : System.Web.UI.UserControl
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
                ViewAnnounce();
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

        #region ViewAnnounce
        private void ViewAnnounce()
        {
            int group = 3;
            AnnounceBSO announceBSO = new AnnounceBSO();
            DataTable table = new DataTable();

            if (!Session["Admin_UserName"].Equals("administrator"))
            {
                string strCate = GetCateParentIDArrayByID(group);
                if (strCate != "")
                    table = announceBSO.GetAnnounceByCateHomeList(strCate);
            }
            else
            {
                table = announceBSO.GetAnnounceAll(Language.language);
            }


            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvAnnounce, table);
            BindCateSearch(group);
        }
        #endregion

        private string GetCateParentIDArrayByID(int group)
        {
            string strArrayID = "";

            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table1 = cateNewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());

            if (table1.Rows.Count > 0)
            {
                foreach (DataRow subrow in table1.Rows)
                {
                    strArrayID += subrow["CateNewsID"].ToString() + ",";
                    // strArrayID += GetCateParentIDArrayByID(Convert.ToInt32(subrow["CateNewsID"].ToString()));
                }

            }

            return strArrayID;

        }

        //#region BindCateSearch
        //private void BindCateSearch()
        //{
        //    ddlCateAnnounceSearch.Items.Clear();
        //    CateNewsBSO catenewsBSO = new CateNewsBSO();
        //    DataTable table = catenewsBSO.GetCateNews(Language.language);
        //    DataView dataView = new DataView(table);
        //    dataView.RowFilter = "GroupCate = 3";
        //    ddlCateAnnounceSearch.DataSource = dataView;
        //    ddlCateAnnounceSearch.DataTextField = "CateNewsName";
        //    ddlCateAnnounceSearch.DataValueField = "CateNewsID";
        //    ddlCateAnnounceSearch.Items.Add(new ListItem("~~~ Trong tat ca ~~~", "0"));
        //    ddlCateAnnounceSearch.DataBind();
        //    //CateNewsBSO catenewsBSO = new CateNewsBSO();
        //    //DataTable datatable = catenewsBSO.GetCateAnnounce(Language.language);
        //    //commonBSO commonBSO = new commonBSO();
        //    //commonBSO.FillToDropDown(ddlCateAnnounceSearch, datatable, "~~ Trong tất cả ~~", "0", "CateAnnounceName", "CateAnnounceID", "");
        //}
        //#endregion

        #region BindCateSearch
        private void BindCateSearch(int group)
        {
            ddlCateAnnounceSearch.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateAnnounceSearch, table, "~~ Trong tất cả ~~", "0", "CateNewsName", "CateNewsID", "");
        }
        #endregion

        #region AnnounceID
        private string AnnounceID()
        {
            string announceId = "";
            foreach (GridViewRow rows in grvAnnounce.Rows)
            {
                CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
                if (checkbox.Checked)
                    announceId += rows.Cells[0].Text + ",";
            }
            return announceId;
        }

        #endregion

        protected void grvAnnounce_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string nName = e.CommandName.ToLower();
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            switch (nName)
            {
                case "_view":
                    break;
                case "_edit":
                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        Response.Redirect("~/Admin/editannounce/" + Id + "/Default.aspx");

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
                        AnnounceBSO announceBSO = new AnnounceBSO();
                        announceBSO.DeleteAnnounce(Id);
                        ViewAnnounce();

                    }
                    else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnews");
                    }

                    break;
            }
        }
        protected void grvAnnounce_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                //      image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");

                ImageButton image_view = (ImageButton)e.Row.FindControl("btn_view");
                image_view.Attributes.Add("onclick", "javascript:window.open('~/Client/Admin/ViewAnnounce.aspx?Id=" + DataBinder.Eval(e.Row.DataItem, "AnnounceID") + "','_blank','width=800,height=600');");

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
        protected void grvAnnounce_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAnnounce.PageIndex = e.NewPageIndex;
            ViewAnnounce();
        }
        protected void btn_enable_Click(object sender, EventArgs e)
        {
            if (AnnounceID() != "")
            {
                AnnounceBSO announceBSO = new AnnounceBSO();
                announceBSO.UpdateAnnounce(AnnounceID(), "1");
            }
            ViewAnnounce();
        }
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            if (AnnounceID() != "")
            {
                AnnounceBSO announceBSO = new AnnounceBSO();
                announceBSO.UpdateAnnounce(AnnounceID(), "0");
            }
            ViewAnnounce();
        }
        protected void btn_enable_approval_Click(object sender, EventArgs e)
        {
            if (AnnounceID() != "")
            {
                AnnounceBSO announceBSO = new AnnounceBSO();
                announceBSO.UpdateAnnounceApproval(AnnounceID(), "1", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            ViewAnnounce();
        }
        protected void btn_disable_approval_Click(object sender, EventArgs e)
        {
            if (AnnounceID() != "")
            {
                AnnounceBSO announceBSO = new AnnounceBSO();
                announceBSO.UpdateAnnounceApproval(AnnounceID(), "0", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            ViewAnnounce();
        }
        protected void btn_delall_Click(object sender, EventArgs e)
        {
            if (AnnounceID() != "")
            {
                AnnounceBSO announceBSO = new AnnounceBSO();
                announceBSO.DeleteAnnounce(AnnounceID());
            }
            ViewAnnounce();
        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text != "")
            {
                int cId = Convert.ToInt32(ddlCateAnnounceSearch.SelectedValue);
                AnnounceBSO announceBSO = new AnnounceBSO();
                DataTable table = announceBSO.AnnounceSearch(txtKeyword.Text, cId, Language.language);
                commonBSO commonBSO = new commonBSO();
                commonBSO.FillToGridView(grvAnnounce, table);
                BindCateSearch(3);
            }
        }

    }
}