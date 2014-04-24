Imports System.Data.SqlClient

Public Class frmInvoice
    Private strInvoiceID As String
    Private Order As COrder
    Private Orders As COrders = New COrders

    Private Sub New(strInvID As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        strInvoiceID = strInvID
    End Sub

    Private Sub frmInvoice_Load(sender As Object, e As EventArgs) Handles Me.Load
        Order = Orders.GetInvoiceByID(strInvoiceID)
        lblMember.Text = Order.MbrID
        lblEmpID.Text = Order.EmpID
        lblTotalCost.Text = Order.ProdTotal
        lblTax.Text = Order.TaxTotal
        lblOrderTotal.Text = Order.InvTotal

        dgvItems.DataSource = GetTable()
    End Sub

    Private Function GetTable() As DataTable
        Dim invItems As DataTable = New DataTable
        Dim aParam As New SqlParameter("ID", strInvoiceID)
        Dim dr As SqlDataReader = myDB.GetDataReaderBySP("dbo.sp_GetInvoiceItemListByInvoiceID", aParam)

        'create columns for the DataGridView
        invItems.Columns.Add("Product ID", GetType(String))
        invItems.Columns.Add("Quantity", GetType(Integer))
        invItems.Columns.Add("Price", GetType(Single))

        'while the SqlDataReader has records add the values to their repective columns
        While dr.Read
            invItems.Rows.Add(dr.Item("PRODID"), dr.Item("QTY"), dr.Item("PRICE"))
        End While

        dr.Close()
        Return invItems
    End Function
End Class
