namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class ModulesFrontPanelBSO
    {
        public int AddModulesFrontPanel(ModulesFrontPanel _modulesFrontPanel)
        {
            ModulesFrontPanelDAO modulesFrontPanelDAO = new ModulesFrontPanelDAO();
            return modulesFrontPanelDAO.CreateModulesFrontPanel(_modulesFrontPanel);
        }

        public bool CheckExist(string ModulesFrontPanelName)
        {
            bool name = false;
            DataTable dataTable = this.GetAllModulesFrontPanel();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable)
                {
                    RowFilter = "ModulesFrontPanel_Url = '" + ModulesFrontPanelName + "'"
                };
                if (dataView.Count > 0)
                {
                    name = true;
                }
            }
            return name;
        }

        public void DeleteModulesFrontPanel(int mID)
        {
            new ModulesFrontPanelDAO().DeleteModulesFrontPanel(mID);
        }

        public int EditModulesFrontPanel(ModulesFrontPanel _modulesFrontPanel)
        {
            ModulesFrontPanelDAO modulesFrontPanelDAO = new ModulesFrontPanelDAO();
            return modulesFrontPanelDAO.UpdateModulesFrontPanel(_modulesFrontPanel);
        }

        public DataTable GetAllModulesFrontPanel()
        {
            ModulesFrontPanelDAO modulesFrontPanelDAO = new ModulesFrontPanelDAO();
            return modulesFrontPanelDAO.GetAllModulesFrontPanel();
        }

        public ModulesFrontPanel GetModulesFrontPanelById(int mID)
        {
            ModulesFrontPanelDAO modulesFrontPanelDAO = new ModulesFrontPanelDAO();
            return modulesFrontPanelDAO.GetModulesFrontPanelById(mID);
        }

        public DataTable GetModulesFrontPanelbyPanel(string Panel, string lang)
        {
            ModulesFrontPanelDAO modulesFrontPanelDAO = new ModulesFrontPanelDAO();
            DataView view = new DataView(modulesFrontPanelDAO.GetAllModulesFrontPanel())
            {
                RowFilter = "ModulesFrontPanel_Panel = '" + Panel + "' And ModulesFrontPanel_Status = 1 and [language]= '" + lang + "' and ModulesFrontPanel_Parent=0",
                Sort = "ModulesFrontPanel_Order ASC"
            };
            return view.ToTable();
        }

        /// <summary>
        /// Linhlv: bổ sung hàm này để có thể load được các panel con thuộc panel cha
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public DataTable GetModulesFrontPanelbyParentPanel(string panel, string parentId)
        {
            var modulesFrontPanelDao = new ModulesFrontPanelDAO();
            var view = new DataView(modulesFrontPanelDao.GetAllModulesFrontPanel())
            {
                RowFilter = "ModulesFrontPanel_Panel = '" + panel + "' And ModulesFrontPanel_Status = 1 and ModulesFrontPanel_Parent=" + parentId,
                Sort = "ModulesFrontPanel_Order ASC"
            };
            return view.ToTable();
        }

        public ModulesFrontPanel GetModulesFrontPanelByUrl(string url)
        {
            ModulesFrontPanelDAO modulesFrontPanelDAO = new ModulesFrontPanelDAO();
            return modulesFrontPanelDAO.GetModulesFrontPanelByUrl(url);
        }

        public DataTable MixModulesFrontPanel()
        {
            ModulesFrontPanelDAO modulesFrontPanelDAO = new ModulesFrontPanelDAO();
            return modulesFrontPanelDAO.MixModulesFrontPanel();
        }

        public DataTable MixModulesFrontPanel(string Panel)
        {
            ModulesFrontPanelDAO modulesFrontPanelDAO = new ModulesFrontPanelDAO();
            DataView view = new DataView(modulesFrontPanelDAO.MixModulesFrontPanel())
            {
                RowFilter = "ModulesFrontPanel_Panel = '" + Panel + "'"
            };
            return view.ToTable();
        }
        public DataTable MixModulesFrontPanel_lag_Vitri(string Panel, string lag)
        {
            ModulesFrontPanelDAO modulesFrontPanelDAO = new ModulesFrontPanelDAO();
            DataView view = new DataView(modulesFrontPanelDAO.MixModulesFrontPanel_lag_vitri())
            {
                RowFilter = "ModulesFrontPanel_Panel = '" + Panel + "' and language = '" + lag + "' "
            };
            return view.ToTable();
        }
        public DataTable MixModulesFrontPanel_lag(string lag)
        {
            ModulesFrontPanelDAO modulesFrontPanelDAO = new ModulesFrontPanelDAO();
            DataView view = new DataView(modulesFrontPanelDAO.MixModulesFrontPanel_lag_vitri())
            {
                RowFilter = "language = '" + lag + "'"
            };
            return view.ToTable();
        }

        public void ModulesFrontPanelUpOrder(int cId, int cOrder)
        {
            new ModulesFrontPanelDAO().ModulesFrontPanelUpOrder(cId, cOrder);
        }
    }
}

