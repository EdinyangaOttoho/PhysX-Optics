Public Class Form2
    Dim kk As Double
    Dim Ppp As Point
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim P As System.Drawing.Pen = New System.Drawing.Pen(Brushes.Black, 1)
        Dim gr As System.Drawing.Graphics = Me.CreateGraphics
        Dim x1 As Integer = 158
        Dim y1 As Integer = 524
        Dim x2 As Integer = 250 * CStr(Math.Cos(-60 / (180 / Math.PI))) + x1
        Dim y2 As Integer = 250 * CStr(Math.Sin(-60 / (180 / Math.PI))) + y1
        gr.DrawLine(P, x1, y1, x2, y2)
        Dim xx1 As Integer = 282
        Dim yy1 As Integer = 308
        Dim xx2 As Integer = 250 * CStr(Math.Cos(60 / (180 / Math.PI))) + xx1
        Dim yy2 As Integer = 250 * CStr(Math.Sin(60 / (180 / Math.PI))) + yy1
        gr.DrawLine(P, xx1, yy1, xx2, yy2)
        gr.DrawLine(P, 158, 524, 408, 524)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim P As System.Drawing.Pen = New System.Drawing.Pen(Brushes.Black, 1)
        Dim gr As System.Drawing.Graphics = Me.CreateGraphics
        Dim x1 As Integer = 226
        Dim y1 As Integer = 405
        Dim x2 As Integer = 30 * CStr(Math.Cos(210 / (180 / Math.PI))) + x1
        Dim y2 As Integer = 30 * CStr(Math.Sin(210 / (180 / Math.PI))) + y1
        gr.DrawLine(P, x1, y1, x2, y2)
        Dim xx1 As Integer = 226
        Dim yy1 As Integer = 405
        Dim xx2 As Integer = 30 * CStr(Math.Cos(30 / (180 / Math.PI))) + xx1
        Dim yy2 As Integer = 30 * CStr(Math.Sin(30 / (180 / Math.PI))) + yy1
        gr.DrawLine(P, xx1, yy1, xx2, yy2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Val(TextBox1.Text) > 90 Or Val(TextBox1.Text) < 0 Then
            MsgBox("You should not input a value less than 0 or greater than 90")
        Else
            Try
                Dim P As System.Drawing.Pen = New System.Drawing.Pen(Brushes.Red, 1)
                Dim gr As System.Drawing.Graphics = Me.CreateGraphics
                gr.Clear(Color.White)
                Dim x1 As Integer = 226
                Dim y1 As Integer = 405
                Dim x2 As Integer = 100 * CStr(Math.Cos((210 - Val(TextBox1.Text)) / (180 / Math.PI))) + x1
                Dim y2 As Integer = 100 * CStr(Math.Sin((210 - Val(TextBox1.Text)) / (180 / Math.PI))) + y1
                gr.DrawLine(P, x1, y1, x2, y2)
                ListBox1.Items.Clear()
                ListBox1.Items.Add("")
                ListBox1.Items.Add("Refractive Index of Glass (n) = 1.5 and Incident Ray = " & TextBox1.Text)
                ListBox1.Items.Add("    Using Snell's Law; Sini/Sinr = n")
                ListBox1.Items.Add("                       Sin (" & TextBox1.Text & ") / Sinr = 1.5 ")
                ListBox1.Items.Add("           r = Sin-1 (" & CStr(Math.Sin(Val(TextBox1.Text) / (180 / CStr(Math.PI)))) & ") / 1.5)")
                ListBox1.Items.Add("           r = Sin-1 (" & (CStr(Math.Sin(Val(TextBox1.Text) / (180 / CStr(Math.PI))))) / 1.5 & ")")
                Dim x As Double = (CStr(Math.Sin(Val(TextBox1.Text) / (180 / CStr(Math.PI))))) / 1.5
                Dim py As Double = CStr(Math.Asin(x)) * (180 / CStr(Math.PI))
                kk = CStr(Math.Round(py, 2))
                ListBox1.Items.Add("           r = " & CStr(Math.Round(py, 2)))
                Dim xx1 As Integer = 226
                Dim yy1 As Integer = 405
                Dim k As Double = (CStr(Math.Sin(Val(TextBox1.Text) / (180 / Math.PI)))) / 1.5
                Dim l As Double = CStr(Math.Asin(k) * (180 / Math.PI))
                Dim xx2 As Integer = 300 * CStr(Math.Cos((390 - l) / (180 / Math.PI))) + x1
                Dim yy2 As Integer = 300 * CStr(Math.Sin((390 - l) / (180 / Math.PI))) + y1
                gr.DrawLine(P, xx1, yy1, xx2, yy2)
                Dim A As New Point(226, 405)
                Dim B As New Point(xx2, yy2)
                Dim C As New Point(282, 308)
                Dim D As New Point(406, 523)
                Dim dy1 As Double = B.Y - A.Y
                Dim dx1 As Double = B.X - A.X
                Dim dy2 As Double = D.Y - C.Y
                Dim dx2 As Double = D.X - C.X
                Dim xa As Integer = ((C.Y - A.Y) * dx1 * dx2 + dy1 * dx2 * A.X - dy2 * dx1 * C.X) / (dy1 * dx2 - dy2 * dx1)
                Dim ya As Integer = A.Y + (dy1 / dx1) * (xa - A.X)
                Dim pp As Point = New Point(xa, ya)
                Dim px As System.Drawing.Pen = New System.Drawing.Pen(Brushes.White, 10)
                gr.DrawLine(px, pp.X, pp.Y, xx2, yy2)
                Dim ox1 As Integer = pp.X
                Dim oy1 As Integer = pp.Y
                Dim ox2 As Integer = 30 * CStr(Math.Cos((330) / (180 / Math.PI))) + ox1
                Dim oy2 As Integer = 30 * CStr(Math.Sin((330) / (180 / Math.PI))) + oy1
                Dim pv As System.Drawing.Pen = New System.Drawing.Pen(Brushes.Black, 1)
                gr.DrawLine(pv, ox1, oy1, ox2, oy2)

                Dim oxx1 As Integer = pp.X
                Dim oyy1 As Integer = pp.Y
                Dim oxx2 As Integer = 30 * CStr(Math.Cos((150) / (180 / Math.PI))) + oxx1
                Dim oyy2 As Integer = 30 * CStr(Math.Sin((150) / (180 / Math.PI))) + oyy1
                gr.DrawLine(pv, oxx1, oyy1, oxx2, oyy2)
                Dim g As Double = Val(TextBox1.Text) / (0.030570148 * kk)
                ox2 = 100 * CStr(Math.Cos((330 + g) / (180 / Math.PI))) + ox1
                oy2 = 100 * CStr(Math.Sin((330 + g) / (180 / Math.PI))) + oy1
                gr.DrawLine(P, oxx1, oyy1, ox2, oy2)
                Ppp = New Point(pp)
                ListBox1.Items.Add("    Emergent Ray = " & CStr(Math.Round(g, 2)) & " (By mensuration)")
                ee.Text = CStr(Math.Round(g, 2))
                i.Text = TextBox1.Text
                r.Text = kk
            Catch ex As Exception
              
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim px As System.Drawing.Pen = New System.Drawing.Pen(Brushes.White, 10)
        Dim gr As System.Drawing.Graphics = Form1.CreateGraphics
        gr.Clear(Color.White)
        Form1.ListBox1.Items.Clear()
        Form1.TextBox1.Text = ""
        Form1.Show()
        Form1.Focus()
        Me.Close()
    End Sub
End Class
