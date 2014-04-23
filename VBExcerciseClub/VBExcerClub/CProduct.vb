Public Class CProduct
    Private _mstrProdID As String
    Private _mstrProdDesc As String
    Private _msglWhCost As String
    Private _msglRetPrice As String
    Private _isTaxable As Boolean
    Private _isNewProduct As Boolean
    Private _hasChanges As Boolean
    'constructor
    Public Sub New()
        'SetProductID()
        _mstrProdID = ""
    End Sub

    'Public Sub SetProductID()
    '    Dim strLastInvoice As String = myDB.GetSingleValueFromSP("sp_GetLastProductID")
    '    Dim strInvoiceID As String

    '    If String.IsNullOrEmpty(strLastInvoice) Then
    '        strInvoiceID = "I0001"
    '    Else
    '        strInvoiceID = "I" + ((CType((Right(strLastInvoice, 4)), Integer)) + 1)
    '        _mstrProdID = strInvoiceID
    '    End If

    'End Sub

    Public Property ProductID As String
        Get
            Return _mstrProdID
        End Get
        Set(strProdID As String)
            _mstrProdID = strProdID
        End Set
    End Property

    Public Property ProductDescription As String
        Get
            Return _mstrProdDesc
        End Get
        Set(strProdDesc As String)
            _mstrProdDesc = strProdDesc
        End Set
    End Property

    Public Property WhCost As String
        Get
            Return _msglWhCost
        End Get
        Set(strWhCost As String)
            _msglWhCost = strWhCost
        End Set
    End Property

    Public Property RetailPrice As Single
        Get
            Return _msglRetPrice
        End Get
        Set(strRetailPrice As Single)
            _msglRetPrice = strRetailPrice
        End Set
    End Property

    Private Property isTaxable As Boolean
        Get
            Return _isTaxable
        End Get
        Set(isTaxable As Boolean)
            _isTaxable = isTaxable
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

    Public Property IsNewProduct() As Boolean
        Get
            Return _isNewProduct
        End Get
        Set(isNewProduct As Boolean)
            _isNewProduct = isNewProduct
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim paramList As New ArrayList()
            paramList.Add(New SqlClient.SqlParameter("prodid", _mstrProdID))
            paramList.Add(New SqlClient.SqlParameter("proddesc", _mstrProdDesc))
            paramList.Add(New SqlClient.SqlParameter("whcost", _msglWhCost))
            paramList.Add(New SqlClient.SqlParameter("retprice", _msglRetPrice))
            paramList.Add(New SqlClient.SqlParameter("istaxable", _isTaxable))

            Return paramList
        End Get
    End Property

    Public Function Save() As Integer
        'return -1 if the ID already exists (and we can't create a new record then
        If IsNewProduct Then
            Dim strRes As String = myDB.GetSingleValueFromSP("sp_CheckProductIDExists", New SqlClient.SqlParameter("PRODID", _mstrProdID))
            If Not strRes = 0 Then
                Return -1 'Not UNIQUE!
            End If
        End If
        'if not a new member or is new and is unique ID then do the save (update or insert)
        Return myDB.ExecSP("sp_SaveOrder", GetSaveParameters())
    End Function
End Class
