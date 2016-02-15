namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class OrderBSO
    {
        public void CreateOrder(Order order)
        {
            new OrderDAO().CreateOrder(order);
        }

        public void DeleteOrder(int Id)
        {
            new OrderDAO().DeleteOrder(Id);
        }

        public DataTable GetOrderAll()
        {
            OrderDAO orderDAO = new OrderDAO();
            return orderDAO.GetOrderAll();
        }

        public Order GetOrderById(int Id)
        {
            OrderDAO orderDAO = new OrderDAO();
            return orderDAO.GetOrderById(Id);
        }

        public DataTable GetOrderByMemberId(int Id)
        {
            OrderDAO orderDAO = new OrderDAO();
            return orderDAO.GetOrderByMemberId(Id);
        }

        public DataTable GetOrderMemberAll()
        {
            OrderDAO orderDAO = new OrderDAO();
            return orderDAO.GetOrderMemberAll();
        }

        public DataTable OrderSearch(string keyword, int cId)
        {
            OrderDAO orderDAO = new OrderDAO();
            return orderDAO.OrderSearch(keyword, cId);
        }

        public void UpdateOrder(Order order)
        {
            new OrderDAO().UpdateOrder(order);
        }

        public void UpdateOrder(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new OrderDAO().UpdateOrder(restr, value);
        }
    }
}

