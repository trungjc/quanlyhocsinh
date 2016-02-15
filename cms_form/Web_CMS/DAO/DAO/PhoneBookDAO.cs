namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;

    public class PhoneBookDAO : BaseDAO
    {
        public void CreatePhoneBook(PhoneBook _phoneBook)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("CreatePhoneBook", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@FullName", _phoneBook.FullName);
                command.Parameters.AddWithValue("@Email", _phoneBook.Email);
                command.Parameters.AddWithValue("@Phone1", _phoneBook.Phone1);
                command.Parameters.AddWithValue("@Phone2", _phoneBook.Phone2);
                command.Parameters.AddWithValue("@HomePhone", _phoneBook.HomePhone);
                command.Parameters.AddWithValue("@Officephone", _phoneBook.Officephone);
                command.Parameters.AddWithValue("@Address", _phoneBook.Address);
                command.Parameters.AddWithValue("@ParentId", _phoneBook.ParentId);
                command.Parameters.AddWithValue("@CreatorId", _phoneBook.CreatorId);
                command.Parameters.AddWithValue("@Orders", _phoneBook.Orders);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void Delete(int _Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = (" Delete tblPhoneBook Where Id= " + _Id) + " Delete tblPhoneBook Where ParentId =" + _Id;
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
        }

        public DataTable GetDepartMent()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook Where ParentId=0 Order by [Orders]";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetDetial(int _id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook Where Id= " + _id;
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetListPhoneBook()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetListPhoneBook(int _departMent, string _fullName)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook Where 1=1 ";
                string _cond = "";
                if (_departMent <= 0)
                {
                    SQL = "select *,";
                    SQL = ((((((SQL + "(select Fullname from tblPhoneBook as A1" + "    where A1.Id=A.ParentId  ") + ") AS GruopFull" + ",") + "(" + "    select Orders from tblPhoneBook as A3") + "    where A3.Id=A.ParentId  " + ") AS Orders1 ") + " from tblPhoneBook AS A " + " Where ParentId IN ") + "(" + "   select Top(100000) ParentId From tblPhoneBook") + "  Where ParentId!=0 ORDER BY Orders " + ")";
                }
                else
                {
                    SQL = "select *,";
                    SQL = ((((((SQL + "(select Fullname from tblPhoneBook as A1" + "    where A1.Id=A.ParentId") + ") AS GruopFull" + ",") + "(" + "    select Orders from tblPhoneBook as A3") + "    where A3.Id=A.ParentId  " + ") AS Orders1 ") + " from tblPhoneBook AS A " + " Where ParentId IN ") + "(" + "   select Top(100000) ParentId From tblPhoneBook") + "  Where ParentId!=0 ORDER BY Orders " + ")";
                    _cond = _cond + " AND ParentId=" + _departMent;
                }
                if (_fullName.Trim() != "")
                {
                    _cond = _cond + " AND FullName Like'%" + _fullName + "%'";
                }
                SQL = SQL + _cond + " Order by Orders1 ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable MixPhoneBook()
        {
            DataTable table2 = this.PhoneBookGetParentID(0);
            DataTable table1 = table2.Clone();
            foreach (DataRow r2 in table2.Rows)
            {
                table1.ImportRow(r2);
                this.SubMixPhoneBook(table1, Convert.ToInt32(r2["ID"]), "");
            }
            return table1;
        }

        public DataTable PhoneBookGetAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable PhoneBookGetParentID(int parentID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook Where ParentId=" + parentID + " Order by [Orders]";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public void PhoneBookUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PhoneBookUpOrder", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", cId);
                command.Parameters.AddWithValue("@Orders", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật danh mục tin");
                }
                command.Dispose();
            }
        }

        public void SubMixPhoneBook(DataTable table, int mID, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();
            subTable = this.PhoneBookGetParentID(mID);
            if (subTable.Rows.Count > 0)
            {
                foreach (DataRow subrow in subTable.Rows)
                {
                    subrow["FullName"] = sSpace + subrow["FullName"].ToString();
                    table.ImportRow(subrow);
                    this.SubMixPhoneBook(table, Convert.ToInt32(subrow["ID"]), "");
                }
            }
        }

        public void UpdatePhoneBook(PhoneBook _phoneBook)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("UpdatePhoneBook", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@FullName", _phoneBook.FullName);
                command.Parameters.AddWithValue("@Email", _phoneBook.Email);
                command.Parameters.AddWithValue("@Phone1", _phoneBook.Phone1);
                command.Parameters.AddWithValue("@Phone2", _phoneBook.Phone2);
                command.Parameters.AddWithValue("@HomePhone", _phoneBook.HomePhone);
                command.Parameters.AddWithValue("@Officephone", _phoneBook.Officephone);
                command.Parameters.AddWithValue("@Address", _phoneBook.Address);
                command.Parameters.AddWithValue("@ParentId", _phoneBook.ParentId);
                command.Parameters.AddWithValue("@Id", _phoneBook.Id);
                command.Parameters.AddWithValue("@Orders", _phoneBook.Orders);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }
    }
}

