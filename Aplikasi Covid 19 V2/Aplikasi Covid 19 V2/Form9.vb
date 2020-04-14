Public Class Form9
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_user", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_user")
        DataGridView1.DataSource = (DS.Tables("tb_user"))
        DataGridView1.Enabled = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form9_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
        DataGridView1.DataSource = (DS.Tables("tb_user"))
        DataGridView1.Enabled = True
    End Sub
End Class