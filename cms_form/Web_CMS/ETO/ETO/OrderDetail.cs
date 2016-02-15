namespace ETO
{
    using System;

    public class OrderDetail
    {
        private int orderDetailId;
        private int orderId;
        private double price;
        private int productID;
        private int quatity;

        public int OrderDetailID
        {
            get
            {
                return this.orderDetailId;
            }
            set
            {
                this.orderDetailId = value;
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

