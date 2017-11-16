<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMisc
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
	Public WithEvents _tmrSendData_0 As System.Windows.Forms.Timer
	Public WithEvents _Sck_0 As AxMSWinsockLib.AxWinsock
	Public WithEvents chkLogConnections As System.Windows.Forms.CheckBox
	Public WithEvents chkLogRequests As System.Windows.Forms.CheckBox
	Public WithEvents txtHTTPIP As System.Windows.Forms.TextBox
	Public WithEvents txtHTTPPort As System.Windows.Forms.TextBox
	Public WithEvents chkHTTP As System.Windows.Forms.CheckBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Sck As AxWinsockArray.AxWinsockArray
	Public WithEvents tmrSendData As Microsoft.VisualBasic.Compatibility.VB6.TimerArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMisc))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me._tmrSendData_0 = New System.Windows.Forms.Timer(components)
		Me._Sck_0 = New AxMSWinsockLib.AxWinsock
		Me.chkLogConnections = New System.Windows.Forms.CheckBox
		Me.chkLogRequests = New System.Windows.Forms.CheckBox
		Me.txtHTTPIP = New System.Windows.Forms.TextBox
		Me.txtHTTPPort = New System.Windows.Forms.TextBox
		Me.chkHTTP = New System.Windows.Forms.CheckBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Sck = New AxWinsockArray.AxWinsockArray(components)
		Me.tmrSendData = New Microsoft.VisualBasic.Compatibility.VB6.TimerArray(components)
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me._Sck_0, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Sck, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.tmrSendData, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "Settings"
		Me.ClientSize = New System.Drawing.Size(267, 149)
		Me.Location = New System.Drawing.Point(377, 294)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMisc"
		Me.Frame1.Text = "Integrated simple HTTP"
		Me.Frame1.Size = New System.Drawing.Size(249, 129)
		Me.Frame1.Location = New System.Drawing.Point(8, 8)
		Me.Frame1.TabIndex = 0
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me._tmrSendData_0.Enabled = False
		Me._tmrSendData_0.Interval = 1
		_Sck_0.OcxState = CType(resources.GetObject("_Sck_0.OcxState"), System.Windows.Forms.AxHost.State)
		Me._Sck_0.Location = New System.Drawing.Point(216, 48)
		Me._Sck_0.Name = "_Sck_0"
		Me.chkLogConnections.Text = "Log opened and closed connections"
		Me.chkLogConnections.Size = New System.Drawing.Size(233, 17)
		Me.chkLogConnections.Location = New System.Drawing.Point(8, 104)
		Me.chkLogConnections.TabIndex = 7
		Me.chkLogConnections.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkLogConnections.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkLogConnections.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkLogConnections.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkLogConnections.BackColor = System.Drawing.SystemColors.Control
		Me.chkLogConnections.CausesValidation = True
		Me.chkLogConnections.Enabled = True
		Me.chkLogConnections.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkLogConnections.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkLogConnections.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkLogConnections.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkLogConnections.TabStop = True
		Me.chkLogConnections.Visible = True
		Me.chkLogConnections.Name = "chkLogConnections"
		Me.chkLogRequests.Text = "Log http requests"
		Me.chkLogRequests.Size = New System.Drawing.Size(233, 17)
		Me.chkLogRequests.Location = New System.Drawing.Point(8, 88)
		Me.chkLogRequests.TabIndex = 6
		Me.chkLogRequests.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkLogRequests.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkLogRequests.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkLogRequests.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkLogRequests.BackColor = System.Drawing.SystemColors.Control
		Me.chkLogRequests.CausesValidation = True
		Me.chkLogRequests.Enabled = True
		Me.chkLogRequests.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkLogRequests.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkLogRequests.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkLogRequests.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkLogRequests.TabStop = True
		Me.chkLogRequests.Visible = True
		Me.chkLogRequests.Name = "chkLogRequests"
		Me.txtHTTPIP.AutoSize = False
		Me.txtHTTPIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtHTTPIP.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtHTTPIP.Size = New System.Drawing.Size(169, 19)
		Me.txtHTTPIP.Location = New System.Drawing.Point(72, 40)
		Me.txtHTTPIP.TabIndex = 5
		Me.txtHTTPIP.Text = "autoselect"
		Me.txtHTTPIP.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtHTTPIP.AcceptsReturn = True
		Me.txtHTTPIP.CausesValidation = True
		Me.txtHTTPIP.Enabled = True
		Me.txtHTTPIP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtHTTPIP.HideSelection = True
		Me.txtHTTPIP.ReadOnly = False
		Me.txtHTTPIP.Maxlength = 0
		Me.txtHTTPIP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtHTTPIP.MultiLine = False
		Me.txtHTTPIP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtHTTPIP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtHTTPIP.TabStop = True
		Me.txtHTTPIP.Visible = True
		Me.txtHTTPIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtHTTPIP.Name = "txtHTTPIP"
		Me.txtHTTPPort.AutoSize = False
		Me.txtHTTPPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtHTTPPort.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtHTTPPort.Size = New System.Drawing.Size(169, 19)
		Me.txtHTTPPort.Location = New System.Drawing.Point(72, 64)
		Me.txtHTTPPort.TabIndex = 4
		Me.txtHTTPPort.Text = "8080"
		Me.txtHTTPPort.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtHTTPPort.AcceptsReturn = True
		Me.txtHTTPPort.CausesValidation = True
		Me.txtHTTPPort.Enabled = True
		Me.txtHTTPPort.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtHTTPPort.HideSelection = True
		Me.txtHTTPPort.ReadOnly = False
		Me.txtHTTPPort.Maxlength = 0
		Me.txtHTTPPort.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtHTTPPort.MultiLine = False
		Me.txtHTTPPort.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtHTTPPort.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtHTTPPort.TabStop = True
		Me.txtHTTPPort.Visible = True
		Me.txtHTTPPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtHTTPPort.Name = "txtHTTPPort"
		Me.chkHTTP.Text = "Enable integrated HTTP server"
		Me.chkHTTP.Size = New System.Drawing.Size(177, 17)
		Me.chkHTTP.Location = New System.Drawing.Point(8, 16)
		Me.chkHTTP.TabIndex = 1
		Me.chkHTTP.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkHTTP.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkHTTP.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkHTTP.BackColor = System.Drawing.SystemColors.Control
		Me.chkHTTP.CausesValidation = True
		Me.chkHTTP.Enabled = True
		Me.chkHTTP.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkHTTP.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkHTTP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkHTTP.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkHTTP.TabStop = True
		Me.chkHTTP.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkHTTP.Visible = True
		Me.chkHTTP.Name = "chkHTTP"
		Me.Label2.Text = "HTTP Port:"
		Me.Label2.Size = New System.Drawing.Size(65, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 64)
		Me.Label2.TabIndex = 3
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "HTTP IP:"
		Me.Label1.Size = New System.Drawing.Size(65, 17)
		Me.Label1.Location = New System.Drawing.Point(8, 40)
		Me.Label1.TabIndex = 2
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Sck.SetIndex(_Sck_0, CType(0, Short))
		Me.tmrSendData.SetIndex(_tmrSendData_0, CType(0, Short))
		CType(Me.tmrSendData, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Sck, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me._Sck_0, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Controls.Add(Frame1)
		Me.Frame1.Controls.Add(_Sck_0)
		Me.Frame1.Controls.Add(chkLogConnections)
		Me.Frame1.Controls.Add(chkLogRequests)
		Me.Frame1.Controls.Add(txtHTTPIP)
		Me.Frame1.Controls.Add(txtHTTPPort)
		Me.Frame1.Controls.Add(chkHTTP)
		Me.Frame1.Controls.Add(Label2)
		Me.Frame1.Controls.Add(Label1)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class