Imports System.Threading
Imports System.Management
Imports System.IO

Public Class Form5

    Dim filename As String = Guid.NewGuid().ToString + ".dll"

    Private TargetProcessHandle As Integer
    Private pfnStartAddr As Integer
    Private pszLibFileRemote As String
    Private TargetBufferSize As Integer

    Public Const PROCESS_VM_READ = &H10
    Public Const TH32CS_SNAPPROCESS = &H2
    Public Const MEM_COMMIT = 4096
    Public Const PAGE_READWRITE = 4
    Public Const PROCESS_CREATE_THREAD = (&H2)
    Public Const PROCESS_VM_OPERATION = (&H8)
    Public Const PROCESS_VM_WRITE = (&H20)
    Dim DLLFileName As String
    Public Declare Function ReadProcessMemory Lib "kernel32" (
    ByVal hProcess As Integer,
    ByVal lpBaseAddress As Integer,
    ByVal lpBuffer As String,
    ByVal nSize As Integer,
    ByRef lpNumberOfBytesWritten As Integer) As Integer

    Public Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (
    ByVal lpLibFileName As String) As Integer

    Public Declare Function VirtualAllocEx Lib "kernel32" (
    ByVal hProcess As Integer,
    ByVal lpAddress As Integer,
    ByVal dwSize As Integer,
    ByVal flAllocationType As Integer,
    ByVal flProtect As Integer) As Integer

    Public Declare Function WriteProcessMemory Lib "kernel32" (
    ByVal hProcess As Integer,
    ByVal lpBaseAddress As Integer,
    ByVal lpBuffer As String,
    ByVal nSize As Integer,
    ByRef lpNumberOfBytesWritten As Integer) As Integer

    Public Declare Function GetProcAddress Lib "kernel32" (
    ByVal hModule As Integer, ByVal lpProcName As String) As Integer

    Private Declare Function GetModuleHandle Lib "Kernel32" Alias "GetModuleHandleA" (
    ByVal lpModuleName As String) As Integer

    Public Declare Function CreateRemoteThread Lib "kernel32" (
    ByVal hProcess As Integer,
    ByVal lpThreadAttributes As Integer,
    ByVal dwStackSize As Integer,
    ByVal lpStartAddress As Integer,
    ByVal lpParameter As Integer,
    ByVal dwCreationFlags As Integer,
    ByRef lpThreadId As Integer) As Integer

    Public Declare Function OpenProcess Lib "kernel32" (
    ByVal dwDesiredAccess As Integer,
    ByVal bInheritHandle As Integer,
    ByVal dwProcessId As Integer) As Integer

    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (
    ByVal lpClassName As String,
    ByVal lpWindowName As String) As Integer

    Private Declare Function CloseHandle Lib "kernel32" Alias "CloseHandleA" (
    ByVal hObject As Integer) As Integer

    Dim dll As String
    Dim exe As String

    Dim ExeName As String = IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath)
    Private Sub Inject()
        On Error GoTo 1 ' If error occurs, app will close without any error messages
        My.Computer.Network.DownloadFile(dll, "C:\temp\Nova\dll\" + filename)
        Dim ToHideDir As New System.IO.DirectoryInfo("C:\temp\Nova\dll")
        ToHideDir.Attributes = IO.FileAttributes.Hidden
        My.Computer.FileSystem.WriteAllText("c:\temp\nova\Nova.Hook.DLLname", filename, False)
        Timer1.Stop()
        Dim TargetProcess As Process() = Process.GetProcessesByName(TextBox1.Text)
        TargetProcessHandle = OpenProcess(PROCESS_CREATE_THREAD Or PROCESS_VM_OPERATION Or PROCESS_VM_WRITE, False, TargetProcess(0).Id)
        pszLibFileRemote = "C:\temp\Nova\dll\" + filename
        pfnStartAddr = GetProcAddress(GetModuleHandle("Kernel32"), "LoadLibraryA")
        TargetBufferSize = 1 + Len(pszLibFileRemote)
        Dim Rtn As Integer
        Dim LoadLibParamAdr As Integer
        LoadLibParamAdr = VirtualAllocEx(TargetProcessHandle, 0, TargetBufferSize, MEM_COMMIT, PAGE_READWRITE)
        Rtn = WriteProcessMemory(TargetProcessHandle, LoadLibParamAdr, pszLibFileRemote, TargetBufferSize, 0)
        CreateRemoteThread(TargetProcessHandle, 0, 0, pfnStartAddr, LoadLibParamAdr, 0, 0)
        CloseHandle(TargetProcessHandle)
1:      Me.Show()
        Dim ToHideDll As New System.IO.FileInfo("C:\temp\Nova\dll\" + filename)
        ToHideDll.Attributes = IO.FileAttributes.Hidden
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Form3.ListBox1.SelectedIndex = 0) Then
            exe = "csgo"
            dll = "http://localhost/ayyware.dll" ' Main build
        ElseIf (Form3.ListBox1.SelectedIndex = 1) Then
            exe = "csgo"
            dll = "http://localhost/ayyware_lite.dll" ' Lite build
        ElseIf (Form3.ListBox1.SelectedIndex = 2) Then
            exe = "csgo"
            dll = "http://localhost/ayyware_beta.dll" ' Beta Build
        ElseIf (Form3.ListBox1.SelectedIndex = 3) Then
            exe = "csgo"
            dll = "http://localhost/ayyware_private.dll" ' Private Build
        ElseIf (Form3.ListBox1.SelectedIndex = 4) Then
            exe = "hl2"
            dll = "http://localhost/gmod_bypass.dll" ' gmod bypass
        End If

        Label1.Text = "Waiting for " + exe + ".exe"
        TextBox1.Text = exe
        Timer1.Interval = 50
        Timer1.Start()
        Button4.Enabled = False
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim pName As String = exe
        Dim psList() As Process
        Try
            psList = Process.GetProcesses()
            For Each p As Process In psList
                If (pName = p.ProcessName) Then
                    Timer1.Stop()
                    Me.Label1.Text = "Successfully Injected!"
                    Call Inject()
                Else
                    Me.Label1.Text = "Waiting for " + exe + ".exe"
                End If
            Next p
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Form3.Show()
        Me.Close()
    End Sub
End Class

'-----------------------------------------------------
' Coded by /id/Thaisen! Free loader source
' https://github.com/ThaisenPM/Cheat-Loader-CSGO
' Note to the person using this, removing this
' text is in violation of the license you agreed
' to by downloading. Only you can see this so what
' does it matter anyways.
' Copyright © ThaisenPM 2017
' Licensed under a MIT license
' Read the terms of the license here
' https://github.com/ThaisenPM/Cheat-Loader-CSGO/blob/master/LICENSE
'-----------------------------------------------------
