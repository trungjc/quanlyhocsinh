namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class SinglePageBSO
    {
        public void CreateSinglePage(SinglePage singlepage)
        {
            new SinglePageDAO().CreateSinglePage(singlepage);
        }

        public void DeleteSinglePage(int singleId)
        {
            new SinglePageDAO().DeleteSinglePage(singleId);
        }

        public DataTable GetSinglePageAll(string language)
        {
            SinglePageDAO singlePageDAO = new SinglePageDAO();
            return singlePageDAO.GetSinglePageAll(0, language);
        }

        public DataTable GetSinglePageAll(string language, int num)
        {
            SinglePageDAO singlePageDAO = new SinglePageDAO();
            return singlePageDAO.GetSinglePageAll(language, num);
        }

        public DataTable GetSinglePageAll(string language, int num, int day)
        {
            SinglePageDAO singlePageDAO = new SinglePageDAO();
            return singlePageDAO.GetSinglePageAll(language, num, day);
        }

        public SinglePage GetSinglePageById(int singleID)
        {
            SinglePageDAO singlePageDAO = new SinglePageDAO();
            return singlePageDAO.SinglePageGetById(singleID, "");
        }

        public void UpdateSinglePage(SinglePage singlepage)
        {
            new SinglePageDAO().UpdateSinglePage(singlepage);
        }
    }
}

