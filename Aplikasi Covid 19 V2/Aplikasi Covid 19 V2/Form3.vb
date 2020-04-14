Public Class Form3
    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_user", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_user")
        DataGridView1.DataSource = (DS.Tables("tb_user"))
        DataGridView1.Enabled = True
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
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Hide()
        Call panggildata()
        Button3.Hide()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Label3.Text = DataGridView1.Item(0, i).Value
        Label9.Text = DataGridView1.Item(1, i).Value
        Label7.Text = DataGridView1.Item(2, i).Value
        If Label7.Text = "L" Then
            Label7.Text = "Laki - laki"
        Else
            Label7.Text = "Perempuan"
        End If
    End Sub

    Private Sub Form3_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label3.Text = "pilihakun" Then
            MsgBox("Harap Pilih Akun")
            GoTo UI
        End If
        Form4.Label1.Text = Label3.Text
        Form5.Label1.Text = Label3.Text
        Form6.Label1.Text = Label3.Text
        Form7.Label1.Text = Label3.Text
        Form8.Label6.Text = Label3.Text
        Form8.Label2.Text = Label9.Text
        Form8.Label4.Text = Label7.Text
        Form4.Show()
        Me.Hide()
UI:
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Call panggildata()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call panggildata()
        Call jalan()
    End Sub
End Class