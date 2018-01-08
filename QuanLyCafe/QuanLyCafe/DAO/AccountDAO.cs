using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() {}

        public bool Login(string username, string password)
        {
            string query = "LOGIN @username , @password";

            DataTable result = DataProvider.Instance.ExcuteQuery(query,new object[]{username,password});

            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("exec UpdateAccount @userName , @displayName , @password , @newPassword", new object[]{userName,displayName,pass,newPass});

            return result > 0;
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExcuteQuery("Select Username,displayname,type FROM dbo.Accoount");
        }
        public Account GetAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.ACCOOUNT WHERE USERNAME = '" + username +"'" );

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public int InsertAccount(string name, string displayName, int type)
        {
            int result = 1;
            DataTable dt = DataProvider.Instance.ExcuteQuery("Select username From Accoount");
            
            foreach (DataRow row in dt.Rows)
            {
                 if (name == row[0].ToString())
                 {
                     result = 0;
                     break;
                 }
           }
           if (result != 0)
           {
                  string query = string.Format("INSERT dbo.Accoount( USERNAME, DISPLAYNAME , TYPE ) VALUES  ( N'{0}', N'{1}', {2})", name, displayName, type);
                  result = DataProvider.Instance.ExcuteNonQuery(query);
           }     
           return result;
        }

        public bool UpdateAccount( string name, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Accoount SET displayname = N'{1}', type={2} WHERE USERNAME =N'{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Accoount where USERNAME = N'{0}'", name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPass(string name)
        {
            string query = string.Format("update Accoount set password = N'0' where USERNAME = N'{0}'", name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
    }
}
 