Imports System.Data.SqlClient
Public Class frmMember
    Private members As CMembers
    Private programs As CPrograms
    Private sqlReader As SqlDataReader
    Private blnClering As Boolean
    Private blnNew As Boolean

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        members = New CMembers
        programs = New CPrograms
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

    Private Sub LoadMemberCombo()
        'load the name search combo
        sqlReader = members.GetMemberList()
        cboName.Items.Clear() 'clear current list and reload
        While sqlReader.Read
            cboName.Items.Add(sqlReader.Item("LName") & ", " & sqlReader.Item("FNAME"))
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
        members.GetMemberByName(Trim(strNames(0)), Trim(strNames(1))) 'this loads CurrentObject
        LoadMemberData(members.CurrentObject)
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
        sqlReader = programs.GetAllProgramIDs()
        cboProgram.Items.Clear()
        While sqlReader.Read
            cboProgram.Items.Add(sqlReader.Item("ProgID"))
        End While
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'first do form validation
        Dim blnError As Boolean = False
        Dim intResult As Integer
        'after validation
        If blnError Then 'dont try to process, data is not good
            Exit Sub
        End If
        'now load the CMember object with form data
        With members.CurrentObject
            .MbrID = Trim(txtID.Text)
            .FName = Trim(txtFName.Text)
            .LName = Trim(txtLName.Text)
            .Address = Trim(txtAddress.Text)
            .City = Trim(txtCity.Text)
            .Zip = mskZip.Text
            .Phone = mskPhone.Text
            .Email = Trim(txtEmail.Text)
            .DateJoined = dtmJoined.Value.Date
            .ProgID = cboProgram.SelectedItem.ToString
        End With
        'now give the object back to the business layer (CMembers)
        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            intResult = members.Save
            'success!
        Catch ex As Exception
            If intResult = -1 Then
                MessageBox.Show("MemberID must be unique. Unable to save the record",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Unable to save the record" & ex.ToString,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Try
    End Sub
End Class