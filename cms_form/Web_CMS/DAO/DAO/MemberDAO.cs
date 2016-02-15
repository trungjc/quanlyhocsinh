namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class MemberDAO : BaseDAO
    {
        public void CreateMember(Member member)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@MemberID", 0);
                command.Parameters.AddWithValue("@Username", member.UserName);
                command.Parameters.AddWithValue("@Password", member.Password);
                command.Parameters.AddWithValue("@FullName", member.FullName);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@Phone", member.Phone);
                command.Parameters.AddWithValue("@Address", member.Address);
                command.Parameters.AddWithValue("@Birth", member.Birth);
                command.Parameters.AddWithValue("@Actived", member.Actived);
                command.Parameters.AddWithValue("@Sex", member.Sex);
                command.Parameters.AddWithValue("@NickYahoo", member.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", member.NickSkype);
                command.Parameters.AddWithValue("@Avatar", member.Avatar);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void DeleteMember(string UserName)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserName", UserName);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a member");
                }
                command.Dispose();
            }
        }

        public DataTable GetAllMember()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberGetAll", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public Member GetMemberById(string UserName)
        {
            Member member = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserName", UserName);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai member");
                    }
                    member = this.MemberReader(reader);
                }
                command.Dispose();
            }
            return member;
        }

        public Member GetMemberByMemberId(int memberID)
        {
            Member member = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberGetByMemberId", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MemberID", memberID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai member");
                    }
                    member = this.MemberReader(reader);
                }
                command.Dispose();
            }
            return member;
        }

        private Member MemberReader(SqlDataReader reader)
        {
            return new Member { MemberID = (int) reader["MemberID"], UserName = (string) reader["UserName"], Password = (string) reader["Password"], FullName = (string) reader["FullName"], Email = (string) reader["Email"], Phone = (string) reader["Phone"], Address = (string) reader["Address"], Birth = (DateTime) reader["Birth"], Actived = (bool) reader["Actived"], Sex = (bool) reader["Sex"], NickYahoo = (string) reader["NickYahoo"], NickSkype = (string) reader["NickSkype"], Avatar = (string) reader["Avatar"] };
        }

        public void UpdateMember(Member member)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@MemberID", member.MemberID);
                command.Parameters.AddWithValue("@Username", member.UserName);
                command.Parameters.AddWithValue("@Password", member.Password);
                command.Parameters.AddWithValue("@FullName", member.FullName);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@Phone", member.Phone);
                command.Parameters.AddWithValue("@Address", member.Address);
                command.Parameters.AddWithValue("@Birth", member.Birth);
                command.Parameters.AddWithValue("@Actived", member.Actived);
                command.Parameters.AddWithValue("@Sex", member.Sex);
                command.Parameters.AddWithValue("@NickYahoo", member.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", member.NickSkype);
                command.Parameters.AddWithValue("@Avatar", member.Avatar);
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

