Imports System.Data.SqlClient

Public Class frmShopping
    Private blnOrderStarted As Boolean = False
    Private DataReader As SqlDataReader
    Private Members As CMembers
    Private Employees As CEmployees
    Private Orders As COrders
    Private Products As CProducts
    Private InvoiceForm As frmInvoice

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Members = New CMembers
        Employees = New CEmployees
        Orders = New COrders
        Products = New CProducts
    End Sub

    Private Sub frmShopping_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadMembers()
        LoadProducts("")
        LoadEmployees()
        initListViewColumns()
        calcTotals()
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
        If Not strSearch = Nothing Then
            DataReader = Products.SearchProductList(strSearch)
        Else
            DataReader = Products.GetProductList()
        End If
        lstItems.Items.Clear()
        While DataReader.Read
            lstItems.Items.Add(DataReader.Item("prodid") & " - " & DataReader.Item("proddesc"))
        End While
        DataReader.Close()
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

    Private Function StartNewOrder() As Boolean
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
            Dim strMember() As String = cboMembers.SelectedItem.ToString.Split(","c)
            Dim strEmployee() As String = cboEmployee.SelectedItem.ToString.Split(","c)
            Orders.CreateNewOrder()
            blnOrderStarted = True
            Members.GetMemberByName(Trim(strMember(0)), Trim(strMember(1)))
            Employees.GetEmployeeByName(Trim(strEmployee(0)), Trim(strEmployee(1)))
            lblMemName.Text = Members.CurrentObject.FName & " " & Members.CurrentObject.LName
            lblOrderNum.Text = Orders.CurrentObject.InvoiceID
            cboEmployee.Enabled = False
            cboMembers.Enabled = False
            calcTotals()
        End If
        Return Not blnError
    End Function

    Private Sub initListViewColumns()
        lsvLines.Items.Clear()
        lsvLines.Columns.Add("Code")
        lsvLines.Columns.Add("Description")
        lsvLines.Columns.Add("Qty")
        lsvLines.Columns.Add("Total")
        lsvLines.Columns.Add("T")
        Dim intWidth As Integer
        intWidth = lsvLines.Columns(0).Width +
                  lsvLines.Columns(2).Width +
                  lsvLines.Columns(3).Width + 25
        lsvLines.Columns(1).Width = lsvLines.Width - intWidth
        lsvLines.Columns(4).Width = 25
    End Sub

    Private Sub addItemToOrder()
        If lstItems.SelectedIndex < 0 Then 'nothing selected
            Exit Sub
        End If

        Dim qty As Integer = nudQty.Value
        Dim strProdID As String = Trim(lstItems.SelectedItem.ToString.Split("-"c)(0))
        Dim product As CProduct = Products.GetProductByID(strProdID)
        Dim line As ListViewItem

        With product
            line = New ListViewItem(.ProductID)
            line.SubItems.Add(.ProductDescription)
            line.SubItems.Add(qty)
            line.SubItems.Add(FormatCurrency(qty * .RetailPrice))
            If (.isTaxable) Then
                line.SubItems.Add("T")
            Else
                line.SubItems.Add("")
            End If
        End With
        lsvLines.Items.Add(line)
        calcTotals()
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
        Dim blnStarted As Boolean = True
        If Not blnOrderStarted Then
            blnStarted = StartNewOrder() ' just in case they forgot to start new order
        End If
        If blnStarted Then
            addItemToOrder()
            nudQty.Value = nudQty.Minimum
        End If
    End Sub

    Private Sub lstItems_DoubleClick(sender As Object, e As EventArgs) Handles lstItems.DoubleClick
        btnAdd.PerformClick()
    End Sub

    Private Sub btnCancelOrder_Click(sender As Object, e As EventArgs) Handles btnCancelOrder.Click
        ClearOrder()
    End Sub

    Private Sub ClearOrder()
        lblMemName.Text = ""
        lblOrderNum.Text = ""
        lsvLines.Items.Clear()
        calcTotals()
        cboEmployee.Enabled = True
        cboMembers.Enabled = True
        blnOrderStarted = False
        Orders.Clear()
        Members.Clear()
        Employees.Clear()
    End Sub

    Private Sub calcTotals()
        Dim sngTotal As Single = 0
        Dim sngTaxable As Single = 0

        For Each lstRow As ListViewItem In lsvLines.Items
            Dim value As Single = CSng(lstRow.SubItems(3).Text)
            sngTotal += value
            If Not lstRow.SubItems(4).Text = "" Then
                sngTaxable += value
            End If
        Next



        lblSub.Text = FormatCurrency(sngTotal)
        lblTax.Text = FormatCurrency(sngTaxable * sTax)
        lblTotal.Text = FormatCurrency(sngTotal + (sngTotal * sTax))
    End Sub

    Private Sub SaveOrder()
        With Orders.CurrentObject
            .MbrID = Members.CurrentObject.MbrID
            .EmpID = Employees.CurrentObject.EmpID
            .InvTotal = CSng(lblTotal.Text)
            .ProdTotal = CSng(lblSub.Text)
            .TaxTotal = CSng(lblTax.Text)
            .InvoiceDate = New Date(Now.Year, Now.Month, Now.Day)
            For Each line As ListViewItem In lsvLines.Items
                Dim item As COrdItem = Orders.NewItem
                item.ProdId = line.SubItems(0).Text
                item.Qty = CInt(line.SubItems(2).Text)
                item.Price = CSng(line.SubItems(3).Text)
                Orders.AddItemToOrder(item)
            Next
        End With
        Orders.Save()
        Orders.AddItems()
        InvoiceForm = New frmInvoice(Orders.CurrentObject.InvoiceID)
        InvoiceForm.ShowDialog()
        ClearOrder()
    End Sub

    Private Sub btnConfirmOrder_Click(sender As Object, e As EventArgs) Handles btnConfirmOrder.Click
        SaveOrder()
    End Sub
End Class