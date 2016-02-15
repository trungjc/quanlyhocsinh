namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class VideoBSO
    {
        public void CreateVideo(Video Video)
        {
            new VideoDAO().CreateVideo(Video);
        }

        public void DeleteVideo(int Id)
        {
            new VideoDAO().DeleteVideo(Id);
        }

        public DataTable GetVideoAll(string lang)
        {
            VideoDAO VideoDAO = new VideoDAO();
            return VideoDAO.GetVideoAll(lang);
        }

        public Video GetVideoById(int Id)
        {
            VideoDAO VideoDAO = new VideoDAO();
            return VideoDAO.GetVideoById(Id);
        }

        public Video GetVideoHot(string lang)
        {
            VideoDAO VideoDAO = new VideoDAO();
            return VideoDAO.GetVideoHot(lang);
        }

        public void UpdateVideo(Video Video)
        {
            new VideoDAO().UpdateVideo(Video);
        }
    }
}

