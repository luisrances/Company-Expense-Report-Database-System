<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class change_pass
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.txtNewPass = New System.Windows.Forms.TextBox()
        Me.txtOldpass = New System.Windows.Forms.TextBox()
        Me.btnShowOldpass = New System.Windows.Forms.Button()
        Me.btnShowNewPass = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblnewpass = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(62, 569)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(220, 68)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Enabled = False
        Me.btnsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(864, 569)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(222, 68)
        Me.btnsave.TabIndex = 1
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'txtNewPass
        '
        Me.txtNewPass.Enabled = False
        Me.txtNewPass.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPass.Location = New System.Drawing.Point(128, 344)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.Size = New System.Drawing.Size(818, 31)
        Me.txtNewPass.TabIndex = 2
        '
        'txtOldpass
        '
        Me.txtOldpass.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldpass.Location = New System.Drawing.Point(128, 218)
        Me.txtOldpass.Name = "txtOldpass"
        Me.txtOldpass.Size = New System.Drawing.Size(818, 31)
        Me.txtOldpass.TabIndex = 3
        '
        'btnShowOldpass
        '
        Me.btnShowOldpass.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnShowOldpass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowOldpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowOldpass.ForeColor = System.Drawing.Color.White
        Me.btnShowOldpass.Location = New System.Drawing.Point(961, 218)
        Me.btnShowOldpass.Name = "btnShowOldpass"
        Me.btnShowOldpass.Size = New System.Drawing.Size(63, 30)
        Me.btnShowOldpass.TabIndex = 4
        Me.btnShowOldpass.Text = "Hide"
        Me.btnShowOldpass.UseVisualStyleBackColor = False
        '
        'btnShowNewPass
        '
        Me.btnShowNewPass.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnShowNewPass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowNewPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowNewPass.ForeColor = System.Drawing.Color.White
        Me.btnShowNewPass.Location = New System.Drawing.Point(961, 347)
        Me.btnShowNewPass.Name = "btnShowNewPass"
        Me.btnShowNewPass.Size = New System.Drawing.Size(63, 30)
        Me.btnShowNewPass.TabIndex = 5
        Me.btnShowNewPass.Text = "Hide"
        Me.btnShowNewPass.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(123, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(235, 29)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Current Password :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(123, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 29)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "New Password :"
        '
        'lblnewpass
        '
        Me.lblnewpass.AutoSize = True
        Me.lblnewpass.Font = New System.Drawing.Font("Microsoft YaHei", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnewpass.ForeColor = System.Drawing.Color.Red
        Me.lblnewpass.Location = New System.Drawing.Point(128, 381)
        Me.lblnewpass.Name = "lblnewpass"
        Me.lblnewpass.Size = New System.Drawing.Size(0, 19)
        Me.lblnewpass.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Impact", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(391, 35)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Mandaluyong TechHub Solutions"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Impact", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(900, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(230, 35)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "CHANGE PASSWORD"
        '
        'change_pass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BackgroundImage = Global.COMPANY_EXPENSE.My.Resources.Resources._2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1138, 669)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblnewpass)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnShowNewPass)
        Me.Controls.Add(Me.btnShowOldpass)
        Me.Controls.Add(Me.txtOldpass)
        Me.Controls.Add(Me.txtNewPass)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btnCancel)
        Me.DoubleBuffered = True
        Me.Name = "change_pass"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Password Setting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnsave As Button
    Friend WithEvents txtNewPass As TextBox
    Friend WithEvents txtOldpass As TextBox
    Friend WithEvents btnShowOldpass As Button
    Friend WithEvents btnShowNewPass As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblnewpass As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
