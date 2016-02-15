namespace ETO
{
    using System;

    public class CateProduct
    {
        private int cateproductid;
        private string cateproductname;
        private int cateproductorder;
        private int cateproducttotal;
        private string icon;
        private string language;
        private int parentproductid;
        private string slogan;

        public int CateProductID
        {
            get
            {
                return this.cateproductid;
            }
            set
            {
                this.cateproductid = value;
            }
        }

        public string CateProductName
        {
            get
            {
                return this.cateproductname;
            }
            set
            {
                this.cateproductname = value;
            }
        }

        public int CateProductOrder
        {
            get
            {
                return this.cateproductorder;
            }
            set
            {
                this.cateproductorder = value;
            }
        }

        public int CateProductTotal
        {
            get
            {
                return this.cateproducttotal;
            }
            set
            {
                this.cateproducttotal = value;
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

        public int ParentProductID
        {
            get
            {
                return this.parentproductid;
            }
            set
            {
                this.parentproductid = value;
            }
        }

        public string Slogan
        {
            get
            {
                return this.slogan;
            }
            set
            {
                this.slogan = value;
            }
        }
    }
}

