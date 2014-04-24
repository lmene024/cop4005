Imports System.Data.SqlClient
Public Class COrders

    'This class represents the ProdInvoice table and the associated business rules for it
    Private _Order As COrder

    'constructor
    Public Sub New()
        'instantiate the COrder object
        _Order = New COrder
    End Sub

    Public ReadOnly Property CurrentObject() As COrder
        Get
            Return _Order
        End Get
    End Property

    Public Function IsValidInvoiceDate(dtmDate As Date) As Boolean
        'ensure that the date is today or earlier, and not a future date
        If dtmDate <= Today Then 'this is not a future date
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub Clear()
        _Order = New COrder() 'so much faster this way
    End Sub

    Public Sub CreateNewOrder() 'Call me when you're clearing the screen to add a new student!
        'This clears the old student and sets it as new
        Clear()
        _Order.NewInvoiceID()
        _Order.IsNewOrder = True
    End Sub

    Public Function Save() As Integer
        Return _Order.Save()
    End Function

    Public Function GetOrderList() As SqlDataReader
        Return myDB.GetDataReaderBySP("dbo.sp_GetOrderList")
    End Function

    Public Function GetInvoiceByID(strID As String) As COrder
        Dim aParam As New SqlParameter("ID", strID)
        FillObject(myDB.GetDataReaderBySP("dbo.sp_GetInvoiceByID", aParam))
        Return _Order
    End Function

    Public Function GetEmployeeByID(strID As String) As COrder
        Dim aParam As New SqlParameter("ID", strID)
        FillObject(myDB.GetDataReaderBySP("dbo.sp_GetEmployeeByID", aParam))
        Return _Order
    End Function

    Public Function GetMemberByID(strID As String) As COrder
        Dim aParam As New SqlParameter("ID", strID)
        FillObject(myDB.GetDataReaderBySP("dbo.sp_GetMemberByID", aParam))
        Return _Order
    End Function

    Public Function FillObject(sqlDR As SqlDataReader) As COrder
        'why persist the object, just pass updateObject with the datareader
        'you could also isnull your select statement fields to get rid of all that appending
        Using sqlDR
            If sqlDR.Read() Then
                With _Order
                    'Review This! What I chose was a guess for what is needed.
                    .InvoiceID = sqlDR.Item("InvID") & ""
                    .EmpID = sqlDR.Item("EmpID") & ""
                    .MbrID = sqlDR.Item("MbrID") & ""
                    .InvTotal = sqlDR.Item("InvTotal") & ""
                    .ProdTotal = sqlDR.Item("ProductTotal") & ""
                    .TaxTotal = sqlDR.Item("TaxTotal") & ""
                    .InvoiceDate = sqlDR.Item("InvDate") & ""
                End With
            Else
                'failed
            End If
        End Using
        Return _Order
    End Function
End Class
