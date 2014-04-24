Imports System.Data.SqlClient
Public Class CProducts
    'This class represents the ProdInvoice table and the associated business rules for it
    Private _Product As CProduct

    'constructor
    Public Sub New()
        'instantiate the COrder object
        _Product = New CProduct
    End Sub

    'Public ReadOnly Property CurrentObject() As CProduct
    '    Get
    '        Return _Product
    'End Property

    'Public Function IsValidInvoiceDate(dtmDate As Date) As Boolean
    '    'ensure that the date is today or earlier, and not a future date
    '    If dtmDate <= Today Then 'this is not a future date
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    Public Sub Clear()
        _Product = New CProduct() 'so much faster this way
    End Sub

    Public Sub CreateNewProduct() 'Call me when you're clearing the screen to add a new student!
        'This clears the old student and sets it as new
        Clear()
        _Product.IsNewProduct = True
    End Sub

    Public Function Save() As Integer
        Return _Product.Save()
    End Function

    Public Function GetProductList() As SqlDataReader
        Return myDB.GetDataReaderBySP("sp_GetProductList")
    End Function

    Public Function SearchProductList(ByVal strSearch As String) As SqlDataReader
        Dim sParam As New SqlParameter("search", strSearch)
        Return myDB.GetDataReaderBySP("sp_GetProductListWithSearch", sParam)
    End Function

    Public Function GetProductByID(strID As String) As CProduct
        Dim aParam As New SqlParameter("ID", strID)
        FillObject(myDB.GetDataReaderBySP("sp_GetProductByID", aParam))
        Return _Product
    End Function

    Public Function GetProductByDesc(strDesc As String) As CProduct
        Dim aParam As New SqlParameter("Description", strDesc)
        FillObject(myDB.GetDataReaderBySP("sp_GetProductByDesc", aParam))
        Return _Product
    End Function

    Public Function FillObject(sqlDR As SqlDataReader) As CProduct
        'why persist the object, just pass updateObject with the datareader
        'you could also isnull your select statement fields to get rid of all that appending
        Using sqlDR
            If sqlDR.Read() Then
                With _Product
                    .ProductID = sqlDR.Item("ProdID") & ""
                    .ProductDescription = sqlDR.Item("ProdDesc") & ""
                    .WhCost = sqlDR.Item("WhCost") & ""
                    .RetailPrice = sqlDR.Item("RetPrice") & ""
                    .isTaxable = sqlDR.Item("taxable")

                End With
            Else
                'failed
            End If
        End Using
        sqlDR.Close()
        Return _Product
    End Function
End Class
