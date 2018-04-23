using System;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPivotGrid;

namespace ImplementCustomSummary {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }
        protected void ASPxPivotGrid1_CustomSummary(
                 object sender, 
                 PivotGridCustomSummaryEventArgs e) {
            if (e.DataField != fieldUnitPrice) return;

            // A variable which counts the number of orders
            // whose sum exceeds $50.
            int unit50Count = 0;

            // Gets the record set corresponding to the current cell.
            PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();

            // Iterates through the records and count the orders.
            for (int i = 0; i < ds.RowCount; i++) {
                PivotDrillDownDataRow row = ds[i];

                // Gets the order's total sum.
                decimal unitSum = (decimal)row[fieldUnitPrice];
                if (unitSum >= 50) unit50Count++;
            }

            // Calculates the percentage.
            if (ds.RowCount > 0) {
                e.CustomValue = (decimal)unit50Count / ds.RowCount;
            }
        }
    }
}
