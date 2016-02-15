using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using BSO;
using System.Data;
using Telerik.Web.UI;
using System.Drawing;
using ETO;
using System.Text;

namespace CMS.Client.Admin
{
    public partial class MeDi_DoiTuong : System.Web.UI.UserControl
    {
        readonly Medi_QuanLyDoiTuongBSO _doituong = new Medi_QuanLyDoiTuongBSO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                LoadGrid_doiTuong();
            }

        }
        private void NavigationTitle(string url)
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            Modules modules = modulesBSO.GetModulesByUrl(url);
            imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }

        protected void LoadGrid_doiTuong()
        {
            DataTable dtDoiTuong = new DataTable();
            dtDoiTuong = _doituong.Get_DoiTuong();
            Grd_Doituong.DataSource = dtDoiTuong;
            Grd_Doituong.DataBind();
            //   Thongbao.Visible = false;

        }


        protected void RadGrid1_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
        {

        }
        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            // Thongbao.Visible = false;
            string comand = e.CommandName;
            GridEditCommandColumn editColumn = (GridEditCommandColumn)Grd_Doituong.MasterTableView.GetColumn("EditCommandColumn");
            switch (comand)
            {

                case "RebindGrid":
                    e.Canceled = false;
                    Thongbao.Visible = false;
                    break;
                case "Save":
                    // hàm save có 2 nhiệm vụ : 1 save, 2 là update nên để trong try catch được
                    string tenDoiTuong;
                    Thongbao.Visible = true;
                    int ID = (e.Item as GridDataItem) == null ? 0 : Convert.ToInt32((e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString());
                    if (ID == 0)
                    {
                        var doiTuongSave = e.Item as GridEditFormItem;
                        var doiTuongText = doiTuongSave.FindControl("txt_doituong") as TextBox;
                        tenDoiTuong = doiTuongText.Text;
                        // check không được nhập trắng
                        if (tenDoiTuong == "")
                        {
                            Thongbao.Text = "Tên đối tượng không được để trắng";
                            Thongbao.ForeColor = Color.Red;
                        }
                        else
                        {
                            // check trùng tên đối tượng
                            if (Convert.ToInt32(CheckTen(tenDoiTuong).ToString()) == 0)
                            {
                                _doituong.Insert_DoiTuong(tenDoiTuong);
                                Thongbao.Text = "Thêm mới đối tượng thành công";
                                Thongbao.ForeColor = Color.Blue;

                            }
                            else
                            {
                                Thongbao.Text = "Tên đối tượng đã tồn tại";
                                Thongbao.ForeColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        //edit
                        GridEditFormItem editform = (GridEditFormItem)((Telerik.Web.UI.GridDataItem)(e.Item)).EditFormItem;
                        TextBox txtbx = (TextBox)editform.FindControl("txt_doituong");
                        tenDoiTuong = txtbx.Text;
                        if (tenDoiTuong == "")
                        {
                            Thongbao.Text = "Tên đối tượng không được để trắng";
                            Thongbao.ForeColor = Color.Red;
                        }
                        else
                        {
                            if (Convert.ToInt32(CheckTen(tenDoiTuong).ToString()) == ID && Convert.ToInt32(CheckTen(tenDoiTuong).ToString()) != 0)
                            {
                                _doituong.update_DoiTuong(ID, tenDoiTuong);
                                Thongbao.Text = "Cập nhật đối tượng thành công";
                                Thongbao.ForeColor = Color.Blue;
                            }
                            else
                            {
                                Thongbao.Text = "Tên đối tượng đã tồn tại";
                                Thongbao.ForeColor = Color.Red;
                            }
                        }
                    }

                    LoadGrid_doiTuong();
                    break;

                case "Cancel":
                    e.Canceled = false;
                    Thongbao.Visible = false;
                    break;

                case "Apgia":
                    int Id = Convert.ToInt32((e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString());
                    Response.Redirect("~/Admin/Medi_ApGiaDoiTuong/" + Id + "/Default.aspx");
                    break;
                case "Delete":
                    Thongbao.Visible = false;
                    break;
                default:
                    break;
            }

        }
        protected void btnTongDV_Click(object sender, EventArgs e)
        {

            LoadGrid_doiTuong();

        }
        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            LoadGrid_doiTuong();
        }
        protected void RadGrid1_Databound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            {
                (e.Item.FindControl("txt_doituong") as TextBox).Focus();
            }
        }
        // lấy ID theo tên đối tượng
        private int CheckTen(string ten)
        {
            DataTable dtTen = new DataTable();
            dtTen = _doituong.Get_DoiTuong(ten);
            if (dtTen.Rows.Count > 0 && dtTen != null)
            {
                return Convert.ToInt32(dtTen.Rows[0]["ID"].ToString());
            }
            else
            {
                return 0;
            }
        }
    }
}