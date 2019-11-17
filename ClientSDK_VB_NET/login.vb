Imports MySql.Data.MySqlClient
Public Class login

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As MySqlConnection
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost; user id=root; password= ; database=data"
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("Ada kesalahan dalam koneksi database")
        End Try
        Dim myAdapter As New MySqlDataAdapter

        Dim sqlQuery = "SELECT * FROM operator WHERE nama='" + TextBox1.Text + "' AND password='" + TextBox2.Text + "'"
        Dim myCommand As New MySqlCommand
        myCommand.Connection = conn
        myCommand.CommandText = sqlQuery

        myAdapter.SelectCommand = myCommand
        Dim myData As MySqlDataReader
        myData = myCommand.ExecuteReader()

        If myData.HasRows = 0 Then
            MsgBox("username dan password salah!! ",
                   MsgBoxStyle.Exclamation, "Error Login")
        Else
            If TextBox1.Text = "admin" Then
                MsgBox("Login berhasil, Selamat datang " & TextBox1.Text & "!", MsgBoxStyle.Information, "Successfull Login")
                presensi_kehadiran2.Show()
                Me.Hide()
                presensi_kehadiran2.DataGridView3.Visible = False
                presensi_kehadiran2.DataGridView2.Visible = False
                presensi_kehadiran2.DataGridView1.Visible = True
            Else
                MsgBox("Login berhasil, Selamat datang Staff !", MsgBoxStyle.Information, "Successfull Login")
                Me.Hide()
                presensikehadiran.Show()
            End If
        End If
    End Sub

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectDatabase()
    End Sub
End Class