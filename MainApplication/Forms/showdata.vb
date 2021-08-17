Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class showdata

    Private Sub showdata_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitializeGrid()
        Label1.Text = "Total Record Count : " & DataGridView1.RowCount
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        searchbutton()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' cmbbox()
    End Sub

    Private Sub btn_export_csv_Click(sender As Object, e As EventArgs) Handles btn_export_csv.Click
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