<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class stagedetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(stagedetails))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_router = New System.Windows.Forms.CheckBox()
        Me.chk_touchupvi = New System.Windows.Forms.CheckBox()
        Me.chk_postwave = New System.Windows.Forms.CheckBox()
        Me.chk_prewave = New System.Windows.Forms.CheckBox()
        Me.chk_rework = New System.Windows.Forms.CheckBox()
        Me.chk_aoi = New System.Windows.Forms.CheckBox()
        Me.chk_pickandplace = New System.Windows.Forms.CheckBox()
        Me.chk_spi = New System.Windows.Forms.CheckBox()
        Me.chk_lasermarking = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cmb_productname = New System.Windows.Forms.ComboBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.chk_router)
        Me.GroupBox1.Controls.Add(Me.chk_touchupvi)
        Me.GroupBox1.Controls.Add(Me.chk_postwave)
        Me.GroupBox1.Controls.Add(Me.chk_prewave)
        Me.GroupBox1.Controls.Add(Me.chk_rework)
        Me.GroupBox1.Controls.Add(Me.chk_aoi)
        Me.GroupBox1.Controls.Add(Me.chk_pickandplace)
        Me.GroupBox1.Controls.Add(Me.chk_spi)
        Me.GroupBox1.Controls.Add(Me.chk_lasermarking)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 332)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Line Stage Details"
        '
        'chk_router
        '
        Me.chk_router.AutoSize = True
        Me.chk_router.Location = New System.Drawing.Point(17, 295)
        Me.chk_router.Name = "chk_router"
        Me.chk_router.Size = New System.Drawing.Size(84, 20)
        Me.chk_router.TabIndex = 8
        Me.chk_router.Text = "9.Router"
        Me.chk_router.UseVisualStyleBackColor = True
        '
        'chk_touchupvi
        '
        Me.chk_touchupvi.AutoSize = True
        Me.chk_touchupvi.Location = New System.Drawing.Point(17, 261)
        Me.chk_touchupvi.Name = "chk_touchupvi"
        Me.chk_touchupvi.Size = New System.Drawing.Size(123, 20)
        Me.chk_touchupvi.TabIndex = 7
        Me.chk_touchupvi.Text = "8.VI / Touchup"
        Me.chk_touchupvi.UseVisualStyleBackColor = True
        '
        'chk_postwave
        '
        Me.chk_postwave.AutoSize = True
        Me.chk_postwave.Location = New System.Drawing.Point(17, 230)
        Me.chk_postwave.Name = "chk_postwave"
        Me.chk_postwave.Size = New System.Drawing.Size(109, 20)
        Me.chk_postwave.TabIndex = 6
        Me.chk_postwave.Text = "7.Post Wave"
        Me.chk_postwave.UseVisualStyleBackColor = True
        '
        'chk_prewave
        '
        Me.chk_prewave.AutoSize = True
        Me.chk_prewave.Location = New System.Drawing.Point(17, 201)
        Me.chk_prewave.Name = "chk_prewave"
        Me.chk_prewave.Size = New System.Drawing.Size(102, 20)
        Me.chk_prewave.TabIndex = 5
        Me.chk_prewave.Text = "6.Pre Wave"
        Me.chk_prewave.UseVisualStyleBackColor = True
        '
        'chk_rework
        '
        Me.chk_rework.AutoSize = True
        Me.chk_rework.Location = New System.Drawing.Point(17, 168)
        Me.chk_rework.Name = "chk_rework"
        Me.chk_rework.Size = New System.Drawing.Size(88, 20)
        Me.chk_rework.TabIndex = 4
        Me.chk_rework.Text = "5.Rework"
        Me.chk_rework.UseVisualStyleBackColor = True
        '
        'chk_aoi
        '
        Me.chk_aoi.AutoSize = True
        Me.chk_aoi.Location = New System.Drawing.Point(17, 135)
        Me.chk_aoi.Name = "chk_aoi"
        Me.chk_aoi.Size = New System.Drawing.Size(63, 20)
        Me.chk_aoi.TabIndex = 3
        Me.chk_aoi.Text = "4.AOI"
        Me.chk_aoi.UseVisualStyleBackColor = True
        '
        'chk_pickandplace
        '
        Me.chk_pickandplace.AutoSize = True
        Me.chk_pickandplace.Location = New System.Drawing.Point(17, 101)
        Me.chk_pickandplace.Name = "chk_pickandplace"
        Me.chk_pickandplace.Size = New System.Drawing.Size(130, 20)
        Me.chk_pickandplace.TabIndex = 2
        Me.chk_pickandplace.Text = "3.Pick and Place"
        Me.chk_pickandplace.UseVisualStyleBackColor = True
        '
        'chk_spi
        '
        Me.chk_spi.AutoSize = True
        Me.chk_spi.Location = New System.Drawing.Point(17, 67)
        Me.chk_spi.Name = "chk_spi"
        Me.chk_spi.Size = New System.Drawing.Size(60, 20)
        Me.chk_spi.TabIndex = 1
        Me.chk_spi.Text = "2.SPI"
        Me.chk_spi.UseVisualStyleBackColor = True
        '
        'chk_lasermarking
        '
        Me.chk_lasermarking.AutoSize = True
        Me.chk_lasermarking.Location = New System.Drawing.Point(17, 35)
        Me.chk_lasermarking.Name = "chk_lasermarking"
        Me.chk_lasermarking.Size = New System.Drawing.Size(130, 20)
        Me.chk_lasermarking.TabIndex = 0
        Me.chk_lasermarking.Text = "1.Laser Marking"
        Me.chk_lasermarking.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(233, 63)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(547, 160)
        Me.DataGridView1.TabIndex = 17
        Me.DataGridView1.Visible = False
        '
        'cmb_productname
        '
        Me.cmb_productname.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_productname.Font = New System.Drawing.Font("Tahoma", 20.25!)
        Me.cmb_productname.FormattingEnabled = True
        Me.cmb_productname.Location = New System.Drawing.Point(12, 12)
        Me.cmb_productname.Name = "cmb_productname"
        Me.cmb_productname.Size = New System.Drawing.Size(338, 41)
        Me.cmb_productname.TabIndex = 18
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(233, 229)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(547, 162)
        Me.DataGridView2.TabIndex = 19
        Me.DataGridView2.Visible = False
        '
        'stagedetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 436)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.cmb_productname)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "stagedetails"
        Me.Text = "EPL Stage Status"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chk_router As CheckBox
    Friend WithEvents chk_touchupvi As CheckBox
    Friend WithEvents chk_postwave As CheckBox
    Friend WithEvents chk_prewave As CheckBox
    Friend WithEvents chk_rework As CheckBox
    Friend WithEvents chk_aoi As CheckBox
    Friend WithEvents chk_pickandplace As CheckBox
    Friend WithEvents chk_spi As CheckBox
    Friend WithEvents chk_lasermarking As CheckBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cmb_productname As ComboBox
    Friend WithEvents DataGridView2 As DataGridView
End Class
