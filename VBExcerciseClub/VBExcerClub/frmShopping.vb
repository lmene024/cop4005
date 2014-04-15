Imports System.Data.SqlClient

Public Class frmShopping

    Private blnOrderStarted As Boolean = False

    Private Sub frmShopping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadMembers()
    End Sub

    Private Sub loadMembers()
        Dim members As New CMembers
        Dim dataReader As SqlDataReader = members.GetMemberList()
        While dataReader.Read
            cboMembers.Items.Add(dataReader("mbrid") & " - " & dataReader("lname") & ", " & dataReader("fname"))
        End While


    End Sub

    Private Sub loadProducts()

    End Sub

End Class