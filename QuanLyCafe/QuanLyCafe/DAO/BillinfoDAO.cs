using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DAO
{
    public class BillinfoDAO
    {
        private static BillinfoDAO instance;

        public static BillinfoDAO Instance
        {
            get { if (instance == null) instance = new BillinfoDAO(); return BillinfoDAO.instance; }
            private set { BillinfoDAO.instance = value; }
        }
        private BillinfoDAO() { }


        public void DeleteBilInfoByFoodID(int id)
        {
            DataProvider.Instance.ExcuteQuery("delete dbo.BillInfo WHERE idFood = " + id);
        }


        public List<Billinfo> GetListBillInfo(int id)
        {
            List<Billinfo> ListBillInfo = new List<Billinfo>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.BILLINFO WHERE IDBILL = " + id);

            foreach (DataRow item in data.Rows)
            {
                Billinfo info = new Billinfo(item);
                ListBillInfo.Add(info);
            }

            return ListBillInfo;
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExcuteNonQuery("exec InsertBillInfo @idBill , @idFood , @count", new object[] { idBill,idFood,count });
        }
    }
}
