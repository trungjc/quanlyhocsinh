namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class OrderDetailBSO
    {
        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            new OrderDetailDAO().CreateOrderDetail(orderDetail);
        }

        public void DeleteOrderDetail(int Id)
        {
            new OrderDetailDAO().DeleteOrderDetail(Id);
        }

        public void DeleteOrderDetailOrder(int Id)
        {
            new OrderDetailDAO().DeleteOrderDetailOrder(Id);
        }

        public DataTable GetOrderDetailAll()
        {
            OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
            return orderDetailDAO.GetOrderDetailAll();
        }

        public OrderDetail GetOrderDetailById(int Id)
        {
            OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
            return orderDetailDAO.GetOrderDetailById(Id);
        }

        public DataTable GetOrderDetailByOrderId(int Id)
        {
            OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
            return orderDetailDAO.GetOrderDetailByOrderId(Id);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            new OrderDetailDAO().UpdateOrderDetail(orderDetail);
        }
    }
}

