Imports System.ComponentModel

Public Class Yieldaoi
    Private Sub Yield_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt_target.Text = g_shift_target
        yield_aoi_timer = True
        lbl_model.Text = g_p_name
        mainform.check_yield_timer()
    End Sub
    Private Sub Yieldaoi_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        yield_aoi_timer = False
    End Sub

    Private Sub txt_pass_count_TextChanged(sender As Object, e As EventArgs)
        txt_yield.Text = (Val(txt_pass_count.Text) / Val(txt_target.Text)) * 100
    End Sub
End Class