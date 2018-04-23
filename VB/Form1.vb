Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports DevExpress.XtraReports.UserDesigner.Native
Imports DevExpress.XtraReports.UI
Imports System.IO

Namespace RepLivePreview
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim report As New XtraReport1()

			report.DataSource = ManualDataSet.CreateData()

			xrDesignPanel1.OpenReport(report)
			xrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.ShowPreviewTab, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)

			Dim dh As IDesignerHost = TryCast(xrDesignPanel1.GetService(GetType(IDesignerHost)), IDesignerHost)
			AddHandler dh.TransactionClosed, AddressOf dh_TransactionClosed

			UpdateView()
		End Sub

		Private Sub dh_TransactionClosed(ByVal sender As Object, ByVal e As DesignerTransactionCloseEventArgs)
			UpdateView()
		End Sub

		Private Sub UpdateView()
			Dim report As XtraReport = xrDesignPanel1.Report
			Dim report2 As New XtraReport()
			Dim ms As New MemoryStream()

			report.SaveLayout(ms)
			ms.Seek(0, SeekOrigin.Begin)
			report2.LoadLayout(ms)
			report2.DataSource = report.DataSource
			report2.CreateDocument()

			printControl1.PrintingSystem = report2.PrintingSystem
			printControl1.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToWholePage)
		End Sub

	End Class

	Public Class ManualDataSet
		Inherits DataSet
		Public Sub New()
			MyBase.New()
			Dim table As New DataTable("table")

			DataSetName = "ManualDataSet"

			table.Columns.Add("ID", GetType(Int32))
			table.Columns.Add("MyDateTime", GetType(DateTime))
			table.Columns.Add("MyRow", GetType(String))
			table.Columns.Add("MyData", GetType(Double))
			table.Constraints.Add("IDPK", table.Columns("ID"), True)

			Tables.AddRange(New DataTable() { table })
		End Sub

		Public Shared Function CreateData() As ManualDataSet
			Dim ds As New ManualDataSet()
			Dim table As DataTable = ds.Tables("table")

			table.Rows.Add(New Object() { 0, DateTime.Today, "A", 103 })
			table.Rows.Add(New Object() { 1, DateTime.Today, "B", 200 })
			table.Rows.Add(New Object() { 2, DateTime.Today, "C", 446 })
			table.Rows.Add(New Object() { 3, DateTime.Today.AddDays(1), "A", 788 })
			table.Rows.Add(New Object() { 4, DateTime.Today.AddDays(1), "B", 787 })
			table.Rows.Add(New Object() { 5, DateTime.Today.AddDays(1), "C", 452 })
			table.Rows.Add(New Object() { 6, DateTime.Today.AddDays(2), "A", 152 })
			table.Rows.Add(New Object() { 7, DateTime.Today.AddDays(2), "B", 565 })
			table.Rows.Add(New Object() { 8, DateTime.Today.AddDays(2), "C", 612 })

			Return ds
		End Function

		#Region "Disable Serialization for Tables and Relations"
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property Tables() As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property Relations() As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property
		#End Region ' Disable Serialization for Tables and Relations
	End Class

End Namespace