Public Class Form4
    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_quest", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_quest")
        DataGridView2.DataSource = (DS.Tables("tb_quest"))
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
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
        Label2.Text = DataGridView2.Rows(0).Cells(0).Value
        Label3.Text = DataGridView2.Rows(1).Cells(0).Value
        Label4.Text = DataGridView2.Rows(2).Cells(0).Value
        Label5.Text = DataGridView2.Rows(3).Cells(0).Value
        Label6.Text = DataGridView2.Rows(4).Cells(0).Value
        DataGridView2.Hide()
        Label1.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ans As Integer
        If ya1.Checked Then
            ans = 1
        ElseIf tidak1.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest, skor) VALUES (" & Label1.Text & ", " & "1" & "," & ans & ")"
        Call jalan()
        If ya2.Checked Then
            ans = 1
        ElseIf tidak2.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest, skor) VALUES (" & Label1.Text & ", " & "2" & "," & ans & ")"
        Call jalan()
        If ya3.Checked Then
            ans = 1
        ElseIf tidak3.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest, skor) VALUES (" & Label1.Text & ", " & "3" & "," & ans & ")"
        Call jalan()
        If ya4.Checked Then
            ans = 1
        ElseIf tidak4.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest, skor) VALUES (" & Label1.Text & ", " & "4" & "," & ans & ")"
        Call jalan()
        If ya5.Checked Then
            ans = 1
        ElseIf tidak5.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest, skor) VALUES (" & Label1.Text & ", " & "5" & "," & ans & ")"
        Call jalan()
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Form4_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub
End Class