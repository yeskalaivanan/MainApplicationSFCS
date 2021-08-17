Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class frmdashboard
    Dim CMD As New MySqlCommand
    Dim bSource As New BindingSource
    Dim ds As New DataSet

    Private Sub frmdashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmbProductName.Items.Add("All")
        CmbProductCode.Items.Add("All")
        CmbLineNo.Items.Add("All")
        CmbLotNo.Items.Add("All")
        CmbStatus.Items.Add("All")
        cmb_workorder.Items.Add("All")
        ComboLoadAoi()
        CmbProductName.SelectedIndex = 0
        CmbProductCode.SelectedIndex = 0
        CmbLineNo.SelectedIndex = 0
        CmbLotNo.SelectedIndex = 0
        CmbStatus.SelectedIndex = 0
        cmb_workorder.SelectedIndex = 0
        'combo()
        'display()
    End Sub

    Private Sub DisplayLaserMarkingProducName()
        conn_stb_new.Open()
        Dim cmd1 As New MySqlCommand("Select * from aoi where ProductName like '%" + CmbProductName.Text + "%' and Status like '" + CmbStatus.Text + "' ", conn_stb_new)
        Dim da1 As New MySqlDataAdapter
        Dim dt1 As New DataTable
        da1.SelectCommand = cmd1
        dt1.Clear()
        da1.Fill(dt1)
        DataGridView1.DataSource = dt1
        conn_stb_new.Close()
    End Sub
    Private Sub DisplayLaserMarkingProductCode()
        conn_stb_new.Open()
        Dim cmd1 As New MySqlCommand("Select * from aoi where ProductCode like '%" + CmbProductCode.Text + "%' ", conn_stb_new)
        Dim da1 As New MySqlDataAdapter
        Dim dt1 As New DataTable
        da1.SelectCommand = cmd1
        dt1.Clear()
        da1.Fill(dt1)
        DataGridView1.DataSource = dt1
        conn_stb_new.Close()
    End Sub
    Private Sub DisplayLaserMarkingLinNo()
        conn_stb_new.Open()
        Dim cmd1 As New MySqlCommand("Select * from aoi where Lineno like '%" + CmbLineNo.Text + "%' ", conn_stb_new)
        Dim da1 As New MySqlDataAdapter
        Dim dt1 As New DataTable
        da1.SelectCommand = cmd1
        dt1.Clear()
        da1.Fill(dt1)
        DataGridView1.DataSource = dt1
        conn_stb_new.Close()
    End Sub
    Private Sub DisplayLaserMarkingLotNo()
        conn_stb_new.Open()
        Dim cmd1 As New MySqlCommand("Select * from aoi where Lotno like '%" + CmbLotNo.Text + "%' ", conn_stb_new)
        Dim da1 As New MySqlDataAdapter
        Dim dt1 As New DataTable
        da1.SelectCommand = cmd1
        dt1.Clear()
        da1.Fill(dt1)
        DataGridView1.DataSource = dt1
        conn_stb_new.Close()
    End Sub
    Private Sub DisplayLaserMarkingStatus()
        Dim da1 As New MySqlDataAdapter
        Dim dt1 As New DataTable
        conn_stb_new.Open()
        If CmbStatus.SelectedItem = "All" Then
            Dim cmd1 As New MySqlCommand("Select * from aoi where Status like '%" + "A" + "%'", conn_stb_new)
            da1.SelectCommand = cmd1
        Else
            Dim cmd1 As New MySqlCommand("Select * from aoi where Status like '" + CmbStatus.Text + "'", conn_stb_new)
            da1.SelectCommand = cmd1
        End If
        dt1.Clear()
        da1.Fill(dt1)
        DataGridView1.DataSource = dt1
        conn_stb_new.Close()
    End Sub
    Private Sub DisplayAOIDate()
        Dim date1 As String = DateTimePicker1.Value.ToString("yyyyMMddHHmmss")
        Dim date2 As String = DateTimePicker2.Value.ToString("yyyyMMddHHmmss")
        'Dim date1 As String = DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")
        'Dim date2 As String = DateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss")
        Dim cmd1 As New MySqlCommand
        conn_stb_new.Open()
        If cmb_workorder.Text = "All" And CmbStatus.Text = "All" Then
            cmd1 = New MySqlCommand("Select * from aoi where AOITime between '" + date1 + "' and '" + date2 + "' ", conn_stb_new)
        ElseIf CmbStatus.Text = "All" And cmb_workorder.Text <> "All" Then
            cmd1 = New MySqlCommand("Select * from aoi where AOITime between '" + date1 + "' and '" + date2 + "' and WorkOrder like '" + cmb_workorder.Text + "' ", conn_stb_new)
        ElseIf cmb_workorder.Text = "All" And CmbStatus.Text <> "All" Then
            cmd1 = New MySqlCommand("Select * from aoi where AOITime between '" + date1 + "' and '" + date2 + "' and  Status like '" + CmbStatus.Text + "' ", conn_stb_new)
        Else
            cmd1 = New MySqlCommand("Select * from aoi where AOITime between '" + date1 + "' and '" + date2 + "' and WorkOrder like '" + cmb_workorder.Text + "'and Status like '" + CmbStatus.Text + "' ", conn_stb_new)
        End If

        'Dim cmd1 As New MySqlCommand("Select PcbSerialNumber,ProductName,ProductCode,WorkOrder,Side,Lotno,Lineno,Stage,Status,Remarks,Time,User,Shift,AOITime from aoi where Status like '%" + "A" + "%'", conn_stb_new)
        Dim da1 As New MySqlDataAdapter
        Dim dt1 As New DataTable
        da1.SelectCommand = cmd1
        dt1.Clear()
        da1.Fill(dt1)
        DataGridView1.DataSource = dt1
        conn_stb_new.Close()
    End Sub
    Private Sub ComboLoadLM()

        conn_stb_new.Open()
        Dim strsql As New MySqlCommand("Select * from lasermarking", conn_stb_new)
        Dim myreader As MySqlDataReader = strsql.ExecuteReader
        CmbProductName.Items.Clear()
        While myreader.Read
            CmbProductName.Items.Add(myreader("ProductName"))
            CmbLotNo.Items.Add(myreader("LotNo"))
            CmbLineNo.Items.Add(myreader("LineNo"))
            CmbProductCode.Items.Add(myreader("ProductCode"))
        End While
        conn_stb_new.Close()
    End Sub
    Private Sub ComboLoadAoi()
        Dim productname_duplicate As Boolean = False
        Dim productcode_duplicate As Boolean = False
        Dim productlineno_duplicate As Boolean = False
        Dim productlotno_duplicate As Boolean = False
        Dim productstatus_duplicate As Boolean = False
        Dim productworkorder_duplicate As Boolean = False

        conn_stb_new.Open()
        Dim strsql As New MySqlCommand("Select * from aoi", conn_stb_new)
        Dim myreader As MySqlDataReader = strsql.ExecuteReader
        CmbProductName.Items.Clear()
        While myreader.Read
            For i = 0 To CmbProductName.Items.Count - 1
                If CmbProductName.Items(i) = myreader("ProductName") Then
                    productname_duplicate = True
                    Exit For
                End If
            Next

            For i = 0 To CmbProductCode.Items.Count - 1
                If CmbProductCode.Items(i) = myreader("ProductCode") Then
                    productcode_duplicate = True
                    Exit For
                End If
            Next
            For i = 0 To CmbLineNo.Items.Count - 1
                If CmbLineNo.Items(i) = myreader("Lineno") Then
                    productlineno_duplicate = True
                    Exit For
                End If
            Next
            For i = 0 To CmbLotNo.Items.Count - 1
                If CmbLotNo.Items(i) = myreader("Lotno") Then
                    productlotno_duplicate = True
                    Exit For
                End If
            Next
            For i = 0 To CmbStatus.Items.Count - 1
                If CmbStatus.Items(i) = myreader("Status") Then
                    productstatus_duplicate = True
                    Exit For
                End If
            Next
            For i = 0 To cmb_workorder.Items.Count - 1
                If cmb_workorder.Items(i) = myreader("WorkOrder") Then
                    productworkorder_duplicate = True
                    Exit For
                End If
            Next

            If productname_duplicate = False Then
                CmbProductName.Items.Add(myreader("ProductName"))
            End If
            If productlotno_duplicate = False Then
                CmbLotNo.Items.Add(myreader("Lotno"))
            End If
            If productlineno_duplicate = False Then
                CmbLineNo.Items.Add(myreader("Lineno"))
            End If
            If productcode_duplicate = False Then
                CmbProductCode.Items.Add(myreader("ProductCode"))
            End If
            If productstatus_duplicate = False Then
                CmbStatus.Items.Add(myreader("Status"))
            End If
            If productworkorder_duplicate = False Then
                cmb_workorder.Items.Add(myreader("WorkOrder"))
            End If
            productname_duplicate = False
            productcode_duplicate = False
            productlineno_duplicate = False
            productlotno_duplicate = False
            productstatus_duplicate = False
            productworkorder_duplicate = False
        End While
        conn_stb_new.Close()
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
        'display()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CmbProductCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbProductCode.SelectedIndexChanged
        DisplayLaserMarkingProductCode()
        totalrecords()
    End Sub

    Private Sub CmbProductName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbProductName.SelectedIndexChanged
        DisplayLaserMarkingProducName()
        totalrecords()
    End Sub

    Private Sub CmbLineNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbLineNo.SelectedIndexChanged
        DisplayLaserMarkingLinNo()
        totalrecords()
    End Sub

    Private Sub CmbLotNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbLotNo.SelectedIndexChanged
        DisplayLaserMarkingLotNo()
        totalrecords()
    End Sub

    Private Sub CmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbStatus.SelectedIndexChanged
        'DisplayLaserMarkingStatus()
        'totalrecords()
    End Sub
    Function totalrecords()
        LblRecords.Text = "Total Records : " & DataGridView1.RowCount - 1
        Return 0
    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        DisplayAOIDate()
        totalrecords()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        ComboLoadAoi()
        totalrecords()
    End Sub
End Class