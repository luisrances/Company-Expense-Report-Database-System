Imports MySql.Data.MySqlClient
Public Class department
    Dim con As New MySqlConnection("server=localhost; user=root; password=; database=company_expense_db;")
    Dim da As New MySqlDataAdapter
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable

    Dim sql, all As String
    Dim to_add, to_edit, to_delete, to_search As Boolean
    'Dim cmd As New MySqlCommand
    'Dim da As New MySqlDataAdapter
    Private Sub department_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        all = "SELECT * from department"
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
            con.Close()
            da.Fill(dt)
            dgv.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'for DEPT_ID combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from department", con)
        da.Fill(dt)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "DEPT_ID"
        ComboBox1.ValueMember = "DEPT_ID"
        ComboBox1.Text = Nothing
        con.Close()
        'for manager_id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from department", con)
        da.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "manager_id"
        ComboBox2.ValueMember = "manager_id"
        ComboBox2.Text = Nothing
        con.Close()
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim row As DataGridViewRow
        row = DataGridView1.Rows(index)
        If to_add = False Then
            ComboBox1.Text = row.Cells(0).Value.ToString()
        End If
        textbox1.Text = row.Cells(0).Value.ToString()
        textbox2.Text = row.Cells(1).Value.ToString()
        ComboBox2.Text = row.Cells(2).Value.ToString()
        textbox3.Text = row.Cells(2).Value.ToString()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        to_add = True
        textTrue()
        textNull()
        btnTrue_SC()
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDown
        'ComboBox1.Text = DataGridView1.Rows.Count + 1

        Dim row As DataGridViewRow
        row = DataGridView1.Rows(DataGridView1.Rows.Count - 1)
        ComboBox1.Text = row.Cells(0).Value.ToString + 1
        ComboBox1.Enabled = False
        current_process()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        to_edit = True
        textTrue()
        'textNull()
        btnTrue_SC()
        current_process()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        to_delete = True
        textFalse()
        'textNull()
        btnTrue_SC()
        textbox1.Enabled = True
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
        'audit trail
        Dim table_name As String = "department"
        Dim id As String = ComboBox1.Text
        Dim oldValue As String = audit_trail.GetOldValue(table_name, "DEPT_ID", id)
        Dim newValue As String = "DEPT_NAME : " & textbox2.Text &
                                ", manager_id : " & ComboBox2.SelectedValue
        Dim currentDateTimeString As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Count - 1)
        Dim record_id As Integer = row.Cells(0).Value.ToString + 1
        If to_add Then
            audit_trail.audit("0", table_name, record_id, "INSERT", "", "", main_login.email, currentDateTimeString)
        ElseIf to_edit Then
            audit_trail.audit("0", table_name, id, "UPDATE", oldValue, newValue, main_login.email, currentDateTimeString)
        ElseIf to_delete Then
            audit_trail.audit("0", table_name, id, "DELETE", "", "", main_login.email, currentDateTimeString)
        End If
        'end audit

        If to_add Then
            Try
                If textbox2.TextLength = 0 Then
                    Throw New Exception
                End If
                con.Open()
                sql = "insert into department values('" & ComboBox1.Text & "','" & textbox2.Text &
                    "','" & ComboBox2.SelectedValue & "');"
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
                If textbox2.TextLength = 0 Then
                    Throw New Exception
                End If
                con.Open()
                sql = "UPDATE department SET DEPT_NAME = '" & textbox2.Text &
                    "', manager_id = '" & ComboBox2.SelectedValue &
                    "' WHERE DEPT_ID = " & ComboBox1.Text & ";"
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
                    sql = "delete from department where DEPT_ID = " & ComboBox1.Text & ";"
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
                sql = "SELECT * FROM department WHERE DEPT_ID LIKE '%" & txtSearch.Text &
                    "%' OR DEPT_NAME LIKE '%" & txtSearch.Text &
                    "%' OR manager_id LIKE '%" & txtSearch.Text & "%';"
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
        textbox1.Enabled = False
        textbox2.Enabled = False
        textbox3.Enabled = False
        txtSearch.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
    End Sub
    Sub textTrue()
        textbox1.Enabled = True
        textbox2.Enabled = True
        textbox3.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
    End Sub
    Sub textNull()
        textbox1.Text = ""
        textbox2.Text = ""
        textbox3.Text = ""
        txtSearch.Text = ""
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
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
End Class