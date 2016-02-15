namespace ETO
{
    using System;

    public class Brand
    {
        private int brandid;
        private string brandname;
        private string brandurl;
        private string image;
        private string language;
        private string shortdescribe;

        public int BrandID
        {
            get
            {
                return this.brandid;
            }
            set
            {
                this.brandid = value;
            }
        }

        public string BrandName
        {
            get
            {
                return this.brandname;
            }
            set
            {
                this.brandname = value;
            }
        }

        public string BrandUrl
        {
            get
            {
                return this.brandurl;
            }
            set
            {
                this.brandurl = value;
            }
        }

        public string Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
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
    }
}

