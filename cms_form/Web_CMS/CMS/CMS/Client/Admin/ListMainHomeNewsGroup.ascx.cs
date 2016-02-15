using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;

namespace CMS.Client.Admin
{
    public partial class ListMainHomeNewsGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

            var adminBSO = new AdminBSO();
            
            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
            {
                btn_editpage.Visible = true;
                btn_enable.Visible = true;
                btn_disable.Visible = true;

            }
            else
            {
                btn_editpage.Visible = false;
                btn_enable.Visible = false;
                btn_disable.Visible = false;
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
                    ViewNewsGroup(group);
                    BindCateSearch(Convert.ToInt32(hddGroup.Value));
                }
            }
        }

        #region NavigationTitle
        private void NavigationTitle(string url)
        {
            var modulesBSO = new ModulesBSO();
            var modules = modulesBSO.GetModulesByUrl(url);
            imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }
        #endregion

        #region ViewNewsGroup
        private void ViewNewsGroup(int group)
        {
            var newsGroupBSO = new NewsGroupBSO();
            var table = new DataTable();

            if (!Session["Admin_UserName"].Equals("administrator"))
            {
                var strCate = GetCateParentIdArrayById(group);
                if (strCate != "")
                    table = newsGroupBSO.GetNewsGroupAll(Language.language, group, strCate);
            }
            else
            {
                if (ddlCateNewsSearch.SelectedValue == "0")
                    table = newsGroupBSO.GetNewsGroupAll(Language.language, group);
                else
                {
                    var cId = Convert.ToInt32(ddlCateNewsSearch.SelectedValue);
                    table = newsGroupBSO.NewsGroupSearch(txtKeyword.Text, cId, Language.language);
                }
            }
            var commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvNewsGroup, table);
        }
        #endregion

        private string GetCateParentIdArrayById(int group)
        {
            string strArrayId = "";

            var cateNewsBSO = new CateNewsBSO();
            var table1 = cateNewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());

            if (table1.Rows.Count > 0)
            {
                foreach (DataRow subrow in table1.Rows)
                {
                    strArrayId += subrow["CateNewsID"].ToString() + ",";
                    // strArrayID += GetCateParentIDArrayByID(Convert.ToInt32(subrow["CateNewsID"].ToString()));
                }
            }
            return strArrayId;
        }

        #region BindCateSearch
        private void BindCateSearch(int group)
        {
            ddlCateNewsSearch.Items.Clear();
            var catenewsBSO = new CateNewsBSO();
            var table = catenewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());
            var commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateNewsSearch, table, "~~ Trong tất cả ~~", "0", "CateNewsName", "CateNewsID", "");
        }
        #endregion

        #region NewsGroupID
        private string NewsGroupID()
        {
            var newsGroupId = "";
            foreach (GridViewRow rows in grvNewsGroup.Rows)
            {
                var checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
                if (checkbox.Checked)
                    newsGroupId += rows.Cells[0].Text + ",";
            }
            return newsGroupId;
        }

        #endregion

        protected void btn_comment_click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/Group/listnewsgroupcomment/" + hddGroup.Value + "/Default.aspx");
        }

        protected void btn_edit_click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/Group/editnewsgroup/" + hddGroup.Value + "/Default.aspx");
        }

        protected void btn_enable_approval_Click(object sender, ImageClickEventArgs e)
        {
            if (NewsGroupID() != "")
            {
                var newsGroupBSO = new NewsGroupBSO();
                newsGroupBSO.UpdateNewsGroupApproval(NewsGroupID(), "1", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            ViewNewsGroup(Convert.ToInt32(hddGroup.Value));
        }

        protected void btn_disable_approval_Click(object sender, ImageClickEventArgs e)
        {
            if (NewsGroupID() != "")
            {
                var newsGroupBSO = new NewsGroupBSO();
                newsGroupBSO.UpdateNewsGroupApproval(NewsGroupID(), "0", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            ViewNewsGroup(Convert.ToInt32(hddGroup.Value));
        }

        protected void btn_enable_Click(object sender, ImageClickEventArgs e)
        {
            if (NewsGroupID() != "")
            {
                var newsGroupBSO = new NewsGroupBSO();
                newsGroupBSO.UpdateNewsGroup(NewsGroupID(), "1");
            }
            ViewNewsGroup(Convert.ToInt32(hddGroup.Value));
        }

        protected void btn_disable_Click(object sender, ImageClickEventArgs e)
        {
            if (NewsGroupID() != "")
            {
                var newsGroupBSO = new NewsGroupBSO();
                newsGroupBSO.UpdateNewsGroup(NewsGroupID(), "0");
            }
            ViewNewsGroup(Convert.ToInt32(hddGroup.Value));
        }

        protected void btn_search_Click(object sender, ImageClickEventArgs e)
        {
            ViewNewsGroup(Convert.ToInt32(hddGroup.Value));
        }

        protected void grvNewsGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvNewsGroup.PageIndex = e.NewPageIndex;
            ViewNewsGroup(Convert.ToInt32(hddGroup.Value));
        }

        protected void grvNewsGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var id = Convert.ToInt32(e.CommandArgument.ToString());
            var nName = e.CommandName.ToLower();
            var adminBSO = new AdminBSO();
            switch (nName)
            {
                case "_view":
                    break;
                case "_edit":
                    
                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        Response.Redirect("~/Admin/editnewsgroup/" + hddGroup.Value + "/" + id + "/Default.aspx");

                    }
                    else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnewsGroup");
                    }


                    break;

                case "_move":
                    
                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        Response.Redirect("~/Admin/editnewsgroupmove/" + hddGroup.Value + "/" + id + "/Default.aspx");

                    }
                    else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnewsGroup");
                    }


                    break;
                case "_delete":
                    
                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
                        newsGroupBSO.DeleteNewsGroup(id);
                        ViewNewsGroup(Convert.ToInt32(hddGroup.Value));

                    }
                    else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnewsGroup");
                    }

                    break;
                case "_default":

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        var newsGroupBSO = new NewsGroupBSO();
                        newsGroupBSO.UpdateSetDefault(id, Convert.ToInt32(hddGroup.Value));
                        newsGroupBSO.UpdateSetNotDefault(id, Convert.ToInt32(hddGroup.Value));
                        ViewNewsGroup(Convert.ToInt32(hddGroup.Value));

                    }
                    break;
            }
        }

        protected void grvNewsGroup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var imageDel = (ImageButton)e.Row.FindControl("btn_delete");
                //    image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");

                //ImageButton image_view = (ImageButton)e.Row.FindControl("btn_view");
                //image_view.Attributes.Add("onclick", "javascript:window.open('~/Client/Admin/ViewNewsGroup.aspx?Id=" + DataBinder.Eval(e.Row.DataItem, "NewsGroupID") + "','_blank','width=800,height=600');");


                var imageEdit = (ImageButton)e.Row.FindControl("btn_edit");

                var imageMove = (ImageButton)e.Row.FindControl("btn_move");

                var adminBSO = new AdminBSO();
                
                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                {
                    imageDel.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
                }
                else
                {
                    imageEdit.Attributes.Add("onclick", "javascript:return confirm('Bạn không có đủ quyền ???');");
                    imageMove.Attributes.Add("onclick", "javascript:return confirm('Bạn không có đủ quyền ???');");
                    imageDel.Attributes.Add("onclick", "javascript:return confirm('Bạn không có đủ quyền ???');");
                }
            }
        }
    }
}