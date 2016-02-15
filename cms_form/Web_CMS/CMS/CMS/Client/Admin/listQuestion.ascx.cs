using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;
using Telerik.Web.UI;
using System.Data;

namespace CMS.Client.Admin
{
    public partial class listQuestion : System.Web.UI.UserControl
    {
        string strParam = "";
        //string GroupName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();


        }

        private void loadData()
        {
            ListQuestionBSO listQuestionBSO_ = new ListQuestionBSO();
            string RolesName_ = listQuestionBSO_.RolesNameByUserName(Session["Admin_UserName"].ToString());
            if (Page.RouteData.Values["dll"] != null)
            {
                btn_delall.Visible = false;
                strParam = Page.RouteData.Values["p"].ToString(); //p = parameter:
                switch (strParam)
                {
                    case "0":
                        Label1.Text = "Yêu cầu mới gửi";
                        listQuestionStatus(int.Parse(strParam), RolesName_);
                        break;
                    case "1":
                        Label1.Text = "Yêu cầu đang xử lý";
                        listQuestionStatus(int.Parse(strParam), RolesName_);
                        break;
                    case "2":
                        Label1.Text = "Yêu cầu đã được trả lời";
                        listQuestionStatus(int.Parse(strParam), RolesName_);
                        break;
                    case "3":
                        Label1.Text = "Yêu cầu đã kết thúc";
                        listQuestionStatus(int.Parse(strParam), RolesName_);
                        break;
                    case "all":
                        Label1.Text = "Tất các câu hỏi đã gửi";
                        listAllQuestionOfRoom(RolesName_);
                        break;
                    default:
                        Label1.Text = "";
                        listAllQuestionOfRoom(RolesName_);
                        break;
                }
            }
            //AdminBSO adminBSO = new AdminBSO();
            //Admin admin = new Admin();
            //admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());
            //RolesBSO roleBSO = new RolesBSO();
            //IRoles iRole = new IRoles();



            //iRole = roleBSO.GetRolesById(admin.RolesID);
            if (RolesName_ == "Guest")
            {
                iconForUser();
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
        private void listAllQuestionOfRoom(string RolesName_)
        {
            ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
            DataTable dt = new DataTable();
            dt = listQuestionBSO.GetListQuestionAll();

            DataView view1 = new DataView(dt);

            string strCate = GetCateParentIDArrayByID(); //Lay danh sach ID cua cac san pham        
            if (RolesName_ == "Guest")
            {
                view1.RowFilter = "CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
                grvListQuestion.Columns[6].Visible = false;
                iconForUser();
            }
            else
                if (!string.IsNullOrEmpty(strCate))
                {
                    string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
                    if (RolesName_ == "mod") //Nguoi quan ly nhom san pham
                    {
                        view1.RowFilter = "CateNewsID in('" + restr + "') or CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
                    }
                }
            //else
            //{
            //    if (RolesName_ == "Guest")
            //    {
            //        view1.RowFilter = "CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
            //        grvListQuestion.Columns[6].Visible = false;
            //        iconForUser();
            //    }
            //}
            grvListQuestion.DataSource = view1;
            grvListQuestion.DataBind();

        }

        private void listQuestionStatus(int opt, string RolesName_)
        {
            ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
            DataTable dt = new DataTable();
            dt = listQuestionBSO.GetListQuestionStausID(int.Parse(strParam));

            DataView view1 = new DataView(dt);
            string strCate = GetCateParentIDArrayByID();

            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();

            if (RolesName_ == "Guest")
            {
                view1.RowFilter = "CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
                grvListQuestion.Columns[6].Visible = false;
                iconForUser();
            }
            else
                if (!string.IsNullOrEmpty(strCate))
                {
                    string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");

                    if (RolesName_ != "Guest") //
                    {
                        //view1.RowFilter = "CateNewsID in('" + restr + "')";
                        view1.RowFilter = "CateNewsID in('" + restr + "') or CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
                        //grvListQuestion.Columns[6].Visible = false;
                        //iconForUser();
                    }

                }
            //else
            //{
            //    if (RolesName_ == "Guest")
            //    {
            //        view1.RowFilter = "CreateUserName ='" + Session["Admin_UserName"].ToString() + "'";
            //        grvListQuestion.Columns[6].Visible = false;
            //        iconForUser();
            //    }
            //}
            grvListQuestion.DataSource = view1;
            grvListQuestion.DataBind();
        }
        protected void btn_enable_Click(object sender, EventArgs e)
        {
            ListQuestionBSO listQuestionBSO_ = new ListQuestionBSO();
            string RolesName_ = listQuestionBSO_.RolesNameByUserName(Session["Admin_UserName"].ToString());
            if (PagesID() != "")
            {

                ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                listQuestionBSO.UpdateQuestionStatus(PagesID(), 1);

                if (Page.RouteData.Values["p"].ToString() == "all") //p = parameter:
                    listAllQuestionOfRoom(RolesName_);
                else
                    listQuestionStatus(int.Parse(strParam), RolesName_);
            }
        }
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            if (PagesID() != "")
            {
                ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                listQuestionBSO.UpdateQuestionStatus(PagesID(), 3);
                loadData();
                //listQuestionStatus(3); //Cac cau hoi bi khoa
            }


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

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgBtnUnLock = (ImageButton)e.Row.FindControl("btn_unLockQuestion");
                ImageButton imgBtnLock = (ImageButton)e.Row.FindControl("btn_lockQuestion");

                imgBtnLock.Visible = true;
                imgBtnUnLock.Visible = false;

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
                        imgBtnLock.Visible = false;
                        imgBtnUnLock.Visible = true;
                        break;
                    default:
                        e.Row.Cells[5].Text = "-";

                        break;
                }
            }
        }
        protected void grvListQuestion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string cName = e.CommandName.ToLower();
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            switch (cName)
            {
                case "_view":
                    break;
                case "_edit":
                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    //if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        Response.Redirect("~/Admin/editquestion/" + Id + "/Default.aspx");
                    }
                    //else
                    {
                        //  Response.Redirect("~/Homepage.aspx?dll=listnews");
                    }

                    break;
                case "_lockquestion": //Cap nhat status = 3 => cau hoi da ket thuc
                    {
                        ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                        string strID = Id.ToString() + ",";
                        listQuestionBSO.UpdateQuestionStatus(strID, 3);
                        loadData();
                        break;
                    }

                case "_unlockquestion": //Cap nhat status = 1 => Dang xu ly
                    {
                        ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                        string strID = Id.ToString() + ",";
                        listQuestionBSO.UpdateQuestionStatus(strID, 1);
                        loadData();
                        Label1.Text = "unlock";
                        break;
                    }
                case "_delete":
                    {
                        ListQuestionBSO listQuestionBSO = new ListQuestionBSO();
                        listQuestionBSO.deleteQuestionByID(Id);
                        loadData();
                    }
                    break;
            }
        }
    }
}