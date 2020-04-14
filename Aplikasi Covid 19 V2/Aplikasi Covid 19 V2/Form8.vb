Public Class Form8
    Dim sqlnya As String
    Sub showskor()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT SUM(skor) as 'total_skor' FROM tb_answer WHERE id_user=" & Label6.Text & "", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "total_skor")
        DataGridView1.DataSource = (DS.Tables("total_skor"))
        DataGridView1.Enabled = True
    End Sub
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_user", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_user")
        DataGridView2.DataSource = (DS.Tables("tb_user"))
        DataGridView2.Enabled = True
    End Sub
    Sub jalan()
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = sqlnya
        objcmd.ExecuteNonQuery()
        objcmd.Dispose()
        Call panggildata()
    End Sub
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Hide()
        DataGridView2.Hide()
        Label6.Hide()
        Dim hasil As Integer
        Call panggildata()
        Call showskor()
        jawabbenar.Text = DataGridView1.Rows(0).Cells(0).Value
        hasil = jawabbenar.Text
        If hasil < 8 Then
            Label5.Text = "Resiko Rendah"
        ElseIf hasil < 15 Then
            Label5.Text = "Resiko Sedang"
        ElseIf hasil > 14 Then
            Label5.Text = "Resiko Tinggi"
        End If
        sqlnya = "UPDATE tb_user SET total_ya='" & jawabbenar.Text & "',resiko='" & Label5.Text & "' WHERE id_user=" & Label6.Text & ""
        Call jalan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("Jika total jawaban Ya 0 - 7 = Resiko Rendah" & vbCrLf & "Jika total jawaban Ya 8 - 14 = Resiko Sedang" & vbCrLf & "Jika total jawaban Ya 15 - 21 = Resiko Tinggi")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sqlnya = "DELETE FROM tb_answer WHERE id_user=" & Label6.Text & ""
        Call jalan()
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form8_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub
End Class