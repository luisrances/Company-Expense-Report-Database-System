<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class employees
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
        Dim Employee_IDLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim Department_IDLabel As System.Windows.Forms.Label
        Dim Position_IDLabel As System.Windows.Forms.Label
        Dim EMP_CONTACTLabel As System.Windows.Forms.Label
        Dim EMP_SEXLabel As System.Windows.Forms.Label
        Dim EMP_EMAILLabel As System.Windows.Forms.Label
        Dim EMP_ADDRESSLabel As System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.txtADDRESS = New System.Windows.Forms.TextBox()
        Me.txtEMAIL = New System.Windows.Forms.TextBox()
        Me.txtSEX = New System.Windows.Forms.TextBox()
        Me.txtCONTACT = New System.Windows.Forms.TextBox()
        Me.txtPOSITION = New System.Windows.Forms.TextBox()
        Me.txtDEPT = New System.Windows.Forms.TextBox()
        Me.txtNAME = New System.Windows.Forms.TextBox()
        Me.txtEID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Employee_IDLabel = New System.Windows.Forms.Label()
        NameLabel = New System.Windows.Forms.Label()
        Department_IDLabel = New System.Windows.Forms.Label()
        Position_IDLabel = New System.Windows.Forms.Label()
        EMP_CONTACTLabel = New System.Windows.Forms.Label()
        EMP_SEXLabel = New System.Windows.Forms.Label()
        EMP_EMAILLabel = New System.Windows.Forms.Label()
        EMP_ADDRESSLabel = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Employee_IDLabel
        '
        Employee_IDLabel.AutoSize = True
        Employee_IDLabel.BackColor = System.Drawing.Color.Transparent
        Employee_IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Employee_IDLabel.Location = New System.Drawing.Point(57, 10)
        Employee_IDLabel.Name = "Employee_IDLabel"
        Employee_IDLabel.Size = New System.Drawing.Size(109, 20)
        Employee_IDLabel.TabIndex = 96
        Employee_IDLabel.Text = "Employee ID:"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.BackColor = System.Drawing.Color.Transparent
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(57, 54)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(58, 20)
        NameLabel.TabIndex = 97
        NameLabel.Text = "Name:"
        '
        'Department_IDLabel
        '
        Department_IDLabel.AutoSize = True
        Department_IDLabel.BackColor = System.Drawing.Color.Transparent
        Department_IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Department_IDLabel.Location = New System.Drawing.Point(57, 98)
        Department_IDLabel.Name = "Department_IDLabel"
        Department_IDLabel.Size = New System.Drawing.Size(124, 20)
        Department_IDLabel.TabIndex = 98
        Department_IDLabel.Text = "Department ID:"
        '
        'Position_IDLabel
        '
        Position_IDLabel.AutoSize = True
        Position_IDLabel.BackColor = System.Drawing.Color.Transparent
        Position_IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Position_IDLabel.Location = New System.Drawing.Point(57, 142)
        Position_IDLabel.Name = "Position_IDLabel"
        Position_IDLabel.Size = New System.Drawing.Size(96, 20)
        Position_IDLabel.TabIndex = 99
        Position_IDLabel.Text = "Position ID:"
        '
        'EMP_CONTACTLabel
        '
        EMP_CONTACTLabel.AutoSize = True
        EMP_CONTACTLabel.BackColor = System.Drawing.Color.Transparent
        EMP_CONTACTLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EMP_CONTACTLabel.Location = New System.Drawing.Point(451, 10)
        EMP_CONTACTLabel.Name = "EMP_CONTACTLabel"
        EMP_CONTACTLabel.Size = New System.Drawing.Size(72, 20)
        EMP_CONTACTLabel.TabIndex = 100
        EMP_CONTACTLabel.Text = "Contact:"
        '
        'EMP_SEXLabel
        '
        EMP_SEXLabel.AutoSize = True
        EMP_SEXLabel.BackColor = System.Drawing.Color.Transparent
        EMP_SEXLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EMP_SEXLabel.Location = New System.Drawing.Point(451, 54)
        EMP_SEXLabel.Name = "EMP_SEXLabel"
        EMP_SEXLabel.Size = New System.Drawing.Size(42, 20)
        EMP_SEXLabel.TabIndex = 101
        EMP_SEXLabel.Text = "Sex:"
        '
        'EMP_EMAILLabel
        '
        EMP_EMAILLabel.AutoSize = True
        EMP_EMAILLabel.BackColor = System.Drawing.Color.Transparent
        EMP_EMAILLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EMP_EMAILLabel.Location = New System.Drawing.Point(451, 98)
        EMP_EMAILLabel.Name = "EMP_EMAILLabel"
        EMP_EMAILLabel.Size = New System.Drawing.Size(56, 20)
        EMP_EMAILLabel.TabIndex = 102
        EMP_EMAILLabel.Text = "Email:"
        '
        'EMP_ADDRESSLabel
        '
        EMP_ADDRESSLabel.AutoSize = True
        EMP_ADDRESSLabel.BackColor = System.Drawing.Color.Transparent
        EMP_ADDRESSLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EMP_ADDRESSLabel.Location = New System.Drawing.Point(451, 142)
        EMP_ADDRESSLabel.Name = "EMP_ADDRESSLabel"
        EMP_ADDRESSLabel.Size = New System.Drawing.Size(76, 20)
        EMP_ADDRESSLabel.TabIndex = 103
        EMP_ADDRESSLabel.Text = "Address:"
        '
        'ComboBox2
        '
        Me.ComboBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(207, 101)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(184, 28)
        Me.ComboBox2.TabIndex = 122
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(207, 13)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(184, 28)
        Me.ComboBox1.TabIndex = 119
        '
        'ComboBox3
        '
        Me.ComboBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(207, 145)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(184, 28)
        Me.ComboBox3.TabIndex = 118
        '
        'txtADDRESS
        '
        Me.txtADDRESS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtADDRESS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtADDRESS.Location = New System.Drawing.Point(601, 145)
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.Size = New System.Drawing.Size(184, 27)
        Me.txtADDRESS.TabIndex = 117
        '
        'txtEMAIL
        '
        Me.txtEMAIL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEMAIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEMAIL.Location = New System.Drawing.Point(601, 101)
        Me.txtEMAIL.Name = "txtEMAIL"
        Me.txtEMAIL.Size = New System.Drawing.Size(184, 27)
        Me.txtEMAIL.TabIndex = 116
        '
        'txtSEX
        '
        Me.txtSEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSEX.Location = New System.Drawing.Point(988, 178)
        Me.txtSEX.Name = "txtSEX"
        Me.txtSEX.Size = New System.Drawing.Size(300, 27)
        Me.txtSEX.TabIndex = 115
        Me.txtSEX.Visible = False
        '
        'txtCONTACT
        '
        Me.txtCONTACT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCONTACT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONTACT.Location = New System.Drawing.Point(601, 13)
        Me.txtCONTACT.Name = "txtCONTACT"
        Me.txtCONTACT.Size = New System.Drawing.Size(184, 27)
        Me.txtCONTACT.TabIndex = 114
        '
        'txtPOSITION
        '
        Me.txtPOSITION.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOSITION.Location = New System.Drawing.Point(988, 145)
        Me.txtPOSITION.Name = "txtPOSITION"
        Me.txtPOSITION.Size = New System.Drawing.Size(262, 27)
        Me.txtPOSITION.TabIndex = 113
        Me.txtPOSITION.Visible = False
        '
        'txtDEPT
        '
        Me.txtDEPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEPT.Location = New System.Drawing.Point(988, 112)
        Me.txtDEPT.Name = "txtDEPT"
        Me.txtDEPT.Size = New System.Drawing.Size(262, 27)
        Me.txtDEPT.TabIndex = 112
        Me.txtDEPT.Visible = False
        '
        'txtNAME
        '
        Me.txtNAME.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNAME.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNAME.Location = New System.Drawing.Point(207, 57)
        Me.txtNAME.Name = "txtNAME"
        Me.txtNAME.Size = New System.Drawing.Size(184, 27)
        Me.txtNAME.TabIndex = 111
        '
        'txtEID
        '
        Me.txtEID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEID.Location = New System.Drawing.Point(988, 79)
        Me.txtEID.Name = "txtEID"
        Me.txtEID.Size = New System.Drawing.Size(262, 27)
        Me.txtEID.TabIndex = 110
        Me.txtEID.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Impact", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(934, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 35)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "ADMINISTRATOR"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Impact", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(391, 35)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Mandaluyong TechHub Solutions"
        '
        'btnMenu
        '
        Me.btnMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMenu.BackColor = System.Drawing.SystemColors.Control
        Me.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMenu.Location = New System.Drawing.Point(13, 613)
        Me.btnMenu.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(125, 45)
        Me.btnMenu.TabIndex = 132
        Me.btnMenu.Text = "BACK TO MENU"
        Me.btnMenu.UseVisualStyleBackColor = False
        Me.btnMenu.Visible = False
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.BackColor = System.Drawing.SystemColors.Control
        Me.btnLoad.Location = New System.Drawing.Point(732, 613)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(125, 45)
        Me.btnLoad.TabIndex = 131
        Me.btnLoad.Text = "LOAD"
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.SystemColors.Window
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(146, 271)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(221, 27)
        Me.txtSearch.TabIndex = 130
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Location = New System.Drawing.Point(865, 612)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(125, 45)
        Me.btnCancel.TabIndex = 129
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Location = New System.Drawing.Point(13, 260)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(125, 45)
        Me.btnSearch.TabIndex = 128
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.Location = New System.Drawing.Point(998, 612)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(125, 45)
        Me.btnSave.TabIndex = 127
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.Location = New System.Drawing.Point(865, 260)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(125, 45)
        Me.btnEdit.TabIndex = 126
        Me.btnEdit.Text = "EDIT"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.SystemColors.Control
        Me.btnRemove.Location = New System.Drawing.Point(998, 260)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(125, 45)
        Me.btnRemove.TabIndex = 125
        Me.btnRemove.Text = "DELETE"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.Location = New System.Drawing.Point(732, 260)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(125, 45)
        Me.btnAdd.TabIndex = 124
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(72, 313)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1003, 291)
        Me.DataGridView1.TabIndex = 123
        '
        'ComboBox4
        '
        Me.ComboBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(601, 57)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(184, 28)
        Me.ComboBox4.TabIndex = 135
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Controls.Add(Employee_IDLabel, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBox4, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Position_IDLabel, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(NameLabel, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Department_IDLabel, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBox1, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNAME, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBox2, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBox3, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(EMP_CONTACTLabel, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(EMP_SEXLabel, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(EMP_EMAILLabel, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(EMP_ADDRESSLabel, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtADDRESS, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCONTACT, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEMAIL, 5, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(145, 65)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(845, 189)
        Me.TableLayoutPanel1.TabIndex = 152
        '
        'employees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.BackgroundImage = Global.COMPANY_EXPENSE.My.Resources.Resources._2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1138, 669)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtSEX)
        Me.Controls.Add(Me.txtPOSITION)
        Me.Controls.Add(Me.txtDEPT)
        Me.Controls.Add(Me.txtEID)
        Me.DoubleBuffered = True
        Me.Name = "employees"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "employees"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents txtADDRESS As TextBox
    Friend WithEvents txtEMAIL As TextBox
    Friend WithEvents txtSEX As TextBox
    Friend WithEvents txtCONTACT As TextBox
    Friend WithEvents txtPOSITION As TextBox
    Friend WithEvents txtDEPT As TextBox
    Friend WithEvents txtNAME As TextBox
    Friend WithEvents txtEID As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnMenu As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
