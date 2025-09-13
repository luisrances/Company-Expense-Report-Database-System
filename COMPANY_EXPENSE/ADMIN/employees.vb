Imports MySql.Data.MySqlClient

Public Class employees
    Dim con As New MySqlConnection("server=localhost; user=root; password=; database=company_expense_db;")
    Dim da As New MySqlDataAdapter
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable

    Dim sql, all As String
    Dim to_add, to_edit, to_delete, to_search As Boolean
    'Dim cmd As New MySqlCommand
    'Dim da As New MySqlDataAdapter
    Private Sub employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        all = "SELECT * from v_employees order by employee_id"
        LoadRecords(all, DataGridView1)
        crudFalse()
        btnFalse_SC()
        textFalse()

        'for sex combobox
        ComboBox4.Items.Add("Male")
        ComboBox4.Items.Add("Female")
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

        'for employee_id combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from employees", con)
        da.Fill(dt)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "employee_id"
        ComboBox1.ValueMember = "employee_id"
        ComboBox1.Text = Nothing
        con.Close()
        'for department combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from department", con)
        da.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "dept_name"
        ComboBox2.ValueMember = "dept_id"
        ComboBox2.Text = Nothing
        con.Close()
        'for postition combobox
        con.Open()
        dt = New DataTable
        da = New MySqlDataAdapter("select * from position", con)
        da.Fill(dt)
        ComboBox3.DataSource = dt
        ComboBox3.DisplayMember = "pos_name"
        ComboBox3.ValueMember = "pos_id"
        ComboBox3.Text = Nothing
        con.Close()
        ComboBox4.Text = Nothing
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox4.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim row As DataGridViewRow
        row = DataGridView1.Rows(index)
        If to_add = False Then
            ComboBox1.Text = row.Cells(0).Value.ToString()
        End If
        txtEID.Text = row.Cells(0).Value.ToString()
        txtNAME.Text = row.Cells(1).Value.ToString()
        ComboBox2.Text = row.Cells(2).Value.ToString()
        txtDEPT.Text = row.Cells(2).Value.ToString()
        ComboBox3.Text = row.Cells(3).Value.ToString()
        txtPOSITION.Text = row.Cells(3).Value.ToString()
        txtCONTACT.Text = row.Cells(4).Value.ToString()
        ComboBox4.Text = row.Cells(5).Value.ToString()
        txtSEX.Text = row.Cells(5).Value.ToString()
        txtEMAIL.Text = row.Cells(6).Value.ToString()
        txtADDRESS.Text = row.Cells(7).Value.ToString()
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
        txtEID.Enabled = True
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
        Dim table_name As String = "employees"
        Dim id As String = ComboBox1.Text
        Dim oldValue As String = audit_trail.GetOldValue(table_name, "Employee_ID", id)
        Dim newValue As String = "Name : " & txtNAME.Text &
                                ", Department_ID : " & ComboBox2.SelectedValue &
                                ", Position_ID : " & ComboBox3.SelectedValue &
                                ", EMP_CONTACT : " & txtCONTACT.Text &
                                ", EMP_SEX : " & ComboBox4.Text &
                                ", EMP_EMAIL : " & txtEMAIL.Text &
                                ", EMP_ADDRESS : " & txtADDRESS.Text
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
                If txtNAME.TextLength = 0 Or txtCONTACT.TextLength = 0 Or txtEMAIL.TextLength = 0 Or txtADDRESS.TextLength = 0 Then
                    Throw New Exception
                End If
                con.Open()
                sql = "insert into employees values('" & ComboBox1.Text & "','" & txtNAME.Text &
                    "','" & ComboBox2.SelectedValue & "','" & ComboBox3.SelectedValue & "','" & txtCONTACT.Text &
                    "','" & ComboBox4.Text & "','" & txtEMAIL.Text & "','" & txtADDRESS.Text & "');"
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
                If txtNAME.TextLength = 0 Or txtCONTACT.TextLength = 0 Or txtEMAIL.TextLength = 0 Or txtADDRESS.TextLength = 0 Then
                    Throw New Exception
                End If
                con.Open()
                sql = "UPDATE employees SET Name = '" & txtNAME.Text &
                                "', Department_ID = '" & ComboBox2.SelectedValue &
                                "', Position_ID = '" & ComboBox3.SelectedValue &
                                "', EMP_CONTACT = '" & txtCONTACT.Text &
                                "', EMP_SEX = '" & ComboBox4.Text &
                                "', EMP_EMAIL = '" & txtEMAIL.Text &
                                "', EMP_ADDRESS = '" & txtADDRESS.Text &
                                "' WHERE Employee_ID = " & ComboBox1.Text & ";"
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
                    sql = "delete from employees where employee_id = " & ComboBox1.Text & ";"
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
                sql = "SELECT * FROM v_employees WHERE employee_id LIKE '%" & txtSearch.Text &
                    "%' OR name LIKE '%" & txtSearch.Text &
                    "%' OR dept_name LIKE '%" & txtSearch.Text &
                    "%' OR pos_name LIKE '%" & txtSearch.Text &
                    "%' OR emp_contact LIKE '%" & txtSearch.Text &
                    "%' OR emp_sex LIKE '%" & txtSearch.Text &
                    "%' OR emp_email LIKE '%" & txtSearch.Text &
                    "%' OR emp_address LIKE '%" & txtSearch.Text & "%';"
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
        txtEID.Enabled = False
        txtNAME.Enabled = False
        txtDEPT.Enabled = False
        txtPOSITION.Enabled = False
        txtCONTACT.Enabled = False
        txtSEX.Enabled = False
        txtEMAIL.Enabled = False
        txtADDRESS.Enabled = False
        txtSearch.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
    End Sub

    Sub textTrue()
        txtEID.Enabled = True
        txtNAME.Enabled = True
        txtDEPT.Enabled = True
        txtPOSITION.Enabled = True
        txtCONTACT.Enabled = True
        txtSEX.Enabled = True
        txtEMAIL.Enabled = True
        txtADDRESS.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
    End Sub
    Sub textNull()
        txtEID.Text = ""
        txtNAME.Text = ""
        txtDEPT.Text = ""
        txtPOSITION.Text = ""
        txtCONTACT.Text = ""
        txtSEX.Text = ""
        txtEMAIL.Text = ""
        txtADDRESS.Text = ""
        txtSearch.Text = ""
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
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