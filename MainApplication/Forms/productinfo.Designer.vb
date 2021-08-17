<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class productinfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(productinfo))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_version = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_cttime = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_panel = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_hourly_target = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.txt_side = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmb_line_no = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_lot_no = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_productname = New System.Windows.Forms.ComboBox()
        Me.txt_save = New System.Windows.Forms.Button()
        Me.txt_startingserialnumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_shift_target = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_productcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_workorder = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(33, 450)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(586, 97)
        Me.DataGridView1.TabIndex = 14
        Me.DataGridView1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.txt_workorder)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txt_version)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txt_cttime)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txt_panel)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txt_hourly_target)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txt_side)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.cmb_line_no)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txt_lot_no)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmb_productname)
        Me.Panel1.Controls.Add(Me.txt_save)
        Me.Panel1.Controls.Add(Me.txt_startingserialnumber)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_shift_target)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_productcode)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(656, 520)
        Me.Panel1.TabIndex = 15
        '
        'txt_version
        '
        Me.txt_version.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_version.Location = New System.Drawing.Point(170, 187)
        Me.txt_version.Name = "txt_version"
        Me.txt_version.Size = New System.Drawing.Size(273, 27)
        Me.txt_version.TabIndex = 38
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(36, 190)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(132, 19)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Software Version :"
        '
        'txt_cttime
        '
        Me.txt_cttime.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cttime.Location = New System.Drawing.Point(170, 355)
        Me.txt_cttime.Name = "txt_cttime"
        Me.txt_cttime.Size = New System.Drawing.Size(273, 27)
        Me.txt_cttime.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(96, 358)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 19)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "CT Time :"
        '
        'txt_panel
        '
        Me.txt_panel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_panel.Location = New System.Drawing.Point(170, 321)
        Me.txt_panel.Name = "txt_panel"
        Me.txt_panel.Size = New System.Drawing.Size(273, 27)
        Me.txt_panel.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(59, 324)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 19)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Boards/Panel :"
        '
        'txt_hourly_target
        '
        Me.txt_hourly_target.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_hourly_target.Location = New System.Drawing.Point(170, 391)
        Me.txt_hourly_target.Name = "txt_hourly_target"
        Me.txt_hourly_target.Size = New System.Drawing.Size(273, 27)
        Me.txt_hourly_target.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(58, 394)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 19)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Hourly Target :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(462, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(159, 234)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Line Stage Details"
        '
        'chk_router
        '
        Me.chk_router.AutoSize = True
        Me.chk_router.Location = New System.Drawing.Point(19, 207)
        Me.chk_router.Name = "chk_router"
        Me.chk_router.Size = New System.Drawing.Size(67, 17)
        Me.chk_router.TabIndex = 8
        Me.chk_router.Text = "9.Router"
        Me.chk_router.UseVisualStyleBackColor = True
        '
        'chk_touchupvi
        '
        Me.chk_touchupvi.AutoSize = True
        Me.chk_touchupvi.Location = New System.Drawing.Point(19, 184)
        Me.chk_touchupvi.Name = "chk_touchupvi"
        Me.chk_touchupvi.Size = New System.Drawing.Size(92, 17)
        Me.chk_touchupvi.TabIndex = 7
        Me.chk_touchupvi.Text = "8.VI / Touchup"
        Me.chk_touchupvi.UseVisualStyleBackColor = True
        '
        'chk_postwave
        '
        Me.chk_postwave.AutoSize = True
        Me.chk_postwave.Location = New System.Drawing.Point(19, 161)
        Me.chk_postwave.Name = "chk_postwave"
        Me.chk_postwave.Size = New System.Drawing.Size(83, 17)
        Me.chk_postwave.TabIndex = 6
        Me.chk_postwave.Text = "7.Post Wave"
        Me.chk_postwave.UseVisualStyleBackColor = True
        '
        'chk_prewave
        '
        Me.chk_prewave.AutoSize = True
        Me.chk_prewave.Location = New System.Drawing.Point(19, 138)
        Me.chk_prewave.Name = "chk_prewave"
        Me.chk_prewave.Size = New System.Drawing.Size(79, 17)
        Me.chk_prewave.TabIndex = 5
        Me.chk_prewave.Text = "6.Pre Wave"
        Me.chk_prewave.UseVisualStyleBackColor = True
        '
        'chk_rework
        '
        Me.chk_rework.AutoSize = True
        Me.chk_rework.Location = New System.Drawing.Point(19, 115)
        Me.chk_rework.Name = "chk_rework"
        Me.chk_rework.Size = New System.Drawing.Size(70, 17)
        Me.chk_rework.TabIndex = 4
        Me.chk_rework.Text = "5.Rework"
        Me.chk_rework.UseVisualStyleBackColor = True
        '
        'chk_aoi
        '
        Me.chk_aoi.AutoSize = True
        Me.chk_aoi.Location = New System.Drawing.Point(19, 92)
        Me.chk_aoi.Name = "chk_aoi"
        Me.chk_aoi.Size = New System.Drawing.Size(52, 17)
        Me.chk_aoi.TabIndex = 3
        Me.chk_aoi.Text = "4.AOI"
        Me.chk_aoi.UseVisualStyleBackColor = True
        '
        'chk_pickandplace
        '
        Me.chk_pickandplace.AutoSize = True
        Me.chk_pickandplace.Location = New System.Drawing.Point(19, 67)
        Me.chk_pickandplace.Name = "chk_pickandplace"
        Me.chk_pickandplace.Size = New System.Drawing.Size(100, 17)
        Me.chk_pickandplace.TabIndex = 2
        Me.chk_pickandplace.Text = "3.Pick and Place"
        Me.chk_pickandplace.UseVisualStyleBackColor = True
        '
        'chk_spi
        '
        Me.chk_spi.AutoSize = True
        Me.chk_spi.Location = New System.Drawing.Point(19, 44)
        Me.chk_spi.Name = "chk_spi"
        Me.chk_spi.Size = New System.Drawing.Size(49, 17)
        Me.chk_spi.TabIndex = 1
        Me.chk_spi.Text = "2.SPI"
        Me.chk_spi.UseVisualStyleBackColor = True
        '
        'chk_lasermarking
        '
        Me.chk_lasermarking.AutoSize = True
        Me.chk_lasermarking.Location = New System.Drawing.Point(19, 21)
        Me.chk_lasermarking.Name = "chk_lasermarking"
        Me.chk_lasermarking.Size = New System.Drawing.Size(99, 17)
        Me.chk_lasermarking.TabIndex = 0
        Me.chk_lasermarking.Text = "1.Laser Marking"
        Me.chk_lasermarking.UseVisualStyleBackColor = True
        '
        'txt_side
        '
        Me.txt_side.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_side.Location = New System.Drawing.Point(170, 222)
        Me.txt_side.Name = "txt_side"
        Me.txt_side.Size = New System.Drawing.Size(273, 27)
        Me.txt_side.TabIndex = 29
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(120, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 19)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Side :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(656, 56)
        Me.Panel2.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(204, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(239, 23)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Product and Line Information"
        '
        'cmb_line_no
        '
        Me.cmb_line_no.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_line_no.FormattingEnabled = True
        Me.cmb_line_no.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmb_line_no.Location = New System.Drawing.Point(170, 288)
        Me.cmb_line_no.Name = "cmb_line_no"
        Me.cmb_line_no.Size = New System.Drawing.Size(273, 27)
        Me.cmb_line_no.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(99, 291)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 19)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Line No :"
        '
        'txt_lot_no
        '
        Me.txt_lot_no.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lot_no.Location = New System.Drawing.Point(170, 255)
        Me.txt_lot_no.Name = "txt_lot_no"
        Me.txt_lot_no.Size = New System.Drawing.Size(273, 27)
        Me.txt_lot_no.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(104, 258)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 19)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Lot No :"
        '
        'cmb_productname
        '
        Me.cmb_productname.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_productname.FormattingEnabled = True
        Me.cmb_productname.Location = New System.Drawing.Point(170, 84)
        Me.cmb_productname.Name = "cmb_productname"
        Me.cmb_productname.Size = New System.Drawing.Size(273, 27)
        Me.cmb_productname.TabIndex = 22
        '
        'txt_save
        '
        Me.txt_save.BackColor = System.Drawing.Color.Green
        Me.txt_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txt_save.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_save.ForeColor = System.Drawing.Color.White
        Me.txt_save.Location = New System.Drawing.Point(208, 466)
        Me.txt_save.Name = "txt_save"
        Me.txt_save.Size = New System.Drawing.Size(157, 47)
        Me.txt_save.TabIndex = 21
        Me.txt_save.Text = "SAVE"
        Me.txt_save.UseVisualStyleBackColor = False
        '
        'txt_startingserialnumber
        '
        Me.txt_startingserialnumber.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_startingserialnumber.Location = New System.Drawing.Point(603, 364)
        Me.txt_startingserialnumber.Name = "txt_startingserialnumber"
        Me.txt_startingserialnumber.Size = New System.Drawing.Size(30, 27)
        Me.txt_startingserialnumber.TabIndex = 20
        Me.txt_startingserialnumber.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(458, 367)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 19)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Starting PCB SNo :"
        Me.Label4.Visible = False
        '
        'txt_shift_target
        '
        Me.txt_shift_target.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_shift_target.Location = New System.Drawing.Point(170, 424)
        Me.txt_shift_target.Name = "txt_shift_target"
        Me.txt_shift_target.Size = New System.Drawing.Size(273, 27)
        Me.txt_shift_target.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(73, 427)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 19)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Shift Target :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 19)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Product Name :"
        '
        'txt_productcode
        '
        Me.txt_productcode.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_productcode.Location = New System.Drawing.Point(170, 117)
        Me.txt_productcode.Name = "txt_productcode"
        Me.txt_productcode.Size = New System.Drawing.Size(273, 27)
        Me.txt_productcode.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Product Code :"
        '
        'txt_workorder
        '
        Me.txt_workorder.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_workorder.Location = New System.Drawing.Point(170, 150)
        Me.txt_workorder.Name = "txt_workorder"
        Me.txt_workorder.Size = New System.Drawing.Size(273, 27)
        Me.txt_workorder.TabIndex = 40
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(69, 153)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 19)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Work Order :"
        '
        'productinfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 520)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "productinfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VEPL SFCS - Porduct Information"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmb_line_no As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_lot_no As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmb_productname As ComboBox
    Friend WithEvents txt_save As Button
    Friend WithEvents txt_shift_target As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_productcode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_side As TextBox
    Friend WithEvents Label8 As Label
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
    Friend WithEvents txt_startingserialnumber As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_hourly_target As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_cttime As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txt_panel As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_version As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_workorder As TextBox
    Friend WithEvents Label13 As Label
End Class
