namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class ModulesBSO
    {
        public int AddModules(Modules _modules)
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.CreateModules(_modules);
        }

        public bool CheckExist(string ModulesName)
        {
            bool name = false;
            DataTable dataTable = this.GetAllModules();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = "Modules_Url = '" + ModulesName + "'"
                };
                if (dataView.Count > 0)
                {
                    name = true;
                }
            }
            return name;
        }

        public bool CheckLevelModulesRoles(string url, string AdminName)
        {
            bool levelRoles = false;
            if (AdminName.Equals("administrator"))
            {
                return true;
            }
            DataView dataView = new DataView(this.ViewMainModulesRoles(AdminName));
            try
            {
                dataView.RowFilter = "Modules_Url = '" + url + "'";
                if (dataView.Count > 0)
                {
                    levelRoles = true;
                }
            }
            catch
            {
                levelRoles = false;
            }
            return levelRoles;
        }

        public bool CheckLevelRoles(string url, string AdminName)
        {
            bool levelRoles = false;
            if (AdminName.Equals("administrator"))
            {
                return true;
            }
            DataView dataView = new DataView(this.ViewMainModules(AdminName));
            try
            {
                dataView.RowFilter = "Modules_Url = '" + url + "'";
                if (dataView.Count > 0)
                {
                    levelRoles = true;
                }
            }
            catch
            {
                levelRoles = false;
            }
            return levelRoles;
        }

        public void DeleteModules(int mID)
        {
            new ModulesDAO().DeleteModules(mID);
        }

        public int EditModules(Modules _modules)
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.UpdateModules(_modules);
        }

        public DataTable GetAllModules()
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.GetAllModules();
        }

        public Modules GetModulesById(int mID)
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.GetModulesById(mID);
        }

        public Modules GetModulesByUrl(string url)
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.GetModulesByUrl(url);
        }

        public DataTable MixModules()
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.MixModules();
        }

        public DataTable MixModulesAdmin()
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.MixModulesAdmin();
        }

        public void ModulesUpOrder(int cId, int cOrder)
        {
            new ModulesDAO().ModulesUpOrder(cId, cOrder);
        }

        public DataTable ViewMainModules(string AdminName)
        {
            DataTable dataTable = new DataTable();
            Admin admin = new AdminBSO().GetAdminById(AdminName);
            RolesBSO rolesBSO = new RolesBSO();
            string strModules = rolesBSO.GetRolesById(admin.RolesID).RolesModules.Replace(",", "','");
            DataTable table = new ModulesBSO().MixModules();
            if (AdminName.Equals("administrator"))
            {
                return table;
            }
            DataView dataView = new DataView(table) {
                RowFilter = "Modules_Url in ('" + strModules + "')",
                Sort = "Modules_ID ASC"
            };
            return dataView.ToTable();
        }

        public DataTable ViewMainModulesRoles(string AdminName)
        {
            DataTable dataTable = new DataTable();
            string strRoles = new AdminRolesBSO().GetRoles(AdminName);
            DataTable table1 = new RolesBSO().GetRolesbyStrRolesID(strRoles);
            string strModules = "";
            if (table1.Rows.Count > 0)
            {
                foreach (DataRow row in table1.Rows)
                {
                    strModules = strModules + row["Roles_Modules"].ToString();
                }
            }
            strModules = strModules.Replace(",", "','");
            DataTable table = new ModulesBSO().MixModulesAdmin();
            if (AdminName.Equals("administrator"))
            {
                return table;
            }
            DataView dataView = new DataView(table) {
                RowFilter = "Modules_Url in ('" + strModules + "')",
                Sort = "Modules_ID ASC"
            };
            return dataView.ToTable();
        }
    }
}

