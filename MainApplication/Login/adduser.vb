Public Class adduser
    Private Sub adduser_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmb_access_level.SelectedIndex = 1
        txt_add_user.Focus()
    End Sub
    Private Sub btn_create_user_Click(sender As Object, e As EventArgs) Handles btn_create_user.Click
        If txt_add_user.Text = "" Then
            MsgBox("User is Empty", vbCritical, "Error")
        ElseIf txt_add_password.Text = "" Then
            MsgBox("Password is Empty", vbCritical, "Error")
        ElseIf txt_add_password.Text <> txt_add_confirm_password.Text Then
            MsgBox("Confirm Password is not Matching", vbCritical, "Error")
        ElseIf usermode = "Admin" Or usermode = "admin" Then
            add_user(txt_add_user.Text, txt_add_password.Text, cmb_access_level.SelectedItem)
        Else
            MsgBox("Contact Admin", vbCritical, "Error")
        End If
    End Sub
    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub
End Class