namespace ETO
{
    using System;

    public class Modules
    {
        private string moduleshelp;
        private string modulesicon;
        private int modulesId;
        private string modulesName;
        private int modulesOrder;
        private int modulesParent;
        private string modulesUrl;

        public string ModulesHelp
        {
            get
            {
                return this.moduleshelp;
            }
            set
            {
                this.moduleshelp = value;
            }
        }

        public string ModulesIcon
        {
            get
            {
                return this.modulesicon;
            }
            set
            {
                this.modulesicon = value;
            }
        }

        public int ModulesID
        {
            get
            {
                return this.modulesId;
            }
            set
            {
                this.modulesId = value;
            }
        }

        public string ModulesName
        {
            get
            {
                return this.modulesName;
            }
            set
            {
                this.modulesName = value;
            }
        }

        public int ModulesOrder
        {
            get
            {
                return this.modulesOrder;
            }
            set
            {
                this.modulesOrder = value;
            }
        }

        public int ModulesParent
        {
            get
            {
                return this.modulesParent;
            }
            set
            {
                this.modulesParent = value;
            }
        }

        public string ModulesUrl
        {
            get
            {
                return this.modulesUrl;
            }
            set
            {
                this.modulesUrl = value;
            }
        }
    }
}

