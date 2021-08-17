Public Class prewavesoldering
    Private Sub prewavesoldering_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_product_code.Text = g_p_code
        txt_product_name.Text = g_p_name
        txt_lot_no.Text = g_lot_number
        txt_line_no.Text = g_line_number
        cmb_status.SelectedIndex = 0
        cmb_remarks.Items.Clear()
        read_rework_remarks()
        cmb_remarks.SelectedIndex = 0
        txt_pcbsno.Select()
        cmb_shifting_time.SelectedText = shifting_time
    End Sub
    Private Sub txt_pcbsno_LostFocus(sender As Object, e As EventArgs)
        btn_save.Focus()
    End Sub
    Private Sub read_rework_remarks()
        Dim appPath As String = Application.StartupPath()
        Dim FILE_NAME As String = appPath & "/Documents/rework_remarks.txt"
        Dim TextLine As String = ""
        Dim txt_data(10) As String
        Dim count As Integer = 0
        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim objReader As New System.IO.StreamReader(FILE_NAME)
            Do While objReader.Peek() <> -1
                'TextLine = TextLine & objReader.ReadLine() & vbNewLine
                TextLine = objReader.ReadLine()
                'strArr = TextLine.Split(",")
                'txt_data(count) = strArr(strArr.Length - 1)
                'count = count + 1                
                cmb_remarks.Items.Add(TextLine)
            Loop
        Else
            MsgBox("File Does Not Exist", vbCritical, "Error")
        End If
    End Sub

    Private Sub cmb_remarks_SelectedIndexChanged(sender As Object, e As EventArgs)
        rtxt_remarks.Text = ""
    End Sub

    Private Sub cmb_status_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cmb_status.SelectedIndex = 1 Then
            cmb_remarks.SelectedIndex = 1
        End If
    End Sub


    Private Sub txt_pcbsno_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btn_save_Click(sender, e)
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If pcb_timer_lock = False Then
            prewavesave()
            GoTo nextline
        End If
        check_time_lasermarking(txt_pcbsno.Text)
        If mainform.DataGridView3.RowCount > 1 Then
            pcb_start_time = mainform.DataGridView3.Rows(0).Cells(2).Value.ToString
            total_pcb_time = DateDiff(DateInterval.Hour, Now, pcb_start_time)
            If total_pcb_time < 0 Then
                total_pcb_time = (total_pcb_time * -1)
                If total_pcb_time < 48 Then
                    prewavesave()
                Else
                    MsgBox("PCB Reached more than 48 hour time period - " & total_pcb_time, vbInformation, "Warning")
                End If
            Else
                MsgBox("Time is Advanced", vbInformation, "Time Mismatch")
            End If
        Else
            MsgBox("PCB Number is not found in previous stage", vbInformation, "PCB Not found")
        End If
nextline:
        txt_pcbsno.Focus()
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        result = check_serialnumber_aoi(txt_pcbsno.Text)
        If result = True Then
            update_prewave(txt_pcbsno.Text)
        Else
            MsgBox("AOI Stage not Passed", vbCritical, "Error")
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
    Private Sub prewavesave()
        remarks = cmb_remarks.SelectedItem & " " & rtxt_remarks.Text
        remarks = remarks.TrimEnd
        If txt_pcbsno.Text = "" Then
            MsgBox("Serial Number is Empty", vbCritical, "No Data")
        Else
            result = check_serialnumber_aoi(txt_pcbsno.Text)
            If result = True Then
                prewave_save(txt_pcbsno.Text, txt_product_code.Text, txt_product_name.Text, txt_lot_no.Text, txt_line_no.Text, Stage_aoi, cmb_status.SelectedItem, remarks)
            Else
                MsgBox("AOI Stage not Passed", vbCritical, "Error")
            End If
        End If
    End Sub
End Class