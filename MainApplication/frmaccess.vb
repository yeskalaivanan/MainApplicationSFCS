Public Class frmaccess
    Private Sub frmaccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.4.0;Data Source=F:\01.mdb")
        '"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=databaseName;User ID=MyUserID;Password=MyPassword;"
        Try
            con.Open()

            If con.State = ConnectionState.Open Then
                MsgBox("Connected")
            Else
                MsgBox("Not Connected!")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class