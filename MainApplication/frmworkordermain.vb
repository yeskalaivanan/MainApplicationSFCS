Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmworkordermain


    Private Sub frmworkordermain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_workorder()
        InitializeGrid()
        cmb_factoryid.SelectedIndex = 0
        cmb_area.SelectedIndex = 0
        cmb_line.SelectedIndex = 0
    End Sub
    Function load_workorder()
        Dim dbDataSet_products As New DataTable
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource
        Try
            conn_stb_new.Open()
            Dim Query As String
            Query = "select * from workorder where WOSTATE = 'Inactive'"
            SDA.SelectCommand = New MySqlCommand(Query, conn_stb_new)
            SDA.Fill(dbDataSet_products)
            bSource.DataSource = dbDataSet_products
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet_products)
            conn_stb_new.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            'conn_stb_new.Dispose()
            conn_stb_new.Close()
        End Try
        Return 0
    End Function



    Private Sub cmb_line_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_line.SelectedIndexChanged
        If cmb_line.SelectedItem = "SMT 1" Then
            TextBox1.Text = "100"
        ElseIf cmb_line.SelectedItem = "SMT 2" Then
            TextBox1.Text = "200"
        ElseIf cmb_line.SelectedItem = "SMT 3" Then
            TextBox1.Text = "300"
        ElseIf cmb_line.SelectedItem = "WAVE" Then
            TextBox1.Text = "400"
        ElseIf cmb_line.SelectedItem = "STB ASSY" Then
            TextBox1.Text = "500"
        ElseIf cmb_line.SelectedItem = "ADAPTOR ASSY" Then
            TextBox1.Text = "600"
        ElseIf cmb_line.SelectedItem = "NORCOLD" Then
            TextBox1.Text = "700"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If cmb_factoryid.Text <> "" And cmb_area.Text <> "" And cmb_line.Text <> "" Then
            frmworkordercreate.btn_update.Visible = False
            frmworkordercreate.Show()
        Else
            MsgBox("Please Check the data")
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
            .Font = New Font("Tahoma", 9)
            'Adjust the width each Column to fit.
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoResizeColumns()
            'Adjust Header Styles.
            With .ColumnHeadersDefaultCellStyle
                .BackColor = Color.Navy
                .ForeColor = Color.White
                .Font = New Font("Tahoma", 9, FontStyle.Bold)
            End With
        End With
    End Sub

    Private Sub btn_modify_Click(sender As Object, e As EventArgs) Handles btn_modify.Click
        Dim selected_row As Integer = DataGridView1.CurrentRow.Index
        frmworkordercreate.cmb_factory_id.Text = cmb_factoryid.Text
        frmworkordercreate.cmb_area.Text = cmb_area.Text
        frmworkordercreate.cmb_line.Text = cmb_line.Text
        frmworkordercreate.cmb_product.Text = DataGridView1.Rows(selected_row).Cells(5).Value.ToString
        frmworkordercreate.cmb_product_code.Text = DataGridView1.Rows(selected_row).Cells(6).Value.ToString
        frmworkordercreate.txt_qty.Text = DataGridView1.Rows(selected_row).Cells(8).Value.ToString
        frmworkordercreate.cmb_priority.Text = DataGridView1.Rows(selected_row).Cells(1).Value.ToString
        frmworkordercreate.lbl_workorderid.Text = DataGridView1.Rows(selected_row).Cells(2).Value.ToString

        frmworkordercreate.cmb_product.Enabled = False
        frmworkordercreate.cmb_product_code.Enabled = False
        frmworkordercreate.cmb_side.Enabled = False
        frmworkordercreate.DateTimePicker1.Enabled = False
        frmworkordercreate.btn_create.Visible = False
        frmworkordercreate.Show()
    End Sub



    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        load_workorder()
    End Sub

    Private Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        '// No data then exit sub.
        If DataGridView1.Rows.Count <= 0 Then Exit Sub
        '// 
        Dim MaxRow As Integer, MaxCol As Short
        Dim nRow As Integer, nCol As Short
        Dim xlsApp As New Excel.Application
        Dim xlsWorkBook As Excel.Workbook = xlsApp.Workbooks.Add
        Dim xlsWorkSheet As Excel.Worksheet = CType(xlsWorkBook.Worksheets(1), Excel.Worksheet)
        '// S T A R T
        Try
            xlsApp.Visible = True
            '// Maximum Rows.
            MaxRow = DataGridView1.RowCount
            '// Maximum Columns.
            MaxCol = DataGridView1.Columns.Count - 1
            With xlsWorkSheet
                .Cells.Select()
                .Cells.Delete()
                '// Header
                For nCol = 0 To MaxCol
                    .Cells(1, nCol + 1).Value = DataGridView1.Columns(nCol).HeaderText
                Next nCol
                '// ไล่ตามจำนวนแถว
                For nRow = 0 To MaxRow - 1
                    For nCol = 0 To MaxCol
                        .Cells(nRow + 2, nCol + 1).value = DataGridView1.Rows(nRow).Cells(nCol).Value
                    Next nCol   '// Nested Loop
                    '// Order is in Nested Loop. 
                    '// Providing the suffix Next will let us know what it is in Loop.
                Next nRow

                '// Define styles in WorkSheet.
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12 '10
                '//
                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        xlsApp = Nothing
        '// Release memory.
        releaseObject(xlsApp)
        releaseObject(xlsWorkBook)
        releaseObject(xlsWorkSheet)
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub cmb_area_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_area.SelectedIndexChanged
        cmb_line.Items.Clear()
        If cmb_area.Text = "SMT" Then
            cmb_line.Items.Add("SMT 1")
            cmb_line.Items.Add("SMT 2")
            cmb_line.Items.Add("SMT 3")
            cmb_line.Items.Add("WAVE")
        Else
            cmb_line.Items.Add("STB ASSY")
            cmb_line.Items.Add("ADAPTOR ASSY")
            cmb_line.Items.Add("NORCOLD")
        End If
        cmb_line.SelectedIndex = 0
    End Sub

    Private Sub btn_assign_Click(sender As Object, e As EventArgs) Handles btn_assign.Click
        Dim Query As String
        Dim workorder As String
        Dim selected_row As Integer = DataGridView1.CurrentRow.Index
        workorder = DataGridView1.Rows(selected_row).Cells(2).Value.ToString
        Query = "Update workorder Set WOSTATE = '" & "Active" & "' where WOID =  '" & workorder & "' "
        ExecuteQuery(Query)
        load_workorder()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        frmworkordersearch.Show()
    End Sub
End Class