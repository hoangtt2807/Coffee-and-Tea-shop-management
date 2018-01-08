namespace QuanLyCafe
{
    partial class fHoadon
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
            this.GETHOADONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GetHoadonDataSet = new QuanLyCafe.GetHoadonDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GETHOADONTableAdapter = new QuanLyCafe.GetHoadonDataSetTableAdapters.GETHOADONTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.GETHOADONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetHoadonDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // GETHOADONBindingSource
            // 
            this.GETHOADONBindingSource.DataMember = "GETHOADON";
            this.GETHOADONBindingSource.DataSource = this.GetHoadonDataSet;
            // 
            // GetHoadonDataSet
            // 
            this.GetHoadonDataSet.DataSetName = "GetHoadonDataSet";
            this.GetHoadonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.GETHOADONBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyCafe.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(645, 372);
            this.reportViewer1.TabIndex = 0;
            // 
            // GETHOADONTableAdapter
            // 
            this.GETHOADONTableAdapter.ClearBeforeFill = true;
            // 
            // fHoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 372);
            this.Controls.Add(this.reportViewer1);
            this.Name = "fHoadon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa đơn";
            this.Load += new System.EventHandler(this.fHoadon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GETHOADONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetHoadonDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GETHOADONBindingSource;
        private GetHoadonDataSet GetHoadonDataSet;
        private GetHoadonDataSetTableAdapters.GETHOADONTableAdapter GETHOADONTableAdapter;
    }
}