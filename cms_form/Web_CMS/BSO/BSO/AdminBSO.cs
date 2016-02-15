namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class AdminBSO
    {
        public DataTable AdminGetAllRolesByID(int rolesID)
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.AdminGetAllRolesByID(rolesID);
        }

        public DataTable AdminGetRolesByID(int rolesID)
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.AdminGetRolesByID(rolesID);
        }

        public bool CheckExist(string adminname)
        {
            bool exist = false;
            DataTable dataTable = this.GetAllAdmin();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = "Admin_Username = '" + adminname + "'"
                };
                if (dataView.Count > 0)
                {
                    exist = true;
                }
            }
            return exist;
        }

        public bool CheckExistEmail(string email)
        {
            bool exist = false;
            DataTable dataTable = this.GetAllAdmin();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = "Admin_Email = '" + email + "'"
                };
                if (dataView.Count > 0)
                {
                    exist = true;
                }
            }
            return exist;
        }

        public bool CheckLoginAdmin(string name, string pass)
        {
            bool login = false;
            //string pass1 = new SecurityBSO().DecPwd("YWRtaW5DaElwWWVV");
            pass = new SecurityBSO().EncPwd(pass);
            DataTable dataTable = this.GetAllAdmin();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = "Admin_Username = '" + name + "' AND Admin_Password = '" + pass + "' AND Admin_Actived = 'True'"
                };
                if (dataView.Count > 0)
                {
                    login = true;
                }
            }
            return login;
        }

        public bool CheckPermission(string name, string permission)
        {
            bool check = false;
            Admin admin = new Admin();
            if (this.GetAdminById(name).AdminPermission.Replace(",", "','").IndexOf(permission) != -1)
            {
                check = true;
            }
            return check;
        }

        public bool CheckUserName(string name)
        {
            bool login = false;
            DataTable dataTable = this.GetAllAdmin();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = "Admin_Username = '" + name + "' AND Admin_Actived = 'True'"
                };
                if (dataView.Count > 0)
                {
                    login = true;
                }
            }
            return login;
        }

        public void CreateAdmin(Admin admin)
        {
            new AdminDAO().CreateAdmin(admin);
        }

        public void DeleteAdmin(string adminname)
        {
            new AdminDAO().DeleteAdmin(adminname);
        }

        public DataTable GetAdminByCateHomeList(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAdminByCateHomeList(restr);
        }

        public Admin GetAdminById(string nameadmin)
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAdminById(nameadmin);
        }

        public DataTable GetAdminBystrName(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAdminByStrName(restr);
        }

        public DataTable GetAllAdmin()
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAllAdmin();
        }

        public DataTable GetAllAdminRoles()
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAllAdminRoles();
        }

        public string GetStrAdmin()
        {
            DataTable table = new DataTable();
            table = this.GetAllAdmin();
            string strID = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow subrow in table.Rows)
                {
                    strID = strID + subrow["Admin_UserName"].ToString() + ",";
                }
            }
            return strID;
        }

        public void UpdateAdmin(Admin admin)
        {
            new AdminDAO().UpdateAdmin(admin);
        }

        public void UpdateAdminLog(string name, DateTime log)
        {
            new AdminDAO().UpdateAdminLog(name, log);
        }
    }
}

