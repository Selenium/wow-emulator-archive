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

Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Reflection
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports vbWoW.Logbase.BaseWriter

Public Class ConsoleColorClass
    Public Enum ForegroundColors
        Black = 0
        Blue = 1
        Green = 2
        Cyan = Blue Or Green
        Red = 4
        Magenta = Blue Or Red
        Yellow = Green Or Red
        White = Blue Or Green Or Red
        Gray = 8
        LightBlue = Gray Or Blue
        LightGreen = Gray Or Green
        LightCyan = Gray Or Cyan
        LightRed = Gray Or Red
        LightMagenta = Gray Or Magenta
        LightYellow = Gray Or Yellow
        BrightWhite = Gray Or White
    End Enum
    Public Enum BackgroundColors
        Black = 0
        Blue = 16
        Green = 32
        Cyan = Blue Or Green
        Red = 64
        Magenta = Blue Or Red
        Yellow = Green Or Red
        White = Blue Or Green Or Red
        Gray = 128
        LightBlue = Gray Or Blue
        LightGreen = Gray Or Green
        LightCyan = Gray Or Cyan
        LightRed = Gray Or Red
        LightMagenta = Gray Or Magenta
        LightYellow = Gray Or Yellow
        BrightWhite = Gray Or White
    End Enum
    Public Enum Attributes
        None = &H0
        GridHorizontal = &H400
        GridLVertical = &H800
        GridRVertical = &H1000
        ReverseVideo = &H4000
        Underscore = &H8000
    End Enum

    Private Const STD_OUTPUT_HANDLE As Integer = -11
    Private Shared InvalidHandleValue As New IntPtr(-1)

    Public Sub New()
        ' This class can not be instantiated.
    End Sub

    ' Our wrapper implementations.
    Public Sub SetConsoleColor()
        SetConsoleColor(ForegroundColors.White, BackgroundColors.Black)
    End Sub
    Public Sub SetConsoleColor(ByVal foreground As ForegroundColors)
        SetConsoleColor(foreground, BackgroundColors.Black, Attributes.None)
    End Sub
    Public Sub SetConsoleColor(ByVal foreground As ForegroundColors, ByVal background As BackgroundColors)
        SetConsoleColor(foreground, background, Attributes.None)
    End Sub
    Public Sub SetConsoleColor(ByVal foreground As ForegroundColors, ByVal background As BackgroundColors, ByVal attribute As Attributes)
        Dim handle As IntPtr = GetStdHandle(STD_OUTPUT_HANDLE)
        If handle.Equals(InvalidHandleValue) Then
            Throw New System.ComponentModel.Win32Exception
        End If
        ' We have to convert the integer flag values into a Unsigned Short (UInt16) to pass to the 
        ' SetConsoleTextAttribute API call.
        Dim value As UInt16 = System.Convert.ToUInt16(foreground Or background Or attribute)
        If Not SetConsoleTextAttribute(handle, value) Then
            'Throw New System.ComponentModel.Win32Exception
        End If
    End Sub

    ' DLLImport's (Win32 functions)
    <DllImport("Kernel32.dll", SetLastError:=True)> Private Shared Function GetStdHandle(ByVal stdHandle As Integer) As IntPtr
    End Function
    <DllImport("Kernel32.dll", SetLastError:=True)> Private Shared Function SetConsoleTextAttribute(ByVal consoleOutput As IntPtr, ByVal Attributes As UInt16) As Boolean
    End Function
    <DllImport("Kernel32.dll", SetLastError:=True)> Public Shared Function SetConsoleTitle(ByVal ConsoleTitle As String) As Boolean
    End Function

End Class



'Dim test As New ScriptedObject("scripts\test.vb", "test.dll")
'test.Invoke(".TestScript", "TestMe")

