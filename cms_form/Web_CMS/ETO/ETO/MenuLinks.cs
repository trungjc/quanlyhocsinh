namespace ETO
{
    using System;

    public class MenuLinks
    {
        private bool isView;
        private string menuLinkshelp;
        private string menuLinksicon;
        private int menuLinksId;
        private string menuLinksName;
        private int menuLinksOrder;
        private int menuLinksParent;
        private string menuLinksUrl;
        private bool status;
        private string target;

        public bool IsView
        {
            get
            {
                return this.isView;
            }
            set
            {
                this.isView = value;
            }
        }

        public string MenuLinksHelp
        {
            get
            {
                return this.menuLinkshelp;
            }
            set
            {
                this.menuLinkshelp = value;
            }
        }

        public string MenuLinksIcon
        {
            get
            {
                return this.menuLinksicon;
            }
            set
            {
                this.menuLinksicon = value;
            }
        }

        public int MenuLinksID
        {
            get
            {
                return this.menuLinksId;
            }
            set
            {
                this.menuLinksId = value;
            }
        }

        public string MenuLinksName
        {
            get
            {
                return this.menuLinksName;
            }
            set
            {
                this.menuLinksName = value;
            }
        }

        public int MenuLinksOrder
        {
            get
            {
                return this.menuLinksOrder;
            }
            set
            {
                this.menuLinksOrder = value;
            }
        }

        public int MenuLinksParent
        {
            get
            {
                return this.menuLinksParent;
            }
            set
            {
                this.menuLinksParent = value;
            }
        }

        public string MenuLinksUrl
        {
            get
            {
                return this.menuLinksUrl;
            }
            set
            {
                this.menuLinksUrl = value;
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

        public string Target
        {
            get
            {
                return this.target;
            }
            set
            {
                this.target = value;
            }
        }
    }
}

