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
    public partial class fReportDoanhthu : Form
    {
        fAdmin f;
        public fReportDoanhthu(fAdmin f)
        {
            InitializeComponent();
            this.f = f;
        }
       
        private void fReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'GetListBillByDateDataSet.GETLISTBILLBYDATEFORREPORT' table. You can move, or remove it, as needed.
            this.GETLISTBILLBYDATEFORREPORTTableAdapter.Fill(this.GetListBillByDateDataSet.GETLISTBILLBYDATEFORREPORT, f.dtpkFromDate.Value, f.dtpkToDate.Value);

            this.reportViewer1.RefreshReport();
        }
    }
}
