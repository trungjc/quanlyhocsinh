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
    public partial class ListDownload : System.Web.UI.UserControl
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
                ViewDownload();
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

        #region ViewDownload
        private void ViewDownload()
        {
            int group = 1;
            DownloadBSO downloadBSO = new DownloadBSO();
            DataTable table = new DataTable();

            if (!Session["Admin_UserName"].Equals("administrator"))
            {
                string strCate = GetCateParentIDArrayByID(group);
                if (strCate != "")
                    table = downloadBSO.GetDownloadByCateHomeList(strCate);
            }
            else
            {
                table = downloadBSO.GetDownloadAll(Language.language);
            }


            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvDownload, table);
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

        #region BindCateSearch
        private void BindCateSearch(int group)
        {
            ddlCateDownloadSearch.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());
            DataView view = new DataView(table);
            view.RowFilter = "ParentNewsID=0";
            table = view.ToTable();

            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateDownloadSearch, table, "~~ Trong tất cả ~~", "0", "CateNewsName", "CateNewsID", "");
        }
        #endregion

        #region DownloadID
        private string DownloadID()
        {
            string downloadId = "";
            foreach (GridViewRow rows in grvDownload.Rows)
            {
                CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
                if (checkbox.Checked)
                    downloadId += rows.Cells[0].Text + ",";
            }
            return downloadId;
        }

        #endregion

        protected void grvDownload_RowCommand(object sender, GridViewCommandEventArgs e)
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
                        Response.Redirect("~/Admin/editdownload/" + Id + "/Default.aspx");

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
                        DownloadBSO downloadBSO = new DownloadBSO();
                        downloadBSO.DeleteDownload(Id);
                        ViewDownload();

                    }
                    else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnews");
                    }

                    break;
            }
        }
        protected void grvDownload_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                //      image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");

                ImageButton image_view = (ImageButton)e.Row.FindControl("btn_view");
                image_view.Attributes.Add("onclick", "javascript:window.open('~/Client/Admin/ViewDownload.aspx?Id=" + DataBinder.Eval(e.Row.DataItem, "DownloadID") + "','_blank','width=800,height=600');");

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
        protected void grvDownload_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDownload.PageIndex = e.NewPageIndex;
            ViewDownload();
        }
        protected void btn_enable_Click(object sender, EventArgs e)
        {
            if (DownloadID() != "")
            {
                DownloadBSO downloadBSO = new DownloadBSO();
                downloadBSO.UpdateDownload(DownloadID(), "1");
            }
            ViewDownload();
        }
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            if (DownloadID() != "")
            {
                DownloadBSO downloadBSO = new DownloadBSO();
                downloadBSO.UpdateDownload(DownloadID(), "0");
            }
            ViewDownload();
        }
        protected void btn_enable_approval_Click(object sender, EventArgs e)
        {
            if (DownloadID() != "")
            {
                DownloadBSO downloadBSO = new DownloadBSO();
                downloadBSO.UpdateDownloadApproval(DownloadID(), "1", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            ViewDownload();
        }
        protected void btn_disable_approval_Click(object sender, EventArgs e)
        {
            if (DownloadID() != "")
            {
                DownloadBSO downloadBSO = new DownloadBSO();
                downloadBSO.UpdateDownloadApproval(DownloadID(), "0", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            ViewDownload();
        }
        protected void btn_delall_Click(object sender, EventArgs e)
        {
            if (DownloadID() != "")
            {
                DownloadBSO downloadBSO = new DownloadBSO();
                downloadBSO.DeleteDownload(DownloadID());
            }
            ViewDownload();
        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text != "")
            {
                int cId = Convert.ToInt32(ddlCateDownloadSearch.SelectedValue);
                DownloadBSO downloadBSO = new DownloadBSO();
                DataTable table = downloadBSO.DownloadSearch(txtKeyword.Text, cId, Language.language);
                commonBSO commonBSO = new commonBSO();
                commonBSO.FillToGridView(grvDownload, table);
                BindCateSearch(1);
            }
        }

    }
}