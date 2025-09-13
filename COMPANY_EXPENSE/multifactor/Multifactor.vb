Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Multifactor
    Private captchaCode As String

    Public Sub init()
        InitializeComponent()
        GenerateCaptcha()
    End Sub

    Private Sub GenerateCaptcha()
        captchaCode = GenerateRandomCode()
        picCaptcha.Image = CreateCaptchaImage(captchaCode)
    End Sub

    Private Function GenerateRandomCode() As String
        Dim characters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789"
        Dim random As New Random
        Dim captcha As String = ""
        For i As Integer = 1 To 5
            captcha &= characters(random.Next(0, characters.Length))
        Next
        Return captcha
    End Function

    Private Function CreateCaptchaImage(code As String) As Bitmap
        Dim width As Integer = 200
        Dim height As Integer = 60
        Dim bmp As New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim font As New Font("Arial", 24, FontStyle.Bold)
        Dim random As New Random()

        g.Clear(Color.White)
        Dim brush As New LinearGradientBrush(New Rectangle(0, 0, bmp.Width, bmp.Height), Color.Blue, Color.DarkBlue, 45)

        'para magulo tingnan yung code hahaha
        For i As Integer = 0 To code.Length - 1
            Dim charOffsetX As Integer = i * 30 + random.Next(-5, 5)
            Dim charOffsetY As Integer = random.Next(5, 15)
            Dim angle As Single = random.Next(-30, 30)

            'random angles ng characters
            g.TranslateTransform(charOffsetX, charOffsetY)
            g.RotateTransform(angle)
            g.DrawString(code(i).ToString(), font, brush, New PointF(0, 0))
            g.ResetTransform()
        Next

        'random lines sa captcha code
        For i As Integer = 0 To 4
            Dim x1 As Integer = random.Next(0, width)
            Dim y1 As Integer = random.Next(0, height)
            Dim x2 As Integer = random.Next(0, width)
            Dim y2 As Integer = random.Next(0, height)
            g.DrawLine(New Pen(Color.Gray, 2), x1, y1, x2, y2)
        Next

        'pang random dots
        For i As Integer = 0 To 100
            Dim x As Integer = random.Next(0, width)
            Dim y As Integer = random.Next(0, height)
            bmp.SetPixel(x, y, Color.LightGray)
        Next

        g.Dispose()
        Return bmp
    End Function

    'redirect na dito
    Public Sub redirect(position As String)
        If position = "employee" Then
            MsgBox("Welcome dear employee")
            Me.Hide()
            Employee.Show()
        ElseIf position = "manager" Then
            MsgBox("Welcome dear manager")
            Me.Hide()
            Manager.Show()
        ElseIf position = "admin" Then
            MsgBox("Welcome dear admin")
            Me.Hide()
            sample_menu.Show()
        End If
    End Sub

    Private Sub pnlVerify_Click(sender As Object, e As EventArgs) Handles pnlVerify.Click
        If txtCaptcha.Text = captchaCode Then
            MsgBox("Captcha verified successfully.")
            txtCaptcha.Clear()
            GenerateCaptcha()
            redirect(main_login.userLevel)
        Else
            MsgBox("Incorrect. Please try again.")
            txtCaptcha.Clear()
            GenerateCaptcha()
        End If
    End Sub

    'SessionTimeout
    Private sessionManager As SessionManager
    Private Sub Multifactor(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        sessionManager.StopSession()
    End Sub
    'sessiontimeout
    Private Sub Multifactor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SessionTimeout to be load
        sessionManager = New SessionManager(Me, New main_login(), 60)

        GenerateCaptcha()
    End Sub
End Class