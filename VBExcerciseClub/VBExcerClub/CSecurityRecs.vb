Imports System.Data.SqlClient
Public Class CSecurityRecs
    Private _Security As CSecurityRec

    Public Sub New()
        _Security = New CSecurityRec
    End Sub

    Public Function LoginUser(strUser As String, strPW As String) As Boolean
        Dim paramList As New ArrayList
        paramList.Add(New SqlParameter("UserID", strUser))
        paramList.Add(New SqlParameter("Password", strPW))
        _Security = FillObject(myDB.GetDataReaderBySP("sp_GetSecurityUser", paramList))
        If _Security.Password = strPW Then 'user supplied correct pw

            'determine security level
            If _Security.MemberArea Then 'member area access
                If _Security.EmployeeArea Then 'emp area access
                    If _Security.ShoppingArea Then 'shop area access
                        userSecurity = SECURITY_MES
                    Else 'shop no access
                        userSecurity = SECURITY_ME
                    End If
                Else 'emp no access
                    If _Security.ShoppingArea Then 'shop area access
                        userSecurity = SECURITY_MS
                    Else 'shop no access
                        userSecurity = SECURITY_M
                    End If
                End If
            Else 'member area no access
                If _Security.EmployeeArea Then 'emp area access
                    If _Security.ShoppingArea Then 'shop area access
                        userSecurity = SECURITY_ES
                    Else 'shop no access
                        userSecurity = SECURITY_E
                    End If
                Else 'emp no access
                    If _Security.ShoppingArea Then 'shop area access
                        userSecurity = SECURITY_S
                    Else 'shop no access
                        userSecurity = SECURITY_N
                    End If
                End If
            End If

            'set logged in employee
            employeeLogged = _Security.EmpId
            Return True
        End If
        Return False
    End Function

    Public Function FillObject(sqlDR As SqlDataReader) As CSecurityRec
        'why persist the object, just pass updateObject with the datareader
        'you could also isnull your select statement fields to get rid of all that appending
        Using sqlDR
            If sqlDR.Read() Then
                With _Security
                    .EmpId = sqlDR.Item("EmpID") & ""
                    .UserId = sqlDR.Item("UserID") & ""
                    .Password = sqlDR.Item("Password") & ""
                    .MemberArea = sqlDR.Item("MbrArea") & ""
                    .EmployeeArea = sqlDR.Item("EmpArea") & ""
                    .ShoppingArea = sqlDR.Item("ShopArea") & ""
                End With
            Else
                'failed
            End If
        End Using
        sqlDR.Close()
        Return _Security
    End Function
End Class
