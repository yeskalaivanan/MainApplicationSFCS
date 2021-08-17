Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.IO
Module Module1

    Public username, password As String
    Public usermode As String = "user"


    Public conn_stb As New MySqlConnection
    Public conn_stb_new As New MySqlConnection
    Public conn_server As New MySqlConnection

    Dim SDA As New MySqlDataAdapter
    Dim dbDataSet As New DataTable
    Dim dbDataSet_user As New DataTable
    Dim dbDataSet_search_pcb As New DataTable
    Dim dbDataSet_product_info As New DataTable
    Dim dbDataSet_stage_info As New DataTable

    Dim start1 As New Date(1947, 8, 15, 6, 0, 1)
    Dim start12 As New Date(1947, 8, 15, 14, 0, 0)
    Dim start2 As New Date(1947, 8, 15, 14, 0, 1)
    Dim start21 As New Date(1947, 8, 15, 22, 0, 0)
    Dim start3 As New Date(1947, 8, 15, 22, 0, 1)
    Dim start31 As New Date(1947, 8, 15, 6, 0, 0)

    Public shiftA_start As Date = Format(start1, "T")
    Public shiftA_finish As Date = Format(start12, "T")
    Public shiftB_start As Date = Format(start2, "T")
    Public shiftB_finish As Date = Format(start21, "T")
    Public shiftC_start As Date = Format(start3, "T")
    Public shiftC_finish As Date = Format(start31, "T")


    Dim bSource As New BindingSource
    Dim bSource_time_check As New BindingSource
    Dim CMD As New MySqlCommand

    Public productcode, product_name, target, startingserialnumber, finishingserialnumber As String
    Public g_p_code, g_s_version, g_p_name, g_lot_number, g_line_number, g_target, g_start_pcb_number, g_workorder, g_serial_number, g_panel_number As String
    Public line1, line2, line3, line4, line5, line6, line7, line8, line9 As String
    Public yield_aoi_timer As Boolean = False
    Public yield_wave_timer As Boolean = False
    Public yield_fg_timer As Boolean = False
    Public mytimestamp_sql As String

    Public result As Boolean = False
    Public Query As String
    Public backup_file_path As String
    Public remarks As String
    Public save_time As String = Format(Now, "dd-MM-yy")
    Public Stage_laser_marking As String = "LaserMarking"
    Public Stage_aoi As String = "AOI"
    Public Stage_rework As String = "REWORK"
    Public Stage_prewave As String = "PREWAVE"
    Public Stage_postwave As String = "POSTWAVE"
    Public Stage_touchupvi As String = "TOUCHUP/VI"
    Public Stage_router As String = "ROUTER"
    Public g_product_names(20) As String
    Public g_product_codes(20) As String
    Public g_product_sides(20) As String
    Public g_total_product_names As Integer
    Public g_product_location As Integer
    Public pcb_start_time As Date
    Public total_pcb_time As Integer
    Public pcb_timer_lock As Boolean = True
    Public shifting_time As String = "A"
    Public g_side As String = "TOP"
    Public g_panel_count As Integer
    Public g_CTtime As Integer
    Public g_hourly_target As Integer
    Public g_shift_target As Integer
    Public backup_product_name, backup_product_code, backup_version, backup_side, backup_panel, backup_cttime, backup_hourly_target, backup_shift_target, backup_workorder As String
    Public backup_serial_number, backup_panel_number As String
    Public backup_stage_1, backup_stage_2, backup_stage_3, backup_stage_4, backup_stage_5, backup_stage_6, backup_stage_7, backup_stage_8, backup_stage_9 As String
    Public aoi_yield As Integer = 0
    Public chart_downtime As Integer = 0
    Public actual_time, planned_time As TimeSpan
    Public actual_time_sec, planned_time_sec As Integer
    Public hourly_output_total(25) As Integer
    Public hourly_output_pass(25) As Integer
    Public wo_quantity As Integer
    Public g_stencil_part_no As String

    Public Sub conndb_stb()
        Try
            conn_stb_new = New MySqlConnection("datasource=10.1.73.90;port=3306;username=gopal;password=52k1BsydRq1den36;database=stbnew;")
            conn_stb_new.Open()
            mainform.ts_message.Text = "Successfully Configured Server Database"
        Catch ex As Exception
            MsgBox("Please Configure Database", MsgBoxStyle.Critical, "Database")
            mainform.ts_message.Text = "Error.Please check Network Cable"
        Finally
            conn_stb_new.Close()
        End Try
    End Sub
    Public Sub read_lasermarking()
        Dim dbDataSet_lasermarking As New DataTable
        Try
            conn_stb_new.Open()
            Query = "select * from lasermarking"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_lasermarking)
            bSource.DataSource = dbDataSet_lasermarking
            showdata.DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet_lasermarking)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_aoi()
        Dim dbDataSet_aoi As New DataTable
        Try
            conn_stb_new.Open()
            Query = "select * from aoi"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_aoi)
            bSource.DataSource = dbDataSet_aoi
            showdata.DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet_aoi)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_rework()
        Dim dbDataSet_rework As New DataTable
        Try
            conn_stb_new.Open()
            Query = "select * from rework"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_rework)
            bSource.DataSource = dbDataSet_rework
            showdata.DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet_rework)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_prewavesoldering()
        Dim dbDataSet_prewave As New DataTable
        Try
            conn_stb_new.Open()
            Query = "select * from prewavesoldering"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_prewave)
            bSource.DataSource = dbDataSet_prewave
            showdata.DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet_prewave)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_postwavesoldering()
        Dim dbDataSet_postwave As New DataTable
        Try
            conn_stb_new.Open()
            Query = "select * from postwavesoldering"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_postwave)
            bSource.DataSource = dbDataSet_postwave
            showdata.DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet_postwave)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_touchupvi()
        Dim dbDataSet_touchupvi As New DataTable
        Try
            conn_stb_new.Open()
            Dim Query As String
            Query = "select * from touchupvi"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_touchupvi)
            bSource.DataSource = dbDataSet_touchupvi
            showdata.DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet_touchupvi)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_router()
        Dim dbDataSet_router As New DataTable
        Try
            conn_stb_new.Open()
            Query = "select * from router"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_router)
            bSource.DataSource = dbDataSet_router
            showdata.DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet_router)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub user_check(username As String, password As String)
        'conn_server = New MySqlConnection("datasource=10.1.73.90;port=3306;username=gopal;password=52k1BsydRq1den36;database=server;")
        CMD = New MySqlCommand("select * from users where username='" + username + "' and password = '" + password + "'", conn_stb_new)
        SDA = New MySqlDataAdapter(CMD)
        SDA.Fill(dbDataSet_user)
        bSource.DataSource = dbDataSet_user
        LoginForm1.DataGridView1.DataSource = bSource
        SDA.Update(dbDataSet_user)

        If dbDataSet_user.Rows.Count > 0 Then
            'MessageBox.Show("Login Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            usermode = LoginForm1.DataGridView1.Rows(0).Cells(2).Value.ToString
            mainform.ToolStripStatusLabel1.Text = usermode & " : " & username
            'log_user_details()
            loginwindowformclear()
            LoginForm1.Hide()
            mainform.dg_workorder.Visible = True
        Else
            MessageBox.Show("Error", "Information", MessageBoxButtons.OK, MessageBoxIcon.Question)
            mainform.ToolStripStatusLabel1.Text = "No login"
            usermode = "none"
            LoginForm1.PasswordTextBox.Text = ""
        End If

        SDA.Dispose()
        dbDataSet_user.Clear()
        conn_stb_new.Dispose()
        active_form()

    End Sub
    Public Sub active_form()
        If usermode = "Admin" Or usermode = "admin" Then
            mainform.WindowsMenu.Enabled = True
            mainform.HelpMenu.Enabled = True
            mainform.DatabaseToolStripMenuItem.Enabled = True
            mainform.ProductInfoToolStripMenuItem.Enabled = True
            mainform.SettingsToolStripMenuItem.Enabled = True
            mainform.YieldToolStripMenuItem1.Enabled = True
        ElseIf usermode = "User" Or usermode = "user" Then
            mainform.WindowsMenu.Enabled = True
            mainform.HelpMenu.Enabled = True
            mainform.DatabaseToolStripMenuItem.Enabled = True
            mainform.ProductInfoToolStripMenuItem.Enabled = True
            mainform.SettingsToolStripMenuItem.Enabled = False
            mainform.YieldToolStripMenuItem1.Enabled = False
        End If
    End Sub
    Public Sub disable_menus()
        mainform.WindowsMenu.Enabled = False
        mainform.HelpMenu.Enabled = False
        mainform.DatabaseToolStripMenuItem.Enabled = False
        mainform.ProductInfoToolStripMenuItem.Enabled = False
        mainform.SettingsToolStripMenuItem.Enabled = False
        mainform.YieldToolStripMenuItem1.Enabled = False
    End Sub
    Public Sub searchbutton()
        'TryCast(showdata.DataGridView1.DataSource, DataTable).DefaultView.RowFilter =
        '    String.Format("PCB_Sno like '%" & showdata.TextBox1.Text & "%'")
        Dim k As New DataView(dbDataSet)
        k.RowFilter = String.Format("PcbSerialNumber like '%{0}%'", showdata.TextBox1.Text)
        showdata.DataGridView1.DataSource = k
        'dbDataSet.DefaultView.RowFilter = showdata.ComboBox1.Text + " like " + "'" + showdata.TextBox1.Text + "'"
    End Sub
    Public Sub loginwindowformclear()
        LoginForm1.UsernameTextBox.Text = ""
        LoginForm1.PasswordTextBox.Text = ""
    End Sub
    Public Sub aoi_save(pcb_sno As String, p_code As String, p_name As String, lot_no As String, line_no As String, stage As String, status As String, remarks As String)
        Try
            Query = "insert into aoi(PcbSerialNumber,ProductCode,ProductName,WorkOrder,Side,Lotno,Lineno,Stage,Status,Remarks,Time,User,Shift)values('" & pcb_sno & "','" & p_code & "','" & p_name & "','" & g_workorder & "','" & g_side & "','" & lot_no & "','" & line_no & "','" & stage & "','" & status & "','" & remarks & "','" & mytimestamp_sql & "','" & username & "','" & shifting_time & "')"
            conn_stb_new.Open()
            CMD = New MySqlCommand(Query, conn_stb_new)
            Dim dr As MySqlDataReader
            dr = CMD.ExecuteReader()
            MsgBox("Data saved successfully", vbInformation)
            mainform.ts_message.Text = "Data saved successfully"
            save_csv_aoi()
            AOI.txt_pcbsno.Text = ""
            AOI.rtxt_remarks.Text = ""
        Catch ex As Exception
            mainform.ts_message.Text = ex.Message
            MsgBox(ex.Message, vbCritical)
        Finally
            CMD.Dispose()
            conn_stb_new.Close()
        End Try
    End Sub
    Public Sub rework_save(pcb_sno As String, p_code As String, p_name As String, lot_no As String, line_no As String, stage As String, status As String, remarks As String)
        Try
            Query = "insert into rework(PcbSerialNumber,ProductCode,ProductName,Lotno,Lineno,Stage,Status,Remarks,Time,User,Shift)values('" & pcb_sno & "','" & p_code & "','" & p_name & "','" & lot_no & "','" & line_no & "','" & stage & "','" & status & "','" & remarks & "','" & mytimestamp_sql & "','" & username & "','" & shifting_time & "')"
            conn_stb_new.Open()
            CMD = New MySqlCommand(Query, conn_stb_new)
            Dim dr As MySqlDataReader
            dr = CMD.ExecuteReader()
            MsgBox("Data saved successfully", vbInformation, "Database")
            mainform.ts_message.Text = "Data saved successfully"
            save_csv_rework()
            rework.txt_pcbsno.Text = ""
            rework.rtxt_remarks.Text = ""
        Catch ex As Exception
            mainform.ts_message.Text = ex.Message
            MsgBox(ex.Message, vbCritical)
        Finally
            CMD.Dispose()
            conn_stb_new.Close()
        End Try
    End Sub
    Public Sub prewave_save(pcb_sno As String, p_code As String, p_name As String, lot_no As String, line_no As String, stage As String, status As String, remarks As String)
        remarks = prewavesoldering.cmb_remarks.SelectedItem & " " & prewavesoldering.rtxt_remarks.Text
        remarks = remarks.TrimEnd
        Try
            Query = "insert into prewavesoldering(PcbSerialNumber,ProductCode,ProductName,Lotno,Lineno,Stage,Status,Remarks,Time,User,Shift)values('" & pcb_sno & "','" & p_code & "','" & p_name & "','" & lot_no & "','" & line_no & "','" & stage & "','" & status & "','" & remarks & "','" & mytimestamp_sql & "','" & username & "','" & shifting_time & "')"
            conn_stb_new.Open()
            CMD = New MySqlCommand(Query, conn_stb_new)
            Dim dr As MySqlDataReader
            dr = CMD.ExecuteReader()
            MsgBox("Data saved successfully", vbInformation, "Database")
            mainform.ts_message.Text = "Data saved successfully"
            save_csv_prewave()
            prewavesoldering.txt_pcbsno.Text = ""
            prewavesoldering.rtxt_remarks.Text = ""
        Catch ex As Exception
            mainform.ts_message.Text = ex.Message
            MsgBox(ex.Message, vbCritical)
        Finally
            CMD.Dispose()
            conn_stb_new.Close()
        End Try
    End Sub
    Public Sub postwave_save(pcb_sno As String, p_code As String, p_name As String, lot_no As String, line_no As String, stage As String, status As String, remarks As String)
        remarks = postwavesoldering.cmb_remarks.SelectedItem & " " & postwavesoldering.rtxt_remarks.Text
        remarks = remarks.TrimEnd
        Try
            Query = "insert into postwavesoldering(PcbSerialNumber,ProductCode,ProductName,Lotno,Lineno,Stage,Status,Remarks,Time,User,shift)values('" & pcb_sno & "','" & p_code & "','" & p_name & "','" & lot_no & "','" & line_no & "','" & stage & "','" & status & "','" & remarks & "','" & mytimestamp_sql & "','" & username & "','" & shifting_time & "')"
            conn_stb_new.Open()
            CMD = New MySqlCommand(Query, conn_stb_new)
            Dim dr As MySqlDataReader
            dr = CMD.ExecuteReader()
            MsgBox("Data saved successfully", vbInformation, "Database")
            mainform.ts_message.Text = "Data saved successfully"
            save_csv_postwave()
            postwavesoldering.txt_pcbsno.Text = ""
            postwavesoldering.rtxt_remarks.Text = ""
        Catch ex As Exception
            mainform.ts_message.Text = ex.Message
            MsgBox(ex.Message, vbCritical)
        Finally
            CMD.Dispose()
            conn_stb_new.Close()
        End Try
    End Sub
    Public Sub touchupvi_save(pcb_sno As String, p_code As String, p_name As String, lot_no As String, line_no As String, stage As String, status As String, remarks As String)
        remarks = touchupvi.cmb_remarks.SelectedItem & " " & touchupvi.rtxt_remarks.Text
        remarks = remarks.TrimEnd
        Try
            Query = "insert into touchupvi(PcbSerialNumber,ProductCode,ProductName,Lotno,Lineno,Stage,Status,Remarks,Time,User,Shift)values('" & pcb_sno & "','" & p_code & "','" & p_name & "','" & lot_no & "','" & line_no & "','" & stage & "','" & status & "','" & remarks & "','" & mytimestamp_sql & "','" & username & "','" & shifting_time & "')"
            conn_stb_new.Open()
            CMD = New MySqlCommand(Query, conn_stb_new)
            Dim dr As MySqlDataReader
            dr = CMD.ExecuteReader()
            MsgBox("Data saved successfully", vbInformation, "Database")
            mainform.ts_message.Text = "Data saved successfully"
            save_csv_touchupvi()
            touchupvi.txt_pcbsno.Text = ""
            touchupvi.rtxt_remarks.Text = ""
        Catch ex As Exception
            mainform.ts_message.Text = ex.Message
            MsgBox(ex.Message, vbCritical)
        Finally
            CMD.Dispose()
            conn_stb_new.Close()
        End Try
    End Sub
    Public Sub router_save(pcb_sno As String, p_code As String, p_name As String, lot_no As String, line_no As String, stage As String, status As String, remarks As String)
        remarks = router.cmb_remarks.SelectedItem & " " & router.rtxt_remarks.Text
        remarks = remarks.TrimEnd
        Try
            Query = "insert into router(PcbSerialNumber,ProductCode,ProductName,Lotno,Lineno,Stage,Status,Remarks,Time,User,Shift)values('" & pcb_sno & "','" & p_code & "','" & p_name & "','" & lot_no & "','" & line_no & "','" & stage & "','" & status & "','" & remarks & "','" & mytimestamp_sql & "','" & username & "','" & shifting_time & "')"
            conn_stb_new.Open()
            CMD = New MySqlCommand(Query, conn_stb_new)
            Dim dr As MySqlDataReader
            dr = CMD.ExecuteReader()
            MsgBox("Data saved successfully", vbInformation, "Database")
            mainform.ts_message.Text = "Data saved successfully"
            save_csv_router()
            router.txt_pcbsno.Text = ""
            router.rtxt_remarks.Text = ""
        Catch ex As Exception
            mainform.ts_message.Text = ex.Message
            MsgBox(ex.Message, vbCritical)
        Finally
            CMD.Dispose()
            conn_stb_new.Close()
        End Try
    End Sub
    Public Sub read_local_txt_product_details()
        Dim appPath As String = Application.StartupPath()
        Dim FILE_NAME As String = appPath & "/Documents/productdetails.txt"
        Dim TextLine As String = ""
        Dim txt_data(10) As String
        Dim strArr() As String
        Dim count As Integer = 0
        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim objReader As New System.IO.StreamReader(FILE_NAME)
            Do While objReader.Peek() <> -1
                TextLine = TextLine & objReader.ReadLine() & vbNewLine
                strArr = TextLine.Split(",")
                txt_data(count) = strArr(strArr.Length - 1)
                count = count + 1
            Loop
            objReader.Close()
            g_line_number = txt_data(0).TrimEnd
            'productcode = txt_data(0).TrimEnd
            g_p_name = txt_data(1).TrimEnd
            'target = txt_data(2).TrimEnd
            'startingserialnumber = txt_data(3).TrimEnd

        Else
            MsgBox("File Does Not Exist", vbCritical, "Error")
        End If
    End Sub
    Public Sub read_yield_aoi_pass()
        Dim READER As MySqlDataReader
        Dim count As Integer = 0
        Try
            conn_stb_new.Open()
            Query = "Select * from aoi WHERE Status='PASS'"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader

            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            'Yieldaoi.txt_pass_count.Text = count
            FrmDashboard1.txt_pass_count.Text = count
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_yield_aoi_rpass()
        Dim READER As MySqlDataReader
        Dim count As Integer = 0

        Try
            conn_stb_new.Open()
            Query = "Select * from aoi WHERE Status='RPASS'"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader

            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            'Yieldaoi.txt_pass_count.Text = count
            FrmDashboard1.txt_rpass_count.Text = count
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_yield_postwave_pass()
        Dim READER As MySqlDataReader
        Dim count As Integer = 0

        Try
            conn_stb_new.Open()
            Query = "Select * from postwavesoldering WHERE Status='PASS'"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader

            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            yieldpostwave.txt_pass_count.Text = count
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_yield_fg_pass()
        Dim READER As MySqlDataReader
        Dim count As Integer = 0

        Try
            conn_stb_new.Open()
            Query = "Select * from router WHERE Status='PASS'"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader

            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            yieldfg.txt_pass_count.Text = count
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_yield_aoi_fail()

        Dim READER As MySqlDataReader
        Try
            conn_stb_new.Open()
            Dim Query As String

            Query = "Select * from aoi WHERE Status='FAIL'"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            'Yieldaoi.txt_fail_count.Text = count
            FrmDashboard1.txt_fail_count.Text = count
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_yield_postwave_fail()

        Dim READER As MySqlDataReader
        Try
            conn_stb_new.Open()
            Dim Query As String

            Query = "Select * from postwavesoldering WHERE Status='FAIL'"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            yieldpostwave.txt_fail_count.Text = count
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_yield_fg_fail()

        Dim READER As MySqlDataReader
        Try
            conn_stb_new.Open()
            Dim Query As String

            Query = "Select * from router WHERE Status='FAIL'"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            yieldfg.txt_fail_count.Text = count
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_yield_aoi_total()
        Dim READER As MySqlDataReader

        Try
            conn_stb_new.Open()
            Dim Query As String

            Query = "Select * from aoi"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            'Yieldaoi.txt_total_count.Text = count
            FrmDashboard1.txt_total_count.Text = count

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_yield_postwave_total()
        Dim READER As MySqlDataReader

        Try
            conn_stb_new.Open()
            Dim Query As String

            Query = "Select * from postwavesoldering"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            yieldpostwave.txt_total_count.Text = count

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Sub read_yield_fg_total()
        Dim READER As MySqlDataReader

        Try
            conn_stb_new.Open()
            Dim Query As String

            Query = "Select * from router"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            yieldfg.txt_total_count.Text = count

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Function check_serialnumber_lasermarking(sno As String) As Boolean
        conn_server = New MySqlConnection("datasource=10.1.73.90;port=3306;username=gopal;password=52k1BsydRq1den36;database=stbnew;")
        Dim result As Boolean
        CMD = New MySqlCommand("select * from lasermarking where PcbSerialNumber = '" + sno + "'", conn_server)
        SDA = New MySqlDataAdapter(CMD)
        SDA.Fill(dbDataSet)

        If dbDataSet.Rows.Count > 0 Then
            result = 1
        Else
            result = 0
        End If

        SDA.Dispose()
        conn_server.Dispose()
        dbDataSet.Clear()
        Return result
    End Function
    Function check_serialnumber_aoi(sno As String) As Boolean
        conn_server = New MySqlConnection("datasource=10.1.73.90;port=3306;username=gopal;password=52k1BsydRq1den36;database=stbnew;")
        Dim variable As String = "PASS"
        Dim result As Boolean
        CMD = New MySqlCommand("select * from aoi where PcbSerialNumber = '" + sno + "' and Status = '" + variable + "'", conn_server)
        SDA = New MySqlDataAdapter(CMD)
        SDA.Fill(dbDataSet)

        If dbDataSet.Rows.Count > 0 Then
            result = 1
        Else
            result = 0
        End If

        SDA.Dispose()
        conn_server.Dispose()
        dbDataSet.Clear()
        Return result
    End Function
    Function check_serialnumber_prewave(sno As String) As Boolean
        conn_server = New MySqlConnection("datasource=10.1.73.90;port=3306;username=gopal;password=52k1BsydRq1den36;database=stbnew;")
        Dim variable As String = "PASS"
        Dim result As Boolean
        CMD = New MySqlCommand("select * from prewavesoldering where PcbSerialNumber = '" + sno + "' and Status = '" + variable + "'", conn_server)
        SDA = New MySqlDataAdapter(CMD)
        SDA.Fill(dbDataSet)

        If dbDataSet.Rows.Count > 0 Then
            result = 1
        Else
            result = 0
        End If

        SDA.Dispose()
        conn_server.Dispose()
        dbDataSet.Clear()
        Return result
    End Function
    Function check_serialnumber_postwave(sno As String) As Boolean
        conn_server = New MySqlConnection("datasource=10.1.73.90;port=3306;username=gopal;password=52k1BsydRq1den36;database=stbnew;")
        Dim variable As String = "PASS"
        Dim result_value As Boolean
        CMD = New MySqlCommand("select * from postwavesoldering where PcbSerialNumber = '" + sno + "' and Status = '" + variable + "'", conn_server)
        SDA = New MySqlDataAdapter(CMD)
        SDA.Fill(dbDataSet)

        If dbDataSet.Rows.Count > 0 Then
            result_value = 1
        Else
            result_value = 0
        End If

        SDA.Dispose()
        conn_server.Dispose()
        dbDataSet.Clear()
        Return result_value
    End Function
    Function check_serialnumber_touchupvi(sno As String) As Boolean
        conn_server = New MySqlConnection("datasource=10.1.73.90;port=3306;username=gopal;password=52k1BsydRq1den36;database=stbnew;")
        Dim variable As String = "PASS"
        Dim result_value As Boolean
        CMD = New MySqlCommand("select * from touchupvi where PcbSerialNumber = '" + sno + "' and Status = '" + variable + "'", conn_server)
        SDA = New MySqlDataAdapter(CMD)
        SDA.Fill(dbDataSet)

        If dbDataSet.Rows.Count > 0 Then
            result_value = 1
        Else
            result_value = 0
        End If

        SDA.Dispose()
        conn_server.Dispose()
        dbDataSet.Clear()
        Return result_value
    End Function
    Public Sub update_aoi(sno As String)
        Dim Query As String
        remarks = AOI.cmb_remarks.SelectedItem & " " & AOI.rtxt_remarks.Text
        remarks = remarks.TrimEnd
        Query = "Update aoi Set ProductCode = '" & AOI.txt_product_code.Text & "',ProductName = '" & AOI.txt_product_name.Text & "',WorkOrder = '" & AOI.txt_workorder.Text & "', Stage = '" & Stage_aoi & "' , Status = '" & AOI.cmb_status.Text & "' ,Remarks = '" & remarks & "', Time = '" & mytimestamp_sql & "',User = '" & username & "', Shift = '" & shifting_time & "'    where PcbSerialNumber =  '" & sno & "'   "
        ExecuteQuery(Query)
        'update_csv_aoi()
        save_csv_aoi()
        AOI.txt_pcbsno.Text = ""
        AOI.rtxt_remarks.Text = ""
    End Sub
    Public Sub update_rework(sno As String)
        Dim Query As String
        remarks = rework.cmb_remarks.SelectedItem & " " & rework.rtxt_remarks.Text
        remarks = remarks.TrimEnd
        Query = "Update rework Set ProductCode = '" & rework.txt_product_code.Text & "',ProductName = '" & rework.txt_product_name.Text & "' , Stage = '" & Stage_rework & "' , Status = '" & rework.cmb_status.Text & "' ,Remarks = '" & remarks & "', Time = '" & mytimestamp_sql & "',User = '" & username & "', Shift = '" & shifting_time & "' where PcbSerialNumber =  '" & sno & "'   "
        ExecuteQuery(Query)
        'update_csv_rework()
        save_csv_rework()
        rework.txt_pcbsno.Text = ""
        rework.rtxt_remarks.Text = ""
    End Sub
    Public Sub update_prewave(sno As String)
        Dim Query As String
        remarks = prewavesoldering.cmb_remarks.SelectedItem & " " & prewavesoldering.rtxt_remarks.Text
        remarks = remarks.TrimEnd
        Query = "Update prewavesoldering Set ProductCode = '" & prewavesoldering.txt_product_code.Text & "',ProductName = '" & prewavesoldering.txt_product_name.Text & "' ,Stage = '" & Stage_prewave & "' ,Status = '" & prewavesoldering.cmb_status.Text & "' ,Remarks = '" & remarks & "', Time = '" & mytimestamp_sql & "',User = '" & username & "', Shift = '" & shifting_time & "' where PcbSerialNumber =  '" & sno & "'   "
        ExecuteQuery(Query)
        'update_csv_prewave()
        save_csv_prewave()
        prewavesoldering.txt_pcbsno.Text = ""
        prewavesoldering.rtxt_remarks.Text = ""
    End Sub
    Public Sub update_postwave(sno As String)
        Dim Query As String
        remarks = postwavesoldering.cmb_remarks.SelectedItem & " " & postwavesoldering.rtxt_remarks.Text
        remarks = remarks.TrimEnd
        Query = "Update postwavesoldering Set ProductCode = '" & postwavesoldering.txt_product_code.Text & "',ProductName = '" & postwavesoldering.txt_product_name.Text & "' ,Stage = '" & Stage_postwave & "' ,Status = '" & postwavesoldering.cmb_status.Text & "' ,Remarks = '" & remarks & "', Time = '" & mytimestamp_sql & "',User = '" & username & "', Shift = '" & shifting_time & "' where PcbSerialNumber =  '" & sno & "'   "
        ExecuteQuery(Query)
        'update_csv_postwave()
        save_csv_postwave()
        postwavesoldering.txt_pcbsno.Text = ""
        postwavesoldering.rtxt_remarks.Text = ""
    End Sub
    Public Sub update_touchupvi(sno As String)
        Dim Query As String
        remarks = touchupvi.cmb_remarks.SelectedItem & " " & touchupvi.rtxt_remarks.Text
        remarks = remarks.TrimEnd
        Query = "Update touchupvi Set ProductCode = '" & touchupvi.txt_product_code.Text & "',ProductName = '" & touchupvi.txt_product_name.Text & "' ,Stage = '" & Stage_touchupvi & "' ,Status = '" & touchupvi.cmb_status.Text & "' ,Remarks = '" & remarks & "', Time = '" & mytimestamp_sql & "',User = '" & username & "', Shift = '" & shifting_time & "' where PcbSerialNumber =   '" & sno & "'   "
        ExecuteQuery(Query)
        'update_csv_touchupvi()
        save_csv_touchupvi()
        touchupvi.txt_pcbsno.Text = ""
        touchupvi.rtxt_remarks.Text = ""
    End Sub
    Public Sub update_router(sno As String)
        Dim Query As String
        remarks = router.cmb_remarks.SelectedItem & " " & router.rtxt_remarks.Text
        remarks = remarks.TrimEnd
        Query = "Update router Set ProductCode = '" & router.txt_product_code.Text & "',ProductName = '" & router.txt_product_name.Text & "' ,Stage = '" & Stage_router & "' ,Status = '" & router.cmb_status.Text & "' ,Remarks = '" & remarks & "', Time = '" & mytimestamp_sql & "',User = '" & username & "', Shift = '" & shifting_time & "' where PcbSerialNumber =   '" & sno & "'   "
        ExecuteQuery(Query)
        'update_csv_router()
        save_csv_router()
        router.txt_pcbsno.Text = ""
        router.rtxt_remarks.Text = ""
    End Sub
    Public Sub ExecuteQuery(query As String)
        Dim command As New MySqlCommand(query, conn_stb_new)
        Try
            conn_stb_new.Open()
            command.ExecuteNonQuery()
            MsgBox("Data saved successfully", vbInformation, "Database")
            mainform.ts_message.Text = "Data Updated Successfully"
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            mainform.ts_message.Text = ex.Message
        Finally
            conn_stb_new.Close()
        End Try
    End Sub

    Public Sub save_csv_aoi()
        Dim filepath As StreamWriter
        remarks = AOI.cmb_remarks.SelectedItem & " " & AOI.rtxt_remarks.Text
        remarks.TrimEnd()
        filepath = File.AppendText(backup_file_path & "\AOI-" & save_time & ".csv")
        filepath.WriteLine(AOI.txt_pcbsno.Text & "," & AOI.txt_product_code.Text & "," & AOI.txt_product_name.Text & "," & AOI.txt_lot_no.Text & "," & AOI.txt_line_no.Text & "," & AOI.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username & "," & shifting_time)
        filepath.Close()
    End Sub
    Public Sub save_csv_rework()
        Dim filepath As StreamWriter
        remarks = rework.cmb_remarks.SelectedItem & " " & rework.rtxt_remarks.Text
        remarks.TrimEnd()
        filepath = File.AppendText(backup_file_path & "\REWORK-" & save_time & ".csv")
        filepath.WriteLine(rework.txt_pcbsno.Text & "," & rework.txt_product_code.Text & "," & rework.txt_product_name.Text & ",," & rework.txt_lot_no.Text & "," & rework.txt_line_no.Text & "" & rework.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username & "," & shifting_time)
        filepath.Close()
    End Sub
    Public Sub save_csv_prewave()
        Dim filepath As StreamWriter
        remarks = prewavesoldering.cmb_remarks.SelectedItem & " " & prewavesoldering.rtxt_remarks.Text
        remarks.TrimEnd()
        filepath = File.AppendText(backup_file_path & "\PREWAVE-" & save_time & ".csv")
        filepath.WriteLine(prewavesoldering.txt_pcbsno.Text & "," & prewavesoldering.txt_product_code.Text & "," & prewavesoldering.txt_product_name.Text & ",," & prewavesoldering.txt_lot_no.Text & "," & prewavesoldering.txt_line_no.Text & "" & prewavesoldering.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username & "," & shifting_time)
        filepath.Close()
    End Sub
    Public Sub save_csv_postwave()
        Dim filepath As StreamWriter
        remarks = postwavesoldering.cmb_remarks.SelectedItem & " " & postwavesoldering.rtxt_remarks.Text
        remarks.TrimEnd()
        filepath = File.AppendText(backup_file_path & "\POSTWAVE-" & save_time & ".csv")
        filepath.WriteLine(postwavesoldering.txt_pcbsno.Text & "," & postwavesoldering.txt_product_code.Text & "," & postwavesoldering.txt_product_name.Text & "," & postwavesoldering.txt_lot_no.Text & "," & postwavesoldering.txt_line_no.Text & "," & postwavesoldering.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username & "," & shifting_time)
        filepath.Close()
    End Sub
    Public Sub save_csv_touchupvi()
        Dim filepath As StreamWriter
        remarks = touchupvi.cmb_remarks.SelectedItem & " " & touchupvi.rtxt_remarks.Text
        remarks.TrimEnd()
        filepath = File.AppendText(backup_file_path & "\TOUCHUPVI-" & save_time & ".csv")
        filepath.WriteLine(touchupvi.txt_pcbsno.Text & "," & touchupvi.txt_product_code.Text & "," & touchupvi.txt_product_name.Text & "," & touchupvi.txt_lot_no.Text & "," & touchupvi.txt_line_no.Text & "," & touchupvi.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username & "," & shifting_time)
        filepath.Close()
    End Sub
    Public Sub save_csv_router()
        Dim filepath As StreamWriter
        remarks = router.cmb_remarks.SelectedItem & " " & router.rtxt_remarks.Text
        remarks.TrimEnd()
        filepath = File.AppendText(backup_file_path & "\ROUTER-" & save_time & ".csv")
        filepath.WriteLine(router.txt_pcbsno.Text & "," & router.txt_product_code.Text & "," & router.txt_product_name.Text & "," & router.txt_lot_no.Text & "," & router.txt_line_no.Text & "," & router.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username & "," & shifting_time)
        filepath.Close()
    End Sub
    'Public Sub update_csv_aoi()
    '    Dim filepath As StreamWriter
    '    remarks = AOI.cmb_remarks.SelectedItem & " " & AOI.rtxt_remarks.Text
    '    remarks.TrimEnd()
    '    filepath = File.AppendText(backup_file_path & "\AOI-UPDATE-" & save_time & ".csv")
    '    filepath.WriteLine(AOI.txt_pcbsno.Text & "," & AOI.txt_product_code.Text & "," & AOI.txt_product_name.Text & "," & AOI.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username)
    '    filepath.Close()
    'End Sub
    'Public Sub update_csv_rework()
    '    Dim filepath As StreamWriter
    '    remarks = rework.cmb_remarks.SelectedItem & " " & rework.rtxt_remarks.Text
    '    remarks.TrimEnd()
    '    filepath = File.AppendText(backup_file_path & "\REWORK-UPDATE-" & save_time & ".csv")
    '    filepath.WriteLine(rework.txt_pcbsno.Text & "," & rework.txt_product_code.Text & "," & rework.txt_product_name.Text & "," & rework.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username)
    '    filepath.Close()
    'End Sub
    'Public Sub update_csv_prewave()
    '    Dim filepath As StreamWriter
    '    remarks = prewavesoldering.cmb_remarks.SelectedItem & " " & prewavesoldering.rtxt_remarks.Text
    '    remarks.TrimEnd()
    '    filepath = File.AppendText(backup_file_path & "\PREWAVE-UPDATE-" & save_time & ".csv")
    '    filepath.WriteLine(prewavesoldering.txt_pcbsno.Text & "," & prewavesoldering.txt_product_code.Text & "," & prewavesoldering.txt_product_name.Text & "," & prewavesoldering.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username)
    '    filepath.Close()
    'End Sub
    'Public Sub update_csv_postwave()
    '    Dim filepath As StreamWriter
    '    remarks = postwavesoldering.cmb_remarks.SelectedItem & " " & postwavesoldering.rtxt_remarks.Text
    '    remarks.TrimEnd()
    '    filepath = File.AppendText(backup_file_path & "\POSTWAVE-UPDATE" & save_time & ".csv")
    '    filepath.WriteLine(postwavesoldering.txt_pcbsno.Text & "," & postwavesoldering.txt_product_code.Text & "," & postwavesoldering.txt_product_name.Text & "," & postwavesoldering.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username)
    '    filepath.Close()
    'End Sub
    'Public Sub update_csv_touchupvi()
    '    Dim filepath As StreamWriter
    '    remarks = touchupvi.cmb_remarks.SelectedItem & " " & touchupvi.rtxt_remarks.Text
    '    remarks.TrimEnd()
    '    filepath = File.AppendText(backup_file_path & "\TOUCHUPVI-UPDATE" & save_time & ".csv")
    '    filepath.WriteLine(touchupvi.txt_pcbsno.Text & "," & touchupvi.txt_product_code.Text & "," & touchupvi.txt_product_name.Text & "," & touchupvi.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username)
    '    filepath.Close()
    'End Sub
    'Public Sub update_csv_router()
    '    Dim filepath As StreamWriter
    '    remarks = router.cmb_remarks.SelectedItem & " " & router.rtxt_remarks.Text
    '    remarks.TrimEnd()
    '    filepath = File.AppendText(backup_file_path & "\ROUTER-UPDATE" & save_time & ".csv")
    '    filepath.WriteLine(router.txt_pcbsno.Text & "," & router.txt_product_code.Text & "," & router.txt_product_name.Text & "," & router.cmb_status.SelectedItem & "," & remarks & "," & mytimestamp_sql & "," & username)
    '    filepath.Close()
    'End Sub
    Function add_user(name As String, password As String, access_level As String)
        Try
            Query = "insert into users(username,password,accesslevel,time)values('" & name & "','" & password & "','" & access_level & "','" & mytimestamp_sql & "')"
            conn_stb_new.Open()
            CMD = New MySqlCommand(Query, conn_stb_new)
            Dim dr As MySqlDataReader
            dr = CMD.ExecuteReader()
            MsgBox("User Added successfully", vbInformation, "Access")
            mainform.ts_message.Text = "User Added successfully"
            adduser.txt_add_user.Text = ""
            adduser.txt_add_password.Text = ""
            adduser.txt_add_confirm_password.Text = ""
        Catch ex As Exception
            mainform.ts_message.Text = ex.Message
            MsgBox(ex.Message, vbCritical)
        Finally
            CMD.Dispose()
            conn_stb_new.Close()
        End Try
        Return 0
    End Function
    Function update_user(user As String, old_password As String, new_password As String, access_level As String)
        Dim reply As Boolean
        Dim Query As String

        reply = check_user(user, old_password)

        If reply = True Then
            Query = "Update users Set password = '" & new_password & "',accesslevel = '" & access_level & "',time = '" & mytimestamp_sql & "' where username =  '" & user & "' and password =  '" & old_password & "'   "
            ExecuteQuery_updateuser(Query)
            changepassword.txt_user_name.Text = ""
            changepassword.txt_old_password.Text = ""
            changepassword.txt_new_password.Text = ""
        Else
            MsgBox("Username or Password is not Matching", vbCritical, "Error")
        End If
        Return 0
    End Function
    Public Sub ExecuteQuery_updateuser(query As String)
        Dim command As New MySqlCommand(query, conn_stb_new)
        Try
            conn_stb_new.Open()
            command.ExecuteNonQuery()
            MsgBox("Data saved successfully", vbInformation, "Database")
            mainform.ts_message.Text = "Data Updated Successfully"
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            mainform.ts_message.Text = ex.Message
        Finally
            conn_stb_new.Close()
        End Try
    End Sub
    Function check_user(user As String, password As String) As Boolean
        Dim result_value As Boolean
        CMD = New MySqlCommand("select * from users where username = '" + user + "' and password = '" + password + "'", conn_stb_new)
        SDA = New MySqlDataAdapter(CMD)
        SDA.Fill(dbDataSet)

        If dbDataSet.Rows.Count > 0 Then
            result_value = 1
        Else
            result_value = 0
        End If

        SDA.Dispose()
        conn_stb_new.Dispose()
        dbDataSet.Clear()
        Return result_value
    End Function

    Function search_pcb(sno As String)
        conn_stb_new.Open()
        Dim connection As Boolean = False
        dbDataSet_search_pcb.Clear()
        Try
            CMD = New MySqlCommand("select * from aoi where PcbSerialNumber='" + sno + "'", conn_stb_new)
            SDA = New MySqlDataAdapter(CMD)
            SDA.Fill(dbDataSet_search_pcb)
            bSource.DataSource = dbDataSet_search_pcb
            status.DataGridView1.DataSource = bSource
            'status.ListView1.datasource = bSource
            SDA.Update(dbDataSet_search_pcb)
            connection = True
        Catch ex As Exception
            MsgBox("PCB Not yet Received in AOI Stage")
        End Try

        If connection = True Then
            Try
                CMD = New MySqlCommand("select * from rework where PcbSerialNumber='" + sno + "'", conn_stb_new)
                SDA = New MySqlDataAdapter(CMD)
                SDA.Fill(dbDataSet_search_pcb)
                bSource.DataSource = dbDataSet_search_pcb
                status.DataGridView1.DataSource = bSource
                SDA.Update(dbDataSet_search_pcb)
            Catch ex As Exception
                'MsgBox("PCB Not yet Received")
                connection = False
            End Try
        End If

        If connection = True Then
            Try
                CMD = New MySqlCommand("select * from prewavesoldering where PcbSerialNumber='" + sno + "'", conn_stb_new)
                SDA = New MySqlDataAdapter(CMD)
                SDA.Fill(dbDataSet_search_pcb)
                bSource.DataSource = dbDataSet_search_pcb
                status.DataGridView1.DataSource = bSource
                SDA.Update(dbDataSet_search_pcb)
            Catch ex As Exception
                'MsgBox(ex.Message)
                connection = False
            End Try
        End If

        If connection = True Then
            Try
                CMD = New MySqlCommand("select * from postwavesoldering where PcbSerialNumber='" + sno + "'", conn_stb_new)
                SDA = New MySqlDataAdapter(CMD)
                SDA.Fill(dbDataSet_search_pcb)
                bSource.DataSource = dbDataSet_search_pcb
                status.DataGridView1.DataSource = bSource
                SDA.Update(dbDataSet_search_pcb)
            Catch ex As Exception
                'MsgBox(ex.Message)
                connection = False
            End Try
        End If

        If connection = True Then
            Try
                CMD = New MySqlCommand("select * from touchupvi where PcbSerialNumber='" + sno + "'", conn_stb_new)
                SDA = New MySqlDataAdapter(CMD)
                SDA.Fill(dbDataSet_search_pcb)
                bSource.DataSource = dbDataSet_search_pcb
                status.DataGridView1.DataSource = bSource
                SDA.Update(dbDataSet_search_pcb)
            Catch ex As Exception
                'MsgBox(ex.Message)
                connection = False
            End Try
        End If

        If connection = True Then
            Try
                CMD = New MySqlCommand("select * from router where PcbSerialNumber='" + sno + "'", conn_stb_new)
                SDA = New MySqlDataAdapter(CMD)
                SDA.Fill(dbDataSet_search_pcb)
                bSource.DataSource = dbDataSet_search_pcb
                status.DataGridView1.DataSource = bSource
                SDA.Update(dbDataSet_search_pcb)
            Catch ex As Exception
                'MsgBox(ex.Message)
                connection = False
            End Try
        End If

        conn_stb_new.Close()
        Return 0
    End Function
    Public Sub log_user_details()
        Try
            Query = "insert into logindetails(user,hostname,time)values('" & username & "','" & System.Net.Dns.GetHostName() & "','" & mytimestamp_sql & "')"
            conn_stb_new.Open()
            CMD = New MySqlCommand(Query, conn_stb_new)
            Dim dr As MySqlDataReader
            dr = CMD.ExecuteReader()
        Catch ex As Exception
            mainform.ts_message.Text = ex.Message
            MsgBox(ex.Message, vbCritical)
        Finally
            CMD.Dispose()
            conn_stb_new.Close()
        End Try
    End Sub
    Public Sub update_productinfo(lineno As String)
        Dim Query As String
        'g_p_name = productinfo.cmb_productname.SelectedItem
        'g_p_code = productinfo.txt_productcode.Text
        'g_lot_number = productinfo.txt_lot_no.Text
        'g_panel_count = productinfo.txt_panel.Text
        'g_side = productinfo.txt_side.Text
        'g_CTtime = productinfo.txt_cttime.Text
        'g_hourly_target = productinfo.txt_hourly_target.Text
        'g_shift_target = productinfo.txt_shift_target.Text

        'line1 = backup_stage_1
        'line2 = backup_stage_2
        'line3 = backup_stage_3
        'line4 = backup_stage_4
        'line5 = backup_stage_5
        'line6 = backup_stage_6
        'line7 = backup_stage_7
        'line8 = backup_stage_8
        'line9 = backup_stage_9
        'Query = "Update linedetails Set ProductName = '" & g_p_name & "',ProductCode = '" & g_p_code & "', LotNo = '" & g_lot_number & "' , Panel = '" & g_panel_count & "' ,Side = '" & g_side & "',LineCT = '" & g_CTtime & "',HourlyTarget = '" & g_hourly_target & "',ShiftTarget = '" & g_shift_target & "' ,S1 = '" & line1 & "'  ,S2 = '" & line2 & "',S3 = '" & line3 & "' ,S4 = '" & line4 & "' ,S5 = '" & line5 & "' ,S6 = '" & line6 & "' ,S7 = '" & line7 & "' ,S8 = '" & line8 & "' ,S9 = '" & line9 & "' where Lineno =  '" & lineno & "'   "
        Query = "Update linedetails Set  Version = '" & backup_version & "', ProductName = '" & backup_product_name & "',ProductCode = '" & backup_product_code & "', LotNo = '" & productinfo.txt_lot_no.Text & "' , Panel = '" & backup_panel & "' ,Side = '" & backup_side & "',LineCT = '" & backup_cttime & "',HourlyTarget = '" & backup_hourly_target & "',ShiftTarget = '" & backup_shift_target & "' ,S1 = '" & backup_stage_1 & "'  ,S2 = '" & backup_stage_2 & "',S3 = '" & backup_stage_3 & "' ,S4 = '" & backup_stage_4 & "' ,S5 = '" & backup_stage_5 & "' ,S6 = '" & backup_stage_6 & "' ,S7 = '" & backup_stage_7 & "' ,S8 = '" & backup_stage_8 & "' ,S9 = '" & backup_stage_9 & "'  where Lineno =  '" & lineno & "'   "
        ExecuteQuery(Query)
    End Sub
    Public Sub read_productinfo(line_no As String)
        If line_no = "" Then
            line_no = 1
        End If
        conn_stb_new.Open()
        dbDataSet_product_info.Clear()
        CMD = New MySqlCommand("select * from linedetails where lineno ='" + line_no + "'", conn_stb_new)
        SDA = New MySqlDataAdapter(CMD)
        SDA.Fill(dbDataSet_product_info)
        bSource.DataSource = dbDataSet_product_info
        productinfo.DataGridView1.DataSource = bSource
        SDA.Update(dbDataSet_product_info)
        conn_stb_new.Close()
        productinfo_load_globalvariable()
    End Sub
    Public Sub productinfo_load_globalvariable()
        If productinfo.DataGridView1.RowCount > 0 Then
            g_line_number = productinfo.DataGridView1.Rows(0).Cells(0).Value.ToString
            g_p_name = productinfo.DataGridView1.Rows(0).Cells(1).Value.ToString
            g_p_code = productinfo.DataGridView1.Rows(0).Cells(2).Value.ToString
            g_workorder = productinfo.DataGridView1.Rows(0).Cells(3).Value.ToString
            g_s_version = productinfo.DataGridView1.Rows(0).Cells(4).Value.ToString
            g_lot_number = productinfo.DataGridView1.Rows(0).Cells(5).Value.ToString
            g_panel_count = productinfo.DataGridView1.Rows(0).Cells(6).Value.ToString
            g_side = productinfo.DataGridView1.Rows(0).Cells(7).Value.ToString
            g_CTtime = productinfo.DataGridView1.Rows(0).Cells(8).Value.ToString
            g_hourly_target = productinfo.DataGridView1.Rows(0).Cells(9).Value.ToString
            g_shift_target = productinfo.DataGridView1.Rows(0).Cells(10).Value.ToString

            productinfo.txt_productcode.Text = g_p_code
            productinfo.cmb_productname.Text = g_p_name
            productinfo.txt_workorder.Text = g_workorder
            productinfo.txt_lot_no.Text = g_lot_number
            productinfo.txt_panel.Text = backup_panel
            productinfo.txt_side.Text = backup_side
            productinfo.txt_cttime.Text = backup_cttime
            productinfo.txt_hourly_target.Text = backup_hourly_target
            productinfo.txt_shift_target.Text = backup_shift_target
            productinfo.txt_startingserialnumber.Text = g_start_pcb_number


            line1 = productinfo.DataGridView1.Rows(0).Cells(10).Value.ToString
            line2 = productinfo.DataGridView1.Rows(0).Cells(11).Value.ToString
            line3 = productinfo.DataGridView1.Rows(0).Cells(12).Value.ToString
            line4 = productinfo.DataGridView1.Rows(0).Cells(13).Value.ToString
            line5 = productinfo.DataGridView1.Rows(0).Cells(14).Value.ToString
            line6 = productinfo.DataGridView1.Rows(0).Cells(15).Value.ToString
            line7 = productinfo.DataGridView1.Rows(0).Cells(16).Value.ToString
            line8 = productinfo.DataGridView1.Rows(0).Cells(17).Value.ToString
            line9 = productinfo.DataGridView1.Rows(0).Cells(18).Value.ToString

            If line1 = "yes" Then
                mainform.chk_lasermarking.Checked = True
                mainform.LaserMarkingToolStripMenuItem1.Enabled = True
            Else
                mainform.chk_lasermarking.Checked = False
                mainform.LaserMarkingToolStripMenuItem1.Enabled = False
            End If

            If line2 = "yes" Then
                mainform.chk_spi.Checked = True
                mainform.ProcessLenseToolStripMenuItem.Enabled = True
            Else
                mainform.chk_spi.Checked = False
                mainform.ProcessLenseToolStripMenuItem.Enabled = False
            End If

            If line3 = "yes" Then
                mainform.chk_pickandplace.Checked = True
                mainform.PickPlaceToolStripMenuItem.Enabled = True
            Else
                mainform.chk_pickandplace.Checked = False
                mainform.PickPlaceToolStripMenuItem.Enabled = False
            End If

            If line4 = "yes" Then
                mainform.chk_aoi.Checked = True
                mainform.AOIToolStripMenuItem1.Enabled = True
            Else
                mainform.chk_aoi.Checked = False
                mainform.AOIToolStripMenuItem1.Enabled = False
            End If

            If line5 = "yes" Then
                mainform.chk_rework.Checked = True
                mainform.ReworkToolStripMenuItem1.Enabled = True
            Else
                mainform.chk_rework.Checked = False
                mainform.ReworkToolStripMenuItem1.Enabled = False
            End If

            If line6 = "yes" Then
                mainform.chk_prewave.Checked = True
                mainform.PrewaveSolderingToolStripMenuItem.Enabled = True
            Else
                mainform.chk_prewave.Checked = False
                mainform.PrewaveSolderingToolStripMenuItem.Enabled = False
            End If

            If line7 = "yes" Then
                mainform.chk_postwave.Checked = True
                mainform.PostwaveSolderingToolStripMenuItem.Enabled = True
            Else
                mainform.chk_postwave.Checked = False
                mainform.PostwaveSolderingToolStripMenuItem.Enabled = False
            End If

            If line8 = "yes" Then
                mainform.chk_touchupvi.Checked = True
                mainform.TouchUpToolStripMenuItem.Enabled = True
            Else
                mainform.chk_touchupvi.Checked = False
                mainform.TouchUpToolStripMenuItem.Enabled = False
            End If

            If line9 = "yes" Then
                mainform.chk_router.Checked = True
                mainform.RouterToolStripMenuItem1.Enabled = True
            Else
                mainform.chk_router.Checked = False
                mainform.RouterToolStripMenuItem1.Enabled = False
            End If

        End If
    End Sub
    Public Sub read_stage_details(p_name As String)
        Dim dbDataSet_new_stage As New DataTable
        conn_stb_new.Open()
        dbDataSet_new_stage.Clear()
        CMD = New MySqlCommand("select * from productnames where pname ='" + p_name + "'", conn_stb_new)
        SDA = New MySqlDataAdapter(CMD)
        SDA.Fill(dbDataSet_new_stage)
        bSource.DataSource = dbDataSet_new_stage
        stagedetails.DataGridView2.DataSource = bSource
        SDA.Update(dbDataSet_new_stage)
        conn_stb_new.Close()

        line1 = (stagedetails.DataGridView2.Rows(0).Cells(1).Value.ToString)
        line2 = (stagedetails.DataGridView2.Rows(0).Cells(2).Value.ToString)
        line3 = (stagedetails.DataGridView2.Rows(0).Cells(3).Value.ToString)
        line4 = (stagedetails.DataGridView2.Rows(0).Cells(4).Value.ToString)
        line5 = (stagedetails.DataGridView2.Rows(0).Cells(5).Value.ToString)
        line6 = (stagedetails.DataGridView2.Rows(0).Cells(6).Value.ToString)
        line7 = (stagedetails.DataGridView2.Rows(0).Cells(7).Value.ToString)
        line8 = (stagedetails.DataGridView2.Rows(0).Cells(8).Value.ToString)
        line9 = (stagedetails.DataGridView2.Rows(0).Cells(9).Value.ToString)

        If line1 = "yes" Then
            stagedetails.chk_lasermarking.Checked = True
            mainform.LaserMarkingToolStripMenuItem1.Enabled = True
        Else
            stagedetails.chk_lasermarking.Checked = False
            mainform.LaserMarkingToolStripMenuItem1.Enabled = False
        End If

        If line2 = "yes" Then
            stagedetails.chk_spi.Checked = True
            mainform.ProcessLenseToolStripMenuItem.Enabled = True
        Else
            stagedetails.chk_spi.Checked = False
            mainform.ProcessLenseToolStripMenuItem.Enabled = False
        End If

        If line3 = "yes" Then
            stagedetails.chk_pickandplace.Checked = True
            mainform.PickPlaceToolStripMenuItem.Enabled = True
        Else
            stagedetails.chk_pickandplace.Checked = False
            mainform.PickPlaceToolStripMenuItem.Enabled = False
        End If

        If line4 = "yes" Then
            stagedetails.chk_aoi.Checked = True
            mainform.AOIToolStripMenuItem1.Enabled = True
        Else
            stagedetails.chk_aoi.Checked = False
            mainform.AOIToolStripMenuItem1.Enabled = False
        End If

        If line5 = "yes" Then
            stagedetails.chk_rework.Checked = True
            mainform.ReworkToolStripMenuItem1.Enabled = True
        Else
            stagedetails.chk_rework.Checked = False
            mainform.ReworkToolStripMenuItem1.Enabled = False
        End If

        If line6 = "yes" Then
            stagedetails.chk_prewave.Checked = True
            mainform.PrewaveSolderingToolStripMenuItem.Enabled = True
        Else
            stagedetails.chk_prewave.Checked = False
            mainform.PrewaveSolderingToolStripMenuItem.Enabled = False
        End If

        If line7 = "yes" Then
            stagedetails.chk_postwave.Checked = True
            mainform.PostwaveSolderingToolStripMenuItem.Enabled = True
        Else
            stagedetails.chk_postwave.Checked = False
            mainform.PostwaveSolderingToolStripMenuItem.Enabled = False
        End If

        If line8 = "yes" Then
            stagedetails.chk_touchupvi.Checked = True
            mainform.TouchUpToolStripMenuItem.Enabled = True
        Else
            stagedetails.chk_touchupvi.Checked = False
            mainform.TouchUpToolStripMenuItem.Enabled = False
        End If

        If line9 = "yes" Then
            stagedetails.chk_router.Checked = True
            mainform.RouterToolStripMenuItem1.Enabled = True
        Else
            stagedetails.chk_router.Checked = False
            mainform.RouterToolStripMenuItem1.Enabled = False
        End If

    End Sub
    Public Sub read_product_names()
        Dim dbDataSet_p_names As New DataTable
        Try
            conn_stb_new.Open()
            Dim Query As String
            Query = "select * from productnames"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_p_names)
            bSource.DataSource = dbDataSet_p_names
            stagedetails.DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet_p_names)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try

        stagedetails.cmb_productname.Items.Clear()
        For i = 0 To stagedetails.DataGridView1.RowCount - 2
            stagedetails.cmb_productname.Items.Add(stagedetails.DataGridView1.Rows(i).Cells(0).Value.ToString)
            g_product_names(i) = stagedetails.DataGridView1.Rows(i).Cells(0).Value.ToString
        Next
    End Sub
    Public Sub check_time_lasermarking(pcbno As String)
        Dim dbDataSet_new_stage As New DataTable
        conn_stb_new.Open()
        dbDataSet_new_stage.Clear()
        CMD = New MySqlCommand("select * from lasermarking where PcbSerialNumber ='" + pcbno + "'", conn_stb_new)
        SDA = New MySqlDataAdapter(CMD)
        SDA.Fill(dbDataSet_new_stage)
        bSource.DataSource = dbDataSet_new_stage
        mainform.DataGridView3.DataSource = bSource
        SDA.Update(dbDataSet_new_stage)
        conn_stb_new.Close()
    End Sub
    Public Sub actual_quntity_total()
        Dim READER As MySqlDataReader
        Try
            conn_stb_new.Open()
            Dim Query As String

            'Query = "Select * from aoi WHERE Status='FAIL'"
            Query = "Select * from aoi"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            Yieldaoi.txt_fail_count.Text = count
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
    End Sub
    Public Function convert_time_to_sec(stamp As String)
        Dim timeString = stamp.Split(":")
        Dim SetPos As Integer
        If UBound(timeString) = 2 Then

            Dim hour = timeString(0)
            Dim min = timeString(1)
            Dim sec = timeString(2)

            Dim totalSecs As Integer = CInt(hour) * 60 * 60 + CInt(min) * 60 + CInt(sec)

            SetPos = totalSecs
        Else
            If UBound(timeString) = 1 Then
                Dim min = timeString(0)
                Dim sec = timeString(1)

                Dim totalSecs As Integer = CInt(min) * 60 + CInt(sec)

                SetPos = totalSecs
            End If
        End If

        Return SetPos
    End Function
End Module
