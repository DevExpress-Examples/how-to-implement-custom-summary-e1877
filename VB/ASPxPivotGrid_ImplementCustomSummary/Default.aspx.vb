Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Web.ASPxPivotGrid
Imports DevExpress.XtraPivotGrid

Namespace ImplementCustomSummary
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, _
                                         ByVal e As EventArgs)
		End Sub
		Protected Sub ASPxPivotGrid1_CustomSummary( _
                                        ByVal sender As Object, _
                                        ByVal e As PivotGridCustomSummaryEventArgs)
			If e.DataField IsNot fieldUnitPrice Then
				Return
			End If

			' A variable which counts the number of orders
                                                ' whose sum exceeds $50.
			Dim unit50Count As Integer = 0

			' Gets the record set corresponding to the current cell.
			Dim ds As PivotDrillDownDataSource = _
                                                         e.CreateDrillDownDataSource()

			' Iterates through the records and count the orders.
			For i As Integer = 0 To ds.RowCount - 1
				Dim row As PivotDrillDownDataRow = ds(i)

				' Gets the order's total sum.
				Dim unitSum As Decimal = _
                                                                         CDec(row(fieldUnitPrice))
				If unitSum >= 50 Then
					unit50Count += 1
				End If
			Next i

			' Calculates the percentage.
			If ds.RowCount > 0 Then
				e.CustomValue = _
                                                                        CDec(unit50Count) / ds.RowCount
			End If
		End Sub
	End Class
End Namespace
