<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoice
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.VBExerClubDBDataSet = New VBExcerClub.VBExerClubDBDataSet()
        Me.PRODINVOICEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PRODINVOICETableAdapter = New VBExcerClub.VBExerClubDBDataSetTableAdapters.PRODINVOICETableAdapter()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        Me.INVOICEITEMBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.INVOICEITEMTableAdapter = New VBExcerClub.VBExerClubDBDataSetTableAdapters.INVOICEITEMTableAdapter()
        Me.INVIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTYDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRICEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMember = New System.Windows.Forms.Label()
        Me.lblEmpID = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.VBExerClubDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODINVOICEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.INVOICEITEMBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Member"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Employee ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Items"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(324, 427)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 14)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Total Cost"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(324, 462)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 14)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Tax"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(324, 499)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 14)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Order Total"
        '
        'VBExerClubDBDataSet
        '
        Me.VBExerClubDBDataSet.DataSetName = "VBExerClubDBDataSet"
        Me.VBExerClubDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PRODINVOICEBindingSource
        '
        Me.PRODINVOICEBindingSource.DataMember = "PRODINVOICE"
        Me.PRODINVOICEBindingSource.DataSource = Me.VBExerClubDBDataSet
        '
        'PRODINVOICETableAdapter
        '
        Me.PRODINVOICETableAdapter.ClearBeforeFill = True
        '
        'dgvItems
        '
        Me.dgvItems.AutoGenerateColumns = False
        Me.dgvItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.INVIDDataGridViewTextBoxColumn, Me.PRODIDDataGridViewTextBoxColumn, Me.QTYDataGridViewTextBoxColumn, Me.PRICEDataGridViewTextBoxColumn})
        Me.dgvItems.DataSource = Me.INVOICEITEMBindingSource
        Me.dgvItems.Location = New System.Drawing.Point(34, 194)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.ReadOnly = True
        Me.dgvItems.Size = New System.Drawing.Size(452, 150)
        Me.dgvItems.TabIndex = 6
        '
        'INVOICEITEMBindingSource
        '
        Me.INVOICEITEMBindingSource.DataMember = "INVOICEITEM"
        Me.INVOICEITEMBindingSource.DataSource = Me.VBExerClubDBDataSet
        '
        'INVOICEITEMTableAdapter
        '
        Me.INVOICEITEMTableAdapter.ClearBeforeFill = True
        '
        'INVIDDataGridViewTextBoxColumn
        '
        Me.INVIDDataGridViewTextBoxColumn.DataPropertyName = "INVID"
        Me.INVIDDataGridViewTextBoxColumn.HeaderText = "INVID"
        Me.INVIDDataGridViewTextBoxColumn.Name = "INVIDDataGridViewTextBoxColumn"
        Me.INVIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRODIDDataGridViewTextBoxColumn
        '
        Me.PRODIDDataGridViewTextBoxColumn.DataPropertyName = "PRODID"
        Me.PRODIDDataGridViewTextBoxColumn.HeaderText = "PRODID"
        Me.PRODIDDataGridViewTextBoxColumn.Name = "PRODIDDataGridViewTextBoxColumn"
        Me.PRODIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QTYDataGridViewTextBoxColumn
        '
        Me.QTYDataGridViewTextBoxColumn.DataPropertyName = "QTY"
        Me.QTYDataGridViewTextBoxColumn.HeaderText = "QTY"
        Me.QTYDataGridViewTextBoxColumn.Name = "QTYDataGridViewTextBoxColumn"
        Me.QTYDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRICEDataGridViewTextBoxColumn
        '
        Me.PRICEDataGridViewTextBoxColumn.DataPropertyName = "PRICE"
        Me.PRICEDataGridViewTextBoxColumn.HeaderText = "PRICE"
        Me.PRICEDataGridViewTextBoxColumn.Name = "PRICEDataGridViewTextBoxColumn"
        Me.PRICEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'lblMember
        '
        Me.lblMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMember.Location = New System.Drawing.Point(138, 93)
        Me.lblMember.Name = "lblMember"
        Me.lblMember.Size = New System.Drawing.Size(79, 21)
        Me.lblMember.TabIndex = 7
        '
        'lblEmpID
        '
        Me.lblEmpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmpID.Location = New System.Drawing.Point(138, 128)
        Me.lblEmpID.Name = "lblEmpID"
        Me.lblEmpID.Size = New System.Drawing.Size(79, 21)
        Me.lblEmpID.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Location = New System.Drawing.Point(407, 498)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 21)
        Me.Label10.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(407, 426)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 21)
        Me.Label11.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Location = New System.Drawing.Point(407, 461)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 21)
        Me.Label12.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Courier New", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(187, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(172, 41)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Invoice"
        '
        'frmInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(516, 542)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblEmpID)
        Me.Controls.Add(Me.lblMember)
        Me.Controls.Add(Me.dgvItems)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmInvoice"
        Me.Text = "Invoice"
        CType(Me.VBExerClubDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODINVOICEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.INVOICEITEMBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents VBExerClubDBDataSet As VBExcerClub.VBExerClubDBDataSet
    Friend WithEvents PRODINVOICEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODINVOICETableAdapter As VBExcerClub.VBExerClubDBDataSetTableAdapters.PRODINVOICETableAdapter
    Friend WithEvents dgvItems As System.Windows.Forms.DataGridView
    Friend WithEvents INVOICEITEMBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents INVOICEITEMTableAdapter As VBExcerClub.VBExerClubDBDataSetTableAdapters.INVOICEITEMTableAdapter
    Friend WithEvents INVIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTYDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRICEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMember As System.Windows.Forms.Label
    Friend WithEvents lblEmpID As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
