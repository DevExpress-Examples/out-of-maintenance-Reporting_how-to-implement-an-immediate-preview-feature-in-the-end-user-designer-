# How to implement an "immediate preview" feature in the End-User Designer


<p>This example illustrates how to implement a live preview in the <a href="http://documentation.devexpress.com/#XtraReports/CustomDocument2557">Custom End-User Designer Form </a>. There is a PrintControl in a separate DockPanel in this example. PrintControl is updated every time the IDesignerHost.TransactionClosed event is triggered. This allows you to immediately preview changes made in the End-User Designer. The Form1.UpdateView() method is responsible for displaying an updated report in the PrintControl.</p>

<br/>


