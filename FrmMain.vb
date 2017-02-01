#Region "Imports"
Imports System.IO
Imports System.IO.Compression
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
#End Region

Public Class FrmMain

#Region "Variables"
    Private mCSV As New CSVData
    Private vtColumn As Integer = 0, pathColumn As Integer = 0
    Private procArgs As String = String.Empty
    Private urlToDonwload As String = "https://download.sysinternals.com/files/Autoruns.zip"
    Private autorunsExecuteablePath As String = Application.StartupPath & "\autoruns\autorunsc.exe"
    Private autoruns64ExecuteablePath As String = Application.StartupPath & "\autoruns\autorunsc64.exe"
    Private autorunsGuiExecuteablePath As String = Application.StartupPath & "\autoruns\autoruns.exe"
    Private autorunsGui64ExecuteablePath As String = Application.StartupPath & "\autoruns\autoruns64.exe"
    Private pathToExtract As String = Application.StartupPath & "\autoruns"
    Private zipFilePath As String = Application.StartupPath & "\autoruns.zip"
    Private autorunsFolderPath As String = Application.StartupPath & "\autoruns"
    Private historyFolderPath As String = Application.StartupPath & "\History"


#End Region

#Region "EntryPoint"
    Sub New()
        InitializeComponent()
        Download()
        UnZip()
        LvSet()
        CreateHistoryFolder()
    End Sub
#End Region

#Region "Init"
    Private Sub LvSet()
        LvCSV.FullRowSelect = True
        LvCSV.View = View.Details
        LvCSV.HeaderStyle = ColumnHeaderStyle.Nonclickable
    End Sub
    Private Sub Download()
        If Not File.Exists(zipFilePath) Then
            My.Computer.Network.DownloadFile(urlToDonwload, zipFilePath)
        End If
    End Sub
    Private Sub UnZip()
        Dim extractPath As String = pathToExtract
        If Not Directory.Exists(autorunsFolderPath) Then
            ZipFile.ExtractToDirectory(zipFilePath, extractPath)
        End If
    End Sub

    Private Sub CreateHistoryFolder()
        If Not Directory.Exists(historyFolderPath) Then
            Directory.CreateDirectory(historyFolderPath)
        End If
    End Sub

    Private Function ChangeFileName(fileName As String)
        fileName = fileName.Replace("/", "-")
        fileName = fileName.Replace(" ", "_")
        fileName = fileName.Replace(":", "_")
        Return fileName
    End Function

#End Region

