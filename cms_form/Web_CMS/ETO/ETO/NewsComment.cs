namespace ETO
{
    using System;

    public class NewsComment
    {
        private bool actived;
        private DateTime approvalDate;
        private string approvalUserName;
        private int commentNewsID;
        private string content;
        private DateTime dateCreated;
        private string email;
        private string fullName;
        private int groupCate;
        private int Newsid;
        private string title;

        public bool Actived
        {
            get
            {
                return this.actived;
            }
            set
            {
                this.actived = value;
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

        public int CommentNewsID
        {
            get
            {
                return this.commentNewsID;
            }
            set
            {
                this.commentNewsID = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated;
            }
            set
            {
                this.dateCreated = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = value;
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

        public int NewsID
        {
            get
            {
                return this.Newsid;
            }
            set
            {
                this.Newsid = value;
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

