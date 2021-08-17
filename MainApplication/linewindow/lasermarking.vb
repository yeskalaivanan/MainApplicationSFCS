Imports System.IO
Imports MySql.Data.MySqlClient

Public Class lasermarking
    Dim CMD As New MySqlCommand
    Private Sub lasermarking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmb_product_name.SelectedIndex = 0
        cmb_time.SelectedIndex = 0
    End Sub

    Private Sub ImpData_norcold(ByRef selectedFile As String)
        Dim dt As New DataTable
        Dim count As Integer = 0
        Dim temp_string As String = ""
        Dim panel_number_check As Boolean = False
        Dim position, fulllength, time_start_index, time_string_length As Integer
        Dim temp_time, temp_panel_number, temp_pcb_number As String

        dt.Columns.Add("Date & Time", GetType(String))
        dt.Columns.Add("PCB Serial Number", GetType(String))
        dt.Columns.Add("Panel Number", GetType(String))
        dt.Columns.Add("Product Name", GetType(String))
        dt.Columns.Add("Product Code", GetType(String))
        dt.Columns.Add("Work Order", GetType(String))
        dt.Columns.Add("Side", GetType(String))
        dt.Columns.Add("Panel/PCB", GetType(String))
        dt.Columns.Add("LOT Number", GetType(String))
        dt.Columns.Add("LINE Number", GetType(String))
        dt.Columns.Add("USER", GetType(String))
        dt.Columns.Add("Time", GetType(String))
        dt.Columns.Add("Shift", GetType(String))
        Dim lines = IO.File.ReadAllLines(selectedFile)
        'Dim colCount = 3

        temp_panel_number = ""
        For Each line In lines
            fulllength = line.Length
            time_start_index = 2
            time_string_length = 19
            temp_time = Mid(line, time_start_index, time_string_length)
            If line.Contains("PCBA") = True Then
                position = line.IndexOf("PCBA")
                temp_panel_number = Mid(line, position + 1, (fulllength - position) + 1)
                Label2.Text = "Panel Contains " & count & " PCB's"
                count = 0
            Else
                count = count + 1
                position = line.IndexOf("]")
                temp_pcb_number = Mid(line, position + 8, (fulllength - position) + 1)
                temp_pcb_number = temp_pcb_number.Replace(";", "")
                temp_pcb_number = temp_pcb_number.Replace(",", "")
                temp_string = temp_time & "," & temp_pcb_number & "," & temp_panel_number
                temp_string = temp_string & "," & g_p_name & "," & g_p_code & "," & g_workorder & "," & g_side & "," & g_panel_count & "," & g_lot_number & "," & g_line_number & "," & username & "," & mytimestamp_sql & "," & shifting_time
                Dim objFields = From field In temp_string.Split(","c)
                                Select field
                Dim newRow = dt.Rows.Add()
                newRow.ItemArray = objFields.ToArray()
            End If
        Next
        DataGridView1.DataSource = dt
    End Sub
    Private Sub ImpData(ByRef selectedFile As String)
        Dim dt As New DataTable
        'For d = 1 To 3
        'dt.Columns.Add(d, GetType(String))
        'Next
        dt.Columns.Add("Date & Time", GetType(String))
        dt.Columns.Add("PCB Serial Number", GetType(String))
        dt.Columns.Add("Panel Number", GetType(String))
        dt.Columns.Add("Product Name", GetType(String))
        dt.Columns.Add("Product Code", GetType(String))
        dt.Columns.Add("Work Order", GetType(String))
        dt.Columns.Add("Side", GetType(String))
        dt.Columns.Add("Panel/PCB", GetType(String))
        dt.Columns.Add("LOT Number", GetType(String))
        dt.Columns.Add("LINE Number", GetType(String))
        dt.Columns.Add("USER", GetType(String))
        dt.Columns.Add("Time", GetType(String))
        dt.Columns.Add("Shift", GetType(String))
        Dim lines = IO.File.ReadAllLines(selectedFile)
        'Dim colCount = 3
        Dim count As Integer = 0
        Dim temp_string As String = ""
        For Each line In lines


            If count = 0 Then
                temp_string = line
                count = count + 1
            ElseIf count = 1 Then
                temp_string = temp_string & "," & line
                count = count + 1
            Else

                temp_string = temp_string & "," & line & "," & g_p_name & "," & g_p_code & "," & g_workorder & "," & g_side & "," & g_panel_count & "," & g_lot_number & "," & g_line_number & "," & username & "," & mytimestamp_sql & "," & shifting_time
                Dim objFields = From field In temp_string.Split(","c)
                                Select field
                Dim newRow = dt.Rows.Add()
                newRow.ItemArray = objFields.ToArray()
                count = 0
                temp_string = ""
            End If

        Next
        Label2.Text = "Panel Contains 1 PCB"
        DataGridView1.DataSource = dt
    End Sub
    Private Sub InitializeGrid()
        With DataGridView1
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .Font = New Font("Tahoma", 9)
            'Adjust the width each Column to fit.
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoResizeColumns()
            'Adjust Header Styles.
            With .ColumnHeadersDefaultCellStyle
                .BackColor = Color.Navy
                .ForeColor = Color.White
                .Font = New Font("Tahoma", 9, FontStyle.Bold)
            End With
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selectedfile As String = ""
        Try
            OpenFileDialog1.ShowDialog()
            selectedfile = Path.GetFullPath(OpenFileDialog1.FileName)
            txt_file_path.Text = selectedfile
            If cmb_product_name.SelectedItem = "STB" Then
                ImpData(selectedfile)
            Else
                ImpData_norcold(selectedfile)
            End If
            InitializeGrid()
            Label1.Text = "Total Record Count : " & DataGridView1.RowCount
        Catch ex As Exception
            Label1.Text = "No Record Found"
        End Try

    End Sub
    Private Sub export_to_database()
        Dim total_records As Integer = DataGridView1.RowCount - 1
        Dim filepath As StreamWriter

        For i = 0 To total_records

            Dim temp As Date = DataGridView1.Rows(i).Cells(0).Value.ToString
            Dim dateandtime As String = Format(temp, "yy-MM-dd HH-mm-ss")
            Dim pcb_number As String = DataGridView1.Rows(i).Cells(1).Value.ToString
            Dim panel_number As String = DataGridView1.Rows(i).Cells(2).Value.ToString

            Try
                Query = "insert into lasermarking(PcbSerialNumber,PanelNumber,DateTime,ProductCode,ProductName,WorkOrder,Side,Panel,Lotno,Lineno,Stage,Time,User,Shift)values('" & pcb_number & "','" & panel_number & "','" & dateandtime & "','" & g_p_code & "','" & g_p_name & "','" & g_workorder & "','" & g_side & "','" & g_panel_count & "','" & g_lot_number & "','" & g_line_number & "','" & Stage_laser_marking & "','" & mytimestamp_sql & "','" & username & "','" & shifting_time & "')"
                conn_stb_new.Open()
                CMD = New MySqlCommand(Query, conn_stb_new)
                Dim dr As MySqlDataReader
                dr = CMD.ExecuteReader()
                mainform.ts_message.Text = pcb_number & " Uploading file to server. Please wait..."
            Catch ex As Exception
                mainform.ts_message.Text = ex.Message
                'MsgBox(ex.Message, vbCritical)
                filepath = File.AppendText(backup_file_path & "\LaserMarkingDuplicate-" & save_time & ".csv")
                filepath.WriteLine(pcb_number & "," & panel_number & "," & dateandtime & "," & g_p_code & "," & g_p_name & "," & g_lot_number & "," & g_line_number & "," & Stage_laser_marking & "," & mytimestamp_sql & "," & username)
                filepath.Close()
            Finally
                CMD.Dispose()
                conn_stb_new.Close()
                mainform.ts_message.Text = "Files Loaded successfully"
                'MsgBox("Files Loaded Successfully", vbInformation, "Successfully")
            End Try
        Next

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If Button3.Text = "Auto Start" Then
            Button3.Text = "Auto Stop"
            If cmb_time.SelectedItem = "" Then
                Timer1.Interval = 1000 * 60
            Else
                Timer1.Interval = cmb_time.SelectedItem * 1000 * 60
            End If

            Timer1.Enabled = True
            Label4.Visible = True
        Else
            Button3.Text = "Auto Start"
            Timer1.Enabled = False
            Label4.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label4.Text = "Last updated on " & mytimestamp_sql
        upload_database()
    End Sub
    Function upload_database()
        If DataGridView1.RowCount < 1 Then
            MsgBox("No data", vbInformation, "Check Database")
        Else
            export_to_database()
        End If
        Return 0
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim selectedfile As String
        Label4.Text = "last updated on " & mytimestamp_sql
        Try
            selectedfile = Path.GetFullPath(txt_file_path.Text)
            If cmb_product_name.SelectedItem = "STB" Then
                ImpData(selectedfile)
            Else
                ImpData_norcold(selectedfile)
            End If
            InitializeGrid()
            Label1.Text = "Total Record Count : " & DataGridView1.RowCount
        Catch ex As Exception
            Label1.Text = "No Record Found"
        End Try

        upload_database()
    End Sub

    Private Sub btn_serial_create_Click(sender As Object, e As EventArgs) Handles btn_serial_create.Click
        If mainform.dg_workorder.RowCount < 2 Then
            MsgBox("No Records", vbInformation, "Error")
            GoTo Finish
        End If

        Dim serial_number_folder As String = "\\10.1.77.87\VEPL_Serial_Number"
        Dim selected_row As Integer = mainform.dg_workorder.CurrentRow.Index
        Dim product_lineno As String = mainform.dg_workorder.Rows(selected_row).Cells(4).Value.ToString
        Dim product_name As String = mainform.dg_workorder.Rows(selected_row).Cells(5).Value.ToString
        Dim product_quantity As Integer = mainform.dg_workorder.Rows(selected_row).Cells(8).Value.ToString
        Dim product_status As String = mainform.dg_workorder.Rows(selected_row).Cells(0).Value.ToString

        If product_status <> "Active" Then
            MsgBox("Serial number is alreay created", vbInformation, "Error")
            GoTo Finish
        End If

        If product_lineno = "SMT 1" Then
            create_line(1)
        ElseIf product_lineno = "SMT 2" Then
            create_line(2)
        Else
            create_line(3)
        End If


        'mainform.read_grid1_backup_parameters_by_productname(product_name)
        'mainform.read_productinfo_from_lineno(product_lineno)

        Dim digit1, digit2, digit3, digit4, digit5, digit6 As String
        'digit7, digit8, digit9, digit10, digit11, digit12, digit13, digit14, digit15, digit16, digit17, digit18, digit19, digit20 As String
        Dim PC_BETTER As String = "640726"
        Dim PC_BETTER_VERSION As String = "211"
        Dim serial_number As String = ""
        Dim WeekNumber As Integer = DatePart(DateInterval.WeekOfYear, Date.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.System)
        Dim filepath As StreamWriter
        Dim temp_string As String
        Dim panel_number As Integer = 0
        Dim panel_total As Integer
        Dim i, j, count As Integer
        digit1 = Format(WeekNumber - 1, "#00")
        digit2 = Format(Now, "yy")
        digit3 = "N"
        backup_serial_number = backup_serial_number + 1 'Next number
        temp_string = Format(Val(backup_serial_number), "#000000")
        digit4 = temp_string
        'digit5 = PC_BETTER
        'digit6 = PC_BETTER_VERSION
        digit5 = backup_product_code
        digit6 = backup_version

        panel_total = Math.Round(product_quantity / backup_panel)

        Dim panel_mod As Integer = product_quantity Mod backup_panel
        If panel_mod > 0 Then
            panel_total = panel_total + 1
        End If
        Dim headings As String = ""
        Dim datas As String = ""
        panel_number = backup_panel_number
        panel_number = panel_number + 1
        count = 0
        For i = 1 To panel_total
            filepath = File.AppendText(serial_number_folder & "\PCBA" & panel_number & ".txt")
            headings = Chr(34) & "PanelID" & Chr(34) & ","
            datas = Chr(34) & "PCBA" & panel_number & Chr(34) & ","
            For j = 1 To g_panel_count

                serial_number = digit1 & digit2 & digit3 & temp_string & digit5 & digit6

                headings = headings & Chr(34) & "Top_BoardSN" & j & Chr(34) & ","
                datas = datas & Chr(34) & serial_number & Chr(34) & ","

                count = count + 1
                temp_string = Format(digit4 + count, "#000000")
            Next
            filepath.WriteLine(headings)
            filepath.WriteLine(datas)
            filepath.Close()
            panel_number = panel_number + 1
        Next
        change_process()
        serial_number = Mid(serial_number, 6, 6)
        save_next_serial(serial_number, panel_number - 1)
