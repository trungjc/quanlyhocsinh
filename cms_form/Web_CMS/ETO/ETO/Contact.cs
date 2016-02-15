namespace ETO
{
    using System;

    public class Contact
    {
        private string address;
        private string attact;
        private string city;
        private string company;
        private int contactId;
        private DateTime date;
        private string email;
        private string fax;
        private string name;
        private string require;
        private string tel;
        private bool sendmail;
        private string answer;

        public string Answer
        {
            get { return this.answer; }
            set { this.answer = value; }
        }

        public bool Sendmail
        {
            get
            {
                return this.sendmail;
            }
            set
            {
                this.sendmail = value;
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

        public string Attact
        {
            get
            {
                return this.attact;
            }
            set
            {
                this.attact = value;
            }
        }

        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }

        public string Company
        {
            get
            {
                return this.company;
            }
            set
            {
                this.company = value;
            }
        }

        public int ContactID
        {
            get
            {
                return this.contactId;
            }
            set
            {
                this.contactId = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
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

        public string Fax
        {
            get
            {
                return this.fax;
            }
            set
            {
                this.fax = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
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

        public string Tel
        {
            get
            {
                return this.tel;
            }
            set
            {
                this.tel = value;
            }
        }
    }
}

