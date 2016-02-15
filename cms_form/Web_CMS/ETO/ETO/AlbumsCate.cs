namespace ETO
{
    using System;

    public class AlbumsCate
    {
        private int albumscateid;
        private string albumscatename;
        private int albumscateorder;
        private int albumscatetotal;
        private DateTime created;
        private string description;
        private string imagelarge;
        private string imagethumb;
        private int parentcateid;
        private string username;

        public int AlbumsCateID
        {
            get
            {
                return this.albumscateid;
            }
            set
            {
                this.albumscateid = value;
            }
        }

        public string AlbumsCateName
        {
            get
            {
                return this.albumscatename;
            }
            set
            {
                this.albumscatename = value;
            }
        }

        public int AlbumsCateOrder
        {
            get
            {
                return this.albumscateorder;
            }
            set
            {
                this.albumscateorder = value;
            }
        }

        public int AlbumsCateTotal
        {
            get
            {
                return this.albumscatetotal;
            }
            set
            {
                this.albumscatetotal = value;
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

        public string ImageLarge
        {
            get
            {
                return this.imagelarge;
            }
            set
            {
                this.imagelarge = value;
            }
        }

        public string ImageThumb
        {
            get
            {
                return this.imagethumb;
            }
            set
            {
                this.imagethumb = value;
            }
        }

        public int ParentCateID
        {
            get
            {
                return this.parentcateid;
            }
            set
            {
                this.parentcateid = value;
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
    }
}

