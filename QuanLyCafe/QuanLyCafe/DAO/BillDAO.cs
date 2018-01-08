using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }

        /*-----------------------------------------------------------------------------*/

        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.BILL WHERE IDTABLE = " + id + " AND STATUS = 0");

            if (data.Rows.Count > 0)
            {

                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }

        /*-----------------------------------------------------------------------------*/

        public void CheckOut(int id, int discount,float totalPrice)
        {
            string query = "UPDATE dbo.BILL SET dateCheckOut = GETDATE(), status = 1," + "discount= " + discount + ", totalPrice = " + totalPrice + " WHERE id= " + id;

            DataProvider.Instance.ExcuteNonQuery(query);
        }

        /*-----------------------------------------------------------------------------*/

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExcuteNonQuery("exec InsertBill @idtable",new object[] {id});
        }

        /*-----------------------------------------------------------------------------*/

        public DataTable GETBILLLISTBYDATE(DateTime checkIn, DateTime checkOut)
        {
           return DataProvider.Instance.ExcuteQuery("exec GETLISTBILLBYDATE @checkIn , @checkOut", new object[]{checkIn,checkOut});
        }

        /*-----------------------------------------------------------------------------*/

        public DataTable GETBILLLISTBYDATEANDPAGE(DateTime checkIn, DateTime checkOut, int pageNum)
        {
            return DataProvider.Instance.ExcuteQuery("exec GETLISTBILLBYDATEANDPAGE @checkIn , @checkOut , @page", new object[] { checkIn, checkOut, pageNum});
        }

        /*-----------------------------------------------------------------------------*/

        public int GETNUMBILLBYDATE(DateTime checkIn, DateTime checkOut)
        {
            return (int)DataProvider.Instance.ExcuteScalar("exec GETNUMBILLBYDATE @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        /*-----------------------------------------------------------------------------*/
        public int GetMaxBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar(" SELECT MAX(ID) FROM dbo.BILL");
            }
            catch
            {
                return 1;
            }
        }
    }
}
