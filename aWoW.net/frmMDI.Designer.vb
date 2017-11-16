<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMDI
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
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
	Public WithEvents mnView As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnAbout As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnHelp As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMDI))
		Me.IsMDIContainer = True
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip
		Me.mnView = New System.Windows.Forms.ToolStripMenuItem
		Me.mnHelp = New System.Windows.Forms.ToolStripMenuItem
		Me.mnAbout = New System.Windows.Forms.ToolStripMenuItem
		Me.MainMenu1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.SystemColors.AppWorkspace
		Me.Text = "aWoWe - Alternative WoW Emulator ALPHA"
		Me.ClientSize = New System.Drawing.Size(661, 457)
		Me.Location = New System.Drawing.Point(170, 123)
		Me.Icon = CType(resources.GetObject("frmMDI.Icon"), System.Drawing.Icon)
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Name = "frmMDI"
		Me.mnView.Name = "mnView"
		Me.mnView.Text = "View"
		Me.mnView.Checked = False
		Me.mnView.Enabled = True
		Me.mnView.Visible = True
		Me.mnHelp.Name = "mnHelp"
		Me.mnHelp.Text = "Help"
		Me.mnHelp.Checked = False
		Me.mnHelp.Enabled = True
		Me.mnHelp.Visible = True
		Me.mnAbout.Name = "mnAbout"
		Me.mnAbout.Text = "About"
		Me.mnAbout.Checked = False
		Me.mnAbout.Enabled = True
		Me.mnAbout.Visible = True
		Me.mnView.MergeAction = System.Windows.Forms.MergeAction.Remove
		Me.mnHelp.MergeAction = System.Windows.Forms.MergeAction.Remove
		MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnView, Me.mnHelp})
		mnHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnAbout})
		Me.Controls.Add(MainMenu1)
		Me.MainMenu1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class