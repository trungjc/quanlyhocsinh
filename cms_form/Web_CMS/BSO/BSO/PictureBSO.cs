namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class PictureBSO
    {
        public void CreatePicture(Picture picture)
        {
            new PictureDAO().CreatePicture(picture);
        }

        public void DeletePicture(int Id)
        {
            new PictureDAO().DeletePicture(Id);
        }

        public DataTable GetPictureByProduct(int pId)
        {
            PictureDAO pictureDAO = new PictureDAO();
            return pictureDAO.GetPictureByProduct(pId);
        }

        public void UpdatePicture(Picture picture)
        {
            new PictureDAO().UpdatePicture(picture);
        }
    }
}

