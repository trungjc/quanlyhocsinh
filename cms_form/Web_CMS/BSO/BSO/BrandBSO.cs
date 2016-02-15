namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class BrandBSO
    {
        public void CreateBrand(Brand brand)
        {
            new BrandDAO().CreateBrand(brand);
        }

        public void DeleteBrand(int Id)
        {
            new BrandDAO().DeleteBrand(Id);
        }

        public DataTable GetBrandAll(string lang)
        {
            BrandDAO brandDAO = new BrandDAO();
            return brandDAO.GetBrandAll(lang);
        }

        public Brand GetBrandById(int Id)
        {
            BrandDAO brandDAO = new BrandDAO();
            return brandDAO.GetBrandById(Id);
        }

        public void UpdateBrand(Brand brand)
        {
            new BrandDAO().UpdateBrand(brand);
        }
    }
}

