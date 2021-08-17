Imports System.IO
Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmworkordersearch
    Private Sub frmworkordersearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_workorder_search()
    End Sub
    Private Sub load_workorder_search()
        Dim dbDataSet_products As New DataTable
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource
        Try
            conn_stb_new.Open()
            Dim Query As String
            Query = "select * from workorder"
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

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
End Class