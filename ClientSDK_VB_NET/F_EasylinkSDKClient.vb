Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data.OleDb
Imports System.Net
Imports System
Imports System.IO
Imports System.Text
Imports ClientSDK_VB_NET
Imports MySql.Data.MySqlClient



Public Class F_EasylinkSDKClient

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

    Private Sub SaveTemplate(ByVal pin As String, ByVal ser As JObject)
        Dim alg_ver As Integer
        Dim idx As Integer
        Dim template As String
        Dim jdata As List(Of JToken) = ser.Children().ToList
        For Each item As JProperty In jdata
            item.CreateReader()
            Select Case item.Name
                Case "Template"
                    For Each comment As JObject In item.Values
                        alg_ver = comment("alg_ver")
                        idx = comment("idx")
                        template = comment("template")
                        str = "INSERT INTO template (pin, finger_idx, alg_ver, template) VALUES ('" & pin & "','" & idx.ToString & "','" & alg_ver.ToString & "','" & template & "')"
                        cmd = New MySqlCommand(str, conn)
                        cmd.ExecuteNonQuery()
                    Next
            End Select
        Next
    End Sub

    Sub gridView()
        Call koneksiBaru()
        adp = New MySqlDataAdapter("SELECT pin,nama,pwd,rfid,privilege FROM data", conn)
            ds = New DataSet
            adp.Fill(ds, "user")
        DGV_User.DataSource = ds.Tables("user")
    End Sub
    Private Sub RefreshDataUser()
        Call koneksiBaru()
        Try
            cmd = New MySqlCommand("Select * from data", conn)
            adp = New MySqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, "user")
            DGV_User.DataSource = ds.Tables("user")

            CMD1 = New MySqlCommand("Select * from scanlog", conn)
            adp = New MySqlDataAdapter(cmd)
            DS1 = New DataSet
            ADP1.Fill(DS1, "scanlog")
            DGV_Scanlog.DataSource = ds.Tables("scanlog")

            cmd = New MySqlCommand("Select * from template", conn)
            adp = New MySqlDataAdapter(cmd)
            DS2 = New DataSet
            ADP2.Fill(DS2, "template")
            DGV_Template.DataSource = ds.Tables("template")

            rowcount = DGV_Scanlog.Rows.Count()
            L_RecordCount.Text = "Record Count : " & rowcount
        Catch ex As Exception
            MsgBox("Database tidak di temukan!!!")
        End Try
    End Sub

    Private Function GetTemplate(ByVal pin As String) As String
        Dim header As String
        Dim content As String
        Dim footer As String
        Dim alg_ver As Integer
        Dim idx As Integer
        Call koneksiBaru()
        cmd = New MySqlCommand("SELECT * FROM template where pin = '" & pin & "'", conn)
        rd = cmd.ExecuteReader
        header = "["
        footer = "]"
        content = ""
        While rd.Read()
            alg_ver = rd.GetInt32(2)
            idx = rd.GetInt32(1)
            If (content <> "") Then
                content = content + ","
            End If
            content = content + "{" + """" + "pin" + """" + ":" + """" + rd.GetString(0) + """" + "," + """" + "idx" + """" + ":" + """" + rd.GetInt32(1).ToString + """" + "," + """" + "alg_ver" + """" + ":" + """" + rd.GetInt32(2).ToString + """" + "," + """" + "template" + """" + ":" + """" + rd.GetString(3) + """" + "}"

        End While
        rd.Close()
        Return (header + content + footer)
    End Function

    Private Sub B_GetAllUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_GetAllUser.Click
        TB_Memo.Clear()
        Dim jpin As String
        Dim jname As String
        Dim jrfid As String
        Dim jpwd As String
        Dim jpriv As String
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_DeviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/user/all/paging", data, "POST")
        Dim json As String = result_post
        Dim ser As JObject = JObject.Parse(json)
        Dim jdata As List(Of JToken) = ser.Children().ToList
        Dim Rst As Boolean = ser.Item("Result")
        If (Rst = True) Then
            'Call koneksiBaru()

            str = "delete from user"
            sql1 = "delete from template"
            cmd = New MySqlCommand(str, conn)
            CMD1 = New MySqlCommand(sql1, conn)

            'cmd.ExecuteReader()
            CMD1.ExecuteNonQuery()
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
                            str = "INSERT INTO user (pin, nama, pwd, rfid, privilege) VALUES ('" & jpin & "','" & jname.Replace("'", "''") & "','" & jpwd & "','" & jrfid & "','" & jpriv & "')"
                            cmd = New MySqlCommand(str, conn)
                            cmd.ExecuteNonQuery()
                            Call SaveTemplate(jpin, comment)
                        Next
                End Select
            Next
        Else
            TB_Memo.Text = "Get All User Failed ! " + vbNewLine + result_post
        End If
        conn.Close()
        'Call RefreshDataUser()
        TB_Memo.Text = "Get All User Success ! " + vbNewLine + result_post
    End Sub

    Private Sub B_DelAllUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_DelAllUser.Click
        TB_Memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_DeviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/user/delall", data, "POST")
        TB_Memo.Text = "Delete All User  " + vbNewLine + result_post
    End Sub

    Private Sub B_SetUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_SetUser.Click
        TB_Memo.Clear()
        Dim pin As String
        Dim nama As String
        Dim pwd As String
        Dim privilege As Integer
        Dim template1 As String
        Dim rfid As String
        Call koneksiBaru()
        If (TB_PINGet.Text = "PIN") Or (TB_PINGet.Text = "pin") Or (TB_PINGet.Text = "") Then
            cmd = New MySqlCommand("Select * from user", conn)
            adp = New MySqlDataAdapter("Select * from user", conn)
            ADP1 = New MySqlDataAdapter("Select * from template", conn)
        Else
            cmd = New MySqlCommand("Select * from user where pin='" & TB_PINGet.Text & "'", conn)
            adp = New MySqlDataAdapter("Select * from user where pin='" & TB_PINGet.Text & "'", conn)
            ADP1 = New MySqlDataAdapter("Select * from template where pin='" & TB_PINGet.Text & "'", conn)
        End If
        ds = New DataSet
        DS1 = New DataSet
        adp.Fill(ds, "user")
        ADP1.Fill(DS1, "template")
        DGV_User.DataSource = ds.Tables("user")
        DGV_Template.DataSource = DS1.Tables("template")
        ARD1 = cmd.ExecuteReader
        While (ARD1.Read())
            pin = ARD1.GetString(0)
            nama = ARD1.GetString(1)
            pwd = ARD1.GetString(2)
            If Not IsDBNull(3) Then
                rfid = ""
            Else
                rfid = ARD1.GetString(3)
            End If
            privilege = ARD1.GetInt32(4)
            template1 = GetTemplate(ARD1.GetString(0))
            Dim data As New Specialized.NameValueCollection
            data.Add("sn", TB_DeviceSN.Text)
            data.Add("pin", pin)
            data.Add("nama", nama)
            data.Add("pwd", pwd)
            data.Add("rfid", rfid)
            data.Add("priv", privilege.ToString)
            data.Add("tmp", template1)
            Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/user/set", data, "POST")
            TB_Memo.Text = "Upload User " + TB_PINGet.Text + vbNewLine + result_post
        End While
    End Sub

    Private Sub B_DelUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_DelUser.Click
        TB_Memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_DeviceSN.Text)
        data.Add("pin", TB_PINDel.Text)
        Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/user/del", data, "POST")
        TB_Memo.Text = "Delete PIN " + TB_PINDel.Text + vbNewLine + result_post
    End Sub

    Private Sub B_ClearUserDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ClearUserDB.Click
        TB_Memo.Clear()
        Call koneksiBaru()
        str = "delete from user"
        sql1 = "delete from template"
        cmd = New MySqlCommand(str, conn)
        CMD1 = New MySqlCommand(sql1, conn)
        cmd.ExecuteNonQuery()
        CMD1.ExecuteNonQuery()
        conn.Close()
        'Call RefreshDataUser()
        TB_Memo.Text = "Delete All User in Database ! "
    End Sub

    Private Sub B_GetAllScanlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_GetAllScanlog.Click
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
        Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/scanlog/all/paging", data, "POST")
        Dim json As String = result_post
        Dim ser As JObject = JObject.Parse(json)
        Dim jdata As List(Of JToken) = ser.Children().ToList
        Dim Rst As Boolean = ser.Item("Result")
        If (Rst = True) Then
            str = "delete from scanlog"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
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
            TB_Memo.Text = "Get All Scanlog Success ! " + vbNewLine + result_post
        Else
            TB_Memo.Text = "Get All Scanlog Failed ! " + vbNewLine + result_post
        End If
        'Call RefreshDataUser()
    End Sub

    Private Sub B_GetNewScanlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_GetNewScanlog.Click
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
        'Call RefreshDataUser()
    End Sub

    Private Sub B_DelScanlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_DelScanlog.Click
        TB_Memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_DeviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/scanlog/del", data, "POST")
        TB_Memo.Text = "Delete All Scanlog " + vbNewLine + result_post
    End Sub

    Private Sub B_ClearScanlogDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ClearScanlogDB.Click
        TB_Memo.Clear()
        Call koneksiBaru()
        str = "delete from scanlog"
        cmd = New MySqlCommand(str, conn)
        cmd.ExecuteNonQuery()
        conn.Close()
        TB_Memo.Text = "Delete All Scanlog in Database ! "
        'Call RefreshDataUser()
    End Sub

    Private Sub B_DeviceInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_DeviceInfo.Click
        TB_Memo.Clear()
        TV_DeviceInfo.Nodes.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_DeviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/dev/info", data, "POST")
        Dim json As String = result_post
        Dim ser As JObject = JObject.Parse(json)
        Dim jdata As List(Of JToken) = ser.Children().ToList
        Dim o As JObject = JObject.Parse(result_post)
        Dim Rst As Boolean = o.Item("Result")
        If (Rst = True) Then
            TB_Memo.Text = "Success " + vbNewLine + result_post
            Dim devinfo As JObject = o.Item("DEVINFO")
            TV_DeviceInfo.Nodes.Add("DEVINFO")
            For Each item In o
                For Each item2 As JProperty In item.Value
                    TV_DeviceInfo.Nodes(0).Nodes.Add(item2.Name & " : " & item2.Value.ToString)
                Next
            Next
            TV_DeviceInfo.ExpandAll()
        Else
            TB_Memo.Text = "Failed !" + vbNewLine + result_post
        End If
    End Sub

    Private Sub B_syncDateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_syncDateTime.Click
        TB_Memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_DeviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/dev/settime", data, "POST")
        TB_Memo.Text = "Sync Date and Time " + vbNewLine + result_post
    End Sub

    Private Sub B_delAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_delAdmin.Click
        TB_Memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_DeviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/dev/deladmin", data, "POST")
        TB_Memo.Text = "Delete Admin " + vbNewLine + result_post
        'Call RefreshDataUser()
    End Sub

    Private Sub B_delDeviceLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_delDeviceLog.Click
        TB_Memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_DeviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/log/del", data, "POST")
        TB_Memo.Text = "Delete Device Log " + vbNewLine + result_post
    End Sub

    Private Sub B_initialization_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_initialization.Click
        TB_Memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_DeviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_ServerIP.Text + ":" + TB_ServerPort.Text + "/dev/init", data, "POST")
        TB_Memo.Text = "Initialization " + vbNewLine + result_post
    End Sub

    Private Sub F_EasylinkSDKClient_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Call RefreshDataUser()
    End Sub

    Private Sub DGV_User_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_User.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Call CType(DGV_Template.DataSource, DataTable).Rows.Clear()
            Call koneksiBaru()
            ADP3 = New MySqlDataAdapter("Select * from template where pin='" & DGV_User.Rows(e.RowIndex).Cells(0).Value & "'", conn)
            DS3 = New DataSet
            ADP3.Fill(DS3, "template")
            DGV_Template.DataSource = DS3.Tables("template")
        End If
    End Sub

    Private Sub F_EasylinkSDKClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksiBaru()
        'Call gridView()

    End Sub

    Private Sub DGV_User_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_User.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.Close()
        'Me.Dispose()
        Me.Hide()
        presensi_kehadiran.Show()
    End Sub
End Class