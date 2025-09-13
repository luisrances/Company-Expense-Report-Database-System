Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms
Public Class report
    Dim con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & Application.StartupPath & "\ms1.mdb")
    Dim da As New OleDbDataAdapter
    Dim cmd As New OleDbCommand
    Dim sql As String
    Dim e_name, eid, department, manager, pos, purpose, p_from, p_to, total, e_sign, authorized_by, es_date, ab_date As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim ov As New M_overview(Nothing)
        ov.Show()
    End Sub

    'SessionTimeout
    Private sessionManager As SessionManager
    Private Sub report(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sessionManager.StopSession()
    End Sub
    'sessiontimeout

    Dim dt As New DataTable
    Private Sub report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SessionTimeout to be load
        sessionManager = New SessionManager(Me, New main_login(), 30)

        'TODO: This line of code loads data into the 'Ms1DataSet.v_expense' table. You can move, or remove it, as needed.
        Me.V_expenseTableAdapter.Fill(Me.Ms1DataSet.v_expense)
        'TODO: This line of code loads data into the 'Ms1DataSet.v_expense1' table. You can move, or remove it, as needed.
        Me.V_expense1TableAdapter.Fillcombo(Me.Ms1DataSet.v_expense1)
        ComboBox1.Text = "Select overview ID"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        printLayout()
        getData()
        setValue()

        Try
            Me.V_expenseTableAdapter.Filloverview(Me.Ms1DataSet.v_expense, ComboBox1.Text)
        Catch ex As Exception

        End Try
        Me.ReportViewer1.RefreshReport()
    End Sub

    Sub printLayout()
        ' for page margin when printing
        Dim pg As New System.Drawing.Printing.PageSettings()
        Dim margins As New System.Drawing.Printing.Margins(0, 0, 50, 50)
        pg.Margins = margins
        ReportViewer1.SetPageSettings(pg)
        'print layout
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent
        Me.ReportViewer1.ZoomPercent = 100
    End Sub

    Public Sub getData()
        Try
            con.Open()
            sql = "SELECT * FROM v_overview_report WHERE overview_id = " & ComboBox1.Text & ";"
            cmd.Connection = con
            cmd.CommandText = sql
            cmd = New OleDbCommand(sql, con)
            da = New OleDbDataAdapter(cmd)
            dt = New DataTable()
            da.Fill(dt)
            e_name = dt.Rows(0)(1).ToString
            eid = dt.Rows(0)(2).ToString
            department = dt.Rows(0)(8).ToString
            manager = dt.Rows(0)(10).ToString
            pos = dt.Rows(0)(15).ToString
            purpose = dt.Rows(0)(3).ToString
            p_from = dt.Rows(0)(4).ToString
            'convert to shortdate
            Dim DateValue As DateTime
            DateTime.TryParse(p_from, DateValue)
            p_from = DateValue.ToString("MM/dd/yyyy")
            p_to = dt.Rows(0)(5).ToString
            DateTime.TryParse(p_to, DateValue)
            p_to = DateValue.ToString("MM/dd/yyyy")
            total = dt.Rows(0)(6).ToString
            e_sign = dt.Rows(0)(1).ToString
            authorized_by = dt.Rows(0)(13).ToString
            es_date = dt.Rows(0)(11).ToString
            DateTime.TryParse(es_date, DateValue)
            es_date = DateValue.ToString("MM/dd/yyyy")
            ab_date = dt.Rows(0)(12).ToString
            DateTime.TryParse(ab_date, DateValue)
            ab_date = DateValue.ToString("MM/dd/yyyy")
        Catch ex As Exception

        End Try
        con.Close()
    End Sub

    Public Sub setValue()
        'setting values
        Dim rp As New ReportParameterCollection
        rp.Add(New ReportParameter("txt1", e_name))
        rp.Add(New ReportParameter("txt2", eid))
        rp.Add(New ReportParameter("txt3", department))
        rp.Add(New ReportParameter("txt4", manager))
        rp.Add(New ReportParameter("txt5", pos))
        rp.Add(New ReportParameter("txt6", purpose))
        rp.Add(New ReportParameter("txt7", p_from))
        rp.Add(New ReportParameter("txt8", p_to))
        rp.Add(New ReportParameter("txt9", total))
        rp.Add(New ReportParameter("txt10", e_sign))
        rp.Add(New ReportParameter("txt11", authorized_by))
        rp.Add(New ReportParameter("txt12", es_date))
        rp.Add(New ReportParameter("txt13", ab_date))
        ReportViewer1.LocalReport.SetParameters(rp)
    End Sub
End Class