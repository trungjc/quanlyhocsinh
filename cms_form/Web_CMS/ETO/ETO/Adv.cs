namespace ETO
{
    using System;

    public class Adv
    {
        private DateTime advenddate;
        private int advheight;
        private int advid;
        private string advimage;
        private DateTime advpostdate;
        private bool advstatus;
        private string advurl;
        private int advwidth;

        public DateTime AdvEndDate
        {
            get
            {
                return this.advenddate;
            }
            set
            {
                this.advenddate = value;
            }
        }

        public int AdvHeight
        {
            get
            {
                return this.advheight;
            }
            set
            {
                this.advheight = value;
            }
        }

        public int AdvID
        {
            get
            {
                return this.advid;
            }
            set
            {
                this.advid = value;
            }
        }

        public string AdvImage
        {
            get
            {
                return this.advimage;
            }
            set
            {
                this.advimage = value;
            }
        }

        public DateTime AdvPostDate
        {
            get
            {
                return this.advpostdate;
            }
            set
            {
                this.advpostdate = value;
            }
        }

        public bool AdvStatus
        {
            get
            {
                return this.advstatus;
            }
            set
            {
                this.advstatus = value;
            }
        }

        public string AdvUrl
        {
            get
            {
                return this.advurl;
            }
            set
            {
                this.advurl = value;
            }
        }

        public int AdvWidth
        {
            get
            {
                return this.advwidth;
            }
            set
            {
                this.advwidth = value;
            }
        }
    }
}

