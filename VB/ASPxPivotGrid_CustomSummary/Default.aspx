<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb"
	Inherits="ASPxPivotGrid_CustomSummary._Default" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v10.2, Version=10.2.5.0,
	Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxPivotGrid"
	TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
	"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" DataSourceID="AccessDataSource1"
		OnCustomSummary="ASPxPivotGrid1_CustomSummary">
			<Fields>
				<dx:PivotGridField ID="fieldProductName" Area="RowArea" AreaIndex="0"
				Caption="Product Name" FieldName="ProductName">
				</dx:PivotGridField>
				<dx:PivotGridField ID="fieldExtendedPrice" Area="DataArea" AreaIndex="0" 
				Caption="Percentage of Orders over $500" SummaryType="Custom" 
				CellFormat-FormatString="p" CellFormat-FormatType="Numeric"
				FieldName="Extended_Price">
				</dx:PivotGridField>
			</Fields>
		</dx:ASPxPivotGrid>
		<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/nwind.mdb"
		SelectCommand="SELECT [Extended Price] AS Extended_Price, [ProductName] FROM [OrderReports]">
		</asp:AccessDataSource>
	</div>
	</form>
</body>
</html>