<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmworkordercreate
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmb_side = New System.Windows.Forms.ComboBox()
        Me.txt_qty = New System.Windows.Forms.TextBox()
        Me.cmb_priority = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb_product_code = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_product = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_line = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_area = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_factory_id = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.lbl_workorderid = New System.Windows.Forms.Label()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btn_create = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cmb_side)
        Me.Panel1.Controls.Add(Me.txt_qty)
        Me.Panel1.Controls.Add(Me.cmb_priority)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cmb_product_code)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmb_product)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmb_line)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmb_area)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmb_factory_id)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1162, 142)
        Me.Panel1.TabIndex = 31
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(69, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 16)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Side"
        '
        'cmb_side
        '
        Me.cmb_side.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_side.FormattingEnabled = True
        Me.cmb_side.Items.AddRange(New Object() {"TOP", "BOT"})
        Me.cmb_side.Location = New System.Drawing.Point(109, 81)
        Me.cmb_side.Name = "cmb_side"
        Me.cmb_side.Size = New System.Drawing.Size(224, 24)
        Me.cmb_side.TabIndex = 46
        '
        'txt_qty
        '
        Me.txt_qty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qty.Location = New System.Drawing.Point(972, 49)
        Me.txt_qty.Name = "txt_qty"
        Me.txt_qty.Size = New System.Drawing.Size(145, 22)
        Me.txt_qty.TabIndex = 45
        '
        'cmb_priority
        '
        Me.cmb_priority.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_priority.FormattingEnabled = True
        Me.cmb_priority.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmb_priority.Location = New System.Drawing.Point(972, 86)
        Me.cmb_priority.Name = "cmb_priority"
        Me.cmb_priority.Size = New System.Drawing.Size(145, 24)
        Me.cmb_priority.TabIndex = 44
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(917, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 16)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Priority"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(584, 83)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(179, 22)
        Me.DateTimePicker1.TabIndex = 42
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(472, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 16)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Work Order Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(909, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 16)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Quantity"
        '
        'cmb_product_code
        '
        Me.cmb_product_code.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_product_code.FormattingEnabled = True
        Me.cmb_product_code.Location = New System.Drawing.Point(584, 46)
        Me.cmb_product_code.Name = "cmb_product_code"
        Me.cmb_product_code.Size = New System.Drawing.Size(175, 24)
        Me.cmb_product_code.TabIndex = 39
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(491, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 16)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Product Code"
        '
        'cmb_product
        '
        Me.cmb_product.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_product.FormattingEnabled = True
        Me.cmb_product.Location = New System.Drawing.Point(109, 43)
        Me.cmb_product.Name = "cmb_product"
        Me.cmb_product.Size = New System.Drawing.Size(315, 24)
        Me.cmb_product.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Product"
        '
        'cmb_line
        '
        Me.cmb_line.Enabled = False
        Me.cmb_line.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_line.FormattingEnabled = True
        Me.cmb_line.Items.AddRange(New Object() {"SMD 1", "SMD 2", "SMD 3", "WAVE", "STB ASSY", "ADAPTOR ASSY", "NORCOLD"})
        Me.cmb_line.Location = New System.Drawing.Point(972, 15)
        Me.cmb_line.Name = "cmb_line"
        Me.cmb_line.Size = New System.Drawing.Size(145, 24)
        Me.cmb_line.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(934, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 16)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Line"
        '
        'cmb_area
        '
        Me.cmb_area.Enabled = False
        Me.cmb_area.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_area.FormattingEnabled = True
        Me.cmb_area.Items.AddRange(New Object() {"SMD", "ASSEMBLY"})
        Me.cmb_area.Location = New System.Drawing.Point(584, 12)
        Me.cmb_area.Name = "cmb_area"
        Me.cmb_area.Size = New System.Drawing.Size(175, 24)
        Me.cmb_area.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(543, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 16)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Area"
        '
        'cmb_factory_id
        '
        Me.cmb_factory_id.Enabled = False
        Me.cmb_factory_id.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_factory_id.FormattingEnabled = True
        Me.cmb_factory_id.Items.AddRange(New Object() {"VEPL UNIT 1", "UNIT 2"})
        Me.cmb_factory_id.Location = New System.Drawing.Point(109, 9)
        Me.cmb_factory_id.Name = "cmb_factory_id"
        Me.cmb_factory_id.Size = New System.Drawing.Size(224, 24)
        Me.cmb_factory_id.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(35, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Factory ID"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btn_update)
        Me.Panel2.Controls.Add(Me.lbl_workorderid)
        Me.Panel2.Controls.Add(Me.btn_close)
        Me.Panel2.Controls.Add(Me.btn_create)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 142)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1162, 62)
        Me.Panel2.TabIndex = 32
        '
        'btn_update
        '
        Me.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_update.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_update.ForeColor = System.Drawing.Color.Olive
        Me.btn_update.Location = New System.Drawing.Point(827, 10)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(109, 38)
        Me.btn_update.TabIndex = 34
        Me.btn_update.Text = "UPDATE"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'lbl_workorderid
        '
        Me.lbl_workorderid.AutoSize = True
        Me.lbl_workorderid.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_workorderid.Location = New System.Drawing.Point(31, 24)
        Me.lbl_workorderid.Name = "lbl_workorderid"
        Me.lbl_workorderid.Size = New System.Drawing.Size(106, 16)
        Me.lbl_workorderid.TabIndex = 33
        Me.lbl_workorderid.Text = "Work Order Date"
        Me.lbl_workorderid.Visible = False
        '
        'btn_close
        '
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.ForeColor = System.Drawing.Color.Maroon
        Me.btn_close.Location = New System.Drawing.Point(1041, 10)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(109, 38)
        Me.btn_close.TabIndex = 32
        Me.btn_close.Text = "CLOSE"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_create
        '
        Me.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_create.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_create.ForeColor = System.Drawing.Color.Green
        Me.btn_create.Location = New System.Drawing.Point(934, 10)
        Me.btn_create.Name = "btn_create"
        Me.btn_create.Size = New System.Drawing.Size(109, 38)
        Me.btn_create.TabIndex = 31
        Me.btn_create.Text = "CREATE"
        Me.btn_create.UseVisualStyleBackColor = True
        '
        'frmworkordercreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1162, 204)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmworkordercreate"
        Me.Text = "CREATE WO"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txt_qty As TextBox
    Friend WithEvents cmb_priority As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmb_product_code As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmb_product As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmb_line As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmb_area As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmb_factory_id As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_update As Button
    Friend WithEvents lbl_workorderid As Label
    Friend WithEvents btn_close As Button
    Friend WithEvents btn_create As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents cmb_side As ComboBox
End Class
