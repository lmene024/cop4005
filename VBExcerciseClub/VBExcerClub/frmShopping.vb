Imports System.Data.SqlClient

Public Class frmShopping
    Private dataReader As SqlDataReader
    Private blnOrderStarted As Boolean = False
    Private Members As CMembers
    'Private Orders As COrders
    'Private Products As CProducts

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Members = New CMembers
        'Orders = New COrders
        'Products = New CProducts
    End Sub


    Private Sub tsbContact_Click(sender As Object, e As EventArgs) Handles tsbContact.Click
        intNextAction = ACTION_CONTACT
        hideForm()
    End Sub

    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        intNextAction = ACTION_HELP
        hideForm()
    End Sub


    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        intNextAction = ACTION_MEMBER
    End Sub

    Private Sub tsbProgram_Click(sender As Object, e As EventArgs) Handles tsbProgram.Click
        intNextAction = ACTION_PROGRAM
        hideForm()
    End Sub

    Private Sub tsbReturn_Click(sender As Object, e As EventArgs) Handles tsbReturn.Click
        intNextAction = ACTION_NONE
        hideForm()
    End Sub

    Private Sub tsbShop_Click(sender As Object, e As EventArgs) Handles tsbShop.Click

    End Sub


    Private Sub tsbHome_Click(sender As Object, e As EventArgs) Handles tsbHome.Click
        intNextAction = ACTION_HOME
        hideForm()
    End Sub

    Private Sub hideForm()
        If Not blnOrderStarted Then
            Me.Hide()
        Else
            MessageBox.Show("Please complete or cancel the current order", "Order in Process", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
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

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If Not blnOrderStarted Then
            blnOrderStarted = True
            'lblOrderNum = 
            lblMemName.Text = cboMembers.SelectedItem.ToString
            cboMembers.Enabled = False
        Else
            MessageBox.Show("Order has already been started for Member:" & cboMembers.SelectedItem.ToString,
                            "Order in Process", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub frmShopping_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        loadMembers()
        loadProducts()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim intQty As Integer = CInt(nudQty.Value)
        Dim item As String = lstItems.SelectedItem.ToString
    End Sub

    Private Sub sellItem()
        'lsvLines.Items.Add("")
        'lblSub.Text = ""
        'lblTax.Text = ""
        'lblTotal.Text = ""
    End Sub

    Private Sub btnCancelOrder_Click(sender As Object, e As EventArgs) Handles btnCancelOrder.Click
        lblOrderNum.Text = ""
        lblMemName.Text = ""
        lsvLines.Items.Clear()
        cboMembers.Enabled = True
        cboMembers.SelectedIndex = -1
        blnOrderStarted = False
    End Sub
End Class