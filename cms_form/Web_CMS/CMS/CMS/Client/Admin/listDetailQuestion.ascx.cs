using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;
using System.Data;

namespace CMS.Client.Admin
{
    public partial class listDetailQuestion : System.Web.UI.UserControl
    {
        string strParam = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminBSO adminBSO = new AdminBSO();
            //Admin admin = new Admin();

            //admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());
            //RolesBSO roleBSO = new RolesBSO();
            //IRoles iRole = new IRoles();
            //btn_delall.Visible = false;
            //iRole = roleBSO.GetRolesById(admin.RolesID); //Thiet lap icon action cho nhom guest
            ListQuestionBSO listQuestionBSO_ = new ListQuestionBSO();
            string RolesName_ = listQuestionBSO_.RolesNameByUserName(Session["Admin_UserName"].ToString());
            if (RolesName_ == "Guest")
            {
                iconForUser();
            }

            if (Page.RouteData.Values["dll"] != null)
            {
                strParam = Page.RouteData.Values["Id"].ToString(); //p = parameter:
                int outValue;
                if (!int.TryParse(strParam, out outValue))
                    Response.Redirect("~/Admin/listquestion/Default.aspx");
                if (!string.IsNullOrEmpty(strParam))
                {
                    //-------------Kiem tra su ton tai cua User

                    listParentQuestionByID(int.Parse(strParam), RolesName_);
                    bindingContentQuestion(int.Parse(strParam), RolesName_);
                    listChildQuestionByParentID(int.Parse(strParam), RolesName_);
                    Label1.Text = "Xem câu trả lời";
                    //------------------------- Edit subQuestion
                    if (!string.IsNullOrEmpty(Page.RouteData.Values["subid"].ToString()))
                    {
                        int outCheck;
                        if (!int.TryParse(Page.RouteData.Values["subid"].ToString(), out outCheck))
                            Response.Redirect("~/Admin/listquestion/Default.aspx");
                        ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                        DataTable dt = new DataTable();
                        int subID = Convert.ToInt32(Page.RouteData.Values["subid"]);
                        //int subID = int.Parse(Page.RouteData.Values["subid"]);
                        dt = listQuestionBSO.GetQuestionByID(subID);
                        if (dt.Rows.Count > 0)
                        {
                            txtRadShort.Html = dt.Rows[0]["Question_Content"].ToString();
                            if (!string.IsNullOrEmpty(dt.Rows[0]["Question_FileAttach"].ToString()))
                                HiddenField_FileAttach.Value = dt.Rows[0]["Question_FileAttach"].ToString();
                            if (!string.IsNullOrEmpty(dt.Rows[0]["Question_Image"].ToString()))
                                HiddenField_ImageAttach.Value = dt.Rows[0]["Question_Image"].ToString();
                            txtRadShort.Focus();
                        }
                    }
                }
            }
            else
            {
                lbContentQuestion.Text = "Chưa có dữ liệu";
                lbDatePostQuestion.Text = "";
                lbQuestionTitle.Text = "";
                btnSend.Enabled = false;
                Label1.Text = "";
                txtRadShort.Enabled = false;
            }


        }
        private void iconForUser()
        {
            btn_enable.Visible = false;
            btn_disable.Visible = false;
            btn_delall.Visible = false;
        }
        private string GetCateParentIDArrayByID()
        {
            string strArrayID = "";

            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table1 = cateNewsBSO.GetCateGroupRoles(Language.language, 1, Session["Admin_UserName"].ToString());

            if (table1.Rows.Count > 0)
            {
                foreach (DataRow subrow in table1.Rows)
                {
                    strArrayID += subrow["CateNewsID"].ToString() + ",";
                }
            }
            return strArrayID;
        }
        private void bindingContentQuestion(int parentID, string RolesName_)
        {
            ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
            DataTable dt = new DataTable();
            dt = listQuestionBSO.listParentQuestionByID(parentID);

            DataView view1 = new DataView(dt);

            string strCate = GetCateParentIDArrayByID();
            ////-------------------Lay nhom Role
            AdminBSO adminBSO = new AdminBSO();
            if (RolesName_ == "Guest")
            {
                view1.RowFilter = "CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
            }
            else
                if (!string.IsNullOrEmpty(strCate))
                {
                    string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
                    //view1.RowFilter = "CateNewsID in('" + restr + "')";
                    view1.RowFilter = "CateNewsID in('" + restr + "') or CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
                }

            ETO.Admin userPostQuestion = new ETO.Admin();
            if (adminBSO.CheckExist(view1[0]["CreateUserName"].ToString()))
            {
                userPostQuestion = adminBSO.GetAdminById(view1[0]["CreateUserName"].ToString());
                lbContentQuestion.Text = view1[0]["Question_Content"].ToString();
                lbDatePostQuestion.Text = " gửi ngày: " + view1[0]["CreateDate"].ToString();
                lbQuestionTitle.Text = "Tiêu đề: <b>" + view1[0]["Question_Title"].ToString() + "</b>";
                lbUserPost.Text = "Người gửi: <b>" + userPostQuestion.AdminFullName.ToString() + "</b>, ";
                if (!string.IsNullOrEmpty(view1[0]["Question_Image"].ToString()))
                {
                    string strImgName = view1[0]["Question_Image"].ToString();
                    Literal_images.Text = "<span style='display: block;'>Hình đính kèm:</span>";
                    Literal_images.Text = "<a href='" + ResolveUrl("~/") + "Upload/Question/Images/" + strImgName + "' rel='lightbox' ><img src='" + ResolveUrl("~/") + "Upload/Question/Images/" + strImgName + "' class='image_album' width='120' align='left'  hspace='1' /></a>";
                }
                if (!string.IsNullOrEmpty(view1[0]["Question_fileAttach"].ToString()))
                {
                    string strFileAttch = view1[0]["Question_fileAttach"].ToString();
                    Literal_file.Text = "<span style='display: block;'>Tệp tin đính kèm:</span>";
                    Literal_file.Text += "<a href='" + ResolveUrl("~/") + "Upload/Question/Files/" + strFileAttch + "'  ><img src='" + ResolveUrl("~/") + "Images/icon_file.png' class='icon' width='30' hspace='1' /> Tải tệp tin đính kèm </a>";
                }
            }
            else
            {
                lbContentQuestion.Text = "";
                lbDatePostQuestion.Text = "";
                lbQuestionTitle.Text = "";
                lbUserPost.Text = "Người gửi câu hỏi không tồn tại!";

            }


        }
        private void listParentQuestionByID(int parentID, string RolesName_)
        {
            ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
            DataTable dt = new DataTable();
            dt = listQuestionBSO.listParentQuestionByID(parentID);

            DataView view1 = new DataView(dt);

            string strCate = GetCateParentIDArrayByID();

            if (RolesName_ == "Guest")
            {
                view1.RowFilter = "CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
                grvListQuestion.Columns[6].Visible = false;  //Hide column publish
                grvListQuestion.Columns[7].Visible = false;  //Hide column Action
                iconForUser(); //Hide icon for Guest
                //------------------Neu la khach && chu de bi khoa => hide textRadHtml va btn
                if (view1[0]["QuestionStatus"].ToString() == "3")
                {
                    txtRadShort.Visible = false;
                    btnSend.Visible = false;
                    btnCancel.Visible = false;
                    image_Attach.Visible = false;
                    file_Attach.Visible = false;
                    Label11.Visible = false;
                    Label6.Visible = false;
                    Label4.Visible = false;
                }
            }
            else
                if (!string.IsNullOrEmpty(strCate))
                {
                    string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
                    //view1.RowFilter = "CateNewsID in('" + restr + "')";
                    view1.RowFilter = "CateNewsID in('" + restr + "') or CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
                }
            //else
            //{
            //    if (RolesName_ == "Guest")
            //    {
            //        view1.RowFilter = "CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
            //        grvListQuestion.Columns[6].Visible = false;  //Hide column Action
            //        iconForUser(); //Hide icon for Guest
            //        //------------------Neu la khach && chu de bi khoa => hide textRadHtml va btn
            //        if (view1[0]["QuestionStatus"].ToString() == "3")
            //        {
            //            txtRadShort.Visible = false;
            //            btnSend.Visible = false;
            //            btnCancel.Visible = false;
            //            image_Attach.Visible = false;
            //            file_Attach.Visible = false;
            //            Label11.Visible = false;
            //            Label6.Visible = false;
            //            Label4.Visible = false;
            //        }
            //    }
            //}
            grvListQuestion.DataSource = view1;
            grvListQuestion.DataBind();
            //-----------------------Luu thong tin ve cau hoi
            HiddenField_CreateDate.Value = view1[0]["CreateDate"].ToString();
            HiddenField_CreateUserName.Value = view1[0]["CreateUserName"].ToString();
            HiddenField_QuestionStatus.Value = view1[0]["QuestionStatus"].ToString();
            HiddenField_CateNewsID.Value = view1[0]["CateNewsID"].ToString();
            HiddenField_Question_Title.Value = view1[0]["Question_Title"].ToString();
            HiddenField_QuestionID.Value = view1[0]["Question_ID"].ToString();
        }
        private void listChildQuestionByParentID(int ParentID, string RolesName_)
        {
            ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
            DataTable dt = new DataTable();
            dt = listQuestionBSO.listChildQuestionByParentID(ParentID);

            DataView view1 = new DataView(dt);

            string strCate = GetCateParentIDArrayByID();

            if (RolesName_ == "Guest")
            {
                view1.RowFilter = "CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
                GridView1.Columns[1].Visible = false; //Hide column Action
                GridView1.Columns[2].Visible = false; //Hide column Action
            }
            else
                if (!string.IsNullOrEmpty(strCate))
                {
                    string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");

                    view1.RowFilter = "CateNewsID in('" + restr + "')";
                }

            GridView1.DataSource = view1;
            GridView1.DataBind();

        }
        private void listAllQuestionOfRoom()
        {
            ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
            DataTable dt = new DataTable();
            dt = listQuestionBSO.GetListQuestionAll();

            DataView view1 = new DataView(dt);

            string strCate = GetCateParentIDArrayByID();
            if (!string.IsNullOrEmpty(strCate))
            {
                string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");

                view1.RowFilter = "CateNewsID in('" + restr + "')";

                grvListQuestion.DataSource = view1;
                grvListQuestion.DataBind();
            }
        }
        private void listQuestionStatus(int opt)
        {
            ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
            DataTable dt = new DataTable();
            dt = listQuestionBSO.GetListQuestionStausID(int.Parse(strParam));

            DataView view1 = new DataView(dt);

            string strCate = GetCateParentIDArrayByID();
            if (!string.IsNullOrEmpty(strCate))
            {
                string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");

                view1.RowFilter = "CateNewsID in('" + restr + "')";

                grvListQuestion.DataSource = view1;
                grvListQuestion.DataBind();
            }
        }
        #region ReceiveHtml
        private ListQuestion ReceiveHtml_()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int thumb_w = Convert.ToInt32(config.New_thumb_w);
            int thumb_h = Convert.ToInt32(config.New_thumb_h);

