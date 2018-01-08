namespace QuanLyCafe
{
    partial class fReportDoanhthu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.GETLISTBILLBYDATEFORREPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GetListBillByDateDataSet = new QuanLyCafe.GetListBillByDateDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GETLISTBILLBYDATEFORREPORTTableAdapter = new QuanLyCafe.GetListBillByDateDataSetTableAdapters.GETLISTBILLBYDATEFORREPORTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.GETLISTBILLBYDATEFORREPORTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetListBillByDateDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // GETLISTBILLBYDATEFORREPORTBindingSource
            // 
            this.GETLISTBILLBYDATEFORREPORTBindingSource.DataMember = "GETLISTBILLBYDATEFORREPORT";
            this.GETLISTBILLBYDATEFORREPORTBindingSource.DataSource = this.GetListBillByDateDataSet;
            // 
            // GetListBillByDateDataSet
            // 
            this.GetListBillByDateDataSet.DataSetName = "GetListBillByDateDataSet";
            this.GetListBillByDateDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.GETLISTBILLBYDATEFORREPORTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyCafe.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(689, 427);
            this.reportViewer1.TabIndex = 0;
            // 
            // GETLISTBILLBYDATEFORREPORTTableAdapter
            // 
            this.GETLISTBILLBYDATEFORREPORTTableAdapter.ClearBeforeFill = true;
            // 
            // fReportDoanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 427);
            this.Controls.Add(this.reportViewer1);
            this.Name = "fReportDoanhthu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Doanh Thu";
            this.Load += new System.EventHandler(this.fReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GETLISTBILLBYDATEFORREPORTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetListBillByDateDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GETLISTBILLBYDATEFORREPORTBindingSource;
        private GetListBillByDateDataSet GetListBillByDateDataSet;
        private GetListBillByDateDataSetTableAdapters.GETLISTBILLBYDATEFORREPORTTableAdapter GETLISTBILLBYDATEFORREPORTTableAdapter;
    }
}