Imports System.Data.SqlClient
Public Class CMembers
    'This class represents the Members table and the associated business rules for it
    Private _Member As CMember

    'constructor
    Public Sub New()
        'instantiate the CMember object
        _Member = New CMember
    End Sub

    Public ReadOnly Property CurrentObject() As CMember
        Get
            Return _Member
        End Get
    End Property

    Public Function IsValidJoinDate(dtmDate As Date) As Boolean
        'ensure that the date is today or earlier, and not a future date
        If dtmDate <= Today Then 'this is not a future date
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub Clear()
        _Member = New CMember() 'so much faster this way
    End Sub

    Public Sub CreateNewMember() 'Call me when you're clearing the screen to add a new student!
        'This clears the old student and sets it as new
        Clear()
        _Member.IsNewMember = True
    End Sub

    Public Function Save() As Integer
        Return _Member.Save()
    End Function

    Public Function GetMemberList() As SqlDataReader
        Return myDB.GetDataReaderBySP("dbo.sp_GetMemberList")
    End Function

    Public Function GetMemberPhoneList() As SqlDataReader
        Return myDB.GetDataReaderBySP("dbo.sp_GetMemberPhoneList")
    End Function

    Public Function GetMemberByName(strLname As String, strFname As String) As CMember
        '  Dim params(0) As SqlParameter
        Dim params As New ArrayList
        Dim param1 As New SqlParameter("lname", strLname)
        params.Add(param1)
        Dim param2 As New SqlParameter("fname", strFname)
        params.Add(param2)
        FillObject(myDB.GetDataReaderBySP("dbo.sp_GetMemberByName", params))
        Return _Member
    End Function

    Public Function GetMemberByPhone(strPhone As String) As CMember
        Dim aParam As New SqlParameter("phone", strPhone)
        FillObject(myDB.GetDataReaderBySP("dbo.sp_GetMemberByPhone", aParam))
        Return _Member
    End Function

    Public Function GetMemberByID(strID As String) As CMember
        Dim aParam As New SqlParameter("ID", strID)
        FillObject(myDB.GetDataReaderBySP("dbo.sp_GetMemberByID", aParam))
        Return _Member
    End Function

    Public Function FillObject(sqlDR As SqlDataReader) As CMember
        'why persist the object, just pass updateObject with the datareader
        'you could also isnull your select statement fields to get rid of all that appending
        Using sqlDR
            If sqlDR.Read() Then
                With _Member
                    .MbrID = sqlDR.Item("MbrID") & ""
                    .LName = sqlDR.Item("LName") & ""
                    .FName = sqlDR.Item("FName") & ""
                    .Address = sqlDR.Item("Address") & ""
                    .City = sqlDR.Item("City") & ""
                    .State = sqlDR.Item("State") & ""
                    .Zip = sqlDR.Item("Zip") & ""
                    .Phone = sqlDR.Item("Phone") & ""
                    .DateJoined = SafeDate(sqlDR.Item("DateJoined").ToString())  '& ""
                    .Email = sqlDR.Item("Email") & ""
                    .ProgID = sqlDR.Item("ProgID") & ""
                End With
            Else
                'failed
            End If
        End Using
        Return _Member
    End Function
End Class
