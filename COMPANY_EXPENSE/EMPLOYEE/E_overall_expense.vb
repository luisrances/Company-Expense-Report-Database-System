Imports MySql.Data.MySqlClient

Public Class E_overall_expense
    Dim con As New MySqlConnection("server=localhost;user=root;password=;database=company_expense_db; convert zero datetime = true")
    Dim da As New MySqlDataAdapter
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim emp_id As String

    Public Sub New(ByVal employeeID As String)
        InitializeComponent()
        emp_id = employeeID
    End Sub

    'SessionTimeout
    Private sessionManager As SessionManager
    Private Sub E_overall_expense(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sessionManager.StopSession()
    End Sub
    'sessiontimeout
    Private Sub E_overall_expense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SessionTimeout to be load
        sessionManager = New SessionManager(Me, New main_login(), 60)

        'con.Open()
        'If con.State = ConnectionState.Open Then
        '    MsgBox("Database Connected!")
        'Else
        '    MsgBox("There's an error in connecting to database.")
        'End If
        'con.Close()

        'txtsearch.Text = emp_id
        loadrecords()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Employee.Show()
        Me.Hide()
    End Sub

    Public Sub loadrecords()
        Try
            con.Open()
            Dim sql As String = "SELECT exp_id, employees.name, exp_type_name, exp_description, exp_date, exp_amount from v_expense join overview on v_expense.overview_id = overview.overview_id join employees on overview.emp_id = employees.employee_id WHERE employees.employee_id = '" & emp_id & "';"
            Console.WriteLine("SQL Query: " & sql)
            Dim cmd As New MySqlCommand(sql, con)
            Dim DA As New MySqlDataAdapter(cmd)
            Dim DT As New DataTable
            DA.Fill(DT)
            dgvOverallExpense.DataSource = DT
        Catch ex As Exception
            MessageBox.Show("Error loading records: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        If txtsearch.Text <> "" Then
            con.Open()
            Dim sql As String
            sql = "SELECT exp_id, employees.name, exp_type_name, exp_description, exp_date, exp_amount from v_expense join overview on v_expense.overview_id = overview.overview_id join employees on overview.emp_id = employees.employee_id WHERE employees.employee_id = '" & emp_id &
                "' and (exp_id = '%" & txtsearch.Text &
                "%' OR employees.name LIKE '%" & txtsearch.Text &
                "%' OR exp_type_name LIKE '%" & txtsearch.Text &
                "%' OR exp_description LIKE '%" & txtsearch.Text &
                "%' OR exp_date LIKE '%" & txtsearch.Text &
                "%' OR exp_amount LIKE '%" & txtsearch.Text & "%');"
            cmd.Connection = con
            cmd.CommandText = sql
            da = New MySqlDataAdapter(cmd)
            dt = New DataTable()
            da.Fill(dt)
            dgvOverallExpense.DataSource = dt
            con.Close()
            'loadrecords()
            'Else
            '    dgvOverallExpense.DataSource = Nothing
        End If
    End Sub

    Private Sub btnViewRecords_Click(sender As Object, e As EventArgs) Handles btnViewRecords.Click
        loadrecords()
    End Sub
End Class