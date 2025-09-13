Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class E_expense
    Dim con As New MySqlConnection("server=localhost; user=root; password=; database=company_expense_db; convert zero datetime = true")
    Dim da As New MySqlDataAdapter
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable

    Dim sql, all As String
    Dim to_add, to_edit, to_delete, to_search As Boolean
    Dim from_date, to_date As Date

    Dim emp_id, emp_name As String
    Dim submitted As Boolean
    Public Sub New(ByVal employeeID As String, empname As String)
        InitializeComponent()
        emp_id = employeeID
        emp_name = empname
    End Sub

    Sub populate_emp_info()
        'emp id
        txtEmployeeID.Text = emp_id
        'emp name
        txtName.Text = emp_name
        'new overview id
        Try
            con.Open()
            sql = "SELECT IFNULL(MAX(OVERVIEW_ID), 0) + 1 AS maxno FROM overview"
            cmd.Connection = con
            cmd.CommandText = sql
            Dim result = cmd.ExecuteScalar()
            If result IsNot DBNull.Value Then
                txtOverviewID.Text = Convert.ToString(result)
            Else
                txtOverviewID.Text = "1"
            End If
        Catch ex As Exception
            MsgBox("sa info")
        End Try
        con.Close()
        'new expense id
        Dim lastrec As Integer = 1
        con.Open()
        Try
            With cmd
                .Connection = con
                .CommandText = "SELECT IFNULL(MAX(EXP_ID), 0) + 1 AS maxno FROM expense"
                Dim result = .ExecuteScalar
                If result IsNot DBNull.Value Then
                    lastrec = CInt(result)
                End If
            End With
        Catch ex As Exception
        Finally
            con.Close()
        End Try
        ComboBox3.Text = lastrec
    End Sub

    Sub create_overview()
        con.Open()
        sql = "insert into overview values('" & txtOverviewID.Text & "','1','1','" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "','" & DateTimePicker2.Value.ToString("yyyy-MM-dd") &
            "','1','1','1');"
        cmd.Connection = con
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Sub create_authorization()
        con.Open()
        sql = "insert into authorization values('" & txtOverviewID.Text & "','1','" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "','" & DateTimePicker2.Value.ToString("yyyy-MM-dd") &
            "');"
        cmd.Connection = con
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'SessionTimeout
    Private sessionManager As SessionManager
    Private Sub E_expense(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sessionManager.StopSession()
    End Sub
    'sessiontimeout

    Private Sub E_expense(sender As Object, e As EventArgs) Handles MyBase.Load
        'SessionTimeout to be load
        sessionManager = New SessionManager(Me, New main_login(), 60)

        combobox1.Text = Nothing
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
        DateTimePicker2.Value = DateTime.Now
        populate_emp_info()
        create_overview()
        create_authorization()
        all = "SELECT * from v_expense where overview_id =" & txtOverviewID.Text & ";"
        'all = "SELECT * from v_expense;"
        LoadRecords(all, DataGridView1)
        crudFalse()
        btnFalse_SC()
        textFalse()
    End Sub

    Public Sub LoadRecords(command As String, dgv As DataGridView)
        dt = New DataTable
        dt.Clear()
        Try
            con.Open()
            da = New MySqlDataAdapter(command, con)
            da.Fill(dt)
            dgv.DataSource = dt
        Catch ex As Exception
        End Try
        con.Close()

        'for purpose_id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from purpose", con)
        da.Fill(dt)
        combobox1.DataSource = dt
        combobox1.DisplayMember = "purpose_description"
        combobox1.ValueMember = "purpose_id"
        con.Close()
        'for exp_type_id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from expense_type", con)
        da.Fill(dt)
        combobox2.DataSource = dt
        combobox2.DisplayMember = "exp_type_name"
        combobox2.ValueMember = "exp_type_id"
        combobox2.Text = Nothing
        con.Close()
        'for exp_id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from expense where overview_id =" & txtOverviewID.Text & ";", con)
        da.Fill(dt)
        ComboBox3.DataSource = dt
        ComboBox3.DisplayMember = "exp_id"
        ComboBox3.ValueMember = "exp_id"
        ComboBox3.Text = Nothing
        con.Close()

        combobox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim exp_date As Date
        Dim index As Integer
        index = e.RowIndex
        Dim row As DataGridViewRow
        row = DataGridView1.Rows(index)
        If to_add = False Then
            ComboBox1.Text = row.Cells(0).Value.ToString()
        End If
        Dim Selrow As DataGridViewRow
        Selrow = DataGridView1.Rows(e.RowIndex)
        'cbbPurpose.Text = Selrow.Cells(1).Value.ToString()
        combobox2.Text = Selrow.Cells(1).Value
        textbox2.Text = Selrow.Cells(2).Value
        exp_date = row.Cells(3).Value.ToString
        DateTimePicker1.Value = exp_date.ToShortDateString
        'DateTimePicker1.Text = Selrow.Cells(3).Value.ToString("yyyy-MM-dd")
        textbox3.Text = Selrow.Cells(4).Value

        ComboBox3.Text = Selrow.Cells(0).Value.ToString()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        to_add = True
        textTrue()
        textNull()
        btnTrue_SC()
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDown

        'new expense id
        Dim lastrec As Integer = 1
        con.Open()
        Try
            With cmd
                .Connection = con
                .CommandText = "SELECT IFNULL(MAX(EXP_ID), 0) + 1 AS maxno FROM expense"
                Dim result = .ExecuteScalar
                If result IsNot DBNull.Value Then
                    lastrec = CInt(result)
                End If
            End With
        Catch ex As Exception
        Finally
            con.Close()
        End Try
        ComboBox3.Text = lastrec

        'Dim row As DataGridViewRow
        'row = DataGridView1.Rows(DataGridView1.Rows.Count - 1)
        'ComboBox3.Text = row.Cells(0).Value.ToString + 1
        'ComboBox3.Enabled = False
        current_process()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        to_edit = True
        textTrue()
        'textNull()
        btnTrue_SC()
        current_process()
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        to_delete = True
        textFalse()
        'textNull()
        btnTrue_SC()
        textbox1.Enabled = True
        combobox1.Enabled = True
        current_process()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        to_search = True
        textFalse()
        textNull()
        btnTrue_SC()
        txtSearch.Enabled = True
        current_process()
    End Sub

    Sub crudFalse()
        to_add = False
        to_edit = False
        to_delete = False
        to_search = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        crudFalse()
        textFalse()
        textNull()
        btnFalse_SC()
        combobox1.DropDownStyle = ComboBoxStyle.DropDownList
        current_process()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        'audit trail
        Dim table_name As String = "expense"
        Dim id As String = ComboBox3.Text
        Dim oldValue As String = audit_trail.GetOldValue(table_name, "exp_id", id)
        Dim newValue As String = "exp_type_id : " & combobox2.SelectedValue &
                                ", exp_description : " & textbox2.Text &
                                ", exp_date : " & DateTimePicker1.Value.ToString("yyyy-MM-dd") &
                                ", exp_amount : " & textbox3.Text
        Dim currentDateTimeString As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        If to_add Then
            audit_trail.audit("0", table_name, id, "INSERT", "", "", main_login.email, currentDateTimeString)
        ElseIf to_edit Then
            audit_trail.audit("0", table_name, id, "UPDATE", oldValue, newValue, main_login.email, currentDateTimeString)
        ElseIf to_delete Then
            audit_trail.audit("0", table_name, id, "DELETE", "", "", main_login.email, currentDateTimeString)
        End If
        'end audit

        If to_add Then
            Try
                ''If ComboBox5.Text.Length = 0 Or TextBox7.TextLength = 0 Or combobox1.Text.Length = 0 Or ComboBox4.Text.Length = 0 Or combobox2.Text.Length = 0 Or ComboBox3.Text.Length = 0 Then
                ''    Throw New Exception
                ''End If
                con.Open()
                sql = "insert into expense values(" & ComboBox3.Text & ",'" & combobox2.SelectedValue & "','" & textbox2.Text &
                "','" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "','" & textbox3.Text & "','" & txtOverviewID.Text & "');"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                con.Close()
                LoadRecords(all, DataGridView1)
            Catch ex As Exception
                con.Close()
                'MessageBox.Show("A required field was empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf to_edit Then
            Try
                'If ComboBox5.Text.Length = 0 Or TextBox7.TextLength = 0 Or combobox1.Text.Length = 0 Or ComboBox4.Text.Length = 0 Or combobox2.Text.Length = 0 Or ComboBox3.Text.Length = 0 Then
                '    Throw New Exception
                'End If
                con.Open()
                sql = "UPDATE expense SET exp_type_id = '" & combobox2.SelectedValue &
                    "', exp_description = '" & textbox2.Text &
                    "', exp_date = '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") &
                    "', exp_amount = '" & textbox3.Text &
                    "' WHERE exp_id = " & ComboBox3.Text & ";"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                con.Close()
                LoadRecords(all, DataGridView1)
            Catch ex As Exception
                con.Close()
                MessageBox.Show("A required field was empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf to_delete Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete it", "", MessageBoxButtons.OKCancel)
            If result = DialogResult.OK Then
                ' Do something when OK is clicked
                Try
                    'If ComboBox5.Text.Length = 0 Or TextBox7.TextLength = 0 Or combobox1.Text.Length = 0 Or ComboBox4.Text.Length = 0 Or combobox2.Text.Length = 0 Or ComboBox3.Text.Length = 0 Then
                    '    Throw New Exception
                    'End If
                    con.Open()
                    sql = "delete from expense where exp_id = " & ComboBox3.Text & ";"
                    cmd.Connection = con
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                    con.Close()
                    LoadRecords(all, DataGridView1)
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show("A required field was empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf result = DialogResult.Cancel Then
                ' Do something when Cancel is clicked
            End If


        ElseIf to_search Then
            Try
                If txtSearch.Text.Length = 0 Then
                    Throw New Exception
                End If
                con.Open()
                sql = "SELECT * FROM v_expense WHERE overview_id = " & txtOverviewID.Text & " and ( exp_id LIKE '%" & txtSearch.Text &
                    "%' OR exp_type_name LIKE '%" & txtSearch.Text &
                    "%' OR exp_description LIKE '%" & txtSearch.Text &
                    "%' OR exp_date LIKE '%" & txtSearch.Text &
                    "%' OR exp_amount LIKE '%" & txtSearch.Text & "%');"
                cmd.Connection = con
                cmd.CommandText = sql
                'cmd = New OleDbCommand(sql, con)
                da = New MySqlDataAdapter(cmd)
                dt = New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
                con.Close()
            Catch ex As Exception
                con.Close()
                MessageBox.Show("A required field was empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

        crudFalse()
        textFalse()
        textNull()
        btnFalse_SC()
        current_process()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        If submitted = False Then
            con.Open()
            sql = "delete from overview where overview_id = " & txtOverviewID.Text & ";"
            cmd.Connection = con
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            con.Close()

            con.Open()
            sql = "delete from authorization where authorization_id = " & txtOverviewID.Text & ";"
            cmd.Connection = con
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            con.Close()
        End If
        Me.Hide()
        Employee.Show()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If combobox1.SelectedItem Is Nothing Then
            MsgBox("Please select a purpose.")
            Return
        End If

        Dim fdate, tdate, tamount, dept_id As String
        Dim dateObj As DateTime
        submitted = True

        'get fdate
        'con.Open()
        'sql = "SELECT MIN(exp_date) FROM expense WHERE overview_id = " & txtOverviewID.Text & ";"
        'dt = New DataTable
        'da = New MySqlDataAdapter(sql, con)
        'da.Fill(dt)
        'fdate = dt(0)(0).ToString
        'dateObj = DateTime.Parse(fdate)
        'fdate = dateObj.ToString("yyyy-MM-dd")
        'con.Close()
        sql = $"SELECT MIN(exp_date) FROM expense WHERE overview_id = {txtOverviewID.Text};"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = sql
        Dim fd As Object = cmd.ExecuteScalar()
        If fd IsNot Nothing Then
            fdate = Convert.ToDateTime(fd).ToString("yyyy-MM-dd")
        End If
        MessageBox.Show(fdate)
        con.Close()

        'get tdate
        'con.Open()
        'sql = "SELECT MAX(exp_date) FROM expense WHERE overview_id = " & txtOverviewID.Text & ";"
        'dt = New DataTable
        'da = New MySqlDataAdapter(sql, con)
        'da.Fill(dt)
        'dt = New DataTable
        'da = New MySqlDataAdapter(sql, con)
        'da.Fill(dt)
        'tdate = dt(0)(0).ToString
        'dateObj = DateTime.Parse(tdate)
        'tdate = dateObj.ToString("yyyy-MM-dd")
        'con.Close()
        sql = $"SELECT MAX(exp_date) FROM expense WHERE overview_id = {txtOverviewID.Text};"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = sql
        Dim td As Object = cmd.ExecuteScalar()
        If td IsNot Nothing Then
            tdate = Convert.ToDateTime(td).ToString("yyyy-MM-dd")
        End If
        con.Close()
        MessageBox.Show(tdate)

        'get tamount
        con.Open()
        sql = "SELECT SUM(exp_amount) FROM expense WHERE overview_id = " & txtOverviewID.Text & ";"
        cmd.Connection = con
        cmd.CommandText = sql
        tamount = cmd.ExecuteScalar.ToString
        con.Close()
        'get dept_id
        con.Open()
        sql = "SELECT department_id FROM employees WHERE employee_id = " & txtEmployeeID.Text & ";"
        cmd.Connection = con
        cmd.CommandText = sql
        dept_id = cmd.ExecuteScalar.ToString
        con.Close()
        'save overview
        con.Open()
        sql = "UPDATE overview SET emp_id = '" & txtEmployeeID.Text &
            "', purpose_id = '" & combobox1.SelectedValue &
            "', from_date = '" & fdate &
            "', to_date = '" & tdate &
            "', total_amount = '" & tamount &
            "', authorization_id = '" & txtOverviewID.Text &
            "', dept_id = '" & dept_id &
            "' WHERE overview_id = " & txtOverviewID.Text & ";"
        cmd.Connection = con
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Successfully submitted!")
        LoadRecords(all, DataGridView1)
    End Sub

    Sub btnTrue_SC()
        btnsave.Enabled = True
        btncancel.Enabled = True
        btnadd.Enabled = False
        btnupdate.Enabled = False
        btndelete.Enabled = False
        btnsearch.Enabled = False
    End Sub

    Private Sub btnLoadRecord_Click(sender As Object, e As EventArgs) Handles btnLoadRecord.Click
        LoadRecords(all, DataGridView1)
    End Sub

    Sub btnFalse_SC()
        btnSave.Enabled = False
        btnCancel.Enabled = False
        btnAdd.Enabled = True
        btnupdate.Enabled = True
        btndelete.Enabled = True
        btnsearch.Enabled = True
    End Sub

    Sub textFalse()
        textbox1.Enabled = False
        textbox2.Enabled = False
        textbox3.Enabled = False
        txtSearch.Enabled = False
        DateTimePicker1.Enabled = False
        combobox2.Enabled = False
    End Sub

    Sub textTrue()
        textbox1.Enabled = True
        textbox2.Enabled = True
        textbox3.Enabled = True
        txtSearch.Enabled = True
        DateTimePicker1.Enabled = True
        combobox2.Enabled = True
    End Sub
    Sub textNull()
        textbox1.Text = ""
        textbox2.Text = ""
        textbox3.Text = ""
        txtSearch.Text = ""
        combobox2.Text = Nothing
    End Sub

    Sub current_process()
        If to_add Then
            btnadd.BackColor = Color.FromArgb(48, 93, 160)
        ElseIf to_edit Then
            btnupdate.BackColor = Color.FromArgb(48, 93, 160)
        ElseIf to_delete Then
            btndelete.BackColor = Color.FromArgb(48, 93, 160)
        ElseIf to_search Then
            btnsearch.BackColor = Color.FromArgb(48, 93, 160)
        Else
            btnadd.BackColor = Color.FromName("control")
            btnupdate.BackColor = Color.FromName("control")
            btndelete.BackColor = Color.FromName("control")
            btnsearch.BackColor = Color.FromName("control")
        End If
    End Sub
End Class