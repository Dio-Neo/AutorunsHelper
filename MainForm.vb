#Region "Imports"
Imports System.IO.Compression
Imports IWshRuntimeLibrary
#End Region

Public Class MainForm

#Region "Variables"
    Private _mCSV As New CSVData
    Private _vtColumn As Integer = 0, _pathColumn As Integer = 0, _timeColumn As Integer = 0
    Private _procArgs As String = String.Empty, _fileName As String = String.Empty
    Private _urlToDonwload As String = "https://download.sysinternals.com/files/Autoruns.zip"
    Private _shortcutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
    Private _autorunsExecuteablePath As String = Application.StartupPath & "\autoruns\autorunsc.exe"
    Private _autoruns64ExecuteablePath As String = Application.StartupPath & "\autoruns\autorunsc64.exe"
    Private _autorunsGuiExecuteablePath As String = Application.StartupPath & "\autoruns\autoruns.exe"
    Private _autorunsGui64ExecuteablePath As String = Application.StartupPath & "\autoruns\autoruns64.exe"
    Private _pathToExtract As String = Application.StartupPath & "\autoruns"
    Private _zipFilePath As String = Application.StartupPath & "\autoruns.zip"
    Private _autorunsFolderPath As String = Application.StartupPath & "\autoruns"
    Private _historyFolderPath As String = Application.StartupPath & "\History"



#End Region

#Region "EntryPoint"
    Sub New()
        InitializeComponent()
        InitializeSetting()
        Download()
        UnZip()
        LvSet()
        CreateHistoryFolder()
    End Sub
#End Region

#Region "Init"
    Private Sub LvSet()
        LvLeft.FullRowSelect = True
        LvLeft.View = View.Details
        LvLeft.HeaderStyle = ColumnHeaderStyle.Nonclickable
        LvRight.FullRowSelect = True
        LvRight.View = View.Details
        LvRight.HeaderStyle = ColumnHeaderStyle.Nonclickable
    End Sub
    Private Sub Download()
        If Not IO.File.Exists(_zipFilePath) Then
            My.Computer.Network.DownloadFile(_urlToDonwload, _zipFilePath)
        End If
    End Sub
    Private Sub UnZip()
        Dim extractPath As String = _pathToExtract
        If Not IO.Directory.Exists(_autorunsFolderPath) Then
            ZipFile.ExtractToDirectory(_zipFilePath, extractPath)
        End If
    End Sub

    Private Sub CreateHistoryFolder()
        If Not IO.Directory.Exists(_historyFolderPath) Then
            IO.Directory.CreateDirectory(_historyFolderPath)
        End If
    End Sub

    Private Function ChangeFileName(fileName As String)
        fileName = fileName.Replace("/", "-")
        fileName = fileName.Replace(" ", "_")
        fileName = fileName.Replace(":", "_")
        _fileName = fileName
        Return fileName
    End Function
    Private Sub InitializeSetting()
        If IO.File.Exists(IO.Path.Combine(_shortcutPath, Application.ProductName) & ".lnk") Then
            StartupToolStripMenuItem.Checked = True
        Else
            StartupToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub CreateShortcutInStartUp(ByVal Description As String)
        Dim WshShell As WshShell = New WshShell()
        Dim Shortcut As IWshShortcut = CType(WshShell.CreateShortcut(IO.Path.Combine(_shortcutPath, Application.ProductName) & ".lnk"), IWshShortcut)
        With Shortcut
            .TargetPath = Application.ExecutablePath
            .WorkingDirectory = Application.StartupPath
            .Description = Description
            .Arguments = "-tray"
            .Save()
        End With
    End Sub

    Private Sub DeleteShortCutInStartUp()
        IO.File.Delete(IO.Path.Combine(_shortcutPath, Application.ProductName) & ".lnk")
    End Sub
#End Region

