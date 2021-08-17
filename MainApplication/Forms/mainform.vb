Imports System.ComponentModel
Imports System.Net.NetworkInformation
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class mainform
    Dim old_minute As String
    Dim new_mintue As String
    Private m_ChildFormNumber As Integer

    Dim dbDataSet As New DataTable
    Dim dbDataSet_user As New DataTable
    Dim dbDataSet_search_pcb As New DataTable
    Dim dbDataSet_product_info As New DataTable
    Dim dbDataSet_stage_info As New DataTable
    Dim bSource As New BindingSource
    Dim bSource1 As New BindingSource
    Dim CMD As New MySqlCommand
    Dim SDA As New MySqlDataAdapter
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        LoginForm1.Show()
    End Sub
    Private Sub PrewaveSolderingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrewaveSolderingToolStripMenuItem.Click
        prewavesoldering.MdiParent = Me
        prewavesoldering.Show()
    End Sub
    Private Sub LaserMarkingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaserMarkingToolStripMenuItem.Click
        read_lasermarking()
        showdata.MdiParent = Me
        showdata.Show()
    End Sub
    Private Sub AOIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AOIToolStripMenuItem.Click
        read_aoi()
        showdata.MdiParent = Me
        showdata.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        mytimestamp_sql = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        save_time = Format(Now, "dd-MM-yy")
        ToolStripStatusLabel3.Text = mytimestamp_sql
        If (old_minute <> Now.Minute) Then
            check_yield_timer()
            old_minute = Now.Minute
        End If

        Dim compare_time As Date = Format(Now, "T")

        If compare_time > shiftA_start And compare_time < shiftA_finish Then
            shifting_time = "A"
        ElseIf compare_time > shiftB_start And compare_time < shiftB_finish Then
            shifting_time = "B"
        Else
            shifting_time = "C"
        End If
    End Sub
    Public Sub check_yield_timer()

        If yield_aoi_timer = True Then
            read_yield_aoi_total()
            read_yield_aoi_pass()
            read_yield_aoi_rpass()
            read_yield_aoi_fail()
            FrmDashboard1.create_chart()
        End If
        If yield_wave_timer = True Then
            read_yield_postwave_total()
            read_yield_postwave_pass()
            read_yield_postwave_fail()
        End If
        If yield_fg_timer = True Then
            read_yield_fg_total()
            read_yield_fg_pass()
            read_yield_fg_fail()
        End If
    End Sub

    Private Sub mainform_Load(sender As Object, e As EventArgs) Handles Me.Load
        conndb_stb() 'connect database
        disable_menus() 'disable all menu bars except login menu
        'read_local_txt_product_details() 'read line number and product names
        'load_filepath() 'save records local path
        refresh_grid1_products() 'refresh products data in gridview1
        'refresh_grid2_line_details() 'load line details in gridview2
        'read_grid1_backup_parameters_by_productname(g_p_name)
        'read_productinfo_from_lineno(g_line_number)
        TimerLockToolStripMenuItem.Checked = True
        LoginForm1.MdiParent = Me
        LoginForm1.Show()
        InitializeGrid()
        load_workorder()
    End Sub

    Private Sub PostwaveSolderingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PostwaveSolderingToolStripMenuItem.Click
        postwavesoldering.MdiParent = Me
        postwavesoldering.Show()
    End Sub

    Private Sub ProductInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductInfoToolStripMenuItem.Click
        If (Panel2.Visible = True) Then
            Panel2.Visible = False
            Panel1.Visible = False
            dg_workorder.Visible = False
        Else
            Panel2.Visible = True
            Panel1.Visible = True
            dg_workorder.Visible = True
        End If
    End Sub
    Private Sub ReworkToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReworkToolStripMenuItem1.Click
        rework.MdiParent = Me
        rework.Show()
    End Sub

    Private Sub AOIToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AOIToolStripMenuItem1.Click
        AOI.MdiParent = Me
        AOI.Show()
    End Sub

    Private Sub TouchUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TouchUpToolStripMenuItem.Click
        touchupvi.MdiParent = Me
        touchupvi.Show()
    End Sub

    Private Sub RouterToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RouterToolStripMenuItem1.Click
        router.MdiParent = Me
        router.Show()
    End Sub

    Private Sub ReworkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReworkToolStripMenuItem.Click
        read_rework()
        showdata.MdiParent = Me
        showdata.Show()
    End Sub

    Private Sub PrewaveSolderingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrewaveSolderingToolStripMenuItem1.Click
        read_prewavesoldering()
        showdata.MdiParent = Me
        showdata.Show()
    End Sub

    Private Sub PostwaveSolderingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PostwaveSolderingToolStripMenuItem1.Click
        read_postwavesoldering()
        showdata.MdiParent = Me
        showdata.Show()
    End Sub

    Private Sub TouchupAndVIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TouchupAndVIToolStripMenuItem.Click
        read_touchupvi()
        showdata.MdiParent = Me
        showdata.Show()
    End Sub

    Private Sub RouterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RouterToolStripMenuItem.Click
        read_router()
        showdata.MdiParent = Me
        showdata.Show()
    End Sub

    Private Sub AOIToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AOIToolStripMenuItem2.Click
        Yieldaoi.MdiParent = Me
        Yieldaoi.Show()
    End Sub

    Private Sub YieldStartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YieldStartToolStripMenuItem.Click
        productinfo.MdiParent = Me
        productinfo.Show()
    End Sub

    Private Sub WaveSolderingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WaveSolderingToolStripMenuItem.Click
        yieldpostwave.MdiParent = Me
        yieldpostwave.Show()
    End Sub

    Private Sub FGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FGToolStripMenuItem.Click
        yieldfg.MdiParent = Me
        yieldfg.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Developer : Kalaivanan" & vbCrLf & "Contact No : 9894227523" & vbCrLf & "Server IP 10.1.73.90", vbInformation)
    End Sub

    Private Sub VersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionToolStripMenuItem.Click
        Dim fileReader As String
        Dim appPath As String = Application.StartupPath()
        Dim FILE_NAME As String = appPath & "/Documents/Logs.txt"
        fileReader = My.Computer.FileSystem.ReadAllText(FILE_NAME)
        'fileReader = My.Computer.FileSystem.ReadAllText("Notes.txt")
        MsgBox(fileReader)
    End Sub
    Private Sub FilePathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilePathToolStripMenuItem.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            backup_file_path = FolderBrowserDialog1.SelectedPath
        End If

        Dim appPath As String = Application.StartupPath()
        Dim FILE_NAME As String = appPath & "/Documents/filepath.txt"
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
        Try
            objWriter.WriteLine(backup_file_path)
            objWriter.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            objWriter.Close()
        End Try
    End Sub
    Private Sub load_filepath()
        Dim fileReader As String
        Dim appPath As String = Application.StartupPath()
        Dim FILE_NAME As String = appPath & "/Documents/filepath.txt"
        fileReader = My.Computer.FileSystem.ReadAllText(FILE_NAME)
        backup_file_path = fileReader
        backup_file_path = backup_file_path.TrimEnd
    End Sub

    Private Sub AddUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddUserToolStripMenuItem.Click
        adduser.MdiParent = Me
        adduser.Show()
    End Sub

    Private Sub UpdateUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateUserToolStripMenuItem.Click
        changepassword.MdiParent = Me
        changepassword.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim reply As String = MsgBox("Are you want to close?", vbOKCancel, "Application")
        If reply = vbOK Then
            End
        Else

        End If
    End Sub

    Private Sub mainform_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim reply As String = MsgBox("Are you want to close?", vbQuestion + vbOKCancel, "Application")
        If reply = vbOK Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub refresh_grid1_products()
        Dim dbDataSet_products As New DataTable
        Try
            conn_stb_new.Open()
            Dim Query As String
            Query = "select * from productnames"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_products)
            bSource.DataSource = dbDataSet_products
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet_products)
            conn_stb_new.Close()
            g_total_product_names = DataGridView1.RowCount - 1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            'conn_stb_new.Dispose()
            conn_stb_new.Close()
        End Try
    End Sub
    Private Sub refresh_grid2_line_details()
        Dim dbDataSet_p_names As New DataTable
        Try
            conn_stb_new.Open()
            Dim Query As String
            Query = "select * from linedetails"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_p_names)
            bSource1.DataSource = dbDataSet_p_names
            DataGridView2.DataSource = bSource1
            SDA.Update(dbDataSet_p_names)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            'conn_stb_new.Dispose()
            conn_stb_new.Close()
        End Try
    End Sub
    Function read_grid1_backup_parameters_by_productname(p_name As String)

        backup_product_name = p_name

        For i = 0 To g_total_product_names - 1
            g_product_names(i) = DataGridView1.Rows(i).Cells(0).Value.ToString
            g_product_codes(i) = DataGridView1.Rows(i).Cells(10).Value.ToString
            g_product_sides(i) = DataGridView1.Rows(i).Cells(13).Value.ToString
            If g_product_names(i) = p_name Then
                g_product_location = i
            End If
        Next

        backup_stage_1 = (DataGridView1.Rows(g_product_location).Cells(1).Value.ToString)
        backup_stage_2 = (DataGridView1.Rows(g_product_location).Cells(2).Value.ToString)
        backup_stage_3 = (DataGridView1.Rows(g_product_location).Cells(3).Value.ToString)
        backup_stage_4 = (DataGridView1.Rows(g_product_location).Cells(4).Value.ToString)
        backup_stage_5 = (DataGridView1.Rows(g_product_location).Cells(5).Value.ToString)
        backup_stage_6 = (DataGridView1.Rows(g_product_location).Cells(6).Value.ToString)
        backup_stage_7 = (DataGridView1.Rows(g_product_location).Cells(7).Value.ToString)
        backup_stage_8 = (DataGridView1.Rows(g_product_location).Cells(8).Value.ToString)
        backup_stage_9 = (DataGridView1.Rows(g_product_location).Cells(9).Value.ToString)

        backup_product_code = DataGridView1.Rows(g_product_location).Cells(10).Value.ToString
        backup_workorder = DataGridView1.Rows(g_product_location).Cells(11).Value.ToString
        backup_version = DataGridView1.Rows(g_product_location).Cells(12).Value.ToString
        backup_side = DataGridView1.Rows(g_product_location).Cells(13).Value.ToString
        backup_panel = DataGridView1.Rows(g_product_location).Cells(14).Value.ToString
        backup_cttime = DataGridView1.Rows(g_product_location).Cells(15).Value.ToString
        backup_hourly_target = DataGridView1.Rows(g_product_location).Cells(16).Value.ToString
        backup_shift_target = DataGridView1.Rows(g_product_location).Cells(17).Value.ToString
        backup_serial_number = DataGridView1.Rows(g_product_location).Cells(18).Value.ToString
        backup_panel_number = DataGridView1.Rows(g_product_location).Cells(19).Value.ToString
        g_stencil_part_no = DataGridView1.Rows(g_product_location).Cells(20).Value.ToString
        txt_productcode.Text = backup_product_code
        txt_workorder.Text = backup_workorder
        txt_version.Text = backup_version
        txt_side.Text = backup_side
        txt_panel.Text = backup_panel
        txt_cttime.Text = backup_cttime
        txt_hourly_target.Text = backup_hourly_target
        txt_shift_target.Text = backup_shift_target

        If backup_stage_1 = "yes" Then
            chk_lasermarking.Checked = True
        Else
            chk_lasermarking.Checked = False
        End If

        If backup_stage_2 = "yes" Then
            chk_spi.Checked = True
        Else
            chk_spi.Checked = False
        End If

        If backup_stage_3 = "yes" Then
            chk_pickandplace.Checked = True
        Else
            chk_pickandplace.Checked = False
        End If

        If backup_stage_4 = "yes" Then
            chk_aoi.Checked = True
        Else
            chk_aoi.Checked = False
        End If

        If backup_stage_5 = "yes" Then
            chk_rework.Checked = True
        Else
            chk_rework.Checked = False
        End If

        If backup_stage_6 = "yes" Then
            chk_prewave.Checked = True
        Else
            chk_prewave.Checked = False
        End If

        If backup_stage_7 = "yes" Then
            chk_postwave.Checked = True
        Else
            chk_postwave.Checked = False
        End If

        If backup_stage_8 = "yes" Then
            chk_touchupvi.Checked = True
        Else
            chk_touchupvi.Checked = False
        End If

        If backup_stage_9 = "yes" Then
            chk_router.Checked = True
        Else
            chk_router.Checked = False
        End If
        Return 0
    End Function
    Function read_productinfo_from_lineno()

        ' backup_product_name = p_name

        'For i = 0 To g_total_product_names - 1
        '    g_product_names(i) = DataGridView1.Rows(i).Cells(0).Value.ToString
        '    If g_product_names(i) = g_p_name Then
        '        g_product_location = i
        '    End If
        'Next
        'If line = "SMT 1" Then
        '    line = 1
        'ElseIf line = "SMT 2" Then
        '    line = 2
        'Else
        '    line = 3
        'End If
        line1 = backup_stage_1
        line2 = backup_stage_2
        line3 = backup_stage_3
        line4 = backup_stage_4
        line5 = backup_stage_5
        line6 = backup_stage_6
        line7 = backup_stage_7
        line8 = backup_stage_8
        line9 = backup_stage_9

        g_p_name = backup_product_name
        g_p_code = backup_product_code
        g_workorder = backup_workorder
        g_s_version = backup_version
        'g_lot_number = backup_
        g_panel_count = backup_panel
        g_side = backup_side
        g_CTtime = backup_cttime
        g_hourly_target = backup_hourly_target
        g_shift_target = backup_shift_target

        txt_product_name.Text = g_p_name
        txt_productcode.Text = g_p_code
        txt_workorder.Text = g_workorder
        txt_version.Text = g_s_version
        txt_side.Text = g_side
        txt_lot_no.Text = g_lot_number
        txt_panel.Text = g_panel_count
        txt_line_no.Text = g_line_number
        txt_cttime.Text = g_CTtime
        txt_hourly_target.Text = g_hourly_target
        txt_shift_target.Text = g_shift_target


        g_serial_number = backup_serial_number
        g_panel_number = backup_panel_number

        If line1 = "yes" Then
            'productinfo.chk_lasermarking.Checked = True
            'chk_lasermarking.Checked = True
            LaserMarkingToolStripMenuItem1.Enabled = True
        Else
            'productinfo.chk_lasermarking.Checked = False
            'chk_lasermarking.Checked = False
            LaserMarkingToolStripMenuItem1.Enabled = False
        End If

        If line2 = "yes" Then
            'productinfo.chk_spi.Checked = True
            'chk_spi.Checked = True
            ProcessLenseToolStripMenuItem.Enabled = True
        Else
            'productinfo.chk_spi.Checked = False
            'chk_spi.Checked = False
            ProcessLenseToolStripMenuItem.Enabled = False
        End If

        If line3 = "yes" Then
            'productinfo.chk_pickandplace.Checked = True
            'chk_pickandplace.Checked = True
            PickPlaceToolStripMenuItem.Enabled = True
        Else
            'productinfo.chk_pickandplace.Checked = False
            'chk_pickandplace.Checked = False
            PickPlaceToolStripMenuItem.Enabled = False
        End If

        If line4 = "yes" Then
            'productinfo.chk_aoi.Checked = True
            'chk_aoi.Checked = True
            AOIToolStripMenuItem1.Enabled = True
        Else
            'productinfo.chk_aoi.Checked = False
            'chk_aoi.Checked = False
            AOIToolStripMenuItem1.Enabled = False
        End If

        If line5 = "yes" Then
            'productinfo.chk_rework.Checked = True
            'chk_rework.Checked = True
            ReworkToolStripMenuItem1.Enabled = True
        Else
            'productinfo.chk_rework.Checked = False
            'chk_rework.Checked = False
            ReworkToolStripMenuItem1.Enabled = False
        End If

        If line6 = "yes" Then
            'productinfo.chk_prewave.Checked = True
            'chk_prewave.Checked = True
            PrewaveSolderingToolStripMenuItem.Enabled = True
        Else
            'productinfo.chk_prewave.Checked = False
            'chk_prewave.Checked = False
            PrewaveSolderingToolStripMenuItem.Enabled = False
        End If

        If line7 = "yes" Then
            'productinfo.chk_postwave.Checked = True
            'chk_postwave.Checked = True
            PostwaveSolderingToolStripMenuItem.Enabled = True
        Else
            'productinfo.chk_postwave.Checked = False
            'chk_postwave.Checked = False
            PostwaveSolderingToolStripMenuItem.Enabled = False
        End If

        If line8 = "yes" Then
            'productinfo.chk_touchupvi.Checked = True
            'chk_touchupvi.Checked = True
            TouchUpToolStripMenuItem.Enabled = True
        Else
            'productinfo.chk_touchupvi.Checked = False
            'chk_touchupvi.Checked = False
            TouchUpToolStripMenuItem.Enabled = False
        End If

        If line9 = "yes" Then
            'productinfo.chk_router.Checked = True
            'chk_router.Checked = True
            RouterToolStripMenuItem1.Enabled = True
        Else
            'productinfo.chk_router.Checked = False
            'chk_router.Checked = False
            RouterToolStripMenuItem1.Enabled = False
        End If
        Return 0
    End Function

    Public Function load_productinfo_parameters()
        'read_local_txt_product_details() 'read line number and product names
        'load_filepath() 'save records local path
        refresh_grid1_products() 'refresh products data in gridview1
        'refresh_grid2_line_details() 'load line details in gridview2
        read_grid1_backup_parameters_by_productname(g_p_name)
        read_productinfo_from_lineno()
        Return 0
    End Function

    Private Sub LaserMarkingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LaserMarkingToolStripMenuItem1.Click
        lasermarking.MdiParent = Me
        lasermarking.Show()
    End Sub

    Private Sub TimerLockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimerLockToolStripMenuItem.Click
        If pcb_timer_lock = False Then
            pcb_timer_lock = True
            TimerLockToolStripMenuItem.Checked = True
        Else
            pcb_timer_lock = False
            TimerLockToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub PCBStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCBStatusToolStripMenuItem.Click
        Dim data As String = InputBox("Enter the Serial Number", "PCB Search")
        If data <> "" Then
            search_pcb(data)
            status.MdiParent = Me
            status.Show()
        Else
            MsgBox("Serial number is Empty", "No Value", vbInformation)
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub SerialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SerialToolStripMenuItem.Click
        serialgeneration.MdiParent = Me
        serialgeneration.Show()
    End Sub

    Private Sub DashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashToolStripMenuItem.Click
        frmdashboard.MdiParent = Me
        frmdashboard.Show()
    End Sub

    Private Sub AoiToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles AoiToolStripMenuItem3.Click
        frmAOI.MdiParent = Me
        frmAOI.Show()
    End Sub

    Private Sub txt_productcode_TextChanged(sender As Object, e As EventArgs) Handles txt_productcode.TextChanged

    End Sub

    Private Sub LaserMarkingToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles LaserMarkingToolStripMenuItem2.Click
        lasermarking.MdiParent = Me
        lasermarking.Show()
    End Sub

    Private Sub AOIToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles AOIToolStripMenuItem4.Click
        frmAOI.MdiParent = Me
        frmAOI.Show()
    End Sub

    Private Sub Aoi1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Aoi1ToolStripMenuItem.Click
        FrmDashboard1.MdiParent = Me
        FrmDashboard1.Show()
    End Sub

    Private Sub WorkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkToolStripMenuItem.Click
        frmworkordermain.MdiParent = Me
        frmworkordermain.Show()
    End Sub

    Private Sub Dash1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Dash1ToolStripMenuItem.Click
        FrmDashboard1.MdiParent = Me
        FrmDashboard1.Show()
    End Sub

    Private Sub ShiftTimingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShiftTimingsToolStripMenuItem.Click
        frmshifttimings.MdiParent = Me
        frmshifttimings.Show()
    End Sub
    Function load_workorder()
        Dim dbDataSet_products As New DataTable
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource
        Try
            conn_stb_new.Open()
            Dim Query As String
            Query = "select * from workorder where WOSTATE='Active' or WOSTATE='Process'"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_products)
            bSource.DataSource = dbDataSet_products
            dg_workorder.DataSource = bSource
            SDA.Update(dbDataSet_products)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            'conn_stb_new.Dispose()
            conn_stb_new.Close()
        End Try
        Return True
    End Function
    Private Sub InitializeGrid()
        With dg_workorder
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
    Private Sub Line1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Line1ToolStripMenuItem.Click
        load_workorder_line(Line1ToolStripMenuItem.Text)
    End Sub
    Function load_workorder_line(lineno As String)
        Dim dbDataSet_products As New DataTable
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource
        Try
            conn_stb_new.Open()
            Dim Query As String
            Query = "select * from workorder where LINEID = '" + lineno + "' and WOSTATE ='Active' or WOSTATE='Process' "
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_products)
            bSource.DataSource = dbDataSet_products
            dg_workorder.DataSource = bSource
            SDA.Update(dbDataSet_products)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            'conn_stb_new.Dispose()
            conn_stb_new.Close()
        End Try
        Return True
    End Function

    Private Sub Line2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Line2ToolStripMenuItem.Click
        load_workorder_line(Line2ToolStripMenuItem.Text)
    End Sub

    Private Sub Line3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Line3ToolStripMenuItem.Click
        load_workorder_line(Line2ToolStripMenuItem.Text)
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        load_workorder()
    End Sub

    Private Sub dg_workorder_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dg_workorder.CellEnter
        'Try
        Dim selected_row As Integer = dg_workorder.CurrentRow.Index
        g_p_name = dg_workorder.Rows(selected_row).Cells(5).Value.ToString
        wo_quantity = dg_workorder.Rows(selected_row).Cells(8).Value.ToString
        read_grid1_backup_parameters_by_productname(g_p_name)
        read_productinfo_from_lineno()
        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub dg_workorder_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_workorder.CellContentClick

    End Sub

    Private Sub dg_workorder_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_workorder.CellDoubleClick
        serialgeneration.MdiParent = Me
        serialgeneration.Show()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        load_workorder()
    End Sub

    Private Sub AccessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccessToolStripMenuItem.Click
        frmaccess.MdiParent = Me
        frmaccess.Show()
    End Sub
End Class
