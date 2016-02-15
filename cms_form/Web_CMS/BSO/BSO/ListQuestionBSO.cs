namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class ListQuestionBSO
    {
        public void CreateListQuestion(ListQuestion listQuestion)
        {
            new ListQuestionDAO().CreatelistQuestion(listQuestion);
        }

        public void deleteQuestionByID(int Id)
        {
            new ListQuestionDAO().deleteQuestionByID(Id);
        }

        public DataTable GetAllPublishQuestion()
        {
            ListQuestionDAO listQuestionDAO = new ListQuestionDAO();
            return listQuestionDAO.GetAllPublishQuestion();
        }

        public DataTable GetListPublishQuestionByProduct(int CateNewsID)
        {
            ListQuestionDAO listQuestionDAO = new ListQuestionDAO();
            return listQuestionDAO.GetListPublishQuestionByProduct(CateNewsID);
        }

        public DataTable GetListQuestionAll()
        {
            ListQuestionDAO listQuestionDAO = new ListQuestionDAO();
            return listQuestionDAO.GetListQuestionAll();
        }

        public ListQuestion GetListQuestionByID(int ID)
        {
            ListQuestionDAO listQuestionDAO = new ListQuestionDAO();
            return listQuestionDAO.GetListQuestionByID(ID);
        }

        public DataTable GetListQuestionStausID(int status)
        {
            ListQuestionDAO listQuestionDAO = new ListQuestionDAO();
            return listQuestionDAO.GetListQuestionStausID(status);
        }

        public DataTable GetPublishQuestionByID(int id)
        {
            ListQuestionDAO listQuestionDAO = new ListQuestionDAO();
            return listQuestionDAO.GetPublishQuestionByID(id);
        }

        public DataTable GetQuestionByID(int id)
        {
            ListQuestionDAO listQuestionDAO = new ListQuestionDAO();
            return listQuestionDAO.GetQuestionByID(id);
        }

        public DataTable listChildQuestionByParentID(int ParentID)
        {
            ListQuestionDAO listQuestionDAO = new ListQuestionDAO();
            return listQuestionDAO.listChildQuestionByParentID(ParentID);
        }

        public DataTable listChildQuestionPublishByParentID(int ParentID)
        {
            ListQuestionDAO listQuestionDAO = new ListQuestionDAO();
            return listQuestionDAO.listChildQuestionPublishByParentID(ParentID);
        }

        public DataTable listParentQuestionByID(int id)
        {
            ListQuestionDAO listQuestionDAO = new ListQuestionDAO();
            return listQuestionDAO.listParentQuestionByID(id);
        }

        public DataTable listQuestionPublishByParentID(int id)
        {
            ListQuestionDAO listQuestionDAO = new ListQuestionDAO();
            return listQuestionDAO.listQuestionPublishByParentID(id);
        }

        public string listRolesID(string userName)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetRoles1(userName);
        }

        public string RolesNameByUserName(string userName)
        {
            string strRolesID = new AdminRolesDAO().GetRoles1(userName);
            DataTable dt = new DataTable();
            RolesBSO roleBSO = new RolesBSO();
            DataTable dt2 = new DataView(roleBSO.GetAllRoles()) { RowFilter = "Roles_ID IN(" + strRolesID + ")" }.ToTable();
            if (dt2.Rows.Count == 0)
            {
                return "Administrators";
            }
            if ((dt2.Rows.Count == 1) && (dt2.Rows[0]["Roles_Name"].ToString().ToLower() == "guest"))
            {
                return "Guest";
            }
            string strRoles = "";
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                strRoles = strRoles + dt2.Rows[i]["Roles_Name"].ToString();
            }
            if (strRoles.ToLower().Contains("admin"))
            {
                return "admin";
            }
            return "mod";
        }

        public void UpdatelistQuestion(ListQuestion listQuestion)
        {
            new ListQuestionDAO().UpdatelistQuestion(listQuestion);
        }

        public void UpdateQuestionStatus(string ArrQuestionID, int status)
        {
            string restr = ArrQuestionID.Remove(ArrQuestionID.LastIndexOf(",")).Replace(",", "','");
            new ListQuestionDAO().UpdateQuestionStatus(restr, status);
        }

        public void updateStatusPublishQuestion(int questionID, int status)
        {
            new ListQuestionDAO().updateStatusPublishQuestion(questionID, status);
        }

        public void UpdateSubQuestion(int questionID, string content, string image, string file)
        {
            new ListQuestionDAO().UpdateSubQuestion(questionID, content, image, file);
        }
    }
}

