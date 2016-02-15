namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class FaqBSO
    {
        public void CreateFaq(Faq faq)
        {
            new FaqDAO().CreateFaq(faq);
        }

        public void DeleteFaq(int Id)
        {
            new FaqDAO().DeleteFaq(Id);
        }

        public void FaqUpOrder(int cId, int cOrder)
        {
            new FaqDAO().FaqUpOrder(cId, cOrder);
        }

        public DataTable GetFaqAll(string lang)
        {
            FaqDAO faqDAO = new FaqDAO();
            return faqDAO.GetFaqAll(lang);
        }

        public Faq GetFaqById(int Id)
        {
            FaqDAO faqDAO = new FaqDAO();
            return faqDAO.GetFaqById(Id);
        }

        public DataTable GetFaqOther(int Id, string lang)
        {
            FaqDAO faqDAO = new FaqDAO();
            return faqDAO.GetFaqOther(Id, lang);
        }

        public void UpdateFaq(Faq faq)
        {
            new FaqDAO().UpdateFaq(faq);
        }
    }
}

