namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class BookBSO
    {
        public DataTable BookSearch(string keyword, int cId)
        {
            BookDAO bookDAO = new BookDAO();
            return bookDAO.BookSearch(keyword, cId);
        }

        public void CreateBook(Book book)
        {
            new BookDAO().CreateBook(book);
        }

        public void DeleteBook(int Id)
        {
            new BookDAO().DeleteBook(Id);
        }

        public DataTable GetBookAll()
        {
            BookDAO bookDAO = new BookDAO();
            return bookDAO.GetBookAll();
        }

        public Book GetBookById(int Id)
        {
            BookDAO bookDAO = new BookDAO();
            return bookDAO.GetBookById(Id);
        }

        public DataTable GetBookByProductId(int Id)
        {
            BookDAO bookDAO = new BookDAO();
            return bookDAO.GetBookByProductId(Id);
        }

        public DataTable GetBookProductAll()
        {
            BookDAO bookDAO = new BookDAO();
            return bookDAO.GetBookProductAll();
        }

        public void UpdateBook(Book book)
        {
            new BookDAO().UpdateBook(book);
        }

        public void UpdateBook(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new BookDAO().UpdateBook(restr, value);
        }
    }
}

