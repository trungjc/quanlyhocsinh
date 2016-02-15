namespace ETO
{
    using System;

    public class Member
    {
        private bool actived;
        private string address;
        private string avatar;
        private DateTime birth;
        private string email;
        private string fullName;
        private int memberId;
        private string nickSkype;
        private string nickYahoo;
        private string passWord;
        private string phone;
        private bool sex;
        private string userName;

        public bool Actived
        {
            get
            {
                return this.actived;
            }
            set
            {
                this.actived = value;
            }
        }

        public string Address
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

        public string Avatar
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

        public DateTime Birth
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

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = value;
            }
        }

        public int MemberID
        {
            get
            {
                return this.memberId;
            }
            set
            {
                this.memberId = value;
            }
        }

        public string NickSkype
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

        public string NickYahoo
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

        public string Password
        {
            get
            {
                return this.passWord;
            }
            set
            {
                this.passWord = value;
            }
        }

        public string Phone
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

        public bool Sex
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