'creature = test.Invoke("DefaultAI_1")
'creature.Move()
Public Class ScriptedObject
    Implements IDisposable

    Private compRes As CompilerResults
    Public ass As [Assembly]

    Public Sub New(ByVal AssemblySourceFile As String, ByVal AssemblyFile As String, ByVal InMemory As Boolean)
        If (Not InMemory) AndAlso (Dir(AssemblyFile) <> "") AndAlso (FileDateTime(AssemblySourceFile) < FileDateTime(AssemblyFile)) Then
            'DONE: We have lates source compiled already
            LoadAssemblyObject(AssemblyFile)
            Return
        End If

        WorldServer.Log.WriteLine(LogType.SUCCESS, "Compiling: {0}", AssemblySourceFile)

        Try
            Dim VBcp As New VBCodeProvider
            'Dim CScp As New Microsoft.CSharp.CSharpCodeProvider

            ' Compiling the source file to an assembly DLL
            Dim cc As ICodeCompiler = VBcp.CreateCompiler()
            Dim cpar As New CompilerParameters
            If Not InMemory Then cpar.OutputAssembly = AssemblyFile
            For Each Include As String In Config.CompilerInclude
                cpar.ReferencedAssemblies.Add(Include)
            Next
            cpar.ReferencedAssemblies.Add(AppDomain.CurrentDomain.FriendlyName)
            cpar.GenerateExecutable = False     ' result is a .DLL
            cpar.GenerateInMemory = InMemory
            'Dim compRes As CompilerResults
            compRes = cc.CompileAssemblyFromFile(cpar, System.AppDomain.CurrentDomain.BaseDirectory() & AssemblySourceFile)

            If compRes.Errors.HasErrors = True Then
                For Each err As System.Codedom.Compiler.CompilerError In compRes.Errors
                    WorldServer.Log.WriteLine(LogType.FAILED, "Compiling: Error on line {1}:{0}{2}", vbNewLine, err.Line, err.ErrorText)
                Next
            End If

            ass = compRes.CompiledAssembly
            'Dim ass As [Assembly] = [Assembly].LoadFrom("test.dll")
        Catch e As Exception
            WorldServer.Log.WriteLine(LogType.FAILED, "Unable to compile script [{0}]. {2}{1}", AssemblySourceFile, e.ToString, vbNewLine)
        End Try
    End Sub
    Public Sub Invoke(ByVal MyModule As String, ByVal MyMethod As String, Optional ByVal Parameters As Object = Nothing)
        Try
            Dim ty As Type = ass.GetType("Scripts." & MyModule)
            Dim mi As MethodInfo = ty.GetMethod(MyMethod)
            mi.Invoke(Nothing, Parameters)
        Catch e As TargetInvocationException
            WorldServer.Log.WriteLine(LogType.FAILED, "Script execution error:{1}{0}", e.GetBaseException.ToString, vbNewLine)
        Catch e As Exception
            WorldServer.Log.WriteLine(LogType.FAILED, "Script Method [{0}] not found in [Scripts.{1}]!", MyMethod, MyModule)
        End Try
    End Sub
    Public Function Invoke(ByVal MyBaseClass As String, Optional ByVal Parameters As Object = Nothing) As Object
        Try
            Dim ty As Type = ass.GetType("Scripts." & MyBaseClass)
            Dim ci() As ConstructorInfo = ty.GetConstructors

            Return ci(0).Invoke(Parameters)
        Catch e As NullReferenceException
            WorldServer.Log.WriteLine(LogType.FAILED, "Scripted Class [{0}] not found in [Scripts]!", MyBaseClass)
        Catch e As Exception
            WorldServer.Log.WriteLine(LogType.FAILED, "Script execution error:{1}{0}", e.GetBaseException.ToString, vbNewLine)
        End Try
        Return Nothing
    End Function
    Public Function ContainsMethod(ByVal MyModule As String, ByVal MyMethod As String) As Boolean
        Dim ty As Type = ass.GetType("Scripts." & MyModule)
        Dim mi As MethodInfo = ty.GetMethod(MyMethod)
        If mi Is Nothing Then Return False Else Return True
    End Function
    'Load an already compiled script.
    Public Sub LoadAssemblyObject(ByVal dllLocation As String)
        Try
            ass = [Assembly].LoadFrom(dllLocation)
        Catch fnfe As FileNotFoundException
            WorldServer.Log.WriteLine(LogType.FAILED, "DLL not found error:{1}{0}", fnfe.GetBaseException.ToString, vbNewLine)
        Catch ane As ArgumentNullException
            WorldServer.Log.WriteLine(LogType.FAILED, "DLL NULL error:{1}{0}", ane.GetBaseException.ToString, vbNewLine)
        Catch bife As BadImageFormatException
            WorldServer.Log.WriteLine(LogType.FAILED, "DLL not a valid assembly error:{1}{0}", bife.GetBaseException.ToString, vbNewLine)
        End Try
    End Sub

    Public Sub Dispose() Implements System.IDisposable.Dispose
    End Sub
End Class















