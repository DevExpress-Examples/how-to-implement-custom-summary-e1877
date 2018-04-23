Imports Microsoft.VisualBasic
Imports System.Web.UI
Imports DevExpress.Web.ASPxPivotGrid
Imports DevExpress.XtraPivotGrid

Namespace ASPxPivotGrid_CustomSummary
	Partial Public Class _Default
		Inherits Page
		Private Shared minSum As Integer = 500
		Protected Sub ASPxPivotGrid1_CustomSummary(ByVal sender As Object, _
				ByVal e As PivotGridCustomSummaryEventArgs)
			If e.DataField IsNot fieldExtendedPrice Then
				Return
			End If

			' A variable which counts the number of orders whose sum exceeds $500.
			Dim order500Count As Integer = 0

			' Get the record set corresponding to the current cell.
			Dim ds As PivotDrillDownDataSource = e.CreateDrillDownDataSource()

			' Iterate through the records and count the orders.
			For i As Integer = 0 To ds.RowCount - 1
				Dim row As PivotDrillDownDataRow = ds(i)

				' Get the order's total sum.
				Dim orderSum As Decimal = CDec(row(fieldExtendedPrice))
				If orderSum >= minSum Then
					order500Count += 1
				End If
			Next i

			' Calculate the percentage.
			If ds.RowCount > 0 Then
				e.CustomValue = CDec(order500Count) / ds.RowCount
			End If
		End Sub
	End Class
End Namespace
