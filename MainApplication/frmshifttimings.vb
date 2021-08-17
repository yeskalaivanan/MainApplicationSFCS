Imports MySql.Data.MySqlClient

Public Class frmshifttimings
    Dim SDA As New MySqlDataAdapter
    Dim bSource As New BindingSource
    Dim today_year, today_month, today_date As Integer
    Private Sub frmshifttimings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        today_year = Now.Year
        today_month = Now.Month
        today_date = Now.Day

        dtp_shift_start.Value = New Date(today_year, today_month, today_date, 6, 0, 0, 0)
        dtp_shift_stop.Value = New Date(today_year, today_month, today_date, 14, 30, 0, 0)
        dtp_planned.Value = New Date(today_year, today_month, today_date, 0, 30, 0, 0)

        Dim shift_hour As Date
        Dim inTime As DateTime = Convert.ToDateTime(dtp_shift_start.Text)
        Dim outTime As DateTime = Convert.ToDateTime(dtp_shift_stop.Text)

        If outTime >= inTime Then
            shift_hour = outTime.Subtract(inTime).ToString
        End If

        txt_shift_time.Text = shift_hour.ToShortTimeString
        load_down_time_sql()
        InitializeGrid()
        calculate_time()
        cmb_shift.SelectedIndex = 0
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        create_data_downtime_sql()
        load_down_time_sql()
        calculate_time()
        'create_chart
    End Sub

    Function load_down_time_sql()
        Dim dbDataSet_downtime As New DataTable
        Try
            conn_stb_new.Open()
            Query = "select downdate,starttime,stoptime,difftime,reason,shiftstarttime,shiftendtime,shift from downtime where downdate = '" & Now.Date & "'"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_downtime)
            bSource.DataSource = dbDataSet_downtime
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet_downtime)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()

        End Try
        Return True
    End Function
    Function create_data_downtime_sql()
        Dim CMD As New MySqlCommand
        Dim today_date As Date = Now.Date
        Dim inTime As DateTime = Convert.ToDateTime(dtp_start.Text)
        Dim outTime As DateTime = Convert.ToDateTime(dtp_stop.Text)
        Dim diff_time As Date
        If outTime >= inTime Then
            diff_time = outTime.Subtract(inTime).ToString
        End If

        Try
            Query = "insert into downtime(downdate,starttime,stoptime,difftime,reason,shiftstarttime,shiftendtime,shift) values ('" & today_date & "','" & dtp_start.Value.ToShortTimeString & "','" & dtp_stop.Value.ToShortTimeString & "','" & diff_time.ToShortTimeString & "','" & cmb_reason.Text & "','" & dtp_shift_start.Value.ToShortTimeString & "','" & dtp_shift_stop.Value.ToShortTimeString & "','" & cmb_shift.SelectedItem & "')"
            conn_stb_new.Open()
            CMD = New MySqlCommand(Query, conn_stb_new)
            Dim dr As MySqlDataReader
            dr = CMD.ExecuteReader()
            MsgBox("Data added successfully", vbInformation)
            mainform.ts_message.Text = "Data added successfully"
        Catch ex As Exception
            mainform.ts_message.Text = ex.Message
            MsgBox(ex.Message, vbCritical)
        Finally
            CMD.Dispose()
            conn_stb_new.Close()
        End Try
        Return True
    End Function

    Private Sub cmb_shift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_shift.SelectedIndexChanged
        If cmb_shift.SelectedItem = "A" Then
            dtp_shift_start.Value = New Date(today_year, today_month, today_date, 6, 0, 0, 0)
            dtp_shift_stop.Value = New Date(today_year, today_month, today_date, 14, 30, 0, 0)
            dtp_planned.Value = New Date(today_year, today_month, today_date, 0, 30, 0, 0)
        ElseIf cmb_shift.SelectedItem = "B" Then
            dtp_shift_start.Value = New Date(today_year, today_month, today_date, 14, 0, 0, 0)
            dtp_shift_stop.Value = New Date(today_year, today_month, today_date, 22, 30, 0, 0)
            dtp_planned.Value = New Date(today_year, today_month, today_date, 0, 30, 0, 0)
        Else
            dtp_shift_start.Value = New Date(today_year, today_month, today_date, 22, 0, 0, 0)
            dtp_shift_stop.Value = New Date(today_year, today_month, today_date, 6, 30, 0, 0)
            dtp_planned.Value = New Date(today_year, today_month, today_date, 0, 30, 0, 0)
        End If
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
            .Font = New Font("Tahoma", 12)
            'Adjust the width each Column to fit.
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoResizeColumns()
            'Adjust Header Styles.
            With .ColumnHeadersDefaultCellStyle
                .BackColor = Color.Navy
                .ForeColor = Color.White
                .Font = New Font("Tahoma", 12, FontStyle.Bold)
            End With
        End With
    End Sub
    Function calculate_time()
        Dim shift_time As TimeSpan
        Dim temp_count As TimeSpan
        Dim planned As TimeSpan
        Dim temp_string, temp_string1, temp_string2 As String
        If DataGridView1.RowCount < 1 Then
            MsgBox("No Data")
        End If

        For i = 0 To DataGridView1.RowCount - 1
            temp_string = DataGridView1.Rows(i).Cells(3).Value
            temp_count = temp_count + TimeSpan.Parse(temp_string)
        Next

        txt_total_down.Text = temp_count.ToString
        temp_string1 = txt_shift_time.Text
        temp_string2 = dtp_planned.Text
        'Dim compare_time As Date = Format(temp_string2, "T")
        planned = TimeSpan.Parse(temp_string2)
        shift_time = TimeSpan.Parse(temp_string1) - planned - temp_count
        planned_time = TimeSpan.Parse(temp_string1) - planned
        txt_acutal_time.Text = shift_time.ToString
        actual_time = shift_time

        actual_time_sec = convert_time_to_sec(actual_time.ToString)
        planned_time_sec = convert_time_to_sec(planned_time.ToString)
        Return True
    End Function
End Class