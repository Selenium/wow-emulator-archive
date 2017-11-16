VERSION 5.00
Begin VB.UserControl GTASAGarageOcx 
   Appearance      =   0  'Flat
   BorderStyle     =   1  'Fixed Single
   ClientHeight    =   1320
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   11190
   ScaleHeight     =   1320
   ScaleWidth      =   11190
   Begin VB.CommandButton cmdCarPics 
      Caption         =   "Pick"
      Height          =   315
      Index           =   3
      Left            =   4245
      TabIndex        =   53
      TabStop         =   0   'False
      ToolTipText     =   "Pick vehicle from extended Car Selection Form"
      Top             =   975
      Visible         =   0   'False
      Width           =   720
   End
   Begin VB.CommandButton cmdCarPics 
      Caption         =   "Pick"
      Height          =   315
      Index           =   2
      Left            =   4245
      TabIndex        =   52
      TabStop         =   0   'False
      ToolTipText     =   "Pick vehicle from extended Car Selection Form"
      Top             =   660
      Visible         =   0   'False
      Width           =   720
   End
   Begin VB.CommandButton cmdCarPics 
      Caption         =   "Pick"
      Height          =   315
      Index           =   1
      Left            =   4245
      TabIndex        =   51
      TabStop         =   0   'False
      ToolTipText     =   "Pick vehicle from extended Car Selection Form"
      Top             =   345
      Visible         =   0   'False
      Width           =   720
   End
   Begin VB.CommandButton cmdCarPics 
      Caption         =   "Pick"
      Height          =   315
      Index           =   0
      Left            =   4245
      TabIndex        =   50
      TabStop         =   0   'False
      ToolTipText     =   "Pick vehicle from extended Car Selection Form"
      Top             =   30
      Width           =   720
   End
   Begin VB.CommandButton cmdEditMods 
      Caption         =   "Edit Mods"
      Enabled         =   0   'False
      Height          =   315
      Index           =   0
      Left            =   9900
      TabIndex        =   45
      ToolTipText     =   "Edit mods of this parked vehicle"
      Top             =   30
      Visible         =   0   'False
      Width           =   1200
   End
   Begin VB.CommandButton cmdEditMods 
      Caption         =   "Edit Mods"
      Enabled         =   0   'False
      Height          =   315
      Index           =   1
      Left            =   9900
      TabIndex        =   44
      ToolTipText     =   "Edit mods of this parked vehicle"
      Top             =   345
      Visible         =   0   'False
      Width           =   1200
   End
   Begin VB.CommandButton cmdEditMods 
      Caption         =   "Edit Mods"
      Enabled         =   0   'False
      Height          =   315
      Index           =   2
      Left            =   9900
      TabIndex        =   43
      ToolTipText     =   "Edit mods of this parked vehicle"
      Top             =   660
      Visible         =   0   'False
      Width           =   1200
   End
   Begin VB.CommandButton cmdEditMods 
      Caption         =   "Edit Mods"
      Enabled         =   0   'False
      Height          =   315
      Index           =   3
      Left            =   9900
      TabIndex        =   42
      ToolTipText     =   "Edit mods of this parked vehicle"
      Top             =   975
      Visible         =   0   'False
      Width           =   1200
   End
   Begin VB.CommandButton cmdClearMods 
      Caption         =   "Clear Mods"
      Height          =   315
      Index           =   0
      Left            =   8715
      TabIndex        =   41
      ToolTipText     =   "Clear all mods of this parked vehicle"
      Top             =   30
      Visible         =   0   'False
      Width           =   1200
   End
   Begin VB.CommandButton cmdClearMods 
      Caption         =   "Clear Mods"
      Height          =   315
      Index           =   1
      Left            =   8715
      TabIndex        =   40
      ToolTipText     =   "Clear all mods of this parked vehicle"
      Top             =   345
      Visible         =   0   'False
      Width           =   1200
   End
   Begin VB.CommandButton cmdClearMods 
      Caption         =   "Clear Mods"
      Height          =   315
      Index           =   2
      Left            =   8715
      TabIndex        =   39
      ToolTipText     =   "Clear all mods of this parked vehicle"
      Top             =   660
      Visible         =   0   'False
      Width           =   1200
   End
   Begin VB.CommandButton cmdClearMods 
      Caption         =   "Clear Mods"
      Height          =   315
      Index           =   3
      Left            =   8715
      TabIndex        =   38
      ToolTipText     =   "Clear all mods of this parked vehicle"
      Top             =   975
      Visible         =   0   'False
      Width           =   1200
   End
   Begin VB.CommandButton cmdAllProof 
      Caption         =   "All-Proof"
      Height          =   315
      Left            =   30
      TabIndex        =   33
      Top             =   345
      Width           =   1860
   End
   Begin VB.CheckBox chkFP 
      Height          =   315
      Index           =   3
      Left            =   5730
      TabIndex        =   28
      TabStop         =   0   'False
      ToolTipText     =   "Flame-proof"
      Top             =   975
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkBP 
      Height          =   315
      Index           =   3
      Left            =   5490
      TabIndex        =   27
      TabStop         =   0   'False
      ToolTipText     =   "Bullet-proof"
      Top             =   975
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkDP 
      Height          =   315
      Index           =   3
      Left            =   5265
      TabIndex        =   26
      TabStop         =   0   'False
      ToolTipText     =   "Damage-proof"
      Top             =   975
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkEP 
      Height          =   315
      Index           =   3
      Left            =   5025
      TabIndex        =   25
      TabStop         =   0   'False
      ToolTipText     =   "Explosion-proof"
      Top             =   975
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.PictureBox picMinor 
      Height          =   285
      Index           =   3
      Left            =   6870
      ScaleHeight     =   225
      ScaleWidth      =   795
      TabIndex        =   24
      TabStop         =   0   'False
      ToolTipText     =   "Doubleclick to change"
      Top             =   990
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.PictureBox picMajor 
      Height          =   285
      Index           =   3
      Left            =   5985
      ScaleHeight     =   225
      ScaleWidth      =   795
      TabIndex        =   23
      TabStop         =   0   'False
      ToolTipText     =   "Doubleclick to change"
      Top             =   990
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.ComboBox cboSelectCar 
      Height          =   315
      Index           =   3
      ItemData        =   "GTASAGarageOcx.ctx":0000
      Left            =   2145
      List            =   "GTASAGarageOcx.ctx":0002
      Style           =   2  'Dropdown List
      TabIndex        =   22
      TabStop         =   0   'False
      ToolTipText     =   "Select a car to Park in this Garage/Parkplace"
      Top             =   975
      Visible         =   0   'False
      Width           =   2070
   End
   Begin VB.CheckBox chkFP 
      Height          =   315
      Index           =   2
      Left            =   5730
      TabIndex        =   21
      TabStop         =   0   'False
      ToolTipText     =   "Flame-proof"
      Top             =   660
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkBP 
      Height          =   315
      Index           =   2
      Left            =   5490
      TabIndex        =   20
      TabStop         =   0   'False
      ToolTipText     =   "Bullet-proof"
      Top             =   660
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkDP 
      Height          =   315
      Index           =   2
      Left            =   5265
      TabIndex        =   19
      TabStop         =   0   'False
      ToolTipText     =   "Damage-proof"
      Top             =   660
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkEP 
      Height          =   315
      Index           =   2
      Left            =   5025
      TabIndex        =   18
      TabStop         =   0   'False
      ToolTipText     =   "Explosion-proof"
      Top             =   660
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.PictureBox picMinor 
      Height          =   285
      Index           =   2
      Left            =   6870
      ScaleHeight     =   225
      ScaleWidth      =   795
      TabIndex        =   17
      TabStop         =   0   'False
      ToolTipText     =   "Doubleclick to change"
      Top             =   675
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.PictureBox picMajor 
      Height          =   285
      Index           =   2
      Left            =   5985
      ScaleHeight     =   225
      ScaleWidth      =   795
      TabIndex        =   16
      TabStop         =   0   'False
      ToolTipText     =   "Doubleclick to change"
      Top             =   675
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.ComboBox cboSelectCar 
      Height          =   315
      Index           =   2
      ItemData        =   "GTASAGarageOcx.ctx":0004
      Left            =   2145
      List            =   "GTASAGarageOcx.ctx":0006
      Style           =   2  'Dropdown List
      TabIndex        =   15
      TabStop         =   0   'False
      ToolTipText     =   "Select a car to Park in this Garage/Parkplace"
      Top             =   660
      Visible         =   0   'False
      Width           =   2070
   End
   Begin VB.CheckBox chkFP 
      Height          =   315
      Index           =   1
      Left            =   5730
      TabIndex        =   14
      TabStop         =   0   'False
      ToolTipText     =   "Flame-proof"
      Top             =   345
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkBP 
      Height          =   315
      Index           =   1
      Left            =   5490
      TabIndex        =   13
      TabStop         =   0   'False
      ToolTipText     =   "Bullet-proof"
      Top             =   345
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkDP 
      Height          =   315
      Index           =   1
      Left            =   5265
      TabIndex        =   12
      TabStop         =   0   'False
      ToolTipText     =   "Damage-proof"
      Top             =   345
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkEP 
      Height          =   315
      Index           =   1
      Left            =   5025
      TabIndex        =   11
      TabStop         =   0   'False
      ToolTipText     =   "Explosion-proof"
      Top             =   345
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.PictureBox picMinor 
      Height          =   285
      Index           =   1
      Left            =   6870
      ScaleHeight     =   225
      ScaleWidth      =   795
      TabIndex        =   10
      TabStop         =   0   'False
      ToolTipText     =   "Doubleclick to change"
      Top             =   360
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.PictureBox picMajor 
      Height          =   285
      Index           =   1
      Left            =   5985
      ScaleHeight     =   225
      ScaleWidth      =   795
      TabIndex        =   9
      TabStop         =   0   'False
      ToolTipText     =   "Doubleclick to change"
      Top             =   360
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.ComboBox cboSelectCar 
      Height          =   315
      Index           =   1
      ItemData        =   "GTASAGarageOcx.ctx":0008
      Left            =   2145
      List            =   "GTASAGarageOcx.ctx":000A
      Style           =   2  'Dropdown List
      TabIndex        =   8
      TabStop         =   0   'False
      ToolTipText     =   "Select a car to Park in this Garage/Parkplace"
      Top             =   345
      Visible         =   0   'False
      Width           =   2070
   End
   Begin VB.CheckBox chkLockGarage 
      Caption         =   "Garage Caption:"
      Height          =   405
      Left            =   30
      TabIndex        =   7
      TabStop         =   0   'False
      ToolTipText     =   "Always Park these Cars to this garage"
      Top             =   0
      Width           =   1860
   End
   Begin VB.CheckBox chkFP 
      Height          =   315
      Index           =   0
      Left            =   5730
      TabIndex        =   6
      TabStop         =   0   'False
      ToolTipText     =   "Flame-proof"
      Top             =   30
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkBP 
      Height          =   315
      Index           =   0
      Left            =   5490
      TabIndex        =   5
      TabStop         =   0   'False
      ToolTipText     =   "Bullet-proof"
      Top             =   30
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkDP 
      Height          =   315
      Index           =   0
      Left            =   5265
      TabIndex        =   4
      TabStop         =   0   'False
      ToolTipText     =   "Damage-proof"
      Top             =   30
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.CheckBox chkEP 
      Height          =   315
      Index           =   0
      Left            =   5025
      TabIndex        =   3
      TabStop         =   0   'False
      ToolTipText     =   "Explosion-proof"
      Top             =   30
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.PictureBox picMinor 
      Height          =   285
      Index           =   0
      Left            =   6870
      ScaleHeight     =   225
      ScaleWidth      =   795
      TabIndex        =   2
      TabStop         =   0   'False
      ToolTipText     =   "Doubleclick to change"
      Top             =   45
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.PictureBox picMajor 
      Height          =   285
      Index           =   0
      Left            =   5985
      ScaleHeight     =   225
      ScaleWidth      =   795
      TabIndex        =   1
      TabStop         =   0   'False
      ToolTipText     =   "Doubleclick to change"
      Top             =   45
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.ComboBox cboSelectCar 
      Height          =   315
      Index           =   0
      ItemData        =   "GTASAGarageOcx.ctx":000C
      Left            =   2145
      List            =   "GTASAGarageOcx.ctx":000E
      Style           =   2  'Dropdown List
      TabIndex        =   0
      TabStop         =   0   'False
      ToolTipText     =   "Select a car to Park in this Garage/Parkplace"
      Top             =   30
      Width           =   2070
   End
   Begin VB.Label lblModNA 
      Caption         =   "There are no mods available for this vehicle."
      Height          =   195
      Index           =   0
      Left            =   7770
      TabIndex        =   49
      Top             =   90
      Visible         =   0   'False
      Width           =   3285
   End
   Begin VB.Label lblModNA 
      Caption         =   "There are no mods available for this vehicle."
      Height          =   195
      Index           =   3
      Left            =   7770
      TabIndex        =   48
      Top             =   1035
      Visible         =   0   'False
      Width           =   3285
   End
   Begin VB.Label lblModNA 
      Caption         =   "There are no mods available for this vehicle."
      Height          =   195
      Index           =   1
      Left            =   7770
      TabIndex        =   46
      Top             =   405
      Visible         =   0   'False
      Width           =   3285
   End
   Begin VB.Label lblModStatus 
      Caption         =   "Modded"
      Height          =   195
      Index           =   3
      Left            =   7755
      TabIndex        =   37
      Top             =   1035
      Visible         =   0   'False
      Width           =   930
   End
   Begin VB.Label lblModStatus 
      Caption         =   "Modded"
      Height          =   195
      Index           =   1
      Left            =   7755
      TabIndex        =   35
      Top             =   405
      Visible         =   0   'False
      Width           =   930
   End
   Begin VB.Label lblModStatus 
      Caption         =   "Modded"
      Height          =   195
      Index           =   0
      Left            =   7755
      TabIndex        =   34
      Top             =   90
      Visible         =   0   'False
      Width           =   930
   End
   Begin VB.Label lblCarOrdinal 
      AutoSize        =   -1  'True
      Caption         =   "4."
      Height          =   195
      Index           =   3
      Left            =   1965
      TabIndex        =   32
      Top             =   1035
      Width           =   135
   End
   Begin VB.Label lblCarOrdinal 
      AutoSize        =   -1  'True
      Caption         =   "3."
      Height          =   195
      Index           =   2
      Left            =   1965
      TabIndex        =   31
      Top             =   720
      Width           =   135
   End
   Begin VB.Label lblCarOrdinal 
      AutoSize        =   -1  'True
      Caption         =   "2."
      Height          =   195
      Index           =   1
      Left            =   1965
      TabIndex        =   30
      Top             =   405
      Width           =   135
   End
   Begin VB.Label lblCarOrdinal 
      AutoSize        =   -1  'True
      Caption         =   "1."
      Height          =   195
      Index           =   0
      Left            =   1965
      TabIndex        =   29
      Top             =   90
      Width           =   135
   End
   Begin VB.Label lblModNA 
      Caption         =   "There are no mods available for this vehicle."
      Height          =   195
      Index           =   2
      Left            =   7770
      TabIndex        =   47
      Top             =   720
      Visible         =   0   'False
      Width           =   3285
   End
   Begin VB.Label lblModStatus 
      Caption         =   "Modded"
      Height          =   195
      Index           =   2
      Left            =   7755
      TabIndex        =   36
      Top             =   720
      Visible         =   0   'False
      Width           =   930
   End
