Public Class Menu_Admin

    Private Sub AbsensiUmatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbsensiUmatToolStripMenuItem.Click
        Me.IsMdiContainer = True
        presensi_kehadiran2.Show()
        presensi_kehadiran2.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub Menu_Admin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        login.Close()
    End Sub

    Private Sub Menu_Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AbsensiStaffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbsensiStaffToolStripMenuItem.Click
        Absensi_Staff.Show()
    End Sub
End Class