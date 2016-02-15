namespace ETO
{
    using System;

    public class Pages
    {
        private DateTime approvalDate;
        private string approvalUserName;
        private string author;
        private int commentTotal;
        private string createdUserName;
        private string describe;
        private string icon;
        private string imagethumb;
        private bool isApproval;
        private bool isComment;
        private bool isView;
        private string language;
        private string pagecontent;
        private int pageid;
        private string pagename;
        private string pagetitle;
        private bool pagetype;
        private int parentPageID;
        private DateTime postdate;
        private bool status;
        private int visitTotal;

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

        public string Describe
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

        public string Icon
        {
            get
            {
                return this.icon;
            }
            set
            {
                this.icon = value;
            }
        }

        public string Imagethumb
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

        public string PageContent
        {
            get
            {
                return this.pagecontent;
            }
            set
            {
                this.pagecontent = value;
            }
        }

        public int PageID
        {
            get
            {
                return this.pageid;
            }
            set
            {
                this.pageid = value;
            }
        }

        public string PageName
        {
            get
            {
                return this.pagename;
            }
            set
            {
                this.pagename = value;
            }
        }

        public string PageTitle
        {
            get
            {
                return this.pagetitle;
            }
            set
            {
                this.pagetitle = value;
            }
        }

        public bool PageType
        {
            get
            {
                return this.pagetype;
            }
            set
            {
                this.pagetype = value;
            }
        }

        public int ParentPageID
        {
            get
            {
                return this.parentPageID;
            }
            set
            {
                this.parentPageID = value;
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

        public int VisitTotal
        {
            get
            {
                return this.visitTotal;
            }
            set
            {
                this.visitTotal = value;
            }
        }
    }
}

