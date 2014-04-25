Public Class CSecurityRec
    Private _mstrEmpId As String
    Private _mstrUserId As String
    Private _mstrPassword As String
    Private _mblnMbrArea As Boolean
    Private _mblnEmpArea As Boolean
    Private _mblnShpArea As Boolean


    'constructor
    Public Sub New()
        _mstrEmpId = ""
    End Sub

    Public Property EmpId As String
        Get
            Return _mstrEmpId
        End Get
        Set(value As String)
            _mstrEmpId = value
        End Set
    End Property

    Public Property UserId As String
        Get
            Return _mstrUserId
        End Get
        Set(value As String)
            _mstrUserId = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _mstrPassword
        End Get
        Set(value As String)
            _mstrPassword = value
        End Set
    End Property

    Public Property MemberArea As Boolean
        Get
            Return _mblnMbrArea
        End Get
        Set(value As Boolean)
            _mblnMbrArea = value
        End Set
    End Property

    Public Property EmployeeArea As Boolean
        Get
            Return _mblnEmpArea
        End Get
        Set(value As Boolean)
            _mblnEmpArea = value
        End Set
    End Property

    Public Property ShoppingArea As Boolean
        Get
            Return _mblnShpArea
        End Get
        Set(value As Boolean)
            _mblnShpArea = value
        End Set
    End Property

    'Not planing on saving this...

End Class
