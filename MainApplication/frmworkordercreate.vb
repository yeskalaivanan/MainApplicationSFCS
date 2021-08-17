Imports MySql.Data.MySqlClient
Imports System.IO
Public Class frmworkordercreate
    Dim number As Integer = 0
    Dim CMD As New MySqlCommand
    Private Sub frmworkordercreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmb_factory_id.Text = frmworkordermain.cmb_factoryid.Text
        cmb_area.Text = frmworkordermain.cmb_area.Text
        cmb_line.Text = frmworkordermain.cmb_line.Text
        cmb_side.SelectedIndex = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        frmworkordermain.load_workorder()
        Me.Close()
    End Sub
    Private Sub create_workorder()
        Dim year As String = Format(Now, "yy")
        Dim month As String = Format(Now, "MM")
        Dim date1 As String = Format(Now, "dd")
        number = number + 1
        lbl_workorderid.Text = "WO" & year & month & date1 & Format(number, "#000")

        Dim productspecdesc As String = "desc"
        Dim inquatity As Integer = 0
        Dim modifiedquantity As Integer = 0
        Try
            Query = "insert into workorder(WOSTATE,PRIORITY,WOID,AREAID,LINEID,PRODUCTLEVEL,PRODUCTSPECID,PRODUCTSPECDESC,QUANTITY,INQUANTITY,CREATEDON,MODIFIEDQUANTITY) values ('" & "Inactive" & "','" & cmb_priority.Text & "','" & lbl_workorderid.Text & "','" & cmb_area.Text & "','" & cmb_line.Text & "','" & cmb_product.Text & "','" & cmb_product_code.Text & "','" & productspecdesc & "','" & txt_qty.Text & "','" & inquatity & "','" & mytimestamp_sql & "','" & modifiedquantity & "')"
            conn_stb_new.Open()
            CMD = New MySqlCommand(Query, conn_stb_new)
            Dim dr As MySqlDataReader
            dr = CMD.ExecuteReader()
            MsgBox("Data saved successfully", vbInformation)
            mainform.ts_message.Text = "Data saved successfully"
        Catch ex As Exception
            mainform.ts_message.Text = ex.Message
            MsgBox(ex.Message, vbCritical)
        Finally
            CMD.Dispose()
            conn_stb_new.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim Query As String
        'Dim modifiedquantity As Integer =
        Query = "Update workorder Set QUANTITY = '" & txt_qty.Text & "',PRIORITY = '" & cmb_priority.Text & "', MODIFIEDQUANTITY = '" & txt_qty.Text & "' where WOID =  '" & lbl_workorderid.Text & "' "
        ExecuteQuery(Query)
        frmworkordermain.load_workorder()
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_create_Click(sender As Object, e As EventArgs) Handles btn_create.Click
        Dim reply As String = MsgBox("Are you want to Create Work Order?", vbQuestion + vbOKCancel, "Application")
        If reply = vbOK Then
            create_workorder()
            frmworkordermain.load_workorder()
            mainform.load_workorder()
        Else
            MsgBox("Work Order Cancelled")
        End If
    End Sub
    Private Sub filter_top_bottom()
        Dim productname_duplicate As Boolean = False
        conn_stb_new.Open()
        Dim strsql As New MySqlCommand("Select * from productnames", conn_stb_new)
        Dim myreader As MySqlDataReader = strsql.ExecuteReader
        cmb_side.Items.Clear()
        While myreader.Read
            For i = 0 To cmb_side.Items.Count - 1
                If cmb_side.Items(i) = myreader("Side") Then
                    productname_duplicate = True
                    Exit For
                End If
            Next

            If productname_duplicate = False Then
                cmb_side.Items.Add(myreader("Side"))
            End If

            productname_duplicate = False

        End While
        conn_stb_new.Close()
    End Sub

    Private Sub cmb_product_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_product.SelectedIndexChanged

    End Sub
    Private Sub cmb_product_Click(sender As Object, e As EventArgs) Handles cmb_product.Click
        load_productdetails()
    End Sub
    Private Sub load_productdetails()
        Dim selectside As String = cmb_side.SelectedItem
        Dim temp_row_count As Integer = 0
        If selectside = "" Then
            MsgBox("Kindly Select PCB Side Details", vbInformation, "No Data")
        Else
            frmproductselect.DataGridView1.RowCount = g_total_product_names

            For i = 0 To g_total_product_names - 1
                'cmb_product.Items.Add(g_product_names(i))
                'cmb_product_code.Items.Add(g_product_codes(i))
                If g_product_sides(i) = selectside Then
                    frmproductselect.DataGridView1.Rows(temp_row_count).Cells(0).Value = g_product_names(i)
                    frmproductselect.DataGridView1.Rows(temp_row_count).Cells(1).Value = g_product_codes(i)
                    frmproductselect.DataGridView1.Rows(temp_row_count).Cells(2).Value = g_product_sides(i)
                    temp_row_count = temp_row_count + 1
                End If

            Next
            frmproductselect.Show()
            'filter_top_bottom()
            'cmb_product.SelectedIndex = 0
            'cmb_product_code.SelectedIndex = 0
        End If

    End Sub
End Class