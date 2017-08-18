Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Management
Imports System.Security

Public Class Form1

    Dim login As Integer
    Dim confirm As Integer
    Dim runlogin As Integer
    Dim updateneeded As Integer
    Dim firstlaunch As Integer
    Dim confirmhwid As Integer
    Dim updatecolor As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("http://localhost/mybb/member.php?action=login")
        WebBrowser2.Navigate("http://localhost/usercheck.php")
        WebBrowser3.Navigate("http://localhost/hwid.php")
        
        'Generate HWID
        Dim hw As New clsComputerInfo

        Dim cpu As String
        Dim mb As String
        Dim mac As String
        Dim hwid As String

        cpu = hw.GetProcessorID()
        mb = hw.GetMotherboardID()
        mac = hw.GetMacAddress()
        hwid = cpu + mb + mac

        Dim hwidEncrypted As String = Strings.UCase(hw.GetMD5Hash(cpu & mb & mac))

        txtHWID.Text = hwidEncrypted
        'HWID Generated

        Timer1.Start()
        Timer2.Start()

        'Local Version
        Dim currentVerison As String
        currentVerison = "1.0.1.0"

        'Web Version
        Dim address As String = "http://localhost/version.txt"
        Dim client As WebClient = New WebClient()
        Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
        Label4.Text = reader.ReadToEnd
        Label4.ForeColor = Color.Transparent

        If (currentVerison < Label4.Text) Then
            updateneeded = 1
            Label5.Text = "An update is available! Click Here"
            Me.Size = New Size(198, 231)
        ElseIf (currentVerison > Label4.Text) Then
            updateneeded = 1
            Label5.Text = "Update the webserver side file now"
            Me.Size = New Size(198, 231)
        Else
            updateneeded = 0
            Label5.Text = ""
            Me.Size = New Size(198, 212)
        End If

        Label6.Text = "Current Status: Waiting for input"

        If My.Computer.FileSystem.FileExists("C:\temp\Nova\Nova.Hook") Then
        Else
            firstlaunch = 1
            System.IO.Directory.CreateDirectory("C:\temp\Nova\")
            My.Computer.FileSystem.WriteAllText("c:\temp\nova\Nova.Hook", "This file just tells the loader if it's your first time opening it or not... delete it if you want XD", False)
            Dim ToHideDir As New System.IO.DirectoryInfo("C:\temp\Nova\")
            ToHideDir.Attributes = IO.FileAttributes.Hidden
        End If


        'Dim pName As String = "Steam"
        'Dim psList() As Process
        'Try
        'psList = Process.GetProcesses()
        'For Each p As Process In psList
        'If (pName = p.ProcessName) Then
        'MsgBox("Steam is currently running! Please close steam before using the loader", MsgBoxStyle.Exclamation)
        'Me.Close()
        'End If
        'Next p

        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try

        'Dim appPath As String = My.Application.Info.DirectoryPath
        'If appPath.Contains("C:\") Then
        'MsgBox("The loader must be run from a USB! Please move the loader's .exe onto a USB then execute!")
        'Me.Close()
        'End If
    End Sub
    ' Confirm HWID
    Private Class clsComputerInfo
        'Get processor ID
        Friend Function GetProcessorId() As String
            Dim strProcessorID As String = String.Empty
            Dim query As New SelectQuery("Win32_processor")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject
            For Each info In search.Get()
                strProcessorID = info("processorID").ToString()
            Next
            Return strProcessorID
        End Function
        ' Get MAC Address
        Friend Function GetMACAddress() As String
            Dim mc As ManagementClass = New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim moc As ManagementObjectCollection = mc.GetInstances()
            Dim MacAddress As String = String.Empty
            For Each mo As ManagementObject In moc
                If (MacAddress.Equals(String.Empty)) Then
                    If CBool(mo("IPEnabled")) Then MacAddress = mo("MacAddress").ToString()
                    mo.Dispose()
                End If
                MacAddress = MacAddress.Replace(":", String.Empty)
            Next
            Return MacAddress
        End Function
        ' Get Motherboard ID
        Friend Function GetMotherboardID() As String
            Dim strMotherboardID As String = String.Empty
            Dim query As New SelectQuery("Win32_BaseBoard")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject
            For Each info In search.Get()
                strMotherboardID = info("product").ToString()
            Next
            Return strMotherboardID
        End Function
        ' Encrypt HWID
        Friend Function getMD5Hash(ByVal strToHash As String) As String
            Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
            bytesToHash = md5Obj.ComputeHash(bytesToHash)
            Dim strResult As String = ""
            For Each b As Byte In bytesToHash
                strResult += b.ToString("x2")
            Next
            Return strResult
        End Function
    End Class
    ' Timer start
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (firstlaunch = 1) Then
            Form6.Show()
            Timer1.Stop()
        Else
            Timer1.Stop()
        End If
    End Sub
    ' Login button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        login = 1
        WebBrowser1.Document.GetElementById("username").SetAttribute("value", TextBox1.Text)
        WebBrowser1.Document.GetElementById("password").SetAttribute("value", TextBox2.Text)
        WebBrowser1.Document.GetElementById("submit").InvokeMember("click")

        WebBrowser2.Document.GetElementById("username").SetAttribute("value", TextBox1.Text)
        WebBrowser2.Document.GetElementById("submit").InvokeMember("click")

        WebBrowser3.Document.GetElementById("username").SetAttribute("value", TextBox1.Text)
        WebBrowser3.Document.GetElementById("hwidin").SetAttribute("value", txtHWID.Text)
        WebBrowser3.Document.GetElementById("submit").InvokeMember("click")
    End Sub
    ' Exit button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
    ' Login check
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If login = 1 Then
            login = 0
            Label6.Text = "Current Status: Checking password"
            If WebBrowser1.DocumentText.Contains("<p>You have successfully been logged in") Then
                Label6.Text = "Current Status: Password accepted"
                My.Computer.FileSystem.WriteAllText("c:\temp\nova\Nova.Hook.Username", TextBox1.Text, False)
                confirm = 1
            Else
                Label6.ForeColor = Color.Red
                Label6.Text = "Current Status: Password rejected!"
                WebBrowser1.Navigate("http://localhost/mybb/member.php?action=login")
                MsgBox("Error: Username or password is incorrect", vbCritical)
                Thread.Sleep(250)
                Application.Restart()
                Button1.Enabled = True
            End If
        End If
    End Sub
    ' Status check
    Private Sub WebBrowser2_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If confirm = 1 Then
            confirm = 0
            Label6.Text = "Current Status: Checking account status"
            If WebBrowser2.DocumentText.Contains("User is premium") Then
                Label6.Text = "Current Status: Group accepted"
                confirmhwid = 1
            ElseIf WebBrowser2.DocumentText.Contains("User is not premium") Then
                Label6.ForeColor = Color.Red
                Label6.Text = "Current Status: User is not premium!"
                WebBrowser1.Navigate("http://localhost/mybb/member.php?action=login")
                WebBrowser2.Navigate("http://localhost/usercheck.php")
                MsgBox("Error: User is not premium! Visit the forums to purchase a subscription.", vbCritical)
                Thread.Sleep(250)
                Application.Restart()
                Button1.Enabled = True
            ElseIf WebBrowser2.DocumentText.Contains("banned") Then
                Label6.ForeColor = Color.Red
                Label6.Text = "Current Status: User is banned!"
                MsgBox("Error: User is banned! Visit the forums to learn why.", vbCritical)
                Thread.Sleep(250)
                Application.Exit()
            ElseIf WebBrowser2.DocumentText.Contains("No user") Then
                Label6.ForeColor = Color.Red
                Label6.Text = "Current Status: User is not found!"
                WebBrowser1.Navigate("http://localhost/mybb/member.php?action=login")
                WebBrowser2.Navigate("http://localhost/usercheck.php")
                MsgBox("Error: No user with that name! Please make sure it is spelt correctly.", vbCritical)
                Thread.Sleep(250)
                Application.Restart()
                Button1.Enabled = True
            End If
        End If
    End Sub
    ' HWID check
    Private Sub WebBrowser3_DocumentCompleted_1(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser3.DocumentCompleted
        If confirmhwid = 1 Then
            confirmhwid = 0
            Label6.Text = "Current Status: Checking HWID"
            If WebBrowser3.DocumentText.Contains("HWID is correct") Then
                Label6.Text = "Current Status: HWID accepted!"
                Thread.Sleep(100)
                Form3.Show()
                Me.Hide()
                Button1.Enabled = True
            ElseIf WebBrowser3.DocumentText.Contains("HWID is not correct") Then
                WebBrowser1.Navigate("http://localhost/mybb/member.php?action=login")
                WebBrowser2.Navigate("http://localhost/usercheck.php")
                WebBrowser3.Navigate("http://localhost/hwid.php")
                Label6.ForeColor = Color.Red
                Label6.Text = "Current Status: HWID rejected!"
                MsgBox("Error: HWID is incorrect", vbCritical)
                Thread.Sleep(250)
                Application.Restart()
                Button1.Enabled = True
            ElseIf WebBrowser3.DocumentText.Contains("") Then
                WebBrowser1.Navigate("http://localhost/mybb/member.php?action=login")
                WebBrowser2.Navigate("http://localhost/usercheck.php")
                WebBrowser3.Navigate("http://localhost/hwid.php")
                Label6.ForeColor = Color.Red
                Label6.Text = "Current Status: HWID rejected!"
                MsgBox("Error: No user with that name (HWID)", vbCritical)
                Thread.Sleep(250)
                Application.Restart()
                Button1.Enabled = True
            End If
        End If
    End Sub
    ' Login fix
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Hide()
        Form2.Show()
    End Sub
    ' Update Script

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim exePath As String = Application.ExecutablePath()
        My.Computer.FileSystem.WriteAllText("c:\temp\nova\Nova.Hook.Path", exePath, False)
        Me.Hide()

        Dim appPath As String = My.Application.Info.DirectoryPath

        If My.Computer.FileSystem.FileExists(appPath + "\Updater.exe") Then
            Process.Start(appPath + "\Updater.exe")
            Application.Exit()
        Else
            My.Computer.Network.DownloadFile("http://localhost/Updater.exe", appPath + "\Updater.exe")
            Process.Start(appPath + "\Updater.exe")
            Application.Exit()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If (updateneeded = 1) Then
            Timer2.Stop()
            Dim exePath As String = Application.ExecutablePath()
            My.Computer.FileSystem.WriteAllText("c:\temp\nova\Nova.Hook.Path", exePath, False)
            Me.Hide()

            Dim appPath As String = My.Application.Info.DirectoryPath

            If My.Computer.FileSystem.FileExists(appPath + "\Updater.exe") Then
                Process.Start(appPath + "\Updater.exe")
                Application.Exit()
            Else
                My.Computer.Network.DownloadFile("http://localhost/Updater.exe", appPath + "\Updater.exe")
                Process.Start(appPath + "\Updater.exe")
                Application.Exit()
            End If
        Else
            Timer2.Stop()
        End If
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
