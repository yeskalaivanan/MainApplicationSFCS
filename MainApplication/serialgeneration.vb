Imports System.IO
Imports MySql.Data.MySqlClient
Public Class serialgeneration
    Dim SDA As New MySqlDataAdapter

    Private Sub serialgeneration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim selected_row As Integer = mainform.dg_workorder.CurrentRow.Index
        txt_product_name.Text = g_p_name
        txt_serial_number.Text = backup_serial_number
        txt_panel_number.Text = backup_panel_number
        txt_panel_size.Text = backup_panel
        txt_quantity.Text = wo_quantity
        g_workorder = mainform.dg_workorder.Rows(selected_row).Cells(2).Value
        btn_generate_serial.Enabled = False
    End Sub
    Function generate_serial_number()
        Dim selected_row As Integer = mainform.dg_workorder.CurrentRow.Index
        Dim product_status As String = mainform.dg_workorder.Rows(selected_row).Cells(0).Value.ToString

        If product_status <> "Active" Then
            MsgBox("Serial number is alreay created", vbInformation, "Error")
            GoTo finish
        End If

        Dim serial_number_folder As String = "\\10.1.77.87\VEPL_Serial_Number"
        serial_number_folder = "F:\backup"
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
        temp_string = Format(Val(txt_serial_number.Text), "#000000")
        digit4 = temp_string
        digit5 = g_p_code 'PC_BETTER
        digit6 = g_s_version  'PC_BETTER_VERSION


        panel_total = Math.Round(txt_quantity.Text / txt_panel_size.Text)

        Dim panel_mod As Integer = txt_quantity.Text Mod txt_panel_size.Text
        If panel_mod > 0 Then
            panel_total = panel_total + 1
        End If
        Dim headings As String = ""
        Dim datas As String = ""
        panel_number = txt_panel_number.Text
        count = 0
        For i = 1 To panel_total
            filepath = File.AppendText(serial_number_folder & "\PCBA" & panel_number & ".txt")
            headings = Chr(34) & "PanelID" & Chr(34) & ","
            datas = Chr(34) & "PCBA" & panel_number & Chr(34) & ","
            For j = 1 To txt_panel_size.Text

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
        lasermarking.change_process()
        serial_number = Mid(serial_number, 6, 6)
        lasermarking.save_next_serial(serial_number, panel_number - 1)
        mainform.load_productinfo_parameters()
finish:
        Return True
    End Function

    Private Sub btn_generate_serial_Click(sender As Object, e As EventArgs) Handles btn_generate_serial.Click
        Try
            generate_serial_number()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_save_details_Click(sender As Object, e As EventArgs) Handles btn_save_details.Click
        frmpcb.Show()
    End Sub
End Class