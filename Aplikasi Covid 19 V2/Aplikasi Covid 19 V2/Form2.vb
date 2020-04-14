Public Class Form2
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
        TextBox1.Text = ""
        Label3.Text = ""
        ComboBox1.Text = ""
        Call panggildata()
    End Sub
    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        sqlnya = "UPDATE tb_user SET name='" & TextBox1.Text & "',gender='" & ComboBox1.Text & "' WHERE id_user=" & Label3.Text & ""
        Call jalan()
        MsgBox("Data Berhasil Diupdate")
        Call panggildata()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = (DS.Tables("tb_user"))
        DataGridView1.Enabled = True
        Call panggildata()
        ComboBox1.Items.Add("L")
        ComboBox1.Items.Add("P")
        Label3.Hide()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Label3.Text = DataGridView1.Item(0, i).Value
        TextBox1.Text = DataGridView1.Item(1, i).Value
        ComboBox1.Text = DataGridView1.Item(2, i).Value
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sqlnya = "DELETE FROM tb_user WHERE id_user=" & Label3.Text & ""
        Call jalan()
        MsgBox("Data Berhasil Dihapus")
        Call panggildata()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        sqlnya = "INSERT INTO tb_user (name,gender) VALUES('" & TextBox1.Text & "', '" & ComboBox1.Text & "' )"
        Call jalan()
        MsgBox("Data Berhasil Tersimpan")
        Call panggildata()
    End Sub

    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        Label3.Text = ""
        ComboBox1.Text = ""
    End Sub
End Class