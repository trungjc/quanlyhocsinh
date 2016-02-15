namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class MemberBSO
    {
        public bool CheckExist(string UserName)
        {
            bool exist = false;
            DataTable dataTable = this.GetAllMember();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = "Username = '" + UserName + "'"
                };
                if (dataView.Count > 0)
                {
                    exist = true;
                }
            }
            return exist;
        }

        public bool CheckLoginMember(string name, string pass)
        {
            bool login = false;
            pass = new SecurityBSO().EncPwd(pass);
            DataTable dataTable = this.GetAllMember();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = "UserName = '" + name + "' AND Password = '" + pass + "' AND Actived = 'True'"
                };
                if (dataView.Count > 0)
                {
                    login = true;
                }
            }
            return login;
        }

        public void CreateMember(Member member)
        {
            new MemberDAO().CreateMember(member);
        }

        public void DeleteMember(string UserName)
        {
            new MemberDAO().DeleteMember(UserName);
        }

        public DataTable GetAllMember()
        {
            MemberDAO memberDAO = new MemberDAO();
            return memberDAO.GetAllMember();
        }

        public Member GetMemberById(string UserName)
        {
            MemberDAO memberDAO = new MemberDAO();
            return memberDAO.GetMemberById(UserName);
        }

        public Member GetMemberByMemberId(int memberID)
        {
            MemberDAO memberDAO = new MemberDAO();
            return memberDAO.GetMemberByMemberId(memberID);
        }

        public void UpdateMember(Member member)
        {
            new MemberDAO().UpdateMember(member);
        }
    }
}

