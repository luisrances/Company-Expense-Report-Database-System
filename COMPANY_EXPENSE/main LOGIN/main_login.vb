Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class main_login
    Dim con As New MySqlConnection("server=localhost; user=root; password=; database=company_expense_db;")
    Dim da As New MySqlDataAdapter
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Public value As String
    Public attempts As Integer = 0
    Public counter As Integer = 60
    Public Shared email As String
    Public Shared userLevel As String

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        If txt_email.Text.Length = 0 Or txt_pass.Text.Length = 0 Then
            MsgBox("Enter your email and password")
        Else
            check_account()
        End If
    End Sub

    'Multifactor
    Private Sub OpenMultifactor(position As String)
        Me.Hide()
        Multifactor.Show()
        'Dim multifactor As New Multifactor
        'multifactor.StartPosition = FormStartPosition.Manual
        'multifactor.Location = Me.Location
        'If multifactor.ShowDialog() = DialogResult.OK Then
        '    txt_email.Text = ""
        '    txt_pass.Text = ""
        '    redirect(position)
        'Else
        '    MsgBox("Failed to verify account.")
        'End If
    End Sub
    '--------

    '--- multiple failed attempt timer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If counter = 0 Then
            Timer1.Stop()
            correctAttempts()
        Else
            counter -= 1
        End If
    End Sub
    Private Sub failedAttempts()
        attempts = attempts + 1
        If attempts = 3 Then
            MsgBox("Multiple failed attempts. Wait for " & counter & " seconds")
            txt_email.Enabled = False
            txt_pass.Enabled = False
            Panel1.Enabled = False
            Timer1.Start()
        Else
            MsgBox("incorrect email")
        End If
    End Sub
    Private Sub correctAttempts()
        attempts = 0
        counter = 60
        txt_email.Enabled = True
        txt_pass.Enabled = True
        Panel1.Enabled = True
    End Sub
    'multiple failed attempt timer end ---

    Public Sub check_account()
        Dim pass, position As String
        Try
            con.Open()
            dt = New DataTable
            Dim sql As String = "select accounts.email, accounts.pass, accounts.employee_id, employees.position_id from accounts 
left join employees on accounts.employee_id = employees.employee_id
where email = '" & txt_email.Text & "';"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                pass = dt(0)(1).ToString
                If txt_pass.Text = pass Then
                    value = dt(0)(2).ToString
                    If dt(0)(2).ToString = "0" Then
                        position = "admin"
                    ElseIf dt(0)(3).ToString = "1" Or dt(0)(3).ToString = "2" Then
                        position = "manager"
                    Else
                        position = "employee"
                    End If
                    email = txt_email.Text
                    txt_email.Text = ""
                    txt_pass.Text = ""
                    'redirect(position)

                    correctAttempts()
                    userLevel = position
                    'Captcha
                    OpenMultifactor(position)
                ElseIf txt_pass.Text <> pass Then
                    MsgBox("incorrect password")
                End If
            Else
                failedAttempts()
            End If

        Catch ex As Exception
        End Try
        con.Close()
    End Sub
    'Public Sub redirect(position As String)
    '    userLevel = position
    '    If position = "employee" Then
    '        MsgBox("Welcome dear employee")
    '        Me.Hide()
    '        Employee.Show()
    '    ElseIf position = "manager" Then
    '        MsgBox("Welcome dear manager")
    '        Me.Hide()
    '        Manager.Show()
    '    ElseIf position = "admin" Then
    '        MsgBox("Welcome dear admin")
    '        Me.Hide()
    '        sample_menu.Show()
    '    End If
    'End Sub


    ' encryption Function to hash a given string using SHA256
    Public Shared Function HashStringSHA256(ByVal input As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(input) ' Convert input string to byte array
            Dim hashBytes As Byte() = sha256.ComputeHash(inputBytes) ' Compute the hash
            Dim sb As New StringBuilder() ' Convert hash byte array to hexadecimal string
            For Each b As Byte In hashBytes
                sb.Append(b.ToString("x2")) ' Convert to hexadecimal
            Next
            Return sb.ToString()
        End Using
    End Function
    Sub Main()
        Dim password As String = txt_pass.Text
        Dim hashedPassword As String = HashStringSHA256(password)
    End Sub
    ' end encryption

    Private Sub main_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class