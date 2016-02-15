namespace ETO
{
    using System;

    public class Relation
    {
        private string author;
        private string fulldescribe;
        private string imagelarge;
        private string imagethumb;
        private string language;
        private int newsid;
        private DateTime postdate;
        private int relationid;
        private string shortdescribe;
        private bool status;
        private string title;

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                this.author = value;
            }
        }

        public string FullDescribe
        {
            get
            {
                return this.fulldescribe;
            }
            set
            {
                this.fulldescribe = value;
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

        public int NewsID
        {
            get
            {
                return this.newsid;
            }
            set
            {
                this.newsid = value;
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

        public int RelationID
        {
            get
            {
                return this.relationid;
            }
            set
            {
                this.relationid = value;
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

