<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class yieldfg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(yieldfg))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_model = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_fail_count = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_total_count = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_yield = New System.Windows.Forms.TextBox()
        Me.txt_pass_count = New System.Windows.Forms.TextBox()
        Me.txt_target = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txt_fail_count)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_total_count)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_yield)
        Me.Panel1.Controls.Add(Me.txt_pass_count)
        Me.Panel1.Controls.Add(Me.txt_target)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(684, 461)
        Me.Panel1.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Panel2.Controls.Add(Me.lbl_model)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(684, 63)
        Me.Panel2.TabIndex = 12
        '
        'lbl_model
        '
        Me.lbl_model.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_model.AutoSize = True
        Me.lbl_model.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_model.ForeColor = System.Drawing.Color.White
        Me.lbl_model.Location = New System.Drawing.Point(12, 18)
        Me.lbl_model.Name = "lbl_model"
        Me.lbl_model.Size = New System.Drawing.Size(88, 31)
        Me.lbl_model.TabIndex = 12
        Me.lbl_model.Text = "Model"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(150, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 31)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Fail Count"
        '
        'txt_fail_count
        '
        Me.txt_fail_count.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_fail_count.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fail_count.Location = New System.Drawing.Point(297, 218)
        Me.txt_fail_count.Name = "txt_fail_count"
        Me.txt_fail_count.Size = New System.Drawing.Size(274, 39)
        Me.txt_fail_count.TabIndex = 9
        Me.txt_fail_count.Text = "0"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(136, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 31)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Total Count"
        '
        'txt_total_count
        '
        Me.txt_total_count.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_total_count.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_count.Location = New System.Drawing.Point(297, 174)
        Me.txt_total_count.Name = "txt_total_count"
        Me.txt_total_count.Size = New System.Drawing.Size(274, 39)
        Me.txt_total_count.TabIndex = 7
        Me.txt_total_count.Text = "0"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(143, 265)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 31)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Pass Count"
        '
        'txt_yield
        '
        Me.txt_yield.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_yield.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_yield.Location = New System.Drawing.Point(297, 306)
        Me.txt_yield.Name = "txt_yield"
        Me.txt_yield.Size = New System.Drawing.Size(274, 39)
        Me.txt_yield.TabIndex = 5
        Me.txt_yield.Text = "0"
        '
        'txt_pass_count
        '
        Me.txt_pass_count.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_pass_count.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pass_count.Location = New System.Drawing.Point(297, 262)
        Me.txt_pass_count.Name = "txt_pass_count"
        Me.txt_pass_count.Size = New System.Drawing.Size(274, 39)
        Me.txt_pass_count.TabIndex = 4
        Me.txt_pass_count.Text = "0"
        '
        'txt_target
        '
        Me.txt_target.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_target.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_target.Location = New System.Drawing.Point(297, 130)
        Me.txt_target.Name = "txt_target"
        Me.txt_target.Size = New System.Drawing.Size(274, 39)
        Me.txt_target.TabIndex = 3
        Me.txt_target.Text = "1000"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(212, 306)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 31)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Yield"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(201, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Target"
        '
        'yieldfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 461)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "yieldfg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EPL SFCS Yield FG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_fail_count As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_total_count As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_yield As TextBox
    Friend WithEvents txt_pass_count As TextBox
    Friend WithEvents txt_target As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbl_model As Label
End Class
