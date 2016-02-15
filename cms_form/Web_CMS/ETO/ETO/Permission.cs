namespace ETO
{
    using System;

    public class Permission
    {
        private string description;
        private int permissionID;
        private string permissionName;
        private string value1;

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public int PermissionID
        {
            get
            {
                return this.permissionID;
            }
            set
            {
                this.permissionID = value;
            }
        }

        public string PermissionName
        {
            get
            {
                return this.permissionName;
            }
            set
            {
                this.permissionName = value;
            }
        }

        public string Value
        {
            get
            {
                return this.value1;
            }
            set
            {
                this.value1 = value;
            }
        }
    }
}

