<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sample
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
        Me.AdvancedDataGridView1 = New ADGV.AdvancedDataGridView()
        CType(Me.AdvancedDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AdvancedDataGridView1
        '
        Me.AdvancedDataGridView1.AutoGenerateContextFilters = True
        Me.AdvancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AdvancedDataGridView1.DateWithTime = False
        Me.AdvancedDataGridView1.Location = New System.Drawing.Point(50, 36)
        Me.AdvancedDataGridView1.Name = "AdvancedDataGridView1"
        Me.AdvancedDataGridView1.Size = New System.Drawing.Size(359, 249)
        Me.AdvancedDataGridView1.TabIndex = 0
        Me.AdvancedDataGridView1.TimeFilter = False
        '
        'sample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 329)
        Me.Controls.Add(Me.AdvancedDataGridView1)
        Me.Name = "sample"
        Me.Text = "sample"
        CType(Me.AdvancedDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AdvancedDataGridView1 As ADGV.AdvancedDataGridView
End Class
