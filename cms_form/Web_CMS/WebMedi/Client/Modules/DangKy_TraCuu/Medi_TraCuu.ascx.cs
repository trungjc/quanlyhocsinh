using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Drawing;
using System.Data;

namespace WebMedi.Client.Modules.DangKy_TraCuu
{
    public partial class Medi_TraCuu : System.Web.UI.UserControl
    {
        protected string InputValue { get; set; }
        enum PageAction { Default, Error }
        Medi_PhieuXetNghiemBSO pxnBSO = new Medi_PhieuXetNghiemBSO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowControl(PageAction.Default);
            }
            ViewWelcome(Language.language);
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Home' class='content_Text_Cat'>" + Resources.Resource.Home + "</a>  &nbsp;>&nbsp;";
        }
        #region initialize
        private void ViewWelcome(string lang)
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(lang);
        }
        #endregion

        protected void btnTraCuu_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string maPhieu = txt_MaPhieu.Text.Trim();
            string maPin = txt_MaPin.Text.Trim();
            if (maPhieu == "" || maPin == "")
            {
                ShowControl(PageAction.Error);
            }
            else
            {
                dt = pxnBSO.GetKQ_XetNghiem(maPhieu, maPin);
                if (dt.Rows.Count > 0)
                {
                    string filePath = dt.Rows[0]["Filepath"].ToString().Trim();
                    InputValue = filePath;
                    lblThongBao.ForeColor = Color.Blue;
                    pn_KQXN.Visible = true;
                    lblThongBao.Text = "Tra cứu thành công. Bạn có thể xem và tải kết quả tại khung PDF bên dưới.";
                }
                else
                {
                    pn_KQXN.Visible = true;
                    lblThongBao.ForeColor = Color.Blue;
                    lblThongBao.Text = "Chào quý khách. Quý khách vui lòng kiểm tra lại thông tin vừa nhập nếu chính xác thì hiện tại chưa có kết quả cho lần xét nghiệm này. Trung tâm sẽ thông báo cho quý khách ngay khi có kết quả. <br/> Cảm ơn quý khách.";
                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            ShowControl(PageAction.Default);
        }
        private void ShowControl(PageAction pageAction)
        {
            switch (pageAction)
            {
                case PageAction.Default:
                    //ẩn nút gì hiện nút gì ở đây
                    txt_MaPhieu.Text = "" ;
                    txt_MaPin.Text = "";
                    break;
                case PageAction.Error:
                    pn_KQXN.Visible = true;
                    lblThongBao.ForeColor = Color.Red;
                    lblThongBao.Text = "Tra cứu không thành công. Quý khách vui lòng nhập đầy đủ thông tin Mã phiếu và Mã pin";
                    break;
            }
        }
    }

}