End
Attribute VB_Name = "GTASAGarageOcx"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
Private fPick As Form
Private iPickedColor As Integer
Private isInit As Boolean

Private tOnlineGarage As GTASAFullGarage
Private tNowParking As GTASAFullGarage
Private tLastParking As GTASAFullGarage

Private tTempGarage As GTASAFullGarage
Private iCarCtr As Integer
Private isResetMods(3) As Boolean

Public isDirty As Boolean 'if user has changed anything
Public isReparkNeeded As Boolean 'if user has changed cars from combo (cars will be reparked!!)
Event CarIDChanged(CarIdx As Integer, NewCarID As Integer)
Event CarColorChanged(CarIdx As Integer, NewCarColorIdx As Integer, isMajor As Boolean)
Event CarSpecsChanged(CarIdx As Integer, i0ep1bp2dp3fp As Integer, iNewVal As Integer)
Event GarageLocked(ByVal iNewChecked As Integer)
'*****************************************************************************************************
'                                    BPDPEPFP Checkboxes:
'*****************************************************************************************************
Public Property Get cEP(ByVal iCarIdx As Integer) As Integer
    cEP = chkEP(iCarIdx).Value
End Property
Public Property Get cBP(ByVal iCarIdx As Integer) As Integer
    cBP = chkBP(iCarIdx).Value
