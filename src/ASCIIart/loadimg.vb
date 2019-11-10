Imports System.Drawing
Module loadimg
    Function loadimg(path As String) As Bitmap
        Dim img As Image = rotateEXIF(Image.FromFile(path, False)) 'Load img, disable colour profile
        Return New Bitmap(img)
    End Function

    Function rotateEXIF(img As Image) As Image
        'some JPG files might store EXIF rotation property. If recognition is not performed,image might get squeezed.
        For Each prop In img.PropertyItems
            If prop.Id = 274 Then '0x0112, EXIF rotation.
                Debug.WriteLine("EXIF Rotation Found: Value is " & img.GetPropertyItem(274).Value(0).ToString)
                'No need to switch around sizes on 270&90 degrees rotation, since the user would type in based on exif.
                Select Case img.GetPropertyItem(274).Value(0)
                    Case 2
                        img.RotateFlip(RotateFlipType.RotateNoneFlipX)
                    Case 3
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone)
                    Case 4
                        img.RotateFlip(RotateFlipType.Rotate180FlipX)
                    Case 5
                        img.RotateFlip(RotateFlipType.Rotate90FlipX)
                    Case 6
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone)
                    Case 7
                        img.RotateFlip(RotateFlipType.Rotate270FlipX)
                    Case 8
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone)
                    Case Else
                        'val:1
                        'Do Nothing(Does not require rotation)
                End Select
            End If
        Next
        Return img
    End Function
End Module
