namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class ContactBSO
    {
        public void CreateContact(Contact contact)
        {
            new ContactDAO().CreateContact(contact);
        }

        public void DeleteContact(int Id)
        {
            new ContactDAO().DeleteContact(Id);
        }

        public DataTable GetContactAll()
        {
            ContactDAO contactDAO = new ContactDAO();
            return contactDAO.GetContactAll();
        }

        public Contact GetContactById(int Id)
        {
            ContactDAO contactDAO = new ContactDAO();
            return contactDAO.GetContactById(Id);
        }

        public void UpdateContact(Contact contact)
        {
            new ContactDAO().UpdateContact(contact);
        }
    }
}

