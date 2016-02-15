namespace ETO
{
    using System;

    public class Link
    {
        private int linkheight;
        private int linkid;
        private string linkimage;
        private bool linkstatus;
        private string linkurl;
        private int linkwidth;
        private int linktype;

        public int LinkHeight
        {
            get
            {
                return this.linkheight;
            }
            set
            {
                this.linkheight = value;
            }
        }

        public int LinkID
        {
            get
            {
                return this.linkid;
            }
            set
            {
                this.linkid = value;
            }
        }

        public string LinkImage
        {
            get
            {
                return this.linkimage;
            }
            set
            {
                this.linkimage = value;
            }
        }

        public bool LinkStatus
        {
            get
            {
                return this.linkstatus;
            }
            set
            {
                this.linkstatus = value;
            }
        }

        public string LinkUrl
        {
            get
            {
                return this.linkurl;
            }
            set
            {
                this.linkurl = value;
            }
        }

        public int LinkWidth
        {
            get
            {
                return this.linkwidth;
            }
            set
            {
                this.linkwidth = value;
            }
        }

        public int LinkType
        {
            get { return this.linktype; }
            set { this.linktype = value; }
        }
    }
}

