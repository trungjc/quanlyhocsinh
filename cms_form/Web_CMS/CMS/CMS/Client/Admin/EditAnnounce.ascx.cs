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
    public partial class EditAnnounce : System.Web.UI.UserControl
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
                ViewCateAnnounce();
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

        #region ViewCateAnnounce
        private void ViewCateAnnounce()
        {
            //ddlCateAnnounce.Items.Clear();
            //CateNewsBSO catenewsBSO = new CateNewsBSO();
            //DataTable table = catenewsBSO.GetCateNews(Language.language);
            //DataView dataView = new DataView(table);
            //dataView.RowFilter = "GroupCate = 3";
            //ddlCateAnnounce.DataSource = dataView;
            //ddlCateAnnounce.DataTextField = "CateNewsName";
            //ddlCateAnnounce.DataValueField = "CateNewsID";
            //ddlCateAnnounce.DataBind();
            //commonBSO commonBSO = new commonBSO();
            //commonBSO.FillToDropDown(ddlCateAnnounce, table, "", "", "CateNewsName", "CateNewsID", "");

            int group = 3;

            ddlCateAnnounce.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateAnnounce, table, "", "", "CateNewsName", "CateNewsID", "");
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
                    Announce announce = new Announce();
                    AnnounceBSO announceBSO = new AnnounceBSO();
                    announce = announceBSO.GetAnnounceById(Id);
                    hddAnnounceID.Value = Convert.ToString(announce.AnnounceID);

                    ddlCateAnnounce.SelectedValue = Convert.ToString(announce.CateAnnounceID);
                    txtTitle.Text = announce.Title;
                    txtRadShort.Html = announce.ShortDescribe;
                    txtRadFull.Html = announce.FullDescribe;
                    hddImageThumb.Value = announce.ImageThumb;
                    hddFileName.Value = announce.FileName;
                    txtAuthor.Text = announce.Author;
                    txtRadDate.SelectedDate = announce.PostDate;
                    hddRelationTotal.Value = Convert.ToString(announce.RelationTotal);
                    rdbStatus.SelectedValue = Convert.ToString(announce.Status);
                    rdbIshot.SelectedValue = Convert.ToString(announce.Ishot);
                    rdbIshome.SelectedValue = Convert.ToString(announce.Ishome);

                    hddCommentTotal.Value = Convert.ToString(announce.CommentTotal);
                    hddIsView.Value = Convert.ToString(announce.Isview);
                    hddCreateUserName.Value = announce.CreatedUserName;
                    hddApprovalUserName.Value = announce.ApprovalUserName;
                    hddApprovalDate.Value = Convert.ToString(announce.ApprovalDate);

                    rdbComment.SelectedValue = Convert.ToString(announce.IsComment);

                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                    {
                        rdbApproval.SelectedValue = Convert.ToString(announce.IsApproval);
                        rdbApproval.Enabled = true;
                    }
                    else
                    {
                        rdbApproval.SelectedValue = Convert.ToString(announce.IsApproval);
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
        private Announce ReceiveHtml()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int thumb_w = Convert.ToInt32(config.New_large_w);
            int thumb_h = Convert.ToInt32(config.New_large_h);

            commonBSO commonBSO = new commonBSO();
            string path_thumb = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Announce/AnnounceThumb/";
            string image_thumb = commonBSO.UploadImage(file_image_thumb, path_thumb, thumb_w, thumb_h);

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Announce/Files/";
            string file_upload = commonBSO.UploadFile(file_attached, path, 1800000000000);


            Announce announce = new Announce();
            announce.AnnounceID = (hddAnnounceID.Value != "") ? Convert.ToInt32(hddAnnounceID.Value) : 0;
            announce.CateAnnounceID = Convert.ToInt32(ddlCateAnnounce.SelectedValue);
            announce.Title = txtTitle.Text;
            announce.ShortDescribe = txtRadShort.Html;
            announce.FullDescribe = txtRadFull.Html;
            announce.ImageThumb = (image_thumb != "") ? image_thumb : hddImageThumb.Value;
            announce.FileName = (file_upload != "") ? file_upload : hddFileName.Value;
            announce.Author = txtAuthor.Text;
            announce.PostDate = txtRadDate.SelectedDate.Value;
            announce.RelationTotal = (hddRelationTotal.Value != "") ? Convert.ToInt32(hddRelationTotal.Value) : 0;
            announce.Status = Convert.ToBoolean(rdbStatus.SelectedItem.Value);
            announce.Language = Language.language;
            announce.Ishot = Convert.ToBoolean(rdbIshot.SelectedValue);
            announce.Ishome = Convert.ToBoolean(rdbIshome.SelectedValue);
            announce.IsComment = Convert.ToBoolean(rdbComment.SelectedValue);

            announce.Isview = (hddIsView.Value != "") ? Convert.ToInt32(hddIsView.Value) : 0;
            announce.CommentTotal = (hddCommentTotal.Value != "") ? Convert.ToInt32(hddCommentTotal.Value) : 0;

            announce.CreatedUserName = (hddCreateUserName.Value != "") ? hddCreateUserName.Value : Session["Admin_UserName"].ToString();

            announce.IsApproval = Convert.ToBoolean(rdbApproval.SelectedValue);
            if (hddApprovalUserName.Value != "")
            {
                announce.ApprovalUserName = hddApprovalUserName.Value;
                announce.ApprovalDate = Convert.ToDateTime(hddApprovalDate.Value);
            }
            else
                if (Convert.ToBoolean(rdbApproval.SelectedValue))
                {
                    announce.ApprovalUserName = Session["Admin_UserName"].ToString();
                    announce.ApprovalDate = DateTime.Now;
                }
                else
                {
                    announce.ApprovalUserName = "";
                    announce.ApprovalDate = DateTime.Now;
                }


            return announce;

        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Announce announce = ReceiveHtml();
                AnnounceBSO announceBSO = new AnnounceBSO();
                announceBSO.CreateAnnounce(announce);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
                ViewCateAnnounce();
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
                Announce announce = ReceiveHtml();
                AnnounceBSO announceBSO = new AnnounceBSO();
                announceBSO.UpdateAnnounce(announce);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "tin", announce.Title);
                ViewCateAnnounce();
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
    }
}