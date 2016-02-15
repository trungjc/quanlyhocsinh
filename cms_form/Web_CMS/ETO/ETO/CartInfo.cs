namespace ETO
{
    using System;

    public class CartInfo
    {
        private int cartInfoId;
        private int orderId;
        private double price;
        private int productID;
        private int quatity;

        public int CartInfoID
        {
            get
            {
                return this.cartInfoId;
            }
            set
            {
                this.cartInfoId = value;
            }
        }

        public int OrderID
        {
            get
            {
                return this.orderId;
            }
            set
            {
                this.orderId = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public int ProductID
        {
            get
            {
                return this.productID;
            }
            set
            {
                this.productID = value;
            }
        }

        public int Quatity
        {
            get
            {
                return this.quatity;
            }
            set
            {
                this.quatity = value;
            }
        }
    }
}

