Public Class Form1
    Dim z As Integer
    Dim y As Integer
    Dim kk As Double
    Dim ll As Double
    Dim pp As Point
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim p As System.Drawing.Pen = New System.Drawing.Pen(Brushes.Black, 1)
        Dim gr As System.Drawing.Graphics = Me.CreateGraphics
        gr.DrawLine(p, 47, 220, 500, 220)
        gr.DrawLine(p, 47, 440, 500, 440)
        gr.DrawLine(p, 47, 220, 47, 440)
        gr.DrawLine(p, 500, 220, 500, 440)
        Dim pp As System.Drawing.Pen = New System.Drawing.Pen(Brushes.Black, 1)
        gr.DrawLine(pp, 200, 190, 200, 250)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Val(TextBox1.Text) > 90 Or Val(TextBox1.Text) < 0 Then
            MsgBox("You should not input a value greater than Or less than 90,", MsgBoxStyle.Exclamation, "Error")
            TextBox1.Text = ""
        Else
            Try
                ListBox1.Items.Clear()
                ListBox1.Items.Add("")
                ListBox1.Items.Add("Refractive Index of Glass (n) = 1.5 and Incident Ray = " & TextBox1.Text)
                ListBox1.Items.Add("    Using Snell's Law; Sini/Sinr = n")
                ListBox1.Items.Add("                       Sin (" & TextBox1.Text & ") / Sinr = 1.5 ")
                ListBox1.Items.Add("           r = Sin-1 (" & CStr(Math.Sin(Val(TextBox1.Text) / (180 / CStr(Math.PI)))) & ") / 1.5)")
                ListBox1.Items.Add("           r = Sin-1 (" & (CStr(Math.Sin(Val(TextBox1.Text) / (180 / CStr(Math.PI))))) / 1.5 & ")")
                Dim x As Double = (CStr(Math.Sin(Val(TextBox1.Text) / (180 / CStr(Math.PI))))) / 1.5
                Dim py As Double = CStr(Math.Asin(x)) * (180 / CStr(Math.PI))
                ListBox1.Items.Add("           r = " & CStr(Math.Round(py, 2)))
                kk = CStr(Math.Round(py, 2))
                ListBox1.Items.Add("Emergent Ray = Incident Ray = " & TextBox1.Text)
                Dim p As System.Drawing.Pen = New System.Drawing.Pen(Brushes.Red, 1)
                Dim gr As System.Drawing.Graphics = Me.CreateGraphics
                gr.Clear(Color.White)
                Dim ang As Double = 90 - (180 + Val(TextBox1.Text))
                Dim x1 As Integer = 200
                Dim y1 As Integer = 220
                Dim x2 As Integer = 100 * CStr(Math.Cos((ang / (180 / CStr(Math.PI))))) + x1
                Dim y2 As Integer = 100 * CStr(Math.Sin((ang / (180 / CStr(Math.PI))))) + y1
                gr.DrawLine(p, x1, y1, x2, y2)
                Dim xx1 As Integer = 200
                Dim yy1 As Integer = 220
                Dim g As Double = CStr(Math.Asin(x)) * (180 / CStr(Math.PI))
                Dim ang1 As Double = 90 - g
                Dim xx2 As Integer = 400 * CStr(Math.Cos((ang1 / (180 / CStr(Math.PI))))) + xx1
                Dim yy2 As Integer = 400 * CStr(Math.Sin((ang1 / (180 / CStr(Math.PI))))) + yy1
                gr.DrawLine(p, xx1, yy1, xx2, yy2)
                Dim A As New Point(xx1, yy1)
                Dim B As New Point(xx2, yy2)
                Dim C As New Point(47, 440)
                Dim D As New Point(500, 440)
                Dim dy1 As Double = B.Y - A.Y
                Dim dx1 As Double = B.X - A.X
                Dim dy2 As Double = D.Y - C.Y
                Dim dx2 As Double = D.X - C.X
                Dim xa As Integer = ((C.Y - A.Y) * dx1 * dx2 + dy1 * dx2 * A.X - dy2 * dx1 * C.X) / (dy1 * dx2 - dy2 * dx1)
                Dim ya As Integer = A.Y + (dy1 / dx1) * (xa - A.X)
                pp = New Point(xa, ya)
                Dim px As System.Drawing.Pen = New System.Drawing.Pen(Brushes.White, 10)
                z = pp.X
                PictureBox1.Visible = True
                Timer2.Enabled = True
            Catch ex As Exception
                If Val(TextBox1.Text) = 0 Or TextBox1.Text = "" Then
                    Label9.Location = New Point(170, 445)
                End If
            End Try
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        y = y + 1
        PictureBox1.Visible = False
        Dim p As System.Drawing.Pen = New System.Drawing.Pen(Brushes.Red, 1)
        Dim pu As System.Drawing.Pen = New System.Drawing.Pen(Brushes.Black, 1)
        Dim gr As System.Drawing.Graphics = Me.CreateGraphics
        Dim xxx1 As Integer = z
        Dim yyy1 As Integer = pp.Y
        Dim ang2 As Double = 90 - (Val(TextBox1.Text))
        Dim xxx2 As Integer = 100 * CStr(Math.Cos((ang2 / (180 / CStr(Math.PI))))) + xxx1
        Dim yyy2 As Integer = 100 * CStr(Math.Sin((ang2 / (180 / CStr(Math.PI))))) + yyy1
        gr.DrawLine(p, xxx1, yyy1, xxx2, yyy2)
        gr.DrawLine(pu, z, pp.Y - 30, z, pp.Y + 30)
        Label9.Location = New Point(z - 30, 445)
        i.Text = TextBox1.Text
        r.Text = kk
        ee.Text = "Incident Ray = " & TextBox1.Text
        If y = 2 Then
            y = 0
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
        Form2.Focus()
    End Sub
End Class
