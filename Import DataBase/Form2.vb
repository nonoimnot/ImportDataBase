Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.bg_time = Dt_Begin.Value()
        Form1.ed_time = DateAdd("d", 1, Dt_End.Value())
        Form1.diff_time = DateDiff(DateInterval.Day, Form1.bg_time, Form1.ed_time)
        Form1.AnalyzeDay = Nud_Duration.Value
        MsgBox("Import from Date  " & Form1.bg_time.ToString("dd-MM-yyyy", Form1._cultureENInfo) & "  to  " &
               Form1.ed_time.ToString("dd-MM-yyyy", Form1._cultureENInfo))
        'MsgBox(Form1.diff_time.ToString)
        If Form1.AnalyzeDay <= Form1.diff_time Then
            Me.Close()
        ElseIf Form1.AnalyzeDay > Form1.diff_time Then
            MsgBox("Analyze day is Over Data to Import !!")
            Form1.bg_time = DateSerial(2562, 1, 1)
            Form1.ed_time = Now()
            Form1.diff_time = DateDiff(DateInterval.Day, Form1.bg_time, Form1.ed_time)
            Form1.AnalyzeDay = 30
        End If
    End Sub
End Class