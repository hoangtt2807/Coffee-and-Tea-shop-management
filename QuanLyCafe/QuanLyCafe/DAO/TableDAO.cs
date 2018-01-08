using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 100;
        public static int TableHeight = 100;

        private TableDAO(){}

        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExcuteQuery("SwitchTable @idTable1 , @idTable2", new object[]{id1, id2});
        }

        public List<Table> LoadTableList()
        {
            List<Table> tablelist= new List<Table>();

            DataTable data = DataProvider.Instance.ExcuteQuery("GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }
            
            return tablelist;
        }
    }
}
