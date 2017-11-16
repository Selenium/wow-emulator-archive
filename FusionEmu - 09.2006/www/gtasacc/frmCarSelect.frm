VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmCarSelect 
   Caption         =   "GTA SA Control Center Garage Editor - Vehicle Selection"
   ClientHeight    =   8625
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   11880
   Icon            =   "frmCarSelect.frx":0000
   LinkTopic       =   "frmCarSelect"
   LockControls    =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   8625
   ScaleWidth      =   11880
   StartUpPosition =   1  'CenterOwner
   Begin VB.Timer tmrLoadCars 
      Enabled         =   0   'False
      Interval        =   200
      Left            =   150
      Top             =   8070
   End
   Begin VB.CommandButton cmdCarSelect 
      Cancel          =   -1  'True
      Caption         =   "Cancel"
      Enabled         =   0   'False
      Height          =   465
      Index           =   1
      Left            =   6478
      TabIndex        =   2
      Top             =   7995
      Width           =   4185
   End
   Begin VB.CommandButton cmdCarSelect 
      Caption         =   "OK"
      Default         =   -1  'True
      Enabled         =   0   'False
      Height          =   465
      Index           =   0
      Left            =   1217
      TabIndex        =   1
      Top             =   7995
      Width           =   4185
   End
   Begin TabDlg.SSTab sstVehicles 
      Height          =   7860
      Left            =   15
      TabIndex        =   0
      Top             =   15
      Visible         =   0   'False
      Width           =   11835
      _ExtentX        =   20876
      _ExtentY        =   13864
      _Version        =   393216
      Style           =   1
      Tabs            =   13
      TabsPerRow      =   7
      TabHeight       =   520
      TabCaption(0)   =   "Favorites"
      TabPicture(0)   =   "frmCarSelect.frx":014A
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "lvwCars(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).ControlCount=   1
      TabCaption(1)   =   "Sports Cars"
      TabPicture(1)   =   "frmCarSelect.frx":0166
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "lvwCars(1)"
      Tab(1).ControlCount=   1
      TabCaption(2)   =   "Off-Road"
      TabPicture(2)   =   "frmCarSelect.frx":0182
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "lvwCars(2)"
      Tab(2).ControlCount=   1
      TabCaption(3)   =   "Lowriders"
      TabPicture(3)   =   "frmCarSelect.frx":019E
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "lvwCars(3)"
      Tab(3).ControlCount=   1
      TabCaption(4)   =   "Convertibles"
      TabPicture(4)   =   "frmCarSelect.frx":01BA
      Tab(4).ControlEnabled=   0   'False
      Tab(4).Control(0)=   "lvwCars(4)"
      Tab(4).ControlCount=   1
      TabCaption(5)   =   "Other Cars"
      TabPicture(5)   =   "frmCarSelect.frx":01D6
      Tab(5).ControlEnabled=   0   'False
      Tab(5).Control(0)=   "lvwCars(5)"
      Tab(5).ControlCount=   1
      TabCaption(6)   =   "Industrial Vehicles"
      TabPicture(6)   =   "frmCarSelect.frx":01F2
      Tab(6).ControlEnabled=   0   'False
      Tab(6).Control(0)=   "lvwCars(6)"
      Tab(6).ControlCount=   1
      TabCaption(7)   =   "Public Service"
      TabPicture(7)   =   "frmCarSelect.frx":020E
      Tab(7).ControlEnabled=   0   'False
      Tab(7).Control(0)=   "lvwCars(7)"
      Tab(7).ControlCount=   1
      TabCaption(8)   =   "Helicopters"
      TabPicture(8)   =   "frmCarSelect.frx":022A
      Tab(8).ControlEnabled=   0   'False
      Tab(8).Control(0)=   "lvwCars(8)"
      Tab(8).ControlCount=   1
      TabCaption(9)   =   "Planes"
      TabPicture(9)   =   "frmCarSelect.frx":0246
      Tab(9).ControlEnabled=   0   'False
      Tab(9).Control(0)=   "lvwCars(9)"
      Tab(9).ControlCount=   1
      TabCaption(10)  =   "Bikes"
      TabPicture(10)  =   "frmCarSelect.frx":0262
      Tab(10).ControlEnabled=   0   'False
      Tab(10).Control(0)=   "lvwCars(10)"
      Tab(10).ControlCount=   1
      TabCaption(11)  =   "Boats"
      TabPicture(11)  =   "frmCarSelect.frx":027E
      Tab(11).ControlEnabled=   0   'False
      Tab(11).Control(0)=   "lvwCars(11)"
      Tab(11).ControlCount=   1
      TabCaption(12)  =   "Unique Vehicles"
      TabPicture(12)  =   "frmCarSelect.frx":029A
      Tab(12).ControlEnabled=   0   'False
      Tab(12).Control(0)=   "lvwCars(12)"
      Tab(12).ControlCount=   1
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   0
         Left            =   75
         TabIndex        =   3
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   1
         Left            =   -74925
         TabIndex        =   4
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   2
         Left            =   -74925
         TabIndex        =   5
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   3
         Left            =   -74925
         TabIndex        =   6
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   4
         Left            =   -74925
         TabIndex        =   7
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   5
         Left            =   -74925
         TabIndex        =   8
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   6
         Left            =   -74925
         TabIndex        =   9
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   7
         Left            =   -74925
         TabIndex        =   10
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   8
         Left            =   -74925
         TabIndex        =   11
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   9
         Left            =   -74925
         TabIndex        =   12
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   10
         Left            =   -74925
         TabIndex        =   13
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   11
         Left            =   -74925
         TabIndex        =   14
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
      Begin MSComctlLib.ListView lvwCars 
         Height          =   7020
         Index           =   12
         Left            =   -74925
         TabIndex        =   15
         Top             =   705
         Width           =   11505
         _ExtentX        =   20294
         _ExtentY        =   12383
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         Icons           =   "iListCars"
         SmallIcons      =   "iListCars"
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   4
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Key             =   "CarPic"
            Text            =   "Picture"
            Object.Width           =   2725
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Key             =   "Stars"
            Text            =   "*"
            Object.Width           =   503
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Key             =   "CarName"
            Text            =   "Name"
            Object.Width           =   2805
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Key             =   "CarDesc"
            Text            =   "Description"
            Object.Width           =   13679
         EndProperty
      End
   End
   Begin MSComctlLib.ImageList iListCars 
      Left            =   11160
      Top             =   510
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      MaskColor       =   12632256
      _Version        =   393216
   End
   Begin VB.Label lblProgress 
      Alignment       =   2  'Center
      Caption         =   "Please wait... Loading Vehicle Pictures"
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   690
      Left            =   960
      TabIndex        =   16
      Top             =   3510
      Width           =   9645
   End
   Begin VB.Menu mFavRemove 
      Caption         =   "mFavRemove"
      Visible         =   0   'False
      Begin VB.Menu uFavRemove 
         Caption         =   "Remove from Favorites"
      End
   End
   Begin VB.Menu mFavAdd 
      Caption         =   "mFavAdd"
      Visible         =   0   'False
      Begin VB.Menu uFavAdd 
         Caption         =   "Add to Favorites"
      End
   End
