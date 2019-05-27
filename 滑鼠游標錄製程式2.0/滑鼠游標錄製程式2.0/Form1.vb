Public Class Form1
    ' 參考資料: https://social.msdn.microsoft.com/Forums/en-US/05e7236e-1b98-43fc-9769-c1ccdbfbff46/monitor-keys?forum=Vsexpressvb
    '操考資料:http://www.programmer-club.com.tw/ShowSameTitleN/vcdotnet/3234.html
    '參考資料:http://myvbdiary.blogspot.tw/2007/12/textbox.html
    '參考資料: https://tw.answers.yahoo.com/question/index?qid=20141201000015KK03610
    Dim ti As Integer = 30000
    Dim a(6000), b(6000) As Integer
    Dim i As Integer = 0
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer
    Dim WithEvents Tmr As New Timer
    Private Sub Tmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tmr.Tick
        Tmr.Stop()
        If CBool(GetAsyncKeyState(Keys.ControlKey)) And CBool(GetAsyncKeyState(Keys.U)) Then
            ti = 0
            Label2.Text = "錄製中"
        End If
        If CBool(GetAsyncKeyState(Keys.ControlKey)) And CBool(GetAsyncKeyState(Keys.I)) Then
            ti = 30000
            Label2.Text = "等待中"
        End If
        If CBool(GetAsyncKeyState(Keys.ControlKey)) And CBool(GetAsyncKeyState(Keys.O)) Then
            ti = 6000
            Label2.Text = "播放中"
        End If
        If CBool(GetAsyncKeyState(Keys.ControlKey)) And CBool(GetAsyncKeyState(Keys.M)) Then
            Shell("滑鼠游標錄製程式", vbNormalFocus)
            End
        End If
        Tmr.Start()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        On Error GoTo oo
        ti += 1
        If ti < 6000 And ti > 0 Then
            a(i) = Cursor.Position.X
            b(i) = Cursor.Position.Y
            i += 1
        End If
        If ti = 6000 Then
            ti = 30000
        End If
        If ti = 6001 Then
            i = 0
        End If
        If ti > 6001 And ti < 12000 Then
            i += 1
            If a(i) = 0 And b(i) = 0 Then
                ti = 30000
                Label2.Text = "等待中"
            Else
                Cursor.Position = New System.Drawing.Point(a(i), b(i))
            End If
        End If
        If ti = -100 Then
oo:         ti = 30000
            Label2.Text = "等待中"
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label2.Text = "播放中"
        ti = 6000
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label2.Text = "錄製中"
        ti = 0
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadioButton1.Select()
        Label2.Text = "等待中"
        Tmr.Interval = 100
        Tmr.Start()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label2.Text = "等待中"
        ti = 30000
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Shell("滑鼠游標錄製程式2.0.exe", vbNormalFocus)
        End
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Timer1.Interval = 1000
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Timer1.Interval = 500
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Timer1.Interval = 200
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Timer1.Interval = 100
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Timer1.Interval = 50
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        Timer1.Interval = 25
    End Sub
End Class
