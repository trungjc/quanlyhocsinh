namespace ETO
{
    using System;

    public class PhoneBook
    {
        private string _address;
        private bool _checkParent;
        private DateTime? _createDate;
        private string _creatorId;
        private string _email;
        private string _fullName;
        private string _homePhone;
        private int _id;
        private string _officephone;
        private int _orders;
        private int _parentId;
        private string _phone1;
        private string _phone2;

        public string Address
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
            }
        }

        public bool CheckParent
        {
            get
            {
                return this._checkParent;
            }
            set
            {
                this._checkParent = value;
            }
        }

        public DateTime? CreateDate
        {
            get
            {
                return this._createDate;
            }
            set
            {
                this._createDate = value;
            }
        }

        public string CreatorId
        {
            get
            {
                return this._creatorId;
            }
            set
            {
                this._creatorId = value;
            }
        }

        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }

        public string FullName
        {
            get
            {
                return this._fullName;
            }
            set
            {
                this._fullName = value;
            }
        }

        public string HomePhone
        {
            get
            {
                return this._homePhone;
            }
            set
            {
                this._homePhone = value;
            }
        }

        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string Officephone
        {
            get
            {
                return this._officephone;
            }
            set
            {
                this._officephone = value;
            }
        }

        public int Orders
        {
            get
            {
                return this._orders;
            }
            set
            {
                this._orders = value;
            }
        }

        public int ParentId
        {
            get
            {
                return this._parentId;
            }
            set
            {
                this._parentId = value;
            }
        }

        public string Phone1
        {
            get
            {
                return this._phone1;
            }
            set
            {
                this._phone1 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return this._phone2;
            }
            set
            {
                this._phone2 = value;
            }
        }
    }
}

