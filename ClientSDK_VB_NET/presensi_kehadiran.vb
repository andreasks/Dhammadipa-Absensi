Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data.OleDb
Imports System.Net
Imports System
Imports System.IO
Imports System.Text
Imports ClientSDK_VB_NET
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Reflection




'Imports System.Web.

Public Class presensi_kehadiran2
    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public adp As MySqlDataAdapter
    Public ds As DataSet
    Public str As String


    Public DBold As OleDbConnection
    'Public CMD As OleDbCommand
    Public CMD1 As MySqlCommand
    'Public ADP As MySqlDataAdapter
    Public ARD As MySqlDataAdapter
    Public ARD1 As MySqlDataReader
    Public ADP1 As MySqlDataAdapter
    Public ADP2 As MySqlDataAdapter
    Public ADP3 As MySqlDataAdapter
    'Public DS As New DataSet
    Public DS1 As New DataSet
    Public DS2 As New DataSet
    Public DS3 As New DataSet
    Public sql1 As String
    'Public sql As String


    Dim rowcount As Integer
    Dim btn As New DataGridViewButtonColumn()

    Private Function SendRequest(ByVal url As String, ByVal reqparm As Specialized.NameValueCollection, ByVal method As String) As String

        Using client As New Net.WebClient
            Dim responsebytes = client.UploadValues(url, method, reqparm)
            Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)
            Return responsebody
        End Using

    End Function

    '//**KONEKSI DATABASE KE MySQL 
    Sub koneksiBaru()
        Try
            Dim str As String = "server=localhost; uid=root; Password=; database=data"
            conn = New MySqlConnection(str)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub


    Public Sub koneksiDB()
        Dim lokasiDB As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=db.mdb;"
        DBold = New OleDbConnection(lokasiDB)
        If DBold.State = ConnectionState.Closed Then
            DBold.Open()
        End If
    End Sub

    Private Sub presensi_kehadiran2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    'Private Sub SaveTemplate(ByVal pin As String, ByVal ser As JObject)
    '    Dim alg_ver As Integer
    '    Dim idx As Integer
    '    Dim template As String
    '    Dim jdata As List(Of JToken) = ser.Children().ToList
    '    For Each item As JProperty In jdata
    '        item.CreateReader()
    '        Select Case item.Name
    '            Case "Template"
    '                For Each comment As JObject In item.Values
    '                    alg_ver = comment("alg_ver")
    '                    idx = comment("idx")
    '                    template = comment("template")
    '                    str = "INSERT INTO template (pin, finger_idx, alg_ver, template) VALUES ('" & pin & "','" & idx.ToString & "','" & alg_ver.ToString & "','" & template & "')"
    '                    cmd = New MySqlCommand(str, conn)
    '                    cmd.ExecuteNonQuery()
    '                Next
    '        End Select
    '    Next
    'End Sub




    Private Sub presensi_kehadiran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Menu_Admin
        connectDatabase()
        Call koneksiBaru()
        isidata3()
        isidata2()
        isiData()

        'isidatadownload()

    End Sub


    Private Sub isidata3()
        Try
            xDataSet.Clear()
            DataGridView3.Refresh()
            xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, kategori, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER LEFT JOIN scanlog ON user.pin = scanlog.pin GROUP BY user.pin", xConnection)
            xAdapter.Fill(xDataSet, "user")
            xView = xDataSet.Tables("user").DefaultView
            DataGridView3.DataSource = xView

        Catch ex As Exception
            MsgBox("Periksa Koneksi DataBase")
        End Try


        xConnection.Close()
    End Sub


    Private Sub isidata2()
        Try
            connectDatabase()
            Dim edit As String = "select ip_server, device_sn, server_port from konfigurasi"
            xCommand = New MySqlCommand(edit, xConnection)
            xReader = xCommand.ExecuteReader()
            If xReader.Read Then
                TB_ServerIP.Text = xReader.GetValue(0)
                TB_DeviceSN.Text = xReader.GetValue(1)
                TB_ServerPort.Text = xReader.GetValue(2)
            End If
            xReader.Close()
        Catch ex As Exception
            MsgBox("Periksa Koneksi DataBase")
        End Try

    End Sub



    Private Sub isidatadownload()
        'Try
        'connectDatabase()
        xDataSet.Clear()
        DataGridView2.Refresh()
        xAdapter = New MySqlDataAdapter("SELECT pin, nama, jenis_kelamin, DATE_FORMAT(tanggal_lahir, '%d/%m/%Y'),  wa, alamat, tlp1, tlp2, email, kategori, check_all, pujabakti, meditasi, dana_makan, baksos, fung_shen, sunskul, bursa, keakraban, pelayanan_umat, donasi, seminar, kelas_dhamma, jenis_kendaraan, no_kendaraan, tempat_lahir, goldar, nama_buddhist  FROM USER", xConnection)
        xAdapter.Fill(xDataSet, "user")
        'xDataSet.Tables("user").Rows(1).Item(4) = "Sudah Absen"
        xView = xDataSet.Tables("user").DefaultView
        DataGridView2.DataSource = xView

        'DataGridView1.Columns.Item(0).HeaderText = "ID"
        'DataGridView1.Columns.Item(1).HeaderText = "Nama"
        'DataGridView1.Columns.Item(2).HeaderText = "Jenis Kendaraan"
        'DataGridView1.Columns.Item(2).Width = 125
        'DataGridView1.Columns.Item(3).Width = 125
        'DataGridView1.Columns.Item(4).Width = 125
        'DataGridView1.Columns.Item(3).HeaderText = "No Kendaraan"
        'DataGridView1.Columns.Item(4).HeaderText = "Status Presensi"


        'DataGridView1.Columns.Item(0).Width = 50
        'DataGridView1.Columns.Item(1).Width = 200

        'Catch ex As Exception
        'MsgBox("Periksa Koneksi DataBase")
        'End Try


        xConnection.Close()
    End Sub

    Private Sub isiData()
        Try

            xDataSet.Clear()
            DataGridView1.Refresh()
            xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, DATE_FORMAT(tanggal_lahir, '%d/%m/%Y'), goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER LEFT JOIN scanlog ON user.pin = scanlog.pin GROUP BY user.pin", xConnection)
            xAdapter.Fill(xDataSet, "user")
            xView = xDataSet.Tables("user").DefaultView
            DataGridView1.DataSource = xView




            Try
                DataGridView1.Columns.Add(btn)
                btn.HeaderText = "Edit"
                btn.Text = "Edit"
                btn.Name = "btn"
                btn.UseColumnTextForButtonValue = True
            Catch
            End Try
        Catch ex As Exception
            MsgBox("Periksa Koneksi DataBase")
        End Try


        xConnection.Close()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        connectDatabase()
        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Then
            GroupBox1.Visible = True
            If DataGridView1.CurrentRow.Index <> DataGridView1.NewRowIndex Then

                Dim edit As String = "select nama, jenis_kelamin, tanggal_lahir, alamat, tlp1, tlp2, wa, email, kategori, check_all, pujabakti, meditasi, dana_makan, baksos, fung_shen, sunskul, bursa, keakraban, pelayanan_umat, pin, tempat_lahir, goldar, nama_buddhist, kelas_dhamma, seminar, donasi, no_kendaraan, jenis_kendaraan from user where pin =" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & ""
                xCommand = New MySqlCommand(edit, xConnection)

                xReader = xCommand.ExecuteReader()
                'Label4.Visible = False
                GroupBox1.Visible = True
                'DataGridView1.Visible = True

                If xReader.Read Then
                    TB_Nama.Text = xReader.GetValue(0)
                    Dim jenis As String
                    jenis = xReader.GetValue(1)

                    If jenis = "P" Then
                        ComboBox1.SelectedIndex = 1
                    ElseIf jenis = "L" Then
                        ComboBox1.SelectedIndex = 0
                    Else

                    End If

                    DateTimePicker2.CustomFormat = "yyyy-MM-dd"
                    DateTimePicker2.Value = xReader.GetValue(2)

                    TB_Alamat.Text = xReader.GetValue(3)
                    TB_Tlp1.Text = xReader.GetValue(4)
                    TB_Tlp2.Text = xReader.GetValue(5)
                    TB_WA.Text = xReader.GetValue(6)
                    TB_Email.Text = xReader.GetValue(7)
                    Dim kategori As String
                    kategori = xReader.GetValue(8)

                    If kategori = "Pengurus" Then
                        ComboBox2.SelectedIndex = 0
                    ElseIf kategori = "Umat" Then
                        ComboBox2.SelectedIndex = 1
                    Else
                        ComboBox2.SelectedIndex = 2
                    End If

                    Dim minat1 As String, minat2 As String, minat3 As String, minat4 As String, minat5 As String, minat6 As String, minat7 As String, minat8 As String, minat9 As String, minat10 As String
                    minat1 = xReader.GetValue(9)
                    minat2 = xReader.GetValue(10)
                    minat3 = xReader.GetValue(11)
                    minat4 = xReader.GetValue(12)
                    minat5 = xReader.GetValue(13)
                    minat6 = xReader.GetValue(14)
                    minat7 = xReader.GetValue(15)
                    minat8 = xReader.GetValue(16)
                    minat9 = xReader.GetValue(17)
                    minat10 = xReader.GetValue(18)

                    If minat1 = "1" Then
                        CheckBox1.Checked = True
                    Else
                        CheckBox1.Checked = False
                    End If

                    If minat2 = "1" Then
                        CheckBox2.Checked = True
                    Else
                        CheckBox2.Checked = False
                    End If

                    If minat3 = "1" Then
                        CheckBox3.Checked = True
                    Else
                        CheckBox3.Checked = False
                    End If

                    If minat4 = "1" Then
                        CheckBox4.Checked = True
                    Else
                        CheckBox4.Checked = False
                    End If

                    If minat5 = "1" Then
                        CheckBox5.Checked = True
                    Else
                        CheckBox5.Checked = False
                    End If

                    If minat6 = "1" Then
                        CheckBox6.Checked = True
                    Else
                        CheckBox6.Checked = False
                    End If

                    If minat7 = "1" Then
                        CheckBox7.Checked = True
                    Else
                        CheckBox7.Checked = False
                    End If

                    If minat8 = "1" Then
                        CheckBox8.Checked = True
                    Else
                        CheckBox8.Checked = False
                    End If

                    If minat9 = "1" Then
                        CheckBox9.Checked = True
                    Else
                        CheckBox9.Checked = False
                    End If

                    If minat10 = "1" Then
                        CheckBox10.Checked = True
                    Else
                        CheckBox10.Checked = False
                    End If


                End If

                Label11.Text = xReader.GetValue(19)

                TB_Tempat.Text = xReader.GetValue(20)
                Dim goldars As String = xReader.GetValue(21)
                If goldars = "A" Then
                    ComboBox3.SelectedIndex = 0
                ElseIf goldars = "B" Then
                    ComboBox3.SelectedIndex = 1
                ElseIf goldars = "AB" Then
                    ComboBox3.SelectedIndex = 2
                ElseIf goldars = "O" Then
                    ComboBox3.SelectedIndex = 3
                End If

                TB_buddhist.Text = xReader.GetValue(22)

                Dim minat11 As String, minat12 As String, minat13 As String
                minat11 = xReader.GetValue(23)
                minat12 = xReader.GetValue(24)
                minat13 = xReader.GetValue(25)

                If minat11 = "1" Then
                    CheckBox12.Checked = True
                Else
                    CheckBox12.Checked = False
                End If

                If minat12 = "1" Then
                    CheckBox13.Checked = True
                Else
                    CheckBox13.Checked = False
                End If

                If minat13 = "1" Then
                    CheckBox11.Checked = True
                Else
                    CheckBox11.Checked = False
                End If

                TB_Plat.Text = xReader.GetValue(26)

                Dim jeniskend As String
                jeniskend = xReader.GetValue(27)
                If jeniskend = "Mobil" Then
                    ComboBox4.SelectedIndex = 0
                ElseIf jeniskend = "Motor" Then
                    ComboBox4.SelectedIndex = 1

                End If
            End If
            xReader.Close()
        End If
    End Sub


    Private Sub hapus_user()
        Call koneksiBaru()
        str = "delete from user"
        cmd = New MySqlCommand(str, conn)
        cmd.ExecuteReader()
        conn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TB_Memo.Clear()
        Dim jpin As String
        Dim jname As String
        Dim jrfid As String
        Dim jpwd As String
        Dim jpriv As String
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_DeviceSN.Text)
        Try
            Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/user/all/paging", data, "POST")

            Dim json As String = result_post
            'MsgBox(json)
            Dim ser As JObject = JObject.Parse(json)
            Dim jdata As List(Of JToken) = ser.Children().ToList
            Dim Rst As Boolean = ser.Item("Result")
            If (Rst = True) Then
                'hapus_user()
                Call koneksiBaru()

                'Str = "delete from user"
                'sql1 = "delete from template"
                'cmd = New MySqlCommand(Str, conn)
                'CMD1 = New MySqlCommand(sql1, conn)

                'cmd.ExecuteReader()
                ' cmd.ExecuteReader.Close()
                'CMD1.ExecuteNonQuery()
                For Each item As JProperty In jdata
                    item.CreateReader()
                    Select Case item.Name
                        Case "Data"
                            For Each comment As JObject In item.Values
                                jpin = comment("PIN")
                                jname = comment("Name")
                                jpwd = comment("Password")
                                jrfid = comment("RFID")
                                jpriv = comment("Privilege")
                                str = "INSERT INTO user (pin, nama, pwd, rfid, privilege) VALUES ('" & jpin & "','" & jname.Replace("'", "''") & "','" & jpwd & "','" & jrfid & "','" & jpriv & "') ON DUPLICATE KEY UPDATE nama ='" & jname & "'"
                                cmd = New MySqlCommand(str, conn)
                                cmd.ExecuteNonQuery()
                                'Call SaveTemplate(jpin, comment)
                            Next
                    End Select
                Next
            Else
                TB_Memo.Text = "Get All User Failed ! " + vbNewLine + result_post
            End If
            conn.Close()
            'Call RefreshDataUser()
            TB_Memo.Text = "Get All User Success ! " + vbNewLine + result_post


            isiData()
            MsgBox("Download Anggota Berhasil")
        Catch ex As Exception
            MsgBox("Terjadi Kesalahan")
        End Try



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TB_Memo.Clear()
        Call koneksiBaru()
        Dim jsn As String
        Dim jscandate As String
        Dim jpin As String
        Dim jverifyMode As String
        Dim jIOMode As String
        Dim WorkCode As String
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_DeviceSN.Text)
        Try
            Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/scanlog/new", data, "POST")
            Dim json As String = result_post
            Dim ser As JObject = JObject.Parse(json)
            Dim jdata As List(Of JToken) = ser.Children().ToList
            Dim Rst As Boolean = ser.Item("Result")
            If (Rst = True) Then
                'str = "delete  from scanlog"
                'cmd = New MySqlCommand(str, conn)
                'cmd.ExecuteNonQuery()
                For Each item As JProperty In jdata
                    item.CreateReader()
                    Select Case item.Name
                        Case "Data"
                            For Each comment As JObject In item.Values
                                jsn = comment("SN")
                                jscandate = comment("ScanDate")
                                jpin = comment("PIN")
                                jverifyMode = comment("VerifyMode")
                                jIOMode = comment("IOMode")
                                WorkCode = comment("WorkCode")
                                str = "INSERT INTO scanlog (sn, scan_date, pin, verifymode, iomode, workcode) VALUES ('" & jsn & "','" & jscandate & "','" & jpin & "','" & jverifyMode & "','" & jIOMode & "','" & WorkCode & "')"
                                cmd = New MySqlCommand(str, conn)
                                cmd.ExecuteNonQuery()
                            Next
                    End Select
                Next
                conn.Close()
                TB_Memo.Text = "Get New Scanlog Success ! " + vbNewLine + result_post
            Else
                TB_Memo.Text = "New Scanlog : 0 " + vbNewLine + result_post
            End If
            MsgBox("Download Presensi Berhasil")
        Catch ex As Exception
            MsgBox("Terjadi Kesalahan")
        End Try
        isiData()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            xConnection.Close()
            connectDatabase()
            xCommand = New MySqlCommand("update konfigurasi set ip_server = '" + TB_ServerIP.Text + "', device_sn= '" + TB_DeviceSN.Text + "', server_port= '" + TB_ServerPort.Text + "' ", xConnection)
            xCommand.ExecuteNonQuery()
            'xDataSet.Clear()
            xConnection.Close()
            isidata2()
            MsgBox("Update Data Berhasil")
        Catch ex As Exception
            MsgBox("Terjadi Kesalahan")
        End Try


    End Sub

    Private Sub TB_ServerIP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_ServerIP.TextChanged

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        GroupBox1.Visible = False

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim mnt1 As String, mnt2 As String, mnt3 As String, mnt4 As String, mnt5 As String, mnt6 As String, mnt7 As String, mnt8 As String, mnt9 As String, mnt10 As String
            connectDatabase()
            Dim jenkel As String
            If ComboBox1.SelectedItem.ToString = "Laki-Laki" Then
                jenkel = "L"
            ElseIf ComboBox1.SelectedItem.ToString = "Perempuan" Then
                jenkel = "P"
            End If

            If CheckBox1.Checked = True Then
                mnt1 = "1"
            Else
                mnt1 = "0"
            End If
            If CheckBox2.Checked = True Then
                mnt2 = "1"
            Else
                mnt2 = "0"
            End If
            If CheckBox3.Checked = True Then
                mnt3 = "1"
            Else
                mnt3 = "0"
            End If
            If CheckBox4.Checked = True Then
                mnt4 = "1"
            Else
                mnt4 = "0"
            End If
            If CheckBox5.Checked = True Then
                mnt5 = "1"
            Else
                mnt5 = "0"
            End If
            If CheckBox6.Checked = True Then
                mnt6 = "1"
            Else
                mnt6 = "0"
            End If
            If CheckBox7.Checked = True Then
                mnt7 = "1"
            Else
                mnt7 = "0"
            End If
            If CheckBox8.Checked = True Then
                mnt8 = "1"
            Else
                mnt8 = "0"
            End If
            If CheckBox9.Checked = True Then
                mnt9 = "1"
            Else
                mnt9 = "0"
            End If
            If CheckBox10.Checked = True Then
                mnt10 = "1"
            Else
                mnt10 = "0"
            End If
            Dim minats11 As String, minats12 As String, minats13 As String

            If CheckBox12.Checked = True Then
                minats11 = "1"
            Else
                minats11 = "0"
            End If

            If CheckBox13.Checked = True Then
                minats12 = "1"
            Else
                minats12 = "0"
            End If

            If CheckBox11.Checked = True Then
                minats13 = "1"
            Else
                minats13 = "0"
            End If

            Dim valuestatus As String
            valuestatus = "0"
            'Dim var_date As Date

            'var_date = DateTimePicker2.Value.Date.ToString("yyyy-MM-dd")
            xCommand = New MySqlCommand("update user set alamat = '" + TB_Alamat.Text + "', tlp1= '" + TB_Tlp1.Text + "', tlp2= '" + TB_Tlp2.Text + "', wa='" + TB_WA.Text + "', email='" + TB_Email.Text + "', kategori='" + ComboBox2.SelectedItem.ToString + "', jenis_kelamin='" + jenkel + "', tanggal_lahir = '" + DateTimePicker2.Value.ToString("yyyy-MM-dd") + "', check_all='" + mnt1 + "', pujabakti = '" + mnt2 + "', meditasi = '" + mnt3 + "', dana_makan = '" + mnt4 + "', baksos = '" + mnt5 + "', fung_shen ='" + mnt6 + "', sunskul = '" + mnt7 + "', bursa = '" + mnt8 + "', keakraban = '" + mnt9 + "', pelayanan_umat = '" + mnt10 + "', donasi = '" + minats13 + "', seminar = '" + minats12 + "', kelas_dhamma = '" + minats11 + "', tempat_lahir = '" + TB_Tempat.Text + "', goldar = '" + ComboBox3.SelectedItem.ToString + "', nama_buddhist = '" + TB_buddhist.Text + "', status = '" + valuestatus + "', no_kendaraan = '" + TB_Plat.Text + "', jenis_kendaraan = '" + ComboBox4.SelectedItem.ToString + "'  where pin = " + Label11.Text + " ", xConnection)
            'MsgBox(var_date)
            xCommand.ExecuteNonQuery()
            GroupBox1.Visible = False
            isiData()
        Catch ex As Exception
            MsgBox("Pastikan mengisi data dengan lengkap")
        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        connectDatabase()
        Dim edit As String = "select pin, nama, pwd, rfid, privilege, jenis_kelamin, tanggal_lahir, alamat, tlp1, tlp2, wa, email, kategori, check_all, pujabakti, meditasi, dana_makan, baksos, fung_shen, sunskul, bursa, keakraban, pelayanan_umat, donasi, jenis_kendaraan, no_kendaraan, status, tempat_lahir, goldar, nama_buddhist from user"
        xCommand = New MySqlCommand(edit, xConnection)
        xReader = xCommand.ExecuteReader()
        Dim result As New ArrayList()
        While xReader.Read
            Dim dict As New Dictionary(Of String, Object)
            For count As Integer = 0 To (xReader.FieldCount - 1)
                dict.Add(xReader.GetName(count), xReader(count))
            Next
            result.Add(dict)
        End While
        Dim json As String
        json = JsonConvert.SerializeObject(result)
        'MsgBox(json)
        Dim data As New Specialized.NameValueCollection
        data.Add("inputpost", json)

        Dim result_post = SendRequest("http://absensi.viharadhammadipa.com/index.php/user/sync_user", data, "POST")
        Dim json2 As String = result_post
        MsgBox(json2)



    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        connectDatabase()
        Dim edit As String = "select sn, scan_date, pin, verifymode, iomode, workcode, status from scanlog"
        xCommand = New MySqlCommand(edit, xConnection)
        xReader = xCommand.ExecuteReader()
        Dim result As New ArrayList()
        While xReader.Read
            Dim dict As New Dictionary(Of String, Object)
            For count As Integer = 0 To (xReader.FieldCount - 1)
                dict.Add(xReader.GetName(count), xReader(count))
            Next
            result.Add(dict)
        End While
        Dim json As String
        json = JsonConvert.SerializeObject(result)
        Dim data As New Specialized.NameValueCollection
        data.Add("inputpost", json)

        Dim result_post = SendRequest("http://absensi.viharadhammadipa.com/index.php/user/sync_scanlog", data, "POST")
        Dim json2 As String = result_post
        MsgBox(json2)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try

            xDataSet.Clear()
            DataGridView1.Refresh()
            xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE nama LIKE '%" & TextBox1.Text & "%' GROUP BY user.pin ", xConnection)
            xAdapter.Fill(xDataSet, "user")

            xView = xDataSet.Tables("user").DefaultView
            DataGridView1.DataSource = xView

            DataGridView1.Columns.Item(0).HeaderText = "ID"
            DataGridView1.Columns.Item(1).HeaderText = "Nama"
            DataGridView1.Columns.Item(2).HeaderText = "Jenis Kendaraan"
            DataGridView1.Columns.Item(2).Width = 125
            DataGridView1.Columns.Item(3).Width = 125
            DataGridView1.Columns.Item(4).Width = 125
            DataGridView1.Columns.Item(3).HeaderText = "No Kendaraan"
            DataGridView1.Columns.Item(4).HeaderText = "Status Presensi"


            DataGridView1.Columns.Item(0).Width = 50
            DataGridView1.Columns.Item(1).Width = 200


            Try
                DataGridView1.Columns.Add(btn)
                btn.HeaderText = "Edit"
                btn.Text = "Edit"
                btn.Name = "btn"
                btn.UseColumnTextForButtonValue = True
            Catch
            End Try
        Catch ex As Exception
            MsgBox("Periksa Koneksi DataBase")
        End Try


        xConnection.Close()

    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        Try
            xDataSet.Clear()
            DataGridView1.Refresh()
            xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE goldar LIKE '%" & ComboBox5.SelectedItem.ToString & "%' GROUP BY user.pin ", xConnection)
            xAdapter.Fill(xDataSet, "user")

            xView = xDataSet.Tables("user").DefaultView
            DataGridView1.DataSource = xView

            DataGridView1.Columns.Item(0).HeaderText = "ID"
            DataGridView1.Columns.Item(1).HeaderText = "Nama"

            DataGridView1.Columns.Item(2).Width = 125
            DataGridView1.Columns.Item(3).Width = 125
            DataGridView1.Columns.Item(4).Width = 125

            DataGridView1.Columns.Item(0).Width = 50
            DataGridView1.Columns.Item(1).Width = 200


            Try
                DataGridView1.Columns.Add(btn)
                btn.HeaderText = "Edit"
                btn.Text = "Edit"
                btn.Name = "btn"
                btn.UseColumnTextForButtonValue = True
            Catch
            End Try
        Catch ex As Exception
            MsgBox("Periksa Koneksi DataBase")
        End Try


        xConnection.Close()
    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged
        Try
            Dim gender As String
            If ComboBox6.SelectedItem.ToString = "Laki-Laki" Then
                gender = "L"
            ElseIf ComboBox6.SelectedItem.ToString = "Perempuan" Then
                gender = "P"
            End If
            xDataSet.Clear()
            DataGridView1.Refresh()
            xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE jenis_kelamin LIKE '%" + gender + "%' GROUP BY user.pin ", xConnection)
            xAdapter.Fill(xDataSet, "user")

            xView = xDataSet.Tables("user").DefaultView
            DataGridView1.DataSource = xView

            DataGridView1.Columns.Item(0).HeaderText = "ID"
            DataGridView1.Columns.Item(1).HeaderText = "Nama"

            DataGridView1.Columns.Item(2).Width = 125
            DataGridView1.Columns.Item(3).Width = 125
            DataGridView1.Columns.Item(4).Width = 125

            DataGridView1.Columns.Item(0).Width = 50
            DataGridView1.Columns.Item(1).Width = 200


            Try
                DataGridView1.Columns.Add(btn)
                btn.HeaderText = "Edit"
                btn.Text = "Edit"
                btn.Name = "btn"
                btn.UseColumnTextForButtonValue = True
            Catch
            End Try
        Catch ex As Exception
            MsgBox("Periksa Koneksi DataBase")
        End Try


        xConnection.Close()
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged
        Try

            xDataSet.Clear()
            DataGridView1.Refresh()
            xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE kategori LIKE '%" & ComboBox7.SelectedItem.ToString & "%' GROUP BY user.pin ", xConnection)
            xAdapter.Fill(xDataSet, "user")

            xView = xDataSet.Tables("user").DefaultView
            DataGridView1.DataSource = xView

            DataGridView1.Columns.Item(0).HeaderText = "ID"
            DataGridView1.Columns.Item(1).HeaderText = "Nama"

            DataGridView1.Columns.Item(2).Width = 125
            DataGridView1.Columns.Item(3).Width = 125
            DataGridView1.Columns.Item(4).Width = 125

            DataGridView1.Columns.Item(0).Width = 50
            DataGridView1.Columns.Item(1).Width = 200


            Try
                DataGridView1.Columns.Add(btn)
                btn.HeaderText = "Edit"
                btn.Text = "Edit"
                btn.Name = "btn"
                btn.UseColumnTextForButtonValue = True
            Catch
            End Try
        Catch ex As Exception
            MsgBox("Periksa Koneksi DataBase")
        End Try


        xConnection.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox2.Checked = True
            CheckBox3.Checked = True
            CheckBox4.Checked = True
            CheckBox5.Checked = True
            CheckBox6.Checked = True
            CheckBox7.Checked = True
            CheckBox8.Checked = True
            CheckBox9.Checked = True
            CheckBox10.Checked = True
            CheckBox11.Checked = True
            CheckBox12.Checked = True
            CheckBox13.Checked = True
        ElseIf CheckBox1.Checked = False Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            CheckBox13.Checked = False
        End If
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        Dim minats As String
        minats = "1"
        If ComboBox8.SelectedItem.ToString = "Puja Bakti" Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE pujabakti LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox8.SelectedIndex = 2 Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE meditasi LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()

        ElseIf ComboBox8.SelectedIndex = 3 Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE pelayanan_umat LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()

        ElseIf ComboBox8.SelectedIndex = 4 Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE dana_makan LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()

        ElseIf ComboBox8.SelectedIndex = 5 Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE baksos LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()

        ElseIf ComboBox8.SelectedIndex = 6 Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE fung_shen LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()

        ElseIf ComboBox8.SelectedIndex = 7 Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE keakraban LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()

        ElseIf ComboBox8.SelectedIndex = 8 Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE sunskul LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()

        ElseIf ComboBox8.SelectedIndex = 9 Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE bursa LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()

        ElseIf ComboBox8.SelectedIndex = 10 Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE donasi LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()

        ElseIf ComboBox8.SelectedIndex = 11 Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE kelas_dhamma LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()

        ElseIf ComboBox8.SelectedIndex = 12 Then
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE seminar LIKE '%" + minats + "%' GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        Else
            Try

                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        End If


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        isidatadownload()
        Dim ExcelApp As Object, ExcelBook As Object
        Dim ExcelSheet As Object
        Dim i As Integer
        Dim j As Integer
        ExcelApp = CreateObject("Excel.Application")
        ExcelBook = ExcelApp.WorkBooks.Add
        ExcelSheet = ExcelBook.WorkSheets(1)
        With ExcelSheet
            Dim x = 1
            For Each col As DataGridViewColumn In DataGridView2.Columns
                .Cells(1, col.Index + 1) = col.HeaderText.ToString
            Next
            For i = 1 To Me.DataGridView2.RowCount
                .cells(i + 1, 1) = Me.DataGridView2.Rows(i - 1).Cells(0).Value
                For j = 1 To DataGridView2.Columns.Count - 1
                    .cells(i + 1, j + 1) = DataGridView2.Rows(i - 1).Cells(j).Value
                Next
            Next
        End With
        ExcelApp.Visible = True
        ExcelSheet = Nothing
        ExcelBook = Nothing
        ExcelApp = Nothing
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.SelectedIndexChanged
        If ComboBox9.SelectedIndex = 1 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 1 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox9.SelectedIndex = 2 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 2 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox9.SelectedIndex = 3 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 3 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox9.SelectedIndex = 4 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 4 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox9.SelectedIndex = 5 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 5 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox9.SelectedIndex = 6 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 6 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox9.SelectedIndex = 7 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 7 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox9.SelectedIndex = 8 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 8 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox9.SelectedIndex = 9 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 9 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox9.SelectedIndex = 10 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 10 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox9.SelectedIndex = 11 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 11 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        ElseIf ComboBox9.SelectedIndex = 12 Then
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin WHERE MONTH(tanggal_lahir) = 12 GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()
        Else
            Try
                xDataSet.Clear()
                DataGridView1.Refresh()
                xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, kategori, tanggal_lahir, goldar, jenis_kendaraan, no_kendaraan, IF(MAX(scan_date)=DATE(NOW()),'Hadir', 'Belum')  AS status_kehadiran FROM USER  LEFT JOIN scanlog ON user.pin = scanlog.pin GROUP BY user.pin ", xConnection)
                xAdapter.Fill(xDataSet, "user")

                xView = xDataSet.Tables("user").DefaultView
                DataGridView1.DataSource = xView

                DataGridView1.Columns.Item(0).HeaderText = "ID"
                DataGridView1.Columns.Item(1).HeaderText = "Nama"

                DataGridView1.Columns.Item(2).Width = 125
                DataGridView1.Columns.Item(3).Width = 125
                DataGridView1.Columns.Item(4).Width = 125

                DataGridView1.Columns.Item(0).Width = 50
                DataGridView1.Columns.Item(1).Width = 200


                Try
                    DataGridView1.Columns.Add(btn)
                    btn.HeaderText = "Edit"
                    btn.Text = "Edit"
                    btn.Name = "btn"
                    btn.UseColumnTextForButtonValue = True
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Periksa Koneksi DataBase")
            End Try


            xConnection.Close()

        End If
    End Sub

    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub
End Class