            commonBSO commonBSO = new commonBSO();
            string path_thumb = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Question/Images/";
            string image_thumb = commonBSO.UploadImage(image_Attach, path_thumb, thumb_w, thumb_h);

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Question/Files/";
            string file_upload = commonBSO.UploadFile(file_Attach, path, 18000000000);

            ListQuestion listQuestion = new ListQuestion();

            //Cau hoi moi: Co lay thong tin tu cau hoi parent        
            listQuestion.Question_ParentID = Convert.ToInt32(Page.RouteData.Values["Id"]);
            listQuestion.CateNewsID = int.Parse(HiddenField_CateNewsID.Value.ToString());
            listQuestion.Question_Title = "Trả lời: " + HiddenField_Question_Title.Value.ToString();
            listQuestion.CreateDate = DateTime.Parse(HiddenField_CreateDate.Value.ToString());
            listQuestion.CreateUserName = HiddenField_CreateUserName.Value.ToString();

            //-------------Noi dung lay tu form        
            listQuestion.Question_Content = txtRadShort.Html;
            listQuestion.Question_FileAttach = (file_upload != "") ? file_upload : HiddenField_FileAttach.Value;
            listQuestion.Question_Image = (image_thumb != "") ? image_thumb : HiddenField_ImageAttach.Value;

