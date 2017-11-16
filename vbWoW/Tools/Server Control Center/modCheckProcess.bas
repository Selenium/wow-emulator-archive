Attribute VB_Name = "modCheckProcess"
'
' Copyright (C) 2005-2007 vbWoW <http://www.vbwow.org/>
'
' This program is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 2 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program; if not, write to the Free Software
' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
'

Public Declare Function GetProcessMemoryInfo Lib "psapi.dll" (ByVal hProcess As Long, ppsmemCounters As PROCESS_MEMORY_COUNTERS, ByVal cb As Long) As Long
Public Declare Function Process32First Lib "kernel32" (ByVal hSnapshot As Long, lppe As PROCESSENTRY32) As Long
Public Declare Function Process32Next Lib "kernel32" (ByVal hSnapshot As Long, lppe As PROCESSENTRY32) As Long
Public Declare Function CloseHandle Lib "Kernel32.dll" (ByVal Handle As Long) As Long
Public Declare Function OpenProcess Lib "Kernel32.dll" (ByVal dwDesiredAccessas As Long, ByVal bInheritHandle As Long, ByVal dwProcId As Long) As Long
Public Declare Function EnumProcesses Lib "psapi.dll" (ByRef lpidProcess As Long, ByVal cb As Long, ByRef cbNeeded As Long) As Long
Public Declare Function GetModuleFileNameExA Lib "psapi.dll" (ByVal hProcess As Long, ByVal hModule As Long, ByVal ModuleName As String, ByVal nSize As Long) As Long
Public Declare Function EnumProcessModules Lib "psapi.dll" (ByVal hProcess As Long, ByRef lphModule As Long, ByVal cb As Long, ByRef cbNeeded As Long) As Long
Public Declare Function CreateToolhelp32Snapshot Lib "kernel32" (ByVal dwflags As Long, ByVal th32ProcessID As Long) As Long
Public Declare Function GetVersionExA Lib "kernel32" (lpVersionInformation As OSVERSIONINFO) As Integer
Public Declare Function SetTimer Lib "user32" (ByVal hwnd As Long, ByVal nIDEvent As Long, ByVal uElapse As Long, ByVal lpTimerFunc As Long) As Long
Public Declare Function KillTimer Lib "user32" (ByVal hwnd As Long, ByVal nIDEvent As Long) As Long
Public Declare Sub GlobalMemoryStatus Lib "kernel32" (lpBuffer As MEMORYSTATUS)



Public Const PROCESS_QUERY_INFORMATION = 1024
Public Const PROCESS_VM_READ = 16
Public Const MAX_PATH = 260
Public Const STANDARD_RIGHTS_REQUIRED = &HF0000
Public Const SYNCHRONIZE = &H100000
Public Const PROCESS_ALL_ACCESS = &H1F0FFF
Public Const TH32CS_SNAPPROCESS = &H2&
Public Const hNull = 0
Public Const WIN95_System_Found = 1
Public Const WINNT_System_Found = 2
Public Const Default_Log_Size = 10000000
Public Const Default_Log_Days = 0
Public Const SPECIFIC_RIGHTS_ALL = &HFFFF
Public Const STANDARD_RIGHTS_ALL = &H1F0000


Type MEMORYSTATUS
   dwLength As Long
   dwMemoryLoad As Long
   dwTotalPhys As Long
   dwAvailPhys As Long
   dwTotalPageFile As Long
   dwAvailPageFile As Long
   dwTotalVirtual As Long
   dwAvailVirtual As Long
End Type


Type PROCESS_MEMORY_COUNTERS
   cb As Long
   PageFaultCount As Long
   PeakWorkingSetSize As Long
   WorkingSetSize As Long
   QuotaPeakPagedPoolUsage As Long
   QuotaPagedPoolUsage As Long
   QuotaPeakNonPagedPoolUsage As Long
   QuotaNonPagedPoolUsage As Long
   PagefileUsage As Long
   PeakPagefileUsage As Long
End Type


Public Type PROCESSENTRY32
   dwSize As Long
   cntUsage As Long
   th32ProcessID As Long ' This process
   th32DefaultHeapID As Long
   th32ModuleID As Long ' Associated exe
   cntThreads As Long
   th32ParentProcessID As Long ' This process's parent process
   pcPriClassBase As Long ' Base priority of process threads
   dwflags As Long
   szExeFile As String * 260 ' MAX_PATH
   End Type


Public Type OSVERSIONINFO
   dwOSVersionInfoSize As Long
   dwMajorVersion As Long
   dwMinorVersion As Long
   dwBuildNumber As Long
   dwPlatformId As Long '1 = Windows 95.
   '2 = Windows NT
   szCSDVersion As String * 128
End Type

Public Function GetProcesses(ByVal EXEName As String) As Boolean

   Dim booResult As Boolean
   Dim lngLength As Long
   Dim lngProcessID As Long
   Dim strProcessName As String
   Dim lngSnapHwnd As Long
   Dim udtProcEntry As PROCESSENTRY32
   Dim lngCBSize As Long 'Specifies the size, In bytes, of the lpidProcess array
   Dim lngCBSizeReturned As Long 'Receives the number of bytes returned
   Dim lngNumElements As Long
   Dim lngProcessIDs() As Long
   Dim lngCBSize2 As Long
   Dim lngModules(1 To 200) As Long
   Dim lngReturn As Long
   Dim strModuleName As String
   Dim lngSize As Long
   Dim lngHwndProcess As Long
   Dim lngLoop As Long
   Dim b As Long
   Dim c As Long
   Dim e As Long
   Dim d As Long
   Dim pmc As PROCESS_MEMORY_COUNTERS
   Dim lRet As Long
   Dim strProcName2 As String
   Dim strProcName As String
   Dim MyPos_Instr As Integer

   'Turn on Error handler
   On Error GoTo Error_handler

   booResult = False
       
   GetProcesses = False

   EXEName = UCase$(Trim$(EXEName))
   lngLength = Len(EXEName)

   'ProcessInfo.bolRunning = False