End Property
Public Property Get cDP(ByVal iCarIdx As Integer) As Integer
    cDP = chkDP(iCarIdx).Value
End Property
Public Property Get cFP(ByVal iCarIdx As Integer) As Integer
    cFP = chkFP(iCarIdx).Value
End Property
Public Property Let cEP(ByVal iCarIdx As Integer, NewChecked As Integer)
    chkEP(iCarIdx).Value = NewChecked
End Property
Public Property Let cBP(ByVal iCarIdx As Integer, NewChecked As Integer)
    chkBP(iCarIdx).Value = NewChecked
End Property
Public Property Let cDP(ByVal iCarIdx As Integer, NewChecked As Integer)
    chkDP(iCarIdx).Value = NewChecked
End Property
Public Property Let cFP(ByVal iCarIdx As Integer, NewChecked As Integer)
    chkFP(iCarIdx).Value = NewChecked
End Property
Private Sub chkBP_Click(Index As Integer)
    If Not isInit Then
        isDirty = True
        RaiseEvent CarSpecsChanged(Index, 1, chkBP(Index).Value)
    End If
End Sub
Private Sub chkDP_Click(Index As Integer)
    If Not isInit Then
        isDirty = True
        RaiseEvent CarSpecsChanged(Index, 2, chkDP(Index).Value)
    End If
End Sub
Private Sub chkEP_Click(Index As Integer)
    If Not isInit Then
        isDirty = True
        RaiseEvent CarSpecsChanged(Index, 0, chkEP(Index).Value)
    End If
End Sub
Private Sub chkFP_Click(Index As Integer)
    If Not isInit Then
        isDirty = True
        RaiseEvent CarSpecsChanged(Index, 3, chkFP(Index).Value)
    End If
End Sub
Public Property Get Locked() As Integer
    Locked = chkLockGarage.Value
End Property
Public Property Let Locked(ByVal NewChecked As Integer)
    chkLockGarage.Value = NewChecked
