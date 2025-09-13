Public Class sample_menu
    Dim myform As New Form

    'SessionTimeout
    Private sessionManager As SessionManager
    Private Sub sample_menu(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sessionManager.StopSession()
    End Sub
    'sessiontimeout
    Public Sub sample_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SessionTimeout to be load
        sessionManager = New SessionManager(Me, New main_login(), 240)

        preloadd_all()
        SetColor(Button1)
        myform = accounts
        switch_panel(accounts)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetColor(Button1)
        myform = accounts
        switch_panel(myform)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SetColor(Button2)
        myform = employees
        switch_panel(myform)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SetColor(Button3)
        myform = department
        switch_panel(myform)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SetColor(Button4)
        myform = position
        switch_panel(myform)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SetColor(Button5)
        myform = expense_type
        switch_panel(myform)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SetColor(Button6)
        myform = purpose
        switch_panel(myform)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        SetColor(Button10)
        myform = authorization
        switch_panel(myform)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SetColor(Button7)
        myform = Admin_overview
        switch_panel(myform)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SetColor(Button8)
        myform = admin_report
        switch_panel(myform)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        SetColor(Button11)
        myform = audit_trail 'audit trail form
        switch_panel(myform)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Hide()
        main_login.Show()
    End Sub

    Public Sub switch_panel(ByVal mypanel As Form)
        Panel1.Show()
        Panel1.Controls.Clear()
        Dim contentHandler As Form = mypanel
        contentHandler.Size = Panel1.Size
        contentHandler.WindowState = FormWindowState.Maximized
        contentHandler.FormBorderStyle = FormBorderStyle.None
        contentHandler.TopLevel = False
        Panel1.Controls.Add(contentHandler)
        contentHandler.Show()
    End Sub
    Private Sub sample_menu_ClientSizeChanged(sender As Object, e As EventArgs) Handles Me.ClientSizeChanged
        switch_panel(myform)
    End Sub

    Private Sub preload(mypanel As Form)
        Dim contentHandler As Form = mypanel
        contentHandler.WindowState = FormWindowState.Maximized
        contentHandler.FormBorderStyle = FormBorderStyle.None
        contentHandler.TopLevel = False
        Panel1.Controls.Add(contentHandler)
        contentHandler.Show()
    End Sub
    Public Sub preloadd_all()
        preload(accounts)
        preload(employees)
        preload(department)
        preload(position)
        preload(expense_type)
        preload(purpose)
        preload(Admin_overview)
        preload(authorization)
        'preload(audit_trail)
        'preload(report)
    End Sub

    Private Sub SetColor(btn As Button)
        Button1.BackColor = Color.FromArgb(182, 199, 223)
        Button2.BackColor = Color.FromArgb(182, 199, 223)
        Button3.BackColor = Color.FromArgb(182, 199, 223)
        Button4.BackColor = Color.FromArgb(182, 199, 223)
        Button5.BackColor = Color.FromArgb(182, 199, 223)
        Button6.BackColor = Color.FromArgb(182, 199, 223)
        Button7.BackColor = Color.FromArgb(182, 199, 223)
        Button8.BackColor = Color.FromArgb(182, 199, 223)
        Button10.BackColor = Color.FromArgb(182, 199, 223)
        Button11.BackColor = Color.FromArgb(182, 199, 223)
        btn.BackColor = Color.FromArgb(48, 93, 160)
    End Sub
End Class