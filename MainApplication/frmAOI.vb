Imports System.IO
Imports MySql.Data.MySqlClient
Public Class frmAOI
    Dim dt As New DataTable

    Dim auto_mode As Boolean = False
    Dim list_complete As Boolean = False
    Private Sub frmAOI_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitializeGrid()
        'gridstyle1()
    End Sub
    Private Sub gridstyle1()

        With DataGridView1
            .GridColor = Color.Green
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            With .ColumnHeadersDefaultCellStyle
                .BackColor = Color.Navy
                .ForeColor = Color.White
                .Font = New Font("Tahoma", 9, FontStyle.Bold)
            End With
        End With
    End Sub
    Private Sub gridstyle2()

    End Sub

    Private Sub ImpData_to_grid(ByRef selectedFile As String)

        Dim count As Integer = 0
        Dim temp_string As String = ""
        Dim panel_number_check As Boolean = False
        Dim position, fulllength, time_start_index, time_string_length As Integer
        Dim temp_time As String
        Dim line_complete As Boolean = False
        Dim aoi_date As String = ""

        dt.Columns.Clear()
        dt.Rows.Clear()

        dt.Columns.Add("Serial Number", GetType(String))
        dt.Columns.Add("Product Name", GetType(String))
        dt.Columns.Add("Product Code", GetType(String))
        dt.Columns.Add("WorkOrder", GetType(String))
        dt.Columns.Add("Side", GetType(String))
        dt.Columns.Add("LOT Number", GetType(String))
        dt.Columns.Add("LINE Number", GetType(String))
        dt.Columns.Add("Stage", GetType(String))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("Remarks", GetType(String))
        dt.Columns.Add("Date & Time", GetType(String))
        dt.Columns.Add("USER", GetType(String))
        dt.Columns.Add("Shift", GetType(String))
        dt.Columns.Add("Time", GetType(String))

        Dim lines = IO.File.ReadAllLines(selectedFile)
        Dim index As String = ""
        Dim serial_number_1_status As String = ""
        Dim serial_number_1_remark As String = ""
        Dim panelnumber As String = ""
        Dim serial_number As String = ""

        For Each line In lines
            fulllength = line.Length
            time_start_index = 2
            time_string_length = 19
            temp_time = Mid(line, time_start_index, time_string_length)
            If line.Contains("Date:") Then
                position = line.IndexOf("Date:")
                aoi_date = Mid(line, position + 6, (fulllength - position) + 1)
            ElseIf line.Contains("Serial Number:") = True And index = "" Then
                position = line.IndexOf("Serial Number:")
                panelnumber = Mid(line, position + 1, (fulllength - position) + 1)
            End If

            If line.Contains("Board:1") = True Then
                index = "board1"
            ElseIf line.Contains("Board:2") = True Then
                index = "board2"
            ElseIf line.Contains("Board:3") = True Then
                index = "board3"
            ElseIf line.Contains("Board:4") = True Then
                index = "board4"
            ElseIf line.Contains("Board:5") = True Then
                index = "board5"
            ElseIf line.Contains("Board:6") = True Then
                index = "board6"
            ElseIf line.Contains("Board:7") = True Then
                index = "board7"
            ElseIf line.Contains("Board:8") = True Then
                index = "board8"
            ElseIf line.Contains("Board:9") = True Then
                index = "board9"
            ElseIf line.Contains("Board:10") = True Then
                index = "board10"
            ElseIf line.Contains("Board:11") = True Then
                index = "board11"
            ElseIf line.Contains("Board:12") = True Then
                index = "board12"
            End If

            Select Case (index)
                Case "board1"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                        'ElseIf line.Contains("R") Then
                        '    serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                        'ElseIf line.Contains("C") Then
                        '    serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                        'ElseIf line.Contains("U") Then
                        '    serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                        'ElseIf line.Contains("Z") Then
                        '    serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                        'ElseIf line.Contains("D") Then
                        '    serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                        'ElseIf line.Contains("P") Then
                        '    serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
                Case "board2"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
                Case "board3"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
                Case "board4"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
                Case "board5"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
                Case "board6"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
                Case "board7"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
                Case "board8"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
                Case "board9"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
                Case "board10"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
                Case "board11"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
                Case "board12"
                    If line.Contains("Serial Number:") = True Then
                        position = line.IndexOf("Serial Number:")
                        serial_number = Mid(line, position + 15, fulllength)
                    ElseIf line.Contains("LED") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("_") Then
                        serial_number_1_remark = serial_number_1_remark & Mid(line, 1, 9) & " & "
                    ElseIf line.Contains("Panel Pass!") Then
                        serial_number_1_status = "PASS"
                        line_complete = True
                    ElseIf line.Contains("Panel Fail!") Then
                        serial_number_1_status = "FAIL"
                        line_complete = True
                    ElseIf line.Contains("Panel Rpass!") Then
                        serial_number_1_status = "RPASS"
                        line_complete = True
                    End If
            End Select
            Try
                If (line_complete = True) Then
                    line_complete = False
                    temp_string = serial_number & "," & g_p_name & "," & g_p_code & "," & g_workorder & "," & g_side & "," & g_lot_number & "," & g_line_number & "," & Stage_aoi & "," & serial_number_1_status & "," & serial_number_1_remark & "," & mytimestamp_sql & "," & username & "," & shifting_time & "," & aoi_date
                    'aoi_save(serial_number, serial_number_1_status, serial_number_1_remark, aoi_date)
                    Dim objFields = From field In temp_string.Split(","c)
                                    Select field
                    Dim newRow = dt.Rows.Add()
                    newRow.ItemArray = objFields.ToArray()
                    serial_number_1_remark = ""
                End If
            Catch ex As Exception
                mainform.ts_message.Text = ex.Message
            End Try

        Next
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
            '.Font = New Font("Tahoma", 9)
            'Adjust the width each Column to fit.
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoResizeColumns()
            'Adjust Header Styles.
            With .ColumnHeadersDefaultCellStyle
                .BackColor = Color.Green
                .ForeColor = Color.White
                .Font = New Font("Tahoma", 9, FontStyle.Bold)
            End With
        End With
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        mainform.ts_message.Text = "Reading File names in Folder"
        read_file_name()
    End Sub
    Private Sub read_file_name()
        Try
            Dim searchPath = txt_file_path.Text.Trim
            Dim files = Directory.GetFiles(searchPath, "*.txt")

            ListBox1.Items.Clear()
            For Each file In files
                ListBox1.Items.Add(Path.GetFileName(file))
            Next

            RepoveDuplicate()

            Label1.Text = "Total Records " & ListBox1.Items.Count
        Catch ex As Exception
            Label1.Text = "No Records Found"
        End Try

    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        load_preview()
    End Sub
    Private Sub load_preview()
        Try
            list_increment()
        Catch ex As Exception
            MsgBox("List Box is Empty, Load the files now", vbInformation, "Files Empty")
        End Try
    End Sub

    Private Sub list_increment()
        Try
            ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
            mainform.ts_message.Text = ListBox1.SelectedItem & " Loading..."
        Catch ex As Exception
            If auto_mode = True Then
                mainform.ts_message.Text = "Files completed"
                list_complete = True
            Else
                mainform.ts_message.Text = ex.Message
                MsgBox("Files Completed", vbInformation, "Completed")
            End If


        End Try

    End Sub
    Public Sub aoi_save(pcb_sno As String, status As String, remarks As String, aoitime As String)
        Dim CMD As New MySqlCommand
        Try
            Query = "insert into aoi(PcbSerialNumber,ProductName,ProductCode,WorkOrder,Side,Lotno,Lineno,Stage,Status,Remarks,Time,User,Shift,AOITime)values('" & pcb_sno & "','" & g_p_name & "','" & g_p_code & "','" & g_workorder & "','" & g_side & "','" & g_lot_number & "','" & g_line_number & "','" & Stage_aoi & "','" & status & "','" & remarks & "','" & mytimestamp_sql & "','" & username & "','" & shifting_time & "','" & aoitime & "')"
            conn_stb_new.Open()
            CMD = New MySqlCommand(Query, conn_stb_new)
            Dim dr As MySqlDataReader
            dr = CMD.ExecuteReader()
            'MsgBox("Data saved successfully", vbInformation)
            mainform.ts_message.Text = "Data saved successfully"
            save_csv_aoi()
        Catch ex As Exception
            mainform.ts_message.Text = ex.Message
            'MsgBox(ex.Message, vbCritical)
        Finally
            CMD.Dispose()
            conn_stb_new.Close()
        End Try
    End Sub
    Private Sub RepoveDuplicate()
        mainform.ts_message.Text = "Removing Duplicates"
        For Row As Int16 = 0 To ListBox1.Items.Count - 2
            For RowAgain As Int16 = ListBox1.Items.Count - 1 To Row + 1 Step -1
                If ListBox1.Items(Row).ToString = ListBox1.Items(RowAgain).ToString Then
                    ListBox1.Items.RemoveAt(RowAgain)
                End If
            Next
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        If btn_auto.Text = "Auto" Then
            btn_auto.Text = "Manual"
            Timer1.Enabled = True
            Timer1.Interval = 2 * 60 * 1000
        Else
            btn_auto.Text = "Auto"
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        read_file_name()
        check_files()
        Timer2.Interval = 100
        Timer2.Enabled = True
    End Sub
    Private Sub check_files()
        If ListBox1.Items.Count < 0 Then
            MsgBox("No files found, please check the folder")
            timer_stop()
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ImpData_to_grid(txt_file_path.Text & ListBox1.SelectedItem)
        Label3.Text = "Selected Count " & ListBox1.SelectedIndex
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        export_to_aoi_database()
    End Sub
    Private Sub export_to_aoi_database()
        Dim total_records As Integer = DataGridView1.RowCount - 1

        'dt.Columns.Add("PCB Serial Number", GetType(String))'0
        'dt.Columns.Add("Product Name", GetType(String))'1
        'dt.Columns.Add("Product Code", GetType(String))'2
        'dt.Columns.Add("Side", GetType(String))'3
        'dt.Columns.Add("LOT Number", GetType(String))'4
        'dt.Columns.Add("LINE Number", GetType(String))'5
        'dt.Columns.Add("Stage", GetType(String))'6
        'dt.Columns.Add("Status", GetType(String))'7
        'dt.Columns.Add("Remarks", GetType(String))'8
        'dt.Columns.Add("Date & Time", GetType(String))'9
        'dt.Columns.Add("USER", GetType(String))'10
        'dt.Columns.Add("Shift", GetType(String))'11
        'dt.Columns.Add("Time", GetType(String))'12

        For i = 0 To total_records

            Dim serial_number As String = DataGridView1.Rows(i).Cells(0).Value.ToString
            Dim serial_number_1_status As String = DataGridView1.Rows(i).Cells(8).Value.ToString
            Dim serial_number_1_remark As String = DataGridView1.Rows(i).Cells(9).Value.ToString
            Dim aoi_date As String = DataGridView1.Rows(i).Cells(13).Value.ToString

            aoi_save(serial_number, serial_number_1_status, serial_number_1_remark, aoi_date)

        Next

    End Sub

    Private Sub btn_auto_Click(sender As Object, e As EventArgs) Handles btn_auto.Click
        If btn_auto.Text = "Auto" Then
            btn_auto.Text = "Manual"
            auto_mode = True
            Timer1.Enabled = True
        Else
            btn_auto.Text = "Auto"
            timer_stop()
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        Try
            load_preview()
            If list_complete = True Then
                list_complete = False
                Timer1.Interval = 1000
                Timer1.Enabled = True
                GoTo next_loop
            End If
            export_to_aoi_database()
            Timer2.Interval = 1000
            Timer2.Enabled = True
        Catch ex As Exception
            timer_stop()
            MsgBox("List Box is Empty, Load the files now", vbInformation, "Files Empty")
            mainform.ts_message.Text = ex.Message
        End Try
next_loop:
    End Sub
    Private Sub timer_stop()
        Timer2.Enabled = False
        Timer1.Enabled = False
        auto_mode = False
        list_complete = False
    End Sub

    Private Sub btn_browse_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txt_file_path.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Process.Start(txt_file_path.Text & ListBox1.SelectedItem)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TxtSearch.Text = "" Then
            MsgBox("Search Text is Empty", vbInformation, "Empty")
        Else
            SearchFile()
        End If
    End Sub
    Private Sub SearchFile()
        Dim count As Integer = ListBox1.Items.Count - 1
        Dim words As String
        For search = 0 To count
            words = ListBox1.Items.Item(search)
            If InStr(words.ToLower, TxtSearch.Text.ToLower) Then
                ListBox1.SelectedItem = words
            End If
        Next
    End Sub
End Class