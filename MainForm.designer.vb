<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelRight = New System.Windows.Forms.Panel()
        Me.PictureBoxRight = New System.Windows.Forms.PictureBox()
        Me.LvRight = New AutorunsHelper.CustomListView()
        Me.PanelLeft = New System.Windows.Forms.Panel()
        Me.PictureBoxLeft = New System.Windows.Forms.PictureBox()
        Me.LvLeft = New AutorunsHelper.CustomListView()
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
        Me.OptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ATWorker = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelRight.SuspendLayout()
        CType(Me.PictureBoxRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLeft.SuspendLayout()
        CType(Me.PictureBoxLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 1
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.Controls.Add(Me.PanelMain, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.txtOutput, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.ProgressBar, 0, 2)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 3
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(827, 570)
        Me.TableLayoutPanel.TabIndex = 2
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.TableLayoutPanel1)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(3, 3)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(821, 436)
        Me.PanelMain.TabIndex = 4
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PanelRight, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelLeft, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(821, 436)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'PanelRight
        '
        Me.PanelRight.Controls.Add(Me.PictureBoxRight)
        Me.PanelRight.Controls.Add(Me.LvRight)
        Me.PanelRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelRight.Location = New System.Drawing.Point(413, 3)
        Me.PanelRight.Name = "PanelRight"
        Me.PanelRight.Size = New System.Drawing.Size(405, 430)
        Me.PanelRight.TabIndex = 1
        '
        'PictureBoxRight
        '
        Me.PictureBoxRight.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBoxRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxRight.Image = Global.AutorunsHelper.My.Resources.Resources.Loading
        Me.PictureBoxRight.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxRight.Name = "PictureBoxRight"
        Me.PictureBoxRight.Size = New System.Drawing.Size(405, 430)
        Me.PictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBoxRight.TabIndex = 5
        Me.PictureBoxRight.TabStop = False
        Me.PictureBoxRight.Visible = False
        '
        'LvRight
        '
        Me.LvRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvRight.Location = New System.Drawing.Point(0, 0)
        Me.LvRight.Name = "LvRight"
        Me.LvRight.Size = New System.Drawing.Size(405, 430)
        Me.LvRight.TabIndex = 4
        Me.LvRight.UseCompatibleStateImageBehavior = False
        '
        'PanelLeft
        '
        Me.PanelLeft.Controls.Add(Me.PictureBoxLeft)
        Me.PanelLeft.Controls.Add(Me.LvLeft)
        Me.PanelLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLeft.Location = New System.Drawing.Point(3, 3)
        Me.PanelLeft.Name = "PanelLeft"
        Me.PanelLeft.Size = New System.Drawing.Size(404, 430)
        Me.PanelLeft.TabIndex = 0
        '
        'PictureBoxLeft
        '
        Me.PictureBoxLeft.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxLeft.Image = Global.AutorunsHelper.My.Resources.Resources.Loading
        Me.PictureBoxLeft.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxLeft.Name = "PictureBoxLeft"
        Me.PictureBoxLeft.Size = New System.Drawing.Size(404, 430)
        Me.PictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBoxLeft.TabIndex = 5
        Me.PictureBoxLeft.TabStop = False
        Me.PictureBoxLeft.Visible = False
        '
        'LvLeft
        '
        Me.LvLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvLeft.Location = New System.Drawing.Point(0, 0)
        Me.LvLeft.Name = "LvLeft"
        Me.LvLeft.Size = New System.Drawing.Size(404, 430)
        Me.LvLeft.TabIndex = 4
        Me.LvLeft.UseCompatibleStateImageBehavior = False
        '
        'txtOutput
        '
        Me.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOutput.Location = New System.Drawing.Point(3, 445)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.Size = New System.Drawing.Size(821, 104)
        Me.txtOutput.TabIndex = 1
        '
        'ProgressBar
        '
        Me.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBar.Location = New System.Drawing.Point(3, 555)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(821, 12)
        Me.ProgressBar.TabIndex = 2
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ScanToolStripMenuItem, Me.HistoryToolStripMenuItem, Me.OptionToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(827, 24)
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
        'OptionToolStripMenuItem
        '
        Me.OptionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartupToolStripMenuItem})
        Me.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem"
        Me.OptionToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.OptionToolStripMenuItem.Text = "Option"
        '
        'StartupToolStripMenuItem
        '
        Me.StartupToolStripMenuItem.Name = "StartupToolStripMenuItem"
        Me.StartupToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.StartupToolStripMenuItem.Text = "Startup"
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
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(827, 594)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.MenuStrip)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MainForm"
        Me.Text = "Autoruns Helper"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PanelRight.ResumeLayout(False)
        CType(Me.PictureBoxRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLeft.ResumeLayout(False)
        CType(Me.PictureBoxLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
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
    Friend WithEvents PanelMain As Panel
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OptionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PanelRight As Panel
    Friend WithEvents PictureBoxRight As PictureBox
    Friend WithEvents LvRight As CustomListView
    Friend WithEvents PanelLeft As Panel
    Friend WithEvents PictureBoxLeft As PictureBox
    Friend WithEvents LvLeft As CustomListView
End Class