End Property
Private Sub chkLockGarage_Click()
    If Not isInit Then RaiseEvent GarageLocked(chkLockGarage.Value)
End Sub
Private Sub cmdAllProof_Click()
On Error Resume Next
    Static iCtr As Integer
    isInit = True
    For iCtr = 0 To 3
        chkEP(iCtr).Value = vbChecked
        chkBP(iCtr).Value = vbChecked
        chkDP(iCtr).Value = vbChecked
        chkFP(iCtr).Value = vbChecked
    Next iCtr
    isInit = False
    isDirty = True
End Sub

Private Sub cmdCarPics_Click(Index As Integer)
On Error Resume Next
    Dim iNewCarID As Integer
    iNewCarID = -1
    If Not isCarPicsReady Then
        Load frmCarSelect 'if not already loaded. This form does not get unloaded until gtasa Control Center exits.
        Do Until isCarPicsReady
            DoEvents
        Loop
        frmCarSelect.Hide
    End If
    If cboSelectCar(Index).ListIndex > 0 Then
        frmCarSelect.PreSelectCarID ParkedCarMatrix(Index, cboSelectCar(Index).ListIndex)
    Else
        frmCarSelect.PreSelectCarID -1
    End If
    frmCarSelect.Show vbModal, Me
    DoEvents
    If frmCarSelect.isOKClicked Then iNewCarID = frmCarSelect.iSelectedID
    If iNewCarID > 0 Then cboSelectCar(Index).ListIndex = GarageListMatrix(Index, iNewCarID)
End Sub

Private Sub cmdClearMods_Click(Index As Integer)
On Error Resume Next
    isResetMods(Index) = True
    CopyMemory tNowParking.ParkingSlots(Index).intTuneArr(0), zeroTuneInt(0), 30&
    '&HFF 02 00 00
    '   3  2  1  0
    tNowParking.ParkingSlots(Index).bytTuneArr(0) = &H0 'keep zero.this is actually for stripe type. &H78 used for camper, &H3E used for cement truck etc.
    tNowParking.ParkingSlots(Index).bytTuneArr(1) = &H0 'keep zero
    tNowParking.ParkingSlots(Index).bytTuneArr(2) = &H2 'not really known yet
    tNowParking.ParkingSlots(Index).bytTuneArr(3) = 0 '&HFF (extras1. if no extras, ignored by game)
    '&H00 FF 00 FF
    '   7  6  5  4
    tNowParking.ParkingSlots(Index).bytTuneArr(4) = &HFE 'FF/0/1/2/3/4 Exhaust, body parts for bikes, etc. (keep &HFE, so that all bits are checked)
    tNowParking.ParkingSlots(Index).bytTuneArr(5) = &H0  '0, related with paint job
    tNowParking.ParkingSlots(Index).bytTuneArr(6) = &HFF 'paint job ordinal. FF/0/1/2/3
    tNowParking.ParkingSlots(Index).bytTuneArr(7) = &H0  'not known yet
    lblModStatus(Index).Caption = "Not Modded"
End Sub

Private Sub cmdEditMods_Click(Index As Integer)
On Error GoTo errEditMods
    Dim iModCtr As Integer
    Load frmMods
    If frmMods.DecodeMods(ParkedCarMatrix(Index, cboSelectCar(Index).ListIndex), _
                         tNowParking.ParkingSlots(Index).intTuneArr(), _
                         ParkedCars(ParkedCarMatrix(Index, cboSelectCar(Index).ListIndex)).sModsArr, _
                         tNowParking.ParkingSlots(Index).bytTuneArr(6)) Then
        frmMods.Show vbModal, UserControl.Parent
        DoEvents
        If frmMods.isOKClicked Then
            If frmMods.EncodeMods(tNowParking.ParkingSlots(Index).intTuneArr(), tNowParking.ParkingSlots(Index).bytTuneArr(6)) Then
                'check if is modded or not:
                isResetMods(Index) = True
                For iModCtr = 0 To 7
                    If tNowParking.ParkingSlots(Index).intTuneArr(iModCtr) <> -1 Or _
                       tNowParking.ParkingSlots(Index).intTuneArr(iModCtr + 7) <> -1 Then
                        isResetMods(Index) = False
                    End If
                Next iModCtr
                If tNowParking.ParkingSlots(Index).bytTuneArr(6) <> &HFF Then isResetMods(Index) = False
                If isResetMods(Index) Then
                   lblModStatus(Index).Caption = "Not Modded"
                Else
                   lblModStatus(Index).Caption = "Modded"
                End If
                isDirty = True
            Else
                MsgBox "Your Mod Selection could not be encoded." & vbCrLf & "Please read online garage again", vbInformation
            End If
        End If
    Else
        MsgBox "Current Mods could not be initialised." & vbCrLf & "Please read online garage again", vbInformation
    End If
CleanExitSub:
On Error Resume Next
    Unload frmMods
Exit Sub
errEditMods:
    MsgBox Err.Description, vbCritical, "Error on ModEdit"
    Err.Clear
End Sub

'*****************************************************************************************************
'                                    Car Colors:
'*****************************************************************************************************
Private Sub picMajor_DblClick(Index As Integer)
On Error Resume Next
    If Len(picMajor(Index).Tag) = 0 Then picMajor(Index).Tag = "0"
    Set fPick = New frmPickColor
    Load fPick
    iPickedColor = CInt(picMajor(Index).Tag)
    fPick.SetPickColor iPickedColor
    fPick.Show vbModal, UserControl.Parent
    DoEvents
    iPickedColor = fPick.iPickColor
    Unload fPick
    Set fPick = Nothing
    If iPickedColor <> CInt(picMajor(Index).Tag) Then
        picMajor(Index).Tag = iPickedColor
        picMajor(Index).BackColor = GTASAColors(iPickedColor).lngRGB
        isDirty = True
        RaiseEvent CarColorChanged(Index, iPickedColor, True)
    End If
End Sub
Private Sub picMinor_DblClick(Index As Integer)
On Error Resume Next
    If Len(picMinor(Index).Tag) = 0 Then picMinor(Index).Tag = "0"
    Set fPick = New frmPickColor
    Load fPick
    iPickedColor = CInt(picMinor(Index).Tag)
    fPick.SetPickColor iPickedColor
    fPick.Show vbModal, UserControl.Parent
    DoEvents
    iPickedColor = fPick.iPickColor
    Unload fPick
    Set fPick = Nothing
    If iPickedColor <> CInt(picMinor(Index).Tag) Then
        picMinor(Index).Tag = iPickedColor
        picMinor(Index).BackColor = GTASAColors(iPickedColor).lngRGB
        isDirty = True
        RaiseEvent CarColorChanged(Index, iPickedColor, True)
    End If
