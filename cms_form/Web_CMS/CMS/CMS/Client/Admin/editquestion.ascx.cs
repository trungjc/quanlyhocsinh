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
    public partial class editquestion : System.Web.UI.UserControl
    {
        int Id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);

            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                ViewCateNews(); //Khoi tao du lieu ban dau
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
            int group = 1;
            //lay thong tin cua user login
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());
            lbFullName.Text = admin.AdminFullName.ToString();
            lbEmail.Text = admin.AdminEmail.ToString();


            ddlCateNews.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateParentGroupAll(0, Language.language, group);

            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateNews, table, "", "", "CateNewsName", "CateNewsID", "");
        }
        #endregion

        #region initControl
        private void initControl(int Id)
        {
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            if (Id > 0)
            {
                //if (!Session["Admin_UserName"].ToString().Equals("administrator"))
                //{
                //    ddlCateNews.Enabled = false;
                //}
                ListQuestion listQuestion = new ListQuestion();
                ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                listQuestion = listQuestionBSO.GetListQuestionByID(Id);
                txtTitle.Text = listQuestion.Question_Title;
                HiddenField_FileAttach.Value = listQuestion.Question_FileAttach;
                HiddenField_ImageAttach.Value = listQuestion.Question_Image;
                HiddenField_QuestionID.Value = Id.ToString();
                HiddenField_QuestionStatus.Value = listQuestion.QuestionStatus.ToString();
                HiddenField_CreateUserName.Value = listQuestion.CreateUserName;
                HiddenField_CreateDate.Value = listQuestion.CreateDate.ToString();
                txtRadShort.Html = listQuestion.Question_Content;
                ddlCateNews.SelectedValue = Convert.ToString(listQuestion.CateNewsID);
            }
        }
        #endregion

        #region ReceiveHtml
        private ListQuestion ReceiveHtml_()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int thumb_w = Convert.ToInt32(config.New_large_w);
            int thumb_h = Convert.ToInt32(config.New_large_h);

            commonBSO commonBSO = new commonBSO();
            string path_thumb = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Question/Images/";
            string image_thumb = commonBSO.UploadImage(image_Attach, path_thumb, thumb_w, thumb_h);

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Question/Files/";
            string file_upload = commonBSO.UploadFile(file_Attach, path, 18000000000);

            ListQuestion listQuestion = new ListQuestion();

            //Cau hoi moi
            listQuestion.CateNewsID = Convert.ToInt32(ddlCateNews.SelectedValue);
            listQuestion.Question_Title = txtTitle.Text.Trim();
            listQuestion.Question_Content = txtRadShort.Html;
            listQuestion.CreateUserName = Session["Admin_UserName"].ToString();
            listQuestion.Question_FileAttach = (file_upload != "") ? file_upload : HiddenField_FileAttach.Value;
            listQuestion.Question_Image = (image_thumb != "") ? image_thumb : HiddenField_ImageAttach.Value;
            listQuestion.CreateDate = DateTime.Now;
            listQuestion.IsApproval = false; //Chua duoc duyet
            listQuestion.ApprovalUserName = "";
            listQuestion.QuestionStatus = 0;
            listQuestion.ApprovalDate = DateTime.Now;

            if (Page.RouteData.Values["Id"] != null)
            {
                listQuestion.Question_ID = Convert.ToInt32(HiddenField_QuestionID.Value);
                listQuestion.QuestionStatus = int.Parse(HiddenField_QuestionStatus.Value);
                listQuestion.CreateDate = DateTime.Parse(HiddenField_CreateDate.Value);
                listQuestion.CreateUserName = HiddenField_CreateUserName.Value;
            }

            return listQuestion;
        }
        #endregion

        protected void btnSend_Click(object sender, EventArgs e)
        {
            ListQuestion listQuestion = ReceiveHtml_();
            ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
            if (Page.RouteData.Values["Id"] != null) //Update record
            {
                if (!string.IsNullOrEmpty(listQuestion.Question_Content) && !string.IsNullOrEmpty(listQuestion.Question_Title))
                {
                    listQuestionBSO.UpdatelistQuestion(listQuestion);
                    clientview.Text = "Cập nhật thành công";
                    ViewCateNews();
                    initControl(Id);
                }
            }
            else //Addnew record
            {
                //ListQuestion listQuestion = ReceiveHtml_();
                //ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                if (!string.IsNullOrEmpty(listQuestion.Question_Content) && !string.IsNullOrEmpty(listQuestion.Question_Title))
                {
                    listQuestionBSO.CreateListQuestion(listQuestion);
                    clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);

                    //------------ Gui email thong bao den nhom nhom support cua tung san pham

                    sendMailToGroup(listQuestion);

                    //-------------Gui email thong bao toi nguoi gui
                    sendMailToUser(listQuestion);
                    //Response.Redirect("Homepage.aspx?dll=listquestion&p=0");
                }
            }
        }
        private void sendMailToGroup(ListQuestion lstQuestion)
        {
            /* ------------- Gui email den nguoi co trach nhiem tra loi cau hoi --*/
            string strObj = "Ban nhan duoc yeu cau ho tro tu khach hang cua EVNIT. Ngay gui: " + DateTime.Now.ToString("dd/MM/yyyy");
            string strBody = "Khách hàng có gửi cho bạn một yêu cầu hỗ trợ.<br /><br/>";
            strBody += "<i>Tiêu đề : </i><strong>" + lstQuestion.Question_Title + "</strong><br/>";
            strBody += "<span><i>Nội dung:</i><br /></span>";
            strBody += "<div style='margin-left: 20px; font-size: 11pt; border-left: 3px solid green; padding: 5px;'>";
            strBody += lstQuestion.Question_Content;
            strBody += "</div>";
            strBody += "<div style='border-bottom: 1px dashed red; width: 500px; height: 20px;'/>";
            strBody += "<p>Trang hỗ trợ sản phẩm dịch vụ EVNIT <strong>http://support.evn.com.vn</strong></p>";


            MailBSO mailBSO = new MailBSO();
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            mailBSO.EmailFrom = config.Email_from;

            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            CateNews cateNews = new CateNews();
            cateNews = cateNewsBSO.GetCateNewsById(int.Parse(ddlCateNews.SelectedValue.ToString())); //list user of product           

            //Get list email
            AdminBSO adminBSO = new AdminBSO();
            DataTable dtUser = new DataTable();
            dtUser = adminBSO.GetAllAdmin();
            if (dtUser.Rows.Count > 0)
            {
                DataView view1 = new DataView(dtUser);
                string strUser = cateNews.Roles;
                strUser = strUser.Remove(strUser.LastIndexOf(",")).Replace(",", "','");
                view1.RowFilter = "Admin_UserName in('" + strUser + "')";
                dtUser = view1.ToTable();

                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    //clientview.Text += dtUser.Rows[i]["Admin_Email"].ToString();
                    mailBSO.SendMail(dtUser.Rows[i]["Admin_Email"].ToString(), strObj, strBody);
                    //sendMailToGroup(dtUser.Rows[i]["Admin_Email"].ToString().Trim()); //Gui mai den nhom support cua san pham                
                }
            }
            /* ------------- End Gui email den nguoi co trach nhiem tra loi cau hoi --*/
        }

        private void sendMailToUser(ListQuestion lstQuestion)
        {
            /* ------------- Gui email den nguoi gui cau hoi --*/
            string strObj = "Yeu cau cua ban da duoc gui thanh cong den trang Support EVNIT. Ngay gui: " + DateTime.Now.ToString("dd/MM/yyyy");
            string strBody = "Câu hỏi đã được gửi thành công tới người Quản lý sản phẩm";
            strBody += "<br><i>Tiêu đề : </i><strong>" + lstQuestion.Question_Title + "</strong><br/>";
            strBody += "<span><i>Nội dung:</i><br /></span>";
            strBody += "<div style='margin-left: 20px; font-size: 11pt; border-left: 3px solid green; padding: 5px;'>";
            strBody += lstQuestion.Question_Content;
            strBody += "</div><p style='font-size: 10pt;'><b>Để xem danh sách các câu hỏi đã gửi và câu trả lời xin thực hiện theo các bước:</b>";
            strBody += "<br>Đăng nhập vào trang http://support.evn.com.vn -> truy cập mục Quản trị.";
            strBody += "</p>";
            strBody += "<div style='border-bottom: 1px dashed red; width: 500px; height: 20px;'/>";
            strBody += "<p>Trang hỗ trợ sản phẩm dịch vụ EVNIT <strong>http://support.evn.com.vn</strong></p>";

            ETO.Admin adminUser = new ETO.Admin();
            AdminBSO adminBSO = new AdminBSO();
            adminUser = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

            MailBSO mailBSO = new MailBSO();
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            mailBSO.EmailFrom = config.Email_from;
            mailBSO.SendMail(adminUser.AdminEmail, strObj, strBody);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/p/listquestion/0/Default.aspx");
        }

    }
}