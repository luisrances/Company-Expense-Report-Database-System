Imports MySql.Data.MySqlClient
Imports System.Text
Public Class audit_trail
    Dim con As New MySqlConnection("server=localhost; user=root; password=; database=company_expense_db;")
    Dim da As New MySqlDataAdapter
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable

    Dim sql, all As String
    Dim to_add, to_edit, to_delete, to_search As Boolean
    'Dim cmd As New MySqlCommand
    'Dim da As New MySqlDataAdapter
    Private Sub audit_trail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        all = "SELECT * FROM audit_trail"
        LoadRecords(all, DataGridView1)
        crudFalse()
        btnFalse_SC()
        textFalse()

        'for sex combobox
        'ComboBox4.Items.Add("Male")
        'ComboBox4.Items.Add("Female")
    End Sub

    Public Sub LoadRecords(command As String, dgv As DataGridView)
        dt = New DataTable
        dt.Clear()
        Try
            con.Open()
            da = New MySqlDataAdapter(command, con)
            con.Close()
            da.Fill(dt)
            dgv.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'for id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from audit_trail", con)
        da.Fill(dt)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "id"
        ComboBox1.ValueMember = "id"
        ComboBox1.Text = Nothing
        con.Close()
        'for table name combobox
        con.Open()
        dt = New DataTable
        Dim query As String = "SELECT 'accounts' AS table_name UNION " &
                      "SELECT 'audit_trail' UNION " &
                      "SELECT 'authorization' UNION " &
                      "SELECT 'department' UNION " &
                      "SELECT 'employees' UNION " &
                      "SELECT 'expense' UNION " &
                      "SELECT 'expense_type' UNION " &
                      "SELECT 'overview' UNION " &
                      "SELECT 'position' UNION " &
                      "SELECT 'purpose'"
        da = New MySqlDataAdapter(query, con)
        da.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "table_name"
        ComboBox2.ValueMember = "table_name"
        ComboBox2.Text = Nothing
        con.Close()
        'for operation combobox
        ComboBox4.Items.Add("INSERT")
        ComboBox4.Items.Add("UPDATE")
        ComboBox4.Items.Add("DELETE")
        ComboBox4.Text = Nothing
        'for change by combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from accounts", con)
        da.Fill(dt)
        ComboBox5.DataSource = dt
        ComboBox5.DisplayMember = "email"
        ComboBox5.ValueMember = "ID"
        ComboBox5.Text = Nothing
        con.Close()
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox4.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox5.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox2.SelectionChangeCommitted
        Dim tableName As String = ComboBox2.Text
        Dim idColumnName As String = ""
        Dim idColumnID As String = ""
        If tableName = "accounts" Then
            idColumnName = "email"
            idColumnID = "ID"
        ElseIf tableName = "employees" Then
            idColumnID = "EMPLOYEE_ID"
            idColumnName = "name"
        ElseIf tableName = "department" Then
            idColumnName = "DEPT_NAME"
            idColumnID = "DEPT_ID"
        ElseIf tableName = "position" Then
            idColumnName = "POS_NAME"
            idColumnID = "POS_ID"
        ElseIf tableName = "expense" Then
            idColumnName = "EXP_DESCRIPTION"
            idColumnID = "EXP_ID"
        ElseIf tableName = "expense_type" Then
            idColumnName = "EXP_TYPE_NAME"
            idColumnID = "EXP_TYPE_ID"
        ElseIf tableName = "purpose" Then
            idColumnName = "PURPOSE_DESCRIPTION"
            idColumnID = "PURPOSE_ID"
        ElseIf tableName = "authorization" Then
            idColumnName = "AUTHORIZATION_ID"
            idColumnID = "AUTHORIZATION_ID"
        ElseIf tableName = "overview" Then
            idColumnName = "OVERVIEW_ID"
            idColumnID = "OVERVIEW_ID"
        ElseIf tableName = "audit_trail" Then
            idColumnName = "id"
            idColumnID = "id"
        End If
        'for record id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from " & tableName, con)
        da.Fill(dt)
        ComboBox3.DataSource = dt
        ComboBox3.DisplayMember = idColumnName
        ComboBox3.ValueMember = idColumnID
        ComboBox3.Text = Nothing
        con.Close()
    End Sub
    Private Sub ComboBox4_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox4.SelectionChangeCommitted
        If ComboBox4.Text = "UPDATE" Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
        Else
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim row As DataGridViewRow
        row = DataGridView1.Rows(index)
        If to_add = False Then
            ComboBox1.Text = row.Cells(0).Value.ToString()
        End If
        ComboBox1.Text = row.Cells(0).Value.ToString()
        ComboBox2.Text = row.Cells(1).Value.ToString()
        ComboBox3.Text = row.Cells(2).Value.ToString()
        ComboBox4.Text = row.Cells(3).Value.ToString()
        TextBox1.Text = row.Cells(4).Value.ToString()
        TextBox2.Text = row.Cells(5).Value.ToString()
        ComboBox5.Text = row.Cells(6).Value.ToString()
        DateTimePicker1.Value = row.Cells(7).Value
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        to_add = True
        textTrue()
        textNull()
        btnTrue_SC()
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDown
        Dim row As DataGridViewRow
        If DataGridView1.Rows.Count = 0 Then
            ComboBox1.Text = 1
        Else
            row = DataGridView1.Rows(DataGridView1.Rows.Count - 1)
            ComboBox1.Text = row.Cells(0).Value.ToString + 1
        End If

        ComboBox1.Enabled = False
        current_process()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        to_edit = True
        textTrue()
        btnTrue_SC()
        current_process()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        to_delete = True
        textFalse()
        btnTrue_SC()
        ComboBox1.Enabled = True
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
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        current_process()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If to_add Then
            Try
                If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox5.Text = "" Then
                    Throw New Exception
                End If
                con.Open()
                sql = "insert into audit_trail values('" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.SelectedIndex + 1 &
                    "','" & ComboBox4.Text & "','" & TextBox1.Text & "','" & TextBox2.Text &
                    "','" & ComboBox5.Text & "','" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "');"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                con.Close()
                LoadRecords(all, DataGridView1)
            Catch ex As Exception
                con.Close()
                MessageBox.Show("A required field was empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf to_edit Then
            Try
                If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox5.Text = "" Then
                    Throw New Exception
                End If
                con.Open()
                sql = "UPDATE audit_trail SET " &
                    "table_name = '" & ComboBox2.Text & "', " &
                    "record_id = '" & ComboBox3.SelectedIndex + 1 & "', " &
                    "operation = '" & ComboBox4.Text & "', " &
                    "old_values = '" & TextBox1.Text & "', " &
                    "new_values = '" & TextBox2.Text & "', " &
                    "changed_by = '" & ComboBox5.Text & "', " &
                    "changed_at = '" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' " &
                    "WHERE id = " & ComboBox1.Text & ";"
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
                    con.Open()
                    sql = "delete from audit_trail where id = " & ComboBox1.Text & ";"
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
                If txtSearch.TextLength = 0 Then
                    Throw New Exception
                End If
                con.Open()
                sql = "SELECT * FROM audit_trail WHERE " &
                  "id LIKE '%" & txtSearch.Text & "%' " &
                  "OR table_name LIKE '%" & txtSearch.Text & "%' " &
                  "OR operation LIKE '%" & txtSearch.Text & "%' " &
                  "OR old_values LIKE '%" & txtSearch.Text & "%' " &
                  "OR new_values LIKE '%" & txtSearch.Text & "%' " &
                  "OR changed_at LIKE '%" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "%' " &
                  "OR changed_by LIKE '%" & txtSearch.Text & "%';"
                cmd = New MySqlCommand(sql, con)
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
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        current_process()
    End Sub
    Sub btnTrue_SC()
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnRemove.Enabled = False
        btnSearch.Enabled = False
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadRecords(all, DataGridView1)
    End Sub

    Sub btnFalse_SC()
        btnSave.Enabled = False
        btnCancel.Enabled = False
        btnAdd.Enabled = True
        btnEdit.Enabled = True
        btnRemove.Enabled = True
        btnSearch.Enabled = True
    End Sub

    Sub textFalse()
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        DateTimePicker1.Enabled = False
        txtSearch.Enabled = False
    End Sub

    Sub textTrue()
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        'TextBox1.Enabled = True
        'TextBox2.Enabled = True
        DateTimePicker1.Enabled = True
    End Sub
    Sub textNull()
        txtSearch.Text = ""
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        dt = New DataTable
        ComboBox3.DataSource = dt
    End Sub
    Sub current_process()
        If to_add Then
            btnAdd.BackColor = Color.FromArgb(48, 93, 160)
        ElseIf to_edit Then
            btnEdit.BackColor = Color.FromArgb(48, 93, 160)
        ElseIf to_delete Then
            btnRemove.BackColor = Color.FromArgb(48, 93, 160)
        ElseIf to_search Then
            btnSearch.BackColor = Color.FromArgb(48, 93, 160)
        Else
            btnAdd.BackColor = Color.FromName("control")
            btnEdit.BackColor = Color.FromName("control")
            btnRemove.BackColor = Color.FromName("control")
            btnSearch.BackColor = Color.FromName("control")
        End If
    End Sub

    'for saving audit from other forms
    Public Sub audit(id As Integer, table_name As String, record_id As String, operation As String, old_values As String, new_values As String, changed_by As String, change_at As String)
        con.Open()
        sql = "insert into audit_trail values('" & id & "','" & table_name & "','" & record_id &
                    "','" & operation & "','" & old_values & "','" & new_values &
                    "','" & changed_by & "','" & change_at & "');"
        cmd.Connection = con
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    'end of saving audit

    Function GetOldValue(tableName As String, column_name As String, id As Integer) As String
        Dim result As New StringBuilder()
        con.Open()
        sql = $"SELECT * FROM {tableName} WHERE {column_name} = {id}"
        cmd.Connection = con
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()

        da = New MySqlDataAdapter(cmd)
        dt = New DataTable()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            For i As Integer = 1 To dt.Columns.Count - 1
                Dim columnName As String = dt.Columns(i).ColumnName.ToLower()
                Dim columnValue As String = row(i).ToString()
                result.AppendFormat("{0} : {1}", columnName, columnValue)
                If i < dt.Columns.Count - 1 Then
                    result.Append(", ")
                End If
            Next
        End If
        con.Close()
        Return result.ToString()
    End Function
End Class