End Sub
'*****************************************************************************************************
'                                    Car ID:
'*****************************************************************************************************
Public Sub AddCar(ByVal sCarName As String)
On Error Resume Next
    cboSelectCar(0).AddItem sCarName
    cboSelectCar(1).AddItem sCarName
    cboSelectCar(2).AddItem sCarName
    cboSelectCar(3).AddItem sCarName
End Sub
Public Property Get CarID(ByVal iCarIdx As Integer) As Integer
    CarID = cboSelectCar(iCarIdx).ListIndex
End Property
Public Property Let CarID(ByVal iCarIdx As Integer, ByVal iNewID As Integer)
    cboSelectCar(iCarIdx).ListIndex = iNewID
End Property
Private Sub cboSelectCar_Click(Index As Integer)
    If Not isInit Then SetVisibility
    If cboSelectCar(Index).ListIndex < 0 Then Exit Sub 'combo box bug
    If Not isInit Then
        If cboSelectCar(Index).ListIndex = 0 Then 'no car
            picMajor(Index).Tag = 0
            picMajor(Index).BackColor = GTASAColors(0).lngRGB
            picMinor(Index).Tag = 0
            picMinor(Index).BackColor = GTASAColors(0).lngRGB
            cmdEditMods(Index).Enabled = False
        Else
            'set colors from cfg
            picMajor(Index).Tag = CInt(ParkedCars(ParkedCarMatrix(Index, cboSelectCar(Index).ListIndex)).MajorColor)
            picMajor(Index).BackColor = GTASAColors(CInt(picMajor(Index).Tag)).lngRGB
            picMinor(Index).Tag = CInt(ParkedCars(ParkedCarMatrix(Index, cboSelectCar(Index).ListIndex)).MinorColor)
            picMinor(Index).BackColor = GTASAColors(CInt(picMinor(Index).Tag)).lngRGB
            cmdEditMods(Index).Enabled = ParkedCars(ParkedCarMatrix(Index, cboSelectCar(Index).ListIndex)).isHasMods
        End If
        isDirty = True
        isReparkNeeded = True
        isResetMods(Index) = True
        lblModStatus(Index).Caption = "Not Modded"
        SetVisibility
        RaiseEvent CarIDChanged(Index, cboSelectCar(Index).ListIndex)
    End If
End Sub
'*****************************************************************************************************
'                                    Initialisation:
'*****************************************************************************************************
Public Function SetIniVals(ByVal iCarIdx As Integer, ByVal sINISetting As String) As Boolean
On Error GoTo errSetIniVals
    Dim sTokens() As String
    Dim iModCtr As Integer
    isInit = True
    SetIniVals = False
    sTokens = Split(sINISetting, ",")
    '"0,1,1,1,1,1,0,0"
    If chkLockGarage.Value = vbUnchecked Then chkLockGarage.Value = CInt(sTokens(0))
    If CInt(sTokens(1)) < 400 Then
        cboSelectCar(iCarIdx).ListIndex = 0
    Else
        cboSelectCar(iCarIdx).ListIndex = GarageListMatrix(iCarIdx, CInt(sTokens(1)))
    End If
    chkEP(iCarIdx).Value = CInt(sTokens(2))
    chkDP(iCarIdx).Value = CInt(sTokens(3))
    chkBP(iCarIdx).Value = CInt(sTokens(4))
    chkFP(iCarIdx).Value = CInt(sTokens(5))
    picMajor(iCarIdx).BackColor = GTASAColors(CInt(sTokens(6))).lngRGB
    picMajor(iCarIdx).Tag = CInt(sTokens(6))
    picMinor(iCarIdx).BackColor = GTASAColors(CInt(sTokens(7))).lngRGB
    picMinor(iCarIdx).Tag = CInt(sTokens(7))
    If UBound(sTokens) > 30 Then
        With tNowParking.ParkingSlots(iCarIdx)
            .lngAngle = CLng("&H" & sTokens(8))
            .intTuneArr(0) = CInt("&H" & sTokens(9))
            .intTuneArr(1) = CInt("&H" & sTokens(10))
            .intTuneArr(2) = CInt("&H" & sTokens(11))
            .intTuneArr(3) = CInt("&H" & sTokens(12))
            .intTuneArr(4) = CInt("&H" & sTokens(13))
            .intTuneArr(5) = CInt("&H" & sTokens(14))
            .intTuneArr(6) = CInt("&H" & sTokens(15))
            .intTuneArr(7) = CInt("&H" & sTokens(16))
            .intTuneArr(8) = CInt("&H" & sTokens(17))
            .intTuneArr(9) = CInt("&H" & sTokens(18))
            .intTuneArr(10) = CInt("&H" & sTokens(19))
            .intTuneArr(11) = CInt("&H" & sTokens(20))
            .intTuneArr(12) = CInt("&H" & sTokens(21))
            .intTuneArr(13) = CInt("&H" & sTokens(22))
            .intTuneArr(14) = CInt("&H" & sTokens(23))
            .bytTuneArr(0) = CByte("&H" & sTokens(24))
            .bytTuneArr(1) = CByte("&H" & sTokens(25))
            .bytTuneArr(2) = CByte("&H" & sTokens(26))
            .bytTuneArr(3) = CByte("&H" & sTokens(27))
            .bytTuneArr(4) = CByte("&H" & sTokens(28))
            .bytTuneArr(5) = CByte("&H" & sTokens(29))
            .bytTuneArr(6) = CByte("&H" & sTokens(30))
            .bytTuneArr(7) = CByte("&H" & sTokens(31))
            isResetMods(iCarIdx) = True
            For iModCtr = 0 To 7
                If .intTuneArr(iModCtr) <> -1 Or _
                   .intTuneArr(iModCtr + 7) <> -1 Then
                    isResetMods(iCarIdx) = False
                End If
            Next iModCtr
            If .bytTuneArr(6) <> &HFF Then isResetMods(iCarIdx) = False
            If isResetMods(iCarIdx) Then
               lblModStatus(iCarIdx).Caption = "Not Modded"
            Else
               lblModStatus(iCarIdx).Caption = "Modded"
            End If
        End With
    Else
        isResetMods(iCarIdx) = True
        lblModStatus(iCarIdx).Caption = "Not Modded"
    End If
    'also populate as now parking (these are the values shown in the ocx)
    With tNowParking.ParkingSlots(iCarIdx)
        .intCarCode = ParkedCarMatrix(iCarIdx, cboSelectCar(iCarIdx).ListIndex)
        .intSpecials = (chkDP(iCarIdx).Value * 8) + (chkEP(iCarIdx).Value * 4) + (chkFP(iCarIdx).Value * 2) + chkBP(iCarIdx).Value
        .bytMajorColor = CByte(picMajor(iCarIdx).Tag)
        .bytMinorColor = CByte(picMinor(iCarIdx).Tag)
    End With
    CopyMemory tLastParking, tNowParking, Len(tNowParking)
    isInit = False
    isReparkNeeded = True
    isDirty = False
    SetVisibility
    SetIniVals = True
