Public Class frmproductselect
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim selected_row As Integer = DataGridView1.CurrentRow.Index
        frmworkordercreate.cmb_product.Text = DataGridView1.Rows(selected_row).Cells(0).Value.ToString
        frmworkordercreate.cmb_product_code.Text = DataGridView1.Rows(selected_row).Cells(1).Value.ToString
        Me.Close()
    End Sub

    Private Sub frmproductselect_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitializeGrid()
    End Sub

    Private Sub gridstyle1()

        With DataGridView1
            .GridColor = Color.Green
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            With .ColumnHeadersDefaultCellStyle
                .BackColor = Color.Navy
                .ForeColor = Color.White
                .Font = New Font("Tahoma", 9, FontStyle.Bold)
            End With
        End With
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
            '.Font = New Font("Tahoma", 9)
            'Adjust the width each Column to fit.
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoResizeColumns()
            'Adjust Header Styles.
            With .ColumnHeadersDefaultCellStyle
                .BackColor = Color.Green
                .ForeColor = Color.White
                .Font = New Font("Tahoma", 9, FontStyle.Bold)
            End With
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Dim selected_row As Integer = DataGridView1.CurrentRow.Index
            frmworkordercreate.cmb_product.Text = DataGridView1.Rows(selected_row).Cells(0).Value.ToString
            frmworkordercreate.cmb_product_code.Text = DataGridView1.Rows(selected_row).Cells(1).Value.ToString
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class