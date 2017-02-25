
Public Module LaunchApp

    'Public Sub Main()
    '    If UBound(Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)) > 0 Then
    '        MsgBox("Already Running!", MsgBoxStyle.Critical)
    '        End
    '    End If
    '    Application.EnableVisualStyles()
    '    Application.Run(New AppContext)
    'End Sub

    Public Sub Main(ByVal cmdArgs() As String)
        If UBound(Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)) > 0 Then
            MsgBox("Already Running!" & vbNewLine & "Check Your Taskbar", MsgBoxStyle.Critical)
            End
        End If
        Application.EnableVisualStyles()

        Dim UseTray As Boolean = False

        For Each Cmd As String In cmdArgs
            If Cmd.ToLower = "-tray" Then
                UseTray = True
                Exit For
            End If
        Next

        If UseTray Then
            DisplayForm = False
        Else
            DisplayForm = True
        End If
        Application.Run(New AppContext)
    End Sub

    'Public Function Main() As Integer
    'End Function

    'Public Function Main(ByVal cmdArgs() As String) As Integer
    'End Function

End Module
