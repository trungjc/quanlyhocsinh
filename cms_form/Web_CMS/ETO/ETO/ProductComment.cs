namespace ETO
{
    using System;

    public class ProductComment
    {
        private bool actived;
        private int commentid;
        private string content;
        private DateTime dateCreated;
        private string email;
        private string fullName;
        private int productid;
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

        public int CommentID
        {
            get
            {
                return this.commentid;
            }
            set
            {
                this.commentid = value;
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

        public int ProductID
        {
            get
            {
                return this.productid;
            }
            set
            {
                this.productid = value;
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

