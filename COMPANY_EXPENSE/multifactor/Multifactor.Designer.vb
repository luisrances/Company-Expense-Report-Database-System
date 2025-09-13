<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Multifactor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtCaptcha = New System.Windows.Forms.TextBox()
        Me.picCaptcha = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlVerify = New System.Windows.Forms.Panel()
        CType(Me.picCaptcha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCaptcha
        '
        Me.txtCaptcha.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCaptcha.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaptcha.Location = New System.Drawing.Point(401, 352)
        Me.txtCaptcha.Name = "txtCaptcha"
        Me.txtCaptcha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCaptcha.Size = New System.Drawing.Size(335, 38)
        Me.txtCaptcha.TabIndex = 2
        '
        'picCaptcha
        '
        Me.picCaptcha.Location = New System.Drawing.Point(437, 210)
        Me.picCaptcha.Name = "picCaptcha"
        Me.picCaptcha.Size = New System.Drawing.Size(260, 79)
        Me.picCaptcha.TabIndex = 3
        Me.picCaptcha.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(398, 332)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Enter here the Captcha Code:"
        '
        'pnlVerify
        '
        Me.pnlVerify.BackColor = System.Drawing.Color.Transparent
        Me.pnlVerify.Location = New System.Drawing.Point(466, 445)
        Me.pnlVerify.Name = "pnlVerify"
        Me.pnlVerify.Size = New System.Drawing.Size(200, 62)
        Me.pnlVerify.TabIndex = 6
        '
        'Multifactor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.COMPANY_EXPENSE.My.Resources.Resources.VERIFICATION
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1138, 669)
        Me.Controls.Add(Me.pnlVerify)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picCaptcha)
        Me.Controls.Add(Me.txtCaptcha)
        Me.Name = "Multifactor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.picCaptcha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCaptcha As TextBox
    Friend WithEvents picCaptcha As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlVerify As Panel
End Class
