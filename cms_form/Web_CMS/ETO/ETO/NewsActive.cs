namespace ETO
{
    using System;

	public class NewsActive
	{
        private DateTime approvalDate;
        private string approvalUserName;
        private int smallgroupcate;
        private DateTime createdDate;
        private string createdUserName;
        private DateTime datepublic;
        private bool isApproval;
        private int newsactiveid;
        private string newsactivename;
        private string quote;
        private bool status;
        private string writer;

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

        public int SmallGroupCate
        {
            get
            {
                return this.smallgroupcate;
            }
            set
            {
                this.smallgroupcate = value;
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

        public DateTime DatePublic
        {
            get
            {
                return this.datepublic;
            }
            set
            {
                this.datepublic = value;
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

        public int NewsActiveID
        {
            get
            {
                return this.newsactiveid;
            }
            set
            {
                this.newsactiveid = value;
            }
        }

        public string NewsActiveName
        {
            get
            {
                return this.newsactivename;
            }
            set
            {
                this.newsactivename = value;
            }
        }

        public string Quote
        {
            get
            {
                return this.quote;
            }
            set
            {
                this.quote = value;
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

        public string Writer
        {
            get
            {
                return this.writer;
            }
            set
            {
                this.writer = value;
            }
        }
	}
}
