Imports System.Data.SqlClient
Public Class CPrograms
    Private _Program As CProgram

    'constructor
    Public Sub New()
        _Program = New CProgram
    End Sub

    Public ReadOnly Property CurrentObject() As CProgram
        Get
            Return _Program
        End Get
    End Property

    Public Sub Clear()
        _Program = New CProgram() 'so much faster this way
    End Sub

    Public Sub CreateNewMember() 'Call me when you're clearing the screen to add a new student!
        'This clears the old student and sets it as new
        Clear()
        _Program.IsNewProgram = True
    End Sub

    Public Function Save() As Integer
        Return _Program.Save()
    End Function

    Public Function GetAllProgramIDs() As SqlClient.SqlDataReader
        Return myDB.GetDataReaderBySP("dbo.sp_GetAllProgramIDs")
    End Function

    Public Function GetProgramByDesc(strDesc As String) As CProgram
        Dim aParam As New SqlParameter("progid", strDesc)
        FillObject(myDB.GetDataReaderBySP("dbo.sp_GetProgramByDesc", aParam))
        Return _Program
    End Function

    Public Function GetProgramByID(strID As String) As CProgram
        Dim aParam As New SqlParameter("progid", strID)
        FillObject(myDB.GetDataReaderBySP("dbo.sp_GetProgramByID", aParam))
        Return _Program
    End Function

    Public Function FillObject(sqlDR As SqlDataReader) As CProgram
        Using sqlDR
            If sqlDR.Read Then
                With _Program
                    .ProgID = sqlDR.Item("ProgID")
                    .ProgDesc = sqlDR.Item("ProgDesc")
                End With
            End If
        End Using
        Return _Program
    End Function
End Class
