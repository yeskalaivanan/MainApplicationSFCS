Imports MySql.Data.MySqlClient
Public Class frmpcb
    Dim SDA As New MySqlDataAdapter
    Dim stencil_total_qty, stencil_used_qty, stencil_balance As Integer
    Private Sub frmpcb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pcb_sql()
        load_stencil_sql()
        load_paste_sql()
        If txt_pcb_total.Text >= wo_quantity And txt_stencil_total.Text >= wo_quantity Then
            MsgBox("Components are Entered Correctly", vbInformation, "OK")
            serialgeneration.btn_generate_serial.Enabled = True
        Else
            MsgBox("Please Enter Component's Correctly", vbInformation, "Enter")
            serialgeneration.btn_generate_serial.Enabled = False
        End If
    End Sub
    Function load_pcb_sql()
        Dim dbDataSet_pcb As New DataTable
        Dim bSource_pcb As New BindingSource
        Try
            conn_stb_new.Open()
            Query = "select * from pcb where WOID = '" & g_workorder & "'"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_pcb)
            bSource_pcb.DataSource = dbDataSet_pcb
            DataGridView1.DataSource = bSource_pcb
            SDA.Update(dbDataSet_pcb)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
        txt_pcb_total.Text = 0
        If DataGridView1.RowCount > 1 Then
            For i = 0 To DataGridView1.RowCount - 1
                txt_pcb_total.Text = Val(txt_pcb_total.Text) + Val(DataGridView1.Rows(i).Cells(2).Value)
            Next
        End If
        Return True
    End Function
    Function load_stencil_sql()
        Dim dbDataSet_pcb As New DataTable
        Dim bSource_pcb As New BindingSource
        Try
            conn_stb_new.Open()
            Query = "select * from stencil where WOID = '" & g_workorder & "'"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_pcb)
            bSource_pcb.DataSource = dbDataSet_pcb
            DataGridView2.DataSource = bSource_pcb
            SDA.Update(dbDataSet_pcb)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
        txt_stencil_total.Text = 0
        If DataGridView1.RowCount > 1 Then
            For i = 0 To DataGridView1.RowCount - 1
                txt_stencil_total.Text = Val(txt_stencil_total.Text) + Val(DataGridView2.Rows(i).Cells(1).Value)
            Next
        End If
        Return True
    End Function
    Function load_paste_sql()
        Dim dbDataSet_pcb As New DataTable
        Dim bSource_pcb As New BindingSource
        Try
            conn_stb_new.Open()
            Query = "select * from paste where WOID = '" & g_workorder & "'"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_pcb)
            bSource_pcb.DataSource = dbDataSet_pcb
            DataGridView3.DataSource = bSource_pcb
            SDA.Update(dbDataSet_pcb)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
        Return True
    End Function

    Private Sub btn_splite_Click(sender As Object, e As EventArgs) Handles btn_splite.Click
        'Dim pcb_lot, pcb_part_no, pcb_qty As String
        txt_lot.Text = Mid(txt_barcode.Text, 5, 12)
        txt_part.Text = Mid(txt_barcode.Text, 18, 12)
        txt_qty.Text = Mid(txt_barcode.Text, 40, 3)
        insert_pcb_sql()
        load_pcb_sql()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        load_pcb_sql()
        load_stencil_sql()
        load_paste_sql()
    End Sub
    Function insert_pcb_sql()
        Dim pcb_lot, pcb_part_no, pcb_qty As String
        pcb_lot = txt_lot.Text & "-" & txt_qty.Text
        pcb_part_no = txt_part.Text
        pcb_qty = txt_qty.Text
        Dim Query As String
        Query = "insert into pcb(WOID,LotId,PartNo,Qty) values ('" & g_workorder & "','" & pcb_lot & "','" & pcb_part_no & "','" & pcb_qty & "')"
        ExecuteQuery(Query)
        txt_barcode.Text = ""
        Return True
    End Function
    Function insert_stencil_sql()
        Dim Query As String
        Dim usedqty, BalanceQty As Integer
        usedqty = 0
        BalanceQty = wo_quantity - usedqty
        Query = "insert into stencil(WOID,PartNo,SetQty,UsedQty,BalanceQty) values ('" & g_workorder & "','" & txt_stencil_partno.Text & "','" & wo_quantity & "','" & usedqty & "','" & BalanceQty & "')"
        ExecuteQuery(Query)
        txt_barcode.Text = ""
        Return True
    End Function
    Function insert_paste_sql()
        Dim Query As String
        Query = "insert into paste(WOID,PartNumber,TotalKg) values ('" & g_workorder & "','" & txt_paste_partno.Text & "')"
        ExecuteQuery(Query)
        txt_barcode.Text = ""
        Return True
    End Function

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        insert_pcb_sql()
        load_pcb_sql()
    End Sub

    Private Sub btn_add_stencil_Click(sender As Object, e As EventArgs) Handles btn_add_stencil.Click


        If stencil_balance > wo_quantity And DataGridView4.RowCount > 1 Then
            check()
        End If
    End Sub
    Function check()
        insert_stencil_sql()
        load_stencil_sql()
        update_stencil_master()
        Return True
    End Function

    Private Sub btn_paste_add_Click(sender As Object, e As EventArgs) Handles btn_paste_add.Click
        insert_paste_sql()
        load_paste_sql()
    End Sub
    Function update_stencil_master()
        Dim Query As String
        Dim usedqty, balance As Integer
        usedqty = stencil_used_qty + wo_quantity
        balance = stencil_balance - wo_quantity
        Query = "Update stencil_master Set UsedQty = '" & usedqty & "', BalanceQty = '" & balance & "' where PartNo =  '" & txt_stencil_partno.Text & "' "
        ExecuteQuery(Query)
        frmworkordermain.load_workorder()
        Return True
    End Function

    Private Sub btn_stencil_check_Click(sender As Object, e As EventArgs) Handles btn_stencil_check.Click
        If g_stencil_part_no = txt_stencil_partno.Text Then
            load_stencil_master_sql()
        Else
            MsgBox("Stencil Part Number is Not Match", vbExclamation, "Error")
        End If
    End Sub

    Function load_stencil_master_sql()
        Dim dbDataSet_pcb As New DataTable
        Dim bSource_pcb As New BindingSource
        Try
            conn_stb_new.Open()
            Query = "select * from stencil_master where PartNo = '" & g_stencil_part_no & "'"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_pcb)
            bSource_pcb.DataSource = dbDataSet_pcb
            DataGridView4.DataSource = bSource_pcb
            SDA.Update(dbDataSet_pcb)
            conn_stb_new.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn_stb_new.Dispose()
        End Try
        stencil_total_qty = DataGridView4.Rows(0).Cells(1).Value
        stencil_used_qty = DataGridView4.Rows(0).Cells(2).Value
        stencil_balance = DataGridView4.Rows(0).Cells(3).Value
        txt_stencil_balance.Text = stencil_balance
        Return True
    End Function
End Class