namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class RelationBSO
    {
        public void CreateRelation(Relation relation)
        {
            new RelationDAO().CreateRelation(relation);
        }

        public void DeleteRelation(int rId)
        {
            new RelationDAO().DeleteRelation(rId);
        }

        public Relation GetRelationById(int rId)
        {
            RelationDAO relationDAO = new RelationDAO();
            return relationDAO.GetRelationById(rId);
        }

        public DataTable GetRelationByNews(int nId)
        {
            RelationDAO relationDAO = new RelationDAO();
            return relationDAO.GetRelationByNews(nId);
        }

        public void RelationDeleteNews(int newsId)
        {
            new RelationDAO().RelationDeleteNews(newsId);
        }

        public void RelationUpdateNews(int newsId)
        {
            new RelationDAO().RelationUpdateNews(newsId);
        }

        public void UpdateRelation(Relation relation)
        {
            new RelationDAO().UpdateRelation(relation);
        }
    }
}