Exit Function
errSetIniVals:
    isInit = False
    Err.Clear
End Function
Public Function GetIniVals(ByVal iCarIdx As Integer) As String
On Error GoTo errGetIniValues
    Dim iModCtr As Integer
    GetIniVals = chkLockGarage.Value & "," & ParkedCarMatrix(iCarIdx, cboSelectCar(iCarIdx).ListIndex) & "," & _
            chkEP(iCarIdx).Value & "," & chkDP(iCarIdx).Value & "," & chkBP(iCarIdx).Value & "," & _
            chkFP(iCarIdx).Value & "," & picMajor(iCarIdx).Tag & "," & picMinor(iCarIdx).Tag
    With tNowParking.ParkingSlots(iCarIdx)
        GetIniVals = GetIniVals & "," & UCase(Hex(.lngAngle))
        For iModCtr = 0 To 14
            GetIniVals = GetIniVals & "," & UCase(Hex(.intTuneArr(iModCtr)))
        Next iModCtr
        For iModCtr = 0 To 7
            GetIniVals = GetIniVals & "," & UCase(Hex(.bytTuneArr(iModCtr)))
        Next iModCtr
    End With
Exit Function
errGetIniValues:
    GetIniVals = "0,1,1,1,1,1,0,0"
End Function
Public Function GetFullGarageValuesToByteArray(ByRef bParking() As Byte) As Boolean
'helper function
    CopyMemory bParking(0), tNowParking, Len(tNowParking)
End Function
Public Function SetValuesFromOnlineGarageByteArray(ByRef bParking() As Byte) As Boolean
On Error Resume Next
    Static iModCtr As Integer
    'copy nowparking to lastparking to compare later:
    CopyMemory tLastParking, tNowParking, Len(tNowParking)
    'get the full garage block from parent form and assign to now parking:
    CopyMemory tNowParking, bParking(0), Len(tNowParking)
    'garage is not locked (otherwise cursor does not come here), show current values:
    isInit = True
    For iCarCtr = 0 To 3
        If tNowParking.ParkingSlots(iCarCtr).intCarCode = 0 Then
            cboSelectCar(iCarCtr).ListIndex = 0
        Else
            cboSelectCar(iCarCtr).ListIndex = GarageListMatrix(iCarCtr, tNowParking.ParkingSlots(iCarCtr).intCarCode)
        End If
        '8:DP/4:EP/2:FP/1:BP
        chkDP(iCarCtr).Value = Abs(CInt(CInt((tNowParking.ParkingSlots(iCarCtr).intSpecials And 8)) = 8))
        chkEP(iCarCtr).Value = Abs(CInt(CInt((tNowParking.ParkingSlots(iCarCtr).intSpecials And 4)) = 4))
        chkFP(iCarCtr).Value = Abs(CInt(CInt((tNowParking.ParkingSlots(iCarCtr).intSpecials And 2)) = 2))
        chkBP(iCarCtr).Value = Abs(CInt(CInt((tNowParking.ParkingSlots(iCarCtr).intSpecials And 1)) = 1))
        picMajor(iCarCtr).Tag = tNowParking.ParkingSlots(iCarCtr).bytMajorColor
        picMajor(iCarCtr).BackColor = GTASAColors(tNowParking.ParkingSlots(iCarCtr).bytMajorColor).lngRGB
        picMinor(iCarCtr).Tag = tNowParking.ParkingSlots(iCarCtr).bytMinorColor
        picMinor(iCarCtr).BackColor = GTASAColors(tNowParking.ParkingSlots(iCarCtr).bytMinorColor).lngRGB
        'check the modifications:
        isResetMods(iCarCtr) = True
        For iModCtr = 0 To 7
            If tNowParking.ParkingSlots(iCarCtr).intTuneArr(iModCtr) <> -1 Or _
               tNowParking.ParkingSlots(iCarCtr).intTuneArr(iModCtr + 7) <> -1 Then
                isResetMods(iCarCtr) = False
            End If
        Next iModCtr
        If tNowParking.ParkingSlots(iCarCtr).bytTuneArr(6) <> &HFF Then isResetMods(iCarCtr) = False
        If isResetMods(iCarCtr) Then
           lblModStatus(iCarCtr).Caption = "Not Modded"
        Else
           lblModStatus(iCarCtr).Caption = "Modded"
        End If
    Next iCarCtr
    isInit = False
    SetVisibility
    isReparkNeeded = False
    isDirty = False
End Function

