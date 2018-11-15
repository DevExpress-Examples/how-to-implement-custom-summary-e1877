<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/ASPxPivotGrid_ImplementCustomSummary/Default.aspx) (VB: [Default.aspx](./VB/ASPxPivotGrid_ImplementCustomSummary/Default.aspx))
* [Default.aspx.cs](./CS/ASPxPivotGrid_ImplementCustomSummary/Default.aspx.cs) (VB: [Default.aspx](./VB/ASPxPivotGrid_ImplementCustomSummary/Default.aspx))
<!-- default file list end -->
# How to Implement Custom Summary


<p>The following example shows how to calculate a custom summary.</p><p>Assume that the ASPxPivotGrid control is bound to an "Invoices" table, which contains invoices information (product name, extended price, salesperson, etc). A field that displays the ratio of units cost over $50 is to be added.</p><p>In this example, a custom summary is calculated against the "Unit Price" field. Its PivotGridCustomTotalBase.SummaryType property is set to PivotSummaryType.Custom and the caption to "Percentage of units cost over $50". The PivotGridControl.CustomSummary event is handled to only count those records whose total sum exceeds $50. The ratio of these records to all the records is a custom summary value and, therefore, is assigned to the PivotGridCustomSummaryEventArgsBase.CustomValue parameter.</p>

<br/>


