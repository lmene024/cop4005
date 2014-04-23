Imports System.Data.SqlClient

Public Class frmShopping
    Private blnOrderStarted As Boolean = False
    Private DataReader As SqlDataReader
    Private Members As CMembers
    Private Employees As CEmployees
    Private Orders As COrders
    'Private Products As CProducts

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Members = New CMembers
        Employees = New CEmployees
        Orders = New COrders
    End Sub

    Private Sub frmShopping_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadMembers()
        LoadProducts("")
        LoadEmployees()
        resetTotals()
    End Sub

    Private Sub LoadMembers()
        DataReader = Members.GetMemberList()
        cboMembers.Items.Clear()
        While dataReader.Read
            cboMembers.Items.Add(DataReader.Item("lname") & ", " & DataReader.Item("fname"))
        End While
        DataReader.Close()
    End Sub

    Private Sub LoadEmployees()
        DataReader = Employees.GetEmployeeList()
        cboEmployee.Items.Clear()
        While DataReader.Read
            cboEmployee.Items.Add(DataReader.Item("lname") & ", " & DataReader.Item("fname"))
        End While
        DataReader.Close()
    End Sub

    Private Sub LoadProducts(ByRef strSearch As String)
        lstItems.Items.Clear()
    End Sub

    Private Sub PerformNextAction()
        'get the next action selected on the child form, and then
        'simulate the click of the button here
        Select Case intNextAction
            Case ACTION_HOME
                tsbHome.PerformClick()
            Case ACTION_CONTACT
                tsbContact.PerformClick()
            Case ACTION_HELP
                tsbHelp.PerformClick()
            Case ACTION_MEMBER
                tsbMember.PerformClick()
            Case ACTION_PROGRAM
                tsbProgram.PerformClick()
            Case ACTION_SHOP
                tsbShop.PerformClick()
            Case Else
                'do nothing
        End Select
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

    Private Sub tsbContact_Click(sender As Object, e As EventArgs) Handles tsbContact.Click
        intNextAction = ACTION_CONTACT
        hideForm()
    End Sub

    Private Sub tsbShop_Click(sender As Object, e As EventArgs) Handles tsbShop.Click
        'do nothing
    End Sub

    Private Sub tsbProgram_Click(sender As Object, e As EventArgs) Handles tsbProgram.Click
        intNextAction = ACTION_PROGRAM
        hideForm()
    End Sub

    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        intNextAction = ACTION_HELP
        hideForm()
    End Sub

    Private Sub tsbHome_Click(sender As Object, e As EventArgs) Handles tsbHome.Click
        intNextAction = ACTION_HOME
        hideForm()
    End Sub

    Private Sub tsbReturn_Click(sender As Object, e As EventArgs) Handles tsbReturn.Click
        intNextAction = ACTION_NONE
        hideForm()
    End Sub

    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        intNextAction = ACTION_MEMBER
        hideForm()
    End Sub

    Private Sub hideForm()
        If Not blnOrderStarted Then
            Me.Hide()
        Else
            MessageBox.Show("Please finish or cancel the current order.", "Order in Process", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub StartNewOrder()
        Dim blnError As Boolean = False
        errP.Clear()
        If cboEmployee.SelectedIndex < 0 Then
            blnError = True
            errP.SetError(cboEmployee, "Please select your Employee Id")
        End If
        If cboMembers.SelectedIndex < 0 Then
            blnError = True
            errP.SetError(cboMembers, "Please select a member to create an order")
        End If

        If Not blnError Then
            Orders.CreateNewOrder()
            blnOrderStarted = True
            lblMemName.Text = cboMembers.SelectedItem.ToString
            lblOrderNum.Text = Orders.CurrentObject.InvoiceID
            cboEmployee.Enabled = False
            cboMembers.Enabled = False
            resetTotals()
        End If
    End Sub
  
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If Not blnOrderStarted Then
            StartNewOrder()
        Else
            MessageBox.Show("Order currently in process for " & cboMembers.SelectedItem.ToString,
                            "Order in Process", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadProducts(txtSearch.Text)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not blnOrderStarted Then
            StartNewOrder() ' just in case they forgot to start new order
        End If
        'add selected item * qty to order
        nudQty.Value = nudQty.Minimum
    End Sub

    Private Sub lstItems_DoubleClick(sender As Object, e As EventArgs) Handles lstItems.DoubleClick
        btnAdd.PerformClick()
    End Sub

    Private Sub btnCancelOrder_Click(sender As Object, e As EventArgs) Handles btnCancelOrder.Click
        lblMemName.Text = ""
        lblOrderNum.Text = ""
        lsvLines.Items.Clear()
        resetTotals()
        blnOrderStarted = False
    End Sub

    Private Sub resetTotals()
        lblSub.Text = "0.00"
        lblTax.Text = "0.00"
        lblTotal.Text = "0.00"
    End Sub

End Class