'    Select Case getVersion()
'        'I'm not bothered about windows 95/98 becasue this class probably wont be used on it anyway.
'        Case WIN95_System_Found 'Windows 95/98
'
'        Case WINNT_System_Found 'Windows NT

   lngCBSize = 8 ' Really needs To be 16, but Loop will increment prior to calling API
   lngCBSizeReturned = 96
   
   Do While lngCBSize <= lngCBSizeReturned
       DoEvents
       'Increment Size
       lngCBSize = lngCBSize * 2
       'Allocate Memory for Array
       ReDim lngProcessIDs(lngCBSize / 4) As Long
       'Get Process ID's
       lngReturn = EnumProcesses(lngProcessIDs(1), lngCBSize, lngCBSizeReturned)
   Loop

   'Count number of processes returned
   lngNumElements = lngCBSizeReturned / 4
   'Loop thru each process

   For lngLoop = 1 To lngNumElements
       DoEvents
   
       'Get a handle to the Process and Open
       lngHwndProcess = OpenProcess(PROCESS_QUERY_INFORMATION Or PROCESS_VM_READ, 0, lngProcessIDs(lngLoop))
   
       If lngHwndProcess <> 0 Then
           'Get an array of the module handles for the specified process
           lngReturn = EnumProcessModules(lngHwndProcess, lngModules(1), 200, lngCBSize2)
   
           'If the Module Array is retrieved, Get the ModuleFileName
           If lngReturn <> 0 Then
   
               'Buffer with spaces first to allocate memory for byte array
               strModuleName = Space(MAX_PATH)
   
               'Must be set prior to calling API
               lngSize = 500
   
               'Get Process Name
               lngReturn = GetModuleFileNameExA(lngHwndProcess, lngModules(1), strModuleName, lngSize)
   
               'Remove trailing spaces
               strProcessName = Left(strModuleName, lngReturn)
   
               'Check for Matching Upper case result
               strProcessName = UCase$(Trim$(strProcessName))
   
               strProcName2 = GetElement(Trim(Replace(strProcessName, Chr$(0), "")), "\", 0, 0, GetNumElements(Trim(Replace(strProcessName, Chr$(0), "")), "\") - 1)
               
               If strProcName2 = EXEName Then
                   'Get the Site of the Memory Structure
                   'pmc.cb = LenB(pmc)
                   'lret = GetProcessMemoryInfo(lngHwndProcess, pmc, pmc.cb)
                   'Debug.Print EXEName & "::" & CStr(pmc.WorkingSetSize / 1024)
                   'MsgBox EXEName & "::" & CStr(pmc.WorkingSetSize / 1024)
                   GetProcesses = True
               End If
           End If
       End If
       'Close the handle to this process
       lngReturn = CloseHandle(lngHwndProcess)
       DoEvents
   Next
   
'    End Select

IsProcessRunning_Exit:

'Exit early to avoid error handler
Exit Function
Error_handler:
   Err.Raise Err, Err.Source, "ProcessInfo", Error
   Resume Next
End Function


Private Function getVersion() As Long

   Dim osinfo As OSVERSIONINFO
   Dim retvalue As Integer

   osinfo.dwOSVersionInfoSize = 148
   osinfo.szCSDVersion = Space$(128)
   retvalue = GetVersionExA(osinfo)
   getVersion = osinfo.dwPlatformId

End Function


Private Function StrZToStr(s As String) As String
   StrZToStr = Left$(s, Len(s) - 1)
End Function



Public Function GetElement(ByVal strList As String, ByVal strDelimiter As String, ByVal lngNumColumns As Long, ByVal lngRow As Long, ByVal lngColumn As Long) As String

   Dim lngCounter As Long

   ' Append delimiter text to the end of the list as a terminator.
   strList = strList & strDelimiter

   ' Calculate the offset for the item required based on the number of columns the list
   ' 'strList' has i.e. 'lngNumColumns' and from which row the element is to be
   ' selected i.e. 'lngRow'.
   lngColumn = IIf(lngRow = 0, lngColumn, (lngRow * lngNumColumns) + lngColumn)

   ' Search for the 'lngColumn' item from the list 'strList'.
   For lngCounter = 0 To lngColumn - 1

       ' Remove each item from the list.
       strList = Mid$(strList, InStr(strList, strDelimiter) + Len(strDelimiter), Len(strList))

       ' If list becomes empty before 'lngColumn' is found then just
       ' return an empty string.
       If Len(strList) = 0 Then
           GetElement = ""
           Exit Function
       End If

   Next lngCounter

   ' Return the sought list element.
   GetElement = Left$(strList, InStr(strList, strDelimiter) - 1)

End Function

Public Function GetNumElements(ByVal strList As String, ByVal strDelimiter As String) As Integer

   Dim intElementCount As Integer

   ' If no elements in the list 'strList' then just return 0.
   If Len(strList) = 0 Then
       GetNumElements = 0
       Exit Function
   End If

   ' Append delimiter text to the end of the list as a terminator.
   strList = strList & strDelimiter

   ' Count the number of elements in 'strlist'
   While InStr(strList, strDelimiter) > 0
       intElementCount = intElementCount + 1
       strList = Mid$(strList, InStr(strList, strDelimiter) + 1, Len(strList))
   Wend

   ' Return the number of elements in 'strList'.
   GetNumElements = intElementCount

End Function