#Region "CSV"

    Private Sub LoadCSV(fileName As String, Optional viewOption As String = Nothing)
        On Error Resume Next
        mCSV.Separator = ","
        mCSV.TextQualifier = """"
        mCSV.LoadCSV(fileName)
        Clear()
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim lvi As ListViewItem
        Dim idx As Integer
        For Each dc In mCSV.CSVDataSet.Tables(0).Columns
            LvCSV.Columns.Add(dc.ColumnName, 100, HorizontalAlignment.Left)
        Next
        For Each dr In mCSV.CSVDataSet.Tables(0).Rows
            lvi = LvCSV.Items.Add(dr(0))
            For idx = 1 To mCSV.CSVDataSet.Tables(0).Columns.Count - 1
                If (dr(idx) = String.Empty) Then
                    lvi.SubItems.Add("Unknown")
                    lvi.BackColor = Color.Pink
                Else
                    lvi.SubItems.Add(dr(idx))
                End If
            Next
        Next
        Dim c As Integer = LvCSV.Columns.Count, lvc As Integer = LvCSV.Items.Count
        For i = 0 To c - 1
            LvCSV.Columns(i).Text = LvCSV.Items(0).SubItems(i).Text
            If LvCSV.Items(0).SubItems(i).Text = "VT detection" Then
                vtColumn = i
            End If
            If LvCSV.Items(0).SubItems(i).Text = "Image Path" Then
                pathColumn = i
            End If
        Next
        LvCSV.Items(0).Remove()
        'For i = 0 To lvc - 1
        '    If lvCSV.Items(i).SubItems(ent).Text = "Unknown" Then
        '        lvCSV.Items(i).BackColor = Color.Pink
        '    End If
        'Next

    End Sub

    Private Sub SaveCSV(fileName As String, pathToSave As String)
        On Error Resume Next
        File.WriteAllText(pathToSave, fileName)
    End Sub


#End Region

#Region "UI Events"
    Private Sub Autoruns32ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Autoruns32ToolStripMenuItem.Click
        Dim procAutoruns As New Process()
        With procAutoruns.StartInfo
            .FileName = autorunsGuiExecuteablePath
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
            .FileName = autorunsGuiExecuteablePath
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
        OFD.InitialDirectory = historyFolderPath
        If OFD.ShowDialog() = DialogResult.OK Then
            Clear()
            LoadCSV(OFD.FileName)
        Else
            Return
        End If
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        procArgs = "-a * -m -s -vt -c -nobanner"
        ATWorker.RunWorkerAsync()
    End Sub
    Private Sub UnsignedAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnsignedAppToolStripMenuItem.Click
        procArgs = "-a * -u -c -nobanner"
        ATWorker.RunWorkerAsync()
    End Sub

    Private Sub NonZeroDetectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NonZeroDetectionToolStripMenuItem.Click
        On Error Resume Next
        Dim lvc As Integer = LvCSV.Items.Count
        For i = lvc - 1 To 0 Step -1
            If LvCSV.Items(i).SubItems(vtColumn).Text <> "Unknown" Then
                LvCSV.Items(i).Remove()
            End If
        Next
    End Sub
    Private Sub DeleteEmptyLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteEmptyLocationToolStripMenuItem.Click
        On Error Resume Next
        Dim lvc As Integer = LvCSV.Items.Count
        For i = lvc - 1 To 0 Step -1
            If Not LvCSV.Items(i).SubItems(pathColumn).Text.Contains("\") Then
                LvCSV.Items(i).Remove()
            End If
        Next
    End Sub


    Private Sub ViewOnlyUnknownItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewOnlyUnknownItemToolStripMenuItem.Click
        On Error Resume Next
        Dim lvc As Integer = LvCSV.Items.Count
        For i = lvc - 1 To 0 Step -1
            If Not LvCSV.Items(i).BackColor = Color.Pink Then
                LvCSV.Items(i).Remove()
            End If
        Next
    End Sub


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Environment.Exit(0)
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
                .FileName = autoruns64ExecuteablePath
            Else
                .FileName = autorunsExecuteablePath
            End If
            .Arguments = procArgs
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
        SaveCSV(txtOutput.Text, historyFolderPath & "\" & fileName & ".csv")
        LoadCSV(historyFolderPath & "\" & fileName & ".csv")
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
                                     PictureBox.Enabled = Status
                                     PictureBox.Visible = Status
                                 End Sub))
    End Sub

    Private Sub Clear()
        Invoke(New MethodInvoker(Sub()
                                     LvCSV.Clear()
                                     LvCSV.Columns.Clear()
                                     txtOutput.Clear()
                                 End Sub))
    End Sub


#End Region

End Class

#Region "Class"
Public Class CSVData
    Implements IDisposable

    Dim dsCSV As DataSet
    Dim mSeparator As Char = ","
    Dim mTextQualifier As Char = """"
    Dim mData() As String
    Dim mHeader As Boolean

    Private regQuote As New Regex("^(\x22)(.*)(\x22)(\s*,)(.*)$", RegexOptions.IgnoreCase + RegexOptions.RightToLeft)
    Private regNormal As New Regex("^([^,]*)(\s*,)(.*)$", RegexOptions.IgnoreCase + RegexOptions.RightToLeft)
    Private regQuoteLast As New Regex("^(\x22)([\x22*]{2,})(\x22)$", RegexOptions.IgnoreCase)
    Private regNormalLast As New Regex("^.*$", RegexOptions.IgnoreCase)

    Protected Disposed As Boolean

