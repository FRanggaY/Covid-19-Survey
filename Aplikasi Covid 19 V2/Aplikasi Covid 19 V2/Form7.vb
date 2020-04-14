Public Class Form7
    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_quest", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_quest")
        DataGridView2.DataSource = (DS.Tables("tb_quest"))
        DataGridView2.Enabled = True
        DataGridView2.Hide()
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
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
        Label2.Text = DataGridView2.Rows(16).Cells(0).Value
        Label3.Text = DataGridView2.Rows(17).Cells(0).Value
        Label4.Text = DataGridView2.Rows(18).Cells(0).Value
        Label5.Text = DataGridView2.Rows(19).Cells(0).Value
        Label6.Text = DataGridView2.Rows(20).Cells(0).Value
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
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "17" & "," & ans & ")"
        Call jalan()
        If ya2.Checked Then
            ans = 1
        ElseIf tidak2.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "18" & "," & ans & ")"
        Call jalan()
        If ya3.Checked Then
            ans = 1
        ElseIf tidak3.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "19" & "," & ans & ")"
        Call jalan()
        If ya4.Checked Then
            ans = 1
        ElseIf tidak4.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "20" & "," & ans & ")"
        Call jalan()
        If ya5.Checked Then
            ans = 1
        ElseIf tidak5.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "21" & "," & ans & ")"
        Call jalan()
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "22" & "," & "0" & ")"
        Call jalan()
        Form8.Show()
        Me.Hide()
    End Sub

    Private Sub Form7_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub
End Class