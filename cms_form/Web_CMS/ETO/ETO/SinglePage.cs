namespace ETO
{
    using System;

    public class SinglePage
    {
        private DateTime createDate;
        private string createdUserName;
        private string icon;
        private string language;
        private string singlepagecontent;
        private string singlepagedesc;
        private int singlepageid;
        private string singlepagename;
        private bool status;

        public DateTime CreateDate
        {
            get
            {
                return this.createDate;
            }
            set
            {
                this.createDate = value;
            }
        }

        public string CreatedUserName
        {
            get
            {
                return this.createdUserName;
            }
            set
            {
                this.createdUserName = value;
            }
        }

        public string Icon
        {
            get
            {
                return this.icon;
            }
            set
            {
                this.icon = value;
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

        public string SinglePageContent
        {
            get
            {
                return this.singlepagecontent;
            }
            set
            {
                this.singlepagecontent = value;
            }
        }

        public string SinglePageDesc
        {
            get
            {
                return this.singlepagedesc;
            }
            set
            {
                this.singlepagedesc = value;
            }
        }

        public int SinglePageID
        {
            get
            {
                return this.singlepageid;
            }
            set
            {
                this.singlepageid = value;
            }
        }

        public string SinglePageName
        {
            get
            {
                return this.singlepagename;
            }
            set
            {
                this.singlepagename = value;
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

