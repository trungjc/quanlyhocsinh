namespace ETO
{
    using System;

    public class Albums
    {
        private int albumscateid;
        private int albumsid;
        private DateTime approvalDate;
        private string approvalUserName;
        private string author;
        private int commentTotal;
        private string createdUserName;
        private string describe;
        private string fulldescribe;
        private string imagelarge;
        private string imagethumb;
        private int inview;
        private bool isApproval;
        private bool isComment;
        private bool ishome;
        private bool ishot;
        private DateTime postdate;
        private bool status;
        private string title;

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

        public int AlbumsID
        {
            get
            {
                return this.albumsid;
            }
            set
            {
                this.albumsid = value;
            }
        }

        public DateTime ApprovalDate
        {
            get
            {
                return this.approvalDate;
            }
            set
            {
                this.approvalDate = value;
            }
        }

        public string ApprovalUserName
        {
            get
            {
                return this.approvalUserName;
            }
            set
            {
                this.approvalUserName = value;
            }
        }

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

        public int CommentTotal
        {
            get
            {
                return this.commentTotal;
            }
            set
            {
                this.commentTotal = value;
            }
        }

        public string CreatedUserName
        {
            get
            {
                return this.createdUserName;
            }
            set
            {
                this.createdUserName = value;
            }
        }

        public string Description
        {
            get
            {
                return this.describe;
            }
            set
            {
                this.describe = value;
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

        public bool IsApproval
        {
            get
            {
                return this.isApproval;
            }
            set
            {
                this.isApproval = value;
            }
        }

        public bool IsComment
        {
            get
            {
                return this.isComment;
            }
            set
            {
                this.isComment = value;
            }
        }

        public bool Ishome
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

        public bool Ishot
        {
            get
            {
                return this.ishot;
            }
            set
            {
                this.ishot = value;
            }
        }

        public int Isview
        {
            get
            {
                return this.inview;
            }
            set
            {
                this.inview = value;
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