#Region "CSV"

    Private Sub LoadCSV(fileName As String)
        On Error Resume Next
        Loading(True)
        _mCSV.Separator = ","
        _mCSV.TextQualifier = """"
        _mCSV.LoadCSV(fileName)
        Clear()
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim lvi As ListViewItem
        Dim lvr As ListViewItem
        Dim idx As Integer
        For Each dc In _mCSV.CSVDataSet.Tables(0).Columns
            LvLeft.Columns.Add(dc.ColumnName, 100, HorizontalAlignment.Left)
            LvRight.Columns.Add(dc.ColumnName, 100, HorizontalAlignment.Left)
        Next
        For Each dr In _mCSV.CSVDataSet.Tables(0).Rows
            lvi = LvLeft.Items.Add(dr(0))
            lvr = LvRight.Items.Add(dr(0))
            For idx = 1 To _mCSV.CSVDataSet.Tables(0).Columns.Count - 1
                If (dr(idx) = String.Empty) Then
                    lvi.SubItems.Add("Unknown")
                    lvr.SubItems.Add("Unknown")
                Else
                    lvi.SubItems.Add(dr(idx))
                    lvr.SubItems.Add(dr(idx))
                End If
            Next
        Next

        'Add Column
        Dim c As Integer = LvLeft.Columns.Count, lvc As Integer = LvLeft.Items.Count
        For i = 0 To c - 1
            LvLeft.Columns(i).Text = LvLeft.Items(0).SubItems(i).Text
            LvRight.Columns(i).Text = LvLeft.Items(0).SubItems(i).Text
            If LvLeft.Items(0).SubItems(i).Text = "VT detection" Then
                _vtColumn = i
            End If
            If LvLeft.Items(0).SubItems(i).Text = "Image Path" Then
                _pathColumn = i
            End If
        Next
        LvLeft.Items(0).Remove()

        'Remove Empty Location

        For i = lvc To 0 Step -1
            If Not LvLeft.Items(i).SubItems(_vtColumn).Text.Contains("0|") Then
                LvLeft.Items(i).BackColor = Color.Pink
                LvRight.Items(i).BackColor = Color.Pink
            End If
            If Not LvLeft.Items(i).SubItems(_pathColumn).Text.Contains("\") Or LvLeft.Items(i).SubItems(_timeColumn).Text = String.Empty Then
                LvLeft.Items(i).Remove()
                LvRight.Items(i).BackColor = Color.Pink
            End If
        Next

        For i = lvc - 1 To 0 Step -1
            If Not LvRight.Items(i).BackColor = Color.Pink Then
                LvRight.Items(i).Remove()
            End If
        Next

        Loading(False)
    End Sub

    Private Sub SaveCSV(fileName As String, pathToSave As String)
        On Error Resume Next
        IO.File.WriteAllText(pathToSave, fileName)
    End Sub
#End Region

#Region "UI Events"
    Private Sub Autoruns32ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Autoruns32ToolStripMenuItem.Click
        Dim procAutoruns As New Process()
        With procAutoruns.StartInfo
            .FileName = _autorunsGuiExecuteablePath
            .UseShellExecute = False
            .CreateNoWindow = False
            .RedirectStandardOutput = True
            .RedirectStandardError = True
        End With
        procAutoruns.Start()
    End Sub

    Private Sub Autoruns64ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Autoruns64ToolStripMenuItem.Click
        Dim procAutoruns As New Process()
        With procAutoruns.StartInfo
            .FileName = _autorunsGuiExecuteablePath
            .UseShellExecute = False
            .CreateNoWindow = False
            .RedirectStandardOutput = True
            .RedirectStandardError = True
        End With
        procAutoruns.Start()
    End Sub

    Private Sub HistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoryToolStripMenuItem.Click
        OFD.FileName = "Select CSV"
        OFD.Filter = "CSV Files|*.csv"
        OFD.InitialDirectory = _historyFolderPath
        If OFD.ShowDialog() = DialogResult.OK Then
            Clear()
            _fileName = OFD.FileName
            LoadCSV(OFD.FileName)
        Else
            Return
        End If
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        _procArgs = "-a * -m -s -vt -c -nobanner"
        ATWorker.RunWorkerAsync()
    End Sub
    Private Sub UnsignedAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnsignedAppToolStripMenuItem.Click
        _procArgs = "-a * -u -c -nobanner"
        ATWorker.RunWorkerAsync()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Environment.Exit(0)
    End Sub


    Private Sub StartupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartupToolStripMenuItem.Click
        If StartupToolStripMenuItem.Checked Then
            StartupToolStripMenuItem.Checked = False
            DeleteShortCutInStartUp()
        Else
            StartupToolStripMenuItem.Checked = True
            CreateShortcutInStartUp(String.Empty)
        End If
    End Sub
#End Region

#Region "Run"

    Private Sub ATWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ATWorker.DoWork
        'CheckForIllegalCrossThreadCalls = False 'This is A temporary measure
        Clear()
        MenuStatus(False)
        Loading(True)
        ATWorker.WorkerReportsProgress = True
        Dim procAutoruns As New Process()
        With procAutoruns.StartInfo
            If (Environment.Is64BitOperatingSystem()) Then
                .FileName = _autoruns64ExecuteablePath
            Else
                .FileName = _autorunsExecuteablePath
            End If
            .Arguments = _procArgs
            .UseShellExecute = False
            .CreateNoWindow = True
            .RedirectStandardOutput = True
            .RedirectStandardError = True
        End With
        procAutoruns.Start()
        While Not procAutoruns.StandardOutput.EndOfStream
            Log(procAutoruns.StandardOutput.ReadLine())
            ProgressStatus(1)
        End While
        procAutoruns.WaitForExit()
    End Sub

    Private Sub ATWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ATWorker.RunWorkerCompleted
        'CheckForIllegalCrossThreadCalls = False 'This is A temporary measure
        ProgressStatus(100, True)
        Loading(False)
        Dim fileName As String = ChangeFileName(System.DateTime.Now())
        SaveCSV(txtOutput.Text, _historyFolderPath & "\" & fileName & ".csv")
        LoadCSV(_historyFolderPath & "\" & fileName & ".csv")
        MenuStatus(True)

    End Sub

    Private Sub Log(Text As String, Optional color As Color = Nothing)
        Invoke(New MethodInvoker(Sub()
                                     txtOutput.AppendText(Text)
                                     txtOutput.AppendText(vbNewLine)
                                 End Sub))
    End Sub

    Private Sub MenuStatus(Status As Boolean)
        Invoke(New MethodInvoker(Sub()
                                     ScanToolStripMenuItem.Enabled = Status
                                     HistoryToolStripMenuItem.Enabled = Status
                                 End Sub))
    End Sub


    Private Sub ProgressStatus(Status As Integer, Optional Complete As Boolean = False)
        Invoke(New MethodInvoker(Sub()
                                     If (Complete) Then
                                         ProgressBar.Value = 100
                                         Return
                                     Else
                                         Try
                                             ProgressBar.Value += Status
                                         Catch ex As Exception
                                             ProgressBar.Value = 0
                                         End Try
                                     End If
                                 End Sub))
    End Sub

    Private Sub Loading(Status As Boolean)
        Invoke(New MethodInvoker(Sub()
                                     PictureBoxLeft.Enabled = Status
                                     PictureBoxLeft.Visible = Status
                                     PictureBoxRight.Enabled = Status
                                     PictureBoxRight.Visible = Status
                                 End Sub))
    End Sub

    Private Sub Clear()
        Invoke(New MethodInvoker(Sub()
                                     LvLeft.Clear()
                                     LvLeft.Columns.Clear()
                                     LvRight.Clear()
                                     LvRight.Columns.Clear()
                                     txtOutput.Clear()
                                 End Sub))
    End Sub


#End Region

End Class

