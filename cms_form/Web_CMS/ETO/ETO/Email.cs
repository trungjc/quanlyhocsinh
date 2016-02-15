namespace ETO
{
    using System;

    public class Email
    {
        private string emailaddress;
        private int emailid;
        private string name;

        public string EmailAddress
        {
            get
            {
                return this.emailaddress;
            }
            set
            {
                this.emailaddress = value;
            }
        }

        public int EmailID
        {
            get
            {
                return this.emailid;
            }
            set
            {
                this.emailid = value;
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
    }
}

