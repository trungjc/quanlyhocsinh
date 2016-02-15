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
    public partial class editcatenews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cId = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out cId);

            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

            if (rdbType.SelectedValue.Equals("True"))
            {
                txtUrl.Visible = true;
            }
            else
            {
                txtUrl.Visible = false;
            }

            int group = 0;
            if (!String.IsNullOrEmpty(Page.RouteData.Values["group"].ToString()))
                if (!int.TryParse(Page.RouteData.Values["group"].ToString().Replace(",", ""), out group))
                    Response.Redirect("~/Admin/home/Default.aspx");

            if (group == 0)
                Response.Redirect("~/Admin/home/Default.aspx");
            else
            {

                if (!IsPostBack)
                {
                    HddGroupCate.Value = Convert.ToString(group);
                    ViewCateGroup(group);

                    InitControl(cId);
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

        #region ViewCateGroup
        private void ViewCateGroup(int group)
        {
            ddlCateNews.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateGroupRolesUrl(Language.language, group, Session["Admin_UserName"].ToString());
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateNews, table, "~~ Danh mục gốc ~~", "0", "CateNewsName", "CateNewsID", "");
        }
        #endregion

        #region initControl
        private void InitControl(int id)
        {
            if (id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    var catenewsBSO = new CateNewsBSO();
                    var catenews = catenewsBSO.GetCateNewsById(id);
                    hddCateNewsID.Value = Convert.ToString(catenews.CateNewsID);
                    hddParentID.Value = Convert.ToString(catenews.ParentNewsID);
                    ddlCateNews.SelectedValue = Convert.ToString(catenews.ParentNewsID);

                    ddlCateNews.Items.Remove(new ListItem(catenews.CateNewsName, Convert.ToString(catenews.CateNewsID)));

                    txtCateNewsName.Text = catenews.CateNewsName;
                    hddCateNewsOrder.Value = Convert.ToString(catenews.CateNewsOrder);
                    hddCateNewsTotal.Value = Convert.ToString(catenews.CateNewsTotal);
                    //rdbGroupCate.SelectedValue = Convert.ToString(catenews.GroupCate);
                    hddIcon.Value = catenews.Icon;
                    hddImage.Value = catenews.Image;
                    uploadPreview.Src = ResolveUrl("~/Upload/Category/") + catenews.Icon;
                    uploadPreview1.Src = ResolveUrl("~/Upload/Category/") + catenews.Image;
                    txtSlogan.Text = catenews.Slogan;
                    hddUserName.Value = Session["Admin_UserName"].ToString();
                    hddCreated.Value = DateTime.Now.ToString();

                    //      HddGroupCate.Value = Convert.ToString(catenews.GroupCate);

                    rdbType.SelectedValue = Convert.ToString(catenews.isUrl);
                    txtUrl.Text = catenews.Url;

                    if (catenews.isUrl == true)
                    {
                        txtUrl.Visible = true;
                    }
                    else
                    {
                        txtUrl.Visible = false;
                    }

                    ViewCateGroup(catenews.GroupCate);
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
        private CateNews ReceiveHtml()
        {

            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int icon_w = Convert.ToInt32(config.New_icon_w);
            int icon_h = Convert.ToInt32(config.New_icon_h);

            int img_w = Convert.ToInt32(config.New_large_w);
            int img_h = Convert.ToInt32(config.New_large_h);

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/Category/";
            commonBSO commonBSO = new commonBSO();
            string image_icon = commonBSO.UploadImage(file_icon, path, icon_w, icon_h);

            string image = commonBSO.UploadImage(FileUpload1, path, img_w, img_h);

            CateNews catenews = new CateNews();
            catenews.CateNewsID = (hddCateNewsID.Value != "") ? Convert.ToInt32(hddCateNewsID.Value) : 0;
            catenews.ParentNewsID = (ddlCateNews.SelectedValue != "") ? Convert.ToInt32(ddlCateNews.SelectedValue) : 0;
            catenews.CateNewsName = txtCateNewsName.Text;
            catenews.CateNewsOrder = (hddCateNewsOrder.Value != "") ? Convert.ToInt32(hddCateNewsOrder.Value) : 0;
            catenews.CateNewsTotal = (hddCateNewsTotal.Value != "") ? Convert.ToInt32(hddCateNewsTotal.Value) : 0;
            catenews.Language = Language.language;
            catenews.GroupCate = Convert.ToInt32(HddGroupCate.Value);
            catenews.Icon = (image_icon != "") ? image_icon : hddIcon.Value;
            catenews.Image = (image != "") ? image : hddImage.Value;
            catenews.Slogan = txtSlogan.Text;

            catenews.UserName = (hddUserName.Value != "") ? hddUserName.Value : Session["Admin_UserName"].ToString();
            catenews.Created = (hddCreated.Value != "") ? Convert.ToDateTime(hddCreated.Value) : DateTime.Now;

            catenews.isUrl = Convert.ToBoolean(rdbType.SelectedValue);
            catenews.Url = txtUrl.Text;

            catenews.Roles = "";
            return catenews;
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                CateNews catenews = ReceiveHtml();
                CateNewsBSO catenewsBSO = new CateNewsBSO();

                int catenews1 = catenewsBSO.CreateCateNewGet(catenews);

                if (!Session["Admin_UserName"].ToString().Equals("administrator"))
                {
                    AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
                    DataTable table = adminRolesBSO.GetAdminRolesByUserName(Session["Admin_UserName"].ToString());

                    CateNewsPermissionBSO catenewPermissionBSO = new CateNewsPermissionBSO();
                    CateNewsPermission cateNewsPermission = new CateNewsPermission();

                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow subrow in table.Rows)
                        {
                            cateNewsPermission.CateNewsID = catenews1;
                            cateNewsPermission.RolesID = Convert.ToInt32(subrow["RolesID"].ToString());
                            //cateNewsPermission.Permission = subrow["Permission"].ToString();
                            cateNewsPermission.Permission = "";
                            cateNewsPermission.UserName = Session["Admin_UserName"].ToString();
                            cateNewsPermission.Created = DateTime.Now;

                            catenewPermissionBSO.CreateCateNewsPermission(cateNewsPermission);
                        }


                    }

                }
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);

                //ViewCateGroup(Convert.ToInt32(HddGroupCate.Value));

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
                CateNews catenews = ReceiveHtml();

                CateNewsBSO catenewsBSO = new CateNewsBSO();
                //if (CheckedList().Equals(""))
                //{
                //    clientview.Text = "Loi : Xin hay lua chon it nhat 1 quyen";
                //}
                //else
                //{
                catenewsBSO.UpdateCateNews(catenews);

                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "danh mục", catenews.CateNewsName);

                //ViewCateGroup(Convert.ToInt32(HddGroupCate.Value));
                //}
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }


        protected void rdbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbType.SelectedValue.Equals("True"))
            {
                txtUrl.Visible = true;
            }
            else
            {
                txtUrl.Visible = false;
            }
        }

        protected void btn_list_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/listcatenews/" + HddGroupCate.Value + "/Default.aspx");
        }
        protected void btn_create_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/editcatenews/" + HddGroupCate.Value + "/Default.aspx");

        }
    }
}