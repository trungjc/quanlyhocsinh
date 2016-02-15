namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class EmailBSO
    {
        public bool CheckExist(string EmailAddress)
        {
            bool exist = false;
            DataTable dataTable = this.GetEmailAll();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = "EmailAddress = '" + EmailAddress + "'"
                };
                if (dataView.Count > 0)
                {
                    exist = true;
                }
            }
            return exist;
        }

        public void CreateEmail(Email email)
        {
            new EmailDAO().CreateEmail(email);
        }

        public void DeleteEmail(int Id)
        {
            new EmailDAO().DeleteEmail(Id);
        }

        public DataTable GetEmailAll()
        {
            EmailDAO emailDAO = new EmailDAO();
            return emailDAO.GetEmailAll();
        }

        public Email GetEmailById(int Id)
        {
            EmailDAO emailDAO = new EmailDAO();
            return emailDAO.GetEmailById(Id);
        }

        public void UpdateEmail(Email email)
        {
            new EmailDAO().UpdateEmail(email);
        }
    }
}

