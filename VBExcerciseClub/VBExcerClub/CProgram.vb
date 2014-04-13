Public Class CProgram
    'represents a single record in the Program table
    Private _mstrProgID As String
    Private _mstrProgDesc As String
    Private _msngMonthFee As Single
    Private _msngAnnualDiscount As Single
    Private _isNewProgram As Boolean

    Public Property ProgID() As String
        Get
            Return _mstrProgID
        End Get
        Set(strProgID As String)
            _mstrProgID = strProgID
        End Set
    End Property

    Public Property ProgDesc() As String
        Get
            Return _mstrProgDesc
        End Get
        Set(strProgDesc As String)
            _mstrProgDesc = strProgDesc
        End Set
    End Property

    Public Property MonthFee() As Single
        Get
            Return _msngMonthFee
        End Get
        Set(sngMonthFee As Single)
            _msngMonthFee = sngMonthFee
        End Set
    End Property

    Public Property AnnualDiscount() As Single
        Get
            Return _msngAnnualDiscount
        End Get
        Set(sngAnnualDiscount As Single)
            _msngAnnualDiscount = sngAnnualDiscount
        End Set
    End Property

    Public Property IsNewProgram() As Boolean
        Get
            Return _isNewProgram
        End Get
        Set(value As Boolean)
            _isNewProgram = value
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim paramList As New ArrayList()
            paramList.Add(New SqlClient.SqlParameter("progrid", _mstrprogID))
            paramList.Add(New SqlClient.SqlParameter("progrdesc", _mstrProgDesc))
            paramList.Add(New SqlClient.SqlParameter("monthfee", _msngMonthFee))
            paramList.Add(New SqlClient.SqlParameter("anndisc", _msngAnnualDiscount))
            Return paramList
        End Get
    End Property

    Public Function Save() As Integer
        'return -1 if the ID already exists (and we can't create a new record then
        If IsNewProgram Then
            Dim strRes As String = myDB.GetSingleValueFromSP("sp_CheckProgramIDExists", New SqlClient.SqlParameter("PROGID", _mstrProgID))
            If Not strRes = 0 Then
                Return -1 'Not UNIQUE!
            End If
        End If
        'if not a new member or is new and is unique ID then do the save (update or insert)
        Return myDB.ExecSP("sp_SaveProgram", GetSaveParameters())
    End Function
End Class