Public Function UpdateValuesOfGarageStructByteArray(ByRef bParking() As Byte) As Boolean
On Error GoTo errUpdateValuesOfGarageStructByteArray
    Static iModCtr As Integer
    'get the full garage block from parent form and assign to now parking:
    CopyMemory tTempGarage, bParking(0), Len(tTempGarage)
    For iCarCtr = 0 To 3
        With tTempGarage.ParkingSlots(iCarCtr)
            .intCarCode = ParkedCarMatrix(iCarCtr, cboSelectCar(iCarCtr).ListIndex)
            If ParkedCarMatrix(iCarCtr, cboSelectCar(iCarCtr).ListIndex) = 0 Then
                .lngHandling = 0
            Else
                .lngHandling = ParkedCars(ParkedCarMatrix(iCarCtr, cboSelectCar(iCarCtr).ListIndex)).iHandling
            End If
            .intSpecials = (chkDP(iCarCtr).Value * 8) + (chkEP(iCarCtr).Value * 4) + (chkFP(iCarCtr).Value * 2) + chkBP(iCarCtr).Value
            .bytMajorColor = CByte(picMajor(iCarCtr).Tag)
            .bytMinorColor = CByte(picMinor(iCarCtr).Tag)
            'modifications come here...
            If (.lngAngle = 0) Or isResetMods(iCarCtr) Then
                'there has been no cars here, or we need to reset the modifications:
                For iModCtr = 0 To 7
                   .intTuneArr(iModCtr) = -1
                   .intTuneArr(iModCtr + 7) = -1
                Next iModCtr
                '&HFF 02 00 00
                '   3  2  1  0
                .bytTuneArr(0) = &H0 'keep zero.this is actually for stripe type. &H78 used for camper, &H3E used for cement truck etc.
                .bytTuneArr(1) = &H0 'keep zero
                .bytTuneArr(2) = &H2 'not really known yet
                .bytTuneArr(3) = 0 '&HFF (extras1. if no extras, ignored by game)
                '&H00 FF 00 FF
                '   7  6  5  4
                .bytTuneArr(4) = &HFE 'FF/0/1/2/3/4 Exhaust, body parts for bikes, etc. (keep &HFE, so that all bits are checked)
                .bytTuneArr(5) = &H0  '0, related with paint job
                .bytTuneArr(6) = &HFF 'paint job ordinal. FF/0/1/2/3
                .bytTuneArr(7) = &H0  'Extras.
            Else
                'set selected mods to online:
                For iModCtr = 0 To 7
                   .intTuneArr(iModCtr) = tNowParking.ParkingSlots(iCarCtr).intTuneArr(iModCtr)
                   .intTuneArr(iModCtr + 7) = tNowParking.ParkingSlots(iCarCtr).intTuneArr(iModCtr + 7)
                   .bytTuneArr(iModCtr) = tNowParking.ParkingSlots(iCarCtr).bytTuneArr(iModCtr)
                Next iModCtr
'                If .intCarCode = 522 Then
'                    lng Was 2 = &H50000 'special case
'                    lng Was 3 = &HFF0004
'                End If
            End If
            'plausibility check comes here:
            If .lngAngle = 0 Then .lngAngle = &HFF9D00 'there has been no cars here.
        End With
    Next iCarCtr
    'get the full garage block from parent form and assign to now parking:
    CopyMemory bParking(0), tTempGarage, Len(tTempGarage)
    UpdateValuesOfGarageStructByteArray = True
Exit Function
errUpdateValuesOfGarageStructByteArray:
    Err.Clear
End Function

Private Sub SetVisibility()
    Static isPreInit As Boolean
    Static iCtr As Integer
    isPreInit = isInit
    isInit = True
    'set visibility of all controls according to selected combo's:
    If cboSelectCar(0).ListIndex < 1 Then
        'disable all
        For iCtr = 0 To 3
            If iCtr < 1 Then 'special case for select car combo
                cboSelectCar(iCtr).Visible = True
                cmdCarPics(iCtr).Visible = True
            Else
                cmdCarPics(iCtr).Visible = False
                cboSelectCar(iCtr).Visible = False
                cboSelectCar(iCtr).ListIndex = 0
            End If
            chkEP(iCtr).Visible = False
            chkBP(iCtr).Visible = False
            chkDP(iCtr).Visible = False
            chkFP(iCtr).Visible = False
            picMajor(iCtr).Visible = False
            picMinor(iCtr).Visible = False
            lblModNA(iCtr).Visible = False
            lblModStatus(iCtr).Visible = False
            cmdClearMods(iCtr).Visible = False
            cmdEditMods(iCtr).Visible = False
        Next iCtr
    ElseIf cboSelectCar(1).ListIndex < 1 Then
        'disable all but index 0
        For iCtr = 0 To 3
            If iCtr < 2 Then 'special case for select car combo
                cboSelectCar(iCtr).Visible = True
                cmdCarPics(iCtr).Visible = True
            Else
                cmdCarPics(iCtr).Visible = False
                cboSelectCar(iCtr).Visible = False
                cboSelectCar(iCtr).ListIndex = 0
            End If
            chkEP(iCtr).Visible = (iCtr < 1)
            chkBP(iCtr).Visible = (iCtr < 1)
            chkDP(iCtr).Visible = (iCtr < 1)
            chkFP(iCtr).Visible = (iCtr < 1)
            picMajor(iCtr).Visible = (iCtr < 1)
            picMinor(iCtr).Visible = (iCtr < 1)
            If (iCtr < 1) And (cboSelectCar(iCtr).ListIndex > 0) Then
                cmdEditMods(iCtr).Enabled = ParkedCars(ParkedCarMatrix(iCtr, cboSelectCar(iCtr).ListIndex)).isHasMods
            Else
                cmdEditMods(iCtr).Enabled = False
            End If
            If cmdEditMods(iCtr).Enabled Then
                lblModNA(iCtr).Visible = False
                lblModStatus(iCtr).Visible = (iCtr < 1)
                cmdClearMods(iCtr).Visible = (iCtr < 1)
                cmdEditMods(iCtr).Visible = (iCtr < 1)
            Else
                lblModNA(iCtr).Visible = (iCtr < 1)
                lblModStatus(iCtr).Visible = False
                cmdClearMods(iCtr).Visible = False
                cmdEditMods(iCtr).Visible = False
            End If
        Next iCtr
    ElseIf cboSelectCar(2).ListIndex < 1 Then
        'disable all but index 0 and 1
        For iCtr = 0 To 3
            If iCtr < 3 Then 'special case for select car combo
                cboSelectCar(iCtr).Visible = True
                cmdCarPics(iCtr).Visible = True
            Else
                cmdCarPics(iCtr).Visible = False
                cboSelectCar(iCtr).Visible = False
                cboSelectCar(iCtr).ListIndex = 0
            End If
            chkEP(iCtr).Visible = (iCtr < 2)
            chkBP(iCtr).Visible = (iCtr < 2)
            chkDP(iCtr).Visible = (iCtr < 2)
            chkFP(iCtr).Visible = (iCtr < 2)
            picMajor(iCtr).Visible = (iCtr < 2)
            picMinor(iCtr).Visible = (iCtr < 2)
            If (iCtr < 2) And (cboSelectCar(iCtr).ListIndex > 0) Then
                cmdEditMods(iCtr).Enabled = ParkedCars(ParkedCarMatrix(iCtr, cboSelectCar(iCtr).ListIndex)).isHasMods
            Else
                cmdEditMods(iCtr).Enabled = False
            End If
            If cmdEditMods(iCtr).Enabled Then
                lblModNA(iCtr).Visible = False
                lblModStatus(iCtr).Visible = (iCtr < 2)
                cmdClearMods(iCtr).Visible = (iCtr < 2)
                cmdEditMods(iCtr).Visible = (iCtr < 2)
            Else
                lblModNA(iCtr).Visible = (iCtr < 2)
                lblModStatus(iCtr).Visible = False
                cmdClearMods(iCtr).Visible = False
                cmdEditMods(iCtr).Visible = False
            End If
        Next iCtr
    ElseIf cboSelectCar(3).ListIndex < 1 Then
        'disable all but index 0 and 1 and 2
        For iCtr = 0 To 3
            'special case for select car combo:
            cboSelectCar(iCtr).Visible = True
            cmdCarPics(iCtr).Visible = True
            chkEP(iCtr).Visible = (iCtr < 3)
            chkBP(iCtr).Visible = (iCtr < 3)
            chkDP(iCtr).Visible = (iCtr < 3)
            chkFP(iCtr).Visible = (iCtr < 3)
            picMajor(iCtr).Visible = (iCtr < 3)
            picMinor(iCtr).Visible = (iCtr < 3)
            If (iCtr < 3) And (cboSelectCar(iCtr).ListIndex > 0) Then
                cmdEditMods(iCtr).Enabled = ParkedCars(ParkedCarMatrix(iCtr, cboSelectCar(iCtr).ListIndex)).isHasMods
            Else
                cmdEditMods(iCtr).Enabled = False
            End If
            If cmdEditMods(iCtr).Enabled Then
                lblModNA(iCtr).Visible = False
                lblModStatus(iCtr).Visible = (iCtr < 3)
                cmdClearMods(iCtr).Visible = (iCtr < 3)
                cmdEditMods(iCtr).Visible = (iCtr < 3)
            Else
                lblModNA(iCtr).Visible = (iCtr < 3)
                lblModStatus(iCtr).Visible = False
                cmdClearMods(iCtr).Visible = False
                cmdEditMods(iCtr).Visible = False
            End If
        Next iCtr
    Else
        'enable all:
        For iCtr = 0 To 3
            'special case for select car combo:
            cboSelectCar(iCtr).Visible = True
            cmdCarPics(iCtr).Visible = True
            chkEP(iCtr).Visible = True
            chkBP(iCtr).Visible = True
            chkDP(iCtr).Visible = True
            chkFP(iCtr).Visible = True
            picMajor(iCtr).Visible = True
            picMinor(iCtr).Visible = True
            If cboSelectCar(iCtr).ListIndex > 0 Then
                cmdEditMods(iCtr).Enabled = ParkedCars(ParkedCarMatrix(iCtr, cboSelectCar(iCtr).ListIndex)).isHasMods
            Else
                cmdEditMods(iCtr).Enabled = False
            End If
            lblModNA(iCtr).Visible = Not cmdEditMods(iCtr).Enabled
            lblModStatus(iCtr).Visible = cmdEditMods(iCtr).Enabled
            cmdClearMods(iCtr).Visible = cmdEditMods(iCtr).Enabled
            cmdEditMods(iCtr).Visible = cmdEditMods(iCtr).Enabled
        Next iCtr
    End If
    isInit = isPreInit
