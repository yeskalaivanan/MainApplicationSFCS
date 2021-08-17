Public Class changepassword
    Private Sub changepassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_user_name.Focus()
        cmb_access_level.SelectedIndex = 1
    End Sub

    Private Sub btn_update_user_Click(sender As Object, e As EventArgs) Handles btn_update_user.Click
        If txt_user_name.Text = "" Then
            MsgBox("User is Empty", vbCritical, "Error")
        ElseIf txt_old_password.Text = "" Then
            MsgBox("Password is Empty", vbCritical, "Error")
        ElseIf txt_new_password.Text = "" Then
            MsgBox("Confirm Password is not Matching", vbCritical, "Error")
        ElseIf usermode = "Admin" Or usermode = "admin" Then
            update_user(txt_user_name.Text, txt_old_password.Text, txt_new_password.Text, cmb_access_level.SelectedItem)
        Else
            MsgBox("Please Contact Admin", vbCritical, "Error")
        End If
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub
End Class