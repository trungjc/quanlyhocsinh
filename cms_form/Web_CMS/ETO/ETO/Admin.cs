namespace ETO
{
    using System;

    public class Admin
    {
        private string address;
        private bool adminActive;
        private DateTime adminCreated;
        private string adminEmail;
        private string adminFullName;
        private int adminId;
        private DateTime adminLog;
        private string adminName;
        private string adminPass;
        private string adminPermission;
        private string avatar;
        private DateTime birth;
        private bool loginType;
        private string nickSkype;
        private string nickYahoo;
        private string phone;
        private int rolesId;
        private bool sex;

        public bool AdminActive
        {
            get
            {
                return this.adminActive;
            }
            set
            {
                this.adminActive = value;
            }
        }

        public string AdminAddress
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public string AdminAvatar
        {
            get
            {
                return this.avatar;
            }
            set
            {
                this.avatar = value;
            }
        }

        public DateTime AdminBirth
        {
            get
            {
                return this.birth;
            }
            set
            {
                this.birth = value;
            }
        }

        public DateTime AdminCreated
        {
            get
            {
                return this.adminCreated;
            }
            set
            {
                this.adminCreated = value;
            }
        }

        public string AdminEmail
        {
            get
            {
                return this.adminEmail;
            }
            set
            {
                this.adminEmail = value;
            }
        }

        public string AdminFullName
        {
            get
            {
                return this.adminFullName;
            }
            set
            {
                this.adminFullName = value;
            }
        }

        public int AdminID
        {
            get
            {
                return this.adminId;
            }
            set
            {
                this.adminId = value;
            }
        }

        public DateTime AdminLog
        {
            get
            {
                return this.adminLog;
            }
            set
            {
                this.adminLog = value;
            }
        }

        public bool AdminLoginType
        {
            get
            {
                return this.loginType;
            }
            set
            {
                this.loginType = value;
            }
        }

        public string AdminName
        {
            get
            {
                return this.adminName;
            }
            set
            {
                this.adminName = value;
            }
        }

        public string AdminNickSkype
        {
            get
            {
                return this.nickSkype;
            }
            set
            {
                this.nickSkype = value;
            }
        }

        public string AdminNickYahoo
        {
            get
            {
                return this.nickYahoo;
            }
            set
            {
                this.nickYahoo = value;
            }
        }

        public string AdminPass
        {
            get
            {
                return this.adminPass;
            }
            set
            {
                this.adminPass = value;
            }
        }

        public string AdminPermission
        {
            get
            {
                return this.adminPermission;
            }
            set
            {
                this.adminPermission = value;
            }
        }

        public string AdminPhone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        public bool AdminSex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        public int RolesID
        {
            get
            {
                return this.rolesId;
            }
            set
            {
                this.rolesId = value;
            }
        }
    }
}

