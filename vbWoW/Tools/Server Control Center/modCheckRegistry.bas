Attribute VB_Name = "modCheckRegistry"
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

Declare Function RegCloseKey Lib "advapi32.dll" (ByVal hKey As Long) As Long
Declare Function RegOpenKeyEx Lib "advapi32.dll" Alias "RegOpenKeyExA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal ulOptions As Long, ByVal samDesired As Long, phkResult As Long) As Long
Declare Function RegQueryValueExString Lib "advapi32.dll" Alias "RegQueryValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal lpReserved As Long, lpType As Long, ByVal lpData As String, lpcbData As Long) As Long
Declare Function RegQueryValueExNULL Lib "advapi32.dll" Alias "RegQueryValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal lpReserved As Long, lpType As Long, ByVal lpData As Long, lpcbData As Long) As Long

Global Const KEY_QUERY_VALUE = &H1
Global Const HKEY_CLASSES_ROOT = &H80000000
Global Const HKEY_CURRENT_USER = &H80000001
Global Const HKEY_LOCAL_MACHINE = &H80000002
Global Const HKEY_USERS = &H80000003

Public Function GetRegStringValue$(Where, sKeyName$, sValueName$)
   Dim lRetVal As Long         'result of the API functions
   Dim hKey As Long         'handle of opened key

   lRetVal = RegOpenKeyEx(Where, sKeyName$, 0, KEY_QUERY_VALUE, hKey)

   Dim cch As Long
   Dim lrc As Long
   Dim lType As Long
   Dim sValue As String

   lrc = RegQueryValueExNULL(hKey, sValueName, 0&, lType, 0&, cch)
   GetRegStringValue$ = Space$(cch)
   lrc = RegQueryValueExString(hKey, sValueName, 0&, lType, GetRegStringValue$, cch)
   If lrc = 0 Then GetRegStringValue$ = Left$(GetRegStringValue$, cch - 1)

   RegCloseKey hKey
End Function