End
Attribute VB_Name = "frmCarSelect"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public iSelectedID As Integer
Public isOKClicked As Boolean
'*****************************************************************************************************************
'                                           Form Load / Unload
'*****************************************************************************************************************

Private Sub Form_Load()
On Error Resume Next
    isOKClicked = False
    iSelectedID = -1
    DoEvents
    tmrLoadCars.Enabled = True
End Sub

Private Sub tmrLoadCars_Timer()
On Error Resume Next
    tmrLoadCars.Enabled = False
    If ParseCarPics Then
        lblProgress.Visible = False
        sstVehicles.Tab = 0
        sstVehicles.Visible = True
        cmdCarSelect(0).Enabled = True
    Else
        lblProgress.Caption = "Error parsing car pictures."
    End If
    cmdCarSelect(1).Enabled = True 'cancel
    isCarPicsReady = True
End Sub

Private Sub Form_Resize()
On Error Resume Next
    Dim iCtr As Integer
    If Me.WindowState = vbMinimized Then Exit Sub
    If Me.WindowState = vbNormal Then 'normal
        If Me.Width < 12000 Then Me.Width = 12000: Exit Sub
        If Me.Height < 9000 Then Me.Height = 9000: Exit Sub
    End If
    sstVehicles.Width = Me.Width - 165
    sstVehicles.Height = Me.Height - 1140 '- 295
    cmdCarSelect(0).Top = Me.Height - 1005 '- 295
    cmdCarSelect(1).Top = Me.Height - 1005 '- 295
    cmdCarSelect(0).Left = (Me.Width - 4185 - 4185) / 3
    cmdCarSelect(1).Left = (2 * ((Me.Width - 4185 - 4185) / 3)) + 4185
    For iCtr = 0 To 12
        lvwCars(iCtr).Height = Me.Height - 1980 '- 295
        lvwCars(iCtr).Width = Me.Width - 495
    Next iCtr
