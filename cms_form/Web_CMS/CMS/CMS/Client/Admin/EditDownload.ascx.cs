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
    public partial class EditDownload : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                ViewCateDownload();
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

        #region ViewCateDownload
        private void ViewCateDownload()
        {

            int group = 1;

            ddlCateDownload.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());
            DataView view = new DataView(table);
            view.RowFilter = "ParentNewsID=0";
            table = view.ToTable();

            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateDownload, table, "", "", "CateNewsName", "CateNewsID", "");
        }
        #endregion

        #region initControl
        private void initControl(int Id)
        {
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    Download download = new Download();
                    DownloadBSO downloadBSO = new DownloadBSO();
                    download = downloadBSO.GetDownloadById(Id);
                    hddDownloadID.Value = Convert.ToString(download.DownloadID);

                    ddlCateDownload.SelectedValue = Convert.ToString(download.CateDownloadID);
                    txtTitle.Text = download.Title;
                    txtRadShort.Html = download.ShortDescribe;
                    txtRadFull.Html = download.FullDescribe;
                    hddImageThumb.Value = download.ImageThumb;
                    hddFileName.Value = download.FileName;
                    txtAuthor.Text = download.Author;
                    txtRadDate.SelectedDate = download.PostDate;
                    hddRelationTotal.Value = Convert.ToString(download.RelationTotal);
                    rdbStatus.SelectedValue = Convert.ToString(download.Status);
                    rdbIshot.SelectedValue = Convert.ToString(download.Ishot);
                    rdbIshome.SelectedValue = Convert.ToString(download.Ishome);

                    hddCommentTotal.Value = Convert.ToString(download.CommentTotal);
                    hddIsView.Value = Convert.ToString(download.Isview);
                    hddCreateUserName.Value = download.CreatedUserName;
                    hddApprovalUserName.Value = download.ApprovalUserName;
                    hddApprovalDate.Value = Convert.ToString(download.ApprovalDate);

                    rdbComment.SelectedValue = Convert.ToString(download.IsComment);

                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                    {
                        rdbApproval.SelectedValue = Convert.ToString(download.IsApproval);
                        rdbApproval.Enabled = true;
                    }
                    else
                    {
                        rdbApproval.SelectedValue = Convert.ToString(download.IsApproval);
                        rdbApproval.Enabled = false;
                    }




                }
                catch (Exception ex)
                {
                    clientview.Text = ex.Message.ToString();
                }
            }
            else
            {
                txtRadDate.SelectedDate = DateTime.Now;
                btn_add.Visible = true;
                btn_edit.Visible = false;

                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                {

                    rdbApproval.Enabled = true;
                }
                else
                {

                    rdbApproval.Enabled = false;
                }
            }
        }
        #endregion

        #region ReceiveHtml
        private Download ReceiveHtml()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int thumb_w = Convert.ToInt32(config.New_large_w);
            int thumb_h = Convert.ToInt32(config.New_large_h);

            commonBSO commonBSO = new commonBSO();
            string path_thumb = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Download/DownloadThumb/";
            string image_thumb = commonBSO.UploadImage(file_image_thumb, path_thumb, thumb_w, thumb_h);

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Download/Files/";
            string file_upload = commonBSO.UploadFile(file_attached, path, 18000000000000);


            Download download = new Download();
            download.DownloadID = (hddDownloadID.Value != "") ? Convert.ToInt32(hddDownloadID.Value) : 0;
            download.CateDownloadID = Convert.ToInt32(ddlCateDownload.SelectedValue);
            download.Title = txtTitle.Text;
            download.ShortDescribe = txtRadShort.Html;
            download.FullDescribe = txtRadFull.Html;
            download.ImageThumb = (image_thumb != "") ? image_thumb : hddImageThumb.Value;
            download.FileName = (file_upload != "") ? file_upload : hddFileName.Value;
            download.Author = txtAuthor.Text;
            download.PostDate = txtRadDate.SelectedDate.Value;
            download.RelationTotal = (hddRelationTotal.Value != "") ? Convert.ToInt32(hddRelationTotal.Value) : 0;
            download.Status = Convert.ToBoolean(rdbStatus.SelectedItem.Value);
            download.Language = Language.language;
            download.Ishot = Convert.ToBoolean(rdbIshot.SelectedValue);
            download.Ishome = Convert.ToBoolean(rdbIshome.SelectedValue);
            download.IsComment = Convert.ToBoolean(rdbComment.SelectedValue);

            download.Isview = (hddIsView.Value != "") ? Convert.ToInt32(hddIsView.Value) : 0;
            download.CommentTotal = (hddCommentTotal.Value != "") ? Convert.ToInt32(hddCommentTotal.Value) : 0;

            download.CreatedUserName = (hddCreateUserName.Value != "") ? hddCreateUserName.Value : Session["Admin_UserName"].ToString();

            download.IsApproval = Convert.ToBoolean(rdbApproval.SelectedValue);
            if (hddApprovalUserName.Value != "")
            {
                download.ApprovalUserName = hddApprovalUserName.Value;
                download.ApprovalDate = Convert.ToDateTime(hddApprovalDate.Value);
            }
            else
                if (Convert.ToBoolean(rdbApproval.SelectedValue))
                {
                    download.ApprovalUserName = Session["Admin_UserName"].ToString();
                    download.ApprovalDate = DateTime.Now;
                }
                else
                {
                    download.ApprovalUserName = "";
                    download.ApprovalDate = DateTime.Now;
                }


            return download;

        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Download download = ReceiveHtml();
                DownloadBSO downloadBSO = new DownloadBSO();
                downloadBSO.CreateDownload(download);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
                ViewCateDownload();
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
                Download download = ReceiveHtml();
                DownloadBSO downloadBSO = new DownloadBSO();
                downloadBSO.UpdateDownload(download);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "tin", download.Title);
                ViewCateDownload();
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
    }
}