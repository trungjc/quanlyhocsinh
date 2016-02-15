namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class CartInfoBSO
    {
        public bool CheckExistProduct(int orderId, int productId)
        {
            bool exist = false;
            DataTable dataTable = this.GetCartInfoAll();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = string.Concat(new object[] { "OrderID = ", orderId, " and ProductID = ", productId })
                };
                if (dataView.Count > 0)
                {
                    exist = true;
                }
            }
            return exist;
        }

        public void CreateCartInfo(CartInfo cartInfo)
        {
            new CartInfoDAO().CreateCartInfo(cartInfo);
        }

        public void DeleteCartInfo(int orderID)
        {
            new CartInfoDAO().DeleteCartInfo(orderID);
        }

        public void DeleteCartInfoProduct(int orderID, int productID)
        {
            new CartInfoDAO().DeleteCartInfoProduct(orderID, productID);
        }

        public void DeleteCartInfoProduct(int orderID, string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new CartInfoDAO().DeleteCartInfoProduct(orderID, restr);
        }

        public DataTable GetCartInfoAll()
        {
            CartInfoDAO cartInfoDAO = new CartInfoDAO();
            return cartInfoDAO.GetCartInfoAll();
        }

        public CartInfo GetCartInfoById(int cartInfoID)
        {
            CartInfoDAO cartInfoDAO = new CartInfoDAO();
            return cartInfoDAO.GetCartInfoById(cartInfoID);
        }

        public DataTable GetCartInfoByOrderId(int orderID)
        {
            CartInfoDAO cartInfoDAO = new CartInfoDAO();
            return cartInfoDAO.GetCartInfoByOrderId(orderID);
        }

        public CartInfo GetCartInfoByProductId(int orderID, int productID)
        {
            CartInfoDAO cartInfoDAO = new CartInfoDAO();
            return cartInfoDAO.GetCartInfoByProductId(orderID, productID);
        }

        public int GetQuatity(int orderId, int productId)
        {
            int quatity = 0;
            DataTable dataTable = this.GetCartInfoAll();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = string.Concat(new object[] { "OrderID = ", orderId, " and ProductID = ", productId })
                };
                if (dataView.Count > 0)
                {
                    quatity = Convert.ToInt32(dataView.Table.Rows[0]["Quatity"].ToString());
                }
            }
            return quatity;
        }

        public DataTable GetTableCartInfoByProductId(int orderID, int productID)
        {
            CartInfoDAO cartInfoDAO = new CartInfoDAO();
            return cartInfoDAO.GetTableCartInfoByProductId(orderID, productID);
        }

        public DataTable GetViewCartInfoByOrderId(int orderID)
        {
            CartInfoDAO cartInfoDAO = new CartInfoDAO();
            return cartInfoDAO.GetViewCartInfoByOrderId(orderID);
        }

        public void UpdateCartInfo(CartInfo cartInfo)
        {
            new CartInfoDAO().UpdateCartInfo(cartInfo);
        }
    }
}

