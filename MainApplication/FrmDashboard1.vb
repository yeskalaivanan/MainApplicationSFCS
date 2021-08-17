Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient
Public Class FrmDashboard1
    Dim downtime As Integer
    Dim value1, value2 As Integer
    Dim myFont As New Font("Tahoma", 14, FontStyle.Bold)
    Private Sub btn_start_Click(sender As Object, e As EventArgs)
        yield_aoi_timer = True
        mainform.check_yield_timer()
    End Sub

    Private Sub btn_stop_Click(sender As Object, e As EventArgs)
        yield_aoi_timer = False
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)


    '    '//
    '    Chart1.Titles.Clear()
    '    '// Clear Legends & Series
    '    Chart1.Series.Clear()
    '    Chart1.Legends.Clear()
    '    '// Clear Points
    '    For Each xSeries In Chart1.Series
    '        xSeries.Points.Clear()
    '    Next
    '    '// Create Legends
    '    Dim Legend1 As Legend = New Legend()
    '    Legend1.Name = "Legend1"
    '    Chart1.Legends.Add(Legend1)
    '    '// Create Series
    '    Dim Series1 As Series = New Series()

    '    '// Add Series
    '    With Chart1
    '        .Series.Add(Series1)

    '    End With
    '    '//
    '    Try
    '        Dim myFont As New Font("Tahoma", 14, FontStyle.Bold)
    '        Chart1.Titles.Add("Sample Chart")
    '        Chart1.Titles(0).Font = myFont
    '        '// Define Chart Type.
    '        For Each xSeries In Chart1.Series
    '            Select Case cmbChartType.Text
    '                Case "Column"
    '                    xSeries.ChartType = SeriesChartType.Column
    '                Case "Line"
    '                    xSeries.ChartType = SeriesChartType.Line
    '                Case "Point"
    '                    xSeries.ChartType = SeriesChartType.Point
    '                Case "Area"
    '                    xSeries.ChartType = SeriesChartType.Area
    '                Case "BoxPlot"
    '                    xSeries.ChartType = SeriesChartType.BoxPlot

    '            End Select
    '            '// Show Legend
    '            'If chkShowLegend.Checked Then
    '            '    xSeries.IsVisibleInLegend = True
    '            'Else
    '            '    xSeries.IsVisibleInLegend = False
    '            'End If
    '            '// View the value of a chart point on mouse over.
    '            xSeries.ToolTip = "#VAL{0.00}"
    '        Next
    '        '//
    '        With Chart1
    '            .Series(0).LegendText = cmbChartType.SelectedItem '"Value 1"
    '        End With
    '        '// Show all Axis Label
    '        Chart1.ChartAreas(0).AxisX.Interval = 1
    '        '//
    '        With Chart1.ChartAreas("ChartArea1")
    '            .AxisX.MajorGrid.LineWidth = 1
    '            .AxisY.MajorGrid.LineWidth = 1
    '        End With

    '        '// LOOP DISPLAY


    '        'For CountData As Integer = 0 To DataGridView1.Rows.Count - 1
    '        '    With Chart1

    '        '        .Series(0).Points.AddXY(DataGridView1.Item(0, CountData).Value, DataGridView1.Item(meter_no, CountData).Value)


    '        '    End With
    '        'Next



    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'DataGridView1.Column
    End Sub



    Function down_time()
        Dim availability As Integer
        Try
            availability = ((60 - downtime) / 60) * 100
            lbl_availability.Text = availability & "%"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return 0
    End Function



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
        create_chart()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ProgressBar1.Value = 100 Then
            ProgressBar1.Value = 0
        End If
        ProgressBar1.Value = ProgressBar1.Value + 10


    End Sub

    Private Sub lbl_availability_Click(sender As Object, e As EventArgs) Handles lbl_availability.Click

    End Sub

    Function create_chart()
        Dim availability As Integer
        Dim performance As Integer
        Dim OEE As Integer

        aoi_yield = (Val(txt_pass_count.Text) / Val(txt_total_count.Text)) * 100
        lbl_AOI.Text = aoi_yield & "%"

        availability = (actual_time_sec / planned_time_sec) * 100
        lbl_availability.Text = availability & "%"

        performance = (txt_total_count.Text / (actual_time_sec / backup_cttime)) * 100
        lbl_performance.Text = performance & "%"

        OEE = (aoi_yield / 100) * (availability / 100) * (performance / 100) * 100
        lbl_OEE.Text = OEE & "%"
        Chart1.Series.Clear()
        Chart1.Series.Add("Series1")

        Chart1.Titles(0).Font = myFont
        Chart1.Series(0).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut

        Chart1.Series("Series1").Points.AddXY("OLE", OEE)
        Chart1.Series("Series1").Points.AddXY("", 100 - OEE)
        Chart1.Series("Series1").Points(0).Color = Color.Green
        Chart1.Series("Series1").Points(0).IsValueShownAsLabel = False
        'Chart1.Series("Series1").Points(0).LabelFormat = "#%"
        Chart1.Series("Series1").IsVisibleInLegend = False

        Chart2.Series.Clear()
        Chart2.Series.Add("Series2")
        Chart2.Titles(0).Font = myFont
        Chart2.Series(0).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Chart2.Series("Series2").Points.AddXY("Availability", availability)
        Chart2.Series("Series2").Points.AddXY("", 100 - availability)
        Chart2.Series("Series2").Points(0).Color = Color.Green
        Chart2.Series("Series2").Points(0).IsValueShownAsLabel = False
        'Chart2.Series("Series2").Points(0).LabelFormat = "#%"
        Chart2.Series("Series2").IsVisibleInLegend = False

        Chart3.Series.Clear()
        Chart3.Series.Add("Series3")
        Chart3.Titles(0).Font = myFont
        Chart3.Series(0).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Chart3.Series("Series3").Points.AddXY("Performance", performance)
        Chart3.Series("Series3").Points.AddXY("", 100 - performance)
        Chart3.Series("Series3").Points(0).Color = Color.Green
        Chart3.Series("Series3").Points(0).IsValueShownAsLabel = False
        'Chart3.Series("Series3").Points(0).LabelFormat = "#%"
        Chart3.Series("Series3").IsVisibleInLegend = False

        Chart4.Series.Clear()
        Chart4.Series.Add("Series4")
        Chart4.Titles(0).Font = myFont
        Chart4.Series(0).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Chart4.Series("Series4").Points.AddXY("AOI", aoi_yield)
        Chart4.Series("Series4").Points.AddXY("", 100 - aoi_yield)
        Chart4.Series("Series4").Points(0).Color = Color.Green
        Chart4.Series("Series4").Points(0).IsValueShownAsLabel = False
        'Chart4.Series("Series4").Points(0).LabelFormat = "#%"
        Chart4.Series("Series4").IsVisibleInLegend = False

        Chart5.Series.Clear()
        Chart5.Series.Add("Total")
        Chart5.Series.Add("AOI")
        Chart5.Titles(0).Font = myFont
        Chart5.Series(0).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
        For i = 0 To 23
            If hourly_output_total(i) > 0 Then
                Chart5.Series("Total").Points.AddXY(i, hourly_output_total(i))
                Chart5.Series("AOI").Points.AddXY(i, hourly_output_pass(i))
            End If
        Next

        Chart5.Series("Total").Points(0).Color = Color.Blue
        Chart5.Series("AOI").Points(0).Color = Color.Yellow
        Chart5.Series("Total").Points(0).IsValueShownAsLabel = False
        'Chart4.Series("Series4").Points(0).LabelFormat = "#%"
        Chart5.Series("Total").IsVisibleInLegend = False

        Dim workorder_rate As Integer = (Val(txt_total_count.Text) / backup_shift_target) * 100
        lbl_workorder.Text = workorder_rate & "%"

        Chart6.Series.Clear()
        Chart6.Series.Add("Series6")
        Chart6.Titles(0).Font = myFont
        Chart6.Series(0).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Chart6.Series("Series6").Points.AddXY("Workorder Rate", workorder_rate)
        Chart6.Series("Series6").Points.AddXY("", 100 - workorder_rate)
        Chart6.Series("Series6").Points(0).Color = Color.Yellow
        Chart6.Series("Series6").Points(0).IsValueShownAsLabel = False
        'Chart4.Series("Series4").Points(0).LabelFormat = "#%"
        Chart6.Series("Series6").IsVisibleInLegend = False
        Return 0
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbl_time.Text = Now

        'txt_active_time.Text = TimeSpan.Parse(frmshifttimings.dtp_shift_start.ToString) - TimeSpan.Parse(Now.ToString)
    End Sub

    Private Sub FrmDashboard1_Load(sender As Object, e As EventArgs) Handles Me.Load


        Chart1.Titles.Add("OEE")
        Chart2.Titles.Add("AVA")
        Chart3.Titles.Add("EFF")
        Chart4.Titles.Add("QUA")
        Chart5.Titles.Add("Progress")
        Chart6.Titles.Add("Production Rate")

        For i = 0 To 24
            calculate_per_hour_total(i)
            calculate_per_hour_pass(i)
        Next

        yield_aoi_timer = True
        mainform.check_yield_timer()

        lbl_line_no.Text = "Line No : " & g_line_number
        lbl_product_name.Text = "Product Name : " & backup_product_name
        Timer1.Interval = 1000
        Timer1.Enabled = True

        lbl_target.Text = backup_shift_target & vbCrLf & "Target Quantity"
        lbl_actual.Text = txt_total_count.Text & vbCrLf & "Actual Quantity"
        lbl_expected.Text = "" & vbCrLf & "Expected Quantity"
        ProgressBar1.Maximum = backup_shift_target



    End Sub

    Function calculate_per_hour_total(today_hour As String)
        Dim READER As MySqlDataReader
        Dim CMD As New MySqlCommand

        If today_hour.Length = 1 Then
            today_hour = "0" & today_hour
        End If


        Dim today_year As String = Now.Year
        Dim today_month As String = Now.Month
        If today_month.Length = 1 Then
            today_month = "0" & today_month
        End If
        Dim today_date = "03" 'Now.Day
        'Dim today_hour = Now.Hour


        Dim date1 As String = today_year & today_month & today_date & today_hour ' & "0000"

        Try
            conn_stb_new.Open()
            Dim Query As String

            'Query = "Select * from aoi WHERE Status='FAIL'"
            Query = "Select * from aoi where AOITime like '%" + date1 + "%' "
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            hourly_output_total(today_hour) = count
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
        Return True
    End Function
    Function calculate_per_hour_pass(today_hour As String)
        Dim READER As MySqlDataReader
        Dim CMD As New MySqlCommand

        If today_hour.Length = 1 Then
            today_hour = "0" & today_hour
        End If


        Dim today_year As String = Now.Year
        Dim today_month As String = Now.Month
        If today_month.Length = 1 Then
            today_month = "0" & today_month
        End If
        Dim today_date = "03" 'Now.Day
        'Dim today_hour = Now.Hour


        Dim date1 As String = today_year & today_month & today_date & today_hour ' & "0000"

        Try
            conn_stb_new.Open()
            Dim Query As String

            'Query = "Select * from aoi WHERE Status='FAIL'"
            Query = "Select * from aoi where AOITime like '%" + date1 + "%' and Status = '" + "PASS" + "'"
            CMD = New MySqlCommand(Query, conn_stb_new)
            READER = CMD.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            conn_stb_new.Close()
            hourly_output_pass(today_hour) = count
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
        Return True
    End Function

End Class