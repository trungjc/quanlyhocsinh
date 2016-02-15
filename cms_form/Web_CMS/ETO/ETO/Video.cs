namespace ETO
{
    using System;

    public class Video
    {
        private string filename;
        private string image;
        private bool ishome;
        private string language;
        private DateTime postdate;
        private string shortdescribe;
        private int Videoid;
        private string Videoname;
        private bool videoType;
        private string Videourl;
        private string videoEmbed;

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

        public int VideoID
        {
            get
            {
                return this.Videoid;
            }
            set
            {
                this.Videoid = value;
            }
        }

        public string VideoName
        {
            get
            {
                return this.Videoname;
            }
            set
            {
                this.Videoname = value;
            }
        }

        public bool VideoType
        {
            get
            {
                return this.videoType;
            }
            set
            {
                this.videoType = value;
            }
        }

        public string VideoUrl
        {
            get
            {
                return this.Videourl;
            }
            set
            {
                this.Videourl = value;
            }
        }

        public string VideoEmbed
        {
            get { return this.videoEmbed; }
            set { this.videoEmbed = value; }
        }
    }
}

