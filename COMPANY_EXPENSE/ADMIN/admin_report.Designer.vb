<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class admin_report
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.V_expenseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ms1DataSet = New COMPANY_EXPENSE.ms1DataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Vexpense1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.V_expense1TableAdapter = New COMPANY_EXPENSE.ms1DataSetTableAdapters.v_expense1TableAdapter()
        Me.V_expenseTableAdapter = New COMPANY_EXPENSE.ms1DataSetTableAdapters.v_expenseTableAdapter()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.V_expenseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ms1DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Vexpense1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'V_expenseBindingSource
        '
        Me.V_expenseBindingSource.DataMember = "v_expense"
        Me.V_expenseBindingSource.DataSource = Me.Ms1DataSet
        '
        'Ms1DataSet
        '
        Me.Ms1DataSet.DataSetName = "ms1DataSet"
        Me.Ms1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.V_expenseBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "COMPANY_EXPENSE.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(2, 66)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1151, 597)
        Me.ReportViewer1.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.Vexpense1BindingSource
        Me.ComboBox1.DisplayMember = "OVERVIEW_ID"
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(320, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(226, 33)
        Me.ComboBox1.TabIndex = 1
        '
        'Vexpense1BindingSource
        '
        Me.Vexpense1BindingSource.DataMember = "v_expense1"
        Me.Vexpense1BindingSource.DataSource = Me.Ms1DataSet
        '
        'V_expense1TableAdapter
        '
        Me.V_expense1TableAdapter.ClearBeforeFill = True
        '
        'V_expenseTableAdapter
        '
        Me.V_expenseTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(161, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 29)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Overview ID"
        '
        'admin_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.BackgroundImage = Global.COMPANY_EXPENSE.My.Resources.Resources._2
        Me.ClientSize = New System.Drawing.Size(1157, 677)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "admin_report"
        Me.Text = "report"
        CType(Me.V_expenseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ms1DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Vexpense1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Ms1DataSet As ms1DataSet
    Friend WithEvents Vexpense1BindingSource As BindingSource
    Friend WithEvents V_expense1TableAdapter As ms1DataSetTableAdapters.v_expense1TableAdapter
    Friend WithEvents V_expenseBindingSource As BindingSource
    Friend WithEvents V_expenseTableAdapter As ms1DataSetTableAdapters.v_expenseTableAdapter
    Friend WithEvents Label1 As Label
End Class
