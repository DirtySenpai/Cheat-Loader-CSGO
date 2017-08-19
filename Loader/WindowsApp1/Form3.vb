Imports System.IO
Imports System.Threading
Imports System.Net
Imports System.Management
Imports System.Diagnostics

Public Class Form3
    Dim clockon As Integer
    Dim online As Integer
    Dim check As Integer

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Removes the .dll if CS:GO is not open. If it is open and it tries to remove it, it will give an error.
        Dim pName As String = "csgo"
        Dim psList() As Process
        Try
            psList = Process.GetProcesses()
            For Each p As Process In psList
                If (pName = p.ProcessName) Then

                Else
                    Directory.Delete("C:\temp\Nova\dll", True)
                End If
            Next p

        Catch ex As Exception

        End Try
        
        'Generate HWID
        Dim hw As New clsComputerInfo

        Dim cpu As String
        Dim mb As String
        Dim mac As String
        Dim hwid As String

        cpu = hw.GetProcessorId()
        mb = hw.GetMotherboardID()
        mac = hw.GetMACAddress()
        hwid = cpu + mb + mac

        Dim hwidEncrypted As String = Strings.UCase(hw.getMD5Hash(cpu & mb & mac))

        txtHWID.Text = hwidEncrypted
        'HWID Generated

        Label1.Text = "User Status: Premium"
        lblNetwork.Text = "Fetching status"
        Timer2.Interval = 1500
        online = 2

        Dim fileReader2 As String
        fileReader2 = My.Computer.FileSystem.ReadAllText("C:\temp\Nova\Nova.Hook")
        Label2.Text = "Loader Version: 1.0.1.0"
        clockon = 1
        Timer2.Start()
        If (clockon = 1) Then
            Timer1.Start()
        Else
            Timer1.Stop()
        End If
    End Sub

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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        clockon = 0
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Restart()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MsgBox("Your HWID is: " + txtHWID.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Clipboard.SetText(txtHWID.Text)
        MsgBox("HWID Copied")
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim webAddress As String = "http://localhost/mybb"
        Process.Start(webAddress)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim webAddress As String = "http://localhost/mybb/usercp.php"
        Process.Start(webAddress)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim webAddress As String = "http://localhost/mybb/private.php"
        Process.Start(webAddress)
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

        If (online = 1) Then
            MsgBox("Work in progress", vbCritical)
        Else
            MsgBox("Cheat is offline", vbCritical)
        End If
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        If (online = 1) Then
            Me.Close()
            Form5.Show()
        Else
            MsgBox("Cheat is offline", vbCritical)
        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        If (online = 1) Then
            Form4.Show()
            Me.Close()
        Else
            MsgBox("Cheat is offline", vbCritical)
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Interval = 10000
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\temp\Nova\Nova.Hook.Username")

        Try
            My.Computer.Network.Ping("127.0.0.1")

            Dim WC As New System.Net.WebClient
            Try
                Dim http3 As String = WC.DownloadString("http://localhost/status.txt")
                If http3.Contains("1") Then
                    online = 1
                ElseIf http3.Contains("0") Then
                    online = 0
                ElseIf http3.Contains("2") Then
                    online = 3
                End If
            Catch
                online = 0
            End Try

        Catch
            online = 0
        End Try

        If (online = 1) Then
            lblNetwork.ForeColor = Color.Green
            lblNetwork.Text = "Cheat is online!"
        ElseIf (online = 0) Then
            lblNetwork.ForeColor = Color.Red
            lblNetwork.Text = "Cheat is offline!"
        ElseIf (online = 3) Then
            lblNetwork.ForeColor = Color.Orange
            lblNetwork.Text = "Down for matinence"
            lblNetwork.Location = New Point(50, 74)
        End If

        Dim WebClient2 As New System.Net.WebClient
        Try
            Dim http4 As String = WebClient2.DownloadString("http://localhost/usercheck_get.php?username=" + fileReader)
            If http4.Contains("User is premium") Then
                online = 1
            ElseIf http4.Contains("User is not premium") Then
                online = 0
                MsgBox("Oh no! Your subscription appears to have ended!")
            ElseIf http4.Contains("User is banned") Then
                online = 0
                MsgBox("You have been banned! Program will not close!")
                Application.Exit()
            End If
        Catch
            Label1.Text = "User status: Unable to connect"
            online = 0
        End Try

    End Sub

    Private Sub gbfreeze()
        If (online = 2) Then
            GroupBox4.Enabled = False
        ElseIf (online = 0) Then
            GroupBox4.Enabled = False
        ElseIf (online = 1) Then
            GroupBox4.Enabled = True
        ElseIf (online = 3) Then
            GroupBox4.Enabled = True
        End If

    End Sub

    Private Sub lblNetwork_Click(sender As Object, e As EventArgs) Handles lblNetwork.Click
        If (online = 2) Then
            MsgBox("The cheat is currently checking it's connection to a few resources! Please be patient as this can take some time!")
        ElseIf (online = 1) Then
            MsgBox("The cheat is online and should be currently working!")
        ElseIf (online = 3) Then
            MsgBox("The cheat is down for matinence! Please be patient in this current time")
        ElseIf (online = 0) Then
            MsgBox("The cheat is offline! Oh no! You have to play a game legit now?!?! TRAGIC!!" + Environment.NewLine + "Possible causes: No internet connection, website is down, developer marked the cheat to be offline for matenience")
        End If

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

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
