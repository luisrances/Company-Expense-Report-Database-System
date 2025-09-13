Imports MySql.Data.MySqlClient
Public Class M_expense
    Dim con As New MySqlConnection("server=localhost;user=root;password=;database=company_expense_db")
    Dim emp_id As String

    Public Sub New(ByVal employeeID As String)
        InitializeComponent()
        emp_id = employeeID
    End Sub

    'SessionTimeout
    Private sessionManager As SessionManager
    Private Sub M_expense(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sessionManager.StopSession()
    End Sub
    'sessiontimeout
    Private Sub M_expense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SessionTimeout to be load
        sessionManager = New SessionManager(Me, New main_login(), 60)

        'con.Open()
        'If con.State = ConnectionState.Open Then
        '    MsgBox("Database Connected!")
        'Else
        '    MsgBox("There's an error in connecting to the database.")
        'End If
        'con.Close()

        txtsearch.Text = emp_id
        LoadRecords()
    End Sub

    Private Sub btnBackToMenu_Click(sender As Object, e As EventArgs) Handles btnBackToMenu.Click
        Manager.Show()
        Me.Hide()
    End Sub

    Public Sub LoadRecords()
        Try
            con.Open()
            Dim sql As String = "SELECT * FROM ExpenseView WHERE emp_id = '" & txtsearch.Text & "';"
            Console.WriteLine("SQL Query: " & sql)
            Dim cmd As New MySqlCommand(sql, con)
            Dim DA As New MySqlDataAdapter(cmd)
            Dim DT As New DataTable
            DA.Fill(DT)
            dgvExpense.DataSource = DT
        Catch ex As Exception
            MessageBox.Show("Error loading records: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        If txtsearch.Text <> "" Then
            Try
                Dim sql As String = "SELECT * FROM expenseview WHERE emp_id LIKE '%" & txtsearch.Text &
                    "%' OR exp_id LIKE '%" & txtsearch.Text &
                    "%' OR exp_type_id LIKE '%" & txtsearch.Text &
                    "%' OR exp_description LIKE '%" & txtsearch.Text &
                    "%' OR exp_date LIKE '%" & txtsearch.Text &
                    "%' OR exp_amount LIKE '%" & txtsearch.Text & "%';"
                Dim cmd As New MySqlCommand(sql, con)
                Dim DA As New MySqlDataAdapter(cmd)
                Dim DT As New DataTable
                DA.Fill(DT)
                dgvExpense.DataSource = DT
            Catch ex As Exception
                MessageBox.Show("Error searching records: " & ex.Message)
            Finally
                con.Close()
            End Try
        Else
            dgvExpense.DataSource = Nothing
        End If
    End Sub

    Private Sub btnViewRecords_Click(sender As Object, e As EventArgs) Handles btnViewRecords.Click
        LoadRecords()
    End Sub
End Class