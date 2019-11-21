Imports MySql.Data.MySqlClient
Public Class manual_absen

    Private Sub manual_absen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        login.Close()
    End Sub


    Private Sub manual_absen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectDatabase()
        isidata()
    End Sub

    Private Sub isidata()
        Dim edit As String = "select nama from user"
        xCommand = New MySqlCommand(edit, xConnection)

        xReader = xCommand.ExecuteReader()
        'Label4.Visible = False

        'DataGridView1.Visible = True
        While xReader.Read
            ComboBox1.Items.Add(xReader.GetValue(0))

        End While
        xConnection.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        connectDatabase()
        Dim edit As String = "select pin, jenis_kendaraan, tanggal_lahir, nama_buddhist from user where nama = '" + ComboBox1.SelectedItem.ToString + "'"
        xCommand = New MySqlCommand(edit, xConnection)

        xReader = xCommand.ExecuteReader()
        'Label4.Visible = False

        'DataGridView1.Visible = True
        While xReader.Read
            Label9.Text = xReader.GetValue(0)
            Label3.Text = xReader.GetValue(1)
            Label5.Text = xReader.GetValue(2)
            Label7.Text = xReader.GetValue(3)

        End While
        xConnection.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        connectDatabase()
        Try
            xCommand = New MySqlCommand("Insert into scanlog(sn, scan_date, pin, verifymode, iomode, workcode, status) values ('" + Label10.Text + "', '" + DateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + Label9.Text + "', '" + Label11.Text + "', '" + Label11.Text + "', '" + Label12.Text + "', '" + Label12.Text + "')", xConnection)
            xCommand.ExecuteNonQuery()
            MsgBox("Absen Berhasil")
            Me.Dispose()
            presensikehadiran.Show()
        Catch ex As Exception
            MsgBox("Periksa Koneksi Database")
        End Try
        
    End Sub
End Class