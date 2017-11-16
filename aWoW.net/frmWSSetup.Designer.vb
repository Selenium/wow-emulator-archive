<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWSSetup
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
	Public WithEvents cmdWSRun As System.Windows.Forms.Button
	Public WithEvents txtWSName As System.Windows.Forms.TextBox
	Public WithEvents txtWSIP As System.Windows.Forms.TextBox
	Public WithEvents txtWSPort As System.Windows.Forms.TextBox
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents lblStatus As System.Windows.Forms.Label
	Public WithEvents lblWSStatus As System.Windows.Forms.Label
	Public WithEvents frmWorld As System.Windows.Forms.GroupBox
	Public WithEvents _WS_0 As AxMSWinsockLib.AxWinsock
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents WS As AxWinsockArray.AxWinsockArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWSSetup))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdWSRun = New System.Windows.Forms.Button
		Me.frmWorld = New System.Windows.Forms.GroupBox
		Me.txtWSName = New System.Windows.Forms.TextBox
		Me.txtWSIP = New System.Windows.Forms.TextBox
		Me.txtWSPort = New System.Windows.Forms.TextBox
		Me._Label1_2 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me.lblStatus = New System.Windows.Forms.Label
		Me.lblWSStatus = New System.Windows.Forms.Label
		Me._WS_0 = New AxMSWinsockLib.AxWinsock
		Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.WS = New AxWinsockArray.AxWinsockArray(components)
		Me.frmWorld.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me._WS_0, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.WS, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "WSSetup"
		Me.ClientSize = New System.Drawing.Size(246, 193)
		Me.Location = New System.Drawing.Point(430, 195)
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
		Me.Name = "frmWSSetup"
		Me.cmdWSRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdWSRun.Text = "Run aWoWe's World Server"
		Me.AcceptButton = Me.cmdWSRun
		Me.cmdWSRun.Size = New System.Drawing.Size(225, 25)
		Me.cmdWSRun.Location = New System.Drawing.Point(8, 160)
		Me.cmdWSRun.TabIndex = 9
		Me.cmdWSRun.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdWSRun.BackColor = System.Drawing.SystemColors.Control
		Me.cmdWSRun.CausesValidation = True
		Me.cmdWSRun.Enabled = True
		Me.cmdWSRun.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdWSRun.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdWSRun.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdWSRun.TabStop = True
		Me.cmdWSRun.Name = "cmdWSRun"
		Me.frmWorld.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.frmWorld.Text = "World Server Setup"
		Me.frmWorld.Size = New System.Drawing.Size(225, 145)
		Me.frmWorld.Location = New System.Drawing.Point(8, 8)
		Me.frmWorld.TabIndex = 0
		Me.frmWorld.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frmWorld.Enabled = True
		Me.frmWorld.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frmWorld.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frmWorld.Visible = True
		Me.frmWorld.Name = "frmWorld"
		Me.txtWSName.AutoSize = False
		Me.txtWSName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtWSName.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtWSName.Size = New System.Drawing.Size(209, 19)
		Me.txtWSName.Location = New System.Drawing.Point(8, 80)
		Me.txtWSName.TabIndex = 3
		Me.txtWSName.Text = "aWoWe Powered Test Realm"
		Me.txtWSName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtWSName.AcceptsReturn = True
		Me.txtWSName.CausesValidation = True
		Me.txtWSName.Enabled = True
		Me.txtWSName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtWSName.HideSelection = True
		Me.txtWSName.ReadOnly = False
		Me.txtWSName.Maxlength = 0
		Me.txtWSName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtWSName.MultiLine = False
		Me.txtWSName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtWSName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtWSName.TabStop = True
		Me.txtWSName.Visible = True
		Me.txtWSName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtWSName.Name = "txtWSName"
		Me.txtWSIP.AutoSize = False
		Me.txtWSIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtWSIP.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtWSIP.Size = New System.Drawing.Size(169, 19)
		Me.txtWSIP.Location = New System.Drawing.Point(48, 16)
		Me.txtWSIP.TabIndex = 2
		Me.txtWSIP.Text = "autoselect"
		Me.txtWSIP.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtWSIP.AcceptsReturn = True
		Me.txtWSIP.CausesValidation = True
		Me.txtWSIP.Enabled = True
		Me.txtWSIP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtWSIP.HideSelection = True
		Me.txtWSIP.ReadOnly = False
		Me.txtWSIP.Maxlength = 0
		Me.txtWSIP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtWSIP.MultiLine = False
		Me.txtWSIP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtWSIP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtWSIP.TabStop = True
		Me.txtWSIP.Visible = True
		Me.txtWSIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtWSIP.Name = "txtWSIP"
		Me.txtWSPort.AutoSize = False
		Me.txtWSPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtWSPort.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtWSPort.Size = New System.Drawing.Size(169, 19)
		Me.txtWSPort.Location = New System.Drawing.Point(48, 40)
		Me.txtWSPort.TabIndex = 1
		Me.txtWSPort.Text = "8085"
		Me.txtWSPort.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtWSPort.AcceptsReturn = True
		Me.txtWSPort.CausesValidation = True
		Me.txtWSPort.Enabled = True
		Me.txtWSPort.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtWSPort.HideSelection = True
		Me.txtWSPort.ReadOnly = False
		Me.txtWSPort.Maxlength = 0
		Me.txtWSPort.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtWSPort.MultiLine = False
		Me.txtWSPort.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtWSPort.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtWSPort.TabStop = True
		Me.txtWSPort.Visible = True
		Me.txtWSPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtWSPort.Name = "txtWSPort"
		Me._Label1_2.Text = "Realm Name:"
		Me._Label1_2.Size = New System.Drawing.Size(65, 17)
		Me._Label1_2.Location = New System.Drawing.Point(8, 64)
		Me._Label1_2.TabIndex = 8
		Me._Label1_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_2.BackColor = System.Drawing.Color.Transparent
		Me._Label1_2.Enabled = True
		Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_2.UseMnemonic = True
		Me._Label1_2.Visible = True
		Me._Label1_2.AutoSize = False
		Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_2.Name = "_Label1_2"
		Me._Label1_0.Text = "IP:"
		Me._Label1_0.Size = New System.Drawing.Size(65, 17)
		Me._Label1_0.Location = New System.Drawing.Point(8, 24)
		Me._Label1_0.TabIndex = 7
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
		Me._Label1_1.Text = "Port:"
		Me._Label1_1.Size = New System.Drawing.Size(65, 17)
		Me._Label1_1.Location = New System.Drawing.Point(8, 40)
		Me._Label1_1.TabIndex = 6
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
		Me.lblStatus.Text = "0 players online"
		Me.lblStatus.ForeColor = System.Drawing.Color.Red
		Me.lblStatus.Size = New System.Drawing.Size(209, 17)
		Me.lblStatus.Location = New System.Drawing.Point(8, 104)
		Me.lblStatus.TabIndex = 5
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
		Me.lblWSStatus.Text = "World Server OFFLINE"
		Me.lblWSStatus.ForeColor = System.Drawing.Color.Red
		Me.lblWSStatus.Size = New System.Drawing.Size(209, 17)
		Me.lblWSStatus.Location = New System.Drawing.Point(8, 120)
		Me.lblWSStatus.TabIndex = 4
		Me.lblWSStatus.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblWSStatus.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblWSStatus.BackColor = System.Drawing.Color.Transparent
		Me.lblWSStatus.Enabled = True
		Me.lblWSStatus.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblWSStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblWSStatus.UseMnemonic = True
		Me.lblWSStatus.Visible = True
		Me.lblWSStatus.AutoSize = False
		Me.lblWSStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblWSStatus.Name = "lblWSStatus"
		_WS_0.OcxState = CType(resources.GetObject("_WS_0.OcxState"), System.Windows.Forms.AxHost.State)
		Me._WS_0.Location = New System.Drawing.Point(240, 8)
		Me._WS_0.Name = "_WS_0"
		Me.Label1.SetIndex(_Label1_2, CType(2, Short))
		Me.Label1.SetIndex(_Label1_0, CType(0, Short))
		Me.Label1.SetIndex(_Label1_1, CType(1, Short))
		Me.WS.SetIndex(_WS_0, CType(0, Short))
		CType(Me.WS, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me._WS_0, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Controls.Add(cmdWSRun)
		Me.Controls.Add(frmWorld)
		Me.Controls.Add(_WS_0)
		Me.frmWorld.Controls.Add(txtWSName)
		Me.frmWorld.Controls.Add(txtWSIP)
		Me.frmWorld.Controls.Add(txtWSPort)
		Me.frmWorld.Controls.Add(_Label1_2)
		Me.frmWorld.Controls.Add(_Label1_0)
		Me.frmWorld.Controls.Add(_Label1_1)
		Me.frmWorld.Controls.Add(lblStatus)
		Me.frmWorld.Controls.Add(lblWSStatus)
		Me.frmWorld.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class