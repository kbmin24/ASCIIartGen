Imports System.Drawing
Imports System.IO
Module saver
    Function HTML(bw As Boolean, img As Bitmap, dest As String, map As List(Of String)) As Boolean
        Dim saver As StreamWriter = New StreamWriter(dest, True, System.Text.Encoding.UTF8)
        Try
            'prepare html
            saver.Write("<!DOCTYPE html><html><head><meta charset='utf-8'></head><body style=""font-family: 'Courier New';font-size:6px;letter-spacing:0px;font-weight:900;white-space:pre;line-height: 65%;"">")
            For y As Integer = 0 To img.Height - 1
                For x As Integer = 0 To img.Width - 1
                    Dim colordata As Color = img.GetPixel(x, y)
                    Dim brightness As Double = (CType(colordata.R, Double) + colordata.G + colordata.B) / 3
                    Dim appropriatechar As String = getclosetchar(brightness, map)
                    'prevent characters from affecting Web browser renderer
                    Select Case appropriatechar
                        Case " "
                            appropriatechar = "<span style='color:rgba(0,0,0,0)'>.</span>" 'transparent, but consumes space
                        Case "<"
                            appropriatechar = "&lt;"
                        Case ">"
                            appropriatechar = "&gt;"
                        Case "&"
                            appropriatechar = "&amp;"
                    End Select
                    If Not bw Then
                        saver.Write($"<span style='color:rgb({colordata.R},{colordata.G},{colordata.B})'>{appropriatechar}</span>")
                    Else
                        saver.Write(appropriatechar)
                    End If
                Next
                saver.Write("<br>")
                If y Mod 100 = 0 Then
                    Console.WriteLine($"{y.ToString} lines processed.")
                End If
            Next
            'close html
            saver.Write("</body></html>")
        Catch ex As Exception
            Console.WriteLine("EXCEPTION: ")
            Console.WriteLine(ex.ToString)
            Console.ReadKey()
            Return False
        End Try
        saver.Close()
        Return True
    End Function
End Module
