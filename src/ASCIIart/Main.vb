Imports System.Drawing
Imports System.IO

Module Main
    'CONF
    Dim charsize As Byte = 96 'em. The accuracy depends on this.
    Dim targets As String() =
    {
     "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
     "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
     "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
     "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
     "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
     " ", "!", """", "#", "$", "%", "&", "'", "(", ")", "*", "+", ",", "-", ".", "/",
     "[", "\", "]", "^", "_", "`", ":", ";", "<", "=", ">", "?", "@", "{", "|", "}", "~",
     "░", "▒", "▓", "╬"
    }

    Sub Main()
        Dim map As Dictionary(Of Double, String) = genmap.genmap(targets)
        Dim mapls = map.Keys.ToList 'map index, making easier to search. If Key is searched here, value will be acquired from the dictionary.
        mapls.Sort()

        Dim newmap As List(Of String) = New List(Of String)
        For Each a In mapls
            newmap.Add(map(a))
        Next

        Console.Write("Drop image file here and hit <Enter> if necessary> ")
        Dim imgpath As String = Console.ReadLine()
        Console.Write("Resolution? (seperate with LOWERCASE *; ex: 800*600) (Just press <Enter> to not resize)> ")
        Dim resraw As String = Console.ReadLine()
        Console.Write("Destination?> ")
        Dim dest As String = Console.ReadLine
        Console.Write("In Colour? Pressing Enter or invalid response will mean Yes (Y/N) ")
        Dim black As Boolean = False
        If Console.ReadLine.ToLower = "n" Then black = True
        Dim img As Bitmap = loadimg.loadimg(imgpath)

        Dim imgsize As Size
        If resraw = "" Then
            imgsize = img.Size 'load image, get size
        Else
            Dim sizear As String() = resraw.Split("*")
            imgsize = New Size(sizear(0), sizear(1))
        End If
        'Resize img
        img = New Bitmap(img, imgsize)
        Console.WriteLine($"The Image resolution is {img.Size}")

        Try
            IO.File.Delete(dest)
        Catch ex As FileNotFoundException
            'Do Nothing.
        Catch ey As Exception
            Console.WriteLine("Critical Error while attempting to delete file. The program cannot continue.")
            Console.WriteLine(ey.ToString)
        End Try
        If Not HTML(black, img, dest, newmap) Then
            Console.WriteLine("ERROR!")
            End
        End If

        Console.WriteLine($"Done.{Environment.NewLine}Press any key to Continue...")
        Console.ReadKey()
    End Sub

    Function getclosetchar(brightness As Double, map As List(Of String)) As String
        'prevent div/0
        If brightness = 0 Then
            Return map(0)
        End If
        Dim interp As Byte = Math.Round(map.Count * brightness / 255)
        If Not interp <= 1 Then
            interp -= 1
        End If
        Return map(interp)
    End Function

End Module
