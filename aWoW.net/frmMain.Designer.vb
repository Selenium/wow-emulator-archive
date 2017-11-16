<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMain
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
		'This form is an MDI child.
		'This code simulates the VB6 
		' functionality of automatically
		' loading and showing an MDI
		' child's parent.
		Me.MDIParent = aWoWe.frmMDI
		aWoWe.frmMDI.Show
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents _RS_0 As AxMSWinsockLib.AxWinsock
	Public WithEvents cmdRSRun As System.Windows.Forms.Button
	Public WithEvents chkOnline As System.Windows.Forms.CheckBox
	Public WithEvents txtRSPort As System.Windows.Forms.TextBox
	Public WithEvents txtRSIP As System.Windows.Forms.TextBox
	Public WithEvents txtWSInput As System.Windows.Forms.TextBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblRSStatus As System.Windows.Forms.Label
	Public WithEvents lblStatus As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents frmRealm As System.Windows.Forms.GroupBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents RS As AxWinsockArray.AxWinsockArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me._RS_0 = New AxMSWinsockLib.AxWinsock
		Me.cmdRSRun = New System.Windows.Forms.Button
		Me.frmRealm = New System.Windows.Forms.GroupBox
		Me.chkOnline = New System.Windows.Forms.CheckBox
		Me.txtRSPort = New System.Windows.Forms.TextBox
		Me.txtRSIP = New System.Windows.Forms.TextBox
		Me.txtWSInput = New System.Windows.Forms.TextBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.lblRSStatus = New System.Windows.Forms.Label
		Me.lblStatus = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.Command2 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.RS = New AxWinsockArray.AxWinsockArray(components)
		Me.frmRealm.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me._RS_0, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.RS, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "RSSetup"
		Me.ClientSize = New System.Drawing.Size(243, 232)
		Me.Location = New System.Drawing.Point(496, 167)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMain"
		_RS_0.OcxState = CType(resources.GetObject("_RS_0.OcxState"), System.Windows.Forms.AxHost.State)
		Me._RS_0.Location = New System.Drawing.Point(240, 16)
		Me._RS_0.Name = "_RS_0"
		Me.cmdRSRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRSRun.Text = "Run aWoWe's Realm Server"
		Me.AcceptButton = Me.cmdRSRun
		Me.cmdRSRun.Size = New System.Drawing.Size(225, 25)
		Me.cmdRSRun.Location = New System.Drawing.Point(8, 200)
		Me.cmdRSRun.TabIndex = 10
		Me.cmdRSRun.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRSRun.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRSRun.CausesValidation = True
		Me.cmdRSRun.Enabled = True
		Me.cmdRSRun.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRSRun.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRSRun.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRSRun.TabStop = True
		Me.cmdRSRun.Name = "cmdRSRun"
		Me.frmRealm.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.frmRealm.Text = "Realm Server Setup"
		Me.frmRealm.Size = New System.Drawing.Size(225, 185)
		Me.frmRealm.Location = New System.Drawing.Point(8, 8)
		Me.frmRealm.TabIndex = 2
		Me.frmRealm.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frmRealm.Enabled = True
		Me.frmRealm.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frmRealm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frmRealm.Visible = True
		Me.frmRealm.Name = "frmRealm"
		Me.chkOnline.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkOnline.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.chkOnline.Text = "Online?"
		Me.chkOnline.Size = New System.Drawing.Size(73, 17)
		Me.chkOnline.Location = New System.Drawing.Point(144, 72)
		Me.chkOnline.TabIndex = 12
		Me.chkOnline.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkOnline.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkOnline.CausesValidation = True
		Me.chkOnline.Enabled = True
		Me.chkOnline.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkOnline.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkOnline.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkOnline.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkOnline.TabStop = True
		Me.chkOnline.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkOnline.Visible = True
		Me.chkOnline.Name = "chkOnline"
		Me.txtRSPort.AutoSize = False
		Me.txtRSPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtRSPort.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtRSPort.Size = New System.Drawing.Size(169, 19)
		Me.txtRSPort.Location = New System.Drawing.Point(48, 40)
		Me.txtRSPort.TabIndex = 9
		Me.txtRSPort.Text = "3724"
		Me.txtRSPort.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtRSPort.AcceptsReturn = True
		Me.txtRSPort.CausesValidation = True
		Me.txtRSPort.Enabled = True
		Me.txtRSPort.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRSPort.HideSelection = True
		Me.txtRSPort.ReadOnly = False
		Me.txtRSPort.Maxlength = 0
		Me.txtRSPort.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRSPort.MultiLine = False
		Me.txtRSPort.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRSPort.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRSPort.TabStop = True
		Me.txtRSPort.Visible = True
		Me.txtRSPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtRSPort.Name = "txtRSPort"
		Me.txtRSIP.AutoSize = False
		Me.txtRSIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtRSIP.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtRSIP.Size = New System.Drawing.Size(169, 19)
		Me.txtRSIP.Location = New System.Drawing.Point(48, 16)
		Me.txtRSIP.TabIndex = 8
		Me.txtRSIP.Text = "autoselect"
		Me.txtRSIP.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtRSIP.AcceptsReturn = True
		Me.txtRSIP.CausesValidation = True
		Me.txtRSIP.Enabled = True
		Me.txtRSIP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRSIP.HideSelection = True
		Me.txtRSIP.ReadOnly = False
		Me.txtRSIP.Maxlength = 0
		Me.txtRSIP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRSIP.MultiLine = False
		Me.txtRSIP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRSIP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRSIP.TabStop = True
		Me.txtRSIP.Visible = True
		Me.txtRSIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtRSIP.Name = "txtRSIP"
		Me.txtWSInput.AutoSize = False
		Me.txtWSInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtWSInput.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtWSInput.Size = New System.Drawing.Size(209, 19)
		Me.txtWSInput.Location = New System.Drawing.Point(8, 96)
		Me.txtWSInput.TabIndex = 5
		Me.txtWSInput.Text = "192.168.0.2:8085"
		Me.txtWSInput.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtWSInput.AcceptsReturn = True
		Me.txtWSInput.CausesValidation = True
		Me.txtWSInput.Enabled = True
		Me.txtWSInput.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtWSInput.HideSelection = True
		Me.txtWSInput.ReadOnly = False
		Me.txtWSInput.Maxlength = 0
		Me.txtWSInput.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtWSInput.MultiLine = False
		Me.txtWSInput.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtWSInput.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtWSInput.TabStop = True
		Me.txtWSInput.Visible = True
		Me.txtWSInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtWSInput.Name = "txtWSInput"
		Me.Label2.Text = "World Server's IP:"
		Me.Label2.Size = New System.Drawing.Size(137, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 72)
		Me.Label2.TabIndex = 11
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.lblRSStatus.Text = "Realm Server OFFLINE"
		Me.lblRSStatus.ForeColor = System.Drawing.Color.Red
		Me.lblRSStatus.Size = New System.Drawing.Size(209, 17)
		Me.lblRSStatus.Location = New System.Drawing.Point(8, 136)
		Me.lblRSStatus.TabIndex = 7
		Me.lblRSStatus.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRSStatus.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblRSStatus.BackColor = System.Drawing.Color.Transparent
		Me.lblRSStatus.Enabled = True
		Me.lblRSStatus.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRSStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRSStatus.UseMnemonic = True
		Me.lblRSStatus.Visible = True
		Me.lblRSStatus.AutoSize = False
		Me.lblRSStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRSStatus.Name = "lblRSStatus"
		Me.lblStatus.Text = "0 world servers selected"
		Me.lblStatus.ForeColor = System.Drawing.Color.Red
		Me.lblStatus.Size = New System.Drawing.Size(209, 17)
		Me.lblStatus.Location = New System.Drawing.Point(8, 120)
		Me.lblStatus.TabIndex = 6
		Me.lblStatus.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblStatus.BackColor = System.Drawing.Color.Transparent
		Me.lblStatus.Enabled = True
		Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblStatus.UseMnemonic = True
		Me.lblStatus.Visible = True
		Me.lblStatus.AutoSize = False
		Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblStatus.Name = "lblStatus"
		Me._Label1_1.Text = "Port:"
		Me._Label1_1.Size = New System.Drawing.Size(65, 17)
		Me._Label1_1.Location = New System.Drawing.Point(8, 40)
		Me._Label1_1.TabIndex = 4
		Me._Label1_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_1.BackColor = System.Drawing.Color.Transparent
		Me._Label1_1.Enabled = True
		Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_1.UseMnemonic = True
		Me._Label1_1.Visible = True
		Me._Label1_1.AutoSize = False
		Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_1.Name = "_Label1_1"
		Me._Label1_0.Text = "IP:"
		Me._Label1_0.Size = New System.Drawing.Size(65, 17)
		Me._Label1_0.Location = New System.Drawing.Point(8, 24)
		Me._Label1_0.TabIndex = 3
		Me._Label1_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_0.BackColor = System.Drawing.Color.Transparent
		Me._Label1_0.Enabled = True
		Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = False
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "Test LOGON_PROOF"
		Me.Command2.Size = New System.Drawing.Size(145, 25)
		Me.Command2.Location = New System.Drawing.Point(280, 40)
		Me.Command2.TabIndex = 1
		Me.Command2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Test PublicB Generation"
		Me.Command1.Size = New System.Drawing.Size(145, 25)
		Me.Command1.Location = New System.Drawing.Point(280, 8)
		Me.Command1.TabIndex = 0
		Me.Command1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.Label1.SetIndex(_Label1_1, CType(1, Short))
		Me.Label1.SetIndex(_Label1_0, CType(0, Short))
		Me.RS.SetIndex(_RS_0, CType(0, Short))
		CType(Me.RS, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me._RS_0, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Controls.Add(_RS_0)
		Me.Controls.Add(cmdRSRun)
		Me.Controls.Add(frmRealm)
		Me.Controls.Add(Command2)
		Me.Controls.Add(Command1)
		Me.frmRealm.Controls.Add(chkOnline)
		Me.frmRealm.Controls.Add(txtRSPort)
		Me.frmRealm.Controls.Add(txtRSIP)
		Me.frmRealm.Controls.Add(txtWSInput)
		Me.frmRealm.Controls.Add(Label2)
		Me.frmRealm.Controls.Add(lblRSStatus)
		Me.frmRealm.Controls.Add(lblStatus)
		Me.frmRealm.Controls.Add(_Label1_1)
		Me.frmRealm.Controls.Add(_Label1_0)
		Me.frmRealm.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class