<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128601308/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1473)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
* [XtraReport1.cs](./CS/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/XtraReport1.vb))
<!-- default file list end -->
# How to implement an "immediate preview" feature in the End-User Designer


<p>This example illustrates how to implement a live preview in the <a href="http://documentation.devexpress.com/#XtraReports/CustomDocument2557">Custom End-User Designer Form </a>. There is a PrintControl in a separate DockPanel in this example. PrintControl is updated every time the IDesignerHost.TransactionClosed event is triggered. This allows you to immediately preview changes made in the End-User Designer. The Form1.UpdateView() method is responsible for displaying an updated report in the PrintControl.</p>

<br/>