Finish:
    End Sub
    Function save_next_serial(serial As Integer, panel As Integer)
        Dim Query As String
        Dim selected_row As Integer = mainform.dg_workorder.CurrentRow.Index
        Dim temp_product_name As String = mainform.dg_workorder.Rows(selected_row).Cells(5).Value.ToString
        Query = "Update productnames Set SerialNumber = '" & serial & "' ,PanelNumber = '" & panel & "' where pname =  '" & temp_product_name & "' "
        ExecuteQuery(Query)
        mainform.load_workorder()
        Return 0
    End Function
    Function change_process()
        Dim Query As String
        Dim workorder As String
        Dim selected_row As Integer = mainform.dg_workorder.CurrentRow.Index
        workorder = mainform.dg_workorder.Rows(selected_row).Cells(2).Value.ToString
        Query = "Update workorder Set WOSTATE = '" & "Process" & "' where WOID =  '" & workorder & "' "
        ExecuteQuery(Query)
        mainform.load_workorder()
        Return True
    End Function
    Private Sub create_line(lineno As String)
        Dim Query As String
        Query = "Update linedetails Set  Version = '" & backup_version & "', ProductName = '" & backup_product_name & "',ProductCode = '" & backup_product_code & "', LotNo = '" & productinfo.txt_lot_no.Text & "' , Panel = '" & backup_panel & "' ,Side = '" & backup_side & "',LineCT = '" & backup_cttime & "',HourlyTarget = '" & backup_hourly_target & "',ShiftTarget = '" & backup_shift_target & "' ,S1 = '" & backup_stage_1 & "'  ,S2 = '" & backup_stage_2 & "',S3 = '" & backup_stage_3 & "' ,S4 = '" & backup_stage_4 & "' ,S5 = '" & backup_stage_5 & "' ,S6 = '" & backup_stage_6 & "' ,S7 = '" & backup_stage_7 & "' ,S8 = '" & backup_stage_8 & "' ,S9 = '" & backup_stage_9 & "'  where Lineno =  '" & lineno & "'   "
        ExecuteQuery(Query)
    End Sub


End Class