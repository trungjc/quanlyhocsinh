namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class AlbumBSO
    {
        public void AlbumUpOrder(int cId, int cOrder)
        {
            new AlbumDAO().AlbumUpOrder(cId, cOrder);
        }

        public void CreateAlbum(Album album)
        {
            new AlbumDAO().CreateAlbum(album);
        }

        public void DeleteAlbum(int Id)
        {
            new AlbumDAO().DeleteAlbum(Id);
        }

        public DataTable GetAlbumAll()
        {
            AlbumDAO albumDAO = new AlbumDAO();
            return albumDAO.GetAlbumAll();
        }

        public DataTable GetAlbumByCate(int cId)
        {
            AlbumDAO albumDAO = new AlbumDAO();
            return albumDAO.GetAlbumByCate(cId);
        }

        public Album GetAlbumByID(int id)
        {
            AlbumDAO albumDAO = new AlbumDAO();
            return albumDAO.GetAlbumById(id);
        }

        public DataTable GetAlbumByIsHome()
        {
            AlbumDAO albumDAO = new AlbumDAO();
            return albumDAO.GetAlbumIsHome();
        }

        public void UpdateAlbum(Album album)
        {
            new AlbumDAO().UpdateAlbum(album);
        }
    }
}

