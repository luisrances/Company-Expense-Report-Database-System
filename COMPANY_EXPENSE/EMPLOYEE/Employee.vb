Imports MySql.Data.MySqlClient
Public Class Employee
    Dim con As New MySqlConnection("server=localhost; user=root; password=; database=company_expense_db;")

    Private Sub btnExpense_Click(sender As Object, e As EventArgs) Handles btnExpense.Click
        Dim emp_id As String = txtEmployeeID.Text
        Dim emp_name As String = txtName.Text
        Dim E_expense As New E_expense(emp_id, emp_name)
        E_expense.Show()
        Me.Hide()
    End Sub

    Private Sub btnOverallExpense_Click(sender As Object, e As EventArgs) Handles btnOverallExpense.Click
        Dim emp_id As String = txtEmployeeID.Text
        Dim E_overall_expense As New E_overall_expense(emp_id)
        E_overall_expense.Show()
        Me.Hide()
    End Sub

    Private Sub btnOverview_Click(sender As Object, e As EventArgs) Handles btnOverview.Click
        Dim emp_id As String = txtEmployeeID.Text
        Dim E_overview As New E_overview(emp_id)
        E_overview.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Me.Close()
        Me.Hide()
        main_login.Show()
    End Sub

    Private Sub txtEmployeeID_TextChanged(sender As Object, e As EventArgs) Handles txtEmployeeID.TextChanged
        Dim sqlQuery As String = "SELECT name, department_id, position_id, emp_contact, emp_email FROM employees WHERE employee_id = " & txtEmployeeID.Text
        Dim cmd As New MySqlCommand(sqlQuery, con)
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("employee_ID", txtEmployeeID.Text)
        Try
            con.Open()
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                txtName.Text = reader("name")
                txtDepartment.Text = reader("department_id")
                txtPosition.Text = reader("position_id")
                txtContact.Text = reader("emp_contact")
                txtEmailAdd.Text = reader("emp_email")
            Else
                MessageBox.Show("Employee ID not found!")
                txtName.Clear()
                txtDepartment.Clear()
                txtPosition.Clear()
                txtContact.Clear()
                txtEmailAdd.Clear()
            End If
            reader.Close()
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub

    'SessionTimeout
    Private sessionManager As SessionManager
    Private Sub Employee(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sessionManager.StopSession()
    End Sub
    'sessiontimeout

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SessionTimeout to be load
        sessionManager = New SessionManager(Me, New main_login(), 60)

        load_employee_info()
    End Sub

    Sub load_employee_info()
        Dim login As New main_login
        con.Open()
        Dim da As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim dt As New DataTable
        dt = New DataTable
        dt.Clear()
        Dim employee_id As String
        employee_id = main_login.value
        'employee_id = 1
        Dim sql As String = "select employee_id, name, dept_name, pos_name, emp_contact, emp_email from v_employees where employee_id = " & employee_id & ";"
        da = New MySqlDataAdapter(sql, con)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            txtEmployeeID.Text = dt(0)(0).ToString
            txtName.Text = dt(0)(1).ToString
            txtDepartment.Text = dt(0)(2).ToString
            txtPosition.Text = dt(0)(3).ToString
            txtContact.Text = dt(0)(4).ToString
            txtEmailAdd.Text = dt(0)(5).ToString
        End If
        con.Close()
    End Sub

    Private Sub Employee_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        load_employee_info()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        change_pass.Show()
    End Sub
End Class
