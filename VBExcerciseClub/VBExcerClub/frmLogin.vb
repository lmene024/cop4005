Public Class frmLogin
    Private Security As CSecurityRecs

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Security = New CSecurityRecs
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtUser.Clear()
        txtPassword.Clear()
        'make sure we remove any logged in user
        userSecurity = SECURITY_N
        intNextAction = ACTION_HOME
        Me.Hide()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim logged As Boolean
        logged = Security.LoginUser(txtUser.Text, txtPassword.Text)
        If logged Then
            Me.Hide()
        Else
            MessageBox.Show("Invalid User Login and/or Password" & vbCrLf & "Please Try Again",
                            "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class