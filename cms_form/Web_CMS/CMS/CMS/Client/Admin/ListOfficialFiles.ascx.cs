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
    public partial class ListOfficialFiles : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

            int cId = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out cId);

            hddOfficialID.Value = Convert.ToString(cId);

            if (!IsPostBack)
                ViewFiles(cId);
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

        #region ViewFiles
        private void ViewFiles(int cId)
        {
            OfficialFileBSO officialFilesBSO = new OfficialFileBSO();
            DataTable table = new DataTable();
            if (cId != 0)
                table = officialFilesBSO.GetOfficialFileByOfficial(cId);
            else
                table = officialFilesBSO.GetOfficialFileAll();

            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvFiles, table);
        }
        #endregion


        protected void grvFiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFiles.PageIndex = e.NewPageIndex;

            ViewFiles(Convert.ToInt32(hddOfficialID.Value));
        }
        protected void grvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string nName = e.CommandName.ToLower();
            switch (nName)
            {
                case "_edit":
                    Response.Redirect("~/Admin/editofficialfiles/" + hddOfficialID.Value + "/" + Id + "/Default.aspx");
                    break;

                case "_delete":
                    OfficialFileBSO officialFileBSO = new OfficialFileBSO();
                    officialFileBSO.DeleteOfficialFile(Id);

                    ViewFiles(Convert.ToInt32(hddOfficialID.Value));
                    break;
            }
        }
        protected void grvFiles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
            }
        }

        protected void btn_delall_Click(object sender, EventArgs e)
        {
            if (FilesID() != "")
            {
                OfficialFileBSO fileBSO = new OfficialFileBSO();
                fileBSO.DeleteOfficialFile(FilesID());
            }
            ViewFiles(Convert.ToInt32(hddOfficialID.Value));
        }

        #region FilesID
        private string FilesID()
        {
            string filesId = "";
            foreach (GridViewRow rows in grvFiles.Rows)
            {
                CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
                if (checkbox.Checked)
                    filesId += rows.Cells[0].Text + ",";
            }
            return filesId;
        }

        #endregion

        protected void btn_editofficialfiles(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/editofficialfiles/" + hddOfficialID.Value + "/0/Default.aspx");

        }

    }
}