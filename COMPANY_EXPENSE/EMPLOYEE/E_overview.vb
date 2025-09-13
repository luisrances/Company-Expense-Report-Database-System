Imports MySql.Data.MySqlClient
Public Class E_overview
    Dim con As New MySqlConnection("server=localhost; user=root; password=; database=company_expense_db;")
    Dim emp_id As String

    Public Sub New(ByVal employeeID As String)
        InitializeComponent()
        emp_id = employeeID
    End Sub

    'SessionTimeout
    Private sessionManager As SessionManager
    Private Sub E_overview(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sessionManager.StopSession()
    End Sub
    'sessiontimeout
    Private Sub E_overview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub loadrecords()
        Try
            con.Open()
            Dim sql As String = "SELECT * FROM OVERVIEW WHERE emp_ID = '" & emp_id & "';"
            Dim cmd As New MySqlCommand(sql, con)
            Dim DA As New MySqlDataAdapter(cmd)
            Dim DT As New DataTable
            DA.Fill(DT)
            dgvOverview.DataSource = DT
        Catch ex As Exception
            MessageBox.Show("Error loading records: " & ex.Message)
        Finally
            con.Close()
        End Try

    End Sub


    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        If txtsearch.Text <> "" Then
            Try
                Dim sql As String = "SELECT * FROM OVERVIEW WHERE emp_ID = '" & emp_id &
                    "' and ( overview_id LIKE '%" & txtsearch.Text &
                    "%' OR emp_id LIKE '%" & txtsearch.Text &
                    "%' OR purpose_id LIKE '%" & txtsearch.Text &
                    "%' OR from_date LIKE '%" & txtsearch.Text &
                    "%' OR to_date LIKE '%" & txtsearch.Text &
                    "%' OR total_amount LIKE '%" & txtsearch.Text &
                    "%' OR authorization_id LIKE '%" & txtsearch.Text &
                    "%' OR dept_id LIKE '%" & txtsearch.Text & "%' );"
                Dim cmd As New MySqlCommand(sql, con)
                Dim DA As New MySqlDataAdapter(cmd)
                Dim DT As New DataTable
                DA.Fill(DT)
                dgvOverview.DataSource = DT
            Catch ex As Exception
                MessageBox.Show("Error searching records: " & ex.Message)
            Finally
                con.Close()
            End Try
        Else
            dgvOverview.DataSource = Nothing
        End If

    End Sub

    Private Sub btnViewRecords_Click(sender As Object, e As EventArgs) Handles btnViewRecords.Click
        loadrecords()
    End Sub

    Private Sub dgvOverview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOverview.CellContentClick
        'dgvOverview.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 14, FontStyle.Bold)
    End Sub
End Class