namespace ETO
{
    using System;

    public class CateNews
    {
        private int catenewsid;
        private string catenewsname;
        private int catenewsorder;
        private int catenewstotal;
        private DateTime created;
        private int groupcate;
        private string icon;
        private bool isurl;
        private string language;
        private int parentnewsid;
        private string roles;
        private string slogan;
        private string url;
        private string username;
        private string image;

        public int CateNewsID
        {
            get
            {
                return this.catenewsid;
            }
            set
            {
                this.catenewsid = value;
            }
        }

        public string CateNewsName
        {
            get
            {
                return this.catenewsname;
            }
            set
            {
                this.catenewsname = value;
            }
        }

        public int CateNewsOrder
        {
            get
            {
                return this.catenewsorder;
            }
            set
            {
                this.catenewsorder = value;
            }
        }

        public int CateNewsTotal
        {
            get
            {
                return this.catenewstotal;
            }
            set
            {
                this.catenewstotal = value;
            }
        }

        public DateTime Created
        {
            get
            {
                return this.created;
            }
            set
            {
                this.created = value;
            }
        }

        public int GroupCate
        {
            get
            {
                return this.groupcate;
            }
            set
            {
                this.groupcate = value;
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

        public bool isUrl
        {
            get
            {
                return this.isurl;
            }
            set
            {
                this.isurl = value;
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

        public int ParentNewsID
        {
            get
            {
                return this.parentnewsid;
            }
            set
            {
                this.parentnewsid = value;
            }
        }

        public string Roles
        {
            get
            {
                return this.roles;
            }
            set
            {
                this.roles = value;
            }
        }

        public string Slogan
        {
            get
            {
                return this.slogan;
            }
            set
            {
                this.slogan = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
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
    }
}

