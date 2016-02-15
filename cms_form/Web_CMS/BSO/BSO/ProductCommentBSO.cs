namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class ProductCommentBSO
    {
        public void CreateProductComment(ProductComment productComment)
        {
            new ProductCommentDAO().CreateProductComment(productComment);
        }

        public void DeleteProductComment(int commentID)
        {
            new ProductCommentDAO().DeleteProductComment(commentID);
        }

        public void DeleteProductComment(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new ProductCommentDAO().DeleteProductComment(restr);
        }

        public DataTable GetAllProductComment()
        {
            ProductCommentDAO productCommentDAO = new ProductCommentDAO();
            return productCommentDAO.GetAllProductComment();
        }

        public DataTable GetAllViewProductComment()
        {
            ProductCommentDAO productCommentDAO = new ProductCommentDAO();
            return productCommentDAO.GetAllViewProductComment();
        }

        public ProductComment GetProductCommentById(int commentID)
        {
            ProductCommentDAO productCommentDAO = new ProductCommentDAO();
            return productCommentDAO.GetProductCommentById(commentID);
        }

        public DataTable GetProductCommentByProductID(int productID)
        {
            ProductCommentDAO productCommentDAO = new ProductCommentDAO();
            return productCommentDAO.GetProductCommentByProductID(productID);
        }

        public void UpdateProductComment(ProductComment productComment)
        {
            new ProductCommentDAO().UpdateProductComment(productComment);
        }

        public void UpdateProductComment(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new ProductCommentDAO().UpdateProductComment(restr, value);
        }
    }
}

