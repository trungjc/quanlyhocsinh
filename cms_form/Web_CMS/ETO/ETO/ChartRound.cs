namespace ETO
{
    using System;

    public class ChartRound
    {
        private int _value;
        private string chartName;
        private DateTime chartpostdate;
        private int chartRoundid;
        private int chartRoundParentid;
        private bool chartstatus;

        public string ChartName
        {
            get
            {
                return this.chartName;
            }
            set
            {
                this.chartName = value;
            }
        }

        public DateTime ChartPostDate
        {
            get
            {
                return this.chartpostdate;
            }
            set
            {
                this.chartpostdate = value;
            }
        }

        public int ChartRoundID
        {
            get
            {
                return this.chartRoundid;
            }
            set
            {
                this.chartRoundid = value;
            }
        }

        public int ChartRoundParentID
        {
            get
            {
                return this.chartRoundParentid;
            }
            set
            {
                this.chartRoundParentid = value;
            }
        }

        public bool ChartStatus
        {
            get
            {
                return this.chartstatus;
            }
            set
            {
                this.chartstatus = value;
            }
        }

        public int Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
}

