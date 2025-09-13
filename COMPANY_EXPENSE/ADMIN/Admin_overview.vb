Imports MySql.Data.MySqlClient
Public Class Admin_overview
    Dim con As New MySqlConnection("server=localhost; user=root; password=; database=company_expense_db; convert zero datetime = true")
    Dim da As New MySqlDataAdapter
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable

    Dim sql, all As String
    Dim to_add, to_edit, to_delete, to_search As Boolean
    Dim from_date, to_date As Date

    Private Sub overview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
        DateTimePicker2.Value = DateTime.Now

        all = "SELECT * from v_overview order by overview_id"
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
            MsgBox(ex.Message)
        End Try
        con.Close()

        'for overview_id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select overview_id from overview", con)
        da.Fill(dt)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "overview_id"
        ComboBox1.ValueMember = "overview_id"
        ComboBox1.Text = Nothing
        con.Close()
        'for purpose_id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from purpose", con)
        da.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "purpose_description"
        ComboBox2.ValueMember = "purpose_id"
        ComboBox2.Text = Nothing
        con.Close()
        'for dept_id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from department", con)
        da.Fill(dt)
        ComboBox3.DataSource = dt
        ComboBox3.DisplayMember = "dept_name"
        ComboBox3.ValueMember = "dept_id"
        ComboBox3.Text = Nothing
        con.Close()
        'for employee_id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from employees", con)
        da.Fill(dt)
        ComboBox4.DataSource = dt
        ComboBox4.DisplayMember = "employee_id"
        ComboBox4.ValueMember = "employee_id"
        ComboBox4.Text = Nothing
        con.Close()
        'for authorization_id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from authorization", con)
        da.Fill(dt)
        ComboBox5.DataSource = dt
        ComboBox5.DisplayMember = "authorization_id"
        ComboBox5.ValueMember = "authorization_id"
        ComboBox5.Text = Nothing
        con.Close()

        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox4.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox5.DropDownStyle = ComboBoxStyle.DropDownList
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
        ComboBox4.Text = row.Cells(1).Value.ToString()
        textbox2.Text = row.Cells(1).Value.ToString()
        ComboBox2.Text = row.Cells(2).Value.ToString()
        textbox3.Text = row.Cells(2).Value.ToString()
        from_date = row.Cells(3).Value.ToString
        TextBox4.Text = from_date.ToShortDateString
        DateTimePicker1.Value = row.Cells(3).Value
        TextBox4.Text = row.Cells(3).Value.ToString()
        to_date = row.Cells(4).Value.ToString
        TextBox5.Text = to_date.ToShortDateString
        DateTimePicker2.Value = row.Cells(4).Value
        TextBox5.Text = row.Cells(4).Value.ToString()
        TextBox6.Text = row.Cells(5).Value.ToString()
        TextBox7.Text = row.Cells(6).Value.ToString()
        ComboBox5.Text = row.Cells(6).Value.ToString()
        TextBox8.Text = row.Cells(7).Value.ToString()
        ComboBox3.Text = row.Cells(7).Value.ToString()
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
        Dim table_name As String = "overview"
        Dim id As String = ComboBox1.Text
        Dim oldValue As String = audit_trail.GetOldValue(table_name, "overview_id", id)
        Dim newValue As String = "emp_id : " & ComboBox2.SelectedValue &
                                ", purpose_id : " & ComboBox2.SelectedValue &
                                ", from_date : " & DateTimePicker1.Value.ToString("yyyy-MM-dd") &
                                ", to_date : " & DateTimePicker2.Value.ToString("yyyy-MM-dd") &
                                ", total_amount : " & TextBox6.Text &
                                ", authorization_id : " & ComboBox5.SelectedValue &
                                ", dept_id : " & ComboBox3.SelectedValue
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
                If ComboBox5.Text.Length = 0 Or TextBox7.TextLength = 0 Or ComboBox1.Text.Length = 0 Or ComboBox4.Text.Length = 0 Or ComboBox2.Text.Length = 0 Or ComboBox3.Text.Length = 0 Then
                    Throw New Exception
                End If
                con.Open()
                sql = "insert into overview values('" & ComboBox1.Text & "','" & ComboBox4.Text & "','" & ComboBox2.SelectedValue &
                "','" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "','" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "','" & TextBox6.Text &
                "','" & ComboBox5.SelectedValue & "','" & ComboBox3.SelectedValue & "');"
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
                If ComboBox5.Text.Length = 0 Or TextBox7.TextLength = 0 Or ComboBox1.Text.Length = 0 Or ComboBox4.Text.Length = 0 Or ComboBox2.Text.Length = 0 Or ComboBox3.Text.Length = 0 Then
                    Throw New Exception
                End If
                con.Open()
                sql = "UPDATE overview SET emp_id = '" & ComboBox4.Text &
                    "', purpose_id = '" & ComboBox2.SelectedValue &
                    "', from_date = '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") &
                    "', to_date = '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") &
                    "', total_amount = '" & TextBox6.Text &
                    "', authorization_id = '" & ComboBox5.SelectedValue &
                    "', dept_id = '" & ComboBox3.SelectedValue &
                    "' WHERE overview_id = " & ComboBox1.Text & ";"
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
                    sql = "delete from overview where overview_id = " & ComboBox1.Text & ";"
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
                sql = "SELECT * FROM overview WHERE overview_id LIKE '%" & txtSearch.Text &
                    "%' OR emp_id LIKE '%" & txtSearch.Text &
                    "%' OR purpose_id LIKE '%" & txtSearch.Text &
                    "%' OR from_date LIKE '%" & txtSearch.Text &
                    "%' OR to_date LIKE '%" & txtSearch.Text &
                    "%' OR total_amount LIKE '%" & txtSearch.Text &
                    "%' OR authorization_id LIKE '%" & txtSearch.Text &
                    "%' OR dept_id LIKE '%" & txtSearch.Text & "%';"
                cmd.Connection = con
                cmd.CommandText = sql
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
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        txtSearch.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
    End Sub

    Sub textTrue()
        textbox1.Enabled = True
        textbox2.Enabled = True
        textbox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
    End Sub
    Sub textNull()
        textbox1.Text = ""
        textbox2.Text = ""
        textbox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        txtSearch.Text = ""
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
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