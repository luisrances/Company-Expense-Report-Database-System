Imports System.Windows.Forms

Public Class SessionManager
    Private WithEvents session_timer As New Timer
    Private inactivity_limit As TimeSpan
    Private last_active_time As DateTime
    Private form As Form
    Private loginForm As Form

    Public Sub New(formInstance As Form, loginFormInstance As Form, timeoutSeconds As Integer)
        form = formInstance
        loginForm = loginFormInstance
        inactivity_limit = TimeSpan.FromSeconds(timeoutSeconds)

        session_timer.Interval = 1000
        session_timer.Start()
        last_active_time = DateTime.Now

        AddHandler form.MouseMove, AddressOf reset_timer
        AddHandler form.KeyPress, AddressOf reset_timer
    End Sub

    Private Sub reset_timer(sender As Object, e As EventArgs)
        last_active_time = DateTime.Now
    End Sub

    Private Sub on_session_timeout(sender As Object, e As EventArgs) Handles session_timer.Tick
        Dim current_time As DateTime = DateTime.Now
        If current_time.Subtract(last_active_time) >= inactivity_limit Then
            session_timer.Stop()
            MessageBox.Show("Session timed out due to inactivity. Returning to login screen.", "Session Timeout", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loginForm.Show()
            form.Close()
        End If
    End Sub
    Public Sub StopSession()
        session_timer.Stop()
        RemoveHandler form.MouseMove, AddressOf reset_timer
        RemoveHandler form.KeyPress, AddressOf reset_timer
    End Sub
End Class
