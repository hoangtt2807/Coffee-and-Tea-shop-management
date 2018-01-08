using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyCafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }
        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "SELECT dbo.FOOD.NAME,dbo.FOOD.PRICE,dbo.BILLINFO.COUNT,dbo.FOOD.PRICE * dbo.BILLINFO.COUNT AS TotalPrice FROM dbo.BILL,dbo.BILLINFO,dbo.FOOD WHERE dbo.BILLINFO.IDBILL = dbo.BILL.ID AND dbo.BILLINFO.IDFOOD = dbo.FOOD.ID AND dbo.BILL.Status = 0 AND dbo.BILL.IDTABLE= " + id;

            DataTable data = DataProvider.Instance.ExcuteQuery(query);


            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);

                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
