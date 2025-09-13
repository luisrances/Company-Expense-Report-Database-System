Imports MySql.Data.MySqlClient
Public Class change_pass
    Dim con As New MySqlConnection("server=localhost; user=root; password=; database=company_expense_db;")
    Dim cmd As New MySqlCommand

    'SessionTimeout
    Private sessionManager As SessionManager
    Private Sub change_pass(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sessionManager.StopSession()
    End Sub
    'sessiontimeout

    Private Sub change_pass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SessionTimeout to be load
        sessionManager = New SessionManager(Me, New main_login(), 60)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If main_login.userLevel = "employee" Then
            Me.Hide()
            Employee.Show()
        ElseIf main_login.userLevel = "manager" Then
            Me.Hide()
            Manager.Show()
        End If
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        Dim NewPass As String = txtNewPass.Text
        Dim OldPass As String = txtOldpass.Text
        Dim isValidLength As Boolean = Len(NewPass) >= 8
        Dim hasNumber As Boolean = False
        Dim hasLowerCase As Boolean = False
        Dim hasUpperCase As Boolean = False


        Try
            con.Open()
            Dim checkSql As String = "SELECT COUNT(*) FROM accounts WHERE PASS = '" & OldPass & "';"
            cmd.Connection = con
            cmd.CommandText = checkSql
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If count = 0 Then
                MessageBox.Show("Old password does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                lblnewpass.Text = ""
                Dim updateSql As String = "UPDATE accounts SET PASS = '" & NewPass & "' WHERE PASS = '" & OldPass & "';"
                cmd.CommandText = updateSql
                cmd.ExecuteNonQuery()
                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNewPass.Text = ""
                txtOldpass.Text = ""

            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show("An error occurred while updating the password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtOldpass_TextChanged(sender As Object, e As EventArgs) Handles txtOldpass.TextChanged
        If txtOldpass.Text IsNot "" Then
            txtNewPass.Enabled = True
        Else
            txtNewPass.Enabled = False
        End If
    End Sub

    Private Sub btnShowOldpass_Click(sender As Object, e As EventArgs) Handles btnShowOldpass.Click
        If txtOldpass.PasswordChar = "*"c Then
            txtOldpass.PasswordChar = ControlChars.NullChar
            btnShowOldpass.Text = "Hide"
        Else
            txtOldpass.PasswordChar = "*"c
            btnShowOldpass.Text = "Show"
        End If
    End Sub

    Private Sub btnShowNewPass_Click(sender As Object, e As EventArgs) Handles btnShowNewPass.Click
        If txtNewPass.PasswordChar = "*"c Then
            txtNewPass.PasswordChar = ControlChars.NullChar
            btnShowNewPass.Text = "Hide"
        Else
            txtNewPass.PasswordChar = "*"c
            btnShowNewPass.Text = "Show"
        End If
    End Sub

    Private Sub txtNewPass_TextChanged(sender As Object, e As EventArgs) Handles txtNewPass.TextChanged
        If txtNewPass.Text = "" Then
            lblnewpass.Text = ""
        Else
            Dim NewPass As String = txtNewPass.Text
            Dim OldPass As String = txtOldpass.Text
            Dim isValidLength As Boolean = Len(NewPass) >= 8
            Dim hasNumber As Boolean = False
            Dim hasLowerCase As Boolean = False
            Dim hasUpperCase As Boolean = False
            For i = 1 To Len(NewPass)
                If Char.IsLetterOrDigit(Mid(NewPass, i, 1)) Then
                    If IsNumeric(Mid(NewPass, i, 1)) Then hasNumber = True
                    If Not IsNumeric(Mid(NewPass, i, 1)) Then
                        If LCase(Mid(NewPass, i, 1)) = Mid(NewPass, i, 1) Then hasLowerCase = True
                        If UCase(Mid(NewPass, i, 1)) = Mid(NewPass, i, 1) Then hasUpperCase = True
                    End If
                End If
            Next i

            btnsave.Enabled = False
            If isValidLength = False Then
                lblnewpass.Text = "Minimum of 8 characters!"
                lblnewpass.ForeColor = System.Drawing.Color.Red
            ElseIf hasNumber = False Then
                lblnewpass.Text = "Password must contain number/s!"
                lblnewpass.ForeColor = System.Drawing.Color.Red
            ElseIf hasLowerCase = False Then
                lblnewpass.Text = "Password must contain lowercase letters!"
                lblnewpass.ForeColor = System.Drawing.Color.Red
            ElseIf hasUpperCase = False Then
                lblnewpass.Text = "Password must contain uppercase letters!"
                lblnewpass.ForeColor = System.Drawing.Color.Red
            ElseIf hasNumber And hasLowerCase And hasUpperCase And isValidLength Then
                lblnewpass.Text = "Valid Password"
                lblnewpass.ForeColor = System.Drawing.Color.Green
                btnsave.Enabled = True
            End If
        End If

    End Sub

End Class