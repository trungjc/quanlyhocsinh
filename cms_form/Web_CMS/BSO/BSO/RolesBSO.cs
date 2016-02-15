namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class RolesBSO
    {
        public void CreateRoles(IRoles roles)
        {
            new RolesDAO().CreateRoles(roles);
        }

        public void DeleteRoles(int rId)
        {
            new RolesDAO().DeleteRoles(rId);
        }

        public DataTable GetAllRoles()
        {
            RolesDAO rolesDAO = new RolesDAO();
            return rolesDAO.GetAllRoles();
        }

        public IRoles GetRolesById(int rId)
        {
            RolesDAO rolesDAO = new RolesDAO();
            return rolesDAO.GetRolesById(rId);
        }

        public IRoles GetRolesByName(string name)
        {
            RolesDAO rolesDAO = new RolesDAO();
            return rolesDAO.GetRolesByName(name);
        }

        public DataTable GetRolesbyStrRolesID(string strRolesID)
        {
            RolesDAO rolesDAO = new RolesDAO();
            return rolesDAO.GetRolesbyStrRolesID(strRolesID);
        }

        public void UpdateRoles(IRoles roles)
        {
            new RolesDAO().UpdateRoles(roles);
        }
    }
}

