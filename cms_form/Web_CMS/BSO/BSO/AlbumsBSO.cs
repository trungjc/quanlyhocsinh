namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class AlbumsBSO
    {
        public void AlbumsClickUpdate(int nId)
        {
            new AlbumsDAO().AlbumsClickUpdate(nId);
        }

        public DataTable AlbumsFollow(int Id, int cId)
        {
            DataTable dataTable = new DataTable();
            DateTime PostTime = this.GetAlbumsById(Id).PostDate;
            DataTable table = this.GetAlbumsAll();
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = string.Concat(new object[] { "AlbumsID <> ", Id, "and CateAlbumsID = ", cId }), Sort = "PostDate DESC " }.ToTable();
            }
            return dataTable;
        }

        public DataTable AlbumsFollow(int Id, int cId, int n)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.AlbumsFollow(Id, cId, n);
        }

        public DataTable AlbumsSearch(string keyword, int cId)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.AlbumsSearch(keyword, cId);
        }

        public void CreateAlbums(Albums albums)
        {
            new AlbumsDAO().CreateAlbums(albums);
        }

        public void DeleteAlbums(int nId)
        {
            new AlbumsDAO().DeleteAlbums(nId);
        }

        public void DeleteAlbums(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new AlbumsDAO().DeleteAlbums(restr);
        }

        public DataTable GetAlbumsAll()
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsAll();
        }

        public DataTable GetAlbumsByCate(int iCateId)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetAlbumsAll();
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "AlbumsCateID = " + iCateId + " and Status = 'True' ", Sort = "PostDate Desc " }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetAlbumsByCateAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateAll(restr);
        }

        public DataTable GetAlbumsByCateHomeAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeAll(restr);
        }

        public DataTable GetAlbumsByCateHomeAll(int n, string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeAll(n, restr);
        }

        public DataTable GetAlbumsByCateHomeAll(int n, string strCate, string approval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeAll(n, restr, approval);
        }

        public DataTable GetAlbumsByCateHomeList(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeList(restr);
        }

        public DataTable GetAlbumsByCateHomeList(string strCate, int num)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeList(restr, num);
        }

        public DataTable GetAlbumsByCateHomeList(string strCate, int num, string approval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeList(restr, num, approval);
        }

        public Albums GetAlbumsById(int nId)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsById(nId);
        }

        public DataTable GetAlbumsHot()
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsHot();
        }

        public DataTable GetAlbumsHot(int n)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsHot(n);
        }

        public DataTable GetAlbumsHot(int n, string approval)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsHot(n, approval);
        }

        public DataTable GetAlbumsView()
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsView();
        }

        public DataTable GetAlbumsViewHome()
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsViewHome();
        }

        public DataTable GetAlbumsViewHome(int n)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsViewHome(n);
        }

        public DataTable GetAlbumsViewHome(int n, string approval)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsViewHome(n, approval);
        }

        public void UpdateAlbums(Albums albums)
        {
            new AlbumsDAO().UpdateAlbums(albums);
        }

        public void UpdateAlbums(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new AlbumsDAO().UpdateAlbums(restr, value);
        }

        public void UpdateAlbumsApproval(int Id, string value, string username, DateTime date)
        {
            new AlbumsDAO().UpdateAlbumsApproval(Id, value, username, date);
        }

        public void UpdateAlbumsApproval(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new AlbumsDAO().UpdateAlbumsApproval(restr, value, username, date);
        }
    }
}

