namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class PhoneBookBSO
    {
        private PhoneBookDAO objDAO = new PhoneBookDAO();

        public void CreatePhoneBook(PhoneBook _obj)
        {
            this.objDAO.CreatePhoneBook(_obj);
        }

        public void Delete(int _Id)
        {
            this.objDAO.Delete(_Id);
        }

        public DataTable GetDepartMent()
        {
            return this.objDAO.GetDepartMent();
        }

        public DataTable GetDetial(int _id)
        {
            return this.objDAO.GetDetial(_id);
        }

        public DataTable GetListPhoneBook()
        {
            return this.objDAO.GetListPhoneBook();
        }

        public DataTable GetListPhoneBook(int _departMent, string _fullName)
        {
            return this.objDAO.GetListPhoneBook(_departMent, _fullName);
        }

        public DataTable MixPhoneBook()
        {
            return this.objDAO.MixPhoneBook();
        }

        public DataTable PhoneBookGetAll()
        {
            return this.objDAO.PhoneBookGetAll();
        }

        public DataTable PhoneBookGetParentID(int pID)
        {
            return this.objDAO.PhoneBookGetParentID(pID);
        }

        public void PhoneBookUpOrder(int _Id, int _Order)
        {
            this.objDAO.PhoneBookUpOrder(_Id, _Order);
        }

        public void UpdatePhoneBook(PhoneBook _phoneBook)
        {
            this.objDAO.UpdatePhoneBook(_phoneBook);
        }
    }
}

