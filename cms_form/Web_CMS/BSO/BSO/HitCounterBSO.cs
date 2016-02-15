namespace BSO
{
    using DAO;
    using System;

    public class HitCounterBSO
    {
        public long GetHitCounter()
        {
            HitCounterDAO hitcounterDAO = new HitCounterDAO();
            return hitcounterDAO.GetHitCounter().SiteHitCounter;
        }

        public void UpdateHitCounter(long hitcounter)
        {
            new HitCounterDAO().UpdateHitCounter(hitcounter);
        }
    }
}

