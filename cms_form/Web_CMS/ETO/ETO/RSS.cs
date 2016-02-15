namespace ETO
{
    using System;

    public class RSS
    {
        private string author;
        private string image;
        private int rssid;
        private string rssname;
        private string rssurl;
        private string shortdescribe;

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                this.author = value;
            }
        }

        public string Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }

        public int RSSID
        {
            get
            {
                return this.rssid;
            }
            set
            {
                this.rssid = value;
            }
        }

        public string RSSName
        {
            get
            {
                return this.rssname;
            }
            set
            {
                this.rssname = value;
            }
        }

        public string RSSUrl
        {
            get
            {
                return this.rssurl;
            }
            set
            {
                this.rssurl = value;
            }
        }

        public string ShortDescribe
        {
            get
            {
                return this.shortdescribe;
            }
            set
            {
                this.shortdescribe = value;
            }
        }
    }
}

