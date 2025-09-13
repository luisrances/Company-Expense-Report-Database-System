Imports MySql.Data.MySqlClient
Public Class M_authorization
    Dim cmd As New MySqlCommand
    Dim sql, x As String
    Dim exp_date As Date
    Dim con As New MySqlConnection("server=localhost; user=root; password=; database=company_expense_db;")
    Dim emp_id As String

    Public Sub New(ByVal employeeID As String)
        InitializeComponent()
        emp_id = employeeID
    End Sub

    'SessionTimeout
    Private sessionManager As SessionManager
    Private Sub M_authorization(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sessionManager.StopSession()
    End Sub
    'sessiontimeout
    Private Sub M_authorization_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SessionTimeout to be load
        sessionManager = New SessionManager(Me, New main_login(), 60)

        dtpAuthorization.Value = DateTime.Now
        'for signature combobox
        con.Open()
        Dim dt As New DataTable
        Dim sql As String = "SELECT * FROM employees WHERE employee_id = 0 or employee_id = '" & emp_id & "';"
        Dim da As New MySqlDataAdapter(sql, con)
        da.Fill(dt)
        ccb_sign.DataSource = dt
        ccb_sign.DisplayMember = "name"
        ccb_sign.ValueMember = "employee_id"
        con.Close()

        dtpAuthorization.Value = DateTime.Now
        txtEmpID.Text = emp_id
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveAuthorization()
    End Sub

    Private Sub SaveAuthorization()
        'audit trail
        Dim esDate_holder As String
        Dim table_name As String = "authorization"
        Dim id As String = txtOverviewID.Text
        sql = $"SELECT es_date FROM authorization WHERE authorization_id = {id};"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = sql
        Dim esDate As Object = cmd.ExecuteScalar()
        con.Close()
        If esDate IsNot Nothing Then
            esDate_holder = esDate.ToString()
        End If
        Dim oldValue As String = audit_trail.GetOldValue(table_name, "authorization_id", id)
        Dim newValue As String = "emp_id : " & ccb_sign.SelectedValue &
                                ", es_date : " & esDate_holder &
                                ", ab_date : " & dtpAuthorization.Value.ToString("yyyy-MM-dd")
        Dim currentDateTimeString As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        audit_trail.audit("0", table_name, id, "UPDATE", oldValue, newValue, main_login.email, currentDateTimeString)
        'end audit
        Try
            con.Open()

            Dim query As String = "update authorization set EMP_ID = '" & ccb_sign.SelectedValue & "',ab_DATE = '" & dtpAuthorization.Value.ToString("yyyy-MM-dd") & "' where authorization_id = " & txtOverviewID.Text & ";"
            Dim employeeID As Integer

            If Integer.TryParse(ccb_sign.SelectedValue, employeeID) Then
                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("EMP_ID", employeeID)
                    cmd.Parameters.AddWithValue("AB_DATE", dtpAuthorization.Value.ToString("yyyy-MM-dd"))
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Authorization saved successfully!")
            Else
                MsgBox("Invalid EMP_ID. Please enter a valid numeric value.")
            End If

        Catch ex As Exception
            MsgBox("Error saving authorization: " & ex.Message)
        Finally
            con.Close()
        End Try
        LoadAuthorizationData()
    End Sub

    Private Sub btnViewRecords_Click(sender As Object, e As EventArgs) Handles btnViewRecords.Click
        LoadAuthorizationData()
    End Sub

    Private Sub btnBackToMenu_Click(sender As Object, e As EventArgs) Handles btnBackToMenu.Click
        Manager.Show()
        Me.Hide()
    End Sub

    Private Sub LoadAuthorizationData()
        Try
            con.Open()
            Dim DA As New MySqlDataAdapter("SELECT * FROM v_authorization;", con)
            Dim DT As New DataTable
            DA.Fill(DT)

            dgvauthorization.DataSource = DT
        Catch ex As Exception
            MessageBox.Show("Error loading authorization data: " & ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub dgvauthorization_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvauthorization.CellClick
        Dim selrow As DataGridViewRow
        selrow = dgvauthorization.Rows(e.RowIndex)
        txtOverviewID.Text = selrow.Cells(0).Value
        dtpAuthorization.Value = CType(selrow.Cells(4).Value, DateTime)
        'need ng exception
    End Sub
End Class