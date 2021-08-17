Public Class productinfo
    Private Sub productinfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'read_product()
        'read_product_names()
        'read_stage_details(g_p_name)
        For i = 0 To g_total_product_names - 1
            cmb_productname.Items.Add(g_product_names(i))
        Next
        cmb_productname.Text = backup_product_name
        txt_productcode.Text = backup_product_code
        txt_workorder.Text = backup_workorder
        txt_side.Text = backup_side
        txt_lot_no.Text = g_lot_number
        cmb_line_no.SelectedIndex = g_line_number - 1
        txt_panel.Text = backup_panel
        txt_cttime.Text = backup_cttime
        txt_hourly_target.Text = backup_hourly_target
        txt_shift_target.Text = backup_shift_target
        'txt_startingserialnumber.Text = g_start_pcb_number
        cmb_productname.Focus()
    End Sub

    Private Sub read_product()
        Dim appPath As String = Application.StartupPath()
        Dim FILE_NAME As String = appPath & "/Documents/productnames.txt"
        Dim TextLine As String = ""
        Dim txt_data(10) As String
        Dim count As Integer = 0
        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim objReader As New System.IO.StreamReader(FILE_NAME)
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine()
                cmb_productname.Items.Add(TextLine)
            Loop
        Else
            MsgBox("File Does Not Exist", vbCritical, "Error")
        End If
    End Sub
    Private Sub save_txt()
        Dim appPath As String = Application.StartupPath()
        Dim FILE_NAME As String = appPath & "/Documents/productdetails.txt"
        'Dim i As Integer
        Dim aryText(4), aryName(4) As String
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
        Try
            aryText(0) = cmb_line_no.SelectedItem
            aryText(0) = aryText(0).Replace(vbCrLf, "")
            aryText(1) = cmb_productname.SelectedItem.ToString
            aryText(1) = aryText(1).Replace(vbCrLf, "")

            aryName(0) = "LineNumber"
            aryName(1) = "Product Name"

            For i = 0 To 1
                objWriter.WriteLine(aryName(i) & "," & aryText(i))
            Next
            objWriter.Close()
            read_local_txt_product_details()
            'MsgBox("Data Saved Successfully", vbInformation, "Productinfo")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            objWriter.Close()
        End Try
    End Sub

    Private Sub txt_save_Click(sender As Object, e As EventArgs) Handles txt_save.Click
        update_productinfo(cmb_line_no.SelectedItem)
        save_txt()
        mainform.load_productinfo_parameters()
    End Sub

    Private Sub cmb_line_no_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_line_no.SelectedIndexChanged
        read_productinfo(cmb_line_no.SelectedItem)
    End Sub

    Private Sub cmb_productname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_productname.SelectedIndexChanged
        mainform.read_grid1_backup_parameters_by_productname(cmb_productname.SelectedItem)
    End Sub
End Class