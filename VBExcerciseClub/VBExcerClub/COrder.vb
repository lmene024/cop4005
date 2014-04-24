Public Class COrder
    Private _mstrInvoiceID As String
    Private _mstrMbrID As String
    Private _mstrEmpID As String
    Private _msglInvTotal As Single
    Private _msglProdTotal As Single
    Private _msglTaxTotal As Single
    Private _mdtmInvoiceDate As DateTime
    Private _marrItems As ArrayList
    Private _isNewOrder As Boolean
    Private _hasChanges As Boolean

    'constructor
    Public Sub New()
        _mstrInvoiceID = ""
        _mdtmInvoiceDate = New Date(Now.Year, Now.Month, Now.Day)
    End Sub

    Public Sub NewInvoiceID()
        Dim strLastInvoice As String = myDB.GetSingleValueFromSP("sp_GetLastInvoiceID")
        Dim strInvoiceID As String

        If String.IsNullOrEmpty(strLastInvoice) Or strLastInvoice = "-1" Then
            strInvoiceID = "I0001"
        Else
            strInvoiceID = "I" + ((CType((Right(strLastInvoice, 4)), Integer)) + 1)
        End If
        _mstrInvoiceID = strInvoiceID

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

    Public Property InvoiceDate As DateTime
        Get
            Return _mdtmInvoiceDate
        End Get
        Set(mdtmInvoiceDate As DateTime)
            _mdtmInvoiceDate = mdtmInvoiceDate
        End Set
    End Property

    Public Property MerrItems As ArrayList
        Get
            Return _marrItems
        End Get
        Set(marrItems As ArrayList)
            _marrItems = marrItems
        End Set
    End Property

    Public Property hasChanges() As Boolean
        Get
            Return _hasChanges
        End Get
        Set(hasChanges As Boolean)
            _hasChanges = hasChanges
        End Set
    End Property

    Public Property IsNewOrder() As Boolean
        Get
            Return _isNewOrder
        End Get
        Set(isNewOrder As Boolean)
            _isNewOrder = isNewOrder
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim paramList As New ArrayList()
            paramList.Add(New SqlClient.SqlParameter("invid", _mstrInvoiceID))
            paramList.Add(New SqlClient.SqlParameter("mbrid", _mstrMbrID))
            paramList.Add(New SqlClient.SqlParameter("empid", _mstrEmpID))
            paramList.Add(New SqlClient.SqlParameter("invtotal", _msglInvTotal))
            paramList.Add(New SqlClient.SqlParameter("prodtotal", _msglProdTotal))
            paramList.Add(New SqlClient.SqlParameter("taxtotal", _msglTaxTotal))
            paramList.Add(New SqlClient.SqlParameter("invdate", _mdtmInvoiceDate))
            Return paramList
        End Get
    End Property

    Public Function Save() As Integer
        'return -1 if the ID already exists (and we can't create a new record then
        If IsNewOrder Then
            Dim strRes As String = myDB.GetSingleValueFromSP("sp_CheckInvoiceIDExists", New SqlClient.SqlParameter("INVID", _mstrInvoiceID))
            If Not strRes = 0 Then
                Return -1 'Not UNIQUE!
            End If
        End If
        'if not a new member or is new and is unique ID then do the save (update or insert)
        Return myDB.ExecSP("sp_SaveOrder", GetSaveParameters())
    End Function
End Class
