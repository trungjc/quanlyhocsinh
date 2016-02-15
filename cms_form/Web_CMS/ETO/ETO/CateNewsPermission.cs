namespace ETO
{
    using System;

    public class CateNewsPermission
    {
        private int cateNewsID;
        private int catenewsPermissionid;
        private DateTime created;
        private string permission;
        private int rolesID;
        private string userName;

        public int CateNewsID
        {
            get
            {
                return this.cateNewsID;
            }
            set
            {
                this.cateNewsID = value;
            }
        }

        public int CateNewsPermissionID
        {
            get
            {
                return this.catenewsPermissionid;
            }
            set
            {
                this.catenewsPermissionid = value;
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

