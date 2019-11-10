Imports System.Drawing
Module genmap
    Function genmap(targets As String()) As Dictionary(Of Double, String)
        Dim dict As New Dictionary(Of Double, String)
        For Each it In targets
            Try
                dict.Add(calcBright(it), it)
            Catch ex As ArgumentException
                Continue For
            End Try
        Next
        Return dict
    End Function
    Function calcBright(character As String) As Double
        Using image As Bitmap = char2Img(character, 96)
            Dim total As Double = 0
            For x As Byte = 0 To image.Width - 1
                For y As Byte = 0 To image.Height - 1
                    Dim colordata As Color = image.GetPixel(x, y)
                    'Debug.WriteLine((CType(colordata.R, Double) + colordata.G + colordata.B) / 3)
                    total += (CType(colordata.R, Double) + colordata.G + colordata.B) / 3
                Next
            Next
            Return total / (image.Width * image.Height) 'divide by w*h(whole num. of pixels) to get average brightness
        End Using
    End Function

    Function char2Img(character As String, tsize As Byte) As Bitmap
        'size should be in em.
        Dim fontname As String = "Courier New"
        Dim bitmap As Bitmap = New Bitmap(1, 1)
        Dim g As Graphics = Graphics.FromImage(bitmap)
        Dim f As Font = New Font(fontname, tsize, FontStyle.Bold)

        Dim csize As SizeF = New SizeF(g.MeasureString(character, f))
        bitmap = New Bitmap(bitmap, CInt(csize.Width), csize.Height)
        g = Graphics.FromImage(bitmap)
        'Draw
        g.Clear(Color.White)
        g.DrawString(character, f, Brushes.Black, 0, 0)
        g.Flush()

        g.Dispose()
        Return bitmap
    End Function
End Module
