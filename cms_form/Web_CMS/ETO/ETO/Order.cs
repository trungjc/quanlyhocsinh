namespace ETO
{
    using System;

    public class Order
    {
        private string address;
        private DateTime dateCreated;
        private string email;
        private string fullName;
        private int Id;
        private bool isActived;
        private int memberId;
        private string nickSkype;
        private string nickYahoo;
        private int orderId;
        private string phone;
        private string require;
        private string title;

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

        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated;
            }
            set
            {
                this.dateCreated = value;
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

        public int ID
        {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = value;
            }
        }

        public bool IsActived
        {
            get
            {
                return this.isActived;
            }
            set
            {
                this.isActived = value;
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

        public int OrderID
        {
            get
            {
                return this.orderId;
            }
            set
            {
                this.orderId = value;
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

        public string Require
        {
            get
            {
                return this.require;
            }
            set
            {
                this.require = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
    }
}

