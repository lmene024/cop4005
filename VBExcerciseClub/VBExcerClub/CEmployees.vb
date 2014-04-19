Imports System.Data.SqlClient
Public Class CEmployees
    'This class represents the Employeed table and the associated business rules for it
    Private _Employee As CEmployee

    'constructor
    Public Sub New()
        'instantiate the CMember object
        _Employee = New CEmployee
    End Sub

    Public ReadOnly Property CurrentObject() As CEmployee
        Get
            Return _Employee
        End Get
    End Property

    Public Function IsValidHiredDate(dtmDate As Date) As Boolean
        'ensure that the date is today or earlier, and not a future date
        If dtmDate <= Today Then 'this is not a future date
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub Clear()
        _Employee = New CEmployee() 'so much faster this way
    End Sub

    Public Sub CreateNewMember() 'Call me when you're clearing the screen to add a new student!
        'This clears the old student and sets it as new
        Clear()
        _Employee.IsNewEmployee = True
    End Sub

    Public Function Save() As Integer
        Return _Employee.Save()
    End Function

    Public Function GetEmployeeList() As SqlDataReader
        Return myDB.GetDataReaderBySP("dbo.sp_GetEmployeeList")
    End Function

    Public Function GetEmployeePhoneList() As SqlDataReader
        Return myDB.GetDataReaderBySP("dbo.sp_GetEmployeePhoneList")
    End Function

    Public Function GetEmployeeByName(strLname As String, strFname As String) As CEmployee
        '  Dim params(0) As SqlParameter
        Dim params As New ArrayList
        Dim param1 As New SqlParameter("lname", strLname)
        params.Add(param1)
        Dim param2 As New SqlParameter("fname", strFname)
        params.Add(param2)
        FillObject(myDB.GetDataReaderBySP("dbo.sp_GetEmployeeByName", params))
        Return _Employee
    End Function

    Public Function GetEmployeeByPhone(strPhone As String) As CEmployee
        Dim aParam As New SqlParameter("phone", strPhone)
        FillObject(myDB.GetDataReaderBySP("dbo.sp_GetEmployeeByPhone", aParam))
        Return _Employee
    End Function

    Public Function GetMemberByID(strID As String) As CEmployee
        Dim aParam As New SqlParameter("ID", strID)
        FillObject(myDB.GetDataReaderBySP("dbo.sp_GetEmployeeByID", aParam))
        Return _Employee
    End Function

    Public Function FillObject(sqlDR As SqlDataReader) As CEmployee
        'why persist the object, just pass updateObject with the datareader
        'you could also isnull your select statement fields to get rid of all that appending
        Using sqlDR
            If sqlDR.Read() Then
                With _Employee
                    .EmpID = sqlDR.Item("EmpID") & ""
                    .LName = sqlDR.Item("LName") & ""
                    .FName = sqlDR.Item("FName") & ""
                    .Address = sqlDR.Item("Address") & ""
                    .City = sqlDR.Item("City") & ""
                    .State = sqlDR.Item("State") & ""
                    .Zip = sqlDR.Item("Zip") & ""
                    .Phone = sqlDR.Item("Phone") & ""
                    .DateHired = SafeDate(sqlDR.Item("DateHired").ToString())  '& ""
                    .Commission = sqlDR.Item("CommissionRate") & ""
                    .RoleID = sqlDR.Item("RoleID") & ""
                End With
            Else
                'failed
            End If
        End Using
        Return _Employee
    End Function
End Class
