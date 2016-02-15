namespace ETO
{
    using System;

    public class ListQuestion
    {
        private DateTime approvalDate;
        private string approvalUserName;
        private int cateNewsID;
        private DateTime createDate;
        private string createUserName;
        private bool isApproval;
        private bool isShowInHome;
        private string question_Content;
        private string question_FileAttach;
        private int question_ID;
        private string question_Image;
        private int question_ParentID;
        private string question_Title;
        private int questionStatus;

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

        public int CateNewsID
        {
            get
            {
                return this.cateNewsID;
            }
            set
            {
                this.cateNewsID = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return this.createDate;
            }
            set
            {
                this.createDate = value;
            }
        }

        public string CreateUserName
        {
            get
            {
                return this.createUserName;
            }
            set
            {
                this.createUserName = value;
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

        public bool IsShowInHome
        {
            get
            {
                return this.isShowInHome;
            }
            set
            {
                this.isShowInHome = value;
            }
        }

        public string Question_Content
        {
            get
            {
                return this.question_Content;
            }
            set
            {
                this.question_Content = value;
            }
        }

        public string Question_FileAttach
        {
            get
            {
                return this.question_FileAttach;
            }
            set
            {
                this.question_FileAttach = value;
            }
        }

        public int Question_ID
        {
            get
            {
                return this.question_ID;
            }
            set
            {
                this.question_ID = value;
            }
        }

        public string Question_Image
        {
            get
            {
                return this.question_Image;
            }
            set
            {
                this.question_Image = value;
            }
        }

        public int Question_ParentID
        {
            get
            {
                return this.question_ParentID;
            }
            set
            {
                this.question_ParentID = value;
            }
        }

        public string Question_Title
        {
            get
            {
                return this.question_Title;
            }
            set
            {
                this.question_Title = value;
            }
        }

        public int QuestionStatus
        {
            get
            {
                return this.questionStatus;
            }
            set
            {
                this.questionStatus = value;
            }
        }
    }
}

