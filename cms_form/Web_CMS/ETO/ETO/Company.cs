namespace ETO
{
    using System;

    public class Company
    {
        private DateTime approvalDate;
        private string approvalUserName;
        private string author;
        private int categories;
        private int commentTotal;
        private int companyid;
        private DateTime createdDate;
        private string createdUserName;
        private string description;
        private int groupCate;
        private bool isApproval;
        private bool isComment;
        private bool isdefault;
        private bool ishot;
        private bool isnormal;
        private string language;
        private string title;
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

        public int Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
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

        public int CompanyID
        {
            get
            {
                return this.companyid;
            }
            set
            {
                this.companyid = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return this.createdDate;
            }
            set
            {
                this.createdDate = value;
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
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public int GroupCate
        {
            get
            {
                return this.groupCate;
            }
            set
            {
                this.groupCate = value;
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

        public bool IsDefault
        {
            get
            {
                return this.isdefault;
            }
            set
            {
                this.isdefault = value;
            }
        }

        public bool IsHot
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

        public bool IsNormal
        {
            get
            {
                return this.isnormal;
            }
            set
            {
                this.isnormal = value;
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

