namespace ETO
{
    using System;

    public class HitCounter
    {
        private long hitcounter;

        public long SiteHitCounter
        {
            get
            {
                return this.hitcounter;
            }
            set
            {
                this.hitcounter = value;
            }
        }
    }
}

