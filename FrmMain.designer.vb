<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Autoruns32ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Autoruns64ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnsignedAppToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NonZeroDetectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ATWorker = New System.ComponentModel.BackgroundWorker()
        Me.LvCSV = New AutorunsHelper.CustomListView()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 1
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.txtOutput, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.ProgressBar, 0, 2)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 3
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(641, 570)
        Me.TableLayoutPanel.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox)
        Me.Panel1.Controls.Add(Me.LvCSV)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(635, 436)
        Me.Panel1.TabIndex = 4
        '
        'txtOutput
        '
        Me.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOutput.Location = New System.Drawing.Point(3, 445)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.Size = New System.Drawing.Size(635, 104)
        Me.txtOutput.TabIndex = 1
        '
        'ProgressBar
        '
        Me.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBar.Location = New System.Drawing.Point(3, 555)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(635, 12)
        Me.ProgressBar.TabIndex = 2
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ScanToolStripMenuItem, Me.HistoryToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(641, 24)
        Me.MenuStrip.TabIndex = 3
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Autoruns32ToolStripMenuItem, Me.Autoruns64ToolStripMenuItem})
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'Autoruns32ToolStripMenuItem
        '
        Me.Autoruns32ToolStripMenuItem.Name = "Autoruns32ToolStripMenuItem"
        Me.Autoruns32ToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.Autoruns32ToolStripMenuItem.Text = "Autoruns32"
        '
        'Autoruns64ToolStripMenuItem
        '
        Me.Autoruns64ToolStripMenuItem.Name = "Autoruns64ToolStripMenuItem"
        Me.Autoruns64ToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.Autoruns64ToolStripMenuItem.Text = "Autoruns64"
        '
        'ScanToolStripMenuItem
        '
        Me.ScanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllToolStripMenuItem, Me.UnsignedAppToolStripMenuItem})
        Me.ScanToolStripMenuItem.Name = "ScanToolStripMenuItem"
        Me.ScanToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.ScanToolStripMenuItem.Text = "Scan"
        '
        'AllToolStripMenuItem
        '
        Me.AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        Me.AllToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.AllToolStripMenuItem.Text = "All"
        '
        'UnsignedAppToolStripMenuItem
        '
        Me.UnsignedAppToolStripMenuItem.Name = "UnsignedAppToolStripMenuItem"
        Me.UnsignedAppToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.UnsignedAppToolStripMenuItem.Text = "Unsigned App"
        '
        'HistoryToolStripMenuItem
        '
        Me.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem"
        Me.HistoryToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.HistoryToolStripMenuItem.Text = "History"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllToolStripMenuItem1, Me.NonZeroDetectionToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.ViewToolStripMenuItem.Text = "View Mode"
        '
        'AllToolStripMenuItem1
        '
        Me.AllToolStripMenuItem1.Name = "AllToolStripMenuItem1"
        Me.AllToolStripMenuItem1.Size = New System.Drawing.Size(183, 22)
        Me.AllToolStripMenuItem1.Text = "All"
        '
        'NonZeroDetectionToolStripMenuItem
        '
        Me.NonZeroDetectionToolStripMenuItem.Name = "NonZeroDetectionToolStripMenuItem"
        Me.NonZeroDetectionToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.NonZeroDetectionToolStripMenuItem.Text = "Non-Zero-Detection"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ATWorker
        '
        '
        'LvCSV
        '
        Me.LvCSV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvCSV.Location = New System.Drawing.Point(0, 0)
        Me.LvCSV.Name = "LvCSV"
        Me.LvCSV.Size = New System.Drawing.Size(635, 436)
        Me.LvCSV.TabIndex = 2
        Me.LvCSV.UseCompatibleStateImageBehavior = False
        '
        'PictureBox
        '
        Me.PictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox.Image = Global.AutorunsHelper.My.Resources.Resources.Loading
        Me.PictureBox.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(635, 436)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox.TabIndex = 3
        Me.PictureBox.TabStop = False
        Me.PictureBox.Visible = False
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(641, 594)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.MenuStrip)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "FrmMain"
        Me.Text = "Autoruns Helper"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OFD As OpenFileDialog
    Friend WithEvents TableLayoutPanel As TableLayoutPanel
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Autoruns32ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Autoruns64ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnsignedAppToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ATWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NonZeroDetectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents LvCSV As CustomListView
    Friend WithEvents PictureBox As PictureBox
End Class
