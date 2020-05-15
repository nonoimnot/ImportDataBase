<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Dt_Begin = New System.Windows.Forms.DateTimePicker()
        Me.Dt_End = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Nud_Duration = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.Nud_Duration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dt_Begin
        '
        Me.Dt_Begin.Location = New System.Drawing.Point(132, 12)
        Me.Dt_Begin.Name = "Dt_Begin"
        Me.Dt_Begin.Size = New System.Drawing.Size(164, 22)
        Me.Dt_Begin.TabIndex = 0
        Me.Dt_Begin.Value = New Date(2019, 1, 1, 0, 0, 0, 0)
        '
        'Dt_End
        '
        Me.Dt_End.Location = New System.Drawing.Point(132, 50)
        Me.Dt_End.Name = "Dt_End"
        Me.Dt_End.Size = New System.Drawing.Size(164, 22)
        Me.Dt_End.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(116, 123)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 29)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Begin Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "End Date"
        '
        'Nud_Duration
        '
        Me.Nud_Duration.Location = New System.Drawing.Point(212, 87)
        Me.Nud_Duration.Name = "Nud_Duration"
        Me.Nud_Duration.Size = New System.Drawing.Size(84, 22)
        Me.Nud_Duration.TabIndex = 5
        Me.Nud_Duration.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Day for Analyze"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 164)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Nud_Duration)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Dt_End)
        Me.Controls.Add(Me.Dt_Begin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Date to Import"
        CType(Me.Nud_Duration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Dt_Begin As DateTimePicker
    Friend WithEvents Dt_End As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Nud_Duration As NumericUpDown
    Friend WithEvents Label3 As Label
End Class
