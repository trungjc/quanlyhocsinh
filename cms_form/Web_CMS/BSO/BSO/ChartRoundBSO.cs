namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class ChartRoundBSO
    {
        public int CreateChartRound(ChartRound _chartRound)
        {
            ChartRoundDAO chartRoundDAO = new ChartRoundDAO();
            return chartRoundDAO.CreateChartRound(_chartRound);
        }

        public void DeleteChartRound(int mID)
        {
            new ChartRoundDAO().DeleteChartRound(mID);
        }

        public DataTable GetAllChartRound()
        {
            ChartRoundDAO chartRoundDAO = new ChartRoundDAO();
            return chartRoundDAO.GetAllChartRound();
        }

        public ChartRound GetChartRoundById(int mID)
        {
            ChartRoundDAO chartRoundDAO = new ChartRoundDAO();
            return chartRoundDAO.GetChartRoundById(mID);
        }

        public DataTable GetChartRoundByParent(int pID)
        {
            ChartRoundDAO chartRoundDAO = new ChartRoundDAO();
            return chartRoundDAO.GetChartRoundByParent(pID);
        }

        public DataTable GetChartRoundByParentValueSort(int pID)
        {
            ChartRoundDAO chartRoundDAO = new ChartRoundDAO();
            return chartRoundDAO.GetChartRoundByParentValueSort(pID);
        }

        public DataTable GetTop1ChartRound()
        {
            ChartRoundDAO chartRoundDAO = new ChartRoundDAO();
            return chartRoundDAO.GetTop1ChartRound();
        }

        public DataTable MixChartRound()
        {
            ChartRoundDAO chartRoundDAO = new ChartRoundDAO();
            return chartRoundDAO.MixChartRound();
        }

        public int UpdateChartRound(ChartRound _chartRound)
        {
            ChartRoundDAO chartRoundDAO = new ChartRoundDAO();
            return chartRoundDAO.UpdateChartRound(_chartRound);
        }
    }
}

