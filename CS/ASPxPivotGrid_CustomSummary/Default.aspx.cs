using System.Web.UI;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPivotGrid;

namespace ASPxPivotGrid_CustomSummary {
    public partial class _Default : Page {
        static int minSum = 500;
        protected void ASPxPivotGrid1_CustomSummary(object sender, 
                                                    PivotGridCustomSummaryEventArgs e) {
            if (e.DataField != fieldExtendedPrice) return;

            // A variable which counts the number of orders whose sum exceeds $500.
            int order500Count = 0;

            // Get the record set corresponding to the current cell.
            PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();

            // Iterate through the records and count the orders.
            for (int i = 0; i < ds.RowCount; i++) {
                PivotDrillDownDataRow row = ds[i];

                // Get the order's total sum.
                decimal orderSum = (decimal)row[fieldExtendedPrice];
                if (orderSum >= minSum) order500Count++;
            }

            // Calculate the percentage.
            if (ds.RowCount > 0) {
                e.CustomValue = (decimal)order500Count / ds.RowCount;
            }
        }
    }
}
