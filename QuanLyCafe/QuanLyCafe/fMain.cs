using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fMain : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public fMain(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbbSwitchTable);
        }

        /*-----------------------------------------------------------------------------*/

        void ChangeAccount(int type)
        {
            mnsAdmin.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text +=" ("+ LoginAccount.DisplayName + ")";
        }

        /*-----------------------------------------------------------------------------*/

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();

            cbbCategory.DataSource = listCategory;
            cbbCategory.DisplayMember = "Name";
        }

        /*-----------------------------------------------------------------------------*/

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);

            cbbFood.DataSource = listFood;
            cbbFood.DisplayMember = "Name";
        }

        /*-----------------------------------------------------------------------------*/

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;

            id = selected.Id;

            LoadFoodListByCategoryID(id);
        }

        /*-----------------------------------------------------------------------------*/

        void LoadTable()
        {

            flpTable.Controls.Clear();

            List<Table> tablelist = TableDAO.Instance.LoadTableList();
            
            foreach (Table item in tablelist)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };

                btn.Image = Image.FromFile("image\\table1.png");
                btn.Font = new Font("Microsoft Sans Serif", 9f);
                btn.ForeColor = Color.Purple;

                btn.Text = item.Name + Environment.NewLine + item.Status;

                btn.Click += btn_Click;

                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.Image = Image.FromFile("image\\table3.png");
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }


        /*-----------------------------------------------------------------------------*/

        
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<QuanLyCafe.DTO.Menu> ListBillInfo = MenuDAO.Instance.GetListMenuByTable(id);

            float totalPrice = 0;

            foreach (QuanLyCafe.DTO.Menu item in ListBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());

                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            } 
            CultureInfo culture = new CultureInfo("vi-VN");
            txbTotalPrice.Text = totalPrice.ToString("c", culture);
        }


        /*-----------------------------------------------------------------------------*/

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }

        /*-----------------------------------------------------------------------------*/

        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;

            lsvBill.Tag = (sender as Button).Tag;

            ShowBill(tableID);
        }

        /*-----------------------------------------------------------------------------*/

        private void mnsAdmin_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            this.Hide();
            f.ShowDialog();
        }

        /*-----------------------------------------------------------------------------*/

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbbFood.SelectedItem as Food).ID;
            int count = (int)nmrAddFood.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);

                BillinfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxBill(), foodID, count);
            }
            else 
            {
                BillinfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }

            ShowBill(table.ID);

            LoadTable();
        }


        /*-----------------------------------------------------------------------------*/


        private void btnPay_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            try
            {
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                int discount = (int)nmrSale.Value;
                double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]) * 1000;
                double sale = totalPrice * discount / 100;
                double FinalTotalprice = (totalPrice - sale);

                if (idBill != -1)
                {

                    if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn thanh toán hóa đơn cho bàn {0}\n{1} - {2} = {3}đ", table.Name, totalPrice, sale, FinalTotalprice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        BillDAO.Instance.CheckOut(idBill, discount, (float)FinalTotalprice);
                        ShowBill(table.ID);

                        LoadTable();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn bàn muốn thanh toán!");
            }
        }


        /*-----------------------------------------------------------------------------*/

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.UpdateAccount+=f_UpdateAccount;
            f.ShowDialog();
        }

        void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName+ ")";
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as Table).ID;

            int id2 = (cbbSwitchTable.SelectedItem as Table).ID;

            if (MessageBox.Show(string.Format("Bạn có muốn chuyển bàn {0} qua {1}", (lsvBill.Tag as Table).Name, (cbbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) ;

            TableDAO.Instance.SwitchTable(id1, id2);
            
            LoadTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fHoadon f = new fHoadon(this);
    
            f.ShowDialog();
            
        }

        private void fMain_Load(object sender, EventArgs e)
        {

        }
    }
}
