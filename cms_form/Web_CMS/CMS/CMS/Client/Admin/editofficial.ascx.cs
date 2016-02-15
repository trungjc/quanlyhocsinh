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
    public partial class editofficial : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString(), out Id);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                ViewCateNews();
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

        #region ViewCateNews
        private void ViewCateNews()
        {
            ddlCateNews.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateNews(Language.language);
            DataView dataView = new DataView(table);
            dataView.RowFilter = "GroupCate = 4";
            ddlCateNews.DataSource = dataView;
            ddlCateNews.DataTextField = "CateNewsName";
            ddlCateNews.DataValueField = "CateNewsID";
            ddlCateNews.DataBind();

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
                    OfficialBSO officialBSO = new OfficialBSO();
                    Official official = officialBSO.GetOfficialById(Id);
                    hddOfficialID.Value = Convert.ToString(official.OfficialID);
                    hddfile_attached.Value = official.Attached;
                    ddlCateNews.SelectedValue = Convert.ToString(official.CateOfficialID);
                    txtNoCode.Text = official.NoCode;
                    txtOfficialName.Text = official.OfficialName;
                    txtRadDate.SelectedDate = official.DatePublic;
                    txtCompany.Text = official.Company;
                    txtClassify.Text = official.Classify;
                    txtAuthor.Text = official.Writer;
                    txtQuote.Html = official.Quote;
                    txtKeyShort.Text = official.KeyShort;
                    rdbStatus.SelectedValue = Convert.ToString(official.Status);

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
            }
        }
        #endregion

        #region ReceiveHtml
        private Official ReceiveHtml()
        {
            //string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Files/";
            //commonBSO commonBSO = new commonBSO();
            //string file_upload = commonBSO.UploadFile(file_attached, path, 18000000000);
            Official official = new Official();
            official.OfficialID = (hddOfficialID.Value != "") ? Convert.ToInt32(hddOfficialID.Value) : 0;
            official.CateOfficialID = Convert.ToInt32(ddlCateNews.SelectedValue);
            official.NoCode = txtNoCode.Text;
            official.OfficialName = txtOfficialName.Text;
            official.DatePublic = txtRadDate.SelectedDate.Value;
            official.Company = txtCompany.Text;
            official.Classify = txtClassify.Text;
            official.Writer = txtAuthor.Text;
            official.Quote = txtQuote.Html;
            official.KeyShort = txtKeyShort.Text;
            // official.Attached = (file_upload != "") ? file_upload : hddfile_attached.Value;
            official.Attached = "";
            official.Status = Convert.ToBoolean(rdbStatus.SelectedValue);


            official.IsApproval = true;
            official.ApprovalDate = DateTime.Now;
            official.ApprovalUserName = Session["Admin_UserName"].ToString();
            official.CreatedDate = DateTime.Now;
            official.CreatedUserName = Session["Admin_UserName"].ToString();
            return official;
        }
        #endregion

        protected void btn_edit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Official official = ReceiveHtml();
                OfficialBSO officialBSO = new OfficialBSO();
                officialBSO.UpdateOfficial(official);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Van ban", official.OfficialName);

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        protected void btn_add_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Official official = ReceiveHtml();
                OfficialBSO officialBSO = new OfficialBSO();
                officialBSO.CreateOfficial(official);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

    }
}