﻿Imports Windows.UI.Popups

Module Vars
    Public localSettings As Windows.Storage.ApplicationDataContainer = Windows.Storage.ApplicationData.Current.LocalSettings
    Public SetFullScreen As Object = localSettings.Values("FullScreen")
    Public LockTopBar As Object = localSettings.Values("LockTopBar")
    Public ShowRecentPosts As Object = localSettings.Values("ShowRecentPosts")
    Public HideAds As Object = localSettings.Values("hideAds")
    Public View As ApplicationView = ApplicationView.GetForCurrentView

    Public MyWebViewSource As String = "https://www.instagram.com/?hl=en"

    Public PrivacyInfo As String = "SlimInsta UWP is a UWP app for Windows 10 Mobile to allow the user to access their Instagram account from a single portal." & vbCrLf & vbCrLf & "Small memory footprint, open source, and forever free." & vbCrLf & vbCrLf & "This app is NOT associated in ANY way with Instagram, Inc." & vbCrLf & vbCrLf & "----------" & vbCrLf & vbCrLf & "SlimInsta UWP Privacy" & vbCrLf & vbCrLf & "No personal, or private, information of either you, or your device, is collected by this app." & vbCrLf & vbCrLf & "Neither is ANY information transmitted by this app."

    Public Async Function displayMessageAsync(ByVal title As String, ByVal content As String, ByVal dialogType As String) As Task
        Dim messageDialog = New MessageDialog(content, title)
        If dialogType = "notification" Then
        Else
            messageDialog.Commands.Add(New UICommand("Yes", Nothing))
            messageDialog.Commands.Add(New UICommand("No", Nothing))
            messageDialog.DefaultCommandIndex = 0
        End If

        messageDialog.CancelCommandIndex = 1
        Dim cmdResult = Await messageDialog.ShowAsync()
        If cmdResult.Label = "Yes" Then
            Application.Current.Exit()
        End If
    End Function
End Module
