Module modGlobal
    Public gstrConn As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\VBExerClubDB.mdf';Integrated Security=True;Connect Timeout=30"
    Public myDB As New CDB
    Public ReadOnly NULL_DATE As Date = New Date(1900, 1, 1)
    'contains constants that need to be accessed in more than one form
    Public Const ACTION_NONE = 0
    Public Const ACTION_HOME = 1
    Public Const ACTION_MEMBER = 2
    Public Const ACTION_PROGRAM = 3
    Public Const ACTION_SHOP = 4
    Public Const ACTION_CONTACT = 5
    Public Const ACTION_HELP = 6

    Public Const SECURITY_N = 0
    Public Const SECURITY_M = 100
    Public Const SECURITY_ME = 110
    Public Const SECURITY_MES = 111
    Public Const SECURITY_MS = 101
    Public Const SECURITY_E = 10
    Public Const SECURITY_ES = 11
    Public Const SECURITY_S = 1

    Public sTax As Single = 0.07
    Public intNextAction As Integer
    Public userSecurity As Integer
    Public employeeLogged As String
End Module