End Sub

'*****************************************************************************************************************
'                                           User Interaction
'*****************************************************************************************************************

Private Sub cmdCarSelect_Click(Index As Integer)
On Error Resume Next
    If Index = 0 Then 'OK
        isOKClicked = True
    Else
        iSelectedID = -1
        isOKClicked = False
    End If
    Me.Hide
End Sub

Private Sub lvwCars_ItemClick(Index As Integer, ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    iSelectedID = CInt(Mid$(Item.Key, 3))
    Me.Caption = "GTA SA Control Center Garage Editor - Vehicle Selection [" & Item.SubItems(2) & "]"
End Sub

Private Sub lvwCars_MouseUp(Index As Integer, Button As Integer, Shift As Integer, x As Single, y As Single)
On Error Resume Next
    If Button = vbRightButton Then
        If Index = 0 Then
            Me.PopupMenu mFavRemove
        Else
            Me.PopupMenu mFavAdd
        End If
    End If
End Sub

Private Sub uFavAdd_Click()
On Error GoTo errAlreadyAdded
    If MsgBox("Add this vehicle to favorites?", vbQuestion + vbDefaultButton2 + vbYesNoCancel, "Add to Favorites") = vbYes Then
        With lvwCars(0).ListItems.Add(, lvwCars(sstVehicles.Tab).SelectedItem.Key, "", lvwCars(sstVehicles.Tab).SelectedItem.Icon, lvwCars(sstVehicles.Tab).SelectedItem.SmallIcon)
            .SubItems(1) = lvwCars(sstVehicles.Tab).SelectedItem.SubItems(1) 'stars
            .SubItems(2) = lvwCars(sstVehicles.Tab).SelectedItem.SubItems(2) 'car name
            .SubItems(3) = lvwCars(sstVehicles.Tab).SelectedItem.SubItems(3) 'car description
        End With
        DumpCarPics
        ParseCarPics True
        PreSelectCarID iSelectedID
    End If
Exit Sub
errAlreadyAdded:
    MsgBox "This vehicle is already in the favorites list", vbInformation
    Err.Clear
End Sub

Private Sub uFavRemove_Click()
On Error Resume Next
    If MsgBox("Remove this vehicle from favorites?", vbQuestion + vbDefaultButton2 + vbYesNoCancel, "Remove from Favorites") = vbYes Then
        lvwCars(sstVehicles.Tab).ListItems.Remove lvwCars(sstVehicles.Tab).SelectedItem.Index
        DumpCarPics
        ParseCarPics True
        PreSelectCarID iSelectedID
    End If
End Sub

'*****************************************************************************************************************
'                                           Private Functions
'*****************************************************************************************************************

Private Function DumpCarPics() As Boolean
On Error Resume Next
    Dim iDumpCtr As Integer
    Dim itmCar As ListItem
    lblProgress.Caption = "Please wait... Saving Changes"
    DoEvents
    sstVehicles.Visible = False
    DoEvents
    Open strPicFileName For Output As #2
        Print #2, "#Edit this file as you wish. CarTypes are the selection tab on garage editor extended car selection. Type Name is the caption of the tab. TypeID is the"
        Print #2, "#reference to CarPictures. CarPictures are 100x72 pixel thumbnails, and saved under \CarPics folder. If a thumbnail is missing, or the car is not parkable,"
        Print #2, "#it will not be listed on the selection. You can list vehicles on more than one selection list. Create your own favorites to select one of your favorite"
        Print #2, "#cars to park in the selected garage. Use Pipe character '|' as seperator between fields. Most of the descriptions and the thumbnails are courtesy of"
        Print #2, "#www.g-unleashed.com. Please visit them. The g-unleashed.com thumbnails and descriptions are from the X-Box version of GTA SA, so some of the pictures"
        Print #2, "#and descriptions can actually differ from the PC edition."
        Print #2, ""
        Print #2, "GTASACarTypes"
        Print #2, "#TypeID", "Type Name"
        For iDumpCtr = 0 To 12
            sstVehicles.Tab = iDumpCtr
            Print #2, iDumpCtr & "|", sstVehicles.Caption
        Next iDumpCtr
        Print #2, "END_GTASACarTypes"
        Print #2, ""
        Print #2, "GTASACarPictures"
        Print #2, "#CarID", "TypeID", "CarName", "Stars", "CarDesc"
        For iDumpCtr = 0 To 12
            sstVehicles.Tab = iDumpCtr
            For Each itmCar In lvwCars(iDumpCtr).ListItems
                Print #2, CInt(Mid$(itmCar.Key, 3)) & "|", iDumpCtr & "|", itmCar.SubItems(2) & "|", itmCar.SubItems(1) & "|", itmCar.SubItems(3)
                          'CarID                          Page           CarName                  Stars                    Description
            Next
        Next iDumpCtr
        Print #2, "END_GTASACarPictures"
        Print #2, ""
    Close #2
    sstVehicles.Tab = 0
    sstVehicles.Visible = True
    DoEvents
End Function

Private Function ParseCarPics(Optional ByVal isReLoadOnly As Boolean = False) As Boolean
On Error GoTo errParseCarPics
    Dim itmCar As ListItem
    Dim intCarID As Integer
    Dim strLineInput As String
    Dim sSplitArr() As String
    Dim sKey As String
    ParseCarPics = False
    lblProgress.Caption = "Please wait... Loading Vehicle Pictures"
    DoEvents
    If isReLoadOnly Then
        sstVehicles.Visible = False
        For intCarID = 0 To 12
            lvwCars(intCarID).ListItems.Clear
        Next intCarID
        DoEvents
    Else
        For intCarID = 400 To 611
            If Len(Dir(App.Path & "\CarPics\" & intCarID & ".bmp")) > 0 Then
                iListCars.ListImages.Add , "id" & intCarID, LoadPicture(App.Path & "\CarPics\" & intCarID & ".bmp")
            End If
        Next intCarID
    End If
    'Read Car Types:
    lblProgress.Caption = "Please wait... Parsing Vehicle Types"
    DoEvents
    Open strPicFileName For Input As #1
    Do Until EOF(1) 'find start of Cat ID's:
        Line Input #1, strLineInput
        If Left$(strLineInput, 13) = "GTASACarTypes" Then Exit Do
    Loop
    Do Until EOF(1) 'read Car ID's:
        Line Input #1, strLineInput
        If Left$(strLineInput, 1) <> "#" Then
            If Left$(strLineInput, 17) = "END_GTASACarTypes" Then Exit Do
            'if we can come to this line, we have found a Car ID:
            strLineInput = Replace(strLineInput, vbTab, "")
            sSplitArr = Split(strLineInput, "|")
            If UBound(sSplitArr) = 1 Then
                If CInt(sSplitArr(0)) > -1 And CInt(sSplitArr(0)) < 13 Then
                    sstVehicles.Tab = Trim(sSplitArr(0))
                    sstVehicles.Caption = Trim(sSplitArr(1))
                End If
            End If
        End If
    Loop
    'Read Car Pics:
    lblProgress.Caption = "Please wait... Parsing Vehicle Descriptions"
    DoEvents
    Do Until EOF(1) 'find start of Cat ID's:
        Line Input #1, strLineInput
        If Left$(strLineInput, 16) = "GTASACarPictures" Then Exit Do
    Loop
    Do Until EOF(1) 'read Car ID's:
        Line Input #1, strLineInput
        If Left$(strLineInput, 1) <> "#" Then
            If Left$(strLineInput, 20) = "END_GTASACarPictures" Then Exit Do
            'if we can come to this line, we have found a Car ID:
            strLineInput = Replace(strLineInput, vbTab, "")
            sSplitArr = Split(strLineInput, "|")
            If UBound(sSplitArr) = 4 Then
                If Len(Dir(App.Path & "\CarPics\" & sSplitArr(0) & ".bmp")) > 0 Then 'doublecheck
                    If CInt(sSplitArr(1)) > -1 And CInt(sSplitArr(1)) < 13 Then 'type is also OK
                        sKey = "id" & Trim(sSplitArr(0))
                        Set itmCar = lvwCars(Trim(sSplitArr(1))).ListItems.Add(, sKey, "", , iListCars.ListImages("id" & Trim(sSplitArr(0))).Index)
                        itmCar.SubItems(1) = Trim(sSplitArr(3)) 'stars
                        itmCar.SubItems(2) = Trim(sSplitArr(2)) 'car name
                        itmCar.SubItems(3) = Trim(sSplitArr(4)) 'car description
                    End If
                End If
            End If
        End If
    Loop
    Close #1
    On Error Resume Next
    sstVehicles.Tab = 0
    sstVehicles.Visible = True
    If lvwCars(0).ListItems.Count > 0 Then
        lvwCars(0).SelectedItem = lvwCars(0).ListItems(1)
        lvwCars(0).ListItems(1).EnsureVisible
    End If
    ParseCarPics = True
Exit Function
errParseCarPics:
    MsgBox Err.Description, vbCritical, "Error parsing Car Pictures"
    Close #1
    Err.Clear
End Function

'*****************************************************************************************************************
'                                           Exported Functions
'*****************************************************************************************************************

Public Function PreSelectCarID(ByVal iCarID As Integer) As Boolean
On Error Resume Next
    Dim iCtr As Integer
    Dim iItemCtr As Integer
    isOKClicked = False
    iSelectedID = -1
    Me.Caption = "GTA SA Control Center Garage Editor - Vehicle Selection"
    If iCarID = -1 Then
        sstVehicles.Tab = 0
        If lvwCars(0).ListItems.Count > 0 Then
            lvwCars(0).ListItems(1).Selected = True
            lvwCars(0).ListItems(1).EnsureVisible
        End If
    Else
        For iCtr = 0 To 12
            For iItemCtr = 1 To lvwCars(iCtr).ListItems.Count
                If lvwCars(iCtr).ListItems(iItemCtr).Key = "id" & iCarID Then
                    sstVehicles.Tab = iCtr
                    lvwCars(iCtr).ListItems(iItemCtr).Selected = True
                    lvwCars(iCtr).ListItems(iItemCtr).EnsureVisible
                    lvwCars(iCtr).SelectedItem = lvwCars(iCtr).ListItems(iItemCtr)
                    Me.Caption = "GTA SA Control Center Garage Editor - Vehicle Selection [" & lvwCars(iCtr).ListItems(iItemCtr).SubItems(2) & "]"
                    iSelectedID = iCarID
                    GoTo CarIDFound
                End If
            Next iItemCtr
        Next iCtr
    End If
CarIDFound:
    PreSelectCarID = True
End Function