#Region " Load CSV "
    '
    ' Load CSV
    '
    Public Sub LoadCSV(ByVal CSVFile As String)
        LoadCSV(CSVFile, False)
    End Sub

    '
    ' Load CSV - Has Header
    '
    Public Sub LoadCSV(ByVal CSVFile As String, ByVal HasHeader As Boolean)
        On Error Resume Next
        mHeader = HasHeader
        SetupRegEx()

        If File.Exists(CSVFile) = False Then
            Throw New Exception(CSVFile & " does not exist.")
        End If

        If Not dsCSV Is Nothing Then
            dsCSV.Clear()
            dsCSV.Tables.Clear()
            dsCSV.Dispose()
            dsCSV = Nothing
        End If

        dsCSV = New DataSet("CSV")
        dsCSV.Tables.Add("CSVData")

        Dim sr As New StreamReader(CSVFile)
        Dim idx As Integer
        Dim bFirstLine As Boolean = True
        Dim dr As DataRow

        Do While sr.Peek > -1
            ProcessLine(sr.ReadLine())

            '
            ' Create Columns
            '
            If bFirstLine = True Then
                For idx = 0 To mData.GetUpperBound(0)
                    If mHeader = True Then
                        dsCSV.Tables("CSVData").Columns.Add(mData(idx), GetType(String))
                    Else
                        dsCSV.Tables("CSVData").Columns.Add("Column" & idx, GetType(String))
                    End If
                Next
            End If

            '
            ' Add Data
            '
            If Not (bFirstLine = True And mHeader = True) Then
                dr = dsCSV.Tables("CSVData").NewRow()

                For idx = 0 To mData.GetUpperBound(0)
                    dr(idx) = mData(idx)
                Next

                dsCSV.Tables("CSVData").Rows.Add(dr)
                dsCSV.AcceptChanges()
            End If

            bFirstLine = False
        Loop

        sr.Close()
    End Sub

    '
    ' Load CSV with custom separator
    '
    Public Sub LoadCSV(ByVal CSVFile As String, ByVal Separator As Char)
        LoadCSV(CSVFile, Separator, False)
    End Sub

    '
    ' Load CSV with custom separator and Has Header
    '
    Public Sub LoadCSV(ByVal CSVFile As String, ByVal Separator As Char, ByVal HasHeader As Boolean)
        mSeparator = Separator
        Try
            LoadCSV(CSVFile, HasHeader)
        Catch ex As Exception
            Throw New Exception("CSV Error", ex)
        End Try
    End Sub

    '
    ' Load CSV with custom separator and text qualifier
    '
    Public Sub LoadCSV(ByVal CSVFile As String, ByVal Separator As Char, ByVal TxtQualifier As Char)
        LoadCSV(CSVFile, Separator, TxtQualifier, False)
    End Sub

    '
    ' Load CSV with custom separator and text qualifier
    '
    Public Sub LoadCSV(ByVal CSVFile As String, ByVal Separator As Char, ByVal TxtQualifier As Char, ByVal HasHeader As Boolean)
        mSeparator = Separator
        mTextQualifier = TxtQualifier
        Try
            LoadCSV(CSVFile, HasHeader)
        Catch ex As Exception
            Throw New Exception("CSV Error", ex)
        End Try
    End Sub
#End Region
#Region " Process Line "
    '
    ' Process Line
    '
    Private Sub ProcessLine(ByVal sLine As String)
        Dim sData As String
        Dim m As Match
        Dim idx As Integer
        Dim mc As MatchCollection

        Erase mData
        sLine = sLine.Replace(ControlChars.Tab, "    ") 'Replace tab with 4 spaces
        sLine = sLine.Trim

        Do While sLine.Length > 0
            sData = ""

            If regQuote.IsMatch(sLine) Then
                mc = regQuote.Matches(sLine)
                '
                ' "text",<rest of the line>
                '
                m = regQuote.Match(sLine)
                sData = m.Groups(2).Value
                sLine = m.Groups(5).Value
            ElseIf regQuoteLast.IsMatch(sLine) Then
                '
                ' "text"
                '
                m = regQuoteLast.Match(sLine)
                sData = m.Groups(2).Value
                sLine = ""
            ElseIf regNormal.IsMatch(sLine) Then
                '
                ' text,<rest of the line>
                '
                m = regNormal.Match(sLine)
                sData = m.Groups(1).Value
                sLine = m.Groups(3).Value
            ElseIf regNormalLast.IsMatch(sLine) Then
                '
                ' text
                '
                m = regNormalLast.Match(sLine)
                sData = m.Groups(0).Value
                sLine = ""
            Else
                '
                ' ERROR!!!!!
                '
                sData = ""
                sLine = ""
            End If

            sData = sData.Trim
            sLine = sLine.Trim

            If mData Is Nothing Then
                ReDim mData(0)
                idx = 0
            Else
                idx = mData.GetUpperBound(0) + 1
                ReDim Preserve mData(idx)
            End If

            mData(idx) = sData
        Loop
    End Sub
