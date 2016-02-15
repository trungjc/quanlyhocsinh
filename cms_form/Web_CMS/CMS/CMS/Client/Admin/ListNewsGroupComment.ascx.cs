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
    public partial class ListNewsGroupComment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

            int group = 0;
            if (!String.IsNullOrEmpty(Page.RouteData.Values["group"].ToString()))
                int.TryParse(Page.RouteData.Values["group"].ToString().Replace(",", ""), out group);
            hddGroup.Value = Convert.ToString(group);

            int Id = -1;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);

            hddNewsID.Value = Convert.ToString(Id);

            //  ltllistnews.Text = "<asp:HyperLink ID='btn_listnews' runat='server' NavigateUrl='~/Homepage.aspx?dll=" + ((group == 1) ? "listnews" : "listannounce") + "'><img src='Admin_Theme/Icons/icon-danhsach.gif' /></asp:HyperLink>";
            //  ltleditcomment.Text = "<asp:HyperLink ID='btn_editnewscomment' runat='server' NavigateUrl='~/Homepage.aspx?dll=editnewscomment&group=" + Convert.ToString(group) + "' ><img src='Admin_Theme/Icons/icon-taomoi-small.gif' /></asp:HyperLink>";

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
                NewsCommentView(group);
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

        protected void grvNewsComment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();

            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string cName = e.CommandName.ToLower();
            switch (cName)
            {
                case "_view":
                    break;
                case "_edit":
                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        Response.Redirect("~/Admin/editnewsgroupcomment/" + Id + "/Default.aspx");

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
                        NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
                        newsCommentBSO.DeleteNewsComment(Id);
                        NewsCommentView(Convert.ToInt32(hddGroup.Value));

                    }
                    else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnews");
                    }

                    break;


            }
        }
        protected void grvNewsComment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                //   image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");
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

        #region NewsCommentView
        protected void NewsCommentView(int group)
        {
            NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
            DataTable table = new DataTable();
            if (hddNewsID.Value != "-1")
            {

                table = newsCommentBSO.GetAllNewsGroupComment(Convert.ToInt32(hddNewsID.Value), group);

            }
            else
            {
                table = newsCommentBSO.GetAllNewsGroupComment(group);
            }
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvNewsComment, table);
        }
        #endregion

        #region NewsCommentID
        private string NewsCommentID()
        {
            string newsCommentId = "";
            foreach (GridViewRow rows in grvNewsComment.Rows)
            {
                CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
                if (checkbox.Checked)
                    newsCommentId += rows.Cells[0].Text + ",";
            }
            return newsCommentId;
        }

        #endregion

        protected void grvNewsComment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvNewsComment.PageIndex = e.NewPageIndex;
            NewsCommentView(Convert.ToInt32(hddGroup.Value));
        }
        protected void btn_enable_Click(object sender, EventArgs e)
        {
            if (NewsCommentID() != "")
            {
                NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
                newsCommentBSO.UpdateNewsComment(NewsCommentID(), "1", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            NewsCommentView(Convert.ToInt32(hddGroup.Value));
        }
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            if (NewsCommentID() != "")
            {
                NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
                newsCommentBSO.UpdateNewsComment(NewsCommentID(), "0", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            NewsCommentView(Convert.ToInt32(hddGroup.Value));
        }


        protected void btn_delAll_Click(object sender, EventArgs e)
        {
            if (NewsCommentID() != "")
            {
                NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
                newsCommentBSO.DeleteNewsComment(NewsCommentID());
            }
            NewsCommentView(Convert.ToInt32(hddGroup.Value));
        }

        protected void btn_list(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/listnewsgroup/" + hddGroup.Value + "/Default.aspx");
        }
        protected void btn_editcomment(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/editnewsgroupcomment/" + hddGroup.Value + "/Default.aspx");

        }

    }
}