            listQuestion.IsApproval = false; //Chua duoc duyet
            listQuestion.ApprovalUserName = Session["Admin_UserName"].ToString();
            listQuestion.QuestionStatus = 2; //Cau hoi da tra loi
            listQuestion.ApprovalDate = DateTime.Now; //Ngay phe duyet

            if (Page.RouteData.Values["Id"] != null) //Truong hop edit cau hoi, nhung thong tin duoc fix
            {
                //listQuestion.Question_ID = Id;
                //listQuestion.QuestionStatus = int.Parse(HiddenField_QuestionStatus.Value);
                //listQuestion.CreateDate = DateTime.Parse(HiddenField_CreateDate.Value);
                //listQuestion.CreateUserName = HiddenField_CreateUserName.Value;
            }
            return listQuestion;
        }
        #endregion
        protected void btnSend_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Page.RouteData.Values["subid"].ToString())) //Update record
            {
                ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                if (!string.IsNullOrEmpty(txtRadShort.Html))
                {
                    ConfigBSO configBSO = new ConfigBSO();
                    Config config = configBSO.GetAllConfig(Language.language);
                    int thumb_w = Convert.ToInt32(config.New_thumb_w);
                    int thumb_h = Convert.ToInt32(config.New_thumb_h);
                    ListQuestion listQuestionUpdate = new ListQuestion();

                    commonBSO commonBSO = new commonBSO();
                    string path_thumb = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Question/Images/";
                    string image_thumb = commonBSO.UploadImage(image_Attach, path_thumb, thumb_w, thumb_h);

                    string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Question/Files/";
                    string file_upload = commonBSO.UploadFile(file_Attach, path, 18000000000);
                    string strFile = (file_upload != "") ? file_upload : HiddenField_FileAttach.Value;
                    string strImage = (image_thumb != "") ? image_thumb : HiddenField_ImageAttach.Value;

                    listQuestionBSO.UpdateSubQuestion(Convert.ToInt32(Page.RouteData.Values["subid"]), txtRadShort.Html, strImage, strFile);
                    txtRadShort.Html = "";
                    //clientview.Text = strFile;
                }
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
                Response.Redirect("~/Admin/listdetailquestion/" + HiddenField_QuestionID.Value.ToString() + "/Default.aspx");
                //initControl(Id);
            }
            else //Addnew record
            {
                ListQuestion listQuestion = ReceiveHtml_();
                ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                if (!string.IsNullOrEmpty(listQuestion.Question_Content))
                {
                    listQuestionBSO.CreateListQuestion(listQuestion);
                }
                else
                {
                    //hien thong bao yeu cau nhap noi dung
                }
                //clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);         

                string strID = HiddenField_QuestionID.Value.ToString() + ",";
                //Cap nhat lai trang thai cau hoi doi voi cau hoi parent
                //Kiem tra user_Name login ? user_name CreateQuestion
                if (Session["Admin_UserName"].ToString() != HiddenField_CreateUserName.Value)
                {
                    //Cap nhat status = 2: Da xu ly
                    listQuestionBSO.UpdateQuestionStatus(strID, 2);
                    //----Gui mail thong bao den khach hang khi co cau tra loi
                    //------Lay userName
                    sendMailToUser(listQuestion);
                }
                else
                {
                    //Cap nhat status = 0: cau hoi moi
                    listQuestionBSO.UpdateQuestionStatus(strID, 0);
                    //Gui mail den nhom support khi khach hang reply
                    sendMailToGroup(listQuestion);
                    //------------ Gui email thong bao den nhom nhom support cua tung san pham              
                }
                Response.Redirect("~/Admin/listdetailquestion/" + HiddenField_QuestionID.Value.ToString() + "/Default.aspx");
            }

        }
        private void sendMailToGroup(ListQuestion lstQuestion)
        {
            /* ------------- Gui email den nguoi co trach nhiem tra loi cau hoi --*/
            string strObj = "Ban nhan duoc yeu cau ho tro tu khach hang cua EVNIT. Ngay gui: " + DateTime.Now.ToString("dd/MM/yyyy");
            string strBody = "Khách hàng có gửi cho bạn một yêu cầu hỗ trợ.<br /><br/>";
            strBody += "<i>Tiêu đề : </i><strong>" + lstQuestion.Question_Title + "</strong><br/>";
            strBody += "<span><i>Nội dung: </i><br /></span>";
            strBody += "<div style='margin-left: 20px; font-size: 11pt; border-left: 3px solid green; padding: 5px;'>";
            strBody += lstQuestion.Question_Content;
            strBody += "</div>";
            strBody += "<div style='border-bottom: 1px dashed red; width: 500px; height: 20px;'/>";
            strBody += "<p>Trang hỗ trợ sản phẩm dịch vụ EVNIT <strong> http://support.evn.com.vn</strong></p>";

            MailBSO mailBSO = new MailBSO();
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            mailBSO.EmailFrom = config.Email_from;

            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            CateNews cateNews = new CateNews();
            cateNews = cateNewsBSO.GetCateNewsById(int.Parse(HiddenField_CateNewsID.Value.ToString())); //list user of product           


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
            string strObj = "Ban nhan duoc cau tra loi tu trang ho tro khach hang cua EVNIT (" + DateTime.Now.ToString("dd/MM/yyyy") + ")";
            string strBody = "";
            strBody += "<i>Tiêu đề : </i><strong>" + lstQuestion.Question_Title + "</strong><br/>";
            strBody += "<span><i>Nội dung: </i><br /></span>";
            strBody += "<div style='margin-left: 20px; font-size: 11pt; border-left: 3px solid green; padding: 5px;'>";
            strBody += lstQuestion.Question_Content;
            //strBody += "<br/><br/><b>Để việc trao đổi giữa chúng tôi và quý khách được nhanh chóng và chính xác, vui lòng phản hồi theo cách sau:</b>";
            //strBody += "<br>Sử dụng tài khoản đã đăng ký để đăng nhập vào trang http://support.evn.com.vn, truy cập vào mục quản trị và quản lý danh sách các câu hỏi của quý khách ";
            strBody += "</div>";
            strBody += "<div style='border-bottom: 1px dashed red; width: 500px; height: 20px;'/>";
            strBody += "<p>Trang hỗ trợ sản phẩm dịch vụ EVNIT <strong>http://support.evn.com.vn</strong></p>";


            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin adminUser = new ETO.Admin();
            adminUser = adminBSO.GetAdminById(HiddenField_CreateUserName.Value.ToString());

            MailBSO mailBSO = new MailBSO();
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            mailBSO.EmailFrom = config.Email_from;
            mailBSO.SendMail(adminUser.AdminEmail, strObj, strBody);
        }
        private void ViewCateNews()
        {
            ListQuestionBSO listQuestionBSO_ = new ListQuestionBSO();
            string RolesName_ = listQuestionBSO_.RolesNameByUserName(Session["Admin_UserName"].ToString());
            if (Page.RouteData.Values["dll"] != null)
            {
                strParam = Page.RouteData.Values["Id"].ToString(); //p = parameter:
                if (!string.IsNullOrEmpty(strParam))
                {
                    listParentQuestionByID(int.Parse(strParam), RolesName_);
                    listChildQuestionByParentID(int.Parse(strParam), RolesName_);
                    bindingContentQuestion(int.Parse(strParam), RolesName_);
                }
            }
        }


        protected void btn_enable_Click(object sender, EventArgs e)
        {
            if (PagesID() != "")
            {
                //PagesBSO pagesBSO = new PagesBSO();
                //pagesBSO.PagesUpdate(PagesID(), "1");
                ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                listQuestionBSO.UpdateQuestionStatus(PagesID(), 1);

                if (Page.RouteData.Values["p"] == "all") //p = parameter:
                    listAllQuestionOfRoom();
                else
                    listQuestionStatus(int.Parse(strParam));
            }
            //PagesView(hddGroup.Value);
        }
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            if (PagesID() != "")
            {
                //PagesBSO pagesBSO = new PagesBSO();
                //pagesBSO.PagesUpdate(PagesID(), "0");
                ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                listQuestionBSO.UpdateQuestionStatus(PagesID(), 3);
                listQuestionStatus(int.Parse(strParam));
                Response.Redirect("~/Admin/p/listQuestion/all/Default.aspx");
            }

            //PagesView(hddGroup.Value);
        }

        protected void btn_enable_approval_Click(object sender, EventArgs e)
        {
            if (PagesID() != "")
            {
                ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                //listQuestionBSO.UpdateQuestionStatus(PagesID(), 1);

                //PagesBSO pagesBSO = new PagesBSO();
                //pagesBSO.PagesUpdate(PagesID(), "1", Session["Admin_UserName"].ToString(), DateTime.Now);
            }

            //PagesView(hddGroup.Value);

        }
        protected void btn_disable_approval_Click(object sender, EventArgs e)
        {
            if (PagesID() != "")
            {
                //PagesBSO pagesBSO = new PagesBSO();
                //pagesBSO.PagesUpdate(PagesID(), "0", Session["Admin_UserName"].ToString(), DateTime.Now);
            }

            //PagesView(hddGroup.Value);
        }
        protected void btn_delAll_Click(object sender, EventArgs e)
        {
            if (PagesID() != "")
            {
                //PagesBSO pagesBSO = new PagesBSO();
                //pagesBSO.DeletePages(PagesID());
            }
            //PagesView(hddGroup.Value);
        }
        #region PagesID
        private string PagesID()
        {
            string pagesId = "";
            foreach (GridViewRow rows in grvListQuestion.Rows)
            {
                CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
                if (checkbox.Checked)
                    pagesId += rows.Cells[0].Text + ",";
            }
            return pagesId;
        }
        #endregion
        protected void grvListQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");
                ImageButton image_publish = (ImageButton)e.Row.FindControl("btn_publish");
                image_publish.Attributes.Add("onclick", "return confirm('Xuất bản');");
                ImageButton image_unpublish = (ImageButton)e.Row.FindControl("btn_unPublish");
                image_unpublish.Attributes.Add("onclick", "return confirm('Ngừng xuất bản');");
                Label lb_IsPublish = (Label)e.Row.FindControl("lb_IsPublish");

                image_unpublish.Visible = false;
                image_publish.Visible = false;

                if (!string.IsNullOrEmpty(lb_IsPublish.Text))
                {
                    if (lb_IsPublish.Text == "True")
                        //image_publish.Visible = true;
                        image_unpublish.Visible = true;
                    else
                        if (lb_IsPublish.Text == "False")
                            //image_publish.Visible = true;
                            image_publish.Visible = true;
                }

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strStatus = e.Row.Cells[5].Text;
                switch (strStatus)
                {
                    case "0":
                        e.Row.Cells[5].Text = "<div style='color:Red; font-weight: bold;text-align: center;'>Mới gửi</div>";
                        break;
                    case "1":
                        e.Row.Cells[5].Text = "<div style='color:Orange; font-weight: bold;text-align: center;'>Đang xử lý</div>";
                        break;
                    case "2":
                        e.Row.Cells[5].Text = "<div style='color:Green; font-weight: bold;text-align: center;'>Đã trả lời</div>";
                        break;
                    case "3":
                        e.Row.Cells[5].Text = "<div style='color:DarkGrey; font-weight: bold;text-align: center;'>Đã khoá</div>";
                        break;
                    default:
                        e.Row.Cells[5].Text = "-";
                        break;
                }
            }
        }
        protected bool isNull(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            else
                return false;
        }
        protected void grvListQuestion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string cName = e.CommandName.ToLower();
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            ListQuestionBSO listQuestionBSO = new ListQuestionBSO();

            switch (cName)
            {
                case "_view":
                    break;
                case "_publish":
                    listQuestionBSO.updateStatusPublishQuestion(Id, 1);
                    Response.Redirect("~/Admin/listdetailquestion/" + Id + "/Default.aspx");
                    break;
                case "_unpublish":
                    listQuestionBSO.updateStatusPublishQuestion(Id, 0);
                    Response.Redirect("~/Admin/listdetailquestion/" + Id + "/Default.aspx");

                    break;
                case "_edit":
                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());
                    //if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        Response.Redirect("~/Admin/editquestion/" + Id + "/Default.aspx");
                    }

                    break;
                case "_delete":
                    listQuestionBSO.deleteQuestionByID(Id);
                    Response.Redirect("~/Admin/p/listquestion/0/Default.aspx");
                    break;
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete_sub");
                image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");
                ImageButton image_publish = (ImageButton)e.Row.FindControl("btn_publish");
                image_publish.Attributes.Add("onclick", "return confirm('Xuất bản');");
                ImageButton image_unpublish = (ImageButton)e.Row.FindControl("btn_unPublish");
                image_unpublish.Attributes.Add("onclick", "return confirm('Ngừng xuất bản');");
                Label lb_IsPublish = (Label)e.Row.FindControl("lb_IsPublish");

                image_unpublish.Visible = false;
                image_publish.Visible = false;

                if (!string.IsNullOrEmpty(lb_IsPublish.Text))
                {
                    if (lb_IsPublish.Text == "True")
                        //image_publish.Visible = true;
                        image_unpublish.Visible = true;
                    else
                        if (lb_IsPublish.Text == "False")
                            //image_publish.Visible = true;
                            image_publish.Visible = true;
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label Imgthumb1 = (Label)e.Row.FindControl("Literal_images11");
                Literal ltlImageThumb1 = (Literal)e.Row.FindControl("Literal_images1");
                if (Imgthumb1.Text != "")
                    ltlImageThumb1.Text = "<span style='display: block;'>Hình đính kèm:</span><a href='" + ResolveUrl("~/") + "Upload/Question/Images/" + Imgthumb1.Text + "' rel='lightbox' ><img src='" + ResolveUrl("~/") + "Upload/Question/Images/" + Imgthumb1.Text + "' class='image_album' width='200' height='200' align='left'  hspace='1' /></a>";

                Label lb_files = (Label)e.Row.FindControl("lb_files");
                Literal ltlFiles = (Literal)e.Row.FindControl("Literal_files");
                if (lb_files.Text != "")
                    ltlFiles.Text = @"<span style='display: block;'>Tệp đính kèm:</span><img src='" + ResolveUrl("~/") + "Images/icon_file.png' class='icon' width='30' hspace='1' /> <a href='" + ResolveUrl("~/") + "Upload/Question/Files/" + lb_files.Text + "'  >Tải tệp tin đính kèm </a>";
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString()); //subID question
            string cName = e.CommandName.ToLower();
            //------------- Lay ParentID

            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
            DataTable dt = new DataTable();
            string strParentID = "";
            dt = listQuestionBSO.GetQuestionByID(Id);
            if (dt.Rows.Count > 0)
                strParentID = dt.Rows[0]["Question_ParentID"].ToString();

            switch (cName)
            {
                case "_view_sub":
                    break;
                case "_publish":
                    listQuestionBSO.updateStatusPublishQuestion(Id, 1);
                    Response.Redirect("~/Admin/listdetailquestion&Id=" + strParentID + "/Default.aspx");
                    break;
                case "_unpublish":
                    listQuestionBSO.updateStatusPublishQuestion(Id, 0);
                    Response.Redirect("~/Admin/listdetailquestion&Id=" + strParentID + "/Default.aspx");
                    break;
                case "_edit_sub":
                    {
                        Response.Redirect("~/Admin/s/listdetailquestion/" + strParentID + "/" + Id + "/Default.aspx");
                        break;
                    }
                case "_delete_sub":
                    {
                        listQuestionBSO.deleteQuestionByID(Id);
                        Response.Redirect("~/Admin/p/listquestion/0/Default.aspx");
                        break;
                    }
            }
        }

    }
}