using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSO;

namespace CMS
{
    public class WebHitCounter
    {
        public void UpdateHitCounter(long hitcouter)
        {
            HitCounterBSO hitcounterBSO = new HitCounterBSO();
            hitcounterBSO.UpdateHitCounter(hitcouter);
        }

        public long GetHitCounter()
        {
            HitCounterBSO hitcounterBSO = new HitCounterBSO();
            return hitcounterBSO.GetHitCounter();
        }
    }
}