using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fHoadon : Form
    {
        fMain f;
        public fHoadon(fMain f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void fHoadon_Load(object sender, EventArgs e)
        {
            Table tb = f.lsvBill.Tag as Table;
            string tenban = tb.Name;
            // TODO: This line of code loads data into the 'GetHoadonDataSet.GETHOADON' table. You can move, or remove it, as needed.
            this.GETHOADONTableAdapter.Fill(this.GetHoadonDataSet.GETHOADON,tenban);
           
            this.reportViewer1.RefreshReport();
        }
    }
}
