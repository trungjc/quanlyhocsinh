namespace ETO
{
    using System;

    public class Album
    {
        private int albumid;
        private int catenewsid;
        private string imagelarge;
        private string imagethumb;
        private bool ishome;
        private int order;

        public int AlbumID
        {
            get
            {
                return this.albumid;
            }
            set
            {
                this.albumid = value;
            }
        }

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
    }
}

