namespace BSO
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class SecurityBSO
    {
        private string keyValue = "ChIpYeU";

        public string DecPwd(string password)
        {
            string originalPassword = "";
            byte[] inputByteArray = Convert.FromBase64String(password);
            originalPassword = Encoding.UTF8.GetString(inputByteArray);
            return originalPassword.Substring(0, originalPassword.Length - this.keyValue.Length);
        }

        public string EncPwd(string password)
        {
            string encryptPassword = password + this.keyValue;
            byte[] passwordBytes = Encoding.UTF8.GetBytes(encryptPassword);
            byte[] hashBytes = new MD5CryptoServiceProvider().ComputeHash(passwordBytes);
            return Convert.ToBase64String(passwordBytes);
        }

        public string Key
        {
            get
            {
                return this.keyValue;
            }
            set
            {
                this.keyValue = value;
            }
        }
    }
}