#End Region
#Region " Regular Expressions "
    '
    ' Set up Regular Expressions
    '
    Private Sub SetupRegEx()
        Dim sQuote As String = "^(%Q)(.*)(%Q)(\s*%S)(.*)$"
        Dim sNormal As String = "^([^%S]*)(\s*%S)(.*)$"
        Dim sQuoteLast As String = "^(%Q)(.*)(%Q$)"
        Dim sNormalLast As String = "^.*$"
        Dim sSep As String
        Dim sQual As String

        If Not regQuote Is Nothing Then regQuote = Nothing
        If Not regNormal Is Nothing Then regNormal = Nothing
        If Not regQuoteLast Is Nothing Then regQuoteLast = Nothing
        If Not regNormalLast Is Nothing Then regNormalLast = Nothing

        sSep = mSeparator
        sQual = mTextQualifier

        If InStr(".$^{[(|)]}*+?\", sSep) > 0 Then sSep = "\" & sSep
        If InStr(".$^{[(|)]}*+?\", sQual) > 0 Then sQual = "\" & sQual

        sQuote = sQuote.Replace("%S", sSep)
        sQuote = sQuote.Replace("%Q", sQual)
        sNormal = sNormal.Replace("%S", sSep)
        sQuoteLast = sQuoteLast.Replace("%Q", sQual)

        regQuote = New Regex(sQuote, RegexOptions.IgnoreCase + RegexOptions.RightToLeft)
        regNormal = New Regex(sNormal, RegexOptions.IgnoreCase + RegexOptions.RightToLeft)
        regQuoteLast = New Regex(sQuoteLast, RegexOptions.IgnoreCase + RegexOptions.RightToLeft)
        regNormalLast = New Regex(sNormalLast, RegexOptions.IgnoreCase + RegexOptions.RightToLeft)
    End Sub
#End Region
#Region " Save As "
    '
    ' Save data as XML
    '
    Public Sub SaveAsXML(ByVal sXMLFile As String)
        If dsCSV Is Nothing Then Exit Sub
        dsCSV.WriteXml(sXMLFile)
    End Sub

    '
    ' Save data as CSV
    '
    Public Sub SaveAsCSV(ByVal sCSVFile As String)
        If dsCSV Is Nothing Then Exit Sub

        Dim dr As DataRow
        Dim sLine As String
        Dim sw As New StreamWriter(sCSVFile)
        Dim iCol As Integer

        For Each dr In dsCSV.Tables("CSVData").Rows
            sLine = ""
            For iCol = 0 To dsCSV.Tables("CSVData").Columns.Count - 1
                If sLine.Length > 0 Then sLine &= mSeparator
                If Not dr(iCol) Is DBNull.Value Then
                    If InStr(dr(iCol), mSeparator) > 0 Then
                        sLine &= mTextQualifier & dr(iCol) & mTextQualifier
                    Else
                        sLine &= dr(iCol)
                    End If
                End If
            Next

            sw.WriteLine(sLine)
        Next

        sw.Flush()
        sw.Close()
        sw = Nothing
    End Sub
#End Region
#Region " Properties "
    '
    ' Separator Property
    '
    Public Property Separator() As Char
        Get
            Return mSeparator
        End Get
        Set(ByVal Value As Char)
            mSeparator = Value
            SetupRegEx()
        End Set
    End Property

    '
    ' Qualifier Property
    '
    Public Property TextQualifier() As Char
        Get
            Return mTextQualifier
        End Get
        Set(ByVal Value As Char)
            mTextQualifier = Value
            SetupRegEx()
        End Set
    End Property

    '
    ' Dataset Property
    '
    Public ReadOnly Property CSVDataSet() As DataSet
        Get
            Return dsCSV
        End Get
    End Property
#End Region
#Region " Dispose and Finalize "
    '
    ' Dispose
    '
    Public Sub Dispose() Implements System.IDisposable.Dispose
        Dispose(True)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Disposed Then Exit Sub

        If disposing Then
            Disposed = True

            GC.SuppressFinalize(Me)
        End If

        If Not dsCSV Is Nothing Then
            dsCSV.Clear()
            dsCSV.Tables.Clear()
            dsCSV.Dispose()
            dsCSV = Nothing
        End If
    End Sub

    '
    ' Finalize
    '
    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub
#End Region
End Class

#End Region