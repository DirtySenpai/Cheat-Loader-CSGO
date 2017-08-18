Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading

Public Class Form1

    Dim button As Integer
    Dim filename As String = Guid.NewGuid().ToString + ".exe"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Label1.Text = "Status: Waiting for user input"
        button = 1
        Dim appPath As String = My.Application.Info.DirectoryPath
        TextBox1.Text = appPath + "\" + filename

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value += 1
        Dim appPath As String = My.Application.Info.DirectoryPath
        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\temp\nova\nova.hook.path")
        Dim stringReader As String
        stringReader = fileReader.ReadLine()

        If (ProgressBar1.Value = ProgressBar1.Maximum) Then
            Timer1.Enabled = False
        End If

        If (ProgressBar1.Value >= 0) Then

            Try
                System.IO.File.Delete(stringReader)
            Catch ex As Exception
            End Try

            File.Delete(stringReader)
            Label1.Text = "Status: Removing old version"
        End If

        If (ProgressBar1.Value = 20) Then

            My.Computer.Network.DownloadFile("http://localhost/loader.exe", TextBox1.Text)

            Label1.Text = "Status: Downloading new version"
        End If

        If (ProgressBar1.Value > 21) Then
            Label1.Text = "Status: Downloading new version"
        End If

        If (ProgressBar1.Value >= 50) Then
            Label1.Text = "Status: Checking system"

            If My.Computer.FileSystem.FileExists(TextBox1.Text) Then

            Else
                Label1.Text = "ERROR: New Version Not Found!"
                ProgressBar1.Value = 0
            End If
        End If

        If (ProgressBar1.Value = 100) Then
            Timer1.Stop()
            Label1.Text = "Status: Done updating"
            button = 0
            Process.Start(TextBox1.Text)
            Thread.Sleep(500)
            Application.Exit()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim appPath As String = My.Application.Info.DirectoryPath

        'MsgBox("Please put the file in " + appPath + "\1000.exe. Please rename if needed. Hit okay when ready")

        Timer1.Enabled = True

        If (button = 1) Then
            Button1.Enabled = False
        End If

        If (button = 0) Then
            Button1.Text = "Start"
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
