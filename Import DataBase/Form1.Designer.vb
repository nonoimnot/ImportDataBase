<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Bt_Im_to_MySql = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lb_status = New System.Windows.Forms.Label()
        Me.Lb_value = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DurationImportTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Bt_Analyze = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bt_Im_to_MySql
        '
        Me.Bt_Im_to_MySql.Location = New System.Drawing.Point(12, 38)
        Me.Bt_Im_to_MySql.Name = "Bt_Im_to_MySql"
        Me.Bt_Im_to_MySql.Size = New System.Drawing.Size(74, 29)
        Me.Bt_Im_to_MySql.TabIndex = 2
        Me.Bt_Im_to_MySql.Text = "Import All"
        Me.Bt_Im_to_MySql.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 85)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(376, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'BackgroundWorker1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(345, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Export from D:\Programming\Python\CK.mdb to MySql"
        '
        'Lb_status
        '
        Me.Lb_status.AutoSize = True
        Me.Lb_status.Location = New System.Drawing.Point(192, 45)
        Me.Lb_status.Name = "Lb_status"
        Me.Lb_status.Size = New System.Drawing.Size(89, 17)
        Me.Lb_status.TabIndex = 5
        Me.Lb_status.Text = "Label_status"
        '
        'Lb_value
        '
        Me.Lb_value.AutoSize = True
        Me.Lb_value.Location = New System.Drawing.Point(337, 65)
        Me.Lb_value.Name = "Lb_value"
        Me.Lb_value.Size = New System.Drawing.Size(46, 17)
        Me.Lb_value.TabIndex = 6
        Me.Lb_value.Text = "xxx  %"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(400, 28)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DurationImportTimeToolStripMenuItem})
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(68, 24)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'DurationImportTimeToolStripMenuItem
        '
        Me.DurationImportTimeToolStripMenuItem.Name = "DurationImportTimeToolStripMenuItem"
        Me.DurationImportTimeToolStripMenuItem.Size = New System.Drawing.Size(228, 26)
        Me.DurationImportTimeToolStripMenuItem.Text = "Duration Import Time"
        '
        'Bt_Analyze
        '
        Me.Bt_Analyze.Location = New System.Drawing.Point(92, 39)
        Me.Bt_Analyze.Name = "Bt_Analyze"
        Me.Bt_Analyze.Size = New System.Drawing.Size(72, 28)
        Me.Bt_Analyze.TabIndex = 8
        Me.Bt_Analyze.Text = "Analyze"
        Me.Bt_Analyze.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 153)
        Me.Controls.Add(Me.Bt_Analyze)
        Me.Controls.Add(Me.Lb_value)
        Me.Controls.Add(Me.Lb_status)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Bt_Im_to_MySql)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Data to MySql"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Bt_Im_to_MySql As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
    Friend WithEvents Lb_status As Label
    Friend WithEvents Lb_value As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DurationImportTimeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Bt_Analyze As Button
End Class
