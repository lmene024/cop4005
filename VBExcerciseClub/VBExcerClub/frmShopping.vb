Imports System.Data.SqlClient

Public Class frmShopping
    Private dataReader As SqlDataReader
    Private blnOrderStarted As Boolean = False

    Private Sub frmShopping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadMembers()
    End Sub

    Private Sub tsbContact_Click(sender As Object, e As EventArgs) Handles tsbContact.Click
        intNextAction = ACTION_CONTACT
        Me.Hide()
    End Sub

    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        intNextAction = ACTION_HELP
        Me.Hide()
    End Sub


    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click

    End Sub

    Private Sub tsbProgram_Click(sender As Object, e As EventArgs) Handles tsbProgram.Click
        intNextAction = ACTION_PROGRAM
        Me.Hide()
    End Sub


    Private Sub tsbReturn_Click(sender As Object, e As EventArgs) Handles tsbReturn.Click
        intNextAction = ACTION_NONE
        Me.Hide()
    End Sub

    Private Sub tsbShop_Click(sender As Object, e As EventArgs) Handles tsbShop.Click
        intNextAction = ACTION_SHOP
        Me.Hide()
    End Sub


    Private Sub tsbHome_Click(sender As Object, e As EventArgs) Handles tsbHome.Click
        intNextAction = ACTION_HOME
        Me.Hide()
    End Sub

    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbContact.MouseEnter, tsbReturn.MouseEnter, tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbMember.MouseEnter, tsbProgram.MouseEnter, tsbShop.MouseEnter
        'we need to do this because we are putting out images in the BackGroundImage property
        'instead of the Image property
        Dim tsbProxy As ToolStripButton
        tsbProxy = CType(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbContact.MouseLeave, tsbReturn.MouseLeave, tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbMember.MouseLeave, tsbProgram.MouseLeave, tsbShop.MouseLeave
        'we need to do this because we are putting out images in the BackGroundImage property
        'instead of the Image property
        Dim tsbProxy As ToolStripButton
        tsbProxy = CType(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub

    Private Sub loadMembers()
        Dim members As New CMembers
        cboMembers.Items.Clear()
        dataReader = members.GetMemberList()
        While dataReader.Read
            cboMembers.Items.Add(dataReader.Item("lname") & ", " & dataReader.Item("fname"))
        End While
        dataReader.Close()

    End Sub

    Private Sub loadProducts()
        lstItems.Items.Clear()

    End Sub

End Class