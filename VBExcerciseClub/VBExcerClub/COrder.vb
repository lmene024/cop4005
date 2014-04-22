Public Class COrder
    Private _mstrInvoiceID As String
    Private _mstrMbrID As String
    Private _mstrEmpID As String
    Private _msglInvTotal As Single
    Private _msglProdTotal As Single
    Private _msglTaxTotal As Single
    Private _mdtmInvoiceDate As DateTime
    Private _marrItems As ArrayList

    'constructor
    Public Sub New()
        SetInvoiceID()
        _mstrEmpID = ""
        _mstrMbrID = ""
        _mdtmInvoiceDate = New Date(Now.Year, Now.Month, Now.Day)
    End Sub

    Public Sub SetInvoiceID()
        Dim strLastInvoice As String = myDB.GetSingleValueFromSP("sp_GetLastInvoiceID")
        Dim strInvoiceID As String

        If String.IsNullOrEmpty(strLastInvoice) Then
            strInvoiceID = "I0001"
        Else
            strInvoiceID = "I" + ((CType((Right(strLastInvoice, 4)), Integer)) + 1)
            _mstrInvoiceID = strInvoiceID
        End If

    End Sub

    Public Property InvoiceID As String
        Get
            Return _mstrInvoiceID
        End Get
        Set(strInvoiceID As String)
            _mstrInvoiceID = strInvoiceID
        End Set
    End Property

    Public Property MbrID As String
        Get
            Return _mstrMbrID
        End Get
        Set(strMbrID As String)
            _mstrMbrID = strMbrID
        End Set
    End Property

    Public Property EmpID As String
        Get
            Return _mstrEmpID
        End Get
        Set(strEmpID As String)
            _mstrEmpID = strEmpID
        End Set
    End Property

    Public Property InvTotal As Single
        Get
            Return _msglInvTotal
        End Get
        Set(sglInvTotal As Single)
            _msglInvTotal = sglInvTotal
        End Set
    End Property

    Public Property ProdTotal As Single
        Get
            Return _msglProdTotal
        End Get
        Set(sglProdTotal As Single)
            _msglProdTotal = sglProdTotal
        End Set
    End Property

    Public Property TaxTotal As Single
        Get
            Return _msglTaxTotal
        End Get
        Set(sglTaxTotal As Single)
            _msglTaxTotal = sglTaxTotal
        End Set
    End Property
End Class
