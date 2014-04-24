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
        Me.INVOICEITEMBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.INVOICEITEMTableAdapter = New VBExcerClub.VBExerClubDBDataSetTableAdapters.INVOICEITEMTableAdapter()
        Me.lblMember = New System.Windows.Forms.Label()
        Me.lblEmpID = New System.Windows.Forms.Label()
        Me.lblOrderTotal = New System.Windows.Forms.Label()
        Me.lblTotalCost = New System.Windows.Forms.Label()
        Me.lblTax = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        CType(Me.VBExerClubDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODINVOICEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.INVOICEITEMBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'INVOICEITEMBindingSource
        '
        Me.INVOICEITEMBindingSource.DataMember = "INVOICEITEM"
        Me.INVOICEITEMBindingSource.DataSource = Me.VBExerClubDBDataSet
        '
        'INVOICEITEMTableAdapter
        '
        Me.INVOICEITEMTableAdapter.ClearBeforeFill = True
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
        'lblOrderTotal
        '
        Me.lblOrderTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderTotal.Location = New System.Drawing.Point(407, 498)
        Me.lblOrderTotal.Name = "lblOrderTotal"
        Me.lblOrderTotal.Size = New System.Drawing.Size(79, 21)
        Me.lblOrderTotal.TabIndex = 10
        '
        'lblTotalCost
        '
        Me.lblTotalCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCost.Location = New System.Drawing.Point(407, 426)
        Me.lblTotalCost.Name = "lblTotalCost"
        Me.lblTotalCost.Size = New System.Drawing.Size(79, 21)
        Me.lblTotalCost.TabIndex = 11
        '
        'lblTax
        '
        Me.lblTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTax.Location = New System.Drawing.Point(407, 461)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.Size = New System.Drawing.Size(79, 21)
        Me.lblTax.TabIndex = 12
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
        'dgvItems
        '
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItems.Location = New System.Drawing.Point(34, 208)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.Size = New System.Drawing.Size(452, 150)
        Me.dgvItems.TabIndex = 14
        '
        'frmInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(516, 542)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvItems)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblTax)
        Me.Controls.Add(Me.lblTotalCost)
        Me.Controls.Add(Me.lblOrderTotal)
        Me.Controls.Add(Me.lblEmpID)
        Me.Controls.Add(Me.lblMember)
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
        CType(Me.INVOICEITEMBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents INVOICEITEMBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents INVOICEITEMTableAdapter As VBExcerClub.VBExerClubDBDataSetTableAdapters.INVOICEITEMTableAdapter
    Friend WithEvents lblMember As System.Windows.Forms.Label
    Friend WithEvents lblEmpID As System.Windows.Forms.Label
    Friend WithEvents lblOrderTotal As System.Windows.Forms.Label
    Friend WithEvents lblTotalCost As System.Windows.Forms.Label
    Friend WithEvents lblTax As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dgvItems As System.Windows.Forms.DataGridView
End Class
