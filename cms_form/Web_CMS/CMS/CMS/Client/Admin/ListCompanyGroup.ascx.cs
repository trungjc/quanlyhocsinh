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
    public partial class ListCompanyGroup : System.Web.UI.UserControl
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

            int group = 0;
            if (!String.IsNullOrEmpty(Page.RouteData.Values["group"].ToString()))
                if (!int.TryParse(Page.RouteData.Values["group"].ToString().Replace(",", ""), out group))
                    Response.Redirect("~/Admin/home/Default.aspx");

            if (group == 0)
                Response.Redirect("~/Admin/home/Default.aspx");
            else
            {
                hddGroup.Value = Convert.ToString(group);

                if (!IsPostBack)
                {

                    ViewCompany(group);

                }
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

        #region ViewCompany
        private void ViewCompany(int group)
        {
            //int group =2;
            CompanyBSO companyBSO = new CompanyBSO();
            DataTable table = new DataTable();

            if (!Session["Admin_UserName"].Equals("administrator"))
            {
                string strCate = GetCateParentIDArrayByID(group);
                if (strCate != "")
                    table = companyBSO.GetCompanyByCateHomeList(group, strCate);
            }
            else
            {
                table = companyBSO.GetCompanyAll(Language.language, group);
            }



            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvCompany, table);
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
        //    ddlCateNewsSearch.Items.Clear();
        //    CateNewsBSO catenewsBSO = new CateNewsBSO();
        //    DataTable table = catenewsBSO.GetCateNews(Language.language);
        //    DataView dataView = new DataView(table);
        //    dataView.RowFilter = "GroupCate = 2";
        //    ddlCateNewsSearch.DataSource = dataView;
        //    ddlCateNewsSearch.DataTextField = "CateNewsName";
        //    ddlCateNewsSearch.DataValueField = "CateNewsID";
        //    ddlCateNewsSearch.Items.Add(new ListItem("~~~ Trong tat ca ~~~","0"));
        //    ddlCateNewsSearch.DataBind();
        //}
        //#endregion

        #region BindCateSearch
        private void BindCateSearch(int group)
        {
            ddlCateNewsSearch.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateNewsSearch, table, "~~ Trong tất cả ~~", "0", "CateNewsName", "CateNewsID", "");
        }
        #endregion

        #region CompanyID
        private string CompanyID()
        {
            string companyId = "";
            foreach (GridViewRow rows in grvCompany.Rows)
            {
                CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
                if (checkbox.Checked)
                    companyId += rows.Cells[0].Text + ",";
            }
            return companyId;
        }

        #endregion

        protected void grvCompany_RowCommand(object sender, GridViewCommandEventArgs e)
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
                        Response.Redirect("~/Admin/editcompanygroup/" + hddGroup.Value + "/" + Id + "/Default.aspx");
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
                        CompanyBSO companyBSO = new CompanyBSO();
                        companyBSO.DeleteCompany(Id);
                        ViewCompany(Convert.ToInt32(hddGroup.Value));

                    }
                    else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnews");
                    }

                    break;
                case "_default":
                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        CompanyBSO companyBSO = new CompanyBSO();
                        companyBSO.UpdateSetDefault(Id, Convert.ToInt32(hddGroup.Value));
                        companyBSO.UpdateSetNotDefault(Id, Convert.ToInt32(hddGroup.Value));
                        ViewCompany(Convert.ToInt32(hddGroup.Value));

                    }
                    else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnews");
                    }

                    break;
            }
        }
        protected void grvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var imageDel = (ImageButton)e.Row.FindControl("btn_delete");
                var imageDefault = (ImageButton)e.Row.FindControl("btn_default");
                //  image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");

                var imageView = (ImageButton)e.Row.FindControl("btn_view");
                imageView.Attributes.Add("onclick", "javascript:window.open('~/Client/Admin/ViewCompany.aspx?Id=" + DataBinder.Eval(e.Row.DataItem, "CompanyID") + "','_blank','width=800,height=600');");

                var imageEdit = (ImageButton)e.Row.FindControl("btn_edit");

                AdminBSO adminBSO = new AdminBSO();
                ETO.Admin admin = new ETO.Admin();
                admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                {
                    imageDel.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
                    imageDefault.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn thiết lập bản tin này là mặc định ko ???');");
                }
                else
                {
                    imageEdit.Attributes.Add("onclick", "javascript:return confirm('Bạn không có đủ quyền ???');");
                    imageDel.Attributes.Add("onclick", "javascript:return confirm('Bạn không có đủ quyền ???');");
                    imageDefault.Attributes.Add("onclick", "javascript:return confirm('Bạn không có đủ quyền ???');");
                }

            }
        }
        protected void grvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCompany.PageIndex = e.NewPageIndex;
            ViewCompany(Convert.ToInt32(hddGroup.Value));
        }
        protected void btn_enable_Click(object sender, EventArgs e)
        {
            if (CompanyID() != "")
            {
                CompanyBSO companyBSO = new CompanyBSO();
                companyBSO.UpdateCompany(CompanyID(), "1");
            }
            ViewCompany(Convert.ToInt32(hddGroup.Value));
        }
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            if (CompanyID() != "")
            {
                CompanyBSO companyBSO = new CompanyBSO();
                companyBSO.UpdateCompany(CompanyID(), "0");
            }
            ViewCompany(Convert.ToInt32(hddGroup.Value));
        }
        protected void btn_enable_approval_Click(object sender, EventArgs e)
        {
            if (CompanyID() != "")
            {
                CompanyBSO companyBSO = new CompanyBSO();
                companyBSO.UpdateCompany(CompanyID(), "1", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            ViewCompany(Convert.ToInt32(hddGroup.Value));
        }
        protected void btn_disable_approval_Click(object sender, EventArgs e)
        {
            if (CompanyID() != "")
            {
                CompanyBSO companyBSO = new CompanyBSO();
                companyBSO.UpdateCompany(CompanyID(), "0", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            ViewCompany(Convert.ToInt32(hddGroup.Value));
        }
        protected void btn_delall_Click(object sender, EventArgs e)
        {
            if (CompanyID() != "")
            {
                CompanyBSO companyBSO = new CompanyBSO();
                companyBSO.DeleteCompany(CompanyID());
            }
            ViewCompany(Convert.ToInt32(hddGroup.Value));
        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text != "")
            {
                int cId = Convert.ToInt32(ddlCateNewsSearch.SelectedValue);
                CompanyBSO companyBSO = new CompanyBSO();
                DataTable table = companyBSO.GetCompanyAll(Language.language, Convert.ToInt32(hddGroup.Value));
                DataView dataView = new DataView(table);
                string sqlCate = "";
                if (cId != 0)
                {
                    sqlCate += " and Categories = " + cId;
                }
                string keySearch = "Title like '%" + txtKeyword.Text + "%' or Description like '%" + txtKeyword.Text + "%'";
                keySearch += sqlCate;
                dataView.RowFilter = keySearch;
                grvCompany.DataSource = dataView;
                grvCompany.DataBind();

                BindCateSearch(Convert.ToInt32(hddGroup.Value));
            }
        }

        protected void btn_comment_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/listnewsgroupcomment/" + hddGroup.Value + "/Default.aspx");

        }
        protected void btn_edit_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/editcompanygroup/" + hddGroup.Value + "/Default.aspx");

        }

    }
}