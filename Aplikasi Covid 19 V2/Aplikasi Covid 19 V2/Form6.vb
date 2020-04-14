Public Class Form6
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
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
        Label2.Text = DataGridView2.Rows(10).Cells(0).Value
        Label3.Text = DataGridView2.Rows(11).Cells(0).Value
        Label4.Text = DataGridView2.Rows(12).Cells(0).Value
        Label5.Text = DataGridView2.Rows(13).Cells(0).Value
        Label6.Text = DataGridView2.Rows(14).Cells(0).Value
        Label18.Text = DataGridView2.Rows(15).Cells(0).Value
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
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "11" & "," & ans & ")"
        Call jalan()
        If ya2.Checked Then
            ans = 1
        ElseIf tidak2.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "12" & "," & ans & ")"
        Call jalan()
        If ya3.Checked Then
            ans = 1
        ElseIf tidak3.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "13" & "," & ans & ")"
        Call jalan()
        If ya4.Checked Then
            ans = 1
        ElseIf tidak4.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "14" & "," & ans & ")"
        Call jalan()
        If ya5.Checked Then
            ans = 1
        ElseIf tidak5.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "15" & "," & ans & ")"
        Call jalan()
        If ya6.Checked Then
            ans = 1
        ElseIf tidak6.Checked Then
            ans = 0
        End If
        sqlnya = "INSERT INTO tb_answer (id_user, id_quest , skor) VALUES (" & Label1.Text & ", " & "16" & "," & ans & ")"
        Call jalan()
        Form7.Show()
        Me.Hide()
    End Sub

    Private Sub Form6_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub
End Class