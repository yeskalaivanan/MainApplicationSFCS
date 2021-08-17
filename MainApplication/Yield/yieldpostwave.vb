Imports System.ComponentModel

Public Class yieldpostwave
    Private Sub yieldpostwave_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        yield_wave_timer = False
    End Sub

    Private Sub yieldpostwave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_target.Text = g_target
        yield_wave_timer = True
        lbl_model.Text = g_p_name
        mainform.check_yield_timer()
    End Sub

    Private Sub txt_pass_count_TextChanged(sender As Object, e As EventArgs) Handles txt_pass_count.TextChanged
        txt_yield.Text = (Val(txt_pass_count.Text) / Val(txt_target.Text)) * 100
    End Sub
End Class