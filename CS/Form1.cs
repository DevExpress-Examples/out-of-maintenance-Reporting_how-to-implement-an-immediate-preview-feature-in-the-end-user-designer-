using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using DevExpress.XtraReports.UserDesigner.Native;
using DevExpress.XtraReports.UI;
using System.IO;

namespace RepLivePreview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XtraReport1 report = new XtraReport1();

            report.DataSource = ManualDataSet.CreateData();

            xrDesignPanel1.OpenReport(report);
            xrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.ShowPreviewTab, DevExpress.XtraReports.UserDesigner.CommandVisibility.None);

            IDesignerHost dh = xrDesignPanel1.GetService(typeof(IDesignerHost)) as IDesignerHost;
            dh.TransactionClosed += new DesignerTransactionCloseEventHandler(dh_TransactionClosed);

            UpdateView();
        }

        void dh_TransactionClosed(object sender, DesignerTransactionCloseEventArgs e) {
            UpdateView();
        }

        void UpdateView() {
            XtraReport report = xrDesignPanel1.Report;
            XtraReport report2 = new XtraReport();
            MemoryStream ms = new MemoryStream();
            
            report.SaveLayout(ms);
            ms.Seek(0, SeekOrigin.Begin);
            report2.LoadLayout(ms);
            report2.DataSource = report.DataSource;
            report2.CreateDocument();

            printControl1.PrintingSystem = report2.PrintingSystem;
            printControl1.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToWholePage);
        }

    }

    public class ManualDataSet : DataSet {
        public ManualDataSet()
            : base() {
            DataTable table = new DataTable("table");

            DataSetName = "ManualDataSet";

            table.Columns.Add("ID", typeof(Int32));
            table.Columns.Add("MyDateTime", typeof(DateTime));
            table.Columns.Add("MyRow", typeof(string));
            table.Columns.Add("MyData", typeof(double));
            table.Constraints.Add("IDPK", table.Columns["ID"], true);

            Tables.AddRange(new DataTable[] { table });
        }

        public static ManualDataSet CreateData() {
            ManualDataSet ds = new ManualDataSet();
            DataTable table = ds.Tables["table"];

            table.Rows.Add(new object[] { 0, DateTime.Today, "A", 103 });
            table.Rows.Add(new object[] { 1, DateTime.Today, "B", 200 });
            table.Rows.Add(new object[] { 2, DateTime.Today, "C", 446 });
            table.Rows.Add(new object[] { 3, DateTime.Today.AddDays(1), "A", 788 });
            table.Rows.Add(new object[] { 4, DateTime.Today.AddDays(1), "B", 787 });
            table.Rows.Add(new object[] { 5, DateTime.Today.AddDays(1), "C", 452 });
            table.Rows.Add(new object[] { 6, DateTime.Today.AddDays(2), "A", 152 });
            table.Rows.Add(new object[] { 7, DateTime.Today.AddDays(2), "B", 565 });
            table.Rows.Add(new object[] { 8, DateTime.Today.AddDays(2), "C", 612 });

            return ds;
        }

        #region Disable Serialization for Tables and Relations
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables {
            get { return base.Tables; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations {
            get { return base.Relations; }
        }
        #endregion Disable Serialization for Tables and Relations
    }

}