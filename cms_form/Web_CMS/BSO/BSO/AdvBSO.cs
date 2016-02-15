namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class AdvBSO
    {
        public void CreateAdv(Adv adv)
        {
            new AdvDAO().CreateAdv(adv);
        }

        public void DeleteAdv(int Id)
        {
            new AdvDAO().DeleteAdv(Id);
        }

        public DataTable GetAdvAll()
        {
            AdvDAO advDAO = new AdvDAO();
            return advDAO.GetAdvAll();
        }

        public Adv GetAdvById(int Id)
        {
            AdvDAO advDAO = new AdvDAO();
            return advDAO.GetAdvById(Id);
        }

        public void UpdateAdv(Adv adv)
        {
            new AdvDAO().UpdateAdv(adv);
        }
    }
}

