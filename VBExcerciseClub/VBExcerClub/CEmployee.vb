Public Class CEmployee
    'represents a single record in the Employee table
    'declare the private instance variables
    Private _mstrEmpID As String
    Private _mstrLName As String
    Private _mstrFName As String
    Private _mstrAddress As String
    Private _mstrCity As String
    Private _mstrState As String
    Private _mstrZip As String
    Private _mstrPhone As String
    Private _mdtmDateHired As DateTime
    Private _msglCommission As Single
    Private _mstrRoleID As String
    Private _isNewEmployee As Boolean
    Private _hasChanges As Boolean
    'constructor
    Public Sub New()
        'initialize class instance variables
        _mstrEmpID = ""
        'do the rest here
        'date values are initialized to 1/1/0001 by default, so we set it to today instead
        _mdtmDateHired = New Date(Now.Year, Now.Month, Now.Day)
    End Sub
    'now do the properties (getters & setters)
    Public Property EmpID() As String
        Get
            Return _mstrEmpID
        End Get
        Set(strEmpID As String)
            _mstrEmpID = strEmpID
        End Set
    End Property
    Public Property LName() As String
        Get
            Return _mstrLName
        End Get
        Set(strLName As String)
            _mstrLName = strLName
        End Set
    End Property
    Public Property FName() As String
        Get
            Return _mstrFName
        End Get
        Set(strFName As String)
            _mstrFName = strFName
        End Set
    End Property
    Public Property Address() As String
        Get
            Return _mstrAddress
        End Get
        Set(strAddress As String)
            _mstrAddress = strAddress
        End Set
    End Property
    Public Property City() As String
        Get
            Return _mstrCity
        End Get
        Set(strCity As String)
            _mstrCity = strCity
        End Set
    End Property
    Public Property State() As String
        Get
            Return _mstrState
        End Get
        Set(strState As String)
            _mstrState = strState
        End Set
    End Property
    Public Property Zip() As String
        Get
            Return _mstrZip
        End Get
        Set(strZip As String)
            _mstrZip = strZip
        End Set
    End Property
    Public Property Phone() As String
        Get
            Return _mstrPhone
        End Get
        Set(strPhone As String)
            _mstrPhone = strPhone
        End Set
    End Property
    Public Property DateHired() As DateTime
        Get
            Return _mdtmDateHired
        End Get
        Set(_mdtmateHired As DateTime)
            _mdtmDateHired = _mdtmateHired
        End Set
    End Property
    Public Property RoleID As String
        Get
            Return _mstrRoleID
        End Get
        Set(strRoleID As String)
            _mstrRoleID = strRoleID
        End Set
    End Property
    Public Property hasChanges() As Boolean
        Get
            Return _hasChanges
        End Get
        Set(value As Boolean)
            _hasChanges = value
        End Set
    End Property
    Public Property Commission() As Single
        Get
            Return _msglCommission
        End Get
        Set(sglCommission As Single)
            _msglCommission = sglCommission
        End Set
    End Property
    Public Property IsNewEmployee() As Boolean
        Get
            Return _isNewEmployee
        End Get
        Set(value As Boolean)
            _isNewEmployee = value
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim paramList As New ArrayList()
            paramList.Add(New SqlClient.SqlParameter("empid", _mstrEmpID))
            paramList.Add(New SqlClient.SqlParameter("lname", _mstrLName))
            paramList.Add(New SqlClient.SqlParameter("fname", _mstrFName))
            paramList.Add(New SqlClient.SqlParameter("address", _mstrAddress))
            paramList.Add(New SqlClient.SqlParameter("city", _mstrCity))
            paramList.Add(New SqlClient.SqlParameter("state", _mstrState))
            paramList.Add(New SqlClient.SqlParameter("zip", _mstrZip))
            paramList.Add(New SqlClient.SqlParameter("phone", _mstrPhone))
            paramList.Add(New SqlClient.SqlParameter("datehired", _mdtmDateHired))
            paramList.Add(New SqlClient.SqlParameter("commissionrate", _msglCommission))
            paramList.Add(New SqlClient.SqlParameter("roleid", _mstrRoleID))
            Return paramList
        End Get
    End Property

    Public Function Save() As Integer
        'return -1 if the ID already exists (and we can't create a new record then
        If IsNewEmployee Then
            Dim strRes As String = myDB.GetSingleValueFromSP("sp_CheckEmployeeIDExists", New SqlClient.SqlParameter("EmployeeID", _mstrEmpID))
            If Not strRes = 0 Then
                Return -1 'Not UNIQUE!
            End If
        End If
        'if not a new member or is new and is unique ID then do the save (update or insert)
        Return myDB.ExecSP("sp_SaveEmployee", GetSaveParameters())
    End Function
End Class
