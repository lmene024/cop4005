Public Class COrdItem
    Private _mstrInvId As String
    Private _mstrProdId As String
    Private _mintQty As Integer
    Private _msngPrice As Single

    'constructor
    Public Sub New()
        _mstrInvId = ""
    End Sub

    Public Property InvId As String
        Get
            Return _mstrInvId
        End Get
        Set(value As String)
            _mstrInvId = value
        End Set
    End Property

    Public Property ProdId As String
        Get
            Return _mstrProdId
        End Get
        Set(value As String)
            _mstrProdId = value
        End Set
    End Property

    Public Property Qty As Integer
        Get
            Return _mintQty
        End Get
        Set(value As Integer)
            _mintQty = value
        End Set
    End Property

    Public Property Price As Single
        Get
            Return _msngPrice
        End Get
        Set(value As Single)
            _msngPrice = value
        End Set
    End Property

    Public ReadOnly Property GetAddParameters() As ArrayList
        Get
            Dim paramList As New ArrayList()
            paramList.Add(New SqlClient.SqlParameter("invoiceID", _mstrInvId))
            paramList.Add(New SqlClient.SqlParameter("productID", _mstrProdId))
            paramList.Add(New SqlClient.SqlParameter("qty", _mintQty))
            paramList.Add(New SqlClient.SqlParameter("price", _msngPrice))
            Return paramList
        End Get
    End Property

    Public Function AddLineItem() As Integer
        'if not a new member or is new and is unique ID then do the save (update or insert)
        Return myDB.ExecSP("sp_AddProductToInvoice", GetAddParameters())
    End Function
End Class
