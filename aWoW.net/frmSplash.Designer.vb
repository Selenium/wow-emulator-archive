<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSplash
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
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents lblProgress As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblStatus As System.Windows.Forms.Label
	Public WithEvents Image7 As System.Windows.Forms.PictureBox
	Public WithEvents Image6 As System.Windows.Forms.PictureBox
	Public WithEvents Image5 As System.Windows.Forms.PictureBox
	Public WithEvents Image4 As System.Windows.Forms.PictureBox
	Public WithEvents Image3 As System.Windows.Forms.PictureBox
	Public WithEvents Image9 As System.Windows.Forms.PictureBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Shape1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSplash))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Timer1 = New System.Windows.Forms.Timer(components)
		Me.lblProgress = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblStatus = New System.Windows.Forms.Label
		Me.Image7 = New System.Windows.Forms.PictureBox
		Me.Image6 = New System.Windows.Forms.PictureBox
		Me.Image5 = New System.Windows.Forms.PictureBox
		Me.Image4 = New System.Windows.Forms.PictureBox
		Me.Image3 = New System.Windows.Forms.PictureBox
		Me.Image9 = New System.Windows.Forms.PictureBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.Shape1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Text = "Form1"
		Me.ClientSize = New System.Drawing.Size(514, 249)
		Me.Location = New System.Drawing.Point(246, 243)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSplash"
		Me.Timer1.Interval = 1000
		Me.Timer1.Enabled = True
		Me.lblProgress.Text = "-"
		Me.lblProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 36!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.lblProgress.ForeColor = System.Drawing.Color.Black
		Me.lblProgress.Size = New System.Drawing.Size(201, 41)
		Me.lblProgress.Location = New System.Drawing.Point(280, 152)
		Me.lblProgress.TabIndex = 3
		Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblProgress.BackColor = System.Drawing.Color.Transparent
		Me.lblProgress.Enabled = True
		Me.lblProgress.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblProgress.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblProgress.UseMnemonic = True
		Me.lblProgress.Visible = True
		Me.lblProgress.AutoSize = False
		Me.lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblProgress.Name = "lblProgress"
		Me.Label1.Text = "Alternative World of Warcraft Emulator"
		Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.Label1.Size = New System.Drawing.Size(225, 17)
		Me.Label1.Location = New System.Drawing.Point(280, 184)
		Me.Label1.TabIndex = 1
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblStatus.Text = "Initializing..."
		Me.lblStatus.Font = New System.Drawing.Font("Franklin Gothic Medium", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.lblStatus.ForeColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.lblStatus.Size = New System.Drawing.Size(273, 25)
		Me.lblStatus.Location = New System.Drawing.Point(232, 230)
		Me.lblStatus.TabIndex = 0
		Me.lblStatus.BackColor = System.Drawing.Color.Transparent
		Me.lblStatus.Enabled = True
		Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblStatus.UseMnemonic = True
		Me.lblStatus.Visible = True
		Me.lblStatus.AutoSize = False
		Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblStatus.Name = "lblStatus"
		Me.Image7.Size = New System.Drawing.Size(43, 44)
		Me.Image7.Location = New System.Drawing.Point(440, 136)
		Me.Image7.Image = CType(resources.GetObject("Image7.Image"), System.Drawing.Image)
		Me.Image7.Enabled = True
		Me.Image7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image7.Visible = True
		Me.Image7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Image7.Name = "Image7"
		Me.Image6.Size = New System.Drawing.Size(43, 44)
		Me.Image6.Location = New System.Drawing.Point(360, 136)
		Me.Image6.Image = CType(resources.GetObject("Image6.Image"), System.Drawing.Image)
		Me.Image6.Enabled = True
		Me.Image6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image6.Visible = True
		Me.Image6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Image6.Name = "Image6"
		Me.Image5.Size = New System.Drawing.Size(43, 44)
		Me.Image5.Location = New System.Drawing.Point(400, 136)
		Me.Image5.Image = CType(resources.GetObject("Image5.Image"), System.Drawing.Image)
		Me.Image5.Enabled = True
		Me.Image5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image5.Visible = True
		Me.Image5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Image5.Name = "Image5"
		Me.Image4.Size = New System.Drawing.Size(43, 44)
		Me.Image4.Location = New System.Drawing.Point(320, 136)
		Me.Image4.Image = CType(resources.GetObject("Image4.Image"), System.Drawing.Image)
		Me.Image4.Enabled = True
		Me.Image4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image4.Visible = True
		Me.Image4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Image4.Name = "Image4"
		Me.Image3.Size = New System.Drawing.Size(43, 44)
		Me.Image3.Location = New System.Drawing.Point(280, 136)
		Me.Image3.Image = CType(resources.GetObject("Image3.Image"), System.Drawing.Image)
		Me.Image3.Enabled = True
		Me.Image3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image3.Visible = True
		Me.Image3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Image3.Name = "Image3"
		Me.Image9.Size = New System.Drawing.Size(512, 144)
		Me.Image9.Location = New System.Drawing.Point(1, 1)
		Me.Image9.Image = CType(resources.GetObject("Image9.Image"), System.Drawing.Image)
		Me.Image9.Enabled = True
		Me.Image9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image9.Visible = True
		Me.Image9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Image9.Name = "Image9"
		Me.Label2.Text = "This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details."
		Me.Label2.Font = New System.Drawing.Font("MS Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label2.Size = New System.Drawing.Size(265, 89)
		Me.Label2.Location = New System.Drawing.Point(8, 152)
		Me.Label2.TabIndex = 2
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Shape1.Size = New System.Drawing.Size(514, 104)
		Me.Shape1.Location = New System.Drawing.Point(0, 145)
		Me.Shape1.BackColor = System.Drawing.Color.White
		Me.Shape1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Shape1.Visible = True
		Me.Shape1.Name = "Shape1"
		Me.Controls.Add(lblProgress)
		Me.Controls.Add(Label1)
		Me.Controls.Add(lblStatus)
		Me.Controls.Add(Image7)
		Me.Controls.Add(Image6)
		Me.Controls.Add(Image5)
		Me.Controls.Add(Image4)
		Me.Controls.Add(Image3)
		Me.Controls.Add(Image9)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Shape1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class