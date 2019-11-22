<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu_Admin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu_Admin))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AbsensiUmatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbsensiStaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbsensiUmatToolStripMenuItem, Me.AbsensiStaffToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(946, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AbsensiUmatToolStripMenuItem
        '
        Me.AbsensiUmatToolStripMenuItem.Name = "AbsensiUmatToolStripMenuItem"
        Me.AbsensiUmatToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.AbsensiUmatToolStripMenuItem.Text = "Absensi Umat"
        '
        'AbsensiStaffToolStripMenuItem
        '
        Me.AbsensiStaffToolStripMenuItem.Name = "AbsensiStaffToolStripMenuItem"
        Me.AbsensiStaffToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.AbsensiStaffToolStripMenuItem.Text = "Absensi Staff"
        '
        'Menu_Admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 505)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Menu_Admin"
        Me.Text = "Menu_Admin"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AbsensiUmatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbsensiStaffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
