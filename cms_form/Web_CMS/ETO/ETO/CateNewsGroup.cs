namespace ETO
{
    using System;

    public class CateNewsGroup
    {
        private int cateNewsGroupID;
        private string cateNewsGroupName;
        private string description;
        private int groupCate;
        private string icon;
        private bool ishome;
        private bool ismenu;
        private bool isnews;
        private bool ispage;
        private bool isurl;
        private bool isview;
        private int order;
        private int position;
        private string url;
        private string language;
        public int CateNewsGroupID
        {
            get
            {
                return this.cateNewsGroupID;
            }
            set
            {
                this.cateNewsGroupID = value;
            }
        }

        public string CateNewsGroupName
        {
            get
            {
                return this.cateNewsGroupName;
            }
            set
            {
                this.cateNewsGroupName = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public int GroupCate
        {
            get
            {
                return this.groupCate;
            }
            set
            {
                this.groupCate = value;
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

        public bool IsHome
        {
            get
            {
                return this.ishome;
            }
            set
            {
                this.ishome = value;
            }
        }

        public bool IsMenu
        {
            get
            {
                return this.ismenu;
            }
            set
            {
                this.ismenu = value;
            }
        }

        public bool IsNew
        {
            get
            {
                return this.isnews;
            }
            set
            {
                this.isnews = value;
            }
        }

        public bool IsPage
        {
            get
            {
                return this.ispage;
            }
            set
            {
                this.ispage = value;
            }
        }

        public bool IsUrl
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

        public bool IsView
        {
            get
            {
                return this.isview;
            }
            set
            {
                this.isview = value;
            }
        }

        public int Order
        {
            get
            {
                return this.order;
            }
            set
            {
                this.order = value;
            }
        }

        public int Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
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
    }
}

