<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_EasylinkSDKClient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_EasylinkSDKClient))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TB_ServerPort = New System.Windows.Forms.TextBox()
        Me.L_ServerPort = New System.Windows.Forms.Label()
        Me.TB_DeviceSN = New System.Windows.Forms.TextBox()
        Me.TB_ServerIP = New System.Windows.Forms.TextBox()
        Me.L_DeviceSN = New System.Windows.Forms.Label()
        Me.L_ServerIP = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TP_DataUser = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DGV_Template = New System.Windows.Forms.DataGridView()
        Me.TempPIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempFingerIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempAlgoritmaVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempTemplate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGV_User = New System.Windows.Forms.DataGridView()
        Me.userPIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserNama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserPWD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserRFID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserPrivilege = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.L_NotifUpUser = New System.Windows.Forms.Label()
        Me.TB_PINDel = New System.Windows.Forms.TextBox()
        Me.TB_PINGet = New System.Windows.Forms.TextBox()
        Me.B_DelUser = New System.Windows.Forms.Button()
        Me.B_SetUser = New System.Windows.Forms.Button()
        Me.B_ClearUserDB = New System.Windows.Forms.Button()
        Me.B_DelAllUser = New System.Windows.Forms.Button()
        Me.B_GetAllUser = New System.Windows.Forms.Button()
        Me.TP_DataScanlog = New System.Windows.Forms.TabPage()
        Me.DGV_Scanlog = New System.Windows.Forms.DataGridView()
        Me.SL_SN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SL_ScanDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SL_PIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SL_VerifyMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SL_IOMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SL_WorkCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.L_RecordCount = New System.Windows.Forms.Label()
        Me.B_ClearScanlogDB = New System.Windows.Forms.Button()
        Me.B_DelScanlog = New System.Windows.Forms.Button()
        Me.B_GetNewScanlog = New System.Windows.Forms.Button()
        Me.B_GetAllScanlog = New System.Windows.Forms.Button()
        Me.TP_Info = New System.Windows.Forms.TabPage()
        Me.TV_DeviceInfo = New System.Windows.Forms.TreeView()
        Me.B_DeviceInfo = New System.Windows.Forms.Button()
        Me.TP_Setting = New System.Windows.Forms.TabPage()
        Me.B_initialization = New System.Windows.Forms.Button()
        Me.B_delDeviceLog = New System.Windows.Forms.Button()
        Me.B_delAdmin = New System.Windows.Forms.Button()
        Me.B_syncDateTime = New System.Windows.Forms.Button()
        Me.TB_Memo = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP_DataUser.SuspendLayout()
        CType(Me.DGV_Template, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_User, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP_DataScanlog.SuspendLayout()
        CType(Me.DGV_Scanlog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP_Info.SuspendLayout()
        Me.TP_Setting.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TB_ServerPort)
        Me.Panel1.Controls.Add(Me.L_ServerPort)
        Me.Panel1.Controls.Add(Me.TB_DeviceSN)
        Me.Panel1.Controls.Add(Me.TB_ServerIP)
        Me.Panel1.Controls.Add(Me.L_DeviceSN)
        Me.Panel1.Controls.Add(Me.L_ServerIP)
        Me.Panel1.Location = New System.Drawing.Point(12, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(710, 74)
        Me.Panel1.TabIndex = 0
        '
        'TB_ServerPort
        '
        Me.TB_ServerPort.Location = New System.Drawing.Point(290, 12)
        Me.TB_ServerPort.Name = "TB_ServerPort"
        Me.TB_ServerPort.Size = New System.Drawing.Size(100, 20)
        Me.TB_ServerPort.TabIndex = 5
        Me.TB_ServerPort.Text = "7005"
        '
        'L_ServerPort
        '
        Me.L_ServerPort.AutoSize = True
        Me.L_ServerPort.Location = New System.Drawing.Point(214, 15)
        Me.L_ServerPort.Name = "L_ServerPort"
        Me.L_ServerPort.Size = New System.Drawing.Size(60, 13)
        Me.L_ServerPort.TabIndex = 4
        Me.L_ServerPort.Text = "Server Port"
        '
        'TB_DeviceSN
        '
        Me.TB_DeviceSN.Location = New System.Drawing.Point(78, 43)
        Me.TB_DeviceSN.Name = "TB_DeviceSN"
        Me.TB_DeviceSN.Size = New System.Drawing.Size(312, 20)
        Me.TB_DeviceSN.TabIndex = 3
        Me.TB_DeviceSN.Text = "61627018331889"
        '
        'TB_ServerIP
        '
        Me.TB_ServerIP.Location = New System.Drawing.Point(78, 12)
        Me.TB_ServerIP.Name = "TB_ServerIP"
        Me.TB_ServerIP.Size = New System.Drawing.Size(130, 20)
        Me.TB_ServerIP.TabIndex = 2
        Me.TB_ServerIP.Text = "169.254.25.190"
        '
        'L_DeviceSN
        '
        Me.L_DeviceSN.AutoSize = True
        Me.L_DeviceSN.Location = New System.Drawing.Point(13, 46)
        Me.L_DeviceSN.Name = "L_DeviceSN"
        Me.L_DeviceSN.Size = New System.Drawing.Size(59, 13)
        Me.L_DeviceSN.TabIndex = 1
        Me.L_DeviceSN.Text = "Device SN"
        '
        'L_ServerIP
        '
        Me.L_ServerIP.AutoSize = True
        Me.L_ServerIP.Location = New System.Drawing.Point(13, 12)
        Me.L_ServerIP.Name = "L_ServerIP"
        Me.L_ServerIP.Size = New System.Drawing.Size(51, 13)
        Me.L_ServerIP.TabIndex = 0
        Me.L_ServerIP.Text = "Server IP"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TP_DataUser)
        Me.TabControl1.Controls.Add(Me.TP_DataScanlog)
        Me.TabControl1.Controls.Add(Me.TP_Info)
        Me.TabControl1.Controls.Add(Me.TP_Setting)
        Me.TabControl1.Location = New System.Drawing.Point(12, 82)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(710, 415)
        Me.TabControl1.TabIndex = 1
        '
        'TP_DataUser
        '
        Me.TP_DataUser.Controls.Add(Me.Button1)
        Me.TP_DataUser.Controls.Add(Me.DGV_Template)
        Me.TP_DataUser.Controls.Add(Me.DGV_User)
        Me.TP_DataUser.Controls.Add(Me.L_NotifUpUser)
        Me.TP_DataUser.Controls.Add(Me.TB_PINDel)
        Me.TP_DataUser.Controls.Add(Me.TB_PINGet)
        Me.TP_DataUser.Controls.Add(Me.B_DelUser)
        Me.TP_DataUser.Controls.Add(Me.B_SetUser)
        Me.TP_DataUser.Controls.Add(Me.B_ClearUserDB)
        Me.TP_DataUser.Controls.Add(Me.B_DelAllUser)
        Me.TP_DataUser.Controls.Add(Me.B_GetAllUser)
        Me.TP_DataUser.Location = New System.Drawing.Point(4, 22)
        Me.TP_DataUser.Name = "TP_DataUser"
        Me.TP_DataUser.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_DataUser.Size = New System.Drawing.Size(702, 389)
        Me.TP_DataUser.TabIndex = 0
        Me.TP_DataUser.Text = "Data User"
        Me.TP_DataUser.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(534, 47)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DGV_Template
        '
        Me.DGV_Template.AllowUserToAddRows = False
        Me.DGV_Template.AllowUserToDeleteRows = False
        Me.DGV_Template.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Template.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TempPIN, Me.TempFingerIndex, Me.TempAlgoritmaVersion, Me.TempTemplate})
        Me.DGV_Template.Location = New System.Drawing.Point(25, 261)
        Me.DGV_Template.Name = "DGV_Template"
        Me.DGV_Template.ReadOnly = True
        Me.DGV_Template.Size = New System.Drawing.Size(662, 122)
        Me.DGV_Template.TabIndex = 9
        '
        'TempPIN
        '
        Me.TempPIN.DataPropertyName = "pin"
        Me.TempPIN.HeaderText = "PIN"
        Me.TempPIN.Name = "TempPIN"
        Me.TempPIN.ReadOnly = True
        '
        'TempFingerIndex
        '
        Me.TempFingerIndex.DataPropertyName = "finger_idx"
        Me.TempFingerIndex.HeaderText = "Finger Index"
        Me.TempFingerIndex.Name = "TempFingerIndex"
        Me.TempFingerIndex.ReadOnly = True
        '
        'TempAlgoritmaVersion
        '
        Me.TempAlgoritmaVersion.DataPropertyName = "alg_ver"
        Me.TempAlgoritmaVersion.HeaderText = "Algoritma Version"
        Me.TempAlgoritmaVersion.Name = "TempAlgoritmaVersion"
        Me.TempAlgoritmaVersion.ReadOnly = True
        '
        'TempTemplate
        '
        Me.TempTemplate.DataPropertyName = "template"
        Me.TempTemplate.HeaderText = "Template"
        Me.TempTemplate.Name = "TempTemplate"
        Me.TempTemplate.ReadOnly = True
        Me.TempTemplate.Width = 300
        '
        'DGV_User
        '
        Me.DGV_User.AllowUserToAddRows = False
        Me.DGV_User.AllowUserToDeleteRows = False
        Me.DGV_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_User.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.userPIN, Me.UserNama, Me.UserPWD, Me.UserRFID, Me.UserPrivilege})
        Me.DGV_User.Location = New System.Drawing.Point(25, 105)
        Me.DGV_User.Name = "DGV_User"
        Me.DGV_User.ReadOnly = True
        Me.DGV_User.Size = New System.Drawing.Size(662, 150)
        Me.DGV_User.TabIndex = 8
        '
        'userPIN
        '
        Me.userPIN.DataPropertyName = "pin"
        Me.userPIN.HeaderText = "PIN"
        Me.userPIN.Name = "userPIN"
        Me.userPIN.ReadOnly = True
        '
        'UserNama
        '
        Me.UserNama.DataPropertyName = "nama"
        Me.UserNama.HeaderText = "Nama"
        Me.UserNama.Name = "UserNama"
        Me.UserNama.ReadOnly = True
        '
        'UserPWD
        '
        Me.UserPWD.DataPropertyName = "pwd"
        Me.UserPWD.HeaderText = "PWD"
        Me.UserPWD.Name = "UserPWD"
        Me.UserPWD.ReadOnly = True
        '
        'UserRFID
        '
        Me.UserRFID.DataPropertyName = "rfid"
        Me.UserRFID.HeaderText = "RFID"
        Me.UserRFID.Name = "UserRFID"
        Me.UserRFID.ReadOnly = True
        '
        'UserPrivilege
        '
        Me.UserPrivilege.DataPropertyName = "privilege"
        Me.UserPrivilege.HeaderText = "Privilege"
        Me.UserPrivilege.Name = "UserPrivilege"
        Me.UserPrivilege.ReadOnly = True
        '
        'L_NotifUpUser
        '
        Me.L_NotifUpUser.AutoSize = True
        Me.L_NotifUpUser.Location = New System.Drawing.Point(22, 79)
        Me.L_NotifUpUser.Name = "L_NotifUpUser"
        Me.L_NotifUpUser.Size = New System.Drawing.Size(188, 13)
        Me.L_NotifUpUser.TabIndex = 7
        Me.L_NotifUpUser.Text = "*) Leave PIN Empty to Upload All User"
        '
        'TB_PINDel
        '
        Me.TB_PINDel.Location = New System.Drawing.Point(267, 47)
        Me.TB_PINDel.Name = "TB_PINDel"
        Me.TB_PINDel.Size = New System.Drawing.Size(100, 20)
        Me.TB_PINDel.TabIndex = 6
        Me.TB_PINDel.Text = "PIN"
        '
        'TB_PINGet
        '
        Me.TB_PINGet.Location = New System.Drawing.Point(25, 47)
        Me.TB_PINGet.Name = "TB_PINGet"
        Me.TB_PINGet.Size = New System.Drawing.Size(100, 20)
        Me.TB_PINGet.TabIndex = 5
        Me.TB_PINGet.Text = "PIN"
        '
        'B_DelUser
        '
        Me.B_DelUser.Location = New System.Drawing.Point(373, 44)
        Me.B_DelUser.Name = "B_DelUser"
        Me.B_DelUser.Size = New System.Drawing.Size(99, 23)
        Me.B_DelUser.TabIndex = 4
        Me.B_DelUser.Text = "Delete User PIN"
        Me.B_DelUser.UseVisualStyleBackColor = True
        '
        'B_SetUser
        '
        Me.B_SetUser.Location = New System.Drawing.Point(129, 44)
        Me.B_SetUser.Name = "B_SetUser"
        Me.B_SetUser.Size = New System.Drawing.Size(75, 23)
        Me.B_SetUser.TabIndex = 3
        Me.B_SetUser.Text = "Set User"
        Me.B_SetUser.UseVisualStyleBackColor = True
        '
        'B_ClearUserDB
        '
        Me.B_ClearUserDB.Location = New System.Drawing.Point(534, 15)
        Me.B_ClearUserDB.Name = "B_ClearUserDB"
        Me.B_ClearUserDB.Size = New System.Drawing.Size(153, 23)
        Me.B_ClearUserDB.TabIndex = 2
        Me.B_ClearUserDB.Text = "Clear User In Database"
        Me.B_ClearUserDB.UseVisualStyleBackColor = True
        '
        'B_DelAllUser
        '
        Me.B_DelAllUser.Location = New System.Drawing.Point(269, 15)
        Me.B_DelAllUser.Name = "B_DelAllUser"
        Me.B_DelAllUser.Size = New System.Drawing.Size(203, 23)
        Me.B_DelAllUser.TabIndex = 1
        Me.B_DelAllUser.Text = "Delete All User"
        Me.B_DelAllUser.UseVisualStyleBackColor = True
        '
        'B_GetAllUser
        '
        Me.B_GetAllUser.Location = New System.Drawing.Point(25, 15)
        Me.B_GetAllUser.Name = "B_GetAllUser"
        Me.B_GetAllUser.Size = New System.Drawing.Size(179, 23)
        Me.B_GetAllUser.TabIndex = 0
        Me.B_GetAllUser.Text = "Get All User"
        Me.B_GetAllUser.UseVisualStyleBackColor = True
        '
        'TP_DataScanlog
        '
        Me.TP_DataScanlog.Controls.Add(Me.DGV_Scanlog)
        Me.TP_DataScanlog.Controls.Add(Me.L_RecordCount)
        Me.TP_DataScanlog.Controls.Add(Me.B_ClearScanlogDB)
        Me.TP_DataScanlog.Controls.Add(Me.B_DelScanlog)
        Me.TP_DataScanlog.Controls.Add(Me.B_GetNewScanlog)
        Me.TP_DataScanlog.Controls.Add(Me.B_GetAllScanlog)
        Me.TP_DataScanlog.Location = New System.Drawing.Point(4, 22)
        Me.TP_DataScanlog.Name = "TP_DataScanlog"
        Me.TP_DataScanlog.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_DataScanlog.Size = New System.Drawing.Size(702, 389)
        Me.TP_DataScanlog.TabIndex = 1
        Me.TP_DataScanlog.Text = "Data Scanlog"
        Me.TP_DataScanlog.UseVisualStyleBackColor = True
        '
        'DGV_Scanlog
        '
        Me.DGV_Scanlog.AllowUserToAddRows = False
        Me.DGV_Scanlog.AllowUserToDeleteRows = False
        Me.DGV_Scanlog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Scanlog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SL_SN, Me.SL_ScanDate, Me.SL_PIN, Me.SL_VerifyMode, Me.SL_IOMode, Me.SL_WorkCode})
        Me.DGV_Scanlog.Location = New System.Drawing.Point(25, 75)
        Me.DGV_Scanlog.Name = "DGV_Scanlog"
        Me.DGV_Scanlog.ReadOnly = True
        Me.DGV_Scanlog.Size = New System.Drawing.Size(656, 286)
        Me.DGV_Scanlog.TabIndex = 5
        '
        'SL_SN
        '
        Me.SL_SN.DataPropertyName = "sn"
        Me.SL_SN.HeaderText = "SN"
        Me.SL_SN.Name = "SL_SN"
        Me.SL_SN.ReadOnly = True
        '
        'SL_ScanDate
        '
        Me.SL_ScanDate.DataPropertyName = "scan_date"
        Me.SL_ScanDate.HeaderText = "ScanDate"
        Me.SL_ScanDate.Name = "SL_ScanDate"
        Me.SL_ScanDate.ReadOnly = True
        '
        'SL_PIN
        '
        Me.SL_PIN.DataPropertyName = "pin"
        Me.SL_PIN.HeaderText = "PIN"
        Me.SL_PIN.Name = "SL_PIN"
        Me.SL_PIN.ReadOnly = True
        '
        'SL_VerifyMode
        '
        Me.SL_VerifyMode.DataPropertyName = "verifymode"
        Me.SL_VerifyMode.HeaderText = "Verify Mode"
        Me.SL_VerifyMode.Name = "SL_VerifyMode"
        Me.SL_VerifyMode.ReadOnly = True
        '
        'SL_IOMode
        '
        Me.SL_IOMode.DataPropertyName = "iomode"
        Me.SL_IOMode.HeaderText = "IOMode"
        Me.SL_IOMode.Name = "SL_IOMode"
        Me.SL_IOMode.ReadOnly = True
        '
        'SL_WorkCode
        '
        Me.SL_WorkCode.DataPropertyName = "workcode"
        Me.SL_WorkCode.HeaderText = "WorkCode"
        Me.SL_WorkCode.Name = "SL_WorkCode"
        Me.SL_WorkCode.ReadOnly = True
        '
        'L_RecordCount
        '
        Me.L_RecordCount.AutoSize = True
        Me.L_RecordCount.Location = New System.Drawing.Point(593, 51)
        Me.L_RecordCount.Name = "L_RecordCount"
        Me.L_RecordCount.Size = New System.Drawing.Size(88, 13)
        Me.L_RecordCount.TabIndex = 4
        Me.L_RecordCount.Text = "Record Count : 0"
        '
        'B_ClearScanlogDB
        '
        Me.B_ClearScanlogDB.Location = New System.Drawing.Point(473, 17)
        Me.B_ClearScanlogDB.Name = "B_ClearScanlogDB"
        Me.B_ClearScanlogDB.Size = New System.Drawing.Size(208, 23)
        Me.B_ClearScanlogDB.TabIndex = 3
        Me.B_ClearScanlogDB.Text = "Clear Scanlog in Database"
        Me.B_ClearScanlogDB.UseVisualStyleBackColor = True
        '
        'B_DelScanlog
        '
        Me.B_DelScanlog.Location = New System.Drawing.Point(202, 17)
        Me.B_DelScanlog.Name = "B_DelScanlog"
        Me.B_DelScanlog.Size = New System.Drawing.Size(160, 23)
        Me.B_DelScanlog.TabIndex = 2
        Me.B_DelScanlog.Text = "Delete Scanlog"
        Me.B_DelScanlog.UseVisualStyleBackColor = True
        '
        'B_GetNewScanlog
        '
        Me.B_GetNewScanlog.Location = New System.Drawing.Point(25, 46)
        Me.B_GetNewScanlog.Name = "B_GetNewScanlog"
        Me.B_GetNewScanlog.Size = New System.Drawing.Size(160, 23)
        Me.B_GetNewScanlog.TabIndex = 1
        Me.B_GetNewScanlog.Text = "Get New Scanlog"
        Me.B_GetNewScanlog.UseVisualStyleBackColor = True
        '
        'B_GetAllScanlog
        '
        Me.B_GetAllScanlog.Location = New System.Drawing.Point(25, 17)
        Me.B_GetAllScanlog.Name = "B_GetAllScanlog"
        Me.B_GetAllScanlog.Size = New System.Drawing.Size(160, 23)
        Me.B_GetAllScanlog.TabIndex = 0
        Me.B_GetAllScanlog.Text = "Get All Scanlog"
        Me.B_GetAllScanlog.UseVisualStyleBackColor = True
        '
        'TP_Info
        '
        Me.TP_Info.Controls.Add(Me.TV_DeviceInfo)
        Me.TP_Info.Controls.Add(Me.B_DeviceInfo)
        Me.TP_Info.Location = New System.Drawing.Point(4, 22)
        Me.TP_Info.Name = "TP_Info"
        Me.TP_Info.Size = New System.Drawing.Size(702, 389)
        Me.TP_Info.TabIndex = 2
        Me.TP_Info.Text = "Info"
        Me.TP_Info.UseVisualStyleBackColor = True
        '
        'TV_DeviceInfo
        '
        Me.TV_DeviceInfo.Location = New System.Drawing.Point(23, 47)
        Me.TV_DeviceInfo.Name = "TV_DeviceInfo"
        Me.TV_DeviceInfo.Size = New System.Drawing.Size(653, 328)
        Me.TV_DeviceInfo.TabIndex = 1
        '
        'B_DeviceInfo
        '
        Me.B_DeviceInfo.Location = New System.Drawing.Point(23, 18)
        Me.B_DeviceInfo.Name = "B_DeviceInfo"
        Me.B_DeviceInfo.Size = New System.Drawing.Size(75, 23)
        Me.B_DeviceInfo.TabIndex = 0
        Me.B_DeviceInfo.Text = "Device Info"
        Me.B_DeviceInfo.UseVisualStyleBackColor = True
        '
        'TP_Setting
        '
        Me.TP_Setting.Controls.Add(Me.B_initialization)
        Me.TP_Setting.Controls.Add(Me.B_delDeviceLog)
        Me.TP_Setting.Controls.Add(Me.B_delAdmin)
        Me.TP_Setting.Controls.Add(Me.B_syncDateTime)
        Me.TP_Setting.Location = New System.Drawing.Point(4, 22)
        Me.TP_Setting.Name = "TP_Setting"
        Me.TP_Setting.Size = New System.Drawing.Size(702, 389)
        Me.TP_Setting.TabIndex = 3
        Me.TP_Setting.Text = "Settings"
        Me.TP_Setting.UseVisualStyleBackColor = True
        '
        'B_initialization
        '
        Me.B_initialization.Location = New System.Drawing.Point(29, 109)
        Me.B_initialization.Name = "B_initialization"
        Me.B_initialization.Size = New System.Drawing.Size(127, 23)
        Me.B_initialization.TabIndex = 3
        Me.B_initialization.Text = "Initialization"
        Me.B_initialization.UseVisualStyleBackColor = True
        '
        'B_delDeviceLog
        '
        Me.B_delDeviceLog.Location = New System.Drawing.Point(29, 80)
        Me.B_delDeviceLog.Name = "B_delDeviceLog"
        Me.B_delDeviceLog.Size = New System.Drawing.Size(127, 23)
        Me.B_delDeviceLog.TabIndex = 2
        Me.B_delDeviceLog.Text = "Delete Device Log"
        Me.B_delDeviceLog.UseVisualStyleBackColor = True
        '
        'B_delAdmin
        '
        Me.B_delAdmin.Location = New System.Drawing.Point(29, 51)
        Me.B_delAdmin.Name = "B_delAdmin"
        Me.B_delAdmin.Size = New System.Drawing.Size(127, 23)
        Me.B_delAdmin.TabIndex = 1
        Me.B_delAdmin.Text = "Delete Admin"
        Me.B_delAdmin.UseVisualStyleBackColor = True
        '
        'B_syncDateTime
        '
        Me.B_syncDateTime.Location = New System.Drawing.Point(29, 22)
        Me.B_syncDateTime.Name = "B_syncDateTime"
        Me.B_syncDateTime.Size = New System.Drawing.Size(127, 23)
        Me.B_syncDateTime.TabIndex = 0
        Me.B_syncDateTime.Text = "Sync Date Time"
        Me.B_syncDateTime.UseVisualStyleBackColor = True
        '
        'TB_Memo
        '
        Me.TB_Memo.Location = New System.Drawing.Point(16, 501)
        Me.TB_Memo.Multiline = True
        Me.TB_Memo.Name = "TB_Memo"
        Me.TB_Memo.Size = New System.Drawing.Size(706, 78)
        Me.TB_Memo.TabIndex = 2
        '
        'F_EasylinkSDKClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 591)
        Me.Controls.Add(Me.TB_Memo)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_EasylinkSDKClient"
        Me.Text = "Easylink SDK Sample"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TP_DataUser.ResumeLayout(False)
        Me.TP_DataUser.PerformLayout()
        CType(Me.DGV_Template, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_User, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP_DataScanlog.ResumeLayout(False)
        Me.TP_DataScanlog.PerformLayout()
        CType(Me.DGV_Scanlog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP_Info.ResumeLayout(False)
        Me.TP_Setting.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TB_ServerPort As System.Windows.Forms.TextBox
    Friend WithEvents L_ServerPort As System.Windows.Forms.Label
    Friend WithEvents TB_DeviceSN As System.Windows.Forms.TextBox
    Friend WithEvents TB_ServerIP As System.Windows.Forms.TextBox
    Friend WithEvents L_DeviceSN As System.Windows.Forms.Label
    Friend WithEvents L_ServerIP As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TP_DataUser As System.Windows.Forms.TabPage
    Friend WithEvents DGV_Template As System.Windows.Forms.DataGridView
    Friend WithEvents TempPIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TempFingerIndex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TempAlgoritmaVersion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TempTemplate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGV_User As System.Windows.Forms.DataGridView
    Friend WithEvents userPIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserNama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserPWD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserRFID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserPrivilege As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents L_NotifUpUser As System.Windows.Forms.Label
    Friend WithEvents TB_PINDel As System.Windows.Forms.TextBox
    Friend WithEvents TB_PINGet As System.Windows.Forms.TextBox
    Friend WithEvents B_DelUser As System.Windows.Forms.Button
    Friend WithEvents B_SetUser As System.Windows.Forms.Button
    Friend WithEvents B_ClearUserDB As System.Windows.Forms.Button
    Friend WithEvents B_DelAllUser As System.Windows.Forms.Button
    Friend WithEvents B_GetAllUser As System.Windows.Forms.Button
    Friend WithEvents TP_DataScanlog As System.Windows.Forms.TabPage
    Friend WithEvents DGV_Scanlog As System.Windows.Forms.DataGridView
    Friend WithEvents SL_SN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SL_ScanDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SL_PIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SL_VerifyMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SL_IOMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SL_WorkCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents L_RecordCount As System.Windows.Forms.Label
    Friend WithEvents B_ClearScanlogDB As System.Windows.Forms.Button
    Friend WithEvents B_DelScanlog As System.Windows.Forms.Button
    Friend WithEvents B_GetNewScanlog As System.Windows.Forms.Button
    Friend WithEvents B_GetAllScanlog As System.Windows.Forms.Button
    Friend WithEvents TP_Info As System.Windows.Forms.TabPage
    Friend WithEvents TV_DeviceInfo As System.Windows.Forms.TreeView
    Friend WithEvents B_DeviceInfo As System.Windows.Forms.Button
    Friend WithEvents TP_Setting As System.Windows.Forms.TabPage
    Friend WithEvents TB_Memo As System.Windows.Forms.TextBox
    Friend WithEvents B_initialization As System.Windows.Forms.Button
    Friend WithEvents B_delDeviceLog As System.Windows.Forms.Button
    Friend WithEvents B_delAdmin As System.Windows.Forms.Button
    Friend WithEvents B_syncDateTime As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
