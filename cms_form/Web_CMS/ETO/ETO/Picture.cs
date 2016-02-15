namespace ETO
{
    using System;

    public class Picture
    {
        private int pictureid;
        private string picturelarge;
        private string picturethumb;
        private int productid;

        public int PictureID
        {
            get
            {
                return this.pictureid;
            }
            set
            {
                this.pictureid = value;
            }
        }

        public string PictureLarge
        {
            get
            {
                return this.picturelarge;
            }
            set
            {
                this.picturelarge = value;
            }
        }

        public string PictureThumb
        {
            get
            {
                return this.picturethumb;
            }
            set
            {
                this.picturethumb = value;
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
    }
}

