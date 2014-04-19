Imports System.Data.SqlClient
Public Class frmMember

    Private Members As CMembers
    Private Programs As CPrograms
    Private sqlReader As SqlClient.SqlDataReader
    Private blnClearing As Boolean
    Private blnNew As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Members = New CMembers
        Programs = New CPrograms
    End Sub

    Private Sub tsbContact_Click(sender As Object, e As EventArgs) Handles tsbContact.Click
        IntNextAction = ACTION_CONTACT
        Me.Hide()
    End Sub

    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        IntNextAction = ACTION_HELP
        Me.Hide()
    End Sub

    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        'Do nothing here - already on this screen
    End Sub

    Private Sub tsbProgram_Click(sender As Object, e As EventArgs) Handles tsbProgram.Click
        IntNextAction = ACTION_PROGRAM
        Me.Hide()
    End Sub

    Private Sub tsbReturn_Click(sender As Object, e As EventArgs) Handles tsbReturn.Click
        IntNextAction = ACTION_NONE
        Me.Hide()
    End Sub

    Private Sub tsbShop_Click(sender As Object, e As EventArgs) Handles tsbShop.Click
        IntNextAction = ACTION_SHOP
        Me.Hide()
    End Sub

    Private Sub tsbHome_Click(sender As Object, e As EventArgs) Handles tsbHome.Click
        IntNextAction = ACTION_HOME
        Me.Hide()
    End Sub

    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbContact.MouseEnter, tsbReturn.MouseEnter, tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbMember.MouseEnter, tsbProgram.MouseEnter, tsbShop.MouseEnter
        'we need to do this becasue we are putting our images in the BackgroundImage property
        'Instead of the Image property
        Dim tsbProxy As ToolStripButton
        tsbProxy = CType(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbContact.MouseLeave, tsbReturn.MouseLeave, tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbMember.MouseLeave, tsbProgram.MouseLeave, tsbShop.MouseLeave
        'we need to do this becasue we are putting our images in the BackgroundImage property
        'Instead of the Image property
        Dim tsbProxy As ToolStripButton
        tsbProxy = CType(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub

    Private Sub LoadMemberCombo()
        'Load the name search combo
        sqlReader = Members.GetMemberList
        cboName.Items.Clear() 'Clear out current list and reload
        While sqlReader.Read
            cboName.Items.Add(sqlReader.Item("LName") & ", " & sqlReader.Item("FName"))
        End While
        sqlReader.Close()
    End Sub

    Private Sub frmMember_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadMemberCombo()
        LoadProgramCombo()
    End Sub

    Private Sub LoadMemberFormByName(strFullName As String)
        Dim strNames() As String ' a string array
        strNames = strFullName.Split(","c) 'break out the pieces of the name
        Members.GetMemberByName(Trim(strNames(0)), Trim(strNames(1))) 'this loads CurrentObject
        LoadMemberData(Members.CurrentObject)
    End Sub

    Private Sub LoadMemberData(aMember As CMember)
        If Not aMember Is Nothing Then
            With aMember
                txtID.Text = .MbrID
                txtFName.Text = .FName
                txtLName.Text = .LName
                txtAddress.Text = .Address
                txtCity.Text = .City
                txtState.Text = .State
                mskZip.Text = .Zip
                mskPhone.Text = .Phone
                dtmJoined.Value = .DateJoined
                txtEmail.Text = .Email
                cboProgram.SelectedIndex = cboProgram.FindStringExact(.ProgID)
            End With
        End If
    End Sub

    Private Sub cboName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboName.SelectedIndexChanged
        LoadMemberFormByName(cboName.SelectedItem.ToString)
    End Sub

    Private Sub LoadProgramCombo()
        sqlReader = Programs.GetAllProgramIDs()
        cboProgram.Items.Clear()
        While sqlReader.Read
            cboProgram.Items.Add(sqlReader.Item("ProgID"))
        End While
        sqlReader.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'first do form validation
        Dim blnError As Boolean = False
        Dim intResult As Integer
        'after validation
        If blnError Then 'don't try to process, data is not good
            Exit Sub
        End If
        'Now load the Cmember object with form data
        With Members.CurrentObject
            .MbrID = Trim(txtID.Text)
            .FName = Trim(txtFName.Text)
            .LName = Trim(txtLName.Text)
            .Address = Trim(txtAddress.Text)
            .City = Trim(txtCity.Text)
            .State = Trim(txtState.Text)
            .Zip = mskZip.Text
            .Phone = mskPhone.Text
            .Email = Trim(txtEmail.Text)
            .DateJoined = dtmJoined.Value.Date
            .ProgID = cboProgram.SelectedItem.ToString
        End With
        'now give the object back to the business layer (Cmembers)
        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            intResult = Members.Save
        Catch ex As Exception
            If intResult = -1 Then 'id is not unique
                MessageBox.Show("MemberID must be uniqe. Unable to save the record.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else 'some other error
                MessageBox.Show("Unable to save record.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Try
    End Sub
End Class