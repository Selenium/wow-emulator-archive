Imports aWoWe.Filebase.MPQ
Imports System.IO
Imports System.Runtime.InteropServices

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents mnMain As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents tvFolders As System.Windows.Forms.TreeView
    Friend WithEvents mnFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnOpen As System.Windows.Forms.MenuItem
    Friend WithEvents mnClose As System.Windows.Forms.MenuItem
    Friend WithEvents mnExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnOptions As System.Windows.Forms.MenuItem
    Friend WithEvents mnSetListFile As System.Windows.Forms.MenuItem
    Friend WithEvents tvImageList As System.Windows.Forms.ImageList
    Friend WithEvents tvList As System.Windows.Forms.ListView
    Friend WithEvents tvStatus As System.Windows.Forms.StatusBar
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents cmExtract As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents mnExtract As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnMain = New System.Windows.Forms.MainMenu
        Me.mnFile = New System.Windows.Forms.MenuItem
        Me.mnOpen = New System.Windows.Forms.MenuItem
        Me.mnClose = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.mnExit = New System.Windows.Forms.MenuItem
        Me.mnOptions = New System.Windows.Forms.MenuItem
        Me.mnSetListFile = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.tvFolders = New System.Windows.Forms.TreeView
        Me.tvImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.tvList = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.cmExtract = New System.Windows.Forms.ContextMenu
        Me.mnExtract = New System.Windows.Forms.MenuItem
        Me.tvStatus = New System.Windows.Forms.StatusBar
        Me.SuspendLayout()
        '
        'mnMain
        '
        Me.mnMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnFile, Me.mnOptions, Me.MenuItem6})
        '
        'mnFile
        '
        Me.mnFile.Index = 0
        Me.mnFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnOpen, Me.mnClose, Me.MenuItem4, Me.mnExit})
        Me.mnFile.Text = "&File"
        '
        'mnOpen
        '
        Me.mnOpen.Index = 0
        Me.mnOpen.Text = "&Open"
        '
        'mnClose
        '
        Me.mnClose.Index = 1
        Me.mnClose.Text = "&Close"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "-"
        '
        'mnExit
        '
        Me.mnExit.Index = 3
        Me.mnExit.Text = "&Exit"
        '
        'mnOptions
        '
        Me.mnOptions.Index = 1
        Me.mnOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnSetListFile, Me.MenuItem1})
        Me.mnOptions.Text = "Options"
        '
        'mnSetListFile
        '
        Me.mnSetListFile.Index = 0
        Me.mnSetListFile.Text = "Set (listfile)"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3})
        Me.MenuItem1.Text = "Extract Map Files"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Mangos MAP V2"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "Mangos MAP V1"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 2
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem7})
        Me.MenuItem6.Text = "&Help"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 0
        Me.MenuItem7.Text = "&About"
        '
        'tvFolders
        '
        Me.tvFolders.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvFolders.ImageIndex = -1
        Me.tvFolders.Location = New System.Drawing.Point(0, 0)
        Me.tvFolders.Name = "tvFolders"
        Me.tvFolders.SelectedImageIndex = -1
        Me.tvFolders.Size = New System.Drawing.Size(232, 440)
        Me.tvFolders.TabIndex = 0
        '
        'tvImageList
        '
        Me.tvImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.tvImageList.ImageStream = CType(resources.GetObject("tvImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.tvImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'tvList
        '
        Me.tvList.BackColor = System.Drawing.SystemColors.Window
        Me.tvList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader3})
        Me.tvList.ContextMenu = Me.cmExtract
        Me.tvList.FullRowSelect = True
        Me.tvList.GridLines = True
        Me.tvList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.tvList.LargeImageList = Me.tvImageList
        Me.tvList.Location = New System.Drawing.Point(240, 0)
        Me.tvList.Name = "tvList"
        Me.tvList.Size = New System.Drawing.Size(655, 440)
        Me.tvList.SmallImageList = Me.tvImageList
        Me.tvList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.tvList.StateImageList = Me.tvImageList
        Me.tvList.TabIndex = 1
        Me.tvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 350
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Size"
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Compressed Size"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Flags"
        Me.ColumnHeader3.Width = 100
        '
        'cmExtract
        '
        Me.cmExtract.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnExtract})
        '
        'mnExtract
        '
        Me.mnExtract.Index = 0
        Me.mnExtract.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.mnExtract.Text = "&Extract File"
        '
        'tvStatus
        '
        Me.tvStatus.Location = New System.Drawing.Point(0, 464)
        Me.tvStatus.Name = "tvStatus"
        Me.tvStatus.Size = New System.Drawing.Size(898, 16)
        Me.tvStatus.TabIndex = 2
        Me.tvStatus.Text = "Ready."
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(898, 480)
        Me.Controls.Add(Me.tvStatus)
        Me.Controls.Add(Me.tvList)
        Me.Controls.Add(Me.tvFolders)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Menu = Me.mnMain
        Me.MinimumSize = New System.Drawing.Size(904, 512)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "aWoWe.MPQReader"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public MPQFile As MPQArchive = Nothing
    Public MPQFilename As String = ""

    Private Sub mnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnOpen.Click

        Dim dlgOpen As New OpenFileDialog
        dlgOpen.CheckFileExists = True
        dlgOpen.CheckPathExists = True
        dlgOpen.DefaultExt = "mpq"
        dlgOpen.Filter = "MPQ Archives (*.mpq)|*.mpq"
        dlgOpen.Multiselect = False
        Dim dres As DialogResult
        dres = dlgOpen.ShowDialog()

        If dlgOpen.OpenFile Is Nothing Then
            MessageBox.Show("File not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MPQFile = New MPQArchive(dlgOpen.OpenFile)
            MPQFilename = Path.GetFileName(dlgOpen.FileName)
            DisplayFolders()
        End If

        dlgOpen.Dispose()

    End Sub
    Private Sub mnSetListFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSetListFile.Click

        If MPQFile Is Nothing Then
            MessageBox.Show("You must open archive file first.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim dlgOpen As New OpenFileDialog
            dlgOpen.CheckFileExists = True
            dlgOpen.CheckPathExists = True
            dlgOpen.DefaultExt = ""
            dlgOpen.Filter = "Text files (*.txt)|*.txt"
            dlgOpen.Multiselect = False
            Dim dres As DialogResult
            dres = dlgOpen.ShowDialog()

            If dres = DialogResult.OK Then MPQFile.ExternalListFile = dlgOpen.FileName
        End If

    End Sub





    Public Sub DisplayFolders()
        Me.tvStatus.Text = "Loading file..."
        Me.tvFolders.Nodes.Clear()
        Me.tvList.Items.Clear()
        Me.tvFolders.ImageList = Me.tvImageList


        Dim folders As New Hashtable

        Dim temp() As String
        Dim FileName As String
        Dim FilePath As String
        Dim i As Integer


        Dim rootNode As New TreeNode(MPQFilename, 1, 1)
        Me.tvFolders.Nodes.Add(rootNode)


        Me.tvStatus.Text = "Listing files..."
        For Each File As MPQArchive.FileInfo In MPQFile.Files

            'Build folders
            temp = Split(File.Name, "\")
            FileName = Path.GetFileName(File.Name)
            FilePath = ""
            For i = 0 To temp.Length - 1
                If temp(i) <> FileName AndAlso Not folders.ContainsKey(FilePath & "\" & temp(i)) Then

                    Dim newNode As TreeNode
                    If i = temp.Length - 1 Then
                        newNode = New TreeNode(temp(i), 2, 2)
                    Else
                        newNode = New TreeNode(temp(i), 1, 1)
                    End If

                    If i > 0 AndAlso folders.ContainsKey(FilePath) Then
                        folders.Add(FilePath & "\" & temp(i), newNode)
                        folders(FilePath).Nodes.Add(newNode)
                    Else
                        folders.Add(FilePath & "\" & temp(i), newNode)
                        rootNode.Nodes.Add(newNode)
                    End If

                End If
                FilePath += "\" & temp(i)
            Next
        Next

        Me.tvStatus.Text = "Ready."

    End Sub
    Private Sub tvFolders_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvFolders.AfterSelect
        Me.tvStatus.Text = "Getting file information..."
        Me.tvList.Items.Clear()

        Const KB = 1000
        Const MB = 1000 * KB

        Dim listMe As String = Me.tvFolders.SelectedNode.FullPath & "\"

        For Each File As MPQArchive.FileInfo In MPQFile.Files
            If UCase(Path.GetDirectoryName(MPQFilename & "\" & File.Name)) = UCase(Path.GetDirectoryName(listMe)) Then
                Select Case File.CompressedSize
                    Case Is < KB
                        Me.tvList.Items.Add(New ListViewItem(New String() { _
                                            Path.GetFileName(File.Name), _
                                            File.UncompressedSize & " B", _
                                            File.CompressedSize & " B", _
                                            "0x" & Hex(File.Flags) _
                                            }, 2))
                    Case Is < MB
                        Me.tvList.Items.Add(New ListViewItem(New String() { _
                                            Path.GetFileName(File.Name), _
                                            File.UncompressedSize \ KB & " KB", _
                                            File.CompressedSize \ KB & " KB", _
                                            "0x" & Hex(File.Flags) _
                                            }, 2))
                    Case Else
                        Me.tvList.Items.Add(New ListViewItem(New String() { _
                                            Path.GetFileName(File.Name), _
                                            File.UncompressedSize \ MB & " MB", _
                                            File.CompressedSize \ MB & " MB", _
                                            "0x" & Hex(File.Flags) _
                                            }, 2))
                End Select
            End If
        Next

        Me.tvStatus.Text = "Ready."
    End Sub

    Private Sub mnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnClose.Click
        Me.tvFolders.Nodes.Clear()
        Me.tvList.Items.Clear()
        MPQFile.Dispose()
        MPQFile = Nothing
    End Sub
    Private Sub mnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnExit.Click
        End
    End Sub
    Private Sub cmExtract_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmExtract.Popup
        mnExtract.Enabled = False

        For Each File As ListViewItem In Me.tvList.Items
            If File.Selected Then
                mnExtract.Enabled = True
                Return
            End If
        Next
    End Sub
    Private Sub mnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnExtract.Click
        Dim ExtractionPath As String = ""

        Dim fbd As FolderBrowserDialog = New FolderBrowserDialog
        Dim dres As DialogResult
        dres = fbd.ShowDialog()
        If dres = Windows.Forms.DialogResult.OK Then
            ExtractionPath = fbd.SelectedPath

            For Each File As ListViewItem In Me.tvList.Items
                Me.tvStatus.Text = "Extracting [" & File.Text & "]..."
                If File.Selected Then
                    Dim ostream As New FileStream(ExtractionPath & "\" & File.Text, FileMode.Create)
                    Dim istream As MpqStream = MPQFile.OpenFile(Mid(Me.tvFolders.SelectedNode.FullPath, UCase(Me.tvFolders.SelectedNode.FullPath).IndexOf(".MPQ\") + 6) & "\" & File.Text)
                    Dim buffer(8096) As Byte
                    Dim readBytes As Integer
                    While True
                        readBytes = istream.Read(buffer, 0, buffer.Length)
                        If readBytes <= 0 Then Exit While
                        ostream.Write(buffer, 0, readBytes)
                    End While
                    ostream.Close()
                    istream.Close()
                End If
            Next
        End If

        Me.tvStatus.Text = "Ready."
    End Sub
End Class

