Imports System.ComponentModel

Public Class yieldfg
    Private Sub yieldfg_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        yield_fg_timer = False
    End Sub

    Private Sub yieldfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_target.Text = g_target
        yield_fg_timer = True
        lbl_model.Text = g_p_name
        mainform.check_yield_timer()
    End Sub

    Private Sub txt_pass_count_TextChanged(sender As Object, e As EventArgs) Handles txt_pass_count.TextChanged
        txt_yield.Text = (Val(txt_pass_count.Text) / Val(txt_target.Text)) * 100
    End Sub
End Class