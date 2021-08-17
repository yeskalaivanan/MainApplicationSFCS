<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class serialgeneration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(serialgeneration))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_panel_size = New System.Windows.Forms.TextBox()
        Me.txt_product_name = New System.Windows.Forms.TextBox()
        Me.btn_save_details = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_panel_number = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_generate_serial = New System.Windows.Forms.Button()
        Me.txt_quantity = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_serial_number = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(785, 223)
        Me.Panel1.TabIndex = 10
        '
        'txt_panel_size
        '
        Me.txt_panel_size.Enabled = False
        Me.txt_panel_size.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_panel_size.Location = New System.Drawing.Point(176, 100)
        Me.txt_panel_size.Name = "txt_panel_size"
        Me.txt_panel_size.Size = New System.Drawing.Size(121, 23)
        Me.txt_panel_size.TabIndex = 31
        '
        'txt_product_name
        '
        Me.txt_product_name.Enabled = False
        Me.txt_product_name.Location = New System.Drawing.Point(176, 20)
        Me.txt_product_name.Name = "txt_product_name"
        Me.txt_product_name.Size = New System.Drawing.Size(174, 20)
        Me.txt_product_name.TabIndex = 30
        '
        'btn_save_details
        '
        Me.btn_save_details.BackColor = System.Drawing.Color.Transparent
        Me.btn_save_details.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save_details.Image = CType(resources.GetObject("btn_save_details.Image"), System.Drawing.Image)
        Me.btn_save_details.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_save_details.Location = New System.Drawing.Point(442, 19)
        Me.btn_save_details.Name = "btn_save_details"
        Me.btn_save_details.Size = New System.Drawing.Size(137, 35)
        Me.btn_save_details.TabIndex = 32
        Me.btn_save_details.Text = "Check Status"
        Me.btn_save_details.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_save_details.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(105, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 15)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Panel Size"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(785, 44)
        Me.Panel2.TabIndex = 20
        '
        'txt_panel_number
        '
        Me.txt_panel_number.Enabled = False
        Me.txt_panel_number.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_panel_number.Location = New System.Drawing.Point(176, 72)
        Me.txt_panel_number.Name = "txt_panel_number"
        Me.txt_panel_number.Size = New System.Drawing.Size(174, 23)
        Me.txt_panel_number.TabIndex = 19
        Me.txt_panel_number.Text = "28211011"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(83, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 15)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Panel Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(46, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Select Product Name"
        '
        'btn_generate_serial
        '
        Me.btn_generate_serial.BackColor = System.Drawing.Color.Transparent
        Me.btn_generate_serial.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generate_serial.Image = CType(resources.GetObject("btn_generate_serial.Image"), System.Drawing.Image)
        Me.btn_generate_serial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_generate_serial.Location = New System.Drawing.Point(442, 60)
        Me.btn_generate_serial.Name = "btn_generate_serial"
        Me.btn_generate_serial.Size = New System.Drawing.Size(137, 35)
        Me.btn_generate_serial.TabIndex = 15
        Me.btn_generate_serial.Text = "Serial Generate"
        Me.btn_generate_serial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_generate_serial.UseVisualStyleBackColor = False
        '
        'txt_quantity
        '
        Me.txt_quantity.Enabled = False
        Me.txt_quantity.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_quantity.Location = New System.Drawing.Point(176, 129)
        Me.txt_quantity.Name = "txt_quantity"
        Me.txt_quantity.Size = New System.Drawing.Size(121, 23)
        Me.txt_quantity.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(110, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Quantity"
        '
        'txt_serial_number
        '
        Me.txt_serial_number.Enabled = False
        Me.txt_serial_number.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_serial_number.Location = New System.Drawing.Point(176, 46)
        Me.txt_serial_number.Name = "txt_serial_number"
        Me.txt_serial_number.Size = New System.Drawing.Size(174, 23)
        Me.txt_serial_number.TabIndex = 12
        Me.txt_serial_number.Text = "012120"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Starting Serial Number"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel4.Controls.Add(Me.btn_save_details)
        Me.Panel4.Controls.Add(Me.btn_generate_serial)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.txt_serial_number)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.txt_quantity)
        Me.Panel4.Controls.Add(Me.txt_panel_size)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.txt_product_name)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.txt_panel_number)
        Me.Panel4.Location = New System.Drawing.Point(0, 44)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(783, 178)
        Me.Panel4.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(279, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(205, 19)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Serial Number Generation"
        '
        'serialgeneration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 223)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "serialgeneration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Serial Number Generation"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txt_panel_number As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_generate_serial As Button
    Friend WithEvents txt_quantity As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_serial_number As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_product_name As TextBox
    Friend WithEvents txt_panel_size As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents btn_save_details As Button
End Class
