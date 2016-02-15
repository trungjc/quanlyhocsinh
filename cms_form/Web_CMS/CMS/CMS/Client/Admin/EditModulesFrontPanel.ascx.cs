using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.IO;
using System.Collections.Specialized;
using System.Data;
using System.Xml;
using System.Xml.Linq;


namespace CMS.Client.Admin
{
    public partial class EditModulesFrontPanel : System.Web.UI.UserControl
    {
        public DataTable dt;
        //string strParentFolder = "Client/Modules/MainHome";
        string strParentFolder = "";
        static DataTable tb;
        #region ViewCateGroup
        private void ViewCateGroup()
        {
            CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
            DataTable table = catenewsGroupBSO.GetCateNewsGroupAll();
            DataView dv = new DataView(table);
            dv.RowFilter = "CateNewsGroupName <> 'Văn bản pháp quy' and language = 'vi-VN'";
            DataTable dt = dv.ToTable();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlValueCategory, dt, "Không có giá trị", "0", "CateNewsGroupName", "GroupCate", "");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            int ID = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString(), out ID);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                item_Drop();
                initControl(ID);
                BindDropDownList();
                ViewCateGroup();
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

        #region initControl
        protected void initControl(int ID)
        {
            if (ID > 0)
            {
                txtModulesFrontPanelID.Value = Convert.ToString(ID);
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    ModulesFrontPanelBSO _modulesFrontPanelBSO = new ModulesFrontPanelBSO();

                    ModulesFrontPanel _modulesFrontPanelRows = _modulesFrontPanelBSO.GetModulesFrontPanelById(ID);
                    ddlModulesFrontPanel.SelectedValue = _modulesFrontPanelRows.ModulesFrontPanelParent.ToString();
                    txtModulesFrontPanelName.Text = _modulesFrontPanelRows.ModulesFrontPanelName;
                    //  txtModulesFrontPanelUrl.Text = _modulesFrontPanelRows.ModulesFrontPanelUrl;


                    txtRadHelp.Content = _modulesFrontPanelRows.ModulesFrontPanelHelp;
                    txtRadFull.Content = _modulesFrontPanelRows.ModulesFontPanelContent;
                    hddIcon.Value = _modulesFrontPanelRows.ModulesFrontPanelIcon;
                    uploadPreview.Src = ResolveUrl("~/Upload/Admin_Theme/Icons/") + _modulesFrontPanelRows.ModulesFrontPanelIcon;

                    txtModulesFrontPanelTitle.Text = _modulesFrontPanelRows.ModulesFrontPanelTitle;
                    ddlValueCategory.SelectedValue = _modulesFrontPanelRows.ModulesFrontPanelValue;
                    txtRecord.Text = _modulesFrontPanelRows.ModulesFrontPanelRecord.ToString();
                    rdbPanel.SelectedValue = _modulesFrontPanelRows.ModulesFrontPanelPanel;
                    chkStatus.Checked = _modulesFrontPanelRows.ModulesFrontPanelStatus;
                    NgonNgu.SelectedValue = _modulesFrontPanelRows.Language;
                    GetFile();
                    dropControl.SelectedValue = _modulesFrontPanelRows.ModulesFrontPanelUrl;
                }
                catch (Exception ex)
                {
                    error.Text = ex.Message.ToString();
                }
            }
            else
            {
                rdbPanel.SelectedValue = "Main";
                GetFile();

                txtModulesFrontPanelID.Value = "";
                ddlModulesFrontPanel.SelectedIndex = 0;
                btn_add.Visible = true;
                btn_edit.Visible = false;
            }
        }
        #endregion

        #region BindDropDownList
        protected void BindDropDownList()
        {
            ModulesFrontPanelBSO _modulesFrontPanelBSO = new ModulesFrontPanelBSO();
            DataTable table = _modulesFrontPanelBSO.MixModulesFrontPanel(rdbPanel.SelectedValue);
            commonBSO commonBSO = new commonBSO();
            ddlModulesFrontPanel.Items.Clear();
            commonBSO.FillToDropDown(ddlModulesFrontPanel, table, "~ Cấp độ Modules ~", "0", "ModulesFrontPanel_Name", "ModulesFrontPanel_ID", "");
        }
        #endregion

        #region AddNews
        protected void Add()
        {
            ModulesFrontPanelBSO _modulesFrontPanelBSO = new ModulesFrontPanelBSO();
            ModulesFrontPanel _modulesFrontPanel = ReceiveHtml();
            try
            {

                _modulesFrontPanelBSO.AddModulesFrontPanel(_modulesFrontPanel);
                error.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }

        }
        #endregion

        #region Edit
        protected void Edit()
        {
            ModulesFrontPanelBSO _modulesFrontPanelBSO = new ModulesFrontPanelBSO();
            ModulesFrontPanel _modulesFrontPanel = ReceiveHtml();
            try
            {
                _modulesFrontPanelBSO.EditModulesFrontPanel(_modulesFrontPanel);
                error.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "ModulesFrontPanel", _modulesFrontPanel.ModulesFrontPanelName);

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region ReceiveHtml
        public ModulesFrontPanel ReceiveHtml()
        {
            ModulesFrontPanel _modulesFrontPanel = new ModulesFrontPanel();

            //      string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Admin/Admin_Theme/Icons/";
            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Admin_Theme/Icons/";
            commonBSO commonBSO = new commonBSO();
            string icon_upload = commonBSO.UploadImage(uploadIcon, path, 32, 32);

            _modulesFrontPanel.ModulesFrontPanelID = (txtModulesFrontPanelID.Value != "") ? Convert.ToInt32(txtModulesFrontPanelID.Value) : 0;
            _modulesFrontPanel.ModulesFrontPanelName = (txtModulesFrontPanelName.Text != "") ? txtModulesFrontPanelName.Text.Trim() : "";
            _modulesFrontPanel.ModulesFrontPanelOrder = 0;
            _modulesFrontPanel.ModulesFrontPanelParent = (ddlModulesFrontPanel.SelectedValue != "") ? Convert.ToInt32(ddlModulesFrontPanel.SelectedValue) : 0;
            //_modulesFrontPanel.ModulesFrontPanelUrl = (txtModulesFrontPanelUrl.Text != "") ? txtModulesFrontPanelUrl.Text.Trim() : "";
            if (dropControl.SelectedIndex > 0)
            {
                _modulesFrontPanel.ModulesFrontPanelUrl = dropControl.SelectedValue;
            }

            _modulesFrontPanel.ModulesFrontPanelHelp = txtRadHelp.Content;
            _modulesFrontPanel.ModulesFontPanelContent = txtRadFull.Content;
            _modulesFrontPanel.ModulesFrontPanelIcon = (icon_upload != "") ? icon_upload : hddIcon.Value;

            _modulesFrontPanel.ModulesFrontPanelTitle = (txtModulesFrontPanelTitle.Text != "") ? txtModulesFrontPanelTitle.Text.Trim() : "";
            _modulesFrontPanel.ModulesFrontPanelValue = (ddlValueCategory.SelectedValue != "") ? ddlValueCategory.SelectedValue.Trim() : "0";
            _modulesFrontPanel.ModulesFrontPanelRecord = (txtRecord.Text != "") ? Convert.ToInt32(txtRecord.Text) : 5;
            _modulesFrontPanel.ModulesFrontPanelPanel = rdbPanel.SelectedValue;
            _modulesFrontPanel.ModulesFrontPanelStatus = chkStatus.Checked;
            _modulesFrontPanel.Language = NgonNgu.SelectedValue;

            return _modulesFrontPanel;
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Add();
            BindDropDownList();
        }
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void GetFile()
        {
            if (rdbPanel.SelectedValue.Equals("Left"))
                strParentFolder = "Panel";
            else
                if (rdbPanel.SelectedValue.Equals("Right"))
                    strParentFolder = "Panel";
                else
                    if (rdbPanel.SelectedValue.Equals("Main"))
                        strParentFolder = "MainHome";
                    else
                        strParentFolder = "Modules";

            //DataTable myDataTable = new DataTable();
            XElement xDoc = XElement.Load(Server.MapPath("~/Client/Modules/Module.xml"));
            List<Module> md = new List<Module>();

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/Client/Modules/Module.xml"));
            XmlNodeList elemList = doc.GetElementsByTagName(strParentFolder).Item(0).SelectNodes("md");
            for (int i = 0; i < elemList.Count; i++)
            {
                md.Add(new Module() { modules = elemList[i].InnerText });
            }

            dropControl.DataSource = md;
            dropControl.DataTextField = "modules";
            dropControl.DataValueField = "modules";

            dropControl.DataBind();
            dropControl.Items.Insert(0, "------ Chọn -------");
        }

        protected void rdbPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbPanel.SelectedValue.Equals("Left"))
                strParentFolder = "Client/Modules/Panel";
            else
                if (rdbPanel.SelectedValue.Equals("Right"))
                    strParentFolder = "Client/Modules/Panel";
                else
                    if (rdbPanel.SelectedValue.Equals("Main"))
                        strParentFolder = "Client/Modules/MainHome";
                    else
                        strParentFolder = "Client/Modules";

            GetFile();
            BindDropDownList();
        }

        protected void item_Drop()
        {
            NgonNgu.Items.Add(new ListItem("Tiếng Việt", "vi-VN"));
            NgonNgu.Items.Add(new ListItem("English", "en-US"));
        }

        protected void NgonNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NgonNgu.SelectedValue == "vi-VN")
            {
                CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
                DataTable table = catenewsGroupBSO.GetCateNewsGroupAll();
                DataView dv = new DataView(table);
                dv.RowFilter = "CateNewsGroupName <> 'Văn bản pháp quy' and language = 'vi-VN'";
                DataTable dt = dv.ToTable();
                commonBSO commonBSO = new commonBSO();
                commonBSO.FillToDropDown(ddlValueCategory, dt, "Không có giá trị", "0", "CateNewsGroupName", "GroupCate", "");
            }
            if (NgonNgu.SelectedValue == "en-US")
            {
                CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
                DataTable table = catenewsGroupBSO.GetCateNewsGroupAll();
                DataView dv = new DataView(table);
                dv.RowFilter = "CateNewsGroupName <> 'Văn bản pháp quy' and language = 'en-US'";
                DataTable dt = dv.ToTable();
                commonBSO commonBSO = new commonBSO();
                commonBSO.FillToDropDown(ddlValueCategory, dt, "Không có giá trị", "0", "CateNewsGroupName", "GroupCate", "");

            }


        }

    }
}