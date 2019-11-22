Imports MySql.Data.MySqlClient
Public Class Absensi_Staff

    Private Sub Absensi_Staff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Menu_Admin
        isidata()
    End Sub

    Private Sub isidata()
        connectDatabase()
        Try
            xDataSet.Clear()
            DataGridView1.Refresh()
            xAdapter = New MySqlDataAdapter("SELECT user.pin, nama, wa, alamat, DATE_FORMAT(tanggal_lahir, '%d/%m/%Y'), kategori, goldar, jenis_kendaraan, no_kendaraan, MAX(scan_date)  AS Jam_Masuk, MIN(scan_date) AS Jam_Keluar FROM USER LEFT JOIN (SELECT scan_date, pin FROM scanlog WHERE DATE(scan_date)= DATE(NOW()) ) scanlog ON user.pin = scanlog.pin WHERE kategori = '" + Label1.Text + "' GROUP BY user.pin", xConnection)
            xAdapter.Fill(xDataSet, "user")
            xView = xDataSet.Tables("user").DefaultView
            DataGridView1.DataSource = xView

        Catch ex As Exception
            MsgBox("Periksa Koneksi DataBase")
        End Try


        xConnection.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        isidata2()
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
        Me.Dispose()
    End Sub

    Private Sub isidata2()
        xDataSet.Clear()
        DataGridView2.Refresh()
        xAdapter = New MySqlDataAdapter("SELECT user.pin, DATE_FORMAT(tanggal_lahir, '%d/%m/%Y') nama, wa, alamat, kategori, DATE_FORMAT(scan_date, '%d/%l/%Y %H:%i:%s') AS Presensi FROM USER NATURAL JOIN scanlog  WHERE kategori = '" + Label1.Text + "'", xConnection)
        xAdapter.Fill(xDataSet, "user")
        xView = xDataSet.Tables("user").DefaultView
        DataGridView2.DataSource = xView
        xConnection.Close()
        isidata()
    End Sub
End Class