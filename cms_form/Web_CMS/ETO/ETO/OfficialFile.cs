namespace ETO
{
    using System;

    public class OfficialFile
    {
        private string filename;
        private int officialFileid;
        private int officialid;
        private string title;

        public string FileName
        {
            get
            {
                return this.filename;
            }
            set
            {
                this.filename = value;
            }
        }

        public int OfficialFileID
        {
            get
            {
                return this.officialFileid;
            }
            set
            {
                this.officialFileid = value;
            }
        }

        public int OfficialID
        {
            get
            {
                return this.officialid;
            }
            set
            {
                this.officialid = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
    }
}

