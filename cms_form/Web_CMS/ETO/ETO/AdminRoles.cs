namespace ETO
{
    using System;

    public class AdminRoles
    {
        private int adminRolesid;
        private string adminUserName;
        private DateTime created;
        private string permission;
        private int rolesID;
        private string userName;

        public int AdminRolesID
        {
            get
            {
                return this.adminRolesid;
            }
            set
            {
                this.adminRolesid = value;
            }
        }

        public string AdminUserName
        {
            get
            {
                return this.adminUserName;
            }
            set
            {
                this.adminUserName = value;
            }
        }

        public DateTime Created
        {
            get
            {
                return this.created;
            }
            set
            {
                this.created = value;
            }
        }

        public string Permission
        {
            get
            {
                return this.permission;
            }
            set
            {
                this.permission = value;
            }
        }

        public int RolesID
        {
            get
            {
                return this.rolesID;
            }
            set
            {
                this.rolesID = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }
    }
}

