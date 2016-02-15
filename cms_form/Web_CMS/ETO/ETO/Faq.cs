namespace ETO
{
    using System;

    public class Faq
    {
        private string answer;
        private int faqid;
        private int faqOrder;
        private string language;
        private DateTime postdate;
        private string question;
        private bool status;
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Answer
        {
            get
            {
                return this.answer;
            }
            set
            {
                this.answer = value;
            }
        }

        public int FaqID
        {
            get
            {
                return this.faqid;
            }
            set
            {
                this.faqid = value;
            }
        }

        public int FaqOrder
        {
            get
            {
                return this.faqOrder;
            }
            set
            {
                this.faqOrder = value;
            }
        }

        public string Language
        {
            get
            {
                return this.language;
            }
            set
            {
                this.language = value;
            }
        }

        public DateTime PostDate
        {
            get
            {
                return this.postdate;
            }
            set
            {
                this.postdate = value;
            }
        }

        public string Question
        {
            get
            {
                return this.question;
            }
            set
            {
                this.question = value;
            }
        }

        public bool Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
    }
}

