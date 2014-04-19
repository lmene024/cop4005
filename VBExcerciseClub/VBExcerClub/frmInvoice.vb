Public Class frmInvoice

    Private Sub frmInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'VBExerClubDBDataSet.INVOICEITEM' table. You can move, or remove it, as needed.
        Me.INVOICEITEMTableAdapter.Fill(Me.VBExerClubDBDataSet.INVOICEITEM)
        'TODO: This line of code loads data into the 'VBExerClubDBDataSet.PRODINVOICE' table. You can move, or remove it, as needed.
        Me.PRODINVOICETableAdapter.Fill(Me.VBExerClubDBDataSet.PRODINVOICE)

    End Sub
End Class