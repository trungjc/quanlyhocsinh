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
    public partial class EditOfficialFiles : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["id"].ToString().Replace(",", ""), out Id);

            int cId = 0;
            if (!String.IsNullOrEmpty(Page.RouteData.Values["group"].ToString()))
                int.TryParse(Page.RouteData.Values["group"].ToString().Replace(",", ""), out cId);

            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                hddOfficialID.Value = Convert.ToString(cId);
                ViewFiles(cId);
                initControl(Id);
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

        #region ViewFiles
        private void ViewFiles(int cId)
        {
            OfficialFileBSO officialFileBSO = new OfficialFileBSO();
            DataTable table = new DataTable();
            if (cId != 0)
                table = officialFileBSO.GetOfficialFileByOfficial(cId);
            else
                table = officialFileBSO.GetOfficialFileAll();

            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvFiles, table);
        }
        #endregion

        #region initControl
        private void initControl(int Id)
        {
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    OfficialFileBSO officialFileBSO = new OfficialFileBSO();
                    OfficialFile officialFile = officialFileBSO.GetOfficialFileByID(Id);


                    hddOfficialFileID.Value = Convert.ToString(officialFile.OfficialFileID);
                    hddOfficialID.Value = Convert.ToString(officialFile.OfficialID);
                    hddFileName.Value = Convert.ToString(officialFile.FileName);
                    txtTitle.Text = officialFile.Title;


                }
                catch (Exception ex)
                {
                    clientview.Text = ex.Message.ToString();
                }
            }
            else
            {
                btn_edit.Visible = false;
                btn_add.Visible = true;



            }
        }
        #endregion

        #region ReceiveHtml
        private OfficialFile ReceiveHtml()
        {


            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Official/Files/";
            commonBSO commonBSO = new commonBSO();
            string file_upload = commonBSO.UploadFile(file_attached, path, 180000000000);


            OfficialFile officialFile = new OfficialFile();


            officialFile.OfficialFileID = (hddOfficialFileID.Value != "") ? Convert.ToInt32(hddOfficialFileID.Value) : 0;
            officialFile.OfficialID = Convert.ToInt32(hddOfficialID.Value);
            officialFile.Title = txtTitle.Text;
            officialFile.FileName = (file_upload != "") ? file_upload : hddFileName.Value;


            return officialFile;
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
                    OfficialFileBSO fileBSO = new OfficialFileBSO();
                    fileBSO.DeleteOfficialFile(Id);

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
        protected void btn_add_Click(object sender, EventArgs e)
        {

            try
            {
                if (String.IsNullOrEmpty(file_attached.FileName))
                {

                    ViewFiles(Convert.ToInt32(hddOfficialID.Value));
                    clientview.Text = "Chưa có file đính kèm";

                }
                else
                {
                    OfficialFile file = new OfficialFile();
                    file = ReceiveHtml();


                    OfficialFileBSO filesBSO = new OfficialFileBSO();
                    filesBSO.CreateOfficialFile(file);


                    ViewFiles(Convert.ToInt32(hddOfficialID.Value));
                    clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);


                }


            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }

        }
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                OfficialFile file = new OfficialFile();
                file = ReceiveHtml();


                OfficialFileBSO filesBSO = new OfficialFileBSO();
                filesBSO.UpdateOfficialFile(file);


                ViewFiles(Convert.ToInt32(hddOfficialID.Value));
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

        protected void btn_listfile(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/listofficialfiles/" + hddOfficialID.Value + "/Default.aspx");
        }
        protected void btn_editfile(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/editofficialfiles/" + hddOfficialID.Value + "/0/Default.aspx");

        }

    }
}