End Sub

'WARNING! DO NOT REMOVE OR MODIFY THE FOLLOWING COMMENTED LINES!
'MappingInfo=chkLockGarage,chkLockGarage,-1,Caption
Public Property Get GarageName() As String
Attribute GarageName.VB_Description = "Returns/sets the text displayed in an object's title bar or below an object's icon."
    GarageName = chkLockGarage.Caption
End Property

Public Property Let GarageName(ByVal New_GarageName As String)
    chkLockGarage.Caption() = New_GarageName
    PropertyChanged "GarageName"
End Property

Private Sub UserControl_Initialize()
On Error Resume Next
    Dim iModCtr As Integer
    'initialise to zeroed parking structures:
    For iCarCtr = 0 To 3
        With tLastParking.ParkingSlots(iCarCtr)
            .sngXcoord = 0
            .sngYcoord = 0
            .sngZcoord = 0
            .lngHandling = 0
            .intSpecials = 0
            .intCarCode = 0
            For iModCtr = 0 To 7
                .intTuneArr(iModCtr) = -1
                .intTuneArr(iModCtr + 7) = -1
            Next iModCtr
            .bytMajorColor = 1 'white
            .bytMinorColor = 1
            '&HFF 02 00 00
            '   3  2  1  0
            .bytTuneArr(0) = &H0 'keep zero.this is actually for stripe type. &H78 used for camper, &H3E used for cement truck etc.
            .bytTuneArr(1) = &H0 'keep zero
            .bytTuneArr(2) = &H2 'not really known yet
            .bytTuneArr(3) = 0 '&HFF (extras1. if no extras, ignored by game)
            '&H00 FF 00 FF
            '   7  6  5  4
            .bytTuneArr(4) = &HFE 'FF/0/1/2/3/4 Exhaust, body parts for bikes, etc. (keep &HFE, so that all bits are checked)
            .bytTuneArr(5) = &H0  '0, related with paint job
            .bytTuneArr(6) = &HFF 'paint job ordinal. FF/0/1/2/3
            .bytTuneArr(7) = &H0  'not known yet
            .lngAngle = &HFF6300
        End With
    Next iCarCtr
    'copy this zero structure to other private structures:
    CopyMemory tNowParking, tLastParking, Len(tLastParking)
    CopyMemory tOnlineGarage, tLastParking, Len(tLastParking)
    CopyMemory tTempGarage, tLastParking, Len(tLastParking)
End Sub

'Load property values from storage
Private Sub UserControl_ReadProperties(PropBag As PropertyBag)
    chkLockGarage.Caption = PropBag.ReadProperty("GarageName", "Garage Caption:")
End Sub

'Write property values to storage
Private Sub UserControl_WriteProperties(PropBag As PropertyBag)
    Call PropBag.WriteProperty("GarageName", chkLockGarage.Caption, "Garage Caption:")